using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Runtime.Serialization.Formatters.Binary;

using HslCommunication;
using HslCommunication.Profinet.Melsec;

using HYProject.Model;

using ToolKit.CommunicAtion;
using ToolKit.HalconTool.Model;

namespace HYProject
{
    [Serializable]
    public struct CameraInfo
    {
        public CameraType CameraType;
        public string CameraName;
        public string Mark;
    }

    [Serializable]
    public class AppParam
    {
        private static AppParam instance;

        /// <summary>
        /// 初始化当前类(单例模式)
        /// </summary>
        public static AppParam Instance
        {
            get
            {
                //先判断是否存在，不存在再加锁处理
                if (instance == null)
                {
                    //在同一个时刻加了锁的那部分程序只有一个线程可以进入

                    if (instance == null)
                    {
                        instance = new AppParam();
                        if (!Directory.Exists(instance.Save_Image_Path))
                        {
                            Directory.CreateDirectory(instance.Save_Image_Path);
                        }
                        if (!Directory.Exists(instance.Save_Data_Path))
                        {
                            Directory.CreateDirectory(instance.Save_Data_Path);
                        }
                    }
                }
                return instance;
            }
        }
        

        private AppParam()
        {
        }

        internal List<CameraInfo> CameraInitStr = new List<CameraInfo>();

        /// <summary>
        /// 当前登陆用户/不序列化保存
        /// </summary>
        [NonSerialized]
        internal string Power = "未登录";

        /// <summary>
        /// 图像保存路径
        /// </summary>
        internal string Save_Image_Path = "Images";

        /// <summary>
        /// 产品库
        /// </summary>
        internal string ProductLibrary = "ProductLibrary";

        /// <summary>
        /// 图像保存天数
        /// </summary>
        internal int Save_Image_Days = 30;

        /// <summary>
        /// 数据保存路径
        /// </summary>
        internal string Save_Data_Path = "Data";

        /// <summary>
        /// 桌面快捷方式
        /// </summary>
        internal bool DesktopShortcut = false;

        /// <summary>
        /// 开机自启动
        /// </summary>
        internal bool PowerBoot = false;

        /// <summary>
        /// 启动自动最大化
        /// </summary>
        internal bool RunStateMax = false;

        /// <summary>
        /// 启动前登陆
        /// </summary>
        internal bool StartBeforeLogin = false;

        /// <summary>
        /// 运行状态/不序列化保存
        /// </summary>
        [NonSerialized]
        internal bool Runing = false;

        /// <summary>
        /// 是否保存图像
        /// </summary>
        internal bool IsSaveImage;

        /// <summary>
        /// 保存OK图像
        /// </summary>
        internal bool IsSaveImage_OK;

        /// <summary>
        /// 保存NG图像
        /// </summary>
        internal bool IsSaveImage_NG;

        /// <summary>
        /// 保存为原图
        /// </summary>
        internal bool IsSaveImage_BmpImage;

        /// <summary>
        /// 保存为截图
        /// </summary>
        internal bool IsSaveImage_DumpImage;

        /// <summary>
        /// 光源串口名称
        /// </summary>
        internal string LightSourcePortName = "COM4";

        /// <summary>
        /// 光源串口波特率
        /// </summary>
        internal int LightSourceBaudRate = 19200;

        /// <summary>
        /// 光源串口奇偶校验
        /// </summary>
        internal Parity LightSourceParity = Parity.None;

        /// <summary>
        /// 光源串口数据位
        /// </summary>
        internal int LightSourceDataBits = 8;

        /// <summary>
        /// 光源串口停止位
        /// </summary>
        internal StopBits LightSourceStopBits = StopBits.One;

        /// <summary>
        /// 光源
        /// </summary>
        internal LightSource lightSource = new LightSource();

        /// <summary>
        /// PLC
        /// </summary>
        [NonSerialized]
        internal MelsecA1ENet Fx3uPLC = new MelsecA1ENet();

        /// <summary>
        /// PLC连接返回对象
        /// </summary>
        [NonSerialized]
        internal OperateResult Fx3uPLCResult;

        /// <summary>
        /// PLC连接 ip
        /// </summary>
        internal string Fx3uPLC_IP = "127.0.0.1";

        /// <summary>
        /// PLC连接 端口
        /// </summary>
        internal int Fx3uPLC_Port = 8080;

        /// <summary>
        /// 卡尺对象
        /// </summary>
        internal MeasureParam Measure;

        /// <summary>
        /// 当前产品
        /// </summary>
        internal string NowProduct;

        /// <summary>
        /// 日志储存天数
        /// </summary>
        internal int Log_Save_Days = 7;

        /// <summary>
        /// 启动自动运行
        /// </summary>
        internal bool StartAutoRun;

        /// <summary>
        /// 操作员密码
        /// </summary>
        internal string OperatorPassword = "123456";

        /// <summary>
        /// 管理员密码
        /// </summary>
        internal string AdminPassword = "admin";

        /// <summary>
        /// 开发人员密码
        /// </summary>
        internal string DeveloperPassword = "develop";

        /// <summary>
        /// TCPSocketServer IP地址  相机1
        /// </summary>
        internal string TCPServerIPAddress_Cam1 = "127.0.0.1";

        /// <summary>
        /// TCPSocketServer 端口   相机1
        /// </summary>
        internal int TCPServerPort_Cam1 = 8500;

        /// <summary>
        /// TCPSocketServer IP地址   相机2
        /// </summary>
        internal string TCPServerIPAddress_Cam2 = "127.0.0.1";

        /// <summary>
        /// TCPSocketServer 端口    相机2
        /// </summary>
        internal int TCPServerPort_Cam2 = 8501;

        /// <summary>
        /// TCPSocketServer IP地址    相机3
        /// </summary>
        internal string TCPServerIPAddress_Cam3 = "127.0.0.1";

        /// <summary>
        /// TCPSocketServer 端口   相机3
        /// </summary>
        internal int TCPServerPort_Cam3 = 8502;

        /// <summary>
        /// TCPSocketClient IP地址
        /// </summary>
        internal string TCPClientIPAddress = "127.0.0.1";

        /// <summary>
        /// TCPSocketClient 端口
        /// </summary>
        internal int TCPClientPort = 8080;

        /// <summary>
        /// TCPSocketServer 服务器对象  Cam1
        /// </summary>
        [NonSerialized]
        internal TCPSocketServer TCPSocketServer_Cam1;

        /// <summary>
        /// TCPSocketServer 服务器对象  Cam2
        /// </summary>
        [NonSerialized]
        internal TCPSocketServer TCPSocketServer_Cam2;

        /// <summary>
        /// TCPSocketServer 服务器对象  Cam3
        /// </summary>
        [NonSerialized]
        internal TCPSocketServer TCPSocketServer_Cam3;

        /// <summary>
        /// TCPSocketClient  客户端对象
        /// </summary>
        [NonSerialized]
        internal TCPSocketClient TCPSocketClient;

        /// <summary>
        /// 产品数据
        /// </summary>
        internal Product product = new Product();

        [NonSerialized]
        internal bool Robot_Calibration_State = false;
        [NonSerialized]
        internal bool Form_Camera_State = false;
        [NonSerialized]
        internal bool Form_Product_Set2_State = false;
        /// <summary>
        /// 保存对象到文件
        /// </summary>
        public void Save_To_File()
        {
            Serialize_To_File(System.Windows.Forms.Application.StartupPath + "\\AppConfig.bin", AppParam.Instance);
        }

        /// <summary>
        /// 从文件加载数据到对象
        /// </summary>
        public void Read_From_File()
        {
            instance = (AppParam)Deserialize_From_File(System.Windows.Forms.Application.StartupPath + "\\AppConfig.bin");
            if (instance == null)
            {
                AppParam.instance = AppParam.Instance;
            }
        }

        /// <summary>
        /// 序列化当前类到文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        private void Serialize_To_File(string path, object obj)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            BinaryFormatter bFormat = new BinaryFormatter();
            bFormat.Serialize(stream, obj);
            stream.Close();
            stream.Dispose();
        }

        /// <summary>
        /// 反序列化当前类到对象
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private object Deserialize_From_File(string path)
        {
            if (!File.Exists(path))
                return null;

            FileStream stream = new FileStream(path, FileMode.Open);
            BinaryFormatter bFormat = new BinaryFormatter();
            object obj = bFormat.Deserialize(stream);
            stream.Close();
            stream.Dispose();
            return obj;
        }
    }
}