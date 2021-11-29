﻿using System;
using System.Threading;
using HalconDotNet;
using HYProject.MenuForm;
using HYProject.Plugin;
using HYProject.ToolForm;

namespace HYProject.Model
{
    public class Cam1_Work
    {
        public static void Cam1_Work_Method(HalconDotNet.HObject ho_image)
        {
            bool result = true;
            double X = 0.000;
            double Y = 0.000;
            double U = 0.000;

            if (Work.Cam1_Calibration_Mode)
            {
                Cam1_Calibration(ho_image);
                return;
            }


            //1号吸嘴定位
            if (Work.Cam1_Suction_Nozzle_Number == 1)
            {
                DisplayForm.Instance[0].Disp_Image(ho_image);
                DisplayForm.Instance[0].Disp_Message("相机1 1号吸嘴", 16, 10, 10, "blue");


                HTuple Center_Row = new HTuple(0.00);
                HTuple Center_Column = new HTuple(0.00);
                HTuple Angle = new HTuple(0.00);


                result = Work.Find_Point(ho_image, DisplayForm.Instance[0], "相机1", "1", out Center_Row, out Center_Column, out Angle);

                if (result)
                {

                    HTuple robot_x = new HTuple(0.0);
                    HTuple robot_y = new HTuple(0.0);
                    double robot_Rotate_X = 0, robot_Rotate_Y = 0;
                    ////最后发送给机器人或者执行机构的偏移值为：x0 - refPos_x，y0 - refPos_y，a
                    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam1_HomMat2d1, Center_Row, Center_Column, out robot_y, out robot_x);
                    ////最后发送给机器人或者执行机构的偏移值为：x0 - refPos_x，y0 - refPos_y，a
                    double 补偿U = Angle.D - StandardPar.Instance.Cam1_Standar_Point1.U;
                    double offsetU = StandardPar.Instance.Cam1_Standar_Point1.U - Angle.D;

                    Work.RotateAngle(CalibrationData.Instance.Cam1_Rotate_Center1_Point.X, CalibrationData.Instance.Cam1_Rotate_Center1_Point.Y,
                        offsetU,
                        robot_x.D, robot_y.D,
                        ref robot_Rotate_X, ref robot_Rotate_Y);


                    // HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam3_HomMat2d1, new HTuple(Rotate_X), new HTuple(Rotate_Y), out robot_x, out robot_y);


                    // xy补偿  //产品定位点到拍照位置的偏差（假设拍照点就是基准点）
                    double offsetX = StandardPar.Instance.Cam1_Standar_Point1.X - robot_Rotate_X;
                    double offsetY = StandardPar.Instance.Cam1_Standar_Point1.Y - robot_Rotate_Y;

                    DisplayForm.Instance[0].Disp_Message("相机1 1号吸嘴", 16, 10, 10, "blue");
                    Log.WriteRunLog("Cam1-1 补偿：" + "X:" + offsetX + "Y:" + offsetY + "U:" + 补偿U);
                    DisplayForm.Instance[0].Disp_Message("X:" + offsetX.ToString("0.00000") + "\nY:" + offsetY.ToString("0.00000") + "\nR:" + 补偿U.ToString("0.00000"), 16, 300, 10, result ? "green" : "red");


                    X = CalibrationData.Instance.Cam1_Standard1_Point.X + offsetX + Offset.Instance.Cam1_OffsetX1;
                    Y = CalibrationData.Instance.Cam1_Standard1_Point.Y + offsetY + Offset.Instance.Cam1_OffsetY1;
                    U = CalibrationData.Instance.Cam1_Standard1_Point.U + 补偿U + Offset.Instance.Cam1_OffsetR1;

                    DisplayForm.Instance[0].Disp_Message("X:" + X.ToString("0.00000") + "\nY:" + Y.ToString("0.00000") + "\nR:" + U.ToString("0.00000"), 16, 1200, 10, result ? "green" : "red");

                }
                else
                {
                    Log.WriteErrorLog("定位失败：[" + Center_Row.D.ToString("0.00000") + "," + Center_Column.D.ToString("0.00000") + "," + Angle.D.ToString("0.00000") + "]");
                }

                AppParam.Instance.TCPSocketServer_Cam1.SendMessage("&OBG,1,1," + (result ? "1" : "0") + "," + X.ToString("0.00000") + "," + Y.ToString("0.00000") + "," + U.ToString("0.00000"));
                Log.WriteRunLog("Cam1-1 贴合位：X:" + X.ToString("0.00000") + "Y:" + Y.ToString("0.00000") + "R:" + U.ToString("0.00000"));
                Work.SaveImage("相机1", "1号吸嘴", result, DisplayForm.Instance[0]);
                if (result)
                {
                    Cam1_OK1 = 1;
                }
                else
                {
                    Cam1_NG1 = 1;
                }
            }
            //2号吸嘴定位
            else if (Work.Cam1_Suction_Nozzle_Number == 2)
            {
                DisplayForm.Instance[3].Disp_Image(ho_image);


                HTuple Center_Row = new HTuple(0.00);
                HTuple Center_Column = new HTuple(0.00);
                HTuple Angle = new HTuple(0.00);


                result = Work.Find_Point(ho_image, DisplayForm.Instance[3], "相机1", "2", out Center_Row, out Center_Column, out Angle);

                if (result)
                {

                    HTuple robot_x = new HTuple(0.0);
                    HTuple robot_y = new HTuple(0.0);
                    double robot_Rotate_X = 0, robot_Rotate_Y = 0;
                    ////最后发送给机器人或者执行机构的偏移值为：x0 - refPos_x，y0 - refPos_y，a
                    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam1_HomMat2d2, Center_Row, Center_Column, out robot_y, out robot_x);
                    ////最后发送给机器人或者执行机构的偏移值为：x0 - refPos_x，y0 - refPos_y，a
                    double 补偿U = Angle.D - StandardPar.Instance.Cam1_Standar_Point2.U;
                    double offsetU = StandardPar.Instance.Cam1_Standar_Point2.U - Angle.D;

                    Work.RotateAngle(CalibrationData.Instance.Cam1_Rotate_Center2_Point.X, CalibrationData.Instance.Cam1_Rotate_Center2_Point.Y,
                        offsetU,
                        robot_x.D, robot_y.D,
                        ref robot_Rotate_X, ref robot_Rotate_Y);


                    // HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam3_HomMat2d1, new HTuple(Rotate_X), new HTuple(Rotate_Y), out robot_x, out robot_y);


                    // xy补偿  //产品定位点到拍照位置的偏差（假设拍照点就是基准点）
                    double offsetX = StandardPar.Instance.Cam1_Standar_Point2.X - robot_Rotate_X;
                    double offsetY = StandardPar.Instance.Cam1_Standar_Point2.Y - robot_Rotate_Y;

                    DisplayForm.Instance[1].Disp_Message("相机1 2号吸嘴", 16, 10, 10, "blue");

                    Log.WriteRunLog("Cam3-1 补偿：" + "X:" + offsetX + "Y:" + offsetY + "U:" + 补偿U);
                    DisplayForm.Instance[3].Disp_Message("X:" + offsetX.ToString("0.00000") + "\nY:" + offsetY.ToString("0.00000") + "\nR:" + 补偿U.ToString("0.00000"), 16, 10, 10, result ? "green" : "red");


                    X = CalibrationData.Instance.Cam1_Standard2_Point.X + offsetX + Offset.Instance.Cam1_OffsetX2;
                    Y = CalibrationData.Instance.Cam1_Standard2_Point.Y + offsetY + Offset.Instance.Cam1_OffsetY2;
                    U = CalibrationData.Instance.Cam1_Standard2_Point.U + 补偿U + Offset.Instance.Cam1_OffsetR2;


                    DisplayForm.Instance[3].Disp_Message("X:" + X.ToString("0.00000") + "\nY:" + Y.ToString("0.00000") + "\nR:" + U.ToString("0.00000"), 16, 1000, 10, result ? "green" : "red");

                }
                else
                {
                    Log.WriteErrorLog("定位失败：[" + Center_Row.D.ToString("0.00000") + "," + Center_Column.D.ToString("0.00000") + "," + Angle.D.ToString("0.00000") + "]");
                }

                AppParam.Instance.TCPSocketServer_Cam1.SendMessage("&OBG,1,2," + (result ? "1" : "0") + "," + X.ToString("0.00000") + "," + Y.ToString("0.00000") + "," + U.ToString("0.00000"));
                Log.WriteRunLog("Cam1-2 贴合位：X:" + X.ToString("0.00000") + "Y:" + Y.ToString("0.00000") + "R:" + U.ToString("0.00000"));

                Work.SaveImage("相机1", "2号吸嘴", result, DisplayForm.Instance[1]);
                if (result)
                {
                    Cam1_OK2 = 1;
                }
                else
                {
                    Cam1_NG2 = 1;
                }
            }

            AppParam.Instance.lightSource.StateCH1 = false;
        }

        private static void Cam1_Calibration(HalconDotNet.HObject ho_image)
        {
            try
            {
                if (Work.Cam1_Calibration_Mode)
                {
                    Form_Robot_Calibration.Instance.Window.Disp_Image(ho_image);
                    if (Work.Cam1_Suction_Nozzle_Number == 1)
                    {
                        //9点标定+ 1号吸嘴旋转标定
                        if (Work.Cam1_Calibration_Index == 0&&Work.Cam1_Suction_Nozzle_Number==1)
                        {
                            Form_Robot_Calibration.Instance.ClearData(1);
                            Thread.Sleep(20);
                        }
                        //像素位置
                        HTuple Row = 0.0, Column = 0.0, Angle = 0.0;
                        //第4点是1号吸嘴旋转第二点
                        //9是旋转中心第一点
                        //10是旋转中心第三点
                        HOperatorSet.FindShapeModel(ho_image, CalibrationData.Instance.Cam1_hv_ModelID, new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), CalibrationData.Instance.Cam1_minScore1, 1, 0.5, "least_squares", 0, 0.7, out Row, out Column, out Angle, out _);
                        //HOperatorSet.FindNccModel(ho_image, CalibrationData.Instance.Cam1_hv_ModelID, new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), CalibrationData.Instance.Cam1_minScore2, 1, 0.5, "true", 0, out Row, out Column, out Angle, out _);

                        if (Row > 0)
                        {
                            Form_Robot_Calibration.Instance.Window.Disp_Message("Row:" + Row.D + "\nColumn:" + Column.D + "\nAngle:" + Angle.TupleDeg().D, 16, 10, 10, "blue");

                            Work.DispModelXLD(CalibrationData.Instance.Cam1_hv_ModelID, Row, Column, Angle);
                            Form_Robot_Calibration.Instance.Window.Disp_Cross(Row, Column, 200, 0, "blue");
                            Form_Robot_Calibration.Instance.AddData(1,Work.Cam1_Suction_Nozzle_Number,Work.Cam1_Calibration_Index , Column.D, Row.D, Work.Cam1_X1, Work.Cam1_Y1);
                            AppParam.Instance.TCPSocketServer_Cam1.SendMessage("&CAE,1");
                            Log.WriteRunLog("相机1 回复指令 ： & CAE, 1");
                        }
                        else
                        {
                            AppParam.Instance.TCPSocketServer_Cam1.SendMessage("&CAE,0");
                            Log.WriteRunLog("相机1 回复指令 ： & CAE, 0");
                        }

                        if (Work.Cam1_Calibration_Index == 23)
                        {
                            //Work.Cam1_Calibration_Mode = false;
                            Work.Cam1_Suction_Nozzle_Number = -1;
                            Log.WriteRunLog("相机1 9点标定+1号吸嘴旋转标定结束");
                        }
                    }
                    else if (Work.Cam1_Suction_Nozzle_Number == 2)
                    {
                        //2号吸嘴旋转标定

                        //2号吸嘴旋转标定

                        //像素位置
                        HTuple Row = 0.0, Column = 0.0, Angle = 0.0;
                        //第4点是1号吸嘴旋转第二点
                        //9是旋转中心第一点
                        //10是旋转中心第三点
                        //HOperatorSet.FindNccModel(ho_image, CalibrationData.Instance.Cam1_hv_ModelID, new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), CalibrationData.Instance.Cam1_minScore2, 1, 0.5, "true", 0, out Row, out Column, out Angle, out _);
                        HOperatorSet.FindShapeModel(ho_image, CalibrationData.Instance.Cam1_hv_ModelID, new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), CalibrationData.Instance.Cam1_minScore2, 1, 0.5, "least_squares", 0, 0.7, out Row, out Column, out Angle, out _);
                        if (Row > 0)
                        {
                            Form_Robot_Calibration.Instance.Window.Disp_Message("Row:" + Row.D + "\nColumn:" + Column.D + "\nAngle:" + Angle.TupleDeg().D, 16, 10, 10, "blue");

                            Work.DispModelXLD(CalibrationData.Instance.Cam1_hv_ModelID, Row, Column, Angle);
                            Form_Robot_Calibration.Instance.Window.Disp_Cross(Row, Column, 200, 0, "blue");
                            Form_Robot_Calibration.Instance.AddData(1, Work.Cam1_Suction_Nozzle_Number, Work.Cam1_Calibration_Index, Column.D, Row.D, Work.Cam1_X1, Work.Cam1_Y1);
                            AppParam.Instance.TCPSocketServer_Cam1.SendMessage("&CAE,1");
                            Log.WriteRunLog("相机1 回复指令 ： & CAE, 1");
                        }
                        else
                        {
                            AppParam.Instance.TCPSocketServer_Cam1.SendMessage("&CAE,0");
                            Log.WriteRunLog("相机1 回复指令 ： & CAE, 0");
                        }

                        if (Work.Cam1_Calibration_Index == 23)
                        {
                            Work.Cam1_Calibration_Mode = false;
                            Work.Cam1_Suction_Nozzle_Number = -1;
                            Log.WriteRunLog("相机1 2号吸嘴旋转标定结束");
                            Form_Robot_Calibration.Instance.Auto(1);
                        }
                    }
                }
            }
            catch (Exception)
            {
                AppParam.Instance.TCPSocketServer_Cam1.SendMessage("&CAE,0");
            }
            AppParam.Instance.lightSource.StateCH1 = false;
        }

        public static int Cam1_OK1
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam1_OK1.Text);
            }
            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam1_OK1.Text);
                MainForm.Instance.label_Cam1_OK1.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam1_TOTAL1.Text = (Cam1_OK1 + Cam1_NG1).ToString();
            }
        }

        public static int Cam1_NG1
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam1_NG1.Text);
            }
            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam1_NG1.Text);
                MainForm.Instance.label_Cam1_NG1.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam1_TOTAL1.Text = (Cam1_OK1 + Cam1_NG1).ToString();
            }
        }

        public static int Cam1_OK2
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam1_OK2.Text);
            }
            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam1_OK2.Text);
                MainForm.Instance.label_Cam1_OK2.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam1_TOTAL2.Text = (Cam1_OK2 + Cam1_NG2).ToString();
            }
        }

        public static int Cam1_NG2
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam1_NG2.Text);
            }

            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam1_NG2.Text);
                MainForm.Instance.label_Cam1_NG2.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam1_TOTAL2.Text = (Cam1_OK2 + Cam1_NG2).ToString();
            }
        }
    }
}