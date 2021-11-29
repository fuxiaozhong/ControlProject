using ControlStart.Helper;
using ControlStart.Utils;

using System;
using System.IO.Ports;

using ToolKit.CommunicAtion;

using HslCommunication.Profinet.Melsec;
using HslCommunication;

namespace ControlStart.Config
{
    [Serializable]
    public class Global
    {
        private static Global instance;
        //图片保存路径
        internal string ImageSavePath;
        //数据保存路径
        internal string DataSavePath;
        //TCP通讯IP1
        internal string TCPIP1 = "127.0.0.1";
        //TCP通讯Port1
        internal int TCPPort1 = 8500;
        //TCP通讯IP2
        internal string TCPIP2 = "127.0.0.1";
        //TCP通讯Port2
        internal int TCPPort2 = 8501;
        //TCP通讯IP3
        internal string TCPIP3 = "127.0.0.1";
        //TCP通讯Port3
        internal int TCPPort3 = 8502;
        //TCP通讯IP4
        internal string TCPIP4 = "127.0.0.1";
        //TCP通讯Port4
        internal int TCPPort4 = 8503;
        //图片保存类型 - OK
        internal bool ImageSaveType_OK = false;
        //图片保存类型 - NG]
        internal bool ImageSaveType_NG = false;
        //图片保存类型 - 原图
        internal bool ImageSaveType_原图 = false;
        //图片保存类型 - 截图]
        internal bool ImageSaveType_截图 = false;
        //TCPSocketServer 服务器对象  Cam1
        [NonSerialized]
        internal TCPSocketServer TCPSocketServer_Cam1;
        //TCPSocketServer 服务器对象  Cam2
        [NonSerialized]
        internal TCPSocketServer TCPSocketServer_Cam2;
        //TCPSocketServer 服务器对象  Cam3
        [NonSerialized]
        internal TCPSocketServer TCPSocketServer_Cam3;
        //TCPSocketServer 服务器对象  Cam4
        [NonSerialized]
        internal TCPSocketServer TCPSocketServer_Cam4;
        //当前产品
        internal ProductConfig NowProduct;
        //桌面快捷方式
        internal bool DesktopShortcut = false;
        //开机自启动
        internal bool Autorun = false;
        //光源串口-名
        internal string LightSourcePortName = "COM1";
        //光源串口-奇偶校验
        internal Parity LightSourcePortParity = Parity.None;
        //光源串口-数据位
        internal int LightSourcePortDataBits = 8;
        //光源串口-停止位
        internal StopBits LightSourcePortStopBits = StopBits.None;
        //光源串口-波特率
        internal int LightSourcePortBaudRate = 19200;
        //运行日志
        [NonSerialized]
        internal Logs RunningLog;
        //通讯日志
        [NonSerialized]
        internal Logs TCPLog;
        //错误日志
        [NonSerialized]
        internal Logs ErrorLog;
        //当前用户
        [NonSerialized]
        internal string Power = "未登录";
        //操作员密码
        internal string OperatorPassword = "123";
        //管理员密码
        internal string AdminPassword = "admin";
        //开发人员密码
        internal string DeveloperPassword = "develop";
        //登录有效时间
        internal int LoginTimeOut = 5;
        //最新登录时间
        [NonSerialized]
        internal DateTime LastLoginTime;


        //三菱PLC  485
        internal string Mitsubishi_FX3U_PortName;
        internal Parity Mitsubishi_FX3U_PortParity;
        internal int Mitsubishi_FX3U_PortDataBits;
        internal StopBits Mitsubishi_FX3U_PortStopBits;
        internal int Mitsubishi_FX3U_PortBaudRate;


        //三菱PLC连接对象  485
        [NonSerialized]
        internal MelsecFxSerial melsecFx = new MelsecFxSerial();
        //相机拍照地址
        internal string Camera_Tack_Aaddress;
        //相机结果返回地址
        internal string Camera_Result_Aaddress;
        //日志保存时间
        internal int LogSaveTime;
        //图片包时间
        internal int ImageSaveTime;

        private Global()
        {
        }

        /// <summary>
        /// 初始化当前类(单例模式)
        /// </summary>
        public static Global Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Global();
                }
                return instance;
            }
        }

        public object ReflectionToStringBuilder { get; private set; }

        /// <summary>
        /// 保存全局参数
        /// </summary>
        public void Save()
        {
            Serialization.Save(instance, "AppGlobalConfig");
        }
        /// <summary>
        /// 加载全局参数
        /// </summary>
        public void Read()
        {
            instance = (Global)Serialization.Read("AppGlobalConfig");
        }


    }
}
