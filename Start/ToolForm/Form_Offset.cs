using HYProject.Helper;
using HYProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolKit.HYControls.HYForm;

namespace HYProject.ToolForm
{
    public partial class Form_Offset : HYBaseForm
    {

        private static Form_Offset instance;

        public static Form_Offset Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Form_Offset();
                    instance.FormBorderStyle = FormBorderStyle.None;
                    instance.TopLevel = false;
                    instance.Dock = DockStyle.Fill;
                    instance.Show();
                }
                return instance;
            }
        }
        public Form_Offset()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (AppParam.Instance.Power == "管理员" || AppParam.Instance.Power == "开发人员")
            {
                Offset.Instance.Cam1_OffsetX1 = (double)num_Cam1_OffsetX1.Value;
                Offset.Instance.Cam1_OffsetY1 = (double)num_Cam1_OffsetY1.Value;
                Offset.Instance.Cam1_OffsetR1 = (double)num_Cam1_OffsetR1.Value;
                Offset.Instance.Cam1_OffsetX2 = (double)num_Cam1_OffsetX2.Value;
                Offset.Instance.Cam1_OffsetY2 = (double)num_Cam1_OffsetY2.Value;
                Offset.Instance.Cam1_OffsetR2 = (double)num_Cam1_OffsetR2.Value;

                Offset.Instance.Cam2_OffsetX1 = (double)num_Cam2_OffsetX1.Value;
                Offset.Instance.Cam2_OffsetY1 = (double)num_Cam2_OffsetY1.Value;
                Offset.Instance.Cam2_OffsetR1 = (double)num_Cam2_OffsetR1.Value;
                Offset.Instance.Cam2_OffsetX2 = (double)num_Cam2_OffsetX2.Value;
                Offset.Instance.Cam2_OffsetY2 = (double)num_Cam2_OffsetY2.Value;
                Offset.Instance.Cam2_OffsetR2 = (double)num_Cam2_OffsetR2.Value;

                Offset.Instance.Cam3_OffsetX1 = (double)num_Cam3_OffsetX1.Value;
                Offset.Instance.Cam3_OffsetY1 = (double)num_Cam3_OffsetY1.Value;
                Offset.Instance.Cam3_OffsetR1 = (double)num_Cam3_OffsetR1.Value;
                Offset.Instance.Cam3_OffsetX2 = (double)num_Cam3_OffsetX2.Value;
                Offset.Instance.Cam3_OffsetY2 = (double)num_Cam3_OffsetY2.Value;
                Offset.Instance.Cam3_OffsetR2 = (double)num_Cam3_OffsetR2.Value;

                Serialization.Save(Offset.Instance, "Offset");
                ShowNormal("保存成功");

            }
            else
            {
                ShowWarn("权限不足无法修改，请登陆管理员模式");
                Form_Offset_Load(sender, e);
            }


        }

        public void ControlEnabled(bool flag)
        {

            tableLayoutPanel1.Enabled = flag;
        }
        public void Form_Offset_Load(object sender, EventArgs e)
        {
            


            num_Cam1_OffsetX1.Value = (decimal)Offset.Instance.Cam1_OffsetX1;
            num_Cam1_OffsetY1.Value = (decimal)Offset.Instance.Cam1_OffsetY1;
            num_Cam1_OffsetR1.Value = (decimal)Offset.Instance.Cam1_OffsetR1;
            num_Cam1_OffsetX2.Value = (decimal)Offset.Instance.Cam1_OffsetX2;
            num_Cam1_OffsetY2.Value = (decimal)Offset.Instance.Cam1_OffsetY2;
            num_Cam1_OffsetR2.Value = (decimal)Offset.Instance.Cam1_OffsetR2;

            num_Cam2_OffsetX1.Value = (decimal)Offset.Instance.Cam2_OffsetX1;
            num_Cam2_OffsetY1.Value = (decimal)Offset.Instance.Cam2_OffsetY1;
            num_Cam2_OffsetR1.Value = (decimal)Offset.Instance.Cam2_OffsetR1;
            num_Cam2_OffsetX2.Value = (decimal)Offset.Instance.Cam2_OffsetX2;
            num_Cam2_OffsetY2.Value = (decimal)Offset.Instance.Cam2_OffsetY2;
            num_Cam2_OffsetR2.Value = (decimal)Offset.Instance.Cam2_OffsetR2;

            num_Cam3_OffsetX1.Value = (decimal)Offset.Instance.Cam3_OffsetX1;
            num_Cam3_OffsetY1.Value = (decimal)Offset.Instance.Cam3_OffsetY1;
            num_Cam3_OffsetR1.Value = (decimal)Offset.Instance.Cam3_OffsetR1;
            num_Cam3_OffsetX2.Value = (decimal)Offset.Instance.Cam3_OffsetX2;
            num_Cam3_OffsetY2.Value = (decimal)Offset.Instance.Cam3_OffsetY2;
            num_Cam3_OffsetR2.Value = (decimal)Offset.Instance.Cam3_OffsetR2;


            
        }

        private void 刷新数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Offset_Load(sender, e);
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5_Click(sender, e);
        }


    }
}
