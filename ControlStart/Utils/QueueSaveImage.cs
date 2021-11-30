using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using ControlStart.Config;

using HalconDotNet;

namespace ControlStart.Utils
{
    public class ImageParam
    {
        public HObject image;
        public string SavePath;
    }

    public class QueueSaveImage
    {
        private static QueueSaveImage instance;

        /// <summary>
        /// 初始化当前类(单例模式)
        /// </summary>
        public static QueueSaveImage Instance
        {
            get
            {
                //先判断是否存在，不存在再加锁处理
                if (instance == null)
                {
                    //在同一个时刻加了锁的那部分程序只有一个线程可以进入
                    if (instance == null)
                    {
                        instance = new QueueSaveImage(2);
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// 线程总数
        /// </summary>
        private int threadNum = 4;


        /// <summary>
        /// 队列
        /// </summary>
        private ConcurrentQueue<ImageParam> queues = new ConcurrentQueue<ImageParam>();

        private List<Thread> threads = new List<Thread>();

        private object obj = new object();

        private QueueSaveImage(int ThreadCount = 4)
        {
            threadNum = ThreadCount;
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < threadNum; i++)
            {
                Thread thread = new Thread(SaveImage);
                threads.Add(thread);
                thread.Start();
            }
            Thread checkImage = new Thread(CheckImage);

            checkImage.Start();
        }


        /// <summary>
        /// 检查图片存储到齐
        /// </summary>
        private void CheckImage()
        {
            while (true)
            {
                try
                {
                    if (Directory.Exists(Global.Instance.ImageSavePath))
                    {
                        Director(Global.Instance.ImageSavePath);
                    }
                    else
                    {
                        Directory.CreateDirectory(Global.Instance.ImageSavePath);
                    }

                }
                catch (Exception)
                {
                }
                Thread.Sleep(1000 * 10);//10S检查一次
            }
        }

        private static void Director(string dir)
        {
            DirectoryInfo d = new DirectoryInfo(dir);
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos();
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)     //判断是否为文件夹
                {
                    Director(fsinfo.FullName);//递归调用
                }
                else
                {
                    TimeSpan t = DateTime.Now - fsinfo.LastWriteTime;  //当前时间  减去 文件创建时间
                    int day = t.Days;
                    if (day >= Global.Instance.ImageSaveTime)   //保存的时间 ;  单位：天
                    {
                        File.Delete(fsinfo.FullName);  //删除超过时间的文件
                        Global.Instance.RunningLog.WriteRunLog("图片:" + fsinfo.Name + "储存到期,已自动删除");
                    }
                }
            }
        }

        ~QueueSaveImage()
        {
            for (int i = 0; i < threadNum; i++)
            {
                threads[i].Abort();
            }
        }


        /// <summary>
        /// 添加要保存的图像加名称
        /// </summary>
        /// <param name="image"></param>
        public void QueueEnqueue(ImageParam image)
        {
            queues.Enqueue(image);
        }

        /// <summary>
        /// 添加要保存的图像,当前时间格式化作为文件名  存在默认文件夹下
        /// </summary>
        /// <param name="ho_image"></param>
        public void QueueEnqueue2(HObject ho_image)
        {
            ImageParam image = new ImageParam()
            {
                image = ho_image.Clone(),
                SavePath = Global.Instance.ImageSavePath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff")
            };
            queues.Enqueue(image);
        }

        /// <summary>
        /// 保存图像指定文件名(指定路径:默认路径)
        /// </summary>
        /// <param name="ho_image"></param>
        /// <param name="name"></param>
        public void QueueEnqueue2(HObject ho_image, string name)
        {
            ImageParam image = new ImageParam()
            {
                image = ho_image.Clone(),
                SavePath = Global.Instance.ImageSavePath + "\\" + name
            };
            queues.Enqueue(image);
        }/// <summary>
         /// 保存图像指定文件名(包括路径)
         /// </summary>
         /// <param name="ho_image"></param>
         /// <param name="name"></param>
        public void QueueEnqueue3(HObject ho_image, string name)
        {
            ImageParam image = new ImageParam()
            {
                image = ho_image.Clone(),
                SavePath = name
            };
            queues.Enqueue(image);
        }

        private void SaveImage()
        {
            while (true)
            {
                try
                {
                    lock (obj)
                    {
                        ImageParam image = null;
                        var isExit = queues.TryDequeue(out image);
                        if (!isExit)
                        {
                            Thread.Sleep(500);
                            continue;
                        }
                        HOperatorSet.WriteImage(image.image, "bmp", 0, image.SavePath);
                        image.image.Dispose();
                    }
                }
                catch (Exception)
                {
                }
                Thread.Sleep(30);
            }
        }
    }
}