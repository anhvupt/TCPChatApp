namespace server
{
    partial class ServerForm
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
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.startServer = new System.Windows.Forms.Button();
            this.stopServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbClientsNumber = new System.Windows.Forms.TextBox();
            this.btnSendAll = new System.Windows.Forms.Button();
            this.lbServerConsole = new System.Windows.Forms.ListBox();
            this.lbListUser = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(13, 356);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(390, 83);
            this.tbInput.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(406, 356);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(97, 38);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // startServer
            // 
            this.startServer.Location = new System.Drawing.Point(21, 24);
            this.startServer.Margin = new System.Windows.Forms.Padding(2);
            this.startServer.Name = "startServer";
            this.startServer.Size = new System.Drawing.Size(211, 37);
            this.startServer.TabIndex = 4;
            this.startServer.Text = "Start Server";
            this.startServer.UseVisualStyleBackColor = true;
            this.startServer.Click += new System.EventHandler(this.StartServer_Click);
            // 
            // stopServer
            // 
            this.stopServer.Location = new System.Drawing.Point(278, 24);
            this.stopServer.Margin = new System.Windows.Forms.Padding(2);
            this.stopServer.Name = "stopServer";
            this.stopServer.Size = new System.Drawing.Size(211, 37);
            this.stopServer.TabIndex = 5;
            this.stopServer.Text = "Stop Server";
            this.stopServer.UseVisualStyleBackColor = true;
            this.stopServer.Click += new System.EventHandler(this.StopServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(506, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Số client đang kết nối: ";
            // 
            // tbClientsNumber
            // 
            this.tbClientsNumber.BackColor = System.Drawing.SystemColors.Menu;
            this.tbClientsNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbClientsNumber.Location = new System.Drawing.Point(615, 50);
            this.tbClientsNumber.Margin = new System.Windows.Forms.Padding(2);
            this.tbClientsNumber.Name = "tbClientsNumber";
            this.tbClientsNumber.Size = new System.Drawing.Size(67, 13);
            this.tbClientsNumber.TabIndex = 7;
            this.tbClientsNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSendAll
            // 
            this.btnSendAll.Location = new System.Drawing.Point(406, 400);
            this.btnSendAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendAll.Name = "btnSendAll";
            this.btnSendAll.Size = new System.Drawing.Size(97, 38);
            this.btnSendAll.TabIndex = 8;
            this.btnSendAll.Text = "Send All";
            this.btnSendAll.UseVisualStyleBackColor = true;
            this.btnSendAll.Click += new System.EventHandler(this.BtnSendAll_Click);
            // 
            // lbServerConsole
            // 
            this.lbServerConsole.FormattingEnabled = true;
            this.lbServerConsole.Location = new System.Drawing.Point(12, 74);
            this.lbServerConsole.Margin = new System.Windows.Forms.Padding(2);
            this.lbServerConsole.Name = "lbServerConsole";
            this.lbServerConsole.Size = new System.Drawing.Size(492, 277);
            this.lbServerConsole.TabIndex = 9;
            // 
            // lbListUser
            // 
            this.lbListUser.FormattingEnabled = true;
            this.lbListUser.Location = new System.Drawing.Point(508, 74);
            this.lbListUser.Margin = new System.Windows.Forms.Padding(2);
            this.lbListUser.Name = "lbListUser";
            this.lbListUser.Size = new System.Drawing.Size(176, 368);
            this.lbListUser.TabIndex = 10;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 445);
            this.Controls.Add(this.lbListUser);
            this.Controls.Add(this.lbServerConsole);
            this.Controls.Add(this.btnSendAll);
            this.Controls.Add(this.tbClientsNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopServer);
            this.Controls.Add(this.startServer);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbInput);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button startServer;
        private System.Windows.Forms.Button stopServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbClientsNumber;
        private System.Windows.Forms.Button btnSendAll;
        private System.Windows.Forms.ListBox lbServerConsole;
        private System.Windows.Forms.ListBox lbListUser;
    }
}

