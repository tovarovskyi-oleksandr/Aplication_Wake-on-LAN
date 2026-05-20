using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Retea_Calculator
{
    public partial class FormAddUser : Form
    {
        List<UserInfo> users = new List<UserInfo>();
        SerialPort serialPort = new SerialPort();
        public FormAddUser()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("Nume", "Nume");
            dataGridView1.Columns.Add("Telefon", "Telefon");
            dataGridView1.Columns.Add("MAC", "MAC Address");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selectează tot rândul
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 58, 64); 
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
        }
 
        private void btnAdd_Click(object sender, EventArgs e)
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

        private void btnSterge_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                users.RemoveAt(index);
                dataGridView1.Rows.RemoveAt(index);

            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<UserInfo>));
                using (FileStream fs = new FileStream("config.xml", FileMode.Create))
                {
                    serializer.Serialize(fs, users);
                }


                MessageBox.Show("XML saved successfully!");
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Eroare la salvare: {ex.Message}");
            }
        }

        private void btnLoadXML_Click(object sender, EventArgs e)
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

                MessageBox.Show("XML loaded!");
            }
            else
            {
                MessageBox.Show("config.xml not found");
            }
        }

        
    }

}
