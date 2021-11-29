using HalconDotNet;
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
using ToolKit.DisplayWindow;
using ToolKit.HalconTool;
using ToolKit.HYControls.HYForm;

namespace HYProject.ToolForm
{
    public partial class Form_Product_Set2 : HYBaseForm
    {


        private static Form_Product_Set2 instance;
        public static Form_Product_Set2 Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Form_Product_Set2();
                }
                return instance;
            }
        }
        private Form_Product_Set2()
        {
            InitializeComponent();
        }

        private void Form_Product_Set2_Load(object sender, EventArgs e)
        {
            AppParam.Instance.lightSource.OpenAllCH();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            //foreach (var item in Cameras.Instance.GetCameras.Keys)
            //{
            //    Cameras.Instance[item].ClearImageProcessEvents();
            //    Cameras.Instance[item].ImageProcessEvent += this.Form_Camera_ImageProcessEvent;
            //}
        }

        public void Form_Camera_ImageProcessEvent(string cameraName, HObject ho_image)
        {
            halconWindow1.Disp_Image(ho_image.Clone());
            if (ShowWarn("确认替换基准图?") == DialogResult.OK)
            {

                if (index == 11)
                {

                    HOperatorSet.CopyImage(ho_image, out AppParam.Instance.product.Cam1_Image1);
                }
                else if (index == 12 )
                {
                    HOperatorSet.CopyImage(ho_image, out AppParam.Instance.product.Cam1_Image2);
                }
                else if (index == 21  )
                {
                    HOperatorSet.CopyImage(ho_image, out AppParam.Instance.product.Cam2_Image1);

                }
                else if (index == 22 )
                {
                    HOperatorSet.CopyImage(ho_image, out AppParam.Instance.product.Cam2_Image2);
                }
                else if (index == 31 )
                {
                    HOperatorSet.CopyImage(ho_image, out AppParam.Instance.product.Cam3_Image1);
                }
                else if (index == 32)
                {
                    HOperatorSet.CopyImage(ho_image, out AppParam.Instance.product.Cam3_Image2);
                }
            }
            index = -1;
        }

        private void Form_Product_Set2_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppParam.Instance.Form_Product_Set2_State = false;
            AppParam.Instance.lightSource.CloseAllCH();

            //foreach (var item in Cameras.Instance.GetCameras.Keys)
            //{
            //    //关闭实时
            //    System.Threading.Thread.Sleep(300);
            //    //清空事件
            //    Cameras.Instance[item].ClearImageProcessEvents();
            //    //重新绑定运行事件
            //    Cameras.Instance[item].ImageProcessEvent += Cameras.Instance.Camera_ImageProcessEvent;
            //}
        }
        int index = -1;
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "相机1")
            {
                if (comboBox2.Text == "1")
                {
                    index = 11;
                }
                else if (comboBox2.Text == "2")
                {
                    index = 12;
                }
                Cameras.Instance["Cam1"].Soft_Trigger();
            }
            else if (comboBox1.Text == "相机2")
            {
                if (comboBox2.Text == "1")
                {
                    index = 21;
                }
                else if (comboBox2.Text == "2")
                {
                    index = 22;
                }
                Cameras.Instance["Cam2"].Soft_Trigger();
            }
            else if (comboBox1.Text == "相机3")
            {
                if (comboBox2.Text == "1")
                {
                    index = 31;
                }
                else if (comboBox2.Text == "2")
                {
                    index = 32;
                }
                Cameras.Instance["Cam3"].Soft_Trigger();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "相机1")
            {
                if (comboBox2.Text == "1")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam1_Image1);
                }
                else if (comboBox2.Text == "2")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam1_Image2);
                }
            }
            else if (comboBox1.Text == "相机2")
            {
                if (comboBox2.Text == "1")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam2_Image1);
                }
                else if (comboBox2.Text == "2")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam2_Image2);
                }
            }
            else if (comboBox1.Text == "相机3")
            {
                if (comboBox2.Text == "1")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam3_Image1);
                }
                else if (comboBox2.Text == "2")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam3_Image2);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "相机1")
            {
                if (comboBox2.Text == "1")
                {
                    Line line = halconWindow1.Draw_Line("blue");
                    if (AppParam.Instance.product.Cam1_Top1 == null)
                        AppParam.Instance.product.Cam1_Top1 = new ToolKit.HalconTool.Model.MeasureParam();
                    AppParam.Instance.product.Cam1_Top1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                    AppParam.Instance.product.Cam1_Top1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);

                }
                else if (comboBox2.Text == "2")
                {
                    Line line = halconWindow1.Draw_Line("blue");
                    if (AppParam.Instance.product.Cam1_Top1 == null)

                        AppParam.Instance.product.Cam1_Top2 = new ToolKit.HalconTool.Model.MeasureParam();
                    AppParam.Instance.product.Cam1_Top2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                    AppParam.Instance.product.Cam1_Top2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
            }
            else if (comboBox1.Text == "相机2")
            {
                if (comboBox2.Text == "1")
                {
                    Line line = halconWindow1.Draw_Line("blue");
                    if (AppParam.Instance.product.Cam2_Top1 == null)
                        AppParam.Instance.product.Cam2_Top1 = new ToolKit.HalconTool.Model.MeasureParam();
                    AppParam.Instance.product.Cam2_Top1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                    AppParam.Instance.product.Cam2_Top1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
                else if (comboBox2.Text == "2")
                {
                    Line line = halconWindow1.Draw_Line("blue");
                    if (AppParam.Instance.product.Cam2_Top2 == null)
                        AppParam.Instance.product.Cam2_Top2 = new ToolKit.HalconTool.Model.MeasureParam();
                    AppParam.Instance.product.Cam2_Top2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                    AppParam.Instance.product.Cam2_Top2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
            }
            else if (comboBox1.Text == "相机3")
            {
                if (comboBox2.Text == "1")
                {
                    Line line = halconWindow1.Draw_Line("blue");
                    if (AppParam.Instance.product.Cam3_Top1 == null)
                        AppParam.Instance.product.Cam3_Top1 = new ToolKit.HalconTool.Model.MeasureParam();
                    AppParam.Instance.product.Cam3_Top1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                    AppParam.Instance.product.Cam3_Top1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
                else if (comboBox2.Text == "2")
                {
                    Line line = halconWindow1.Draw_Line("blue");
                    if (AppParam.Instance.product.Cam3_Top2 == null)
                        AppParam.Instance.product.Cam3_Top2 = new ToolKit.HalconTool.Model.MeasureParam();
                    AppParam.Instance.product.Cam3_Top2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                    AppParam.Instance.product.Cam3_Top2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "相机1")
            {
                if (comboBox2.Text == "1")
                {
                    Line line = halconWindow1.Draw_Line("blue");
                    if (AppParam.Instance.product.Cam1_Left1 == null)
                        AppParam.Instance.product.Cam1_Left1 = new ToolKit.HalconTool.Model.MeasureParam();
                    AppParam.Instance.product.Cam1_Left1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                    AppParam.Instance.product.Cam1_Left1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);

                }
                else if (comboBox2.Text == "2")
                {
                    Line line = halconWindow1.Draw_Line("blue");
                    if (AppParam.Instance.product.Cam1_Left2 == null)
                        AppParam.Instance.product.Cam1_Left2 = new ToolKit.HalconTool.Model.MeasureParam();
                    AppParam.Instance.product.Cam1_Left2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                    AppParam.Instance.product.Cam1_Left2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
            }
            else if (comboBox1.Text == "相机2")
            {
                if (comboBox2.Text == "1")
                {
                    Line line = halconWindow1.Draw_Line("blue");
                    if (AppParam.Instance.product.Cam2_Left1 == null)
                        AppParam.Instance.product.Cam2_Left1 = new ToolKit.HalconTool.Model.MeasureParam();
                    AppParam.Instance.product.Cam2_Left1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                    AppParam.Instance.product.Cam2_Left1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
                else if (comboBox2.Text == "2")
                {
                    Line line = halconWindow1.Draw_Line("blue");
                    if (AppParam.Instance.product.Cam2_Left2 == null)
                        AppParam.Instance.product.Cam2_Left2 = new ToolKit.HalconTool.Model.MeasureParam();
                    AppParam.Instance.product.Cam2_Left2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                    AppParam.Instance.product.Cam2_Left2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
            }
            else if (comboBox1.Text == "相机3")
            {
                if (comboBox2.Text == "1")
                {
                    Line line = halconWindow1.Draw_Line("blue");
                    if (AppParam.Instance.product.Cam3_Left1 == null)
                        AppParam.Instance.product.Cam3_Left1 = new ToolKit.HalconTool.Model.MeasureParam();
                    AppParam.Instance.product.Cam3_Left1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                    AppParam.Instance.product.Cam3_Left1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
                else if (comboBox2.Text == "2")
                {
                    Line line = halconWindow1.Draw_Line("blue");
                    if (AppParam.Instance.product.Cam3_Left2 == null)
                        AppParam.Instance.product.Cam3_Left2 = new ToolKit.HalconTool.Model.MeasureParam();
                    AppParam.Instance.product.Cam3_Left2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                    AppParam.Instance.product.Cam3_Left2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "相机1")
            {
                if (comboBox2.Text == "1")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam1_Image1);
                    HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Top1, AppParam.Instance.product.Cam1_Image1, out _, out _);
                    propertyGrid1.SelectedObject = AppParam.Instance.product.Cam1_Top1;

                }
                else if (comboBox2.Text == "2")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam1_Image2);
                    HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Top2, AppParam.Instance.product.Cam1_Image2, out _, out _);
                    propertyGrid1.SelectedObject = AppParam.Instance.product.Cam1_Top2;
                }
            }
            else if (comboBox1.Text == "相机2")
            {
                if (comboBox2.Text == "1")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam2_Image1);
                    HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Top1, AppParam.Instance.product.Cam2_Image1, out _, out _);
                    propertyGrid1.SelectedObject = AppParam.Instance.product.Cam2_Top1;
                }
                else if (comboBox2.Text == "2")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam2_Image2);
                    HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Top2, AppParam.Instance.product.Cam2_Image2, out _, out _);
                    propertyGrid1.SelectedObject = AppParam.Instance.product.Cam2_Top2;
                }
            }
            else if (comboBox1.Text == "相机3")
            {
                if (comboBox2.Text == "1")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam3_Image1);
                    HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Top1, AppParam.Instance.product.Cam3_Image1, out _, out _);
                    propertyGrid1.SelectedObject = AppParam.Instance.product.Cam3_Top1;
                }
                else if (comboBox2.Text == "2")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam3_Image2);
                    HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Top2, AppParam.Instance.product.Cam3_Image2, out _, out _);
                    propertyGrid1.SelectedObject = AppParam.Instance.product.Cam3_Top2;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "相机1")
            {
                if (comboBox2.Text == "1")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam1_Image1);
                    HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Left1, AppParam.Instance.product.Cam1_Image1, out _, out _);
                    propertyGrid1.SelectedObject = AppParam.Instance.product.Cam1_Left1;
                }
                else if (comboBox2.Text == "2")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam1_Image2);
                    HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Left2, AppParam.Instance.product.Cam1_Image2, out _, out _);
                    propertyGrid1.SelectedObject = AppParam.Instance.product.Cam1_Left2;
                }
            }
            else if (comboBox1.Text == "相机2")
            {
                if (comboBox2.Text == "1")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam2_Image1);
                    HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Left1, AppParam.Instance.product.Cam2_Image1, out _, out _);
                    propertyGrid1.SelectedObject = AppParam.Instance.product.Cam2_Left1;
                }
                else if (comboBox2.Text == "2")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam2_Image2);
                    HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Left2, AppParam.Instance.product.Cam2_Image2, out _, out _);
                    propertyGrid1.SelectedObject = AppParam.Instance.product.Cam2_Left2;
                }
            }
            else if (comboBox1.Text == "相机3")
            {
                if (comboBox2.Text == "1")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam3_Image1);
                    HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Left1, AppParam.Instance.product.Cam3_Image1, out _, out _);
                    propertyGrid1.SelectedObject = AppParam.Instance.product.Cam3_Left1;
                }
                else if (comboBox2.Text == "2")
                {
                    halconWindow1.Disp_Image(AppParam.Instance.product.Cam3_Image2);
                    HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Left2, AppParam.Instance.product.Cam3_Image2, out _, out _);
                    propertyGrid1.SelectedObject = AppParam.Instance.product.Cam3_Left2;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {


                HTuple Top = new HTuple(0.0, 0.0, 0.0, 0.0);
                HTuple Left = new HTuple(0.0, 0.0, 0.0, 0.0);
                if (comboBox1.Text == "相机1")
                {
                    if (comboBox2.Text == "1")
                    {


                        halconWindow1.Disp_Image(AppParam.Instance.product.Cam1_Image1);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Top1, AppParam.Instance.product.Cam1_Image1, out _, out Top);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Left1, AppParam.Instance.product.Cam1_Image1, out _, out Left);
                    }
                    else if (comboBox2.Text == "2")
                    {

                        halconWindow1.Disp_Image(AppParam.Instance.product.Cam1_Image2);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Left2, AppParam.Instance.product.Cam1_Image2, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Top2, AppParam.Instance.product.Cam1_Image2, out _, out Top);
                    }
                }
                else if (comboBox1.Text == "相机2")
                {
                    if (comboBox2.Text == "1")
                    {
                        halconWindow1.Disp_Image(AppParam.Instance.product.Cam2_Image1);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Left1, AppParam.Instance.product.Cam2_Image1, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Top1, AppParam.Instance.product.Cam2_Image1, out _, out Top);
                    }
                    else if (comboBox2.Text == "2")
                    {
                        halconWindow1.Disp_Image(AppParam.Instance.product.Cam2_Image2);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Left2, AppParam.Instance.product.Cam2_Image2, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Top2, AppParam.Instance.product.Cam2_Image2, out _, out Top);
                    }
                }
                else if (comboBox1.Text == "相机3")
                {
                    if (comboBox2.Text == "1")
                    {
                        halconWindow1.Disp_Image(AppParam.Instance.product.Cam3_Image1);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Left1, AppParam.Instance.product.Cam3_Image1, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Top1, AppParam.Instance.product.Cam3_Image1, out _, out Top);
                    }
                    else if (comboBox2.Text == "2")
                    {
                        halconWindow1.Disp_Image(AppParam.Instance.product.Cam3_Image2);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Left2, AppParam.Instance.product.Cam3_Image2, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Top2, AppParam.Instance.product.Cam3_Image2, out _, out Top);
                    }
                }
                HTuple row = new HTuple(0.0);
                HTuple col = new HTuple(0.0);
                HTuple Phi = new HTuple(0.0);
                HOperatorSet.IntersectionLines(Left[0], Left[1], Left[2], Left[3], Top[2], Top[3], Top[0], Top[1], out row, out col, out _);

                HOperatorSet.LineOrientation(Top[2], Top[3], Top[0], Top[1], out Phi);
                halconWindow1.Disp_Cross(row, col, 100, 0, "green");
                halconWindow1.Disp_Message("Row:" + row + "\nCol:" + col + "\nAngle:" + Phi.TupleDeg(), 16, 20, 20, "blue");


            }
            catch (Exception)
            {
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            AppParam.Instance.Save_To_File();
            ShowNormal("保存成功");
        }

        private void button38_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "相机1")
            {
                if (comboBox2.Text == "1")
                {
                    HTuple Center_Row = new HTuple(0.0), Center_Column = new HTuple(0.0), Angle = new HTuple(0.0);
                    Work.Find_Point(AppParam.Instance.product.Cam1_Image1, halconWindow1, "相机1", "1", out Center_Row, out Center_Column, out Angle);
                    HTuple Robot_x = new HTuple(0.0);
                    HTuple Robot_y = new HTuple(0.0);
                    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam1_HomMat2d1, Center_Row, Center_Column, out Robot_y, out Robot_x);

                    StandardPar.Instance.Cam1_Standar_Point1.X = Robot_x.D;
                    StandardPar.Instance.Cam1_Standar_Point1.Y = Robot_y.D;
                    StandardPar.Instance.Cam1_Standar_Point1.U = Angle.D;

                    Serialization.Save(StandardPar.Instance, "StandardPar");
                    ShowNormal("设置成功");

                }
                else if (comboBox2.Text == "2")
                {
                    HTuple Center_Row = new HTuple(0.0), Center_Column = new HTuple(0.0), Angle = new HTuple(0.0);
                    Work.Find_Point(AppParam.Instance.product.Cam1_Image2, halconWindow1, "相机1", "2", out Center_Row, out Center_Column, out Angle);
                    HTuple Robot_x = new HTuple(0.0);
                    HTuple Robot_y = new HTuple(0.0);
                    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam1_HomMat2d2, Center_Row, Center_Column,  out Robot_y,out Robot_x);

                    StandardPar.Instance.Cam1_Standar_Point2.X = Robot_x.D;
                    StandardPar.Instance.Cam1_Standar_Point2.Y = Robot_y.D;
                    StandardPar.Instance.Cam1_Standar_Point2.U = Angle.D;

                    Serialization.Save(StandardPar.Instance, "StandardPar");
                    ShowNormal("设置成功");
                }
            }
            else if (comboBox1.Text == "相机2")
            {
                if (comboBox2.Text == "1")
                {
                    HTuple Center_Row = new HTuple(0.0), Center_Column = new HTuple(0.0), Angle = new HTuple(0.0);
                    Work.Find_Point(AppParam.Instance.product.Cam2_Image1, halconWindow1, "相机2", "1", out Center_Row, out Center_Column, out Angle);
                    HTuple Robot_x = new HTuple(0.0);
                    HTuple Robot_y = new HTuple(0.0);
                    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d1, Center_Row, Center_Column, out Robot_y, out Robot_x);

                    StandardPar.Instance.Cam2_Standar_Point1.X = Robot_x.D;
                    StandardPar.Instance.Cam2_Standar_Point1.Y = Robot_y.D;
                    StandardPar.Instance.Cam2_Standar_Point1.U = Angle.D;

                    Serialization.Save(StandardPar.Instance, "StandardPar");
                    ShowNormal("设置成功");
                }
                else if (comboBox2.Text == "2")
                {
                    HTuple Center_Row = new HTuple(0.0), Center_Column = new HTuple(0.0), Angle = new HTuple(0.0);
                    Work.Find_Point(AppParam.Instance.product.Cam2_Image2, halconWindow1, "相机2", "2", out Center_Row, out Center_Column, out Angle);
                    HTuple Robot_x = new HTuple(0.0);
                    HTuple Robot_y = new HTuple(0.0);
                    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d2, Center_Row, Center_Column, out Robot_y, out Robot_x);

                    StandardPar.Instance.Cam2_Standar_Point2.X = Robot_x.D;
                    StandardPar.Instance.Cam2_Standar_Point2.Y = Robot_y.D;
                    StandardPar.Instance.Cam2_Standar_Point2.U = Angle.D;

                    Serialization.Save(StandardPar.Instance, "StandardPar");
                    ShowNormal("设置成功");
                }
            }
            else if (comboBox1.Text == "相机3")
            {
                if (comboBox2.Text == "1")
                {
                    HTuple Center_Row = new HTuple(0.0), Center_Column = new HTuple(0.0), Angle = new HTuple(0.0);
                    Work.Find_Point(AppParam.Instance.product.Cam3_Image1, halconWindow1, "相机3", "1", out Center_Row, out Center_Column, out Angle);
                    HTuple Robot_x = new HTuple(0.0);
                    HTuple Robot_y = new HTuple(0.0);
                    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam3_HomMat2d1, Center_Row, Center_Column, out Robot_y, out Robot_x);

                    StandardPar.Instance.Cam3_Standar_Point1.X = Robot_x.D;
                    StandardPar.Instance.Cam3_Standar_Point1.Y = Robot_y.D;
                    StandardPar.Instance.Cam3_Standar_Point1.U = Angle.D;

                    Serialization.Save(StandardPar.Instance, "StandardPar");
                    ShowNormal("设置成功");
                }
                else if (comboBox2.Text == "2")
                {
                    HTuple Center_Row = new HTuple(0.0), Center_Column = new HTuple(0.0), Angle = new HTuple(0.0);
                    Work.Find_Point(AppParam.Instance.product.Cam3_Image2, halconWindow1, "相机3", "2", out Center_Row, out Center_Column, out Angle);
                    HTuple Robot_x = new HTuple(0.0);
                    HTuple Robot_y = new HTuple(0.0);
                    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam3_HomMat2d2, Center_Row, Center_Column, out Robot_y, out Robot_x);

                    StandardPar.Instance.Cam3_Standar_Point2.X = Robot_x.D;
                    StandardPar.Instance.Cam3_Standar_Point2.Y = Robot_y.D;
                    StandardPar.Instance.Cam3_Standar_Point2.U = Angle.D;

                    Serialization.Save(StandardPar.Instance, "StandardPar");
                    ShowNormal("设置成功");
                }
            }
        }

        private void Form_Product_Set2_Activated(object sender, EventArgs e)
        {
            AppParam.Instance.Form_Product_Set2_State = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                HObject image;
                HOperatorSet.ReadImage(out image,openFileDialog.FileName);
                if (comboBox1.Text == "相机1")
                {
                    if (comboBox2.Text == "1")
                    {
                        index = 11;
                    }
                    else if (comboBox2.Text == "2")
                    {
                        index = 12;
                    }
                    Form_Camera_ImageProcessEvent("Cam1",image);
                }
                else if (comboBox1.Text == "相机2")
                {
                    if (comboBox2.Text == "1")
                    {
                        index = 21;
                    }
                    else if (comboBox2.Text == "2")
                    {
                        index = 22;
                    }
                    Form_Camera_ImageProcessEvent("Cam2", image);
                }
                else if (comboBox1.Text == "相机3")
                {
                    if (comboBox2.Text == "1")
                    {
                        index = 31;
                    }
                    else if (comboBox2.Text == "2")
                    {
                        index = 32;
                    }
                    Form_Camera_ImageProcessEvent("Cam3", image);
                }
               
            }
        }
    }
}
