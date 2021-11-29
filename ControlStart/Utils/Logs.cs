using ControlStart.Config;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStart.Utils
{
    public class Logs
    {

        public Logs(Control c)
        {
            this.control = c;
        }

        public Control control;
        public string name = "运行日志";


        /// <summary>
        /// 显示队列
        /// </summary>
        private ConcurrentQueue<LogInfo> Dispqueues = new ConcurrentQueue<LogInfo>();

        /// <summary>
        /// 显示线程
        /// </summary>
        private Thread DispLog;


        /// <summary>
        /// 保存CSV队列
        /// </summary>
        private ConcurrentQueue<LogInfo> SaveCSVQueues = new ConcurrentQueue<LogInfo>();

        /// <summary>
        /// 保存CSV线程
        /// </summary>
        private Thread SaveSCV;

        /// <summary>
        /// 保存CSV线程
        /// </summary>
        private Thread DeleteSCV;

        /// <summary>
        /// 添加队列
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        private void DispMessage(string message, string type)
        {
            //if (message.Contains(","))
            //{
            //    message = message.Replace(',', '.');
            //}
            //if (message.Contains("，"))
            //{
            //    message = message.Replace('，', '.');
            //}


            Dispqueues.Enqueue(new LogInfo() { datetime = DateTime.Now, type = type, message = message });
            SaveCSVQueues.Enqueue(new LogInfo() { datetime = DateTime.Now, type = type, message = message });

            if (DispLog == null)
            {
                DispLog = new Thread(DispLogWork);
                DispLog.Priority = ThreadPriority.Highest;
                DispLog.IsBackground = true;
                DispLog.Name = "显示日志文件";
                DispLog.Start();
            }
            if (SaveSCV == null)
            {
                SaveSCV = new Thread(AutoSaveCSV);
                SaveSCV.IsBackground = true;
                SaveSCV.Name = "保存日志文件到CSV";
                SaveSCV.Start();
            }
            if (DeleteSCV == null)
            {
                DeleteSCV = new Thread(DeleteCSV);

                DeleteSCV.IsBackground = true;
                DeleteSCV.Name = "删除日志文件";
                DeleteSCV.Start();
            }

        }



        /// <summary>
        /// 功能描述:写入警告日志
        /// </summary>
        /// <param name="strWarnLog">strWarnLog</param>
        public void WriteWarnLog(string strWarnLog)
        {
            DispMessage(strWarnLog, "警告");
        }

        /// <summary>
        /// 功能描述:写入错误日志
        /// </summary>
        /// <param name="strErrLog">strErrLog</param>
        /// <param name="ex">ex</param>
        public void WriteErrorLog(string strErrLog, Exception ex = null)
        {
            DispMessage(strErrLog, "异常");
        }

        /// <summary>
        /// 功能描述:写入运行日志
        /// </summary>
        /// <param name="runmessage">strErrLog</param>
        public void WriteRunLog(string runmessage)
        {
            DispMessage(runmessage, "正常");
        }
        private object obj1 = new object();
        private void DispLogWork()
        {
            while (true)
            {
                try
                {
                    lock (obj1)
                    {
                        LogInfo logMessage = null;
                        var isExit = Dispqueues.TryDequeue(out logMessage);
                        if (!isExit)
                        {
                            Thread.Sleep(10);
                            continue;
                        }

                        (control as RichTextBox).Invoke(new Action(delegate
                        {
                            int startIndex = (control as RichTextBox).TextLength;
                            int endindex = 0;
                            switch (logMessage.type)
                            {
                                case "警告":

                                    (control as RichTextBox).AppendText("[" + logMessage.datetime.ToString("HH:mm:ss:ffff") + "]" + "[" + logMessage.type + "]:" + logMessage.message + "\n");
                                    endindex = (control as RichTextBox).TextLength;
                                    (control as RichTextBox).Select(startIndex, endindex);
                                    (control as RichTextBox).SelectionColor = Color.Orange;
                                    break;

                                case "异常":
                                    (control as RichTextBox).AppendText("[" + logMessage.datetime.ToString("HH:mm:ss:ffff") + "]" + "[" + logMessage.type + "]:" + logMessage.message + "\n");
                                    endindex = (control as RichTextBox).TextLength;
                                    (control as RichTextBox).Select(startIndex, endindex);
                                    (control as RichTextBox).SelectionColor = Color.Red;
                                    break;

                                case "正常":
                                    (control as RichTextBox).AppendText("[" + logMessage.datetime.ToString("HH:mm:ss:ffff") + "]" + "[" + logMessage.type + "]:" + logMessage.message + "\n");
                                    endindex = (control as RichTextBox).TextLength;
                                    (control as RichTextBox).Select(startIndex, endindex);
                                    (control as RichTextBox).SelectionColor = Color.Lime;
                                    break;
                            }
                             (control as RichTextBox).SelectionStart = (control as RichTextBox).TextLength;
                            (control as RichTextBox).ScrollToCaret();
                            GC.Collect();
                        }));
                    }
                }
                catch
                {
                }
                Thread.Sleep(20);

            }
        }

        private object obj = new object();


        DateTime Lastwritetime = DateTime.Now;
        private void AutoSaveCSV()
        {
            while (true)
            {
                try
                {
                    lock (obj)
                    {
                        LogInfo info = null;
                        var isExit = SaveCSVQueues.TryDequeue(out info);
                        if (!isExit)
                        {
                            Thread.Sleep(100);
                            continue;
                        }
                    ggg:
                        string filename = System.AppDomain.CurrentDomain.BaseDirectory + "Vision_Logs\\" + name + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
                        if (!System.IO.Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + @"\\Vision_Logs\\" + name + "\\"))
                            System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + @"\\Vision_Logs\\" + name + "\\");//不存在就创建目录
                        if (File.Exists(filename))
                        {
                            try
                            {
                                File.AppendAllText(filename, info.datetime.ToString("yyyy/MM/dd HH:mm:ss:ffff") + "," + info.type + "," + info.message + "\n", Encoding.Default);
                                Lastwritetime = DateTime.Now;
                                GC.Collect();
                            }
                            catch (Exception)
                            {
                                Thread.Sleep(10);
                                if ((DateTime.Now - Lastwritetime).TotalSeconds > 30)
                                {
                                    WriteErrorLog("日志写入文件失败,请检查!!日志文件是否打开?如已打开请关闭.");
                                    Lastwritetime = DateTime.Now;
                                }
                                goto ggg;
                            }
                        }
                        else
                        {
                            try
                            {
                                File.AppendAllText(filename, "时间,类型,信息\n", Encoding.Default);
                                File.AppendAllText(filename, info.datetime.ToString("yyyy/MM/dd HH:mm:ss:ffff") + "," + info.type + "," + info.message + "\n", Encoding.Default);
                                Lastwritetime = DateTime.Now;
                                GC.Collect();
                            }
                            catch (Exception)
                            {
                                Thread.Sleep(10);
                                if ((DateTime.Now - Lastwritetime).TotalSeconds > 30)
                                {
                                    WriteErrorLog("日志写入文件失败,请检查!!日志文件是否打开?如已打开请关闭.");
                                    Lastwritetime = DateTime.Now;
                                }
                                goto ggg;
                            }
                        }
                    }

                }
                catch
                {

                }

                Thread.Sleep(10);
            }
        }
        private void DeleteCSV()
        {
            while (true)
            {
                if (System.IO.Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + @"\\Vision_Logs\\" + name + "\\"))
                {
                    DirectoryInfo root = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory + @"\\Vision_Logs\\" + name + "\\");
                    foreach (FileInfo f in root.GetFiles())
                    {
                        string name = f.Name;
                        string fullName = f.FullName;

                        if ((DateTime.Now - f.LastWriteTime).TotalDays >= Global.Instance.LogSaveTime)
                        {
                            File.Delete(fullName);
                            GC.Collect();
                        }
                    }

                }
                Thread.Sleep(100);
            }
        }
    }
    internal class LogInfo
    {
        public string type;
        public DateTime datetime;
        public string message;
    }
}
