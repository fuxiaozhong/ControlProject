using ControlStart.Config;

using System;
using System.Windows.Forms;

using ToolKit.HYControls;
using ToolKit.HYControls.HYForm;

namespace ControlStart.Login
{
    public partial class Form_User_Login : HYBaseForm
    {
        public Form_User_Login()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            HYMessageTip.ShowWarning("取消登陆");
            DialogResult = DialogResult.Cancel;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text == "操作员")
            {
                if (textBox_Password.Text == Global.Instance.OperatorPassword)
                {
                    HYMessageTip.ShowOk("操作员,登陆成功");
                    Global.Instance.Power = "操作员";
                    Global.Instance.LastLoginTime = DateTime.Now;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    HYMessageTip.ShowError("密码错误");
                }
            }
            else if (textBox_username.Text == "管理员")
            {
                if (textBox_Password.Text.ToLower() == Global.Instance.AdminPassword)
                {
                    HYMessageTip.ShowOk("管理员,登陆成功");
                    Global.Instance.Power = "管理员";
                    Global.Instance.LastLoginTime = DateTime.Now;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    HYMessageTip.ShowError("密码错误");
                }
            }
            else if (textBox_username.Text == "开发人员")
            {
                if (textBox_Password.Text.ToLower() == Global.Instance.DeveloperPassword)
                {
                    HYMessageTip.ShowOk("开发人员,登陆成功");
                    Global.Instance.Power = "开发人员";
                    Global.Instance.LastLoginTime = DateTime.Now;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    HYMessageTip.ShowError("密码错误");
                }
            }
        }

        private void Form_User_Load(object sender, EventArgs e)
        {
            textBox_username.Text = Global.Instance.Power == "管理员" ? "管理员" : "操作员";
        }

        private void TextBox1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(label5, new System.Drawing.Point(0, 0));
        }

        private void ContextMenuStrip1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            textBox_username.Text = toolStripMenuItem.Text;
        }

        private void Form_User_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(sender, e);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            new Form_Access_Configuration().ShowDialog();
        }
    }
}