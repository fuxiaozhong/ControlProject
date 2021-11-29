using ControlStart.Utils;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStart.ControlForms
{
    public partial class Form_Camera : UserControl
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
        public Form_Camera()
        {
            InitializeComponent();
        }

        private void Camera_Load(object sender, EventArgs e)
        {
            comboBox_CamList.Items.Clear();
            foreach (var item in Cameras.Instance.GetCameras.Keys)
            {
                comboBox_CamList.Items.Add(item);
            }
            if (comboBox_CamList.Items.Count > 0)
            {
                comboBox_CamList.SelectedIndex = 0;
            }
            //this.Dock = DockStyle.Fill;
        }

        public void CamWork(string CamName, HalconDotNet.HObject image)
        {

            halconWindow1.Disp_Image(image);
            halconWindow1.Disp_Message(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff"), 14, 0, 0, "green");
        }

        private void uiButton_singlePhoto_Click(object sender, EventArgs e)
        {
            Cameras.Instance[comboBox_CamList.Text].Soft_Trigger();
        }

        private void uiButton_SaveConfig_Click(object sender, EventArgs e)
        {
            Cameras.Instance[comboBox_CamList.Text].Set_Exposure_Time(uiDoubleUpDown1.Value);
            Cameras.Instance[comboBox_CamList.Text].Set_Gain(uiIntegerUpDown1.Value);
            Cameras.Instance[comboBox_CamList.Text].Set_TriggerMode(uiRadioButton1.Checked ? "On" : "Off");
            Cameras.Instance[comboBox_CamList.Text].Set_TriggerSource(uiComboBox1.Text);
        }

        private void comboBox_CamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            uiDoubleUpDown1.Value = Cameras.Instance[comboBox_CamList.Text].Get_Exposure_Time();
            uiIntegerUpDown1.Value = (int)Cameras.Instance[comboBox_CamList.Text].Get_Gain();

            if (Cameras.Instance[comboBox_CamList.Text].Get_TriggerMode() == "On")
            {
                uiRadioButton1.Checked = true;
            }
            else
            {
                uiRadioButton2.Checked = true;
            }
            uiComboBox1.Text = Cameras.Instance[comboBox_CamList.Text].Get_TriggerSource();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (uiButton1.Text == "实时模式")
            {
                uiButton1.Text = "停止实时";
                comboBox_CamList.Enabled = false;
                uiButton_singlePhoto.Enabled = false;

                Cameras.Instance[comboBox_CamList.Text].Start_Real_Mode();
                comboBox_CamList_SelectedIndexChanged(sender, e);
            }
            else
            {
                uiButton1.Text = "实时模式";
                comboBox_CamList.Enabled = true;
                uiButton_singlePhoto.Enabled = true;
                Cameras.Instance[comboBox_CamList.Text].End_Real_Mode();
                comboBox_CamList_SelectedIndexChanged(sender, e);
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            halconWindow1.Save_Image();
        }
    }
}