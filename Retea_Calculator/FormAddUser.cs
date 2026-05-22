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

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selectează tot rândul
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 58, 64); 
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            if (dataGridView1.Columns["SMS"] is DataGridViewCheckBoxColumn smsCol)
            {
                smsCol.FalseValue = false;
                smsCol.TrueValue = true;
            }

            if (dataGridView1.Columns["Apel"] is DataGridViewCheckBoxColumn apelCol)
            {
                apelCol.FalseValue = false;
                apelCol.TrueValue = true;
            }
        }
 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserInfo user = new UserInfo();
            user.Nume = txtNume.Text;
            user.Telefon = txtTelefon.Text;
            user.MAC = txtMAC.Text;

            users.Add(user);

            dataGridView1.Rows.Add(user.Nume, user.Telefon, user.MAC, false, false);
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
                users.Clear();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    UserInfo user = new UserInfo();
                    user.Nume = row.Cells["Nume"].Value?.ToString() ?? "";
                    user.Telefon = row.Cells["Telefon"].Value?.ToString() ?? "";
                    user.MAC = row.Cells["Mac"].Value?.ToString() ?? "";

                    user.PermiteSMS = Convert.ToBoolean(row.Cells["SMS"].Value);
                    user.PermiteApel = Convert.ToBoolean(row.Cells["Apel"].Value);

                    users.Add(user);
                }

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
                try
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
                        dataGridView1.Rows.Add(user.Nume, user.Telefon, user.MAC, user.PermiteSMS, user.PermiteApel);
                    }

                    MessageBox.Show("XML loaded!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la încărcare: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("config.xml not found");
            }
        }

        
    }

}
