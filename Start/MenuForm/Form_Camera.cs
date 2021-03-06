using System;
using System.Windows.Forms;

using HYProject.Model;
using ToolKit.DisplayWindow;
using ToolKit.HYControls.HYForm;

using HalconDotNet;

namespace HYProject.MenuForm
{
    public partial class Form_Camera : HYBaseForm
    {
        private static Form_Camera instance;
        public static Form_Camera Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Form_Camera();
                }
                return instance;
            }
        }
        private Form_Camera()
        {
            InitializeComponent();
        }

        private void Form_Camera_Load(object sender, EventArgs e)
        {
            AppParam.Instance.lightSource.OpenAllCH();

            //初始化相机  列举相机列表
            comboBox_CamList.Items.Clear();
            foreach (var item in Cameras.Instance.GetCameras.Keys)
            {
                comboBox_CamList.Items.Add(item);
                //Cameras.Instance[item].ClearImageProcessEvents();
                //Cameras.Instance[item].ImageProcessEvent += this.Form_Camera_ImageProcessEvent;
            }
            if (comboBox_CamList.Items.Count > 0)
            {
                comboBox_CamList.SelectedIndex = 0;
            }
            else
            {
                num_gain.Enabled = false;
                num_exposuretime.Enabled = false;
                comboBox_TriggerMode.Enabled = false;
                comboBox_TriggerSource.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button_Save.Enabled = false;
            }
            comboBox_TriggerMode.SelectedIndex = 0;
            comboBox_TriggerSource.SelectedIndex = 0;
        }

        public void Form_Camera_ImageProcessEvent(string cameraName, HalconDotNet.HObject ho_image)
        {
            //显示图像
            displayWindow1.Disp_Image(ho_image);
            displayWindow1.Disp_Message(DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss:ffff"),16,10,10,"green");
        }

        private void ComboBox_CamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (button3.Text == "停止实时")
            {
                foreach (var item in Cameras.Instance.GetCameras.Keys)
                {
                    Cameras.Instance[item].End_Real_Mode();
                }
                button3.Text = "实时模式";
            }
            //刷新数据
            Refresh();
            //num_exposuretime.Value = (decimal)Cameras.Instance[this.comboBox_CamList.Text].Get_Exposure_Time();
            //num_gain.Value = (decimal)Cameras.Instance[this.comboBox_CamList.Text].Get_Gain();
            //comboBox_TriggerMode.Text = Cameras.Instance[this.comboBox_CamList.Text].Get_TriggerMode();
            //comboBox_TriggerSource.Text = Cameras.Instance[this.comboBox_CamList.Text].Get_TriggerSource();
        }

        private void Refresh()
        {
            label_exposuretime.Text = Cameras.Instance[comboBox_CamList.Text].Get_Exposure_Time().ToString();
            label_Gain.Text = Cameras.Instance[comboBox_CamList.Text].Get_Gain().ToString("0");
            label_TriggerMode.Text = Cameras.Instance[comboBox_CamList.Text].Get_TriggerMode().ToString();
            label_TriggerSource.Text = Cameras.Instance[comboBox_CamList.Text].Get_TriggerSource().ToString();
            num_exposuretime.Value = (decimal)Cameras.Instance[this.comboBox_CamList.Text].Get_Exposure_Time();
            num_gain.Value = (decimal)Cameras.Instance[this.comboBox_CamList.Text].Get_Gain();
            comboBox_TriggerMode.Text = Cameras.Instance[this.comboBox_CamList.Text].Get_TriggerMode();
            comboBox_TriggerSource.Text = Cameras.Instance[this.comboBox_CamList.Text].Get_TriggerSource();
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            //设置相机参数
            Cameras.Instance[comboBox_CamList.Text].Set_Exposure_Time((double)this.num_exposuretime.Value);
            Cameras.Instance[comboBox_CamList.Text].Set_Gain((double)this.num_gain.Value);
            Cameras.Instance[comboBox_CamList.Text].Set_TriggerMode(this.comboBox_TriggerMode.Text);
            Cameras.Instance[comboBox_CamList.Text].Set_TriggerSource(this.comboBox_TriggerSource.Text);
            Refresh();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //软触发
            Cameras.Instance[comboBox_CamList.Text].Soft_Trigger();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "实时模式")
            {
                button3.Text = "停止实时";
                Cameras.Instance[comboBox_CamList.Text].Start_Real_Mode();
                comboBox_CamList.Enabled = false;
            }
            else
            {
                button3.Text = "实时模式";
                Cameras.Instance[comboBox_CamList.Text].End_Real_Mode();
                comboBox_CamList.Enabled = true;
            }
            Refresh();
        }

        /// <summary>
        /// 退出小计操作 绑定运行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppParam.Instance.lightSource.CloseAllCH();
            foreach (var item in Cameras.Instance.GetCameras.Keys)
            {
                //关闭实时
                Cameras.Instance[item].End_Real_Mode();
                System.Threading.Thread.Sleep(300);
                //清空事件
                //Cameras.Instance[item].ClearImageProcessEvents();
                ////重新绑定运行事件
                //Cameras.Instance[item].ImageProcessEvent += Cameras.Instance.Camera_ImageProcessEvent;
            }
            AppParam.Instance.Form_Camera_State = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            displayWindow1.Save_Image(displayWindow1.Image);
        }

        private void Form_Camera_Activated(object sender, EventArgs e)
        {
            AppParam.Instance.Form_Camera_State = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rectangle1 rectangle1 = displayWindow1.Draw_Rectangle1("blue");
            HOperatorSet.ReduceDomain(displayWindow1.Image, rectangle1.rectangle1, out rectangle1.rectangle1);
            HOperatorSet.BinaryThreshold(rectangle1.rectangle1, out rectangle1.rectangle1, "max_separability", "dark", out _);
            HOperatorSet.AreaCenter(rectangle1.rectangle1, out _, out HTuple R, out HTuple C);

            HTuple Robot_Point1_X3, Robot_Point1_Y3;
            HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam3_HomMat2d1,
                 R,
                 C, out Robot_Point1_Y3, out Robot_Point1_X3);
            displayWindow1.Disp_Message("X:"+Robot_Point1_Y3.D +"\nY:"+ Robot_Point1_X3.D, 16, 500, 20, "blue");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Rectangle1 rectangle1 = displayWindow1.Draw_Rectangle1("blue");
            HOperatorSet.ReduceDomain(displayWindow1.Image, rectangle1.rectangle1, out rectangle1.rectangle1);
            HOperatorSet.BinaryThreshold(rectangle1.rectangle1, out rectangle1.rectangle1, "max_separability", "dark", out _);
            HOperatorSet.AreaCenter(rectangle1.rectangle1, out _, out HTuple R, out HTuple C);

            HTuple Robot_Point1_X3, Robot_Point1_Y3;
            HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam3_HomMat2d2,
                 R,
                 C, out Robot_Point1_Y3, out Robot_Point1_X3);
            displayWindow1.Disp_Message("X:" + Robot_Point1_Y3.D + "\nY:" + Robot_Point1_X3.D, 16, 500, 20, "blue");
        }
    }
}