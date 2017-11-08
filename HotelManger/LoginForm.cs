using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelLogic;

namespace HotelManger
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            int statuscode = LoginManger.LoginIn(account.Text, password.Text);

            if(statuscode==0)
            {
                MessageBox.Show("登陆成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(statuscode==-404)
            {
                MessageBox.Show("用户名或密码不正确", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(statuscode==-1)
            {
                MessageBox.Show("账户已被禁用，请与管理员联系", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
