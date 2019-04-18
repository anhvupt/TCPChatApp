namespace formLapTrinhMang
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
            this.lbID = new System.Windows.Forms.Label();
            this.lbPword = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbPassWord = new System.Windows.Forms.TextBox();
            this.btLogin = new System.Windows.Forms.Button();
            this.btCreatAccount = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbID.Location = new System.Drawing.Point(89, 73);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(120, 20);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "Tên đăng nhập:";
            // 
            // lbPword
            // 
            this.lbPword.AutoSize = true;
            this.lbPword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPword.Location = new System.Drawing.Point(89, 111);
            this.lbPword.Name = "lbPword";
            this.lbPword.Size = new System.Drawing.Size(79, 20);
            this.lbPword.TabIndex = 1;
            this.lbPword.Text = "Mật khẩu:";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(216, 73);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(160, 20);
            this.tbID.TabIndex = 1;
            // 
            // tbPassWord
            // 
            this.tbPassWord.Location = new System.Drawing.Point(216, 113);
            this.tbPassWord.Name = "tbPassWord";
            this.tbPassWord.Size = new System.Drawing.Size(160, 20);
            this.tbPassWord.TabIndex = 2;
            this.tbPassWord.UseSystemPasswordChar = true;
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(216, 181);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(87, 23);
            this.btLogin.TabIndex = 3;
            this.btLogin.Text = "Đăng nhập";
            this.btLogin.UseVisualStyleBackColor = true;
            // 
            // btCreatAccount
            // 
            this.btCreatAccount.Location = new System.Drawing.Point(309, 181);
            this.btCreatAccount.Name = "btCreatAccount";
            this.btCreatAccount.Size = new System.Drawing.Size(87, 23);
            this.btCreatAccount.TabIndex = 4;
            this.btCreatAccount.Text = "Đăng ký";
            this.btCreatAccount.UseVisualStyleBackColor = true;
            this.btCreatAccount.Click += new System.EventHandler(this.btCreatAccount_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(440, 223);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(87, 23);
            this.btExit.TabIndex = 5;
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 258);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btCreatAccount);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.tbPassWord);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.lbPword);
            this.Controls.Add(this.lbID);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbPword;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbPassWord;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Button btCreatAccount;
        private System.Windows.Forms.Button btExit;
    }
}

