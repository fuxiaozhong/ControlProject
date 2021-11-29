using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using HalconDotNet;
using HYProject.Helper;
using HYProject.Model;

using ToolKit.DisplayWindow;

namespace HYProject.Plugin
{
    public partial class Form_Robot_Calibration : ToolKit.HYControls.HYForm.HYBaseForm
    {
        private static Form_Robot_Calibration instance;

        public static Form_Robot_Calibration Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Form_Robot_Calibration();
                }
                return instance;
            }
        }

        public HalconWindow Window
        {
            get
            {
                return halconWindow1;
            }
        }

        private Form_Robot_Calibration()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            for (int i = 0; i < 48; i++)
            {
                int index = dataGridView_Cam1.Rows.Add();
                dataGridView_Cam1.Rows[index].Cells[0].Value = index + 1;
                dataGridView_Cam1.Rows[index].Cells[1].Value = 0.00000.ToString("0.00000");
                dataGridView_Cam1.Rows[index].Cells[2].Value = 0.00000.ToString("0.00000");
                dataGridView_Cam1.Rows[index].Cells[3].Value = 0.00000.ToString("0.00000");
                dataGridView_Cam1.Rows[index].Cells[4].Value = 0.00000.ToString("0.00000");
                 index = dataGridView_Cam2.Rows.Add();
                dataGridView_Cam2.Rows[index].Cells[0].Value = index + 1;
                dataGridView_Cam2.Rows[index].Cells[1].Value = 0.00000.ToString("0.00000");
                dataGridView_Cam2.Rows[index].Cells[2].Value = 0.00000.ToString("0.00000");
                dataGridView_Cam2.Rows[index].Cells[3].Value = 0.00000.ToString("0.00000");
                dataGridView_Cam2.Rows[index].Cells[4].Value = 0.00000.ToString("0.00000");
                 index = dataGridView_Cam3.Rows.Add();
                dataGridView_Cam3.Rows[index].Cells[0].Value = index + 1;
                dataGridView_Cam3.Rows[index].Cells[1].Value = 0.00000.ToString("0.00000");
                dataGridView_Cam3.Rows[index].Cells[2].Value = 0.00000.ToString("0.00000");
                dataGridView_Cam3.Rows[index].Cells[3].Value = 0.00000.ToString("0.00000");
                dataGridView_Cam3.Rows[index].Cells[4].Value = 0.00000.ToString("0.00000");
            }
        }

        public void ClearData(int CamStep)
        {
            if (CamStep == 1)
            {
                //dataGridView_Cam1.Rows.Clear();
            }
            else if (CamStep == 2)
            {
               /// dataGridView_Cam2.Rows.Clear();
            }
            else if (CamStep == 3)
            {
                //dataGridView_Cam3.Rows.Clear();
            }
        }

        public void Disp_order(string order)
        {
            this.Invoke(new Action(delegate
            {
                label2.Text = order;
            }));
        }

        /// <summary>
        /// 标定相机添加数据
        /// </summary>
        /// <param name="CamStep">工位号</param>
        /// <param name="Column">Column</param>
        /// <param name="Row">Row</param>
        /// <param name="RobotX">X</param>
        /// <param name="RobotY">Y</param>
        public void AddData(int CamStep, int Nozzle_Number, int count, double Column, double Row, double RobotX, double RobotY)
        {
            //这里采用委托的方式解决线程卡死问题；
            //在需要添加行的地方直接copy如下代码即可；
            this.Invoke(new Action(delegate
            {
                if (CamStep == 1)
                {
                    if (Nozzle_Number == 1)
                    {
                        dataGridView_Cam1.Rows[count].Cells[1].Value = Row.ToString("0.00000");
                        dataGridView_Cam1.Rows[count].Cells[2].Value = Column.ToString("0.00000");
                        dataGridView_Cam1.Rows[count].Cells[3].Value = RobotX.ToString("0.00000");
                        dataGridView_Cam1.Rows[count].Cells[4].Value = RobotY.ToString("0.00000");
                    }
                    else if (Nozzle_Number == 2)
                    {
                        dataGridView_Cam1.Rows[24 + count].Cells[1].Value = Row.ToString("0.00000");
                        dataGridView_Cam1.Rows[24 + count].Cells[2].Value = Column.ToString("0.00000");
                        dataGridView_Cam1.Rows[24 + count].Cells[3].Value = RobotX.ToString("0.00000");
                        dataGridView_Cam1.Rows[24 + count].Cells[4].Value = RobotY.ToString("0.00000");
                    }


                }
                else if (CamStep == 2)
                {


                    if (Nozzle_Number == 1)
                    {
                        dataGridView_Cam2.Rows[count].Cells[1].Value = Row.ToString("0.00000");
                        dataGridView_Cam2.Rows[count].Cells[2].Value = Column.ToString("0.00000");
                        dataGridView_Cam2.Rows[count].Cells[3].Value = RobotX.ToString("0.00000");
                        dataGridView_Cam2.Rows[count].Cells[4].Value = RobotY.ToString("0.00000");
                    }
                    else if (Nozzle_Number == 2)
                    {
                        dataGridView_Cam2.Rows[24 + count].Cells[1].Value = Row.ToString("0.00000");
                        dataGridView_Cam2.Rows[24 + count].Cells[2].Value = Column.ToString("0.00000");
                        dataGridView_Cam2.Rows[24 + count].Cells[3].Value = RobotX.ToString("0.00000");
                        dataGridView_Cam2.Rows[24 + count].Cells[4].Value = RobotY.ToString("0.00000");
                    }
                }
                else if (CamStep == 3)
                {


                    if (Nozzle_Number == 1)
                    {
                        dataGridView_Cam3.Rows[count].Cells[1].Value = Row.ToString("0.00000");
                        dataGridView_Cam3.Rows[count].Cells[2].Value = Column.ToString("0.00000");
                        dataGridView_Cam3.Rows[count].Cells[3].Value = RobotX.ToString("0.00000");
                        dataGridView_Cam3.Rows[count].Cells[4].Value = RobotY.ToString("0.00000");
                    }
                    else if (Nozzle_Number == 2)
                    {
                        dataGridView_Cam3.Rows[24 + count].Cells[1].Value = Row.ToString("0.00000");
                        dataGridView_Cam3.Rows[24 + count].Cells[2].Value = Column.ToString("0.00000");
                        dataGridView_Cam3.Rows[24 + count].Cells[3].Value = RobotX.ToString("0.00000");
                        dataGridView_Cam3.Rows[24 + count].Cells[4].Value = RobotY.ToString("0.00000");
                    }
                }
            }));
        }

        public RobotPoint CenterRotation(RobotPoint p1, RobotPoint p2, RobotPoint p3)
        {
            RobotPoint rpoint = new RobotPoint();
            double a = p1.X - p2.X;
            double b = p1.Y - p2.Y;
            double c = p1.X - p3.X;
            double d = p1.Y - p3.Y;
            double e = (Math.Pow(p1.X, 2) - Math.Pow(p2.X, 2) + Math.Pow(p1.Y, 2) - Math.Pow(p2.Y, 2)) / 2.0;
            double f = (Math.Pow(p1.X, 2) - Math.Pow(p3.X, 2) + Math.Pow(p1.Y, 2) - Math.Pow(p3.Y, 2)) / 2.0;
            double det = b * c - a * d;
            if (Math.Abs(det) > 0)
            {
                //x0,y0为计算得到的原点
                double x0 = -(d * e - b * f) / det;
                double y0 = -(a * f - c * e) / det;
                rpoint.X = x0;
                rpoint.Y = y0;
                return rpoint;
            }
            else
            {
                RobotPoint ab = new RobotPoint();
                ab.X = 9999;
                ab.Y = 9999;
                return ab;
            }
        }
        public void Gen_Center_2P(HTuple hv_Row1, HTuple hv_Col1, HTuple hv_Row2, HTuple hv_Col2, HTuple hv_Angle, out HTuple hv_Center_Row, out HTuple hv_Center_Col)
        {
            // Local iconic variables 
            // Local control variables 
            HTuple hv_Mid_Row = null, hv_Mid_Col = null;
            HTuple hv_DRow = null, hv_DCol = null, hv_D = null, hv_L = null;
            HTuple hv_Rad = null, hv_Tan = null, hv_H = null;
            // Initialize local and output iconic variables 
            //
            //
            hv_Mid_Row = (hv_Row1 + hv_Row2) / 2;
            hv_Mid_Col = (hv_Col1 + hv_Col2) / 2;
            //
            //
            hv_DRow = hv_Row2 - hv_Row1;
            hv_DCol = hv_Col2 - hv_Col1;
            hv_D = (hv_DRow * hv_DRow) + (hv_DCol * hv_DCol);
            HOperatorSet.TupleSqrt(hv_D, out hv_D);
            hv_L = hv_D * 0.5;
            //
            HOperatorSet.TupleRad(hv_Angle / 2, out hv_Rad);
            HOperatorSet.TupleTan(hv_Rad, out hv_Tan);
            hv_H = hv_L / hv_Tan;
            //
            hv_Center_Row = new HTuple();
            hv_Center_Col = new HTuple();
            if (hv_Center_Row == null)
                hv_Center_Row = new HTuple();
            hv_Center_Row[0] = hv_Mid_Row - ((hv_DCol * hv_H) / hv_D);
            if (hv_Center_Col == null)
                hv_Center_Col = new HTuple();
            hv_Center_Col[0] = hv_Mid_Col + ((hv_DRow * hv_H) / hv_D);
            if (hv_Center_Row == null)
                hv_Center_Row = new HTuple();
            hv_Center_Row[1] = hv_Mid_Row + ((hv_DCol * hv_H) / hv_D);
            if (hv_Center_Col == null)
                hv_Center_Col = new HTuple();
            hv_Center_Col[1] = hv_Mid_Col - ((hv_DRow * hv_H) / hv_D);
            //
            return;
        }
        public double[] RotateCenter(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double a, b, c, d, e, f;
            a = 2 * (x2 - x1);
            b = 2 * (y2 - y1);
            c = x2 * x2 + y2 * y2 - x1 * x1 - y1 * y1;
            d = 2 * (x3 - x2);
            e = 2 * (y3 - y2);
            f = x3 * x3 + y3 * y3 - x2 * x2 - y2 * y2;
            double x = (b * f - e * c) / (b * d - e * a);
            double y = (d * c - a * f) / (b * d - e * a);
            double r = Math.Sqrt((x1 - x) * (x1 - x) + (y1 - x) * (y1 - x));
            double[] xyr = new double[3];
            xyr[0] = x;
            xyr[1] = y;
            xyr[2] = r;
            return xyr;
        }


        public void Get_Cirrle_Center(HTuple hv_Rows, HTuple hv_Cols, out HTuple hv_Center_Row, out HTuple hv_Center_Column, HalconWindow hv_ExpDefaultWinHandle = null)
        {
            // Local iconic variables 

            HObject ho_Contour, ho_ContCircle, ho_ContCircle1;
            HObject ho_Cross;

            // Local control variables 

            HTuple hv_Radius = new HTuple(), hv_StartPhi = new HTuple();
            HTuple hv_EndPhi = new HTuple(), hv_PointOrder = new HTuple();
            HTuple hv_DistanceMin = new HTuple(), hv_DistanceMax = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Contour);
            HOperatorSet.GenEmptyObj(out ho_ContCircle);
            HOperatorSet.GenEmptyObj(out ho_ContCircle1);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            hv_Center_Row = new HTuple();
            hv_Center_Column = new HTuple();
            ho_Contour.Dispose();
            HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Rows, hv_Cols);

            halconWindow1.Disp_Cross(hv_Rows, hv_Cols, 150, 0, "blue");

            //拟合一个圆XLD
            hv_Center_Row.Dispose(); hv_Center_Column.Dispose(); hv_Radius.Dispose(); hv_StartPhi.Dispose(); hv_EndPhi.Dispose(); hv_PointOrder.Dispose();
            HOperatorSet.FitCircleContourXld(ho_Contour, "geotukey", -1, 0, 0, 3, 2, out hv_Center_Row, out hv_Center_Column, out hv_Radius, out hv_StartPhi, out hv_EndPhi, out hv_PointOrder);
            //创建圆弧xld
            ho_ContCircle.Dispose();
            HOperatorSet.GenCircleContourXld(out ho_ContCircle, hv_Center_Row, hv_Center_Column, hv_Radius, hv_StartPhi, hv_EndPhi, "negative", 1);
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_DistanceMin.Dispose(); hv_DistanceMax.Dispose();
                HOperatorSet.DistancePc(ho_ContCircle, hv_Rows.TupleSelect(2), hv_Cols.TupleSelect(2), out hv_DistanceMin, out hv_DistanceMax);
            }
            //判断第三点在不在拟合的弧线上面，这一步主要用点的顺序确定圆弧的其实位置
            if ((int)(new HTuple(hv_DistanceMin.TupleGreater(1))) != 0)
            {
                ho_ContCircle.Dispose();
                HOperatorSet.GenCircleContourXld(out ho_ContCircle, hv_Center_Row, hv_Center_Column, hv_Radius, hv_StartPhi, hv_EndPhi, "positive", 1);
            }
            //拟合一个整圆(其实就是弧度值0到2PI)
            ho_ContCircle1.Dispose();
            HOperatorSet.GenCircleContourXld(out ho_ContCircle1, hv_Center_Row, hv_Center_Column, hv_Radius, 0, 6.28318, "positive", 1);
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                ho_Cross.Dispose();
                HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Center_Row, hv_Center_Column, hv_Radius / 5, 0);
            }
            if (hv_ExpDefaultWinHandle != null)
            {
                hv_ExpDefaultWinHandle.Disp_Region(ho_ContCircle1, "red", "margin");
                hv_ExpDefaultWinHandle.Disp_Region(ho_Cross, "red", "margin");

            }


            ho_Contour.Dispose();
            ho_ContCircle.Dispose();


            hv_Radius.Dispose();
            hv_StartPhi.Dispose();
            hv_EndPhi.Dispose();
            hv_PointOrder.Dispose();
            hv_DistanceMin.Dispose();
            hv_DistanceMax.Dispose();

            return;
        }


        private void Form_Robot_Calibration_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        label75.Text = Work.Cam1_Calibration_Mode ? "标定模式" : "待机模式";
                        label75.BackColor = Work.Cam1_Calibration_Mode ? Color.Green : Color.Cyan;

                        label76.Text = Work.Cam2_Calibration_Mode ? "标定模式" : "待机模式";
                        label76.BackColor = Work.Cam2_Calibration_Mode ? Color.Green : Color.Cyan;

                        label77.Text = Work.Cam3_Calibration_Mode ? "标定模式" : "待机模式";
                        label77.BackColor = Work.Cam3_Calibration_Mode ? Color.Green : Color.Cyan;
                    }
                    catch (Exception)
                    {
                    }
                    Thread.Sleep(500);
                }
            });

            textBox_Cam1_minScore1.Text = CalibrationData.Instance.Cam1_minScore1.ToString("0.00000");
            textBox_Cam1_minScore2.Text = CalibrationData.Instance.Cam1_minScore2.ToString("0.00000");
            textBox_Cam2_minScore1.Text = CalibrationData.Instance.Cam2_minScore1.ToString("0.00000");
            textBox_Cam2_minScore2.Text = CalibrationData.Instance.Cam2_minScore2.ToString("0.00000");
            textBox_Cam3_minScore1.Text = CalibrationData.Instance.Cam3_minScore1.ToString("0.00000");
            textBox_Cam3_minScore2.Text = CalibrationData.Instance.Cam3_minScore2.ToString("0.00000");

            textBox_Cam1_Point1_X1.Text = CalibrationData.Instance.Cam1_Rotate1_Point1.X.ToString("0.00000");
            textBox_Cam1_Point1_Y1.Text = CalibrationData.Instance.Cam1_Rotate1_Point1.Y.ToString("0.00000");
            textBox_Cam1_Point1_X2.Text = CalibrationData.Instance.Cam1_Rotate1_Point2.X.ToString("0.00000");
            textBox_Cam1_Point1_Y2.Text = CalibrationData.Instance.Cam1_Rotate1_Point2.Y.ToString("0.00000");
            textBox_Cam1_Point1_X3.Text = CalibrationData.Instance.Cam1_Rotate1_Point3.X.ToString("0.00000");
            textBox_Cam1_Point1_Y3.Text = CalibrationData.Instance.Cam1_Rotate1_Point3.Y.ToString("0.00000");
            textBox_Cam1_Point2_X1.Text = CalibrationData.Instance.Cam1_Rotate2_Point1.X.ToString("0.00000");
            textBox_Cam1_Point2_Y1.Text = CalibrationData.Instance.Cam1_Rotate2_Point1.Y.ToString("0.00000");
            textBox_Cam1_Point2_X2.Text = CalibrationData.Instance.Cam1_Rotate2_Point2.X.ToString("0.00000");
            textBox_Cam1_Point2_Y2.Text = CalibrationData.Instance.Cam1_Rotate2_Point2.Y.ToString("0.00000");
            textBox_Cam1_Point2_X3.Text = CalibrationData.Instance.Cam1_Rotate2_Point3.X.ToString("0.00000");
            textBox_Cam1_Point2_Y3.Text = CalibrationData.Instance.Cam1_Rotate2_Point3.Y.ToString("0.00000");
            textBox_Cam1_Center1_X.Text = CalibrationData.Instance.Cam1_Rotate_Center1_Point.X.ToString("0.00000");
            textBox_Cam1_Center1_Y.Text = CalibrationData.Instance.Cam1_Rotate_Center1_Point.Y.ToString("0.00000");
            textBox_Cam1_Center2_X.Text = CalibrationData.Instance.Cam1_Rotate_Center2_Point.X.ToString("0.00000");
            textBox_Cam1_Center2_Y.Text = CalibrationData.Instance.Cam1_Rotate_Center2_Point.Y.ToString("0.00000");
            text_Cam1_Standard_Point1_X.Text = CalibrationData.Instance.Cam1_Standard1_Point.X.ToString("0.00000");
            text_Cam1_Standard_Point1_Y.Text = CalibrationData.Instance.Cam1_Standard1_Point.Y.ToString("0.00000");
            text_Cam1_Standard_Point1_U.Text = CalibrationData.Instance.Cam1_Standard1_Point.U.ToString("0.00000");
            text_Cam1_Standard_Point2_X.Text = CalibrationData.Instance.Cam1_Standard2_Point.X.ToString("0.00000");
            text_Cam1_Standard_Point2_Y.Text = CalibrationData.Instance.Cam1_Standard2_Point.Y.ToString("0.00000");
            text_Cam1_Standard_Point2_U.Text = CalibrationData.Instance.Cam1_Standard2_Point.U.ToString("0.00000");

            textBox_Cam2_Point1_X1.Text = CalibrationData.Instance.Cam2_Rotate1_Point1.X.ToString("0.00000");
            textBox_Cam2_Point1_Y1.Text = CalibrationData.Instance.Cam2_Rotate1_Point1.Y.ToString("0.00000");
            textBox_Cam2_Point1_X2.Text = CalibrationData.Instance.Cam2_Rotate1_Point2.X.ToString("0.00000");
            textBox_Cam2_Point1_Y2.Text = CalibrationData.Instance.Cam2_Rotate1_Point2.Y.ToString("0.00000");
            textBox_Cam2_Point1_X3.Text = CalibrationData.Instance.Cam2_Rotate1_Point3.X.ToString("0.00000");
            textBox_Cam2_Point1_Y3.Text = CalibrationData.Instance.Cam2_Rotate1_Point3.Y.ToString("0.00000");
            textBox_Cam2_Point2_X1.Text = CalibrationData.Instance.Cam2_Rotate2_Point1.X.ToString("0.00000");
            textBox_Cam2_Point2_Y1.Text = CalibrationData.Instance.Cam2_Rotate2_Point1.Y.ToString("0.00000");
            textBox_Cam2_Point2_X2.Text = CalibrationData.Instance.Cam2_Rotate2_Point2.X.ToString("0.00000");
            textBox_Cam2_Point2_Y2.Text = CalibrationData.Instance.Cam2_Rotate2_Point2.Y.ToString("0.00000");
            textBox_Cam2_Point2_X3.Text = CalibrationData.Instance.Cam2_Rotate2_Point3.X.ToString("0.00000");
            textBox_Cam2_Point2_Y3.Text = CalibrationData.Instance.Cam2_Rotate2_Point3.Y.ToString("0.00000");
            textBox_Cam2_Center1_X.Text = CalibrationData.Instance.Cam2_Rotate_Center1_Point.X.ToString("0.00000");
            textBox_Cam2_Center1_Y.Text = CalibrationData.Instance.Cam2_Rotate_Center1_Point.Y.ToString("0.00000");
            textBox_Cam2_Center2_X.Text = CalibrationData.Instance.Cam2_Rotate_Center2_Point.X.ToString("0.00000");
            textBox_Cam2_Center2_Y.Text = CalibrationData.Instance.Cam2_Rotate_Center2_Point.Y.ToString("0.00000");
            text_Cam2_Standard_Point1_X.Text = CalibrationData.Instance.Cam2_Standard1_Point.X.ToString("0.00000");
            text_Cam2_Standard_Point1_Y.Text = CalibrationData.Instance.Cam2_Standard1_Point.Y.ToString("0.00000");
            text_Cam2_Standard_Point1_U.Text = CalibrationData.Instance.Cam2_Standard1_Point.U.ToString("0.00000");
            text_Cam2_Standard_Point2_X.Text = CalibrationData.Instance.Cam2_Standard2_Point.X.ToString("0.00000");
            text_Cam2_Standard_Point2_Y.Text = CalibrationData.Instance.Cam2_Standard2_Point.Y.ToString("0.00000");
            text_Cam2_Standard_Point2_U.Text = CalibrationData.Instance.Cam2_Standard2_Point.U.ToString("0.00000");

            textBox_Cam3_Point1_X1.Text = CalibrationData.Instance.Cam3_Rotate1_Point1.X.ToString("0.00000");
            textBox_Cam3_Point1_Y1.Text = CalibrationData.Instance.Cam3_Rotate1_Point1.Y.ToString("0.00000");
            textBox_Cam3_Point1_X2.Text = CalibrationData.Instance.Cam3_Rotate1_Point2.X.ToString("0.00000");
            textBox_Cam3_Point1_Y2.Text = CalibrationData.Instance.Cam3_Rotate1_Point2.Y.ToString("0.00000");
            textBox_Cam3_Point1_X3.Text = CalibrationData.Instance.Cam3_Rotate1_Point3.X.ToString("0.00000");
            textBox_Cam3_Point1_Y3.Text = CalibrationData.Instance.Cam3_Rotate1_Point3.Y.ToString("0.00000");
            textBox_Cam3_Point2_X1.Text = CalibrationData.Instance.Cam3_Rotate2_Point1.X.ToString("0.00000");
            textBox_Cam3_Point2_Y1.Text = CalibrationData.Instance.Cam3_Rotate2_Point1.Y.ToString("0.00000");
            textBox_Cam3_Point2_X2.Text = CalibrationData.Instance.Cam3_Rotate2_Point2.X.ToString("0.00000");
            textBox_Cam3_Point2_Y2.Text = CalibrationData.Instance.Cam3_Rotate2_Point2.Y.ToString("0.00000");
            textBox_Cam3_Point2_X3.Text = CalibrationData.Instance.Cam3_Rotate2_Point3.X.ToString("0.00000");
            textBox_Cam3_Point2_Y3.Text = CalibrationData.Instance.Cam3_Rotate2_Point3.Y.ToString("0.00000");
            textBox_Cam3_Center1_X.Text = CalibrationData.Instance.Cam3_Rotate_Center1_Point.X.ToString("0.00000");
            textBox_Cam3_Center1_Y.Text = CalibrationData.Instance.Cam3_Rotate_Center1_Point.Y.ToString("0.00000");
            textBox_Cam3_Center2_X.Text = CalibrationData.Instance.Cam3_Rotate_Center2_Point.X.ToString("0.00000");
            textBox_Cam3_Center2_Y.Text = CalibrationData.Instance.Cam3_Rotate_Center2_Point.Y.ToString("0.00000");
            text_Cam3_Standard_Point1_X.Text = CalibrationData.Instance.Cam3_Standard1_Point.X.ToString("0.00000");
            text_Cam3_Standard_Point1_Y.Text = CalibrationData.Instance.Cam3_Standard1_Point.Y.ToString("0.00000");
            text_Cam3_Standard_Point1_U.Text = CalibrationData.Instance.Cam3_Standard1_Point.U.ToString("0.00000");
            text_Cam3_Standard_Point2_X.Text = CalibrationData.Instance.Cam3_Standard2_Point.X.ToString("0.00000");
            text_Cam3_Standard_Point2_Y.Text = CalibrationData.Instance.Cam3_Standard2_Point.Y.ToString("0.00000");
            text_Cam3_Standard_Point2_U.Text = CalibrationData.Instance.Cam3_Standard2_Point.U.ToString("0.00000");

            for (int i = 0; i < CalibrationData.Instance.Cam1_Robot_Location.Count; i++)
            {
                //int index = dataGridView_Cam1.Rows.Add();
                dataGridView_Cam1.Rows[i].Cells[0].Value = i + 1;
                dataGridView_Cam1.Rows[i].Cells[1].Value = CalibrationData.Instance.Cam1_Pixel_Location[i].X;
                dataGridView_Cam1.Rows[i].Cells[2].Value = CalibrationData.Instance.Cam1_Pixel_Location[i].Y;
                dataGridView_Cam1.Rows[i].Cells[3].Value = CalibrationData.Instance.Cam1_Robot_Location[i].X;
                dataGridView_Cam1.Rows[i].Cells[4].Value = CalibrationData.Instance.Cam1_Robot_Location[i].Y;

                //AddData(1, i >= 24 ? 1 : 2, i,
                //    CalibrationData.Instance.Cam1_Pixel_Location[i].X,
                //    CalibrationData.Instance.Cam1_Pixel_Location[i].Y,
                //    CalibrationData.Instance.Cam1_Robot_Location[i].X,
                //    CalibrationData.Instance.Cam1_Robot_Location[i].Y);

            }

            for (int i = 0; i < CalibrationData.Instance.Cam2_Robot_Location.Count; i++)
            {
                //int index = dataGridView_Cam2.Rows.Add();
                dataGridView_Cam2.Rows[i].Cells[0].Value = i + 1;
                dataGridView_Cam2.Rows[i].Cells[1].Value = CalibrationData.Instance.Cam2_Pixel_Location[i].X;
                dataGridView_Cam2.Rows[i].Cells[2].Value = CalibrationData.Instance.Cam2_Pixel_Location[i].Y;
                dataGridView_Cam2.Rows[i].Cells[3].Value = CalibrationData.Instance.Cam2_Robot_Location[i].X;
                dataGridView_Cam2.Rows[i].Cells[4].Value = CalibrationData.Instance.Cam2_Robot_Location[i].Y;
                //AddData(2, i >= 24 ? 1 : 2, i,
                //   CalibrationData.Instance.Cam1_Pixel_Location[i].X,
                //   CalibrationData.Instance.Cam1_Pixel_Location[i].Y,
                //   CalibrationData.Instance.Cam1_Robot_Location[i].X,
                //   CalibrationData.Instance.Cam1_Robot_Location[i].Y);
            }
            for (int i = 0; i < CalibrationData.Instance.Cam3_Robot_Location.Count; i++)
            {
                //int index = dataGridView_Cam3.Rows.Add();
                dataGridView_Cam3.Rows[i].Cells[0].Value = i + 1;
                dataGridView_Cam3.Rows[i].Cells[1].Value = CalibrationData.Instance.Cam3_Pixel_Location[i].X;
                dataGridView_Cam3.Rows[i].Cells[2].Value = CalibrationData.Instance.Cam3_Pixel_Location[i].Y;
                dataGridView_Cam3.Rows[i].Cells[3].Value = CalibrationData.Instance.Cam3_Robot_Location[i].X;
                dataGridView_Cam3.Rows[i].Cells[4].Value = CalibrationData.Instance.Cam3_Robot_Location[i].Y;
                //AddData(3, i > 24 ? 1 : 2, i,
                //   CalibrationData.Instance.Cam1_Pixel_Location[i].X,
                //   CalibrationData.Instance.Cam1_Pixel_Location[i].Y,
                //   CalibrationData.Instance.Cam1_Robot_Location[i].X,
                //   CalibrationData.Instance.Cam1_Robot_Location[i].Y);
            }
        }

        public void SaveData()
        {
            CalibrationData.Instance.Cam1_minScore1 = double.Parse(textBox_Cam1_minScore1.Text.Trim());
            CalibrationData.Instance.Cam1_minScore2 = double.Parse(textBox_Cam1_minScore2.Text.Trim());
            CalibrationData.Instance.Cam2_minScore1 = double.Parse(textBox_Cam2_minScore1.Text.Trim());
            CalibrationData.Instance.Cam2_minScore2 = double.Parse(textBox_Cam2_minScore2.Text.Trim());
            CalibrationData.Instance.Cam3_minScore1 = double.Parse(textBox_Cam3_minScore1.Text.Trim());
            CalibrationData.Instance.Cam3_minScore2 = double.Parse(textBox_Cam3_minScore2.Text.Trim());

            CalibrationData.Instance.Cam1_Rotate1_Point1.X = double.Parse(textBox_Cam1_Point1_X1.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate1_Point1.Y = double.Parse(textBox_Cam1_Point1_Y1.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate1_Point2.X = double.Parse(textBox_Cam1_Point1_X2.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate1_Point2.Y = double.Parse(textBox_Cam1_Point1_Y2.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate1_Point3.X = double.Parse(textBox_Cam1_Point1_X3.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate1_Point3.Y = double.Parse(textBox_Cam1_Point1_Y3.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate2_Point1.X = double.Parse(textBox_Cam1_Point2_X1.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate2_Point1.Y = double.Parse(textBox_Cam1_Point2_Y1.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate2_Point2.X = double.Parse(textBox_Cam1_Point2_X2.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate2_Point2.Y = double.Parse(textBox_Cam1_Point2_Y2.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate2_Point3.X = double.Parse(textBox_Cam1_Point2_X3.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate2_Point3.Y = double.Parse(textBox_Cam1_Point2_Y3.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate_Center1_Point.X = double.Parse(textBox_Cam1_Center1_X.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate_Center1_Point.Y = double.Parse(textBox_Cam1_Center1_Y.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate_Center2_Point.X = double.Parse(textBox_Cam1_Center2_X.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate_Center2_Point.Y = double.Parse(textBox_Cam1_Center2_Y.Text.Trim());
            CalibrationData.Instance.Cam1_Standard1_Point.X = double.Parse(text_Cam1_Standard_Point1_X.Text.Trim());
            CalibrationData.Instance.Cam1_Standard1_Point.Y = double.Parse(text_Cam1_Standard_Point1_Y.Text.Trim());
            CalibrationData.Instance.Cam1_Standard1_Point.U = double.Parse(text_Cam1_Standard_Point1_U.Text.Trim());
            CalibrationData.Instance.Cam1_Standard2_Point.X = double.Parse(text_Cam1_Standard_Point2_X.Text.Trim());
            CalibrationData.Instance.Cam1_Standard2_Point.Y = double.Parse(text_Cam1_Standard_Point2_Y.Text.Trim());
            CalibrationData.Instance.Cam1_Standard2_Point.U = double.Parse(text_Cam1_Standard_Point2_U.Text.Trim());

            CalibrationData.Instance.Cam2_Rotate1_Point1.X = double.Parse(textBox_Cam2_Point1_X1.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate1_Point1.Y = double.Parse(textBox_Cam2_Point1_Y1.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate1_Point2.X = double.Parse(textBox_Cam2_Point1_X2.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate1_Point2.Y = double.Parse(textBox_Cam2_Point1_Y2.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate1_Point3.X = double.Parse(textBox_Cam2_Point1_X3.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate1_Point3.Y = double.Parse(textBox_Cam2_Point1_Y3.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate2_Point1.X = double.Parse(textBox_Cam2_Point2_X1.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate2_Point1.Y = double.Parse(textBox_Cam2_Point2_Y1.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate2_Point2.X = double.Parse(textBox_Cam2_Point2_X2.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate2_Point2.Y = double.Parse(textBox_Cam2_Point2_Y2.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate2_Point3.X = double.Parse(textBox_Cam2_Point2_X3.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate2_Point3.Y = double.Parse(textBox_Cam2_Point2_Y3.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate_Center1_Point.X = double.Parse(textBox_Cam2_Center1_X.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate_Center1_Point.Y = double.Parse(textBox_Cam2_Center1_Y.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate_Center2_Point.X = double.Parse(textBox_Cam2_Center2_X.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate_Center2_Point.Y = double.Parse(textBox_Cam2_Center2_Y.Text.Trim());
            CalibrationData.Instance.Cam2_Standard1_Point.X = double.Parse(text_Cam2_Standard_Point1_X.Text.Trim());
            CalibrationData.Instance.Cam2_Standard1_Point.Y = double.Parse(text_Cam2_Standard_Point1_Y.Text.Trim());
            CalibrationData.Instance.Cam2_Standard1_Point.U = double.Parse(text_Cam2_Standard_Point1_U.Text.Trim());
            CalibrationData.Instance.Cam2_Standard2_Point.X = double.Parse(text_Cam2_Standard_Point2_X.Text.Trim());
            CalibrationData.Instance.Cam2_Standard2_Point.Y = double.Parse(text_Cam2_Standard_Point2_Y.Text.Trim());
            CalibrationData.Instance.Cam2_Standard2_Point.U = double.Parse(text_Cam2_Standard_Point2_U.Text.Trim());

            CalibrationData.Instance.Cam3_Rotate1_Point1.X = double.Parse(textBox_Cam3_Point1_X1.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate1_Point1.Y = double.Parse(textBox_Cam3_Point1_Y1.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate1_Point2.X = double.Parse(textBox_Cam3_Point1_X2.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate1_Point2.Y = double.Parse(textBox_Cam3_Point1_Y2.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate1_Point3.X = double.Parse(textBox_Cam3_Point1_X3.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate1_Point3.Y = double.Parse(textBox_Cam3_Point1_Y3.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate2_Point1.X = double.Parse(textBox_Cam3_Point2_X1.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate2_Point1.Y = double.Parse(textBox_Cam3_Point2_Y1.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate2_Point2.X = double.Parse(textBox_Cam3_Point2_X2.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate2_Point2.Y = double.Parse(textBox_Cam3_Point2_Y2.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate2_Point3.X = double.Parse(textBox_Cam3_Point2_X3.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate2_Point3.Y = double.Parse(textBox_Cam3_Point2_Y3.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate_Center1_Point.X = double.Parse(textBox_Cam3_Center1_X.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate_Center1_Point.Y = double.Parse(textBox_Cam3_Center1_Y.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate_Center2_Point.X = double.Parse(textBox_Cam3_Center2_X.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate_Center2_Point.Y = double.Parse(textBox_Cam3_Center2_Y.Text.Trim());
            CalibrationData.Instance.Cam3_Standard1_Point.X = double.Parse(text_Cam3_Standard_Point1_X.Text.Trim());
            CalibrationData.Instance.Cam3_Standard1_Point.Y = double.Parse(text_Cam3_Standard_Point1_Y.Text.Trim());
            CalibrationData.Instance.Cam3_Standard1_Point.U = double.Parse(text_Cam3_Standard_Point1_U.Text.Trim());
            CalibrationData.Instance.Cam3_Standard2_Point.X = double.Parse(text_Cam3_Standard_Point2_X.Text.Trim());
            CalibrationData.Instance.Cam3_Standard2_Point.Y = double.Parse(text_Cam3_Standard_Point2_Y.Text.Trim());
            CalibrationData.Instance.Cam3_Standard2_Point.U = double.Parse(text_Cam3_Standard_Point2_U.Text.Trim());

            CalibrationData.Instance.Cam1_Robot_Location = new List<RobotPoint>();
            CalibrationData.Instance.Cam1_Pixel_Location = new List<RobotPoint>();
            CalibrationData.Instance.Cam2_Robot_Location = new List<RobotPoint>();
            CalibrationData.Instance.Cam2_Pixel_Location = new List<RobotPoint>();
            CalibrationData.Instance.Cam3_Robot_Location = new List<RobotPoint>();
            CalibrationData.Instance.Cam3_Pixel_Location = new List<RobotPoint>();

            for (int i = 0; i < dataGridView_Cam1.Rows.Count - 1; i++)
            {
                CalibrationData.Instance.Cam1_Robot_Location.Add(new RobotPoint() { X = double.Parse(dataGridView_Cam1.Rows[i].Cells[3].Value.ToString()), Y = double.Parse(dataGridView_Cam1.Rows[i].Cells[4].Value.ToString()) });
                CalibrationData.Instance.Cam1_Pixel_Location.Add(new RobotPoint() { X = double.Parse(dataGridView_Cam1.Rows[i].Cells[1].Value.ToString()), Y = double.Parse(dataGridView_Cam1.Rows[i].Cells[2].Value.ToString()) });
            }
            for (int i = 0; i < dataGridView_Cam2.Rows.Count - 1; i++)
            {
                CalibrationData.Instance.Cam2_Robot_Location.Add(new RobotPoint() { X = double.Parse(dataGridView_Cam2.Rows[i].Cells[3].Value.ToString()), Y = double.Parse(dataGridView_Cam2.Rows[i].Cells[4].Value.ToString()) });
                CalibrationData.Instance.Cam2_Pixel_Location.Add(new RobotPoint() { X = double.Parse(dataGridView_Cam2.Rows[i].Cells[1].Value.ToString()), Y = double.Parse(dataGridView_Cam2.Rows[i].Cells[2].Value.ToString()) });
            }
            for (int i = 0; i < dataGridView_Cam3.Rows.Count - 1; i++)
            {
                CalibrationData.Instance.Cam3_Robot_Location.Add(new RobotPoint() { X = double.Parse(dataGridView_Cam3.Rows[i].Cells[3].Value.ToString()), Y = double.Parse(dataGridView_Cam3.Rows[i].Cells[4].Value.ToString()) });
                CalibrationData.Instance.Cam3_Pixel_Location.Add(new RobotPoint() { X = double.Parse(dataGridView_Cam3.Rows[i].Cells[1].Value.ToString()), Y = double.Parse(dataGridView_Cam3.Rows[i].Cells[2].Value.ToString()) });
            }
        }

        private void Form_Robot_Calibration_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppParam.Instance.Robot_Calibration_State = false;
            //SaveData();
            //AppParam.Instance.Save_To_File();
        }

        public void Auto(int CamIndex)
        {
            // x=>Row
            //y=>column


            if (CamIndex == 1)
            {

                HTuple CenterX, CenterY;
                Cam1_1号吸嘴9点标定();
                Cam1_1号吸嘴旋转标定();
                Cam1_2号吸嘴9点标定();
                Cam1_2号吸嘴旋转标定();
                SaveData();
                AppParam.Instance.Save_To_File();
                Log.WriteRunLog("相机1 自动标定完成");
            }
            else if (CamIndex == 2)
            {

                HTuple CenterX, CenterY;
                Cam2_1号吸嘴9点标定();
                Cam2_1号吸嘴旋转标定();
                Cam2_2号吸嘴9点标定();
                Cam2_2号吸嘴旋转标定();
                SaveData();
                AppParam.Instance.Save_To_File();

                Log.WriteRunLog("相机2 自动标定完成");
            }
            else if (CamIndex == 3)
            {

                HTuple CenterX, CenterY;
                Cam3_1号吸嘴9点标定();
                Cam3_1号吸嘴旋转标定();
                Cam3_2号吸嘴9点标定();
                Cam3_2号吸嘴旋转标定();
                SaveData();
                AppParam.Instance.Save_To_File();
                Log.WriteRunLog("相机3 自动标定完成");
            }


        }
        //private void Cam1_1号吸嘴9点标定()
        //{
        //    HTuple Row = new HTuple(); HTuple Column = new HTuple(); HTuple X = new HTuple(); HTuple Y = new HTuple();
        //    for (int i = 0; i < 9; i++)
        //    {
        //        X[i] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[3].Value.ToString());
        //        Y[i] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[4].Value.ToString());


        //        Column[i] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[2].Value.ToString());
        //        Row[i] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[1].Value.ToString());

        //        halconWindow1.Disp_Cross(Row[i], Column[i], 150, 0, "blue");
        //        halconWindow1.Disp_Message("" + i, 16, Row[i], Column[i], "blue");

        //    }
        //    HOperatorSet.VectorToHomMat2d(Row, Column, X, Y, out CalibrationData.Instance.Cam1_HomMat2d1);
        //}

        //private void Cam1_1号吸嘴旋转标定()
        //{
        //    HTuple CenterX = new HTuple(); HTuple CenterY = new HTuple();
        //    textBox_Cam1_Point1_X1.Text = dataGridView_Cam1.Rows[4].Cells[1].Value.ToString();
        //    textBox_Cam1_Point1_Y1.Text = dataGridView_Cam1.Rows[4].Cells[2].Value.ToString();
        //    textBox_Cam1_Point1_X2.Text = dataGridView_Cam1.Rows[9].Cells[1].Value.ToString();
        //    textBox_Cam1_Point1_Y2.Text = dataGridView_Cam1.Rows[9].Cells[2].Value.ToString();
        //    textBox_Cam1_Point1_X3.Text = dataGridView_Cam1.Rows[10].Cells[1].Value.ToString();
        //    textBox_Cam1_Point1_Y3.Text = dataGridView_Cam1.Rows[10].Cells[2].Value.ToString();
        //    HTuple Point1_X1 = double.Parse(textBox_Cam1_Point1_X1.Text);
        //    HTuple Point1_Y1 = double.Parse(textBox_Cam1_Point1_Y1.Text);
        //    HTuple Point1_X2 = double.Parse(textBox_Cam1_Point1_X2.Text);
        //    HTuple Point1_Y2 = double.Parse(textBox_Cam1_Point1_Y2.Text);
        //    HTuple Point1_X3 = double.Parse(textBox_Cam1_Point1_X3.Text);
        //    HTuple Point1_Y3 = double.Parse(textBox_Cam1_Point1_Y3.Text);
        //    // RobotPoint Center_Point = CenterRotation(new RobotPoint() { X = Point1_X1.D, Y = Point1_Y1.D }, new RobotPoint() { X = Point1_X2.D, Y = Point1_Y2.D }, new RobotPoint() { X = Point1_X3.D, Y = Point1_Y3.D });
        //    Get_Cirrle_Center(new HTuple(Point1_X1, Point1_X2, Point1_X3), new HTuple(Point1_Y2, Point1_Y2, Point1_Y3), out _, out _, halconWindow1);

        //    HTuple Robot_Point1_X1 = new HTuple(0.0);
        //    HTuple Robot_Point1_Y1 = new HTuple(0.0);
        //    HTuple Robot_Point1_X2 = new HTuple(0.0);
        //    HTuple Robot_Point1_Y2 = new HTuple(0.0);
        //    HTuple Robot_Point1_X3 = new HTuple(0.0);
        //    HTuple Robot_Point1_Y3 = new HTuple(0.0);

        //    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam1_HomMat2d1, Point1_X1, Point1_Y1, out Robot_Point1_X1, out Robot_Point1_Y1);
        //    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam1_HomMat2d1, Point1_X2, Point1_Y2, out Robot_Point1_X2, out Robot_Point1_Y3);
        //    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam1_HomMat2d1, Point1_X3, Point1_Y3, out Robot_Point1_X3, out Robot_Point1_Y2);
        //    CenterX = new HTuple(0.0);
        //    CenterY = new HTuple(0.0);
        //    Get_Cirrle_Center(new HTuple(Robot_Point1_X1, Robot_Point1_X2, Robot_Point1_X3), new HTuple(Robot_Point1_Y1, Robot_Point1_Y2, Robot_Point1_Y3), out CenterX, out CenterY, halconWindow1);

        //    textBox_Cam1_Center1_X.Text = CenterX.D.ToString("0.00000");
        //    textBox_Cam1_Center1_Y.Text = CenterY.D.ToString("0.00000");
        //}

        //private void Cam1_2号吸嘴9点标定()
        //{
        //    HTuple Row = new HTuple(); HTuple Column = new HTuple(); HTuple X = new HTuple(); HTuple Y = new HTuple();
        //    for (int i = 11; i < 20; i++)
        //    {
        //        X[i - 11] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[3].Value.ToString());
        //        Y[i - 11] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[4].Value.ToString());
        //        Column[i - 11] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[2].Value.ToString());
        //        Row[i - 11] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[1].Value.ToString());
        //        halconWindow1.Disp_Cross(Row[i], Column[i], 150, 0, "blue");
        //        halconWindow1.Disp_Message("" + i, 16, Row[i], Column[i], "blue");
        //    }
        //    HOperatorSet.VectorToHomMat2d(Row, Column, X, Y, out CalibrationData.Instance.Cam1_HomMat2d2);
        //}

        //private void Cam1_2号吸嘴旋转标定()
        //{
        //    HTuple CenterX = new HTuple(); HTuple CenterY = new HTuple();
        //    textBox_Cam1_Point2_X1.Text = dataGridView_Cam1.Rows[15].Cells[1].Value.ToString();
        //    textBox_Cam1_Point2_Y1.Text = dataGridView_Cam1.Rows[15].Cells[2].Value.ToString();
        //    textBox_Cam1_Point2_X2.Text = dataGridView_Cam1.Rows[20].Cells[1].Value.ToString();
        //    textBox_Cam1_Point2_Y2.Text = dataGridView_Cam1.Rows[20].Cells[2].Value.ToString();
        //    textBox_Cam1_Point2_X3.Text = dataGridView_Cam1.Rows[21].Cells[1].Value.ToString();
        //    textBox_Cam1_Point2_Y3.Text = dataGridView_Cam1.Rows[21].Cells[2].Value.ToString();
        //    HTuple Point2_X1 = double.Parse(textBox_Cam1_Point2_X1.Text);
        //    HTuple Point2_Y1 = double.Parse(textBox_Cam1_Point2_Y1.Text);
        //    HTuple Point2_X2 = double.Parse(textBox_Cam1_Point2_X2.Text);
        //    HTuple Point2_Y2 = double.Parse(textBox_Cam1_Point2_Y2.Text);
        //    HTuple Point2_X3 = double.Parse(textBox_Cam1_Point2_X3.Text);
        //    HTuple Point2_Y3 = double.Parse(textBox_Cam1_Point2_Y3.Text);

        //    HTuple Robot_Point2_X1;
        //    HTuple Robot_Point2_Y1;
        //    HTuple Robot_Point2_X2;
        //    HTuple Robot_Point2_Y2;
        //    HTuple Robot_Point2_X3;
        //    HTuple Robot_Point2_Y3;
        //    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam1_HomMat2d2, Point2_X1, Point2_Y1, out Robot_Point2_X1, out Robot_Point2_Y1);
        //    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam1_HomMat2d2, Point2_X2, Point2_Y2, out Robot_Point2_X2, out Robot_Point2_Y2);
        //    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam1_HomMat2d2, Point2_X3, Point2_Y3, out Robot_Point2_X3, out Robot_Point2_Y3);

        //    Get_Cirrle_Center(new HTuple(Robot_Point2_X1, Robot_Point2_X2, Robot_Point2_X3), new HTuple(Robot_Point2_Y1, Robot_Point2_Y2, Robot_Point2_Y3), out CenterX, out CenterY, halconWindow1);


        //    textBox_Cam1_Center2_X.Text = CenterX.D.ToString("0.00000");
        //    textBox_Cam1_Center2_Y.Text = CenterY.D.ToString("0.00000");
        //}

        //private void Cam2_1号吸嘴9点标定()
        //{
        //    HTuple Row = new HTuple(); HTuple Column = new HTuple(); HTuple X = new HTuple(); HTuple Y = new HTuple();
        //    for (int i = 0; i < 9; i++)
        //    {
        //        X[i] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[3].Value.ToString());
        //        Y[i] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[4].Value.ToString());
        //        Column[i] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[2].Value.ToString());
        //        Row[i] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[1].Value.ToString());
        //        halconWindow1.Disp_Cross(Row[i], Column[i], 150, 0, "blue");
        //        halconWindow1.Disp_Message("" + i, 16, Row[i], Column[i], "blue");
        //    }
        //    HOperatorSet.VectorToHomMat2d(Row, Column, X, Y, out CalibrationData.Instance.Cam2_HomMat2d1);
        //}

        //private void Cam2_1号吸嘴旋转标定()
        //{
        //    HTuple CenterX = new HTuple(); HTuple CenterY = new HTuple();
        //    textBox_Cam2_Point1_X1.Text = dataGridView_Cam2.Rows[4].Cells[1].Value.ToString();
        //    textBox_Cam2_Point1_Y1.Text = dataGridView_Cam2.Rows[4].Cells[2].Value.ToString();
        //    textBox_Cam2_Point1_X2.Text = dataGridView_Cam2.Rows[9].Cells[1].Value.ToString();
        //    textBox_Cam2_Point1_Y2.Text = dataGridView_Cam2.Rows[9].Cells[2].Value.ToString();
        //    textBox_Cam2_Point1_X3.Text = dataGridView_Cam2.Rows[10].Cells[1].Value.ToString();
        //    textBox_Cam2_Point1_Y3.Text = dataGridView_Cam2.Rows[10].Cells[2].Value.ToString();
        //    HTuple Point1_X1 = double.Parse(textBox_Cam2_Point1_X1.Text);
        //    HTuple Point1_Y1 = double.Parse(textBox_Cam2_Point1_Y1.Text);
        //    HTuple Point1_X2 = double.Parse(textBox_Cam2_Point1_X2.Text);
        //    HTuple Point1_Y2 = double.Parse(textBox_Cam2_Point1_Y2.Text);
        //    HTuple Point1_X3 = double.Parse(textBox_Cam2_Point1_X3.Text);
        //    HTuple Point1_Y3 = double.Parse(textBox_Cam2_Point1_Y3.Text);
        //    //RobotPoint Center_Point = CenterRotation(new RobotPoint() { X = Point1_X1.D, Y = Point1_Y1.D }, new RobotPoint() { X = Point1_X2.D, Y = Point1_Y2.D },
        //    //                                        new RobotPoint() { X = Point1_X3.D, Y = Point1_Y3.D });

        //    HTuple Robot_Point1_X1 = new HTuple(0.0);
        //    HTuple Robot_Point1_Y1 = new HTuple(0.0);
        //    HTuple Robot_Point1_X2 = new HTuple(0.0);
        //    HTuple Robot_Point1_Y2 = new HTuple(0.0);
        //    HTuple Robot_Point1_X3 = new HTuple(0.0);
        //    HTuple Robot_Point1_Y3 = new HTuple(0.0);
        //    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d1, Point1_X1, Point1_Y1, out Robot_Point1_X1, out Robot_Point1_Y1);
        //    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d1, Point1_X2, Point1_Y2, out Robot_Point1_X2, out Robot_Point1_Y3);
        //    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d1, Point1_X3, Point1_Y3, out Robot_Point1_X3, out Robot_Point1_Y2);
        //    CenterX = new HTuple(0.0);
        //    CenterY = new HTuple(0.0);
        //    Get_Cirrle_Center(new HTuple(Robot_Point1_X1, Robot_Point1_X2, Robot_Point1_X3), new HTuple(Robot_Point1_Y1, Robot_Point1_Y2, Robot_Point1_Y3), out CenterX, out CenterY, halconWindow1);

        //    textBox_Cam2_Center1_X.Text = CenterX.D.ToString("0.00000");
        //    textBox_Cam2_Center1_Y.Text = CenterY.D.ToString("0.00000");
        //}

        //private void Cam2_2号吸嘴9点标定()
        //{
        //    HTuple Row = new HTuple(); HTuple Column = new HTuple(); HTuple X = new HTuple(); HTuple Y = new HTuple();
        //    for (int i = 11; i < 20; i++)
        //    {
        //        X[i - 11] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[3].Value.ToString());
        //        Y[i - 11] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[4].Value.ToString());
        //        Column[i - 11] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[2].Value.ToString());
        //        Row[i - 11] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[1].Value.ToString());
        //        halconWindow1.Disp_Cross(Row[i], Column[i], 150, 0, "blue");
        //        halconWindow1.Disp_Message("" + i, 16, Row[i], Column[i], "blue");
        //    }
        //    HOperatorSet.VectorToHomMat2d(Row, Column, X, Y, out CalibrationData.Instance.Cam2_HomMat2d2);
        //}

        //private void Cam2_2号吸嘴旋转标定()
        //{
        //    HTuple CenterX = new HTuple(); HTuple CenterY = new HTuple();
        //    textBox_Cam2_Point2_X1.Text = dataGridView_Cam2.Rows[15].Cells[1].Value.ToString();
        //    textBox_Cam2_Point2_Y1.Text = dataGridView_Cam2.Rows[15].Cells[2].Value.ToString();
        //    textBox_Cam2_Point2_X2.Text = dataGridView_Cam2.Rows[20].Cells[1].Value.ToString();
        //    textBox_Cam2_Point2_Y2.Text = dataGridView_Cam2.Rows[20].Cells[2].Value.ToString();
        //    textBox_Cam2_Point2_X3.Text = dataGridView_Cam2.Rows[21].Cells[1].Value.ToString();
        //    textBox_Cam2_Point2_Y3.Text = dataGridView_Cam2.Rows[21].Cells[2].Value.ToString();
        //    HTuple Point2_X1 = double.Parse(textBox_Cam2_Point2_X1.Text);
        //    HTuple Point2_Y1 = double.Parse(textBox_Cam2_Point2_Y1.Text);
        //    HTuple Point2_X2 = double.Parse(textBox_Cam2_Point2_X2.Text);
        //    HTuple Point2_Y2 = double.Parse(textBox_Cam2_Point2_Y2.Text);
        //    HTuple Point2_X3 = double.Parse(textBox_Cam2_Point2_X3.Text);
        //    HTuple Point2_Y3 = double.Parse(textBox_Cam2_Point2_Y3.Text);

        //    //Center_Point = CenterRotation(new RobotPoint() { X = Point2_X1.D, Y = Point2_Y1.D }, new RobotPoint() { X = Point2_X2.D, Y = Point2_Y2.D },

        //    //                                       new RobotPoint() { X = Point2_X3.D, Y = Point2_Y3.D });
        //    HTuple Robot_Point2_X1 = new HTuple(0.0);
        //    HTuple Robot_Point2_Y1 = new HTuple(0.0);
        //    HTuple Robot_Point2_X2 = new HTuple(0.0);
        //    HTuple Robot_Point2_Y2 = new HTuple(0.0);
        //    HTuple Robot_Point2_X3 = new HTuple(0.0);
        //    HTuple Robot_Point2_Y3 = new HTuple(0.0);
        //    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d2, Point2_X1, Point2_Y1, out Robot_Point2_X1, out Robot_Point2_Y1);
        //    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d2, Point2_X2, Point2_Y2, out Robot_Point2_X2, out Robot_Point2_Y3);
        //    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d2, Point2_X3, Point2_Y3, out Robot_Point2_X3, out Robot_Point2_Y2);

        //    Get_Cirrle_Center(new HTuple(Robot_Point2_X1, Robot_Point2_X2, Robot_Point2_X3), new HTuple(Robot_Point2_Y1, Robot_Point2_Y2, Robot_Point2_Y3), out CenterX, out CenterY, halconWindow1);


        //    textBox_Cam2_Center2_X.Text = CenterX.D.ToString("0.00000");
        //    textBox_Cam2_Center2_Y.Text = CenterY.D.ToString("0.00000");
        //}

        private void Cam1_1号吸嘴9点标定()
        {

            halconWindow1.Disp_Image(halconWindow1.Image);


            HTuple R = new HTuple(); HTuple C = new HTuple(); HTuple X = new HTuple(); HTuple Y = new HTuple();

            R[0] = Convert.ToDouble(dataGridView_Cam1.Rows[0].Cells[1].Value.ToString());
            C[0] = Convert.ToDouble(dataGridView_Cam1.Rows[0].Cells[2].Value.ToString());
            X[0] = Convert.ToDouble(dataGridView_Cam1.Rows[0].Cells[3].Value.ToString());
            Y[0] = Convert.ToDouble(dataGridView_Cam1.Rows[0].Cells[4].Value.ToString());

            R[1] = Convert.ToDouble(dataGridView_Cam1.Rows[5].Cells[1].Value.ToString());
            C[1] = Convert.ToDouble(dataGridView_Cam1.Rows[5].Cells[2].Value.ToString());
            X[1] = Convert.ToDouble(dataGridView_Cam1.Rows[5].Cells[3].Value.ToString());
            Y[1] = Convert.ToDouble(dataGridView_Cam1.Rows[5].Cells[4].Value.ToString());

            R[2] = Convert.ToDouble(dataGridView_Cam1.Rows[6].Cells[1].Value.ToString());
            C[2] = Convert.ToDouble(dataGridView_Cam1.Rows[6].Cells[2].Value.ToString());
            X[2] = Convert.ToDouble(dataGridView_Cam1.Rows[6].Cells[3].Value.ToString());
            Y[2] = Convert.ToDouble(dataGridView_Cam1.Rows[6].Cells[4].Value.ToString());

            R[3] = Convert.ToDouble(dataGridView_Cam1.Rows[7].Cells[1].Value.ToString());
            C[3] = Convert.ToDouble(dataGridView_Cam1.Rows[7].Cells[2].Value.ToString());
            X[3] = Convert.ToDouble(dataGridView_Cam1.Rows[7].Cells[3].Value.ToString());
            Y[3] = Convert.ToDouble(dataGridView_Cam1.Rows[7].Cells[4].Value.ToString());

            R[4] = Convert.ToDouble(dataGridView_Cam1.Rows[4].Cells[1].Value.ToString());
            C[4] = Convert.ToDouble(dataGridView_Cam1.Rows[4].Cells[2].Value.ToString());
            X[4] = Convert.ToDouble(dataGridView_Cam1.Rows[4].Cells[3].Value.ToString());
            Y[4] = Convert.ToDouble(dataGridView_Cam1.Rows[4].Cells[4].Value.ToString());

            R[5] = Convert.ToDouble(dataGridView_Cam1.Rows[1].Cells[1].Value.ToString());
            C[5] = Convert.ToDouble(dataGridView_Cam1.Rows[1].Cells[2].Value.ToString());
            X[5] = Convert.ToDouble(dataGridView_Cam1.Rows[1].Cells[3].Value.ToString());
            Y[5] = Convert.ToDouble(dataGridView_Cam1.Rows[1].Cells[4].Value.ToString());

            R[6] = Convert.ToDouble(dataGridView_Cam1.Rows[2].Cells[1].Value.ToString());
            C[6] = Convert.ToDouble(dataGridView_Cam1.Rows[2].Cells[2].Value.ToString());
            X[6] = Convert.ToDouble(dataGridView_Cam1.Rows[2].Cells[3].Value.ToString());
            Y[6] = Convert.ToDouble(dataGridView_Cam1.Rows[2].Cells[4].Value.ToString());

            R[7] = Convert.ToDouble(dataGridView_Cam1.Rows[3].Cells[1].Value.ToString());
            C[7] = Convert.ToDouble(dataGridView_Cam1.Rows[3].Cells[2].Value.ToString());
            X[7] = Convert.ToDouble(dataGridView_Cam1.Rows[3].Cells[3].Value.ToString());
            Y[7] = Convert.ToDouble(dataGridView_Cam1.Rows[3].Cells[4].Value.ToString());

            R[8] = Convert.ToDouble(dataGridView_Cam1.Rows[8].Cells[1].Value.ToString());
            C[8] = Convert.ToDouble(dataGridView_Cam1.Rows[8].Cells[2].Value.ToString());
            X[8] = Convert.ToDouble(dataGridView_Cam1.Rows[8].Cells[3].Value.ToString());
            Y[8] = Convert.ToDouble(dataGridView_Cam1.Rows[8].Cells[4].Value.ToString());


            halconWindow1.Disp_Cross(R, C, 150, 0, "blue");
            for (int i = 0; i < 9; i++)
            {
                halconWindow1.Disp_Message("" + i, 16, R[i], C[i], "green");
            }

            HOperatorSet.VectorToHomMat2d(R, C, Y, X, out CalibrationData.Instance.Cam1_HomMat2d1);
        }

        private void Cam1_1号吸嘴旋转标定()
        {
            HTuple CenterX = new HTuple(); HTuple CenterY = new HTuple();


            HTuple XS = new HTuple();
            HTuple YS = new HTuple();
            HTuple RS = new HTuple();
            HTuple CS = new HTuple();

            for (int i = 9; i < 22; i++)
            {


                HTuple Robot_Point1_X2, Robot_Point1_Y2;
                HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam1_HomMat2d1,
                    double.Parse(dataGridView_Cam1.Rows[i].Cells[1].Value.ToString()),
                    double.Parse(dataGridView_Cam1.Rows[i].Cells[2].Value.ToString()), out Robot_Point1_Y2, out Robot_Point1_X2);

                XS[i - 9] = Robot_Point1_X2.D;
                YS[i - 9] = Robot_Point1_Y2.D;
                RS[i - 9] = double.Parse(dataGridView_Cam1.Rows[i].Cells[1].Value.ToString());
                CS[i - 9] = double.Parse(dataGridView_Cam1.Rows[i].Cells[2].Value.ToString());



            }
            Get_Cirrle_Center(XS, YS, out CenterX, out CenterY, halconWindow1);
            Get_Cirrle_Center(RS, CS, out _, out _, halconWindow1);

            textBox_Cam1_Center1_X.Text = CenterX.D.ToString("0.00000");
            textBox_Cam1_Center1_Y.Text = CenterY.D.ToString("0.00000");


        }

        private void Cam1_2号吸嘴9点标定()
        {
            halconWindow1.Disp_Image(halconWindow1.Image);
            HTuple R = new HTuple(); HTuple C = new HTuple(); HTuple X = new HTuple(); HTuple Y = new HTuple();

            R[0] = Convert.ToDouble(dataGridView_Cam1.Rows[24].Cells[1].Value.ToString());
            C[0] = Convert.ToDouble(dataGridView_Cam1.Rows[24].Cells[2].Value.ToString());
            X[0] = Convert.ToDouble(dataGridView_Cam1.Rows[24].Cells[3].Value.ToString());
            Y[0] = Convert.ToDouble(dataGridView_Cam1.Rows[24].Cells[4].Value.ToString());

            R[1] = Convert.ToDouble(dataGridView_Cam1.Rows[29].Cells[1].Value.ToString());
            C[1] = Convert.ToDouble(dataGridView_Cam1.Rows[29].Cells[2].Value.ToString());
            X[1] = Convert.ToDouble(dataGridView_Cam1.Rows[29].Cells[3].Value.ToString());
            Y[1] = Convert.ToDouble(dataGridView_Cam1.Rows[29].Cells[4].Value.ToString());

            R[2] = Convert.ToDouble(dataGridView_Cam1.Rows[30].Cells[1].Value.ToString());
            C[2] = Convert.ToDouble(dataGridView_Cam1.Rows[30].Cells[2].Value.ToString());
            X[2] = Convert.ToDouble(dataGridView_Cam1.Rows[30].Cells[3].Value.ToString());
            Y[2] = Convert.ToDouble(dataGridView_Cam1.Rows[30].Cells[4].Value.ToString());

            R[3] = Convert.ToDouble(dataGridView_Cam1.Rows[31].Cells[1].Value.ToString());
            C[3] = Convert.ToDouble(dataGridView_Cam1.Rows[31].Cells[2].Value.ToString());
            X[3] = Convert.ToDouble(dataGridView_Cam1.Rows[31].Cells[3].Value.ToString());
            Y[3] = Convert.ToDouble(dataGridView_Cam1.Rows[31].Cells[4].Value.ToString());

            R[4] = Convert.ToDouble(dataGridView_Cam1.Rows[28].Cells[1].Value.ToString());
            C[4] = Convert.ToDouble(dataGridView_Cam1.Rows[28].Cells[2].Value.ToString());
            X[4] = Convert.ToDouble(dataGridView_Cam1.Rows[28].Cells[3].Value.ToString());
            Y[4] = Convert.ToDouble(dataGridView_Cam1.Rows[28].Cells[4].Value.ToString());

            R[5] = Convert.ToDouble(dataGridView_Cam1.Rows[25].Cells[1].Value.ToString());
            C[5] = Convert.ToDouble(dataGridView_Cam1.Rows[25].Cells[2].Value.ToString());
            X[5] = Convert.ToDouble(dataGridView_Cam1.Rows[25].Cells[3].Value.ToString());
            Y[5] = Convert.ToDouble(dataGridView_Cam1.Rows[25].Cells[4].Value.ToString());

            R[6] = Convert.ToDouble(dataGridView_Cam1.Rows[26].Cells[1].Value.ToString());
            C[6] = Convert.ToDouble(dataGridView_Cam1.Rows[26].Cells[2].Value.ToString());
            X[6] = Convert.ToDouble(dataGridView_Cam1.Rows[26].Cells[3].Value.ToString());
            Y[6] = Convert.ToDouble(dataGridView_Cam1.Rows[26].Cells[4].Value.ToString());

            R[7] = Convert.ToDouble(dataGridView_Cam1.Rows[27].Cells[1].Value.ToString());
            C[7] = Convert.ToDouble(dataGridView_Cam1.Rows[27].Cells[2].Value.ToString());
            X[7] = Convert.ToDouble(dataGridView_Cam1.Rows[27].Cells[3].Value.ToString());
            Y[7] = Convert.ToDouble(dataGridView_Cam1.Rows[27].Cells[4].Value.ToString());

            R[8] = Convert.ToDouble(dataGridView_Cam1.Rows[32].Cells[1].Value.ToString());
            C[8] = Convert.ToDouble(dataGridView_Cam1.Rows[32].Cells[2].Value.ToString());
            X[8] = Convert.ToDouble(dataGridView_Cam1.Rows[32].Cells[3].Value.ToString());
            Y[8] = Convert.ToDouble(dataGridView_Cam1.Rows[32].Cells[4].Value.ToString());

            halconWindow1.Disp_Cross(R, C, 150, 0, "blue");
            for (int i = 0; i < 9; i++)
            {
                halconWindow1.Disp_Message("" + i, 16, R[i], C[i], "green");
            }

            HOperatorSet.VectorToHomMat2d(R, C, Y, X, out CalibrationData.Instance.Cam1_HomMat2d2);
        }

        private void Cam1_2号吸嘴旋转标定()
        {
            HTuple CenterX = new HTuple(); HTuple CenterY = new HTuple();



            HTuple XS = new HTuple();
            HTuple YS = new HTuple();
            HTuple RS = new HTuple();
            HTuple CS = new HTuple();

            for (int i = 33; i < 48; i++)
            {
                HTuple Robot_Point1_X1, Robot_Point1_Y1;
                HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam1_HomMat2d2,
                    double.Parse(dataGridView_Cam1.Rows[i].Cells[1].Value.ToString()),
                    double.Parse(dataGridView_Cam1.Rows[i].Cells[2].Value.ToString()), out Robot_Point1_Y1, out Robot_Point1_X1);

                XS[i - 33] = Robot_Point1_X1.D;
                YS[i - 33] = Robot_Point1_Y1.D;
                RS[i - 33] = double.Parse(dataGridView_Cam1.Rows[i].Cells[1].Value.ToString());
                CS[i - 33] = double.Parse(dataGridView_Cam1.Rows[i].Cells[2].Value.ToString());



            }
            Get_Cirrle_Center(XS, YS, out CenterX, out CenterY, halconWindow1);
            Get_Cirrle_Center(RS, CS, out _, out _, halconWindow1);



            textBox_Cam1_Center2_X.Text = CenterX.D.ToString("0.00000");
            textBox_Cam1_Center2_Y.Text = CenterY.D.ToString("0.00000");

        }

        private void Cam2_1号吸嘴9点标定()
        {

            halconWindow1.Disp_Image(halconWindow1.Image);


            HTuple R = new HTuple(); HTuple C = new HTuple(); HTuple X = new HTuple(); HTuple Y = new HTuple();

            R[0] = Convert.ToDouble(dataGridView_Cam2.Rows[0].Cells[1].Value.ToString());
            C[0] = Convert.ToDouble(dataGridView_Cam2.Rows[0].Cells[2].Value.ToString());
            X[0] = Convert.ToDouble(dataGridView_Cam2.Rows[0].Cells[3].Value.ToString());
            Y[0] = Convert.ToDouble(dataGridView_Cam2.Rows[0].Cells[4].Value.ToString());

            R[1] = Convert.ToDouble(dataGridView_Cam2.Rows[5].Cells[1].Value.ToString());
            C[1] = Convert.ToDouble(dataGridView_Cam2.Rows[5].Cells[2].Value.ToString());
            X[1] = Convert.ToDouble(dataGridView_Cam2.Rows[5].Cells[3].Value.ToString());
            Y[1] = Convert.ToDouble(dataGridView_Cam2.Rows[5].Cells[4].Value.ToString());

            R[2] = Convert.ToDouble(dataGridView_Cam2.Rows[6].Cells[1].Value.ToString());
            C[2] = Convert.ToDouble(dataGridView_Cam2.Rows[6].Cells[2].Value.ToString());
            X[2] = Convert.ToDouble(dataGridView_Cam2.Rows[6].Cells[3].Value.ToString());
            Y[2] = Convert.ToDouble(dataGridView_Cam2.Rows[6].Cells[4].Value.ToString());

            R[3] = Convert.ToDouble(dataGridView_Cam2.Rows[7].Cells[1].Value.ToString());
            C[3] = Convert.ToDouble(dataGridView_Cam2.Rows[7].Cells[2].Value.ToString());
            X[3] = Convert.ToDouble(dataGridView_Cam2.Rows[7].Cells[3].Value.ToString());
            Y[3] = Convert.ToDouble(dataGridView_Cam2.Rows[7].Cells[4].Value.ToString());

            R[4] = Convert.ToDouble(dataGridView_Cam2.Rows[4].Cells[1].Value.ToString());
            C[4] = Convert.ToDouble(dataGridView_Cam2.Rows[4].Cells[2].Value.ToString());
            X[4] = Convert.ToDouble(dataGridView_Cam2.Rows[4].Cells[3].Value.ToString());
            Y[4] = Convert.ToDouble(dataGridView_Cam2.Rows[4].Cells[4].Value.ToString());

            R[5] = Convert.ToDouble(dataGridView_Cam2.Rows[1].Cells[1].Value.ToString());
            C[5] = Convert.ToDouble(dataGridView_Cam2.Rows[1].Cells[2].Value.ToString());
            X[5] = Convert.ToDouble(dataGridView_Cam2.Rows[1].Cells[3].Value.ToString());
            Y[5] = Convert.ToDouble(dataGridView_Cam2.Rows[1].Cells[4].Value.ToString());

            R[6] = Convert.ToDouble(dataGridView_Cam2.Rows[2].Cells[1].Value.ToString());
            C[6] = Convert.ToDouble(dataGridView_Cam2.Rows[2].Cells[2].Value.ToString());
            X[6] = Convert.ToDouble(dataGridView_Cam2.Rows[2].Cells[3].Value.ToString());
            Y[6] = Convert.ToDouble(dataGridView_Cam2.Rows[2].Cells[4].Value.ToString());

            R[7] = Convert.ToDouble(dataGridView_Cam2.Rows[3].Cells[1].Value.ToString());
            C[7] = Convert.ToDouble(dataGridView_Cam2.Rows[3].Cells[2].Value.ToString());
            X[7] = Convert.ToDouble(dataGridView_Cam2.Rows[3].Cells[3].Value.ToString());
            Y[7] = Convert.ToDouble(dataGridView_Cam2.Rows[3].Cells[4].Value.ToString());

            R[8] = Convert.ToDouble(dataGridView_Cam2.Rows[8].Cells[1].Value.ToString());
            C[8] = Convert.ToDouble(dataGridView_Cam2.Rows[8].Cells[2].Value.ToString());
            X[8] = Convert.ToDouble(dataGridView_Cam2.Rows[8].Cells[3].Value.ToString());
            Y[8] = Convert.ToDouble(dataGridView_Cam2.Rows[8].Cells[4].Value.ToString());


            halconWindow1.Disp_Cross(R, C, 150, 0, "blue");
            for (int i = 0; i < 9; i++)
            {
                halconWindow1.Disp_Message("" + i, 16, R[i], C[i], "green");
            }

            HOperatorSet.VectorToHomMat2d(R, C, Y, X, out CalibrationData.Instance.Cam2_HomMat2d1);
        }

        private void Cam2_1号吸嘴旋转标定()
        {
            HTuple CenterX = new HTuple(); HTuple CenterY = new HTuple();


            HTuple XS = new HTuple();
            HTuple YS = new HTuple();
            HTuple RS = new HTuple();
            HTuple CS = new HTuple();

            for (int i = 9; i < 22; i++)
            {


                HTuple Robot_Point1_X2, Robot_Point1_Y2;
                HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d1,
                    double.Parse(dataGridView_Cam2.Rows[i].Cells[1].Value.ToString()),
                    double.Parse(dataGridView_Cam2.Rows[i].Cells[2].Value.ToString()), out Robot_Point1_Y2, out Robot_Point1_X2);

                XS[i - 9] = Robot_Point1_X2.D;
                YS[i - 9] = Robot_Point1_Y2.D;
                RS[i - 9] = double.Parse(dataGridView_Cam2.Rows[i].Cells[1].Value.ToString());
                CS[i - 9] = double.Parse(dataGridView_Cam2.Rows[i].Cells[2].Value.ToString());



            }
            Get_Cirrle_Center(XS, YS, out CenterX, out CenterY, halconWindow1);
            Get_Cirrle_Center(RS, CS, out _, out _, halconWindow1);

            textBox_Cam2_Center1_X.Text = CenterX.D.ToString("0.00000");
            textBox_Cam2_Center1_Y.Text = CenterY.D.ToString("0.00000");


        }

        private void Cam2_2号吸嘴9点标定()
        {
            halconWindow1.Disp_Image(halconWindow1.Image);
            HTuple R = new HTuple(); HTuple C = new HTuple(); HTuple X = new HTuple(); HTuple Y = new HTuple();

            R[0] = Convert.ToDouble(dataGridView_Cam2.Rows[24].Cells[1].Value.ToString());
            C[0] = Convert.ToDouble(dataGridView_Cam2.Rows[24].Cells[2].Value.ToString());
            X[0] = Convert.ToDouble(dataGridView_Cam2.Rows[24].Cells[3].Value.ToString());
            Y[0] = Convert.ToDouble(dataGridView_Cam2.Rows[24].Cells[4].Value.ToString());

            R[1] = Convert.ToDouble(dataGridView_Cam2.Rows[29].Cells[1].Value.ToString());
            C[1] = Convert.ToDouble(dataGridView_Cam2.Rows[29].Cells[2].Value.ToString());
            X[1] = Convert.ToDouble(dataGridView_Cam2.Rows[29].Cells[3].Value.ToString());
            Y[1] = Convert.ToDouble(dataGridView_Cam2.Rows[29].Cells[4].Value.ToString());

            R[2] = Convert.ToDouble(dataGridView_Cam2.Rows[30].Cells[1].Value.ToString());
            C[2] = Convert.ToDouble(dataGridView_Cam2.Rows[30].Cells[2].Value.ToString());
            X[2] = Convert.ToDouble(dataGridView_Cam2.Rows[30].Cells[3].Value.ToString());
            Y[2] = Convert.ToDouble(dataGridView_Cam2.Rows[30].Cells[4].Value.ToString());

            R[3] = Convert.ToDouble(dataGridView_Cam2.Rows[31].Cells[1].Value.ToString());
            C[3] = Convert.ToDouble(dataGridView_Cam2.Rows[31].Cells[2].Value.ToString());
            X[3] = Convert.ToDouble(dataGridView_Cam2.Rows[31].Cells[3].Value.ToString());
            Y[3] = Convert.ToDouble(dataGridView_Cam2.Rows[31].Cells[4].Value.ToString());

            R[4] = Convert.ToDouble(dataGridView_Cam2.Rows[28].Cells[1].Value.ToString());
            C[4] = Convert.ToDouble(dataGridView_Cam2.Rows[28].Cells[2].Value.ToString());
            X[4] = Convert.ToDouble(dataGridView_Cam2.Rows[28].Cells[3].Value.ToString());
            Y[4] = Convert.ToDouble(dataGridView_Cam2.Rows[28].Cells[4].Value.ToString());

            R[5] = Convert.ToDouble(dataGridView_Cam2.Rows[25].Cells[1].Value.ToString());
            C[5] = Convert.ToDouble(dataGridView_Cam2.Rows[25].Cells[2].Value.ToString());
            X[5] = Convert.ToDouble(dataGridView_Cam2.Rows[25].Cells[3].Value.ToString());
            Y[5] = Convert.ToDouble(dataGridView_Cam2.Rows[25].Cells[4].Value.ToString());

            R[6] = Convert.ToDouble(dataGridView_Cam2.Rows[26].Cells[1].Value.ToString());
            C[6] = Convert.ToDouble(dataGridView_Cam2.Rows[26].Cells[2].Value.ToString());
            X[6] = Convert.ToDouble(dataGridView_Cam2.Rows[26].Cells[3].Value.ToString());
            Y[6] = Convert.ToDouble(dataGridView_Cam2.Rows[26].Cells[4].Value.ToString());

            R[7] = Convert.ToDouble(dataGridView_Cam2.Rows[27].Cells[1].Value.ToString());
            C[7] = Convert.ToDouble(dataGridView_Cam2.Rows[27].Cells[2].Value.ToString());
            X[7] = Convert.ToDouble(dataGridView_Cam2.Rows[27].Cells[3].Value.ToString());
            Y[7] = Convert.ToDouble(dataGridView_Cam2.Rows[27].Cells[4].Value.ToString());

            R[8] = Convert.ToDouble(dataGridView_Cam2.Rows[32].Cells[1].Value.ToString());
            C[8] = Convert.ToDouble(dataGridView_Cam2.Rows[32].Cells[2].Value.ToString());
            X[8] = Convert.ToDouble(dataGridView_Cam2.Rows[32].Cells[3].Value.ToString());
            Y[8] = Convert.ToDouble(dataGridView_Cam2.Rows[32].Cells[4].Value.ToString());

            halconWindow1.Disp_Cross(R, C, 150, 0, "blue");
            for (int i = 0; i < 9; i++)
            {
                halconWindow1.Disp_Message("" + i, 16, R[i], C[i], "green");
            }

            HOperatorSet.VectorToHomMat2d(R, C, Y, X, out CalibrationData.Instance.Cam2_HomMat2d2);
        }

        private void Cam2_2号吸嘴旋转标定()
        {
            HTuple CenterX = new HTuple(); HTuple CenterY = new HTuple();



            HTuple XS = new HTuple();
            HTuple YS = new HTuple();
            HTuple RS = new HTuple();
            HTuple CS = new HTuple();

            for (int i = 33; i < 48; i++)
            {
                HTuple Robot_Point1_X1, Robot_Point1_Y1;
                HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d2,
                    double.Parse(dataGridView_Cam2.Rows[i].Cells[1].Value.ToString()),
                    double.Parse(dataGridView_Cam2.Rows[i].Cells[2].Value.ToString()), out Robot_Point1_Y1, out Robot_Point1_X1);

                XS[i - 33] = Robot_Point1_X1.D;
                YS[i - 33] = Robot_Point1_Y1.D;
                RS[i - 33] = double.Parse(dataGridView_Cam2.Rows[i].Cells[1].Value.ToString());
                CS[i - 33] = double.Parse(dataGridView_Cam2.Rows[i].Cells[2].Value.ToString());



            }
            Get_Cirrle_Center(XS, YS, out CenterX, out CenterY, halconWindow1);
            Get_Cirrle_Center(RS, CS, out _, out _, halconWindow1);



            textBox_Cam2_Center2_X.Text = CenterX.D.ToString("0.00000");
            textBox_Cam2_Center2_Y.Text = CenterY.D.ToString("0.00000");

        }

        private void Cam3_1号吸嘴9点标定()
        {

            halconWindow1.Disp_Image(halconWindow1.Image);


            HTuple R = new HTuple(); HTuple C = new HTuple(); HTuple X = new HTuple(); HTuple Y = new HTuple();

            R[0] = Convert.ToDouble(dataGridView_Cam3.Rows[0].Cells[1].Value.ToString());
            C[0] = Convert.ToDouble(dataGridView_Cam3.Rows[0].Cells[2].Value.ToString());
            X[0] = Convert.ToDouble(dataGridView_Cam3.Rows[0].Cells[3].Value.ToString());
            Y[0] = Convert.ToDouble(dataGridView_Cam3.Rows[0].Cells[4].Value.ToString());

            R[1] = Convert.ToDouble(dataGridView_Cam3.Rows[5].Cells[1].Value.ToString());
            C[1] = Convert.ToDouble(dataGridView_Cam3.Rows[5].Cells[2].Value.ToString());
            X[1] = Convert.ToDouble(dataGridView_Cam3.Rows[5].Cells[3].Value.ToString());
            Y[1] = Convert.ToDouble(dataGridView_Cam3.Rows[5].Cells[4].Value.ToString());

            R[2] = Convert.ToDouble(dataGridView_Cam3.Rows[6].Cells[1].Value.ToString());
            C[2] = Convert.ToDouble(dataGridView_Cam3.Rows[6].Cells[2].Value.ToString());
            X[2] = Convert.ToDouble(dataGridView_Cam3.Rows[6].Cells[3].Value.ToString());
            Y[2] = Convert.ToDouble(dataGridView_Cam3.Rows[6].Cells[4].Value.ToString());

            R[3] = Convert.ToDouble(dataGridView_Cam3.Rows[7].Cells[1].Value.ToString());
            C[3] = Convert.ToDouble(dataGridView_Cam3.Rows[7].Cells[2].Value.ToString());
            X[3] = Convert.ToDouble(dataGridView_Cam3.Rows[7].Cells[3].Value.ToString());
            Y[3] = Convert.ToDouble(dataGridView_Cam3.Rows[7].Cells[4].Value.ToString());

            R[4] = Convert.ToDouble(dataGridView_Cam3.Rows[4].Cells[1].Value.ToString());
            C[4] = Convert.ToDouble(dataGridView_Cam3.Rows[4].Cells[2].Value.ToString());
            X[4] = Convert.ToDouble(dataGridView_Cam3.Rows[4].Cells[3].Value.ToString());
            Y[4] = Convert.ToDouble(dataGridView_Cam3.Rows[4].Cells[4].Value.ToString());

            R[5] = Convert.ToDouble(dataGridView_Cam3.Rows[1].Cells[1].Value.ToString());
            C[5] = Convert.ToDouble(dataGridView_Cam3.Rows[1].Cells[2].Value.ToString());
            X[5] = Convert.ToDouble(dataGridView_Cam3.Rows[1].Cells[3].Value.ToString());
            Y[5] = Convert.ToDouble(dataGridView_Cam3.Rows[1].Cells[4].Value.ToString());

            R[6] = Convert.ToDouble(dataGridView_Cam3.Rows[2].Cells[1].Value.ToString());
            C[6] = Convert.ToDouble(dataGridView_Cam3.Rows[2].Cells[2].Value.ToString());
            X[6] = Convert.ToDouble(dataGridView_Cam3.Rows[2].Cells[3].Value.ToString());
            Y[6] = Convert.ToDouble(dataGridView_Cam3.Rows[2].Cells[4].Value.ToString());

            R[7] = Convert.ToDouble(dataGridView_Cam3.Rows[3].Cells[1].Value.ToString());
            C[7] = Convert.ToDouble(dataGridView_Cam3.Rows[3].Cells[2].Value.ToString());
            X[7] = Convert.ToDouble(dataGridView_Cam3.Rows[3].Cells[3].Value.ToString());
            Y[7] = Convert.ToDouble(dataGridView_Cam3.Rows[3].Cells[4].Value.ToString());

            R[8] = Convert.ToDouble(dataGridView_Cam3.Rows[8].Cells[1].Value.ToString());
            C[8] = Convert.ToDouble(dataGridView_Cam3.Rows[8].Cells[2].Value.ToString());
            X[8] = Convert.ToDouble(dataGridView_Cam3.Rows[8].Cells[3].Value.ToString());
            Y[8] = Convert.ToDouble(dataGridView_Cam3.Rows[8].Cells[4].Value.ToString());


            halconWindow1.Disp_Cross(R, C, 150, 0, "blue");
            for (int i = 0; i < 9; i++)
            {
                halconWindow1.Disp_Message("" + i, 16, R[i], C[i], "green");
            }

            HOperatorSet.VectorToHomMat2d(R, C, Y, X, out CalibrationData.Instance.Cam3_HomMat2d1);
        }

        private void Cam3_1号吸嘴旋转标定()
        {
            HTuple CenterX = new HTuple(); HTuple CenterY = new HTuple();


            HTuple XS = new HTuple();
            HTuple YS = new HTuple();
            HTuple RS = new HTuple();
            HTuple CS = new HTuple();

            for (int i = 9; i < 22; i++)
            {


                HTuple Robot_Point1_X2, Robot_Point1_Y2;
                HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam3_HomMat2d1,
                    double.Parse(dataGridView_Cam3.Rows[i].Cells[1].Value.ToString()),
                    double.Parse(dataGridView_Cam3.Rows[i].Cells[2].Value.ToString()), out Robot_Point1_Y2, out Robot_Point1_X2);

                XS[i - 9] = Robot_Point1_X2.D;
                YS[i - 9] = Robot_Point1_Y2.D;
                RS[i - 9] = double.Parse(dataGridView_Cam3.Rows[i].Cells[1].Value.ToString());
                CS[i - 9] = double.Parse(dataGridView_Cam3.Rows[i].Cells[2].Value.ToString());



            }
            Get_Cirrle_Center(XS, YS, out CenterX, out CenterY, halconWindow1);
            Get_Cirrle_Center(RS, CS, out _, out _, halconWindow1);

            textBox_Cam3_Center1_X.Text = CenterX.D.ToString("0.00000");
            textBox_Cam3_Center1_Y.Text = CenterY.D.ToString("0.00000");


        }

        private void Cam3_2号吸嘴9点标定()
        {
            halconWindow1.Disp_Image(halconWindow1.Image);
            HTuple R = new HTuple(); HTuple C = new HTuple(); HTuple X = new HTuple(); HTuple Y = new HTuple();

            R[0] = Convert.ToDouble(dataGridView_Cam3.Rows[24].Cells[1].Value.ToString());
            C[0] = Convert.ToDouble(dataGridView_Cam3.Rows[24].Cells[2].Value.ToString());
            X[0] = Convert.ToDouble(dataGridView_Cam3.Rows[24].Cells[3].Value.ToString());
            Y[0] = Convert.ToDouble(dataGridView_Cam3.Rows[24].Cells[4].Value.ToString());

            R[1] = Convert.ToDouble(dataGridView_Cam3.Rows[29].Cells[1].Value.ToString());
            C[1] = Convert.ToDouble(dataGridView_Cam3.Rows[29].Cells[2].Value.ToString());
            X[1] = Convert.ToDouble(dataGridView_Cam3.Rows[29].Cells[3].Value.ToString());
            Y[1] = Convert.ToDouble(dataGridView_Cam3.Rows[29].Cells[4].Value.ToString());

            R[2] = Convert.ToDouble(dataGridView_Cam3.Rows[30].Cells[1].Value.ToString());
            C[2] = Convert.ToDouble(dataGridView_Cam3.Rows[30].Cells[2].Value.ToString());
            X[2] = Convert.ToDouble(dataGridView_Cam3.Rows[30].Cells[3].Value.ToString());
            Y[2] = Convert.ToDouble(dataGridView_Cam3.Rows[30].Cells[4].Value.ToString());

            R[3] = Convert.ToDouble(dataGridView_Cam3.Rows[31].Cells[1].Value.ToString());
            C[3] = Convert.ToDouble(dataGridView_Cam3.Rows[31].Cells[2].Value.ToString());
            X[3] = Convert.ToDouble(dataGridView_Cam3.Rows[31].Cells[3].Value.ToString());
            Y[3] = Convert.ToDouble(dataGridView_Cam3.Rows[31].Cells[4].Value.ToString());

            R[4] = Convert.ToDouble(dataGridView_Cam3.Rows[28].Cells[1].Value.ToString());
            C[4] = Convert.ToDouble(dataGridView_Cam3.Rows[28].Cells[2].Value.ToString());
            X[4] = Convert.ToDouble(dataGridView_Cam3.Rows[28].Cells[3].Value.ToString());
            Y[4] = Convert.ToDouble(dataGridView_Cam3.Rows[28].Cells[4].Value.ToString());

            R[5] = Convert.ToDouble(dataGridView_Cam3.Rows[25].Cells[1].Value.ToString());
            C[5] = Convert.ToDouble(dataGridView_Cam3.Rows[25].Cells[2].Value.ToString());
            X[5] = Convert.ToDouble(dataGridView_Cam3.Rows[25].Cells[3].Value.ToString());
            Y[5] = Convert.ToDouble(dataGridView_Cam3.Rows[25].Cells[4].Value.ToString());

            R[6] = Convert.ToDouble(dataGridView_Cam3.Rows[26].Cells[1].Value.ToString());
            C[6] = Convert.ToDouble(dataGridView_Cam3.Rows[26].Cells[2].Value.ToString());
            X[6] = Convert.ToDouble(dataGridView_Cam3.Rows[26].Cells[3].Value.ToString());
            Y[6] = Convert.ToDouble(dataGridView_Cam3.Rows[26].Cells[4].Value.ToString());

            R[7] = Convert.ToDouble(dataGridView_Cam3.Rows[27].Cells[1].Value.ToString());
            C[7] = Convert.ToDouble(dataGridView_Cam3.Rows[27].Cells[2].Value.ToString());
            X[7] = Convert.ToDouble(dataGridView_Cam3.Rows[27].Cells[3].Value.ToString());
            Y[7] = Convert.ToDouble(dataGridView_Cam3.Rows[27].Cells[4].Value.ToString());

            R[8] = Convert.ToDouble(dataGridView_Cam3.Rows[32].Cells[1].Value.ToString());
            C[8] = Convert.ToDouble(dataGridView_Cam3.Rows[32].Cells[2].Value.ToString());
            X[8] = Convert.ToDouble(dataGridView_Cam3.Rows[32].Cells[3].Value.ToString());
            Y[8] = Convert.ToDouble(dataGridView_Cam3.Rows[32].Cells[4].Value.ToString());

            halconWindow1.Disp_Cross(R, C, 150, 0, "blue");
            for (int i = 0; i < 9; i++)
            {
                halconWindow1.Disp_Message("" + i, 16, R[i], C[i], "green");
            }

            HOperatorSet.VectorToHomMat2d(R, C, Y, X, out CalibrationData.Instance.Cam3_HomMat2d2);
        }

        private void Cam3_2号吸嘴旋转标定()
        {
            HTuple CenterX = new HTuple(); HTuple CenterY = new HTuple();



            HTuple XS = new HTuple();
            HTuple YS = new HTuple();
            HTuple RS = new HTuple();
            HTuple CS = new HTuple();

            for (int i = 33; i < 48; i++)
            {
                HTuple Robot_Point1_X1, Robot_Point1_Y1;
                HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam3_HomMat2d2,
                    double.Parse(dataGridView_Cam3.Rows[i].Cells[1].Value.ToString()),
                    double.Parse(dataGridView_Cam3.Rows[i].Cells[2].Value.ToString()), out Robot_Point1_Y1, out Robot_Point1_X1);

                XS[i - 33] = Robot_Point1_X1.D;
                YS[i - 33] = Robot_Point1_Y1.D;
                RS[i - 33] = double.Parse(dataGridView_Cam3.Rows[i].Cells[1].Value.ToString());
                CS[i - 33] = double.Parse(dataGridView_Cam3.Rows[i].Cells[2].Value.ToString());



            }
            Get_Cirrle_Center(XS, YS, out CenterX, out CenterY, halconWindow1);
            Get_Cirrle_Center(RS, CS, out _, out _, halconWindow1);



            textBox_Cam3_Center2_X.Text = CenterX.D.ToString("0.00000");
            textBox_Cam3_Center2_Y.Text = CenterY.D.ToString("0.00000");

        }
        /// <summary>
        /// 相机1 9点标定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button9_Click(object sender, EventArgs e)
        {
            if (dataGridView_Cam1.Rows.Count <= 8)
            {
                ShowWarn("数据不够,无法标定");
                return;
            }
            Cam1_1号吸嘴9点标定();
        }

        /// <summary>
        /// 相机2  9点标定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button8_Click(object sender, EventArgs e)
        {
            if (dataGridView_Cam2.Rows.Count <= 8)
            {
                ShowWarn("数据不够,无法标定");
                return;
            }
            Cam2_1号吸嘴9点标定();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(halconWindow1.Image);

            Cam3_1号吸嘴9点标定();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(halconWindow1.Image);
            Cam1_1号吸嘴旋转标定();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(halconWindow1.Image);
            Cam1_2号吸嘴旋转标定();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(halconWindow1.Image);
            Cam2_1号吸嘴旋转标定();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(halconWindow1.Image);
            Cam2_2号吸嘴旋转标定();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(halconWindow1.Image);
            Cam3_1号吸嘴旋转标定();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(halconWindow1.Image);
            Cam3_2号吸嘴旋转标定();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SaveData();
            AppParam.Instance.Save_To_File();
            //标定数据保存
            Serialization.Save(CalibrationData.Instance, "CalibrationData");
            ShowNormal("保存成功");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Rectangle1 rectangle1 = halconWindow1.Draw_Rectangle1("blue");
                HObject ho_ImageReduced;
                HOperatorSet.GenEmptyObj(out ho_ImageReduced);
                ho_ImageReduced.Dispose();
                HOperatorSet.ReduceDomain(halconWindow1.Image, rectangle1.rectangle1, out ho_ImageReduced);
                HOperatorSet.CreateShapeModel(ho_ImageReduced, "auto", new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), "auto", "auto", "use_polarity", "auto", "auto", out CalibrationData.Instance.Cam1_hv_ModelID);
                // HOperatorSet.CreateNccModel(ho_ImageReduced, "auto", new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), "auto", "use_polarity",        out CalibrationData.Instance.Cam1_hv_ModelID);
                ShowNormal("创建成功");
            }
            catch (Exception)
            {
                ShowError("创建失败");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                Rectangle1 rectangle1 = halconWindow1.Draw_Rectangle1("blue");
                HObject ho_ImageReduced;
                HOperatorSet.GenEmptyObj(out ho_ImageReduced);
                ho_ImageReduced.Dispose();
                HOperatorSet.ReduceDomain(halconWindow1.Image, rectangle1.rectangle1, out ho_ImageReduced);
                HOperatorSet.CreateShapeModel(ho_ImageReduced, "auto", new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), "auto", "auto", "use_polarity", "auto", "auto", out CalibrationData.Instance.Cam3_hv_ModelID);
                ShowNormal("创建成功");
            }
            catch (Exception)
            {
                ShowError("创建失败");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                Rectangle1 rectangle1 = halconWindow1.Draw_Rectangle1("blue");
                HObject ho_ImageReduced;
                HOperatorSet.GenEmptyObj(out ho_ImageReduced);
                ho_ImageReduced.Dispose();
                HOperatorSet.ReduceDomain(halconWindow1.Image, rectangle1.rectangle1, out ho_ImageReduced);
                HOperatorSet.CreateShapeModel(ho_ImageReduced, "auto", new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), "auto", "auto", "use_polarity", "auto", "auto", out CalibrationData.Instance.Cam2_hv_ModelID);
                ShowNormal("创建成功");
            }
            catch (Exception)
            {
                ShowError("创建失败");
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void Form_Robot_Calibration_Activated(object sender, EventArgs e)
        {
            AppParam.Instance.Robot_Calibration_State = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            new Form_Angle_Calibration().ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {

            if (dataGridView_Cam2.Rows.Count <= 19)
            {
                ShowWarn("数据不够,无法标定");
                return;
            }
            Cam2_2号吸嘴9点标定();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (dataGridView_Cam1.Rows.Count <= 19)
            {
                ShowWarn("数据不够,无法标定");
                return;
            }
            Cam1_2号吸嘴9点标定();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (dataGridView_Cam3.Rows.Count <= 19)
            {
                ShowWarn("数据不够,无法标定");
                return;
            }
            Cam3_2号吸嘴9点标定();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //dataGridView_Cam1.Rows.Clear();
            //dataGridView_Cam2.Rows.Clear();
            //dataGridView_Cam3.Rows.Clear();
            Form_Robot_Calibration_Load(sender, e);
        }
    }
}