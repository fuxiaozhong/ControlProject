using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolKit.HalconTool.Model;

namespace HYProject.Model
{
    [Serializable]
    public class StandardPar
    {

        
        internal HObject Cam1_Image1;
        internal HObject Cam1_Image2;
        internal HObject Cam2_Image1;
        internal HObject Cam2_Image2;
        internal HObject Cam3_Image1;
        internal HObject Cam3_Image2;
        internal MeasureParam Cam1_Top1;
        internal MeasureParam Cam1_Left1;
        internal MeasureParam Cam1_Button1;
        internal MeasureParam Cam1_Right1;
        internal MeasureParam Cam1_Top2;
        internal MeasureParam Cam1_Left2;
        internal MeasureParam Cam1_Button2;
        internal MeasureParam Cam1_Right2;

        internal MeasureParam Cam2_Top1;
        internal MeasureParam Cam2_Left1;
        internal MeasureParam Cam2_Button1;
        internal MeasureParam Cam2_Right1;
        internal MeasureParam Cam2_Top2;
        internal MeasureParam Cam2_Left2;
        internal MeasureParam Cam2_Button2;
        internal MeasureParam Cam2_Right2;

        internal MeasureParam Cam3_Top1;
        internal MeasureParam Cam3_Left1;
        internal MeasureParam Cam3_Button1;
        internal MeasureParam Cam3_Right1;
        internal MeasureParam Cam3_Top2;
        internal MeasureParam Cam3_Left2;
        internal MeasureParam Cam3_Button2;
        internal MeasureParam Cam3_Right2;




        internal RobotPoint Cam1_Standar_Point1;
        internal RobotPoint Cam1_Standar_Point2;
        internal RobotPoint Cam2_Standar_Point1;
        internal RobotPoint Cam2_Standar_Point2;
        internal RobotPoint Cam3_Standar_Point1;
        internal RobotPoint Cam3_Standar_Point2;


        private static StandardPar instance;
        /// <summary>
        /// 初始化当前类(单例模式)
        /// </summary>
        public static StandardPar Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StandardPar();
                }
                return instance;
            }
            set
            {
                if (instance == null)
                {
                    instance = new StandardPar();
                }
                instance = value;
            }
        }


    }
}
