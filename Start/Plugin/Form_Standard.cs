using HalconDotNet;
using HYProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using HYProject.Model;
using ToolKit.DisplayWindow;
using ToolKit.HalconTool.Model;
using ToolKit.HalconTool;
using HYProject.Helper;

namespace HYProject.Plugin
{
    public partial class Form_Standard : ToolKit.HYControls.HYForm.HYBaseForm
    {
        public Form_Standard()
        {
            InitializeComponent();
        }
        int index = -1;
        private void button9_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "1")
            {
                index = 31;

            }
            else
            {
                index = 32;
            }
            Cameras.Instance["Cam3"].Soft_Trigger();

        }

        private void Form_Standard_Load(object sender, EventArgs e)
        {
            AppParam.Instance.lightSource.OpenAllCH();

            foreach (var item in Cameras.Instance.GetCameras.Keys)
            {
                Cameras.Instance[item].ClearImageProcessEvents();
                Cameras.Instance[item].ImageProcessEvent += this.Form_Camera_ImageProcessEvent;
            }
        }

        private void Form_Camera_ImageProcessEvent(string cameraName, HObject ho_image)
        {
            halconWindow1.Disp_Image(ho_image);
            switch (index)
            {
                case 11:
                    if (ShowWarn("是否替换基准图片") == DialogResult.OK)
                        HOperatorSet.CopyImage(ho_image, out StandardPar.Instance.Cam1_Image1);
                    break;
                case 12:
                    if (ShowWarn("是否替换基准图片") == DialogResult.OK)
                        HOperatorSet.CopyImage(ho_image, out StandardPar.Instance.Cam1_Image2);
                    break;
                case 21:
                    if (ShowWarn("是否替换基准图片") == DialogResult.OK)
                        HOperatorSet.CopyImage(ho_image, out StandardPar.Instance.Cam2_Image1);

                    break;
                case 22:
                    if (ShowWarn("是否替换基准图片") == DialogResult.OK)
                        HOperatorSet.CopyImage(ho_image, out StandardPar.Instance.Cam2_Image2);

                    break;
                case 31:
                    if (ShowWarn("是否替换基准图片") == DialogResult.OK)
                        HOperatorSet.CopyImage(ho_image, out StandardPar.Instance.Cam3_Image1);

                    break;
                case 32:
                    if (ShowWarn("是否替换基准图片") == DialogResult.OK)
                        HOperatorSet.CopyImage(ho_image, out StandardPar.Instance.Cam3_Image2);
                    break;
            }
            index = -1;
        }

        private void Form_Standard_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppParam.Instance.lightSource.CloseAllCH();

            foreach (var item in Cameras.Instance.GetCameras.Keys)
            {
                //关闭实时
                System.Threading.Thread.Sleep(300);
                //清空事件
                Cameras.Instance[item].ClearImageProcessEvents();
                //重新绑定运行事件
                Cameras.Instance[item].ImageProcessEvent += Cameras.Instance.Camera_ImageProcessEvent;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "1")
            {
                halconWindow1.Disp_Image(StandardPar.Instance.Cam3_Image1);
            }
            else
            {
                halconWindow1.Disp_Image(StandardPar.Instance.Cam3_Image2);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //            Top
            //   Left
            //Button
            //Right
            Line line = halconWindow1.Draw_Line("blue");

            if (comboBox1.Text == "1")
            {
                if (comboBox2.Text == "Top")
                {
                    if (StandardPar.Instance.Cam3_Top1 == null)
                    {
                        StandardPar.Instance.Cam3_Top1 = new MeasureParam();
                    }
                    StandardPar.Instance.Cam3_Top1.Shape = MeasureShapes.line;
                    StandardPar.Instance.Cam3_Top1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
                else if (comboBox2.Text == "Left")
                {
                    if (StandardPar.Instance.Cam3_Left1 == null)
                    {
                        StandardPar.Instance.Cam3_Left1 = new MeasureParam();
                    }
                    StandardPar.Instance.Cam3_Left1.Shape = MeasureShapes.line;
                    StandardPar.Instance.Cam3_Left1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
                else if (comboBox2.Text == "Button")
                {
                    if (StandardPar.Instance.Cam3_Button1 == null)
                    {
                        StandardPar.Instance.Cam3_Button1 = new MeasureParam();
                    }
                    StandardPar.Instance.Cam3_Button1.Shape = MeasureShapes.line;
                    StandardPar.Instance.Cam3_Button1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
                else if (comboBox2.Text == "Right")
                {
                    if (StandardPar.Instance.Cam3_Right1 == null)
                    {
                        StandardPar.Instance.Cam3_Right1 = new MeasureParam();
                    }
                    StandardPar.Instance.Cam3_Right1.Shape = MeasureShapes.line;
                    StandardPar.Instance.Cam3_Right1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
            }
            else
            {
                if (comboBox2.Text == "Top")
                {
                    if (StandardPar.Instance.Cam3_Top2 == null)
                    {
                        StandardPar.Instance.Cam3_Top2 = new MeasureParam();
                    }
                    StandardPar.Instance.Cam3_Top2.Shape = MeasureShapes.line;
                    StandardPar.Instance.Cam3_Top2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
                else if (comboBox2.Text == "Left")
                {
                    if (StandardPar.Instance.Cam3_Left2 == null)
                    {
                        StandardPar.Instance.Cam3_Left2 = new MeasureParam();
                    }
                    StandardPar.Instance.Cam3_Left2.Shape = MeasureShapes.line;
                    StandardPar.Instance.Cam3_Left2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
                else if (comboBox2.Text == "Button")
                {
                    if (StandardPar.Instance.Cam3_Button2 == null)
                    {
                        StandardPar.Instance.Cam3_Button2 = new MeasureParam();
                    }
                    StandardPar.Instance.Cam3_Button2.Shape = MeasureShapes.line;
                    StandardPar.Instance.Cam3_Button2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
                else if (comboBox2.Text == "Right")
                {
                    if (StandardPar.Instance.Cam3_Right2 == null)
                    {
                        StandardPar.Instance.Cam3_Right2 = new MeasureParam();
                    }
                    StandardPar.Instance.Cam3_Right2.Shape = MeasureShapes.line;
                    StandardPar.Instance.Cam3_Right2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "1")
            {
                if (comboBox2.Text == "Top")
                {
                    HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Top1, StandardPar.Instance.Cam3_Image1, out _, out _);
                }
                else if (comboBox2.Text == "Left")
                {
                    HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Left1, StandardPar.Instance.Cam3_Image1, out _, out _);
                }
                else if (comboBox2.Text == "Button")
                {
                    HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Button1, StandardPar.Instance.Cam3_Image1, out _, out _);
                }
                else if (comboBox2.Text == "Right")
                {
                    HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Right1, StandardPar.Instance.Cam3_Image1, out _, out _);
                }
            }
            else
            {
                if (comboBox2.Text == "Top")
                {
                    HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Top2, StandardPar.Instance.Cam3_Image2, out _, out _);
                }
                else if (comboBox2.Text == "Left")
                {
                    HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Left2, StandardPar.Instance.Cam3_Image2, out _, out _);
                }
                else if (comboBox2.Text == "Button")
                {
                    HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Button2, StandardPar.Instance.Cam3_Image2, out _, out _);
                }
                else if (comboBox2.Text == "Right")
                {
                    HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Right2, StandardPar.Instance.Cam3_Image2, out _, out _);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "1")
            {
                if (comboBox2.Text == "Top")
                {
                    propertyGrid1.SelectedObject = StandardPar.Instance.Cam3_Top1;
                }
                else if (comboBox2.Text == "Left")
                {
                    propertyGrid1.SelectedObject = StandardPar.Instance.Cam3_Left1;
                }
                else if (comboBox2.Text == "Button")
                {
                    propertyGrid1.SelectedObject = StandardPar.Instance.Cam3_Button1;
                }
                else if (comboBox2.Text == "Right")
                {
                    propertyGrid1.SelectedObject = StandardPar.Instance.Cam3_Right1;
                }
            }
            else
            {
                if (comboBox2.Text == "Top")
                {
                    propertyGrid1.SelectedObject = StandardPar.Instance.Cam3_Top2;
                }
                else if (comboBox2.Text == "Left")
                {
                    propertyGrid1.SelectedObject = StandardPar.Instance.Cam3_Left2;
                }
                else if (comboBox2.Text == "Button")
                {
                    propertyGrid1.SelectedObject = StandardPar.Instance.Cam3_Button2;
                }
                else if (comboBox2.Text == "Right")
                {
                    propertyGrid1.SelectedObject = StandardPar.Instance.Cam3_Right2;
                }

            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            Serialization.Save(StandardPar.Instance, "StandardPar");
            ShowNormal("保存成功");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "1")
            {
                halconWindow1.Disp_Image(StandardPar.Instance.Cam3_Image1);
                HTuple Top = new HTuple(0.0, 0.0, 0.0, 0.0);
                HTuple Left = new HTuple(0.0, 0.0, 0.0, 0.0);
                HTuple Button = new HTuple(0.0, 0.0, 0.0, 0.0);
                HTuple Right = new HTuple(0.0, 0.0, 0.0, 0.0);
                HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Top1, StandardPar.Instance.Cam3_Image1, out _, out Top);
                HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Button1, StandardPar.Instance.Cam3_Image1, out _, out Button);
                HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Left1, StandardPar.Instance.Cam3_Image1, out _, out Left);
                HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Right1, StandardPar.Instance.Cam3_Image1, out _, out Right);
                HTuple CenterRow, CenterColumn, Phi;
                NewMethod(Top, Left, Button, Right, out CenterRow, out CenterColumn, out Phi);

                textBox1.Text = CenterRow.D.ToString("0.00000");
                textBox2.Text = CenterColumn.D.ToString("0.00000");
                textBox3.Text = Phi.TupleDeg().D.ToString("0.00000");

            }
            else
            {
                halconWindow1.Disp_Image(StandardPar.Instance.Cam3_Image2);
                HTuple Top = new HTuple(0.0, 0.0, 0.0, 0.0);
                HTuple Left = new HTuple(0.0, 0.0, 0.0, 0.0);
                HTuple Button = new HTuple(0.0, 0.0, 0.0, 0.0);
                HTuple Right = new HTuple(0.0, 0.0, 0.0, 0.0);
                HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Top2, StandardPar.Instance.Cam3_Image2, out _, out Top);
                HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Button2, StandardPar.Instance.Cam3_Image2, out _, out Button);
                HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Left2, StandardPar.Instance.Cam3_Image2, out _, out Left);
                HalconUtils.CaliperMeasure(halconWindow1, StandardPar.Instance.Cam3_Right2, StandardPar.Instance.Cam3_Image2, out _, out Right);
                HTuple CenterRow, CenterColumn, Phi;
                NewMethod(Top, Left, Button, Right, out CenterRow, out CenterColumn, out Phi);

                textBox1.Text = CenterRow.D.ToString("0.00000");
                textBox2.Text = CenterColumn.D.ToString("0.00000");
                textBox3.Text = Phi.TupleDeg().D.ToString("0.00000");
            }
        }

        private void NewMethod(HTuple Top, HTuple Left, HTuple Button, HTuple Right, out HTuple CenterRow, out HTuple CenterColumn, out HTuple Phi)
        {
            HTuple LeftUpRow;
            HTuple LeftUpColumn;
            HTuple LeftDownRow;
            HTuple LeftDownColumn;
            HTuple RightUpRow;
            HTuple RightUpColumn;
            HTuple RightDownRow;
            HTuple RightDownColumn;

            HOperatorSet.IntersectionLines(Left[0], Left[1], Left[2], Left[3], Top[2], Top[3], Top[0], Top[1], out LeftUpRow, out LeftUpColumn, out _);
            HOperatorSet.IntersectionLines(Left[0], Left[1], Left[2], Left[3], Button[0], Button[1], Button[2], Button[3], out LeftDownRow, out LeftDownColumn, out _);
            HOperatorSet.IntersectionLines(Right[0], Right[1], Right[2], Right[3], Top[0], Top[1], Top[2], Top[3], out RightUpRow, out RightUpColumn, out _);
            HOperatorSet.IntersectionLines(Button[0], Button[1], Button[2], Button[3], Right[0], Right[1], Right[2], Right[3], out RightDownRow, out RightDownColumn, out _);
            HOperatorSet.IntersectionLines(LeftUpRow, LeftUpColumn, RightDownRow, RightDownColumn, RightUpRow, RightUpColumn, LeftDownRow, LeftDownColumn, out CenterRow, out CenterColumn, out _);

            HObject Line1;
            HOperatorSet.GenEmptyObj(out Line1);
            HObject Line2;
            HOperatorSet.GenEmptyObj(out Line2);

            HOperatorSet.GenRegionLine(out Line1, LeftUpRow, LeftUpColumn, RightDownRow, RightDownColumn);
            HOperatorSet.GenRegionLine(out Line2, RightUpRow, RightUpColumn, LeftDownRow, LeftDownColumn);

            HObject LeftLine;
            HOperatorSet.GenEmptyObj(out LeftLine);
            HOperatorSet.GenRegionLine(out LeftLine, LeftUpRow, LeftUpColumn, LeftDownRow, LeftDownColumn);
            HOperatorSet.LineOrientation(RightUpRow, RightUpColumn, LeftUpRow, LeftUpColumn, out Phi);


            halconWindow1.Disp_Region(Line1, "green", "margin");
            halconWindow1.Disp_Region(Line2, "green", "margin");
            halconWindow1.Disp_Cross(LeftUpRow, LeftUpColumn, 200, Phi, "green");
            halconWindow1.Disp_Cross(LeftDownRow, LeftDownColumn, 200, Phi, "green");
            halconWindow1.Disp_Cross(RightUpRow, RightUpColumn, 200, Phi, "green");
            halconWindow1.Disp_Cross(RightDownRow, RightDownColumn, 200, Phi, "green");
            halconWindow1.Disp_Cross(CenterRow, CenterColumn, 200, Phi, "green");
            halconWindow1.Disp_Message("Row:" + CenterRow.D + "\nColumn:" + CenterColumn + "\nAngle:" + Phi.TupleDeg().D, 16, 300, 10, "green");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ShowWarn("确认设为基准？") == DialogResult.OK)
            {
                if (comboBox1.Text == "1")
                {
                    StandardPar.Instance.Cam3_Standar_Point1.U = double.Parse(textBox3.Text);
                    StandardPar.Instance.Cam3_Standar_Point1.Y = double.Parse(textBox2.Text);
                    StandardPar.Instance.Cam3_Standar_Point1.X = double.Parse(textBox1.Text);
                }
                else
                {
                    StandardPar.Instance.Cam3_Standar_Point2.U = double.Parse(textBox3.Text);
                    StandardPar.Instance.Cam3_Standar_Point2.Y = double.Parse(textBox2.Text);
                    StandardPar.Instance.Cam3_Standar_Point2.X = double.Parse(textBox1.Text);
                }


            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "1")
            {
                textBox1.Text = StandardPar.Instance.Cam3_Standar_Point1.X.ToString("0.00000");
                textBox2.Text = StandardPar.Instance.Cam3_Standar_Point1.Y.ToString("0.00000");
                textBox3.Text = StandardPar.Instance.Cam3_Standar_Point1.U.ToString("0.00000");
            }
            else
            {
                textBox1.Text = StandardPar.Instance.Cam3_Standar_Point2.X.ToString("0.00000");
                textBox2.Text = StandardPar.Instance.Cam3_Standar_Point2.Y.ToString("0.00000");
                textBox3.Text = StandardPar.Instance.Cam3_Standar_Point2.U.ToString("0.00000");
            }
            comboBox2_SelectedIndexChanged(sender, e);
        }
    }
}
