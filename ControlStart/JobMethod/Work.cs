using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolKit.DisplayWindow;
using HalconDotNet;
using System.Threading;
using ControlStart.Config;
using ControlStart.Utils;


namespace ControlStart.JobMethod
{
    public class Work
    {
        public static void CamWork(HalconWindow halconWindow, string camName, HObject image)
        {
            if (camName == "ABCam")
            {
                ABCamWork(halconWindow, camName, image);
            }
            else if (camName == "CDCam")
            {
                CDCamWork(halconWindow, camName, image);
            }
            else if (camName == "DownCam")
            {
                DownCamWork(halconWindow, camName, image);
            }
            else if (camName == "Cam1")
            {
                Cam1Work(halconWindow, camName, image);
            }








            //Global.Instance.RunningLog.WriteRunLog("回复PLC结果:" + (Result ? 1 : 0));
            //Global.Instance.melsecFx.Write(Global.Instance.Camera_Result_Aaddress, Result ? 1 : 0);
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="halconWindow"></param>
        /// <param name="camName"></param>
        /// <param name="image"></param>
        public static void SaveImage(HalconWindow halconWindow, string camName, HObject image, bool flag)
        {
            string name = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            ////图片保存类型 - OK
            if (Global.Instance.ImageSaveType_OK && flag)
            {
                ////图片保存类型 - 原图
                if (Global.Instance.ImageSaveType_原图)
                {
                    string path = Global.Instance.ImageSavePath + "\\" + camName + "\\OK\\原图";
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    QueueSaveImage.Instance.QueueEnqueue2(image, path + "\\" + name);

                }
                ////图片保存类型 - 截图
                if (Global.Instance.ImageSaveType_截图)
                {
                    string path = Global.Instance.ImageSavePath + "\\" + camName + "\\OK\\截图";
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    QueueSaveImage.Instance.QueueEnqueue2(halconWindow.DumpImage(), path + "\\" + name);
                }
            }
            ////图片保存类型 - NG
            if (Global.Instance.ImageSaveType_NG && !flag)
            {
                ////图片保存类型 - 原图
                if (Global.Instance.ImageSaveType_原图)
                {
                    string path = Global.Instance.ImageSavePath + "\\" + camName + "\\NG\\原图";
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    QueueSaveImage.Instance.QueueEnqueue2(image, path + "\\" + name);

                }
                ////图片保存类型 - 截图
                if (Global.Instance.ImageSaveType_截图)
                {
                    string path = Global.Instance.ImageSavePath + "\\" + camName + "\\NG\\截图";
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    QueueSaveImage.Instance.QueueEnqueue2(halconWindow.DumpImage(), path + "\\" + name);
                }
            }
        }

        /// <summary>
        /// 上料相机工作
        /// </summary>
        /// <param name="halconWindow"></param>
        /// <param name="camName"></param>
        /// <param name="image"></param>
        private static void Cam1Work(HalconWindow halconWindow, string camName, HObject image)
        {

        }
        /// <summary>
        /// 下相机处理事件
        /// </summary>
        /// <param name="halconWindow"></param>
        /// <param name="camName"></param>
        /// <param name="image"></param>
        private static void DownCamWork(HalconWindow halconWindow, string camName, HObject image)
        {
            string[] _content = TcpWork.DownCamOrder.Split(',');
            TcpWork.DownCamOrder = "";
            //bool Result = false;
            halconWindow.Disp_Image(image);
            //Down相机定位  不复检
            if (_content[1] == "D1" && !_content[2].Contains("check"))
            {
                DownCam_Mark(_content, halconWindow, camName, image);
            }
            // Down相机复检
            else if (_content[1] == "D1" && _content[2].Contains("check"))
            {
                DownCam_Check(_content, halconWindow, camName, image);
            }
            //Down相机标定
            else if (_content[1] == "B3")
            {
                DownCam_Calibration(_content, halconWindow, camName, image);
            }
        }


        /// <summary>
        /// CD相机标定
        /// </summary>
        /// <param name="content"></param>
        /// <param name="halconWindow"></param>
        /// <param name="camName"></param>
        /// <param name="image"></param>
        private static void DownCam_Calibration(string[] content, HalconWindow halconWindow, string camName, HObject image)
        {

        }
        /// <summary>
        /// CD相机复检
        /// </summary>
        /// <param name="content"></param>
        /// <param name="halconWindow"></param>
        /// <param name="camName"></param>
        /// <param name="image"></param>
        private static void DownCam_Check(string[] content, HalconWindow halconWindow, string camName, HObject image)
        {

        }

        /// <summary>
        /// CD相机定位
        /// </summary>
        /// <param name="content"></param>
        /// <param name="halconWindow"></param>
        /// <param name="camName"></param>
        /// <param name="image"></param>
        private static void DownCam_Mark(string[] content, HalconWindow halconWindow, string camName, HObject image)
        {

        }


        /// <summary>
        /// CD相机处理事件
        /// </summary>
        /// <param name="halconWindow"></param>
        /// <param name="camName"></param>
        /// <param name="image"></param>
        private static void CDCamWork(HalconWindow halconWindow, string camName, HObject image)
        {
            string[] _content = TcpWork.CDCamOrder.Split(',');
            TcpWork.CDCamOrder = "";
            //切换复检曝光
            if (_content[2] == "SB")
            {



            }
            //切换定位曝光
            if (_content[2] == "SW")
            {


            }


            //bool Result = false;
            halconWindow.Disp_Image(image);
            //CD相机定位  不复检
            if (_content[1] == "U2" && !_content[2].Contains("check"))
            {
                CDCam_Mark(_content, halconWindow, camName, image);
            }
            // CD相机复检
            else if (_content[1] == "U2" && _content[2].Contains("check"))
            {
                CDCam_Check(_content, halconWindow, camName, image);
            }
            //CD相机标定
            else if (_content[1] == "B2")
            {
                CDCam_Calibration(_content, halconWindow, camName, image);
            }
        }
        /// <summary>
        /// CD相机标定
        /// </summary>
        /// <param name="content"></param>
        /// <param name="halconWindow"></param>
        /// <param name="camName"></param>
        /// <param name="image"></param>
        private static void CDCam_Calibration(string[] content, HalconWindow halconWindow, string camName, HObject image)
        {

        }
        /// <summary>
        /// CD相机复检
        /// </summary>
        /// <param name="content"></param>
        /// <param name="halconWindow"></param>
        /// <param name="camName"></param>
        /// <param name="image"></param>
        private static void CDCam_Check(string[] content, HalconWindow halconWindow, string camName, HObject image)
        {

        }

        /// <summary>
        /// CD相机定位
        /// </summary>
        /// <param name="content"></param>
        /// <param name="halconWindow"></param>
        /// <param name="camName"></param>
        /// <param name="image"></param>
        private static void CDCam_Mark(string[] content, HalconWindow halconWindow, string camName, HObject image)
        {

        }


        #region AB相机
        /// <summary>
        /// AB相机处理事件
        /// </summary>
        /// <param name="halconWindow"></param>
        /// <param name="camName"></param>
        /// <param name="image"></param>
        private static void ABCamWork(HalconWindow halconWindow, string camName, HObject image)
        {
            string[] _content = TcpWork.ABCamOrder.Split(',');
            TcpWork.ABCamOrder = "";
            //切换复检曝光
            if (_content[2] == "SB")
            {



            }
            //切换定位曝光
            if (_content[2] == "SW")
            {


            }


            //bool Result = false;
            halconWindow.Disp_Image(image);
            //AB相机定位  不复检
            if (_content[1] == "U1" && !_content[2].Contains("check"))
            {
                ABCam_Mark(_content, halconWindow, camName, image);
            }
            // AB相机复检
            else if (_content[1] == "U1" && _content[2].Contains("check"))
            {
                ABCam_Check(_content, halconWindow, camName, image);
            }
            //AB相机标定
            else if (_content[1] == "B1")
            {
                ABCam_Calibration(_content, halconWindow, camName, image);
            }

            //SaveImage(halconWindow, camName, image, Result);
        }
        /// <summary>
        /// AB相机标定
        /// </summary>
        /// <param name="content"></param>
        /// <param name="halconWindow"></param>
        /// <param name="camName"></param>
        /// <param name="image"></param>
        private static void ABCam_Calibration(string[] content, HalconWindow halconWindow, string camName, HObject image)
        {

        }
        /// <summary>
        /// AB相机复检
        /// </summary>
        /// <param name="content"></param>
        /// <param name="halconWindow"></param>
        /// <param name="camName"></param>
        /// <param name="image"></param>
        private static void ABCam_Check(string[] content, HalconWindow halconWindow, string camName, HObject image)
        {

        }

        /// <summary>
        /// AB相机定位
        /// </summary>
        /// <param name="content"></param>
        /// <param name="halconWindow"></param>
        /// <param name="camName"></param>
        /// <param name="image"></param>
        private static void ABCam_Mark(string[] content, HalconWindow halconWindow, string camName, HObject image)
        {

        }

        #endregion


        #region  PLC监控拍照信号

        /// <summary>
        /// PLC监控拍照信号
        /// </summary>
        public static void MonitorTakePhotosSignal()
        {
            Thread thread = new Thread(TakePhotosSignal);
            thread.Start();
        }

        private static void TakePhotosSignal()
        {
            while (true)
            {
                try
                {
                    if (Global.Instance.melsecFx != null && Global.Instance.melsecFx.IsOpen())
                    {
                        int Camera_Tack_Aaddress_Value = Global.Instance.melsecFx.ReadInt32(Global.Instance.Camera_Tack_Aaddress).Content;
                        if (Camera_Tack_Aaddress_Value == 1)
                        {
                            Global.Instance.RunningLog.WriteRunLog("收到PLC拍照信号:" + Global.Instance.Camera_Tack_Aaddress + "=" + Camera_Tack_Aaddress_Value);
                            Cameras.Instance[0].Soft_Trigger();
                            Global.Instance.melsecFx.Write(Global.Instance.Camera_Tack_Aaddress, 0);
                            Global.Instance.RunningLog.WriteRunLog("复位PLC拍照信号:" + Global.Instance.Camera_Tack_Aaddress + "=" + 0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Global.Instance.RunningLog.WriteErrorLog("获取PLC拍照信号:" + ex.Message);
                }
                Thread.Sleep(10);
            }
        }
        #endregion
    }
}
