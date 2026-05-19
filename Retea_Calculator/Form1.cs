using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Retea_Calculator
{
    public partial class Form1 : Form
    {
        List<UserInfo> users = new List<UserInfo>();
        SerialPort serialPort = new SerialPort();
        Timer gsmTimer = new Timer();
        private const string XmlFileName = "config.xml";

        public Form1()
        {
            InitializeComponent();
            gsmTimer.Interval = 2000;
            gsmTimer.Tick += GsmTimer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Nume", "Nume");
            dataGridView1.Columns.Add("Telefon", "Telefon");
            dataGridView1.Columns.Add("MAC", "MAC Address");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            listViewLog.View = View.Details;
            listViewLog.FullRowSelect = true;
            listViewLog.GridLines = true;
            listViewLog.Columns.Add("Ora", 80);
            listViewLog.Columns.Add("Eveniment / Detalii", 450);

            LogeazaActivitate("Aplicatie pornita. Pregatit pentru conectare.");
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                users.RemoveAt(index);
                dataGridView1.Rows.RemoveAt(index);

            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            UserInfo user = new UserInfo();
            user.Nume = txtNume.Text;
            user.Telefon = txtTelefon.Text;
            user.MAC = txtMAC.Text;

            users.Add(user);

            dataGridView1.Rows.Add(user.Nume, user.Telefon, user.MAC);
            txtNume.Clear();
            txtTelefon.Clear();
            txtMAC.Clear();

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

        private void btnLoadXML_Click_1(object sender, EventArgs e)
        {
            if (File.Exists("config.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<UserInfo>));
                using (FileStream fs = new FileStream("config.xml", FileMode.Open))
                {
                    users = (List<UserInfo>)serializer.Deserialize(fs);
                }
                if (users == null)
                {
                    users = new List<UserInfo>();
                }
                dataGridView1.Rows.Clear();

                foreach (UserInfo user in users)
                {
                    dataGridView1.Rows.Add(user.Nume, user.Telefon, user.MAC);
                }
                LogeazaActivitate($"Au fost încărcați {users.Count} utilizatori din XML.");
                MessageBox.Show("XML loaded!");
            }
            else
            {
                MessageBox.Show("config.xml not found");
            }
        }

        private void btnConectare_Click(object sender, EventArgs e)
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

        private void btnDeconectare_Click(object sender, EventArgs e)
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

        private void btnAT_Click_1(object sender, EventArgs e)
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

        private void btnRefresh_Click(object sender, EventArgs e)
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
        private void GsmTimer_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen && serialPort.BytesToRead > 0)
            {
                try
                {
                    string datePrimite = serialPort.ReadExisting();

                    if (datePrimite.Contains("RING") && datePrimite.Contains("+CLIP:"))
                    {
                        ProceseazaApel(datePrimite);
                    }
                    else if (datePrimite.Contains("+CMTI:"))
                    {
                        LogeazaActivitate("Notificare SMS nou receptionata pe modem.");
                    }
                }
                catch (Exception ex)
                {
                    LogeazaActivitate($"Eroare in timpul citirii ciclice: {ex.Message}");
                }
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<UserInfo>));
                using (FileStream fs = new FileStream("config.xml", FileMode.Create))
                {
                    serializer.Serialize(fs, users);
                }

                LogeazaActivitate("Datele au fost salvate cu succes in config.xml.");
                MessageBox.Show("XML saved successfully!");
            }
            catch (Exception ex)
            {
                LogeazaActivitate($"Eroare la salvarea XML: {ex.Message}");
                MessageBox.Show($"Eroare la salvare: {ex.Message}");
            }
        }

        private void btn_add_user_form_Click(object sender, EventArgs e)
        {

        }
    }

}


  