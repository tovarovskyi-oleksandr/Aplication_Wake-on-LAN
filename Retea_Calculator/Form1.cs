using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Retea_Calculator
{
    public partial class Form1 : Form
    {
        List<UserInfo> users = new List<UserInfo>();
        SerialPort serialPort = new SerialPort();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Nume", "Nume");
            dataGridView1.Columns.Add("Telefon", "Telefon");
            dataGridView1.Columns.Add("MAC", "MAC Address");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void btnLoadXML_Click_1(object sender, EventArgs e)
        {
            if (File.Exists("config.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<UserInfo>));
                using (FileStream fs = new FileStream("config.xml", FileMode.Open))
                {
                    users = (List<UserInfo>)serializer.Deserialize(fs);
                }

                dataGridView1.Rows.Clear();

                foreach (UserInfo user in users)
                {
                    dataGridView1.Rows.Add(user.Nume, user.Telefon, user.MAC);
                }
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
                MessageBox.Show("GSM Connected!!!");
            }
            catch (Exception ex)
            {
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
                    MessageBox.Show("GSM Disconnected successfully!");
                }
                else
                {
                    MessageBox.Show("The port is already closed or was never connected.");
                }
            }
            catch (Exception ex)
            {
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

                    System.Threading.Thread.Sleep(500);

                    string response = serialPort.ReadExisting();

                    if (string.IsNullOrWhiteSpace(response))
                    {
                        MessageBox.Show("Nu s-a primit niciun raspuns de la modul (raspuns gol).", "Raspuns vid");
                    }
                    else
                    {
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
            MessageBox.Show("Ports loaded!");
        }
    }
}


  