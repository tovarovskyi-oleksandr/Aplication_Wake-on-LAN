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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogout_form = new System.Windows.Forms.Button();
            this.btnConnect_form = new System.Windows.Forms.Button();
            this.btn_add_user_form = new System.Windows.Forms.Button();
            this.pnlFormLoader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.pnlNav);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnLogout_form);
            this.panel1.Controls.Add(this.btnConnect_form);
            this.panel1.Controls.Add(this.btn_add_user_form);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 610);
            this.panel1.TabIndex = 19;
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.White;
            this.pnlNav.Location = new System.Drawing.Point(0, 223);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(3, 100);
            this.pnlNav.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogout_form
            // 
            this.btnLogout_form.FlatAppearance.BorderSize = 0;
            this.btnLogout_form.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout_form.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout_form.ForeColor = System.Drawing.Color.White;
            this.btnLogout_form.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout_form.Image")));
            this.btnLogout_form.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout_form.Location = new System.Drawing.Point(12, 559);
            this.btnLogout_form.Name = "btnLogout_form";
            this.btnLogout_form.Size = new System.Drawing.Size(153, 44);
            this.btnLogout_form.TabIndex = 4;
            this.btnLogout_form.Text = "Logout";
            this.btnLogout_form.UseVisualStyleBackColor = true;
            this.btnLogout_form.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnConnect_form
            // 
            this.btnConnect_form.FlatAppearance.BorderSize = 0;
            this.btnConnect_form.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect_form.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect_form.ForeColor = System.Drawing.Color.White;
            this.btnConnect_form.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect_form.Image")));
            this.btnConnect_form.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect_form.Location = new System.Drawing.Point(12, 279);
            this.btnConnect_form.Name = "btnConnect_form";
            this.btnConnect_form.Size = new System.Drawing.Size(153, 44);
            this.btnConnect_form.TabIndex = 1;
            this.btnConnect_form.Text = "Connect";
            this.btnConnect_form.UseVisualStyleBackColor = true;
            this.btnConnect_form.Click += new System.EventHandler(this.btnConnect_form_Click);
            this.btnConnect_form.Leave += new System.EventHandler(this.btnConnect_form_Leave);
            // 
            // btn_add_user_form
            // 
            this.btn_add_user_form.FlatAppearance.BorderSize = 0;
            this.btn_add_user_form.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_user_form.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_user_form.ForeColor = System.Drawing.Color.White;
            this.btn_add_user_form.Image = ((System.Drawing.Image)(resources.GetObject("btn_add_user_form.Image")));
            this.btn_add_user_form.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add_user_form.Location = new System.Drawing.Point(12, 219);
            this.btn_add_user_form.Name = "btn_add_user_form";
            this.btn_add_user_form.Size = new System.Drawing.Size(153, 44);
            this.btn_add_user_form.TabIndex = 0;
            this.btn_add_user_form.Text = "Add User";
            this.btn_add_user_form.UseVisualStyleBackColor = true;
            this.btn_add_user_form.Click += new System.EventHandler(this.btn_add_user_form_Click);
            this.btn_add_user_form.Leave += new System.EventHandler(this.btn_add_user_form_Leave);
            // 
            // pnlFormLoader
            // 
            this.pnlFormLoader.Location = new System.Drawing.Point(185, 50);
            this.pnlFormLoader.Name = "pnlFormLoader";
            this.pnlFormLoader.Size = new System.Drawing.Size(741, 560);
            this.pnlFormLoader.TabIndex = 20;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Reem Kufi", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(192, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(139, 50);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "Add User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(702, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 32);
            this.label2.TabIndex = 23;
            this.label2.Text = "Powertrace SRL Copyright 2026\r\nTovarovskyi Oleksandr\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(928, 610);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlFormLoader);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_add_user_form;
        private System.Windows.Forms.Button btnConnect_form;
        private System.Windows.Forms.Button btnLogout_form;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Panel pnlFormLoader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
    }
}

