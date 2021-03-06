using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using HalconDotNet;

namespace HYProject.Helper
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
                        instance = new QueueSaveImage();
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
        /// 已处理
        /// </summary>
        private long index = 0;

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
                SavePath = AppParam.Instance.Save_Image_Path + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff")
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
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        ImageParam image = null;
                        var isExit = queues.TryDequeue(out image);
                        if (!isExit)
                        {
                            Thread.Sleep(500);
                            continue;
                        }
                        try
                        {
                            index++;
                            HOperatorSet.WriteImage(image.image, "bmp", 0, image.SavePath);
                            image.image.Dispose();
                            sw.Stop();
                            Console.WriteLine(string.Format("ThreadID:" + Thread.CurrentThread.ManagedThreadId.ToString() + "--- 共{0}条 当前第{1}条,保存成功,耗时{2}ms", queues.Count, index, sw.ElapsedMilliseconds));
                           }
                        catch (Exception ex)
                        {
                            sw.Stop();
                            Console.WriteLine("ThreadID:" + Thread.CurrentThread.ManagedThreadId.ToString() + "   -- SaveImage: " + ex.Message + ",保存失败, 耗时:" + sw.ElapsedMilliseconds + "ms");
                           }
                    }
                }
                catch (Exception ex)
                {
                  
                }
                Thread.Sleep(30);
            }
        }
    }
}