namespace Retea_Calculator
{
    partial class FormConnect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnect));
            this.listViewLog = new System.Windows.Forms.ListView();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeconectare = new System.Windows.Forms.Button();
            this.btnConectare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewLog
            // 
            this.listViewLog.BackColor = System.Drawing.Color.Gray;
            this.listViewLog.HideSelection = false;
            this.listViewLog.Location = new System.Drawing.Point(338, -1);
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(544, 506);
            this.listViewLog.TabIndex = 24;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            // 
            // txtCommand
            // 
            this.txtCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.txtCommand.ForeColor = System.Drawing.Color.White;
            this.txtCommand.Location = new System.Drawing.Point(92, 332);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(163, 20);
            this.txtCommand.TabIndex = 23;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3"});
            this.comboBox1.Location = new System.Drawing.Point(94, 132);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 21);
            this.comboBox1.TabIndex = 22;
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.ForeColor = System.Drawing.Color.White;
            this.btnSendCommand.Image = ((System.Drawing.Image)(resources.GetObject("btnSendCommand.Image")));
            this.btnSendCommand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendCommand.Location = new System.Drawing.Point(92, 288);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(163, 38);
            this.btnSendCommand.TabIndex = 21;
            this.btnSendCommand.Text = "Send Command";
            this.btnSendCommand.UseVisualStyleBackColor = false;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(92, 244);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(161, 38);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // btnDeconectare
            // 
            this.btnDeconectare.ForeColor = System.Drawing.Color.White;
            this.btnDeconectare.Image = ((System.Drawing.Image)(resources.GetObject("btnDeconectare.Image")));
            this.btnDeconectare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeconectare.Location = new System.Drawing.Point(92, 200);
            this.btnDeconectare.Name = "btnDeconectare";
            this.btnDeconectare.Size = new System.Drawing.Size(161, 38);
            this.btnDeconectare.TabIndex = 19;
            this.btnDeconectare.Text = "Disconnect";
            this.btnDeconectare.UseVisualStyleBackColor = false;
            this.btnDeconectare.Click += new System.EventHandler(this.btnDeconectare_Click_1);
            // 
            // btnConectare
            // 
            this.btnConectare.ForeColor = System.Drawing.Color.White;
            this.btnConectare.Image = ((System.Drawing.Image)(resources.GetObject("btnConectare.Image")));
            this.btnConectare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConectare.Location = new System.Drawing.Point(92, 159);
            this.btnConectare.Name = "btnConectare";
            this.btnConectare.Size = new System.Drawing.Size(163, 35);
            this.btnConectare.TabIndex = 18;
            this.btnConectare.Text = "Connect/Open Port";
            this.btnConectare.UseVisualStyleBackColor = false;
            this.btnConectare.Click += new System.EventHandler(this.btnConectare_Click_1);
            // 
            // FormConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1088, 610);
            this.Controls.Add(this.listViewLog);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnSendCommand);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeconectare);
            this.Controls.Add(this.btnConectare);
            this.Name = "FormConnect";
            this.Text = "FormConnect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewLog;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeconectare;
        private System.Windows.Forms.Button btnConectare;
    }
}