using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlStart.ControlForms;
using ControlStart.Utils;
using ToolKit.HYControls.HYForm;
using System.Threading;
using ControlStart.Config;
using System.IO;
using ControlStart.JobMethod;
using ControlStart.Login;
using ToolKit.CommunicAtion;
using HslCommunication.Profinet.Melsec;
using System.Net.NetworkInformation;
using System.Runtime;

namespace ControlStart
{
    public partial class MainForm : UserControl
    {

        //外部输出 图片委托
        public delegate void ExternalOutputImage(string CamName, HalconDotNet.HObject image);
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var parms = base.CreateParams;
        //        parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN
        //        return parms;
        //    }
        //}
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

        }
        private Thread dataRefresh;
        private void MianForm_Load(object sender, EventArgs e)
        {
            //Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 初始化程序
        /// </summary>
        public void Initialize()
        {
            //创建文件夹
            if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Vision_Config"))
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Vision_Config");
            if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Vision_Product"))
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Vision_Product");
            if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Vision_Logs"))
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Vision_Logs");
            if (Global.Instance.ImageSavePath == null)
            {
                string imagePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                if (!Directory.Exists(imagePath + "\\Vision_Images"))
                    Directory.CreateDirectory(imagePath + "\\Vision_Images");
                Global.Instance.ImageSavePath = imagePath + "\\Vision_Images";
            }
            if (Global.Instance.DataSavePath == null)
            {
                string imagePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (!Directory.Exists(imagePath + "\\Vision_Data"))
                    Directory.CreateDirectory(imagePath + "\\Vision_Data");
                Global.Instance.DataSavePath = imagePath + "\\Vision_Data";
            }


            this.Visible = false;
            Global.Instance.Read();
            Global.Instance.RunningLog = new Logs(this.richTextBox_RunLog);
            Global.Instance.RunningLog.name = "运行日志";
            Global.Instance.RunningLog.WriteRunLog("软件启动加载数据中...");

            Global.Instance.TCPLog = new Logs(this.richTextBox_Communication_Log);
            Global.Instance.TCPLog.name = "通讯日志";
            Global.Instance.TCPLog.WriteRunLog("通讯日志开启...");
            Global.Instance.ErrorLog = new Logs(this.richTextBox_ErrorLog);
            Global.Instance.ErrorLog.name = "错误日志";
            Global.Instance.ErrorLog.WriteErrorLog("错误日志开启...");

            if (toolform == null)
                toolform = new Form_Tool();

            if (cameraform == null)
                cameraform = new Form_Camera();

            if (productSetform == null)
                productSetform = new Form_ProductSet();

            if (systemSettingform == null)
                systemSettingform = new Form_SystemSetting();

            if (toolform == null)
                toolform = new Form_Tool();

            GlobalMethod.control = toolform;
            if (dataform == null)
                dataform = new Form_Data();
            toolform.Read();

            SetCamMode(CamStep.停止模式);
            Thread thread = new Thread(Using_the_UISettings);
            thread.Start();

            //初始化相机
            Cameras.Instance.InitCamera("ABCam", CameraType.大华相机);


            Cameras.Instance.form = this;
            if (homeform == null)
                homeform = new Form_Home();
            Mian_Panel_Home.Controls.Add(homeform);
            homeform.Dock = DockStyle.Fill;


            Global.Instance.TCPSocketServer_Cam1 = new ToolKit.CommunicAtion.TCPSocketServer(Global.Instance.TCPIP1, Global.Instance.TCPPort1);
            Global.Instance.TCPSocketServer_Cam1.SocketReceiveMessage += TcpWork.TCPSocketServer_SocketReceiveMessage1;
            Global.Instance.TCPSocketServer_Cam1.ClientsConnect += TcpWork.TCPSocketServer_ClientsConnect1;
            Global.Instance.TCPSocketServer_Cam1.ClientsLoss += TcpWork.TCPSocketServer_ClientsLoss1;
            Global.Instance.RunningLog.WriteRunLog(Global.Instance.TCPSocketServer_Cam1.StartListen() ? "Cam1_TCP服务器打开成功" : "Cam1_TCP服务器打开失败");

            Global.Instance.TCPSocketServer_Cam2 = new ToolKit.CommunicAtion.TCPSocketServer(Global.Instance.TCPIP2, Global.Instance.TCPPort2);
            Global.Instance.TCPSocketServer_Cam2.SocketReceiveMessage += TcpWork.TCPSocketServer_SocketReceiveMessage2;
            Global.Instance.TCPSocketServer_Cam2.ClientsConnect += TcpWork.TCPSocketServer_ClientsConnect2;
            Global.Instance.TCPSocketServer_Cam2.ClientsLoss += TcpWork.TCPSocketServer_ClientsLoss2;
            Global.Instance.RunningLog.WriteRunLog(Global.Instance.TCPSocketServer_Cam2.StartListen() ? "Cam2_TCP服务器打开成功" : "Cam2_TCP服务器打开失败");

            Global.Instance.TCPSocketServer_Cam3 = new ToolKit.CommunicAtion.TCPSocketServer(Global.Instance.TCPIP3, Global.Instance.TCPPort3);
            Global.Instance.TCPSocketServer_Cam3.SocketReceiveMessage += TcpWork.TCPSocketServer_SocketReceiveMessage3;
            Global.Instance.TCPSocketServer_Cam3.ClientsConnect += TcpWork.TCPSocketServer_ClientsConnect3;
            Global.Instance.TCPSocketServer_Cam3.ClientsLoss += TcpWork.TCPSocketServer_ClientsLoss3;
            Global.Instance.RunningLog.WriteRunLog(Global.Instance.TCPSocketServer_Cam3.StartListen() ? "Cam3_TCP服务器打开成功" : "Cam3_TCP服务器打开失败");


            Global.Instance.TCPSocketServer_Cam4 = new ToolKit.CommunicAtion.TCPSocketServer(Global.Instance.TCPIP4, Global.Instance.TCPPort4);
            Global.Instance.TCPSocketServer_Cam4.SocketReceiveMessage += TcpWork.TCPSocketServer_SocketReceiveMessage4;
            Global.Instance.TCPSocketServer_Cam4.ClientsConnect += TcpWork.TCPSocketServer_ClientsConnect4;
            Global.Instance.TCPSocketServer_Cam4.ClientsLoss += TcpWork.TCPSocketServer_ClientsLoss4;
            Global.Instance.RunningLog.WriteRunLog(Global.Instance.TCPSocketServer_Cam4.StartListen() ? "Cam4_TCP服务器打开成功" : "Cam4_TCP服务器打开失败");


            //PLC 485 连接
            Global.Instance.melsecFx = new HslCommunication.Profinet.Melsec.MelsecFxSerial();
            Global.Instance.melsecFx.LogNet = new HslCommunication.LogNet.LogNetSingle(System.Windows.Forms.Application.StartupPath + "\\Vision_Logs\\FX3U\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
            try
            {
                Global.Instance.melsecFx.SerialPortInni(sp =>
                {
                    sp.PortName = Global.Instance.Mitsubishi_FX3U_PortName;
                    sp.BaudRate = Global.Instance.Mitsubishi_FX3U_PortBaudRate;
                    sp.DataBits = Global.Instance.Mitsubishi_FX3U_PortDataBits;
                    sp.StopBits = Global.Instance.Mitsubishi_FX3U_PortStopBits;
                    sp.Parity = Global.Instance.Mitsubishi_FX3U_PortParity;
                });
                Global.Instance.melsecFx.Open();


                if (Global.Instance.melsecFx.IsOpen())
                {
                    Global.Instance.RunningLog.WriteRunLog("PLC连接成功");
                }
                else
                {
                    Global.Instance.RunningLog.WriteErrorLog("PLC连接失败");
                }
            }
            catch (Exception)
            {
                Global.Instance.RunningLog.WriteErrorLog("PLC连接失败");
            }


            if (dataRefresh == null)
            {
                dataRefresh = new Thread(DataRefreshWorkThread);
            }
            dataRefresh.IsBackground = true;
            dataRefresh.Start();





            Global.Instance.RunningLog.WriteRunLog("参数加载成功.");
            this.Visible = true;


            Work.MonitorTakePhotosSignal();

        }

        private void Using_the_UISettings()
        {
            while (true)
            {
                
                try
                {
                    label_Time.Text = DateTime.Now.ToString();
                    object obj = toolform.GetSystemValue("产品设置");
                    if (obj != null)
                        产品库ToolStripMenuItem.Visible = (bool)obj;
                    else
                        产品库ToolStripMenuItem.Visible = false;
                    obj = toolform.GetSystemValue("数据");
                    if (obj != null)
                        数据ToolStripMenuItem.Visible = (bool)obj;
                    else
                        数据ToolStripMenuItem.Visible = false;
                    obj = toolform.GetSystemValue("标题");
                    if (obj != null)
                        label_Title.Text = (string)obj;
                    else
                        label_Title.Text = "视觉检测软件";



                }
                catch (Exception)
                {
                }
                Thread.Sleep(100);
            }
        }

        private void DataRefreshWorkThread()
        {
            while (true)
            {
                uiLabel_CameraMode.Invoke(new Action(delegate
                {
                    uiLabel_CameraMode.Text = Enum.GetName(typeof(CamStep), Cameras.Instance.step);
                }));

                uiLabel_NowProduct.Invoke(new Action(delegate
                {
                    if (Global.Instance.NowProduct == null)
                        uiLabel_NowProduct.Text = "无产品";
                    else
                        uiLabel_NowProduct.Text = Global.Instance.NowProduct?.ProductName;

                }));
                uiLabel2.Invoke(new Action(delegate
                {
                    uiLabel2.Text = Global.Instance.Power;
                }));

                //登录有效时间判断
                if ((DateTime.Now - Global.Instance.LastLoginTime).TotalMinutes > Global.Instance.LoginTimeOut)
                {
                    Global.Instance.Power = "操作员";
                }

                Thread.Sleep(100);
            }
        }

        private Form_Camera cameraform;
        private Form_Home homeform;
        private Form_ProductSet productSetform;
        private Form_SystemSetting systemSettingform;
        private Form_Tool toolform;
        private Form_Data dataform;

        private void 主页面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showform == true)
            {
                HYMessageBox.ShowWarn("无法切换页面,请先关闭打开的页面");
                return;
            }
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            switch (toolStripMenuItem.Text)
            {
                case "主 页 面":
                    if (homeform == null)
                        homeform = new Form_Home();
                    Mian_Panel_Home.Controls.Clear();
                    Mian_Panel_Home.Controls.Add(homeform);
                    homeform.Dock = DockStyle.Fill;
                    break;
                case "相      机":
                    if (Cameras.Instance.step == CamStep.运行模式)
                    {
                        HYMessageBox.ShowWarn("运行中,无法操作.");
                        return;
                    }
                    if (cameraform == null)
                        cameraform = new Form_Camera();
                    Mian_Panel_Home.Controls.Clear();
                    Mian_Panel_Home.Controls.Add(cameraform);
                    cameraform.Dock = DockStyle.Fill;
                    SetCamMode(CamStep.相机);
                    break;
                case "产品设置":
                    if (Cameras.Instance.step == CamStep.运行模式)
                    {
                        HYMessageBox.ShowWarn("运行中,无法操作.");
                        return;
                    }
                    if (productSetform == null)
                        productSetform = new Form_ProductSet();
                    Mian_Panel_Home.Controls.Clear();
                    Mian_Panel_Home.Controls.Add(productSetform);
                    productSetform.Dock = DockStyle.Fill;
                    SetCamMode(CamStep.产品设置);
                    break;
                case "系统设置":
                    if (Cameras.Instance.step == CamStep.运行模式)
                    {
                        HYMessageBox.ShowWarn("运行中,无法操作.");
                        return;
                    }
                    if (systemSettingform == null)
                        systemSettingform = new Form_SystemSetting();
                    Mian_Panel_Home.Controls.Clear();
                    Mian_Panel_Home.Controls.Add(systemSettingform);
                    systemSettingform.Dock = DockStyle.Fill;
                    SetCamMode(CamStep.系统设置);
                    break;
                case "工      具":
                    if (Cameras.Instance.step == CamStep.运行模式)
                    {
                        HYMessageBox.ShowWarn("运行中,无法操作.");
                        return;
                    }
                    if (toolform == null)
                        toolform = new Form_Tool();
                    Mian_Panel_Home.Controls.Clear();
                    Mian_Panel_Home.Controls.Add(toolform);
                    toolform.Dock = DockStyle.Fill;
                    SetCamMode(CamStep.工具);
                    break;
                case "数      据":
                    if (dataform == null)
                        dataform = new Form_Data();
                    Mian_Panel_Home.Controls.Clear();
                    Mian_Panel_Home.Controls.Add(dataform);
                    dataform.Dock = DockStyle.Fill;
                    break;
                case "登      录":
                    Form_User_Login form_User_Login = new Form_User_Login();
                    form_User_Login.ShowDialog();
                    break;
            }
            toolform.Save();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HYMessageBox.ShowWarn("确认退出系统?", "提示") == DialogResult.OK)
            {
                HYForm_Waiting form_Waiting = new HYForm_Waiting(CloseEvent, "正在保存相关数据,请稍等!");
                if (form_Waiting.ShowDialog(this) == DialogResult.OK)
                {
                    Application.ExitThread();
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
            }
        }

        /// <summary>
        /// 关闭程序
        /// </summary>
        /// <returns></returns>
        public bool CloseSoftware()
        {

            HYForm_Waiting form_Waiting = new HYForm_Waiting(CloseEvent, "正在保存相关数据,请稍等!");
            if (form_Waiting.ShowDialog(this) == DialogResult.OK)
            {
                Application.ExitThread();
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return true;
        }

        private void CloseEvent(object sender, EventArgs e)
        {
            //IniFunc.writeString();

            Global.Instance.TCPSocketServer_Cam1?.Close();
            Global.Instance.TCPSocketServer_Cam2?.Close();
            Global.Instance.TCPSocketServer_Cam3?.Close();
            Global.Instance.TCPSocketServer_Cam4?.Close();
            Global.Instance.melsecFx?.Close();


            Cameras.Instance.CloseCamera();
            Global.Instance.Save();
            toolform.Save();
            Thread.Sleep(1000);
            Global.Instance.RunningLog.WriteRunLog("软件关闭成功");
        }

        private void 运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showform == true)
            {
                HYMessageBox.ShowWarn("无法运行,请先关闭打开的页面");
                return;
            }
            if (运行ToolStripMenuItem.ForeColor == Color.Red)
            {
                RunMethod();
            }
            else
            {
                StopMethod();
            }

        }
        private void RunMethod()
        {
            Mian_Panel_Home.Controls.Clear();
            if (homeform == null)
                homeform = new Form_Home();
            Mian_Panel_Home.Controls.Add(homeform);
            homeform.Dock = DockStyle.Fill;
            SetCamMode(CamStep.运行模式);
            this.运行ToolStripMenuItem.Image = ((System.Drawing.Image)(new System.ComponentModel.ComponentResourceManager(typeof(MainForm)).GetObject("toolStripMenuItem1.Image")));
            运行ToolStripMenuItem.ForeColor = Color.Green;
            运行ToolStripMenuItem.Text = "停    止";
            Global.Instance.RunningLog.WriteRunLog("开始运行...");
        }

        private void StopMethod()
        {
            SetCamMode(CamStep.停止模式);
            运行ToolStripMenuItem.ForeColor = Color.Red;
            运行ToolStripMenuItem.Text = "运    行";
            this.运行ToolStripMenuItem.Image = ((System.Drawing.Image)(new System.ComponentModel.ComponentResourceManager(typeof(MainForm)).GetObject("运行ToolStripMenuItem.Image")));
            Global.Instance.RunningLog.WriteRunLog("停止运行...");
        }

        public void CamWork(string CamName, HalconDotNet.HObject image)
        {

            switch (Cameras.Instance.step)
            {
                case CamStep.相机:
                    cameraform?.CamWork(CamName, image);
                    break;
                case CamStep.产品设置:
                    productSetform?.CamWork(CamName, image);
                    break;
                case CamStep.系统设置:
                    systemSettingform?.CamWork(CamName, image);
                    break;
                case CamStep.工具:
                    toolform?.CamWork(CamName, image);
                    break;
                case CamStep.运行模式:
                    homeform?.CamWork(CamName, image);
                    break;
                case CamStep.停止模式:
                    break;
                case CamStep.外部模式:
                    _ExternalOutputImage?.Invoke(CamName, image);
                    break;
            }
        }

        public event ExternalOutputImage _ExternalOutputImage;

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox_RunLog.TextLength > 500000)
            {
                richTextBox_RunLog.Clear();
            }
            if (richTextBox_Communication_Log.TextLength > 500000)
            {
                richTextBox_Communication_Log.Clear();
            }
            if (richTextBox_ErrorLog.TextLength > 500000)
            {
                richTextBox_ErrorLog.Clear();
            }
        }


        /// <summary>
        /// 设置相机模式
        /// </summary>
        /// <param name="camStep">模式</param>
        public void SetCamMode(CamStep camStep)
        {
            Cameras.Instance.step = camStep;
        }
        /// <summary>
        /// 开始运行
        /// </summary>
        public void Run()
        {
            RunMethod();
        }
        //停止运行
        public void Stop()
        {
            StopMethod();
        }
        /// <summary>
        /// 相机对象 例: mainForm1.Cameras["Cam1"].Soft_Trigger();
        /// </summary>
        public Cameras Cameras
        {
            get
            {
                return Cameras.Instance;
            }
        }
        bool showform = false;
        public void ShowControlForm(FormPage page)
        {
            showform = true;
            Form form = new Form();
            form.Text = Enum.GetName(typeof(FormPage), page);
            form.Size = new Size(1200, 600);
            switch (page)
            {
                case FormPage.主页面:
                    form.Controls.Add(homeform);
                    break;
                case FormPage.相机:
                    form.Controls.Add(cameraform);
                    Cameras.Instance.step = CamStep.相机;
                    break;
                case FormPage.产品设置:
                    form.Controls.Add(productSetform);
                    Cameras.Instance.step = CamStep.产品设置;
                    break;
                case FormPage.工具:
                    form.Controls.Add(toolform);
                    Cameras.Instance.step = CamStep.工具;
                    break;
                case FormPage.数据:
                    form.Controls.Add(dataform);
                    break;
                case FormPage.系统设置:
                    form.Controls.Add(systemSettingform);
                    Cameras.Instance.step = CamStep.系统设置;
                    break;
            }
            form.FormClosing += Form_FormClosing;
            form.Shown += Form_Shown;
            form.Show();



        }

        private void Form_Shown(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        if ((sender as Form).Controls.Count == 0)
                        {
                            (sender as Form).Invoke(new Action(delegate
                            {

                                (sender as Form).Close();
                            }));
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            });

        }



        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            showform = false;

            if ((sender as Form).Text == Enum.GetName(typeof(FormPage), FormPage.主页面))
            {
                主页面ToolStripMenuItem_Click(主页面ToolStripMenuItem, e);
            }
            else if ((sender as Form).Text == Enum.GetName(typeof(FormPage), FormPage.相机))
            {
                主页面ToolStripMenuItem_Click(相机ToolStripMenuItem, e);
            }
            else if ((sender as Form).Text == Enum.GetName(typeof(FormPage), FormPage.产品设置))
            {
                主页面ToolStripMenuItem_Click(产品库ToolStripMenuItem, e);
            }
            else if ((sender as Form).Text == Enum.GetName(typeof(FormPage), FormPage.系统设置))
            {
                主页面ToolStripMenuItem_Click(设置ToolStripMenuItem, e);
            }
            else if ((sender as Form).Text == Enum.GetName(typeof(FormPage), FormPage.数据))
            {
                主页面ToolStripMenuItem_Click(数据ToolStripMenuItem, e);
            }
            else if ((sender as Form).Text == Enum.GetName(typeof(FormPage), FormPage.工具))
            {
                主页面ToolStripMenuItem_Click(工具ToolStripMenuItem, e);
            }
        }

        private void richTextBox_RunLog_MouseEnter(object sender, EventArgs e)
        {
            (sender as RichTextBox).ScrollBars = RichTextBoxScrollBars.Vertical;
            (sender as RichTextBox).ScrollBars = RichTextBoxScrollBars.Both;


        }

        private void richTextBox_RunLog_MouseLeave(object sender, EventArgs e)
        {
            (sender as RichTextBox).ScrollBars = RichTextBoxScrollBars.None;
        }

        private void richTextBox_RunLog_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }

    /// <summary>
    /// 相机图像输出位置
    /// </summary>
    public enum CamStep
    {
        /// <summary>
        /// 相机页面
        /// </summary>
        相机 = 1,
        /// <summary>
        /// 产品设置页面
        /// </summary>
        产品设置 = 2,
        /// <summary>
        /// 系统设置页面
        /// </summary>
        系统设置 = 3,
        /// <summary>
        /// 工具页面
        /// </summary>
        工具 = 4,
        /// <summary>
        /// 输出至工作处理(图像显示页面)
        /// </summary>
        运行模式 = 5,
        /// <summary>
        /// 停止模式 不输出图像
        /// </summary>
        停止模式 = 6,
        /// <summary>
        /// 外部输出  实现_ExternalOutputImage事件
        /// </summary>
        外部模式 = 7,
    }
    public enum FormPage
    {
        主页面 = 1,
        相机 = 2,
        产品设置 = 3,
        工具 = 4,
        数据 = 5,
        系统设置 = 6
    }


}
