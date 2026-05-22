using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
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
        private FormAddUser formAddUserInstance;
        private FormConnect formConnectInstance;

        //Design 
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // Coordonata X stânga-sus
            int nTopRect,      // Coordonata Y stânga-sus
            int nRightRect,    // Coordonata X dreapta-jos (Lățimea)
            int nBottomRect,   // Coordonata Y dreapta-jos (Înălțimea)
            int nWidthEllipse, // Cât de mult să fie rotunjit colțul pe orizontală
            int nHeightEllipse // Cât de mult să fie rotunjit colțul pe verticală
        );

        public Form1()
        {
            InitializeComponent();

            //Design             
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            lblTitle.Text = "Add User";
            this.pnlFormLoader.Controls.Clear();
            FormAddUser FormAddUser_Vrb = new FormAddUser() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormAddUser_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FormAddUser_Vrb);
            FormAddUser_Vrb.Show();

            formAddUserInstance = new FormAddUser() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            formConnectInstance = new FormConnect() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };

            ShowFormInPanel(formAddUserInstance);
        }
        private void ShowFormInPanel(Form form)
        {
            this.pnlFormLoader.Controls.Clear();
            this.pnlFormLoader.Controls.Add(form);
            form.Show();
        }
        private void btn_add_user_form_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btn_add_user_form.Height;
            pnlNav.Top = btn_add_user_form.Top;
            pnlNav.Left = btn_add_user_form.Left;
            btn_add_user_form.BackColor = Color.FromArgb(52, 58, 64);

            //design
            lblTitle.Text = "Add User";
            this.pnlFormLoader.Controls.Clear();
            FormAddUser FormAddUser_Vrb = new FormAddUser() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormAddUser_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FormAddUser_Vrb);
            FormAddUser_Vrb.Show();
            ShowFormInPanel(formAddUserInstance);

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConnect_form_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnConnect_form.Height;
            pnlNav.Top = btnConnect_form.Top;
            pnlNav.Left = btnConnect_form.Left;
            btnConnect_form.BackColor = Color.FromArgb(52, 58, 64);

            lblTitle.Text = "Connect";
            this.pnlFormLoader.Controls.Clear();
            FormConnect FormConnect_Vrb = new FormConnect() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormConnect_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FormConnect_Vrb);
            FormConnect_Vrb.Show();

            ShowFormInPanel(formConnectInstance);
        }

        private void btn_add_user_form_Leave(object sender, EventArgs e)
        {
            btn_add_user_form.BackColor = Color.FromArgb(52, 58, 64);
        }

        private void btnConnect_form_Leave(object sender, EventArgs e)
        {
            btnConnect_form.BackColor = Color.FromArgb(52, 58, 64);
        }

       
    }

}


  