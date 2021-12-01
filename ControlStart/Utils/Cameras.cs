
using ControlStart.Config;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using ToolKit.CamreaSDK;
namespace ControlStart.Utils
{
    public class Cameras
    {
        private static Cameras instance;

        /// <summary>
        /// 初始化当前类(单例模式)
        /// </summary>
        public static Cameras Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Cameras();
                }
                return instance;
            }
        }

        public Dictionary<string, ICamera> GetCameras
        {
            get { return this.cameras; }
        }

        /// <summary>
        /// 相机列表
        /// </summary>
        private Dictionary<string, ICamera> cameras = new Dictionary<string, ICamera>();

        private Cameras()
        {
        }

        /// <summary>
        /// 索引器(根据相机名称拿取相机)
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <returns></returns>
        public ICamera this[string cameraName]
        {
            get
            {
                bool isExis = false;
                foreach (var item in cameras.Keys)
                {
                    if (item == cameraName)
                    {
                        isExis = true;
                        break;
                    }
                    isExis = false;
                }
                if (isExis)
                {
                    return cameras[cameraName];
                }
                else
                {
                    Global.Instance.RunningLog.WriteWarnLog("没有找到ID:" + cameraName + "的相机,默认使用第一个相机");
                    return cameras.Values.First();
                }
            }
        }

        /// <summary>
        /// 根据下标去获取相机
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ICamera this[int index]
        {
            get
            {
                if (index < cameras.Values.Count)
                {
                    return cameras.Values.ElementAt(index);
                }
                return cameras.Values.First();
            }
        }

        /// <summary>
        /// 添加相机到字典中
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <param name="camera">相机</param>
        private void AddCamera(string cameraName, ICamera camera)
        {
            bool isExis = false;
            foreach (var item in cameras.Keys)
            {
                if (item == cameraName)
                {
                    isExis = true;
                    break;
                }
                isExis = false;
            }

            if (isExis)
            {
                System.Windows.Forms.MessageBox.Show("软件中已经存在相同名称的相机,无法添加名称为:" + cameraName + "的相机");
            }
            else
            {
                cameras.Add(cameraName, camera);
            }
        }

        /// <summary>
        /// 关闭所有相机
        /// </summary>
        public void CloseCamera()
        {
            foreach (ICamera item in cameras.Values)
            {
                Global.Instance.RunningLog.WriteRunLog("相机:" + item._CameraNmae + "关闭成功");
                IniFunc.WriteIniData("ExposureTime", item._CameraNmae, item.Get_Exposure_Time().ToString());
                IniFunc.WriteIniData("TriggerMode", item._CameraNmae, item.Get_TriggerMode().ToString());
                IniFunc.WriteIniData("TriggerSource", item._CameraNmae, item.Get_TriggerSource().ToString());
                IniFunc.WriteIniData("Gain", item._CameraNmae, item.Get_Gain().ToString());
                item?.Close();
            }

            cameras.Clear();
        }

        /// <summary>
        /// 初始化打开相机
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <param name="type">相机类型</param>
        public void InitCamera(string cameraName, CameraType type)
        {
            switch (type)
            {
                case CameraType.大华相机:
                    DaHuaCamera dahua = new DaHuaCamera();
                    dahua.IsSaveLog2Disk = true;
                    if (dahua.Open(cameraName, cameraName + ".mvcfg"))
                    {
                        Global.Instance.RunningLog.WriteRunLog("相机:" + cameraName + "打开成功");

                        dahua.Set_Exposure_Time(double.Parse(IniFunc.ReadIniData("ExposureTime", cameraName) == "" ? "1000" : IniFunc.ReadIniData("ExposureTime", cameraName)));
                        dahua.Set_Gain(double.Parse(IniFunc.ReadIniData("Gain", cameraName) == "" ? "1" : IniFunc.ReadIniData("Gain", cameraName)));
                        dahua.Set_TriggerMode(IniFunc.ReadIniData("TriggerMode", cameraName) == "" ? "On" : IniFunc.ReadIniData("TriggerMode", cameraName));
                        dahua.Set_TriggerSource(IniFunc.ReadIniData("TriggerSource", cameraName) == "" ? "Software" : IniFunc.ReadIniData("TriggerSource", cameraName));

                        AddCamera(cameraName, dahua);
                        dahua.ImageProcessEvent += Camera_ImageProcessEvent;
                        dahua.CameraLogs += Dahua_CameraLogs;

                    }
                    else
                    {
                        Global.Instance.RunningLog.WriteErrorLog("相机:" + cameraName + "打开失败");
                    }
                    break;

                case CameraType.海康威视:
                    HikvisionCamera haikang = new HikvisionCamera();
                    if (haikang.Open(cameraName))
                    {
                        Global.Instance.RunningLog.WriteRunLog("相机:" + cameraName + "打开成功");

                        haikang.Set_Exposure_Time(double.Parse(IniFunc.ReadIniData("ExposureTime", cameraName) == "" ? "1000" : IniFunc.ReadIniData("ExposureTime", cameraName)));
                        haikang.Set_Gain(double.Parse(IniFunc.ReadIniData("Gain", cameraName) == "" ? "1" : IniFunc.ReadIniData("Gain", cameraName)));
                        haikang.Set_TriggerMode(IniFunc.ReadIniData("TriggerMode", cameraName) == "" ? "On" : IniFunc.ReadIniData("TriggerMode", cameraName));
                        haikang.Set_TriggerSource(IniFunc.ReadIniData("TriggerSource", cameraName) == "" ? "Software" : IniFunc.ReadIniData("TriggerSource", cameraName));


                        AddCamera(cameraName, haikang);
                        haikang.IsSaveLog2Disk = true;
                        haikang.ImageProcessEvent += Camera_ImageProcessEvent;
                        haikang.CameraLogs += Dahua_CameraLogs;
                    }
                    else
                    {
                        Global.Instance.RunningLog.WriteErrorLog("相机:" + cameraName + "打开失败");
                    }
                    break;

                case CameraType.巴斯勒:
                    BaslerPylonGigE basler = new BaslerPylonGigE();
                    if (basler.Open(cameraName))
                    {
                        Global.Instance.RunningLog.WriteRunLog("相机:" + cameraName + "打开成功");
                        basler.Set_Exposure_Time(double.Parse(IniFunc.ReadIniData("ExposureTime", cameraName) == "" ? "1000" : IniFunc.ReadIniData("ExposureTime", cameraName)));
                        basler.Set_Gain(double.Parse(IniFunc.ReadIniData("Gain", cameraName) == "" ? "1" : IniFunc.ReadIniData("Gain", cameraName)));
                        basler.Set_TriggerMode(IniFunc.ReadIniData("TriggerMode", cameraName) == "" ? "On" : IniFunc.ReadIniData("TriggerMode", cameraName));
                        basler.Set_TriggerSource(IniFunc.ReadIniData("TriggerSource", cameraName) == "" ? "Software" : IniFunc.ReadIniData("TriggerSource", cameraName));


                        AddCamera(cameraName, basler);
                        basler.IsSaveLog2Disk = true;
                        basler.ImageProcessEvent += Camera_ImageProcessEvent;
                        basler.CameraLogs += Dahua_CameraLogs;
                    }
                    else
                    {
                        Global.Instance.RunningLog.WriteErrorLog("相机:" + cameraName + "打开失败");
                    }
                    break;

                case CameraType.Halcon:
                    HalconCamera halconCamera = new HalconCamera();
                    if (halconCamera.Open(cameraName))
                    {
                        Global.Instance.RunningLog.WriteRunLog("相机:" + cameraName + "打开成功");
                        string exposureTime = IniFunc.ReadIniData("ExposureTime", cameraName) == "" ? "1000" : IniFunc.ReadIniData("ExposureTime", cameraName);
                        halconCamera.Set_Exposure_Time(double.Parse(exposureTime));

                        halconCamera.Set_Exposure_Time(double.Parse(IniFunc.ReadIniData("ExposureTime", cameraName) == "" ? "1000" : IniFunc.ReadIniData("ExposureTime", cameraName)));
                        halconCamera.Set_Gain(double.Parse(IniFunc.ReadIniData("Gain", cameraName) == "" ? "1" : IniFunc.ReadIniData("Gain", cameraName)));
                        halconCamera.Set_TriggerMode(IniFunc.ReadIniData("TriggerMode", cameraName) == "" ? "On" : IniFunc.ReadIniData("TriggerMode", cameraName));
                        halconCamera.Set_TriggerSource(IniFunc.ReadIniData("TriggerSource", cameraName) == "" ? "Software" : IniFunc.ReadIniData("TriggerSource", cameraName));

                        AddCamera(cameraName, halconCamera);
                        halconCamera.IsSaveLog2Disk = true;
                        halconCamera.ImageProcessEvent += Camera_ImageProcessEvent;
                        halconCamera.CameraLogs += Dahua_CameraLogs;
                    }
                    else
                    {
                        Global.Instance.RunningLog.WriteErrorLog("相机:" + cameraName + "打开失败");
                    }
                    break;
            }
        }

        private void Dahua_CameraLogs(string cameraName, string message)
        {

        }

        public CamStep step;

        public System.Windows.Forms.Control form;
        /// <summary>
        /// 图像处理事件
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <param name="ho_image">图片</param>
        private void Camera_ImageProcessEvent(string cameraName, HalconDotNet.HObject ho_image)
        {
            if (step != CamStep.相机)
                Global.Instance.RunningLog.WriteRunLog(cameraName + "接收到图像开始处理......");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            (form as MainForm).Invoke(new Action(delegate
            {
                (form as MainForm).CamWork(cameraName, ho_image);
            }));
            stopwatch.Stop();
            if (step != CamStep.相机)
                Global.Instance.RunningLog.WriteRunLog(cameraName + "图像处理完成,耗时:" + stopwatch.ElapsedMilliseconds + "ms");
        }
    }

    /// <summary>
    /// 相机类型
    /// </summary>
    public enum CameraType
    {
        大华相机, 海康威视, 巴斯勒, Halcon
    }
}