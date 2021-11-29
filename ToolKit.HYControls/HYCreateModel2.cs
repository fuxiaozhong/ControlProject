using System;
using System.Windows.Forms;

using HalconDotNet;

using ToolKit.HalconTool;
using ToolKit.HalconTool.Model;

using ToolKit.DisplayWindow;

namespace ToolKit.HYControls
{
    public partial class HYCreateModel2 : UserControl
    {

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private ModelParameter model;

        public HYCreateModel2()
        {
            InitializeComponent();
        }
        private HalconWindow halconWindow;

        private int index;

        public HalconWindow HalconWindow
        {
            get
            {
                return halconWindow;
            }

            set
            {
                halconWindow = value;
            }
        }

        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
                if (index == 0)
                {
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    tabControl1.SelectedIndex = 1;
                }
            }
        }

        public bool Draw
        {
            get
            {
                return draw;
            }

            set
            {
                draw = value;
            }
        }

        public void SetModel(ref ModelParameter modelpar)
        {
            this.model = modelpar;
            if (model.ModelType == MatchMode.ShapeModel)
                model_Shple.Checked = true;
            else
                radioButton2.Checked = true;


            model_minScore.Value = (decimal)model.minScore;
            model_matchNum.Value = model.matchNum;
            model_angleStep.Value = model.AngleStep;

            if (model.polarity == "use_polarity")
                model_polarity.Text = "使用极性";
            else
                model_polarity.Text = "忽略极性";

            model_startAngle.Value = model.AngleStart;
            model_angleRange.Value = model.AngleExtent;
            model_minScale.Value = (decimal)model.ScaleMin;
            model_maxScale.Value = (decimal)model.ScaleMax;

            if (model.Contrast == -1)
            {
                model_contrastAuto.Checked = true;
            }
            else
            {
                model_contrast.Value = model.Contrast;
            }

            model.dispFindRegion = model_DispFindRegion.Checked;
            model_DispModel.Checked = model.dispModel;
            model_findRegionEnable.Checked = model.findRegionEnable;

            displayWindow2.Disp_Image(model.ModelImage);
            HalconWindow.Disp_Image(model.ModelBaseImage);
        }

        public ModelParameter GetModel()
        {
            if (model_Shple.Checked)
                model.ModelType = MatchMode.ShapeModel;
            else
                model.ModelType = MatchMode.GrayModel;

            model.minScore = (double)model_minScore.Value;
            model.matchNum = (int)model_matchNum.Value;
            model.AngleStep = (int)model_angleStep.Value;
            model.polarity = model_polarity.Text == "使用极性" ? "use_polarity" : "ignore_global_polarity";
            model.AngleStart = (int)model_startAngle.Value;
            model.AngleExtent = (int)model_angleRange.Value;
            model.ScaleMin = (double)model_minScale.Value;
            model.ScaleMax = (double)model_maxScale.Value;
            model.Contrast = (int)(model_contrastAuto.Checked ? -1 : model_contrast.Value);
            model.dispFindRegion = model_DispFindRegion.Checked;
            model.dispModel = model_DispModel.Checked;
            model.findRegionEnable = model_findRegionEnable.Checked;

            return model;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            GetModel();

            if (model.ModelBaseImage == null)
            {
                MessageBox.Show("请先导入图像", "Tips");
                return;
            }
            if (model.ModelRegion == null)
            {
                MessageBox.Show("请先框选模板区域", "Tips");
                return;
            }
            if (HalconUtils.CreateModel(ref model))
            {
                MessageBox.Show("模板学习成功", "Tips");
                label12.Text = "模板学习成功";
                if (model.ModelType == MatchMode.GrayModel)
                {
                    HObject modelregion;
                    HOperatorSet.GetNccModelRegion(out modelregion, model.ModelID);
                    HalconWindow.Disp_Image(model.ModelBaseImage);
                    HalconWindow.Disp_Region(modelregion, "blue", "margin");
                }
                else
                {
                    HObject modelregion;
                    HOperatorSet.GetShapeModelContours(out modelregion, model.ModelID, 1);
                    HTuple HomMat2DIdentity;
                    HOperatorSet.HomMat2dIdentity(out HomMat2DIdentity);
                    HOperatorSet.HomMat2dTranslate(HomMat2DIdentity, model.modelCenterRow, model.modelCenterColumn, out HomMat2DIdentity);
                    HOperatorSet.AffineTransContourXld(modelregion, out modelregion, HomMat2DIdentity);
                    HalconWindow.Disp_Image(model.ModelBaseImage);
                    HalconWindow.Disp_Region(modelregion, "blue", "margin");
                }
            }
            else
            {
                MessageBox.Show("创建失败", "Tips");
                label12.Text = "模板学习失败";
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            HObject image = HalconWindow.Open_Image();
            if (image != null && model != null)
            {
                model.ModelBaseImage = image;
                HalconWindow.Disp_Image(model.ModelBaseImage);
                model_polarity.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
        }

        private bool draw = false;

        private void Button1_Click(object sender, EventArgs e)
        {
            if (draw)
            {
                MessageBox.Show("请先完成之前的操作后在继续操作.", "提示");
                return;
            }
            Button button = sender as Button;
            HalconWindow.Disp_Image(model.ModelBaseImage);

            HObject drawRegion = new HObject();
            HOperatorSet.GenEmptyObj(out drawRegion);
            drawRegion.Dispose();
            draw = true;
            switch (button.Text)
            {
                case "矩形":
                    drawRegion = HalconWindow.Draw_Rectangle1("blue").rectangle1;
                    break;

                case "仿矩":
                    drawRegion = HalconWindow.Draw_Rectangle2("blue").rectangle2;
                    break;

                case "圆":
                    drawRegion = HalconWindow.Draw_Circle("blue").circle;
                    break;

                case "椭圆":
                    drawRegion = HalconWindow.Draw_Ellipse("blue").ellipse;
                    break;
            }
            draw = false; ;
            if (radioButton4.Checked)
            {
                if (model.ModelRegion != null)
                {
                    HOperatorSet.Union2(drawRegion, model.ModelRegion, out model.ModelRegion);
                }
                else
                {
                    model.ModelRegion = drawRegion.Clone();
                }
            }
            else
            {
                HOperatorSet.Difference(model.ModelRegion, drawRegion, out model.ModelRegion);
            }
            HTuple area = new HTuple(0);
            HOperatorSet.AreaCenter(model.ModelRegion, out area, out model.modelCenterRow, out model.modelCenterColumn);
            if (area > 0)
            {
                HOperatorSet.OrientationRegion(model.ModelRegion, out model.modelCenterPhi);
                HObject ReduceImage;
                HOperatorSet.GenEmptyObj(out ReduceImage);
                ReduceImage.Dispose();
                HOperatorSet.ReduceDomain(model.ModelBaseImage, model.ModelRegion, out ReduceImage);
                HOperatorSet.CropDomain(ReduceImage, out ReduceImage);
                model.ModelImage = ReduceImage.Clone();
                displayWindow2.Disp_Image(ReduceImage);
                drawRegion.Dispose();
            }
            else
            {
                HalconWindow.HalconWindowHandle.ClearWindow();
            }

            HalconWindow.Disp_Image(model.ModelBaseImage);
            HalconWindow.Disp_Region(model.ModelRegion, "blue", "margin");
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            FindModel();
        }

        private void FindModel()
        {
            GetModel();
            HalconWindow.Disp_Image(model.ModelBaseImage);
            HTuple rows, cols, angles, scores;
            HalconTool.HalconUtils.FindModel(HalconWindow, model.ModelBaseImage, model, out rows, out cols, out angles, out scores);
            HalconWindow.Disp_Message("Row:" + rows.ToString() + "\nCol:" + cols.ToString() + "\nAngle:" + angles.ToString() + "\nScores:" + scores.ToString(), 16, 10, 10, "green");
            label12.Text = "找到:" + angles.Length + "个";
        }

        private void 显示模板图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HalconWindow.Disp_Image(model.ModelBaseImage);
        }

        private void 显示模板区域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HalconWindow.Disp_Region(model.ModelRegion, "green", "margin");
        }

        private void 显示搜索区域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HalconWindow.Disp_Region(model.FindModelRegion, "green", "margin");
        }

        private void 测试查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetModel();
            HTuple rows, cols, angles, scores;
            HalconTool.HalconUtils.FindModel(HalconWindow, HalconWindow.Open_Image(), model, out rows, out cols, out angles, out scores);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            HObject drawRegion = new HObject();
            HOperatorSet.GenEmptyObj(out drawRegion);
            drawRegion.Dispose();
            switch (comboBox2.Text)
            {
                case "矩形":
                    drawRegion = HalconWindow.Draw_Rectangle1("green").rectangle1;
                    break;

                case "仿矩":
                    drawRegion = HalconWindow.Draw_Rectangle2("green").rectangle2;
                    break;

                case "圆":
                    drawRegion = HalconWindow.Draw_Circle("green").circle;
                    break;

                case "椭圆":
                    drawRegion = HalconWindow.Draw_Ellipse("green").ellipse;
                    break;

                default:
                    drawRegion = HalconWindow.Draw_Rectangle1("green").rectangle1;
                    break;
            }
            if (model.FindModelRegion == null)
            {
                HOperatorSet.GenEmptyObj(out model.FindModelRegion);
            }
            model.FindModelRegion.Dispose();
            model.FindModelRegion = drawRegion.Clone();
            HalconWindow.Disp_Region(model.ModelBaseImage, "green", "margin");
            HalconWindow.Disp_Region(model.FindModelRegion, "green", "margin");
            drawRegion.Dispose();
        }

        private void Model_contrastAuto_CheckedChanged(object sender, EventArgs e)
        {
            model_contrast.Enabled = !model_contrastAuto.Checked;
        }

        private void model_minScore_ValueChanged(object sender, EventArgs e)
        {
            GetModel();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetModel();
        }

        private void model_polarity_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetModel();
        }

        private void model_findRegionEnable_CheckedChanged(object sender, EventArgs e)
        {
            GetModel();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}