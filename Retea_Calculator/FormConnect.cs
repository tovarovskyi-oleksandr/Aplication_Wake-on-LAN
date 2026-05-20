using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retea_Calculator
{ 
    public partial class FormConnect : Form
    {
        List<UserInfo> users = new List<UserInfo>();
        SerialPort serialPort = new SerialPort();
        Timer gsmTimer = new Timer();
        private const string XmlFileName = "config.xml";
        private string serialBuffer = "";
        public FormConnect()
        {
            InitializeComponent();
            gsmTimer.Interval = 2000;
            gsmTimer.Tick += GsmTimer_Tick;

            listViewLog.View = View.Details;
            listViewLog.FullRowSelect = true;
            listViewLog.GridLines = true;
            listViewLog.Columns.Add("Ora", 80);
            listViewLog.Columns.Add("Eveniment / Detalii", 450);

            IncarcaUtilizatoriDinXML();
            LogeazaActivitate("Aplicatie pornita. Pregatit pentru conectare.");
        }

        private void IncarcaUtilizatoriDinXML()
        {
            try
            {
                if (File.Exists(XmlFileName))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<UserInfo>));
                    using (FileStream fs = new FileStream(XmlFileName, FileMode.Open))
                    {
                        users = (List<UserInfo>)serializer.Deserialize(fs);
                    }
                    LogeazaActivitate($"Baza de date XML incarcata cu succes. {users.Count} utilizatori gasiti.");
                }
                else
                {
                    LogeazaActivitate("Atentie: Fișierul config.xml nu exista. Adauga utilizatori prima data!");
                }
            }
            catch (Exception ex)
            {
                LogeazaActivitate($"Eroare la incarcarea XML-ului: {ex.Message}");
            }
        }
        private void LogeazaActivitate(string mesaj)
        {
            if (listViewLog.InvokeRequired)
            {
                listViewLog.Invoke(new Action(() => LogeazaActivitate(mesaj)));
                return;
            }

            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            ListViewItem item = new ListViewItem(timestamp);
            item.SubItems.Add(mesaj);
            listViewLog.Items.Insert(0, item);
        }
        
        private void ProceseazaApel(string dateModem)
        {
            int indexClip = dateModem.IndexOf("+CLIP:");
            if (indexClip != -1)
            {
                int primaGhilimea = dateModem.IndexOf("\"", indexClip);
                int aDouaGhilimea = dateModem.IndexOf("\"", primaGhilimea + 1);

                if (primaGhilimea != -1 && aDouaGhilimea != -1)
                {
                    string numarApelant = dateModem.Substring(primaGhilimea + 1, aDouaGhilimea - primaGhilimea - 1);
                    LogeazaActivitate($"Apel detectat de la numarul: {numarApelant}");

                    serialPort.Write("ATH\r");
                    LogeazaActivitate("Comanda de respingere apel (ATH) trimisa.");

                    UserInfo utilizatorGasit = users.Find(u => u.Telefon.Trim() == numarApelant.Trim() ||
                                                               numarApelant.Contains(u.Telefon.Trim()));

                    if (utilizatorGasit != null)
                    {
                        LogeazaActivitate($"Utilizator autorizat identificat: {utilizatorGasit.Nume}");
                        TrimiteMagicPacket(utilizatorGasit.MAC);
                    }
                    else
                    {
                        LogeazaActivitate($"Numarul {numarApelant} nu a fost gasit in baza de date XML.");
                    }
                }
            }
        }
        private void ProceseazaSMS(string dateModem)
        {
            try
            {
                int indexCmti = dateModem.IndexOf("+CMTI:");
                if (indexCmti != -1)
                {
                    int ultimaVirgula = dateModem.IndexOf(",", indexCmti);
                    if (ultimaVirgula != -1)
                    {
                        string indexSMS = dateModem.Substring(ultimaVirgula + 1).Trim(new char[] { '\r', '\n', ' ', '"' });
                        LogeazaActivitate($"SMS nou detectat la indexul: {indexSMS}. Se citeste...");

                        serialPort.DiscardInBuffer();
                        serialPort.Write($"AT+CMGR={indexSMS}\r");

                        System.Threading.Thread.Sleep(500);
                        string raspunsSMS = serialPort.ReadExisting();

                        if (raspunsSMS.Contains("+CMGR:"))
                        {
                            int primaGhilimea = raspunsSMS.IndexOf("\"", raspunsSMS.IndexOf("+CMGR:"));
                            if (primaGhilimea != -1)
                            {
                                int aDouaGhilimea = raspunsSMS.IndexOf("\"", primaGhilimea + 1);
                                int aTreiaGhilimea = raspunsSMS.IndexOf("\"", aDouaGhilimea + 1);
                                int aPatraGhilimea = raspunsSMS.IndexOf("\"", aTreiaGhilimea + 1);

                                if (aTreiaGhilimea != -1 && aPatraGhilimea != -1)
                                {
                                    string numarExpeditor = raspunsSMS.Substring(aTreiaGhilimea + 1, aPatraGhilimea - aTreiaGhilimea - 1);
                                    LogeazaActivitate($"SMS primit de la numărul: {numarExpeditor}");

                                    int sfarsitAntet = raspunsSMS.IndexOf("\r\n", aPatraGhilimea);
                                    if (sfarsitAntet != -1)
                                    {
                                        string continutMesaj = raspunsSMS.Substring(sfarsitAntet).Replace("OK", "").Trim();
                                        LogeazaActivitate($"Continut SMS: \"{continutMesaj}\"");
                                    }

                                    ValideazaSiTrimiteWOL(numarExpeditor);
                                }
                            }
                        }

                        serialPort.Write($"AT+CMGD={indexSMS}\r");
                    }
                }
            }
            catch (Exception ex)
            {
                LogeazaActivitate($"Eroare la procesarea SMS-ului: {ex.Message}");
            }
        }
        private void ValideazaSiTrimiteWOL(string numarTelefon)
        {
            UserInfo utilizatorGasit = users.Find(u => u.Telefon.Trim() == numarTelefon.Trim() ||
                                                       numarTelefon.Contains(u.Telefon.Trim()) ||
                                                       u.Telefon.Trim().Contains(numarTelefon.Trim()));

            if (utilizatorGasit != null)
            {
                LogeazaActivitate($"Utilizator autorizat identificat: {utilizatorGasit.Nume}");
                TrimiteMagicPacket(utilizatorGasit.MAC);
            }
            else
            {
                LogeazaActivitate($"Numarul {numarTelefon} nu este in baza de date XML.");
            }
        }
        private void TrimiteMagicPacket(string macAddress)
        {
            try
            {
                string curatMAC = macAddress.Replace(":", "").Replace("-", "").Replace(" ", "");

                if (curatMAC.Length != 12)
                {
                    LogeazaActivitate($"Eroare WOL: Adresa MAC string are lungime invalida ({macAddress})");
                    return;
                }

                byte[] macBytes = new byte[6];
                for (int i = 0; i < 6; i++)
                {
                    macBytes[i] = byte.Parse(curatMAC.Substring(i * 2, 2), NumberStyles.HexNumber);
                }

                byte[] packet = new byte[102];
                for (int i = 0; i < 6; i++)
                {
                    packet[i] = 0xFF;
                }

                for (int i = 1; i <= 16; i++)
                {
                    Array.Copy(macBytes, 0, packet, i * 6, 6);
                }

                using (UdpClient client = new UdpClient())
                {
                    client.Connect(IPAddress.Broadcast, 9);
                    client.Send(packet, packet.Length);
                }

                LogeazaActivitate($"Magic Packet WOL trimis cu succes catre MAC: {macAddress}");
            }
            catch (Exception ex)
            {
                LogeazaActivitate($"Eroare la asamblarea/trimiterea pachetului WOL: {ex.Message}");
            }
        }
        private void GsmTimer_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen && serialPort.BytesToRead > 0)
            {
                try
                {
                    serialBuffer += serialPort.ReadExisting();

                    if (serialBuffer.Contains("RING") && serialBuffer.Contains("+CLIP:"))
                    {
                        ProceseazaApel(serialBuffer);
                        serialBuffer = "";
                    }
                    else if (serialBuffer.Contains("+CMTI:"))
                    {
                        ProceseazaSMS(serialBuffer);
                        serialBuffer = "";
                    }

                    if (serialBuffer.Length > 1000) serialBuffer = "";
                }
                catch (Exception ex)
                {
                    LogeazaActivitate($"Eroare citire port: {ex.Message}");
                }
            }
        }
        

        private void btnConectare_Click_1(object sender, EventArgs e)
        {
            try
            {
                serialPort.PortName = comboBox1.Text;
                serialPort.BaudRate = 115200;
                serialPort.Open();

                serialPort.Write("AT+CLIP=1\r");
                System.Threading.Thread.Sleep(200);
                serialPort.Write("AT+CMGF=1\r");
                System.Threading.Thread.Sleep(200);
                serialPort.DiscardInBuffer();

                serialPort.Write("AT+CNMI=2,1,0,0,0\r");
                System.Threading.Thread.Sleep(200);

                gsmTimer.Start();
                LogeazaActivitate($"Portul {serialPort.PortName} a fost deschis. Monitorizare pornita.");
                MessageBox.Show("GSM Connected!!!");
            }
            catch (Exception ex)
            {
                LogeazaActivitate($"Eroare la conectare: {ex.Message}");
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeconectare_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();
                    LogeazaActivitate("Portul serial a fost inchis. Monitorizare oprita.");
                    MessageBox.Show("GSM Disconnected successfully!");
                }
                else
                {
                    MessageBox.Show("The port is already closed or was never connected.");
                }
            }
            catch (Exception ex)
            {
                LogeazaActivitate($"Eroare la deconectare: {ex.Message}");
                MessageBox.Show("Error during disconnection: " + ex.Message);
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }
            if (comboBox1.SelectedIndex > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            LogeazaActivitate("Lista porturilor disponibile a fost reimprospatata.");
            MessageBox.Show("Ports loaded!");
        }
        private void btnSendCommand_Click_1(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.DiscardInBuffer();
                    string comandaMea = txtCommand.Text;
                    serialPort.Write(comandaMea + "\r");

                    LogeazaActivitate($"Comanda trimisa: {comandaMea}");

                    System.Threading.Thread.Sleep(500);
                    string response = serialPort.ReadExisting();

                    if (string.IsNullOrWhiteSpace(response))
                    {
                        LogeazaActivitate("Modulul a intors un raspuns gol.");
                        MessageBox.Show("Nu s-a primit niciun raspuns de la modul (raspuns gol).", "Raspuns vid");
                    }
                    else
                    {
                        LogeazaActivitate($"Raspuns primit: {response.Replace("\r\n", " ")}");
                        MessageBox.Show(response, "Raspuns de la modul");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la citire/scriere: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Port not connected!");
            }
        }
    }
}
