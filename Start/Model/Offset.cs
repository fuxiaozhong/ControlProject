using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYProject.Model
{
    [Serializable]
    public class Offset
    {
        private static Offset instance;


        internal double Cam1_OffsetX1;
        internal double Cam1_OffsetY1;
        internal double Cam1_OffsetR1;
        internal double Cam1_OffsetX2;
        internal double Cam1_OffsetY2;
        internal double Cam1_OffsetR2;
        internal double Cam2_OffsetX1;
        internal double Cam2_OffsetY1;
        internal double Cam2_OffsetR1;
        internal double Cam2_OffsetX2;
        internal double Cam2_OffsetY2;
        internal double Cam2_OffsetR2;
        internal double Cam3_OffsetX1;
        internal double Cam3_OffsetY1;
        internal double Cam3_OffsetR1;
        internal double Cam3_OffsetX2;
        internal double Cam3_OffsetY2;
        internal double Cam3_OffsetR2;

        /// <summary>
        /// 初始化当前类(单例模式)
        /// </summary>
        public static Offset Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Offset();
                }
                return instance;
            }
            set
            {
                if (instance == null)
                {
                    instance = new Offset();
                }
                instance = value;
            }
        }
    }
}
