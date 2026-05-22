namespace Retea_Calculator
{
    partial class FormAddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddUser));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoadXML = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblMac = new System.Windows.Forms.Label();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.lblNume = new System.Windows.Forms.Label();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtMAC = new System.Windows.Forms.TextBox();
            this.btnSterge = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.Nume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SMS = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Apel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(168, 192);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(128, 34);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnLoadXML
            // 
            this.btnLoadXML.ForeColor = System.Drawing.Color.White;
            this.btnLoadXML.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadXML.Image")));
            this.btnLoadXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadXML.Location = new System.Drawing.Point(168, 232);
            this.btnLoadXML.Name = "btnLoadXML";
            this.btnLoadXML.Size = new System.Drawing.Size(128, 34);
            this.btnLoadXML.TabIndex = 27;
            this.btnLoadXML.Text = "Load XML";
            this.btnLoadXML.UseVisualStyleBackColor = false;
            this.btnLoadXML.Click += new System.EventHandler(this.btnLoadXML_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nume,
            this.Telefon,
            this.Mac,
            this.SMS,
            this.Apel});
            this.dataGridView1.Location = new System.Drawing.Point(338, -1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(544, 506);
            this.dataGridView1.TabIndex = 26;
            // 
            // lblMac
            // 
            this.lblMac.AutoSize = true;
            this.lblMac.ForeColor = System.Drawing.Color.White;
            this.lblMac.Location = new System.Drawing.Point(247, 149);
            this.lblMac.Name = "lblMac";
            this.lblMac.Size = new System.Drawing.Size(71, 13);
            this.lblMac.TabIndex = 25;
            this.lblMac.Text = "Address MAC";
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.ForeColor = System.Drawing.Color.White;
            this.lblTelefon.Location = new System.Drawing.Point(125, 149);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(76, 13);
            this.lblTelefon.TabIndex = 24;
            this.lblTelefon.Text = "Phone number";
            // 
            // lblNume
            // 
            this.lblNume.AutoSize = true;
            this.lblNume.ForeColor = System.Drawing.Color.White;
            this.lblNume.Location = new System.Drawing.Point(42, 149);
            this.lblNume.Name = "lblNume";
            this.lblNume.Size = new System.Drawing.Size(35, 13);
            this.lblNume.TabIndex = 23;
            this.lblNume.Text = "Nume";
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(8, 165);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(104, 20);
            this.txtNume.TabIndex = 22;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(118, 165);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(104, 20);
            this.txtTelefon.TabIndex = 21;
            // 
            // txtMAC
            // 
            this.txtMAC.Location = new System.Drawing.Point(228, 165);
            this.txtMAC.Name = "txtMAC";
            this.txtMAC.Size = new System.Drawing.Size(104, 20);
            this.txtMAC.TabIndex = 20;
            // 
            // btnSterge
            // 
            this.btnSterge.Font = new System.Drawing.Font("Reem Kufi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSterge.ForeColor = System.Drawing.Color.White;
            this.btnSterge.Image = ((System.Drawing.Image)(resources.GetObject("btnSterge.Image")));
            this.btnSterge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSterge.Location = new System.Drawing.Point(32, 232);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(128, 35);
            this.btnSterge.TabIndex = 19;
            this.btnSterge.Text = "Delete User";
            this.btnSterge.UseVisualStyleBackColor = false;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btnAdd.Font = new System.Drawing.Font("Reem Kufi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(32, 192);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 34);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "Add User";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Nume
            // 
            this.Nume.HeaderText = "Nume";
            this.Nume.Name = "Nume";
            // 
            // Telefon
            // 
            this.Telefon.HeaderText = "Telefon";
            this.Telefon.Name = "Telefon";
            // 
            // Mac
            // 
            this.Mac.HeaderText = "Mac";
            this.Mac.Name = "Mac";
            // 
            // SMS
            // 
            this.SMS.HeaderText = "SMS";
            this.SMS.Name = "SMS";
            // 
            // Apel
            // 
            this.Apel.HeaderText = "Apel";
            this.Apel.Name = "Apel";
            // 
            // FormAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1088, 610);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoadXML);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblMac);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.lblNume);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.txtMAC);
            this.Controls.Add(this.btnSterge);
            this.Name = "FormAddUser";
            this.Text = "FormAddUser";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoadXML;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblMac;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.Label lblNume;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtMAC;
        private System.Windows.Forms.Button btnSterge;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mac;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SMS;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Apel;
    }
}