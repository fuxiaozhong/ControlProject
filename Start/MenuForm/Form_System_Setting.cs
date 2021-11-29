using System;
using System.Threading;
using System.Windows.Forms;

using HYProject.Helper;
using ToolKit.HYControls;
using ToolKit.HYControls.HYForm;

namespace HYProject.MenuForm
{
    public partial class Form_System_Setting : HYBaseForm
    {
        public Form_System_Setting()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
            }
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = fbd.SelectedPath;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            flag = false;
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, EventArgs e)
        {
            AppParam.Instance.Save_Image_Path = textBox1.Text;
            AppParam.Instance.Save_Data_Path = textBox2.Text;
            AppParam.Instance.Save_Image_Days = (int)numericUpDown1.Value;
            AppParam.Instance.Log_Save_Days = (int)hyNumericUpDown1.Value;
            AppParam.Instance.DesktopShortcut = checkBox1.Checked;
            AppParam.Instance.PowerBoot = checkBox2.Checked;
            AppParam.Instance.RunStateMax = checkBox3.Checked;
            AppParam.Instance.StartBeforeLogin = checkBox4.Checked;
            AppParam.Instance.IsSaveImage = checkBox_save_Image.Checked;
            AppParam.Instance.IsSaveImage_OK = checkBox6.Checked;
            AppParam.Instance.IsSaveImage_NG = checkBox7.Checked;
            AppParam.Instance.IsSaveImage_BmpImage = checkBox8.Checked;
            AppParam.Instance.IsSaveImage_DumpImage = checkBox9.Checked;
            AppParam.Instance.StartAutoRun = check_startAutoRun.Checked;

            PowerBoot.SetMeAutoStart(AppParam.Instance.PowerBoot);
            PowerBoot.CreateDesktopShortcut(AppParam.Instance.DesktopShortcut);
            AppParam.Instance.Save_To_File();
            ShowOKTip("保存成功");
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Setting_Load(object sender, EventArgs e)
        {
            textBox1.Text = AppParam.Instance.Save_Image_Path;
            textBox2.Text = AppParam.Instance.Save_Data_Path;
            numericUpDown1.Value = AppParam.Instance.Save_Image_Days;
            hyNumericUpDown1.Value = AppParam.Instance.Log_Save_Days;
            checkBox1.Checked = AppParam.Instance.DesktopShortcut;
            checkBox2.Checked = AppParam.Instance.PowerBoot;
            checkBox3.Checked = AppParam.Instance.RunStateMax;
            checkBox4.Checked = AppParam.Instance.StartBeforeLogin;
            checkBox_save_Image.Checked = AppParam.Instance.IsSaveImage;
            checkBox6.Checked = AppParam.Instance.IsSaveImage_OK;
            checkBox7.Checked = AppParam.Instance.IsSaveImage_NG;
            checkBox8.Checked = AppParam.Instance.IsSaveImage_BmpImage;
            checkBox9.Checked = AppParam.Instance.IsSaveImage_DumpImage;
            check_startAutoRun.Checked = AppParam.Instance.StartAutoRun;
            flag = true;
            Thread thread = new Thread(DiskRefresh)
            {
                IsBackground = true
            };
            thread.Start();
        }
        bool flag = false;
        /// <summary>
        /// 图像、数据保存磁盘检测
        /// </summary>
        private void DiskRefresh()
        {
            while (flag)
            {
                try
                {
                    long TotalFreeSpace = new long();
                    long TotalSize = new long();
                    string sidkName = AppParam.Instance.Save_Image_Path.Substring(0, 1) + ":\\";
                    System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
                    foreach (System.IO.DriveInfo drive in drives)
                    {
                        if (drive.Name == sidkName)
                        {
                            TotalFreeSpace = drive.TotalFreeSpace / 1024 / 1024 / 1024;//剩余容量
                            TotalSize = drive.TotalSize / 1024 / 1024 / 1024; //总容量
                            label7.Text = "剩余：" + TotalFreeSpace + "GB/总：" + TotalSize + "GB";
                            progressBar1.Value = 100 - (int)((double)TotalFreeSpace / (double)TotalSize * 100);
                            break;
                        }
                    }
                    sidkName = AppParam.Instance.Save_Data_Path.Substring(0, 1) + ":\\";
                    foreach (System.IO.DriveInfo drive in drives)
                    {
                        if (drive.Name == sidkName)
                        {
                            TotalFreeSpace = drive.TotalFreeSpace / 1024 / 1024 / 1024;//剩余容量
                            TotalSize = drive.TotalSize / 1024 / 1024 / 1024; //总容量
                            label8.Text = "剩余：" + TotalFreeSpace + "GB/总：" + TotalSize + "GB";
                            progressBar2.Value = 100 - (int)((double)TotalFreeSpace / (double)TotalSize * 100);
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                }

                Thread.Sleep(100);
                Application.DoEvents();
            }
        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = checkBox_save_Image.Checked;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                AppParam.Instance.lightSource.StateCH1 = true;
                Thread.Sleep(70);
                AppParam.Instance.lightSource.StateCH1 = false;

                AppParam.Instance.lightSource.StateCH2 = true;
                Thread.Sleep(70);
                AppParam.Instance.lightSource.StateCH2 = false;

                AppParam.Instance.lightSource.StateCH3 = true;
                Thread.Sleep(70);
                AppParam.Instance.lightSource.StateCH3 = false;

                AppParam.Instance.lightSource.StateCH4 = true;
                Thread.Sleep(70);
                AppParam.Instance.lightSource.StateCH4 = false;
            }

        }

        private void hySwitch1_Click(object sender, EventArgs e)
        {
            if ((sender as HYSwitch).Name.Contains("Left"))
            {
                AppParam.Instance.lightSource.StateCH1 = (sender as HYSwitch).Checked;
            }
            if ((sender as HYSwitch).Name.Contains("Min"))
            {
                AppParam.Instance.lightSource.StateCH2 = (sender as HYSwitch).Checked;
            }
            if ((sender as HYSwitch).Name.Contains("Right"))
            {
                AppParam.Instance.lightSource.StateCH3 = (sender as HYSwitch).Checked;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Text == "全部打开")
            {
                AppParam.Instance.lightSource.OpenAllCH();
                (sender as Button).Text = "全部关闭";
            }
            else
            {
                AppParam.Instance.lightSource.CloseAllCH();
                (sender as Button).Text = "全部打开";

            }
        }

        private void Form_System_Setting_FormClosing(object sender, FormClosingEventArgs e)
        {

            flag = false;
        }
    }
}