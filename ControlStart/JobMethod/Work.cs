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
            bool Result = false;
            halconWindow.Disp_Image(image);







            #region  保存图片
             
            string name = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            ////图片保存类型 - OK
            if (Global.Instance.ImageSaveType_OK)
            {
                ////图片保存类型 - 原图
                if (Global.Instance.ImageSaveType_原图)
                {
                    string path = Global.Instance.ImageSavePath + "\\" + camName + "\\OK\\原图";
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    QueueSaveImage.Instance.QueueEnqueue2(image, path+"\\"+name);

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
            if (Global.Instance.ImageSaveType_NG)
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
           
            #endregion


            Global.Instance.RunningLog.WriteRunLog("回复PLC结果:" + (Result ? 1 : 0));
            Global.Instance.melsecFx.Write(Global.Instance.Camera_Result_Aaddress, Result ? 1 : 0);
        }


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
                            Cameras.Instance["Cam1"].Soft_Trigger();
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
    }
}
