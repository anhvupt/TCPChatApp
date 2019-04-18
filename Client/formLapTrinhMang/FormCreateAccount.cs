using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formLapTrinhMang
{
    public partial class FormCreateAccount : Form
    {
        public FormCreateAccount()
        {
            InitializeComponent();
        }

        private void btCreateAccount_Click(object sender, EventArgs e)
        {
            if(tbIDCreate.Text == "")
            {
                DialogResult h = MessageBox.Show("Nhập lại tên đăng nhập", "Đăng ký không thành công", MessageBoxButtons.OK);
                    tbIDCreate.Focus();
                    
            }
			else if (tbCreataPassWord1.Text == "")
			{
				DialogResult h = MessageBox.Show("Nhập lại mật khẩu", "Đăng ký không thành công", MessageBoxButtons.OK);
				tbCreataPassWord1.Focus();
			}
			else if (tbCreataPassWord2.Text == "")
			{
				DialogResult h = MessageBox.Show("Nhập lại mật xác nhận mật khẩu", "Đăng ký không thành công", MessageBoxButtons.OK);
				tbCreataPassWord2.Focus();
			}
			else if (tbCreataPassWord2.Text != tbCreataPassWord1.Text)
			{
				DialogResult h = MessageBox.Show("Mật khẩu xác nhận không khớp", "Đăng ký không thành công", MessageBoxButtons.OK);
				tbCreataPassWord2.Focus();
			}
			else
			
				MessageBox.Show("Đăng kí thành công", "Thành công!", MessageBoxButtons.OK);
				
			
        }
    }
}
