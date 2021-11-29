using System;
using System.Threading;
using System.Threading.Tasks;
using HYProject.ToolForm;

namespace HYProject.Helper
{
    public class SystemThread
    {

        public static void Start()
        {
            Task.Run(() =>
            {
                Global_SystemWork();
            });
        }
        static DateTime startTime;
        private static void Global_SystemWork()
        {
            while (true)
            {
                try
                {
                    if (AppParam.Instance.Power == "操作员")
                    {
                        startTime = DateTime.Now;
                    }
                    else
                    {
                        if ((DateTime.Now - startTime).Minutes >= 5)
                        {
                            AppParam.Instance.Power = "操作员";
                        }
                    }

                    if (AppParam.Instance.Power == "管理员" || AppParam.Instance.Power == "开发人员")
                    {
                        Form_Offset.Instance.ControlEnabled(true);
                        Form_General_Parameters.Instance.ControlEnabled(true);
                    }
                    else
                    {
                        Form_Offset.Instance.ControlEnabled(false);
                        Form_General_Parameters.Instance.ControlEnabled(false);
                    }
                    PowerBoot.QuickName = (Form_Global_System.Instance["标题栏"] == null ? "视觉软件" : Form_Global_System.Instance["标题栏"].ToString());
                    PowerBoot.SetMeAutoStart(AppParam.Instance.PowerBoot);
                    PowerBoot.CreateDesktopShortcut(AppParam.Instance.DesktopShortcut);
                    MainForm.Instance.UserName = AppParam.Instance.Power;
                    SystemInfo systemInfo = new SystemInfo();
                    MainForm.Instance.pro_memory.Value = (int)Math.Ceiling(((double)((systemInfo.PhysicalMemory - systemInfo.MemoryAvailable)) / (double)(systemInfo.PhysicalMemory) * 100));
                    MainForm.Instance.tsl_nowtime.Text = DateTime.Now.ToString(Form_Global_System.Instance["日期格式"] == null ? "yyyy-MM-dd HH:mm:ss" : Form_Global_System.Instance["日期格式"].ToString());
                    MainForm.Instance.Text = (Form_Global_System.Instance["标题栏"] == null ? "视觉软件" : Form_Global_System.Instance["标题栏"].ToString());
                    MainForm.Instance.toolStrip_Version.Text = "版本号:" + (Form_Global_System.Instance["版本号"] == null ? "v1.0.0" : Form_Global_System.Instance["版本号"].ToString());
                    MainForm.Instance.系统设置ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["系统设置"] == null ? true : Form_Global_System.Instance["系统设置"]));
                    MainForm.Instance.用户设置ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["用户设置"] == null ? true : Form_Global_System.Instance["用户设置"]));
                    MainForm.Instance.通讯设置ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["通讯设置"] == null ? true : Form_Global_System.Instance["通讯设置"]));
                    MainForm.Instance.相机ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["相机"] == null ? true : Form_Global_System.Instance["相机"]));
                    MainForm.Instance.设置ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["设置"] == null ? true : Form_Global_System.Instance["设置"]));
                    MainForm.Instance.产品库ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["产品库"] == null ? true : Form_Global_System.Instance["产品库"]));
                    MainForm.Instance.工具ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["工具"] == null ? true : Form_Global_System.Instance["工具"]));
                    MainForm.Instance.锁定ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["锁定"] == null ? true : Form_Global_System.Instance["锁定"]));
                    MainForm.Instance.相机配置ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["相机配置"] == null ? true : Form_Global_System.Instance["相机配置"]));
                    MainForm.Instance.光源配置ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["光源配置"] == null ? true : Form_Global_System.Instance["光源配置"]));
                    // MainForm.Instance.全局变量ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["全局变量"] == null ? true : Form_Global_System.Instance["全局变量"]));
                    MainForm.Instance.屏幕键盘ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["屏幕键盘"] == null ? true : Form_Global_System.Instance["屏幕键盘"]));
                    MainForm.Instance.pLC配置ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["PLC配置"] == null ? true : Form_Global_System.Instance["PLC配置"]));
                    MainForm.Instance.系统操作ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["系统操作"] == null ? true : Form_Global_System.Instance["系统操作"]));
                    MainForm.Instance.用户变量ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["用户变量"] == null ? true : Form_Global_System.Instance["用户变量"]));
                    //MainForm.Instance.系统变量ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["系统变量"] == null ? true : Form_Global_System.Instance["系统变量"]));
                    MainForm.Instance.备份ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["备份"] == null ? true : Form_Global_System.Instance["备份"]));
                    MainForm.Instance.重启ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["重启"] == null ? true : Form_Global_System.Instance["重启"]));
                    MainForm.Instance.tCP服务端ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["TCP服务端"] == null ? true : Form_Global_System.Instance["TCP服务端"]));
                    MainForm.Instance.tCP客户端ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["TCP客户端"] == null ? true : Form_Global_System.Instance["TCP客户端"]));
                    MainForm.Instance.splitContainer_Main.Panel2Collapsed = !((bool)(Form_Global_System.Instance["数据面板"] == null ? true : Form_Global_System.Instance["数据面板"]));


                    Form_Offset.Instance.grop_Cam1.Visible = ((bool)(Form_Global_System.Instance["Cam1补偿"] == null ? true : Form_Global_System.Instance["Cam1补偿"]));
                    Form_Offset.Instance.grop_Cam2.Visible = ((bool)(Form_Global_System.Instance["Cam2补偿"] == null ? true : Form_Global_System.Instance["Cam2补偿"]));
                    Form_Offset.Instance.grop_Cam3.Visible = ((bool)(Form_Global_System.Instance["Cam3补偿"] == null ? true : Form_Global_System.Instance["Cam3补偿"]));

                    Form_General_Parameters.Instance.grop_Cam1.Visible = ((bool)(Form_Global_System.Instance["Cam1补偿"] == null ? true : Form_Global_System.Instance["Cam1补偿"]));
                    Form_General_Parameters.Instance.grop_Cam2.Visible = ((bool)(Form_Global_System.Instance["Cam2补偿"] == null ? true : Form_Global_System.Instance["Cam2补偿"]));
                    Form_General_Parameters.Instance.grop_Cam3.Visible = ((bool)(Form_Global_System.Instance["Cam3补偿"] == null ? true : Form_Global_System.Instance["Cam3补偿"]));

                    MainForm.Instance.grop_Cam1_Count.Visible = ((bool)(Form_Global_System.Instance["Cam1补偿"] == null ? true : Form_Global_System.Instance["Cam1补偿"]));
                    MainForm.Instance.grop_Cam2_Count.Visible = ((bool)(Form_Global_System.Instance["Cam2补偿"] == null ? true : Form_Global_System.Instance["Cam2补偿"]));
                    MainForm.Instance.grop_Cam3_Count.Visible = ((bool)(Form_Global_System.Instance["Cam3补偿"] == null ? true : Form_Global_System.Instance["Cam3补偿"]));

                }
                catch (Exception ex)
                {
                    Log.WriteErrorLog("Global_SystemWork:" + ex.Message, ex);
                }
                Thread.Sleep(300);
            }
        }
    }
}