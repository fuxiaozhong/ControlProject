using System;
using System.Threading;
using HalconDotNet;
using HYProject.MenuForm;
using HYProject.Plugin;
using HYProject.ToolForm;

namespace HYProject.Model
{
    public class Cam2_Work
    {
        public static void Cam2_Work_Method(HalconDotNet.HObject ho_image)
        {



            bool result = false;
            double X = 0.000;
            double Y = 0.000;
            double U = 0.000;
            try
            {


                if (Work.Cam2_Calibration_Mode)
                {
                    Cam2_Calibration(ho_image);
                    return;
                }



                //1号吸嘴定位
                if (Work.Cam2_Suction_Nozzle_Number == 1)
                {
                    DisplayForm.Instance[1].Disp_Image(ho_image);
                    DisplayForm.Instance[1].Disp_Message("相机2 1号吸嘴", 16, 10, 10, "blue");

                    HTuple Center_Row;
                    HTuple Center_Column;
                    HTuple Angle;

                    result = Work.Find_Point(ho_image, DisplayForm.Instance[1], "相机2", "1", out Center_Row, out Center_Column, out Angle);

                    if (result)
                    {
                        Log.WriteRunLog("定位成功：[" + Center_Row.D.ToString("0.00000") + "," + Center_Column.D.ToString("0.00000") + "," + Angle.D.ToString("0.00000") + "]");


                        HTuple robot_x = new HTuple(0.0);
                        HTuple robot_y = new HTuple(0.0);
                        double robot_Rotate_X = 0, robot_Rotate_Y = 0;
                        ////最后发送给机器人或者执行机构的偏移值为：x0 - refPos_x，y0 - refPos_y，a
                        HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d1, Center_Row, Center_Column, out robot_y, out robot_x);
                        ////最后发送给机器人或者执行机构的偏移值为：x0 - refPos_x，y0 - refPos_y，a
                        double 补偿U = Angle.D - StandardPar.Instance.Cam2_Standar_Point1.U;
                        double offsetU = StandardPar.Instance.Cam2_Standar_Point1.U - Angle.D;

                        Work.RotateAngle(CalibrationData.Instance.Cam2_Rotate_Center1_Point.X, CalibrationData.Instance.Cam2_Rotate_Center1_Point.Y,
                            offsetU,
                            robot_x.D, robot_y.D,
                            ref robot_Rotate_X, ref robot_Rotate_Y);


                        // HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam3_HomMat2d1, new HTuple(Rotate_X), new HTuple(Rotate_Y), out robot_x, out robot_y);


                        // xy补偿  //产品定位点到拍照位置的偏差（假设拍照点就是基准点）
                        double offsetX = StandardPar.Instance.Cam2_Standar_Point1.X - robot_Rotate_X;
                        double offsetY = StandardPar.Instance.Cam2_Standar_Point1.Y - robot_Rotate_Y;


                        Log.WriteRunLog("Cam2-1 补偿：" + "X:" + offsetX + "Y:" + offsetY + "U:" + 补偿U);
                        DisplayForm.Instance[1].Disp_Message("X:" + offsetX.ToString("0.00000") + "\nY:" + offsetY.ToString("0.00000") + "\nR:" + 补偿U.ToString("0.00000"), 16, 10, 10, result ? "green" : "red");


                        X = CalibrationData.Instance.Cam2_Standard1_Point.X + offsetX + Offset.Instance.Cam2_OffsetX1;
                        Y = CalibrationData.Instance.Cam2_Standard1_Point.Y + offsetY + Offset.Instance.Cam2_OffsetY1;
                        U = CalibrationData.Instance.Cam2_Standard1_Point.U + 补偿U + Offset.Instance.Cam2_OffsetR1;
                        DisplayForm.Instance[1].Disp_Message("X:" + X.ToString("0.00000") + "\nY:" + Y.ToString("0.00000") + "\nR:" + U.ToString("0.00000"), 16, 1000, 10, result ? "green" : "red");

                    }
                    else
                    {
                        Log.WriteErrorLog("定位失败：[" + Center_Row.D.ToString("0.00000") + "," + Center_Column.D.ToString("0.00000") + "," + Angle.D.ToString("0.00000") + "]");
                    }

                    AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&OBG,1,1," + (result ? "1" : "0") + "," + X.ToString("0.00000") + "," + Y.ToString("0.00000") + "," + U.ToString("0.00000"));
                    Log.WriteRunLog("Cam2-1 贴合位：X:" + X.ToString("0.00000") + "Y:" + Y.ToString("0.00000") + "R:" + U.ToString("0.00000"));
                    Work.SaveImage("相机2", "1号吸嘴", result, DisplayForm.Instance[1]);
                    if (result)
                    {
                        Cam2_OK1 = 1;
                    }
                    else
                    {
                        Cam2_NG1 = 1;
                    }
                }
                //2号吸嘴定位
                else if (Work.Cam2_Suction_Nozzle_Number == 2)
                {
                    DisplayForm.Instance[4].Disp_Image(ho_image);
                    DisplayForm.Instance[4].Disp_Message("相机2 2号吸嘴", 16, 10, 10, "blue");

                    HTuple Center_Row;
                    HTuple Center_Column;
                    HTuple Angle;

                    result = Work.Find_Point(ho_image, DisplayForm.Instance[4], "相机2", "2", out Center_Row, out Center_Column, out Angle);

                    if (result)
                    {
                        Log.WriteRunLog("定位成功：[" + Center_Row.D.ToString("0.00000") + "," + Center_Column.D.ToString("0.00000") + "," + Angle.D.ToString("0.00000") + "]");

                        HTuple robot_x = new HTuple(0.0);
                        HTuple robot_y = new HTuple(0.0);
                        double robot_Rotate_X = 0, robot_Rotate_Y = 0;
                        ////最后发送给机器人或者执行机构的偏移值为：x0 - refPos_x，y0 - refPos_y，a
                        HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d2, Center_Row, Center_Column, out robot_y, out robot_x);
                        ////最后发送给机器人或者执行机构的偏移值为：x0 - refPos_x，y0 - refPos_y，a
                        double 补偿U = Angle.D - StandardPar.Instance.Cam2_Standar_Point2.U;
                        double offsetU = StandardPar.Instance.Cam2_Standar_Point2.U - Angle.D;

                        Work.RotateAngle(CalibrationData.Instance.Cam2_Rotate_Center2_Point.X, CalibrationData.Instance.Cam2_Rotate_Center2_Point.Y,
                            offsetU,
                            robot_x.D, robot_y.D,
                            ref robot_Rotate_X, ref robot_Rotate_Y);


                        // HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam3_HomMat2d1, new HTuple(Rotate_X), new HTuple(Rotate_Y), out robot_x, out robot_y);


                        // xy补偿  //产品定位点到拍照位置的偏差（假设拍照点就是基准点）
                        double offsetX = StandardPar.Instance.Cam2_Standar_Point2.X - robot_Rotate_X;
                        double offsetY = StandardPar.Instance.Cam2_Standar_Point2.Y - robot_Rotate_Y;


                        Log.WriteRunLog("Cam3-1 补偿：" + "X:" + offsetX + "Y:" + offsetY + "U:" + 补偿U);
                        DisplayForm.Instance[4].Disp_Message("X:" + offsetX.ToString("0.00000") + "\nY:" + offsetY.ToString("0.00000") + "\nR:" + 补偿U.ToString("0.00000"), 16, 10, 10, result ? "green" : "red");


                        X = CalibrationData.Instance.Cam2_Standard2_Point.X + offsetX + Offset.Instance.Cam2_OffsetX2;
                        Y = CalibrationData.Instance.Cam2_Standard2_Point.Y + offsetY + Offset.Instance.Cam2_OffsetY2;
                        U = CalibrationData.Instance.Cam2_Standard2_Point.U + 补偿U + Offset.Instance.Cam2_OffsetR2;

                        DisplayForm.Instance[4].Disp_Message("X:" + X.ToString("0.00000") + "\nY:" + Y.ToString("0.00000") + "\nR:" + U.ToString("0.00000"), 16, 1000, 10, result ? "green" : "red");

                    }
                    else
                    {
                        Log.WriteErrorLog("定位失败：[" + Center_Row.D.ToString("0.00000") + "," + Center_Column.D.ToString("0.00000") + "," + Angle.D.ToString("0.00000") + "]");
                    }

                    AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&OBG,1,2," + (result ? "1" : "0") + "," + X.ToString("0.00000") + "," + Y.ToString("0.00000") + "," + U.ToString("0.00000"));
                    Log.WriteRunLog("Cam2-1 发送指令：&OBG,1,2," + (result ? "1" : "0") + "," + X.ToString("0.00000") + "," + Y.ToString("0.00000") + "," + U.ToString("0.00000"));
                    Work.SaveImage("相机2", "2号吸嘴", result, DisplayForm.Instance[4]);
                    if (result)
                    {
                        Cam2_OK2 = 1;
                    }
                    else
                    {
                        Cam2_NG2 = 1;
                    }
                }
            }
            catch (Exception)
            {
                result = false;
                AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&OBG,1,2," + (result ? "1" : "0") + "," + X.ToString("0.00000") + "," + Y.ToString("0.00000") + "," + U.ToString("0.00000"));
            }

            AppParam.Instance.lightSource.StateCH2 = false;
        }

        private static void Cam2_Calibration(HalconDotNet.HObject ho_image)
        {
            try
            {
                if (Work.Cam2_Calibration_Mode)
                {
                    Form_Robot_Calibration.Instance.Window.Disp_Image(ho_image);
                    if (Work.Cam2_Suction_Nozzle_Number == 1)
                    {
                        //9点标定+ 1号吸嘴旋转标定
                        if (Work.Cam2_Calibration_Index == 0 && Work.Cam2_Suction_Nozzle_Number == 1)
                        {
                            Form_Robot_Calibration.Instance.ClearData(2);
                            Thread.Sleep(20);
                        }
                        //像素位置
                        HTuple Row = 0.0, Column = 0.0, Angle = 0.0;
                        //第4点是1号吸嘴旋转第二点
                        //9是旋转中心第一点
                        //10是旋转中心第三点
                        HOperatorSet.FindShapeModel(ho_image, CalibrationData.Instance.Cam2_hv_ModelID, new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), CalibrationData.Instance.Cam2_minScore1, 1, 0.5, "least_squares", 0, 0.7, out Row, out Column, out Angle, out _);
                        if (Row > 0)
                        {
                            Form_Robot_Calibration.Instance.Window.Disp_Message("Row:" + Row.D + "\nColumn:" + Column.D + "\nAngle:" + Angle.TupleDeg().D, 16, 10, 10, "blue");
                            Work.DispModelXLD(CalibrationData.Instance.Cam2_hv_ModelID, Row, Column, Angle);
                            Form_Robot_Calibration.Instance.Window.Disp_Cross(Row, Column, 200, Angle, "blue");
                            Form_Robot_Calibration.Instance.AddData(2, Work.Cam2_Suction_Nozzle_Number, Work.Cam2_Calibration_Index, Column.D, Row.D, Work.Cam2_X1, Work.Cam2_Y1);
                            AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&CAE,1");

                            Log.WriteRunLog("相机2 回复指令 ： & CAE, 1");
                        }
                        else
                        {
                            AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&CAE,0");
                            Log.WriteRunLog("相机2 回复指令 ： & CAE, 0");
                        }
                        if (Work.Cam2_Calibration_Index == 23)
                        {
                            //Work.Cam2_Calibration_Mode = false;
                            Work.Cam2_Suction_Nozzle_Number = -1;
                            Log.WriteRunLog("相机2 9点标定+1号吸嘴旋转标定结束");
                        }
                    }
                    else if (Work.Cam2_Suction_Nozzle_Number == 2)
                    {
                        //2号吸嘴旋转标定

                        //像素位置
                        HTuple Row = 0.0, Column = 0.0, Angle = 0.0;
                        //第4点是1号吸嘴旋转第二点
                        //9是旋转中心第一点
                        //10是旋转中心第三点
                        HOperatorSet.FindShapeModel(ho_image, CalibrationData.Instance.Cam2_hv_ModelID, new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), CalibrationData.Instance.Cam2_minScore2, 1, 0.5, "least_squares", 0, 0.7, out Row, out Column, out Angle, out _);
                        if (Row > 0)
                        {
                            Form_Robot_Calibration.Instance.Window.Disp_Message("Row:" + Row.D + "\nColumn:" + Column.D + "\nAngle:" + Angle.TupleDeg().D, 16, 10, 10, "blue");

                            Work.DispModelXLD(CalibrationData.Instance.Cam2_hv_ModelID, Row, Column, Angle);
                            Form_Robot_Calibration.Instance.Window.Disp_Cross(Row, Column, 200, Angle, "blue");
                            Form_Robot_Calibration.Instance.AddData(2, Work.Cam2_Suction_Nozzle_Number, Work.Cam2_Calibration_Index, Column.D, Row.D, Work.Cam2_X1, Work.Cam2_Y1);
                            AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&CAE,1");
                            Log.WriteRunLog("相机2 回复指令 ： & CAE, 1");
                        }
                        else
                        {
                            AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&CAE,0");

                            Log.WriteRunLog("相机2 回复指令 ： & CAE, 0");
                        }
                        if (Work.Cam2_Calibration_Index == 23)
                        {
                            Work.Cam2_Calibration_Mode = false;
                            Work.Cam2_Suction_Nozzle_Number = -1;
                            Log.WriteRunLog("相机2 2号吸嘴旋转标定结束");
                            Form_Robot_Calibration.Instance.Auto(2);
                        }
                    }
                }
            }
            catch (Exception)
            {
                AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&CAE,0");
            }
            AppParam.Instance.lightSource.StateCH2 = false;
        }

        public static int Cam2_OK1
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam2_OK1.Text);
            }
            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam2_OK1.Text);
                MainForm.Instance.label_Cam2_OK1.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam2_TOTAL1.Text = (Cam2_OK1 + Cam2_NG1).ToString();
            }
        }

        public static int Cam2_NG1
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam2_NG1.Text);
            }
            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam2_NG1.Text);
                MainForm.Instance.label_Cam2_NG1.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam2_TOTAL1.Text = (Cam2_OK1 + Cam2_NG1).ToString();
            }
        }

        public static int Cam2_OK2
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam2_OK2.Text);
            }
            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam2_OK2.Text);
                MainForm.Instance.label_Cam2_OK2.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam2_TOTAL2.Text = (Cam2_OK2 + Cam2_NG2).ToString();
            }
        }

        public static int Cam2_NG2
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam2_NG2.Text);
            }

            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam2_NG2.Text);
                MainForm.Instance.label_Cam2_NG2.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam2_TOTAL2.Text = (Cam2_OK2 + Cam2_NG2).ToString();
            }
        }
    }
}