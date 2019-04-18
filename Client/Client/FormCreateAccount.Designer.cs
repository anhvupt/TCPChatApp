namespace formLapTrinhMang
{
    partial class FormCreateAccount
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
            this.lbIDCreateAccount = new System.Windows.Forms.Label();
            this.lbPassWordCreateAccount1 = new System.Windows.Forms.Label();
            this.lbPassWordCreateAccount2 = new System.Windows.Forms.Label();
            this.tbIDCreate = new System.Windows.Forms.TextBox();
            this.tbCreataPassWord1 = new System.Windows.Forms.TextBox();
            this.tbCreataPassWord2 = new System.Windows.Forms.TextBox();
            this.btCreateAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbIDCreateAccount
            // 
            this.lbIDCreateAccount.AutoSize = true;
            this.lbIDCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIDCreateAccount.Location = new System.Drawing.Point(53, 48);
            this.lbIDCreateAccount.Name = "lbIDCreateAccount";
            this.lbIDCreateAccount.Size = new System.Drawing.Size(120, 20);
            this.lbIDCreateAccount.TabIndex = 0;
            this.lbIDCreateAccount.Text = "Tên đăng nhập:";
            // 
            // lbPassWordCreateAccount1
            // 
            this.lbPassWordCreateAccount1.AutoSize = true;
            this.lbPassWordCreateAccount1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassWordCreateAccount1.Location = new System.Drawing.Point(53, 76);
            this.lbPassWordCreateAccount1.Name = "lbPassWordCreateAccount1";
            this.lbPassWordCreateAccount1.Size = new System.Drawing.Size(79, 20);
            this.lbPassWordCreateAccount1.TabIndex = 1;
            this.lbPassWordCreateAccount1.Text = "Mật khẩu:";
            // 
            // lbPassWordCreateAccount2
            // 
            this.lbPassWordCreateAccount2.AutoSize = true;
            this.lbPassWordCreateAccount2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassWordCreateAccount2.Location = new System.Drawing.Point(53, 108);
            this.lbPassWordCreateAccount2.Name = "lbPassWordCreateAccount2";
            this.lbPassWordCreateAccount2.Size = new System.Drawing.Size(140, 20);
            this.lbPassWordCreateAccount2.TabIndex = 2;
            this.lbPassWordCreateAccount2.Text = "Nhập lại mật khẩu:";
            // 
            // tbIDCreate
            // 
            this.tbIDCreate.Location = new System.Drawing.Point(202, 48);
            this.tbIDCreate.Name = "tbIDCreate";
            this.tbIDCreate.Size = new System.Drawing.Size(174, 20);
            this.tbIDCreate.TabIndex = 3;
            // 
            // tbCreataPassWord1
            // 
            this.tbCreataPassWord1.Location = new System.Drawing.Point(202, 78);
            this.tbCreataPassWord1.Name = "tbCreataPassWord1";
            this.tbCreataPassWord1.Size = new System.Drawing.Size(174, 20);
            this.tbCreataPassWord1.TabIndex = 4;
            this.tbCreataPassWord1.UseSystemPasswordChar = true;
            // 
            // tbCreataPassWord2
            // 
            this.tbCreataPassWord2.Location = new System.Drawing.Point(202, 110);
            this.tbCreataPassWord2.Name = "tbCreataPassWord2";
            this.tbCreataPassWord2.Size = new System.Drawing.Size(174, 20);
            this.tbCreataPassWord2.TabIndex = 5;
            this.tbCreataPassWord2.UseSystemPasswordChar = true;
            // 
            // btCreateAccount
            // 
            this.btCreateAccount.Location = new System.Drawing.Point(301, 164);
            this.btCreateAccount.Name = "btCreateAccount";
            this.btCreateAccount.Size = new System.Drawing.Size(75, 23);
            this.btCreateAccount.TabIndex = 6;
            this.btCreateAccount.Text = "Đăng ký";
            this.btCreateAccount.UseVisualStyleBackColor = true;
            this.btCreateAccount.Click += new System.EventHandler(this.btCreateAccount_Click);
            // 
            // FormCreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 293);
            this.Controls.Add(this.btCreateAccount);
            this.Controls.Add(this.tbCreataPassWord2);
            this.Controls.Add(this.tbCreataPassWord1);
            this.Controls.Add(this.tbIDCreate);
            this.Controls.Add(this.lbPassWordCreateAccount2);
            this.Controls.Add(this.lbPassWordCreateAccount1);
            this.Controls.Add(this.lbIDCreateAccount);
            this.Name = "FormCreateAccount";
            this.Text = "FormCreateAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIDCreateAccount;
        private System.Windows.Forms.Label lbPassWordCreateAccount1;
        private System.Windows.Forms.Label lbPassWordCreateAccount2;
        private System.Windows.Forms.TextBox tbIDCreate;
        private System.Windows.Forms.TextBox tbCreataPassWord1;
        private System.Windows.Forms.TextBox tbCreataPassWord2;
        private System.Windows.Forms.Button btCreateAccount;
    }
}