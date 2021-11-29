using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStart.ControlForms
{
    public partial class Form_Data : UserControl
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
        public Form_Data()
        {
            InitializeComponent();
            //this.Dock = DockStyle.Fill;

        }

        private void Form_Data_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Process[] processes = Process.GetProcessesByName(System.IO.Path.GetFileName(Application.ExecutablePath).Replace(".exe", ""));

                foreach (Process instance in processes)
                {
                    Console.WriteLine("");
                    Console.WriteLine("ProcessName:" + instance.ProcessName);
                    try
                    {
                        Console.WriteLine("工作设置(内存)\t" + instance.WorkingSet64 / 1024);
                        Console.WriteLine("线程数\t" + instance.Threads.Count);
                        Console.WriteLine("句柄数\t" + instance.HandleCount);

                    }
                    catch { }
                }
                if (processes.Length > 0)
                {
                    Process p = processes[0];
                    var objQuery = new ObjectQuery("select * from Win32_Process WHERE ProcessID = " + p.Id);
                    var moSearcher = new ManagementObjectSearcher(objQuery);
                    DateTime firstSample = DateTime.MinValue, secondSample = DateTime.MinValue;

                    double ProcessorUsage;
                    double msPassed;
                    ulong u_OldCPU = 0;
                    while (true)
                    {
                        var gets = moSearcher.Get();
                        foreach (ManagementObject mObj in gets)
                        {
                            try
                            {
                                if (firstSample == DateTime.MinValue)
                                {
                                    firstSample = DateTime.Now;
                                    mObj.Get();
                                    u_OldCPU = (ulong)mObj["UserModeTime"] + (ulong)mObj["KernelModeTime"];
                                }
                                else
                                {
                                    secondSample = DateTime.Now;
                                    mObj.Get();
                                    ulong u_newCPU = (ulong)mObj["UserModeTime"] + (ulong)mObj["KernelModeTime"];

                                    msPassed = (secondSample - firstSample).TotalMilliseconds;
                                    ProcessorUsage = (u_newCPU - u_OldCPU) / (msPassed * 100.0 * Environment.ProcessorCount);

                                    u_OldCPU = u_newCPU;
                                    firstSample = secondSample;
                                    //  toolStripLabel2.Text = "CPU:" + ProcessorUsage.ToString("0.0") + "%";
                                    uiRoundProcess1.Invoke(new Action(() =>
                                    {
                                        uiRoundProcess1.Value = (int)ProcessorUsage;
                                    }));
                                   // Console.WriteLine("ProcessorUsage:" + (int)ProcessorUsage);
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message + ex.StackTrace);
                                Console.WriteLine(ex.InnerException.Message);
                            }
                        }
                        Thread.Sleep(200);
                    }
                }

            });
        }
    }
}
