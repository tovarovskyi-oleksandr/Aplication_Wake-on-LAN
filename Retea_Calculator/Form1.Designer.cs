namespace Retea_Calculator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSterge = new System.Windows.Forms.Button();
            this.btnConectare = new System.Windows.Forms.Button();
            this.btnDeconectare = new System.Windows.Forms.Button();
            this.txtMAC = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.lblNume = new System.Windows.Forms.Label();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.lblMac = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoadXML = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAT = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(228, 285);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 34);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Adauga Utilizator";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnSterge
            // 
            this.btnSterge.Location = new System.Drawing.Point(338, 284);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(90, 35);
            this.btnSterge.TabIndex = 1;
            this.btnSterge.Text = "Sterge Utilizator";
            this.btnSterge.UseVisualStyleBackColor = true;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // btnConectare
            // 
            this.btnConectare.Location = new System.Drawing.Point(173, 325);
            this.btnConectare.Name = "btnConectare";
            this.btnConectare.Size = new System.Drawing.Size(138, 35);
            this.btnConectare.TabIndex = 2;
            this.btnConectare.Text = "Conectare/Deschide Port ";
            this.btnConectare.UseVisualStyleBackColor = true;
            this.btnConectare.Click += new System.EventHandler(this.btnConectare_Click);
            // 
            // btnDeconectare
            // 
            this.btnDeconectare.Location = new System.Drawing.Point(317, 325);
            this.btnDeconectare.Name = "btnDeconectare";
            this.btnDeconectare.Size = new System.Drawing.Size(136, 38);
            this.btnDeconectare.TabIndex = 3;
            this.btnDeconectare.Text = "Deconectare";
            this.btnDeconectare.UseVisualStyleBackColor = true;
            this.btnDeconectare.Click += new System.EventHandler(this.btnDeconectare_Click);
            // 
            // txtMAC
            // 
            this.txtMAC.Location = new System.Drawing.Point(437, 259);
            this.txtMAC.Name = "txtMAC";
            this.txtMAC.Size = new System.Drawing.Size(104, 20);
            this.txtMAC.TabIndex = 5;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(338, 259);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(90, 20);
            this.txtTelefon.TabIndex = 6;
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(228, 259);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(102, 20);
            this.txtNume.TabIndex = 7;
            // 
            // lblNume
            // 
            this.lblNume.AutoSize = true;
            this.lblNume.Location = new System.Drawing.Point(261, 243);
            this.lblNume.Name = "lblNume";
            this.lblNume.Size = new System.Drawing.Size(35, 13);
            this.lblNume.TabIndex = 8;
            this.lblNume.Text = "Nume";
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Location = new System.Drawing.Point(340, 243);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(88, 13);
            this.lblTelefon.TabIndex = 9;
            this.lblTelefon.Text = "Numar de telefon";
            // 
            // lblMac
            // 
            this.lblMac.AutoSize = true;
            this.lblMac.Location = new System.Drawing.Point(456, 243);
            this.lblMac.Name = "lblMac";
            this.lblMac.Size = new System.Drawing.Size(66, 13);
            this.lblMac.TabIndex = 10;
            this.lblMac.Text = "Adresa MAC";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(173, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(422, 208);
            this.dataGridView1.TabIndex = 11;
            // 
            // btnLoadXML
            // 
            this.btnLoadXML.Location = new System.Drawing.Point(437, 284);
            this.btnLoadXML.Name = "btnLoadXML";
            this.btnLoadXML.Size = new System.Drawing.Size(104, 34);
            this.btnLoadXML.TabIndex = 12;
            this.btnLoadXML.Text = "Load XML";
            this.btnLoadXML.UseVisualStyleBackColor = true;
            this.btnLoadXML.Click += new System.EventHandler(this.btnLoadXML_Click_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(459, 325);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(136, 38);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAT
            // 
            this.btnAT.Location = new System.Drawing.Point(317, 369);
            this.btnAT.Name = "btnAT";
            this.btnAT.Size = new System.Drawing.Size(136, 38);
            this.btnAT.TabIndex = 14;
            this.btnAT.Text = "Send AT";
            this.btnAT.UseVisualStyleBackColor = true;
            this.btnAT.Click += new System.EventHandler(this.btnAT_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3"});
            this.comboBox1.Location = new System.Drawing.Point(244, 417);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 21);
            this.comboBox1.TabIndex = 15;
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(386, 418);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(119, 20);
            this.txtCommand.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnAT);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLoadXML);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblMac);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.lblNume);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.txtMAC);
            this.Controls.Add(this.btnDeconectare);
            this.Controls.Add(this.btnConectare);
            this.Controls.Add(this.btnSterge);
            this.Controls.Add(this.btnAdd);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSterge;
        private System.Windows.Forms.Button btnConectare;
        private System.Windows.Forms.Button btnDeconectare;
        private System.Windows.Forms.TextBox txtMAC;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.Label lblNume;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.Label lblMac;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoadXML;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAT;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtCommand;
    }
}

