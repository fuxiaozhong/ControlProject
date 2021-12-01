using HalconDotNet;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStart.ToolForms
{
    public partial class Form_CameraCalibration : UserControl
    {
        public Form_CameraCalibration()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 标定事件
        /// </summary>
        /// <param name="camName"></param>
        /// <param name="image"></param>
        internal void CamWrok(string camName, HObject image)
        {
           
        }
    }
}
