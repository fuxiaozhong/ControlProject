using ControlStart.Config;
using ControlStart.Utils;

using Sunny.UI;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ToolKit.HYControls;
using ToolKit.HYControls.HYForm;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ControlStart.ControlForms
{
    public partial class Form_SystemSetting : UserControl
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }
        public Form_SystemSetting()
        {

            InitializeComponent();
        }

        /// <summary>
        /// 相机工作事件
        /// </summary>
        /// <param name="CamName"></param>
        /// <param name="image"></param>
        public void CamWork(string CamName, HalconDotNet.HObject image)
        {


        }

        private void btn_SelectImageSavePath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (folderBrowserDialog1.SelectedPath != null)
                {
                    tb_ImageSavePath.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }
        private void btn_DataSavePath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (folderBrowserDialog1.SelectedPath != null)
                {
                    tb_DataSavePath.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }
        private void checkmessage()
        {
            Task.Run(() =>
            {
                DateTime start = DateTime.Now;
                while (true)
                {
                    if ((DateTime.Now - start).TotalSeconds >= 5)
                    {
                        HYMessageBox.ShowWarn("接收客户端回馈消息超时:5s");
                        Global.Instance.TCPSocketServer_Cam1.Message = null;
                        return;
                    }

                    if (Global.Instance.TCPSocketServer_Cam1.Message != null)
                    {
                        uiRichTextBox2.Invoke(new Action(() =>
                        {
                            uiRichTextBox2.Text = Global.Instance.TCPSocketServer_Cam1.Message;
                            Global.Instance.TCPSocketServer_Cam1.Message = null;
                            return;
                        }));
                    }
                }
            });
        }
        private void btn_tcpsend_Click(object sender, EventArgs e)
        {
            uiRichTextBox2.Text = null;
            if (uiComboBox1.SelectedIndex == 0)
            {
                if (Global.Instance.TCPSocketServer_Cam1 != null && Global.Instance.TCPSocketServer_Cam1.SendMessage(uiRichTextBox1.Text))
                {
                    checkmessage();
                }
                else
                {
                    HYMessageBox.ShowWarn("发送消息失败,请检查是否打开TCP Sever,请检查是否有客户端连接");
                }

            }
            else if (uiComboBox1.SelectedIndex == 1)
            {
                if (Global.Instance.TCPSocketServer_Cam2 != null && Global.Instance.TCPSocketServer_Cam2.SendMessage(uiRichTextBox1.Text))
                {
                    checkmessage();
                }
                else
                {
                    HYMessageBox.ShowWarn("发送消息失败,请检查是否打开TCP Sever,请检查是否有客户端连接");
                }

            }
            else if (uiComboBox1.SelectedIndex == 2)
            {
                if (Global.Instance.TCPSocketServer_Cam3 != null && Global.Instance.TCPSocketServer_Cam3.SendMessage(uiRichTextBox1.Text))
                {
                    checkmessage();
                }
                else
                {
                    HYMessageBox.ShowWarn("发送消息失败,请检查是否打开TCP Sever,请检查是否有客户端连接");
                }

            }
            else if (uiComboBox1.SelectedIndex == 3)
            {
                if (Global.Instance.TCPSocketServer_Cam4 != null && Global.Instance.TCPSocketServer_Cam4.SendMessage(uiRichTextBox1.Text))
                {
                    checkmessage();
                }
                else
                {
                    HYMessageBox.ShowWarn("发送消息失败,请检查是否打开TCP Sever,请检查是否有客户端连接");
                }
            }
        }

        private void UiSymbolLabel1_Click(object sender, EventArgs e)
        {
            if (uiSymbolLabel1.Symbol == 261550)
            {
                uiSymbolLabel1.Symbol = 261552;
                uitb_oldpassword.PasswordChar = '*';
            }
            else
            {
                uiSymbolLabel1.Symbol = 261550;
                uitb_oldpassword.PasswordChar = new char();
            }

        }

        private void UiSymbolLabel2_Click(object sender, EventArgs e)
        {
            if (uiSymbolLabel2.Symbol == 261550)
            {
                uiSymbolLabel2.Symbol = 261552;
                uitb_newpassword1.PasswordChar = '*';
            }
            else
            {
                uiSymbolLabel2.Symbol = 261550;
                uitb_newpassword1.PasswordChar = new char();
            }
        }

        private void UiSymbolLabel3_Click(object sender, EventArgs e)
        {
            if (uiSymbolLabel3.Symbol == 261550)
            {
                uiSymbolLabel3.Symbol = 261552;
                uitb_newpassword2.PasswordChar = '*';
            }
            else
            {
                uiSymbolLabel3.Symbol = 261550;
                uitb_newpassword2.PasswordChar = new char();
            }
        }
        private void Form_SystemSetting_Load(object sender, EventArgs e)
        {
            //系统设置
            tb_ImageSavePath.Text = Global.Instance.ImageSavePath;
            tb_DataSavePath.Text = Global.Instance.DataSavePath;
            cb_ImageSaveType_OK.Checked = Global.Instance.ImageSaveType_OK;
            cb_ImageSaveType_NG.Checked = Global.Instance.ImageSaveType_NG;
            cb_ImageSaveType_MasterMap.Checked = Global.Instance.ImageSaveType_原图;
            cb_ImageSaveType_Printscreen.Checked = Global.Instance.ImageSaveType_截图;
            cb_shortcut.Checked = Global.Instance.DesktopShortcut;
            cb_Autorun.Checked = Global.Instance.Autorun;


            //通讯-TCP
            tb_tcpip1.Text = Global.Instance.TCPIP1;
            tb_tcpport1.Text = Global.Instance.TCPPort1.ToString();
            tb_tcpip2.Text = Global.Instance.TCPIP2;
            tb_tcpport2.Text = Global.Instance.TCPPort2.ToString();
            tb_tcpip3.Text = Global.Instance.TCPIP3;
            tb_tcpport3.Text = Global.Instance.TCPPort3.ToString();
            tb_tcpip4.Text = Global.Instance.TCPIP4;
            tb_tcpport4.Text = Global.Instance.TCPPort4.ToString();

            //通讯-光源
            hySerialPort1.PortName = Global.Instance.LightSourcePortName;
            hySerialPort1.Parity = Global.Instance.LightSourcePortParity;
            hySerialPort1.DataBits = Global.Instance.LightSourcePortDataBits;
            hySerialPort1.StopBits = Global.Instance.LightSourcePortStopBits;
            hySerialPort1.BaudRate = Global.Instance.LightSourcePortBaudRate;



            //通讯-PLC  485
            hySerialPort1.PortName = Global.Instance.Mitsubishi_FX3U_PortName;
            hySerialPort1.Parity = Global.Instance.Mitsubishi_FX3U_PortParity;
            hySerialPort1.DataBits = Global.Instance.Mitsubishi_FX3U_PortDataBits;
            hySerialPort1.StopBits = Global.Instance.Mitsubishi_FX3U_PortStopBits;
            hySerialPort1.BaudRate = Global.Instance.Mitsubishi_FX3U_PortBaudRate;
            textBox1.Text = Global.Instance.Camera_Tack_Aaddress;
            textBox2.Text = Global.Instance.Camera_Result_Aaddress;







            //其他设置
            numericUpDown1.Value = Global.Instance.LoginTimeOut;
            numericUpDown2.Value = Global.Instance.LogSaveTime;
            numericUpDown3.Value = Global.Instance.ImageSaveTime;

            //用户设置
            uicmb_user_list.SelectedIndex = 0;


            Dock = DockStyle.Fill;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //系统设置
            Global.Instance.ImageSavePath = tb_ImageSavePath.Text;
            Global.Instance.DataSavePath = tb_DataSavePath.Text;
            Global.Instance.ImageSaveType_OK = cb_ImageSaveType_OK.Checked;
            Global.Instance.ImageSaveType_NG = cb_ImageSaveType_NG.Checked;
            Global.Instance.ImageSaveType_原图 = cb_ImageSaveType_MasterMap.Checked;
            Global.Instance.ImageSaveType_截图 = cb_ImageSaveType_Printscreen.Checked;
            Global.Instance.DesktopShortcut = cb_shortcut.Checked;
            Global.Instance.Autorun = cb_Autorun.Checked;
            OperateComputer operateComputer = new OperateComputer();
            operateComputer.SetMeAutoStart(Global.Instance.Autorun);
            operateComputer.CreateDesktopShortcut(Global.Instance.DesktopShortcut);



            Global.Instance.Save();
            HYMessageBox.ShowNormal("保存成功");
        }

        private void Btn_communication_Save_Click(object sender, EventArgs e)
        {
            //通讯-TCP
            Global.Instance.TCPIP1 = tb_tcpip1.Text;
            Global.Instance.TCPPort1 = int.Parse(tb_tcpport1.Text);
            Global.Instance.TCPIP2 = tb_tcpip2.Text;
            Global.Instance.TCPPort2 = int.Parse(tb_tcpport2.Text);
            Global.Instance.TCPIP3 = tb_tcpip3.Text;
            Global.Instance.TCPPort3 = int.Parse(tb_tcpport3.Text);
            Global.Instance.TCPIP4 = tb_tcpip4.Text;
            Global.Instance.TCPPort4 = int.Parse(tb_tcpport4.Text);

            //通讯-光源
            Global.Instance.LightSourcePortName = hySerialPort1.PortName;
            Global.Instance.LightSourcePortParity = hySerialPort1.Parity;
            Global.Instance.LightSourcePortDataBits = hySerialPort1.DataBits;
            Global.Instance.LightSourcePortStopBits = hySerialPort1.StopBits;
            Global.Instance.LightSourcePortBaudRate = hySerialPort1.BaudRate;


            //通讯 - PLC 485
            Global.Instance.Mitsubishi_FX3U_PortName = hySerialPort2.PortName;
            Global.Instance.Mitsubishi_FX3U_PortParity = hySerialPort2.Parity;
            Global.Instance.Mitsubishi_FX3U_PortDataBits = hySerialPort2.DataBits;
            Global.Instance.Mitsubishi_FX3U_PortStopBits = hySerialPort2.StopBits;
            Global.Instance.Mitsubishi_FX3U_PortBaudRate = hySerialPort2.BaudRate;
            Global.Instance.Camera_Tack_Aaddress = textBox1.Text;
            Global.Instance.Camera_Result_Aaddress = textBox2.Text;

            Global.Instance.Save();
            HYMessageBox.ShowNormal("保存成功");
        }

        private void Btn_rests_Save_Click(object sender, EventArgs e)
        {
            //其他设置
            Global.Instance.LoginTimeOut = (int)numericUpDown1.Value;
            Global.Instance.LogSaveTime = (int)numericUpDown2.Value;
            Global.Instance.ImageSaveTime = (int)numericUpDown3.Value;

            Global.Instance.Save();
            HYMessageBox.ShowNormal("保存成功");
        }

        private void Btn_user_Save_Click(object sender, EventArgs e)
        {
            //用户设置
            if (uicmb_user_list.Text == "操作员")
            {
                if (uitb_oldpassword.Text.Trim() == Global.Instance.OperatorPassword)
                {
                    if (uitb_newpassword1.Text.Trim() == uitb_newpassword2.Text.Trim() && uitb_newpassword1.Text.Trim() != "" && uitb_newpassword1.Text.Trim() != null)
                    {
                        Global.Instance.OperatorPassword = uitb_newpassword2.Text.Trim();
                    }
                    else
                    {
                        HYMessageBox.ShowWarn("两次新密码输入不一致.请重新输入");
                        return;
                    }
                }
                else
                {
                    HYMessageBox.ShowWarn("旧密码错误.");
                    return;
                }

            }
            else if (uicmb_user_list.Text == "管理员")
            {
                if (uitb_oldpassword.Text.Trim() == Global.Instance.AdminPassword)
                {
                    if (uitb_newpassword1.Text.Trim() == uitb_newpassword2.Text.Trim() && uitb_newpassword1.Text.Trim() != "" && uitb_newpassword1.Text.Trim() != null)
                    {
                        Global.Instance.AdminPassword = uitb_newpassword2.Text.Trim();
                    }
                    else
                    {
                        HYMessageBox.ShowWarn("两次新密码输入不一致.请重新输入");
                        return;
                    }
                }
                else
                {
                    HYMessageBox.ShowWarn("旧密码错误.");
                    return;
                }
            }
            else if (uicmb_user_list.Text == "开发人员")
            {
                if (uitb_oldpassword.Text.Trim() == Global.Instance.DeveloperPassword)
                {
                    if (uitb_newpassword1.Text.Trim() == uitb_newpassword2.Text.Trim() && uitb_newpassword1.Text.Trim() != "" && uitb_newpassword1.Text.Trim() != null)
                    {
                        Global.Instance.DeveloperPassword = uitb_newpassword2.Text.Trim();
                    }
                    else
                    {
                        HYMessageBox.ShowWarn("两次新密码输入不一致.请重新输入");
                        return;
                    }
                }
                else
                {
                    HYMessageBox.ShowWarn("旧密码错误.");
                    return;
                }
            }

            Global.Instance.Save();
            HYMessageBox.ShowNormal("保存成功");
            uitb_oldpassword.Text = "";
            uitb_newpassword1.Text = "";
            uitb_newpassword2.Text = "";
        }

        private void Btn_cameraConfig_Save_Click(object sender, EventArgs e)
        {
            //相机配置设置






            Global.Instance.Save();
            HYMessageBox.ShowNormal("保存成功");
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            if (Global.Instance.melsecFx != null && Global.Instance.melsecFx.IsOpen())
            {
                Global.Instance.melsecFx.Close();
            }
            HYMessageBox.ShowNormal("关闭成功");
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            Global.Instance.Mitsubishi_FX3U_PortName = hySerialPort2.PortName;
            Global.Instance.Mitsubishi_FX3U_PortParity = hySerialPort2.Parity;
            Global.Instance.Mitsubishi_FX3U_PortDataBits = hySerialPort2.DataBits;
            Global.Instance.Mitsubishi_FX3U_PortStopBits = hySerialPort2.StopBits;
            Global.Instance.Mitsubishi_FX3U_PortBaudRate = hySerialPort2.BaudRate;
            Global.Instance.Camera_Tack_Aaddress = textBox1.Text;
            Global.Instance.Camera_Result_Aaddress = textBox2.Text;

            Global.Instance.melsecFx = new HslCommunication.Profinet.Melsec.MelsecFxSerial();

            try
            {
                Global.Instance.melsecFx.SerialPortInni(sp =>
                {
                    sp.PortName = hySerialPort2.PortName;
                    sp.BaudRate = hySerialPort2.BaudRate;
                    sp.DataBits = hySerialPort2.DataBits;
                    sp.StopBits = hySerialPort2.StopBits;
                    sp.Parity = hySerialPort2.Parity;
                });
                Global.Instance.melsecFx.Open();

                if (Global.Instance.melsecFx.IsOpen())
                {
                    HYMessageBox.ShowNormal("PLC连接成功");
                }
                else
                {
                    HYMessageBox.ShowNormal("PLC连接失败");
                }
            }
            catch (Exception)
            {
                HYMessageBox.ShowNormal("PLC连接失败");
            }








        }
    }
}
