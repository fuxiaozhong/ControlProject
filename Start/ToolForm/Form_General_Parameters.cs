using HYProject.Helper;
using HYProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HYProject.ToolForm
{
    public partial class Form_General_Parameters : ToolKit.HYControls.HYForm.HYBaseForm
    {
        private static Form_General_Parameters instance;

        public static Form_General_Parameters Instance
        {
            get
            {
                if (instance == null||instance.IsDisposed)
                {
                    instance = new Form_General_Parameters();
                    instance.FormBorderStyle = FormBorderStyle.None;
                    instance.TopLevel = false;
                    instance.Dock = DockStyle.Fill;
                    instance.Show();
                }
                return instance;
            }
        }
        private Form_General_Parameters()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (AppParam.Instance.Power == "管理员" || AppParam.Instance.Power == "开发人员")
            {
                CalibrationData.Instance.Cam1_Standard1_Point.X = (double)num_Cam1_X1.Value;
                CalibrationData.Instance.Cam1_Standard1_Point.Y = (double)num_Cam1_Y1.Value;
                CalibrationData.Instance.Cam1_Standard1_Point.U = (double)num_Cam1_R1.Value;
                CalibrationData.Instance.Cam1_Standard2_Point.X = (double)num_Cam1_X2.Value;
                CalibrationData.Instance.Cam1_Standard2_Point.Y = (double)num_Cam1_Y2.Value;
                CalibrationData.Instance.Cam1_Standard2_Point.U = (double)num_Cam1_R2.Value;

                CalibrationData.Instance.Cam2_Standard1_Point.X = (double)num_Cam2_X1.Value;
                CalibrationData.Instance.Cam2_Standard1_Point.Y = (double)num_Cam2_Y1.Value;
                CalibrationData.Instance.Cam2_Standard1_Point.U = (double)num_Cam2_R1.Value;
                CalibrationData.Instance.Cam2_Standard2_Point.X = (double)num_Cam2_X2.Value;
                CalibrationData.Instance.Cam2_Standard2_Point.Y = (double)num_Cam2_Y2.Value;
                CalibrationData.Instance.Cam2_Standard2_Point.U = (double)num_Cam2_R2.Value;

                CalibrationData.Instance.Cam3_Standard1_Point.X = (double)num_Cam3_X1.Value;
                CalibrationData.Instance.Cam3_Standard1_Point.Y = (double)num_Cam3_Y1.Value;
                CalibrationData.Instance.Cam3_Standard1_Point.U = (double)num_Cam3_R1.Value;
                CalibrationData.Instance.Cam3_Standard2_Point.X = (double)num_Cam3_X2.Value;
                CalibrationData.Instance.Cam3_Standard2_Point.Y = (double)num_Cam3_Y2.Value;
                CalibrationData.Instance.Cam3_Standard2_Point.U = (double)num_Cam3_R2.Value;

                Serialization.Save(CalibrationData.Instance, "CalibrationData");
                ShowNormal("保存成功");
            }
            else
            {
                ShowWarn("权限不足无法修改，请登陆管理员模式");
                Form_General_Parameters_Load(sender, e);
            }
        }

        public void ControlEnabled(bool flag)
        {

            tableLayoutPanel1.Enabled = flag;
        }

        public void Form_General_Parameters_Load(object sender, EventArgs e)
        {
            num_Cam1_X1.Value = (decimal)CalibrationData.Instance.Cam1_Standard1_Point.X;
            num_Cam1_Y1.Value = (decimal)CalibrationData.Instance.Cam1_Standard1_Point.Y;
            num_Cam1_R1.Value = (decimal)CalibrationData.Instance.Cam1_Standard1_Point.U;
            num_Cam1_X2.Value = (decimal)CalibrationData.Instance.Cam1_Standard2_Point.X;
            num_Cam1_Y2.Value = (decimal)CalibrationData.Instance.Cam1_Standard2_Point.Y;
            num_Cam1_R2.Value = (decimal)CalibrationData.Instance.Cam1_Standard2_Point.U;

            num_Cam2_X1.Value = (decimal)CalibrationData.Instance.Cam2_Standard1_Point.X;
            num_Cam2_Y1.Value = (decimal)CalibrationData.Instance.Cam2_Standard1_Point.Y;
            num_Cam2_R1.Value = (decimal)CalibrationData.Instance.Cam2_Standard1_Point.U;
            num_Cam2_X2.Value = (decimal)CalibrationData.Instance.Cam2_Standard2_Point.X;
            num_Cam2_Y2.Value = (decimal)CalibrationData.Instance.Cam2_Standard2_Point.Y;
            num_Cam2_R2.Value = (decimal)CalibrationData.Instance.Cam2_Standard2_Point.U;

            num_Cam3_X1.Value = (decimal)CalibrationData.Instance.Cam3_Standard1_Point.X;
            num_Cam3_Y1.Value = (decimal)CalibrationData.Instance.Cam3_Standard1_Point.Y;
            num_Cam3_R1.Value = (decimal)CalibrationData.Instance.Cam3_Standard1_Point.U;
            num_Cam3_X2.Value = (decimal)CalibrationData.Instance.Cam3_Standard2_Point.X;
            num_Cam3_Y2.Value = (decimal)CalibrationData.Instance.Cam3_Standard2_Point.Y;
            num_Cam3_R2.Value = (decimal)CalibrationData.Instance.Cam3_Standard2_Point.U;
        }

       
    }
}
