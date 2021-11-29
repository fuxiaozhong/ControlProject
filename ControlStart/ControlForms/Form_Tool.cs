using ControlStart.ToolForms;
using ControlStart.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolKit.HYControls;

namespace ControlStart.ControlForms
{
    public partial class Form_Tool : UserControl
    {
        public Form_Tool()
        {
            InitializeComponent();
        }
        public void CamWork(string CamName, HalconDotNet.HObject image)
        {


        }
        public void Read()
        {
            hyGlobalVariable_System.SetData((List<GlobalVariableData>)Serialization.Read("GlobalSystemConfig"));
            hyGlobalVariable_User.SetData((List<GlobalVariableData>)Serialization.Read("GlobalUserConfig"));
        }
        public void Save()
        {
            Serialization.Save(hyGlobalVariable_System.GetData(), "GlobalSystemConfig");
            Serialization.Save(hyGlobalVariable_User.GetData(), "GlobalUserConfig");
        }

        public object GetSystemValue(string key)
        {
            return hyGlobalVariable_System.GetValue(key);
        }
        public object GetUserValue(string key)
        {
            return hyGlobalVariable_User.GetValue(key);
        }
        //Form_CameraCalibration form_CameraCalibration;

        private void Form_Tool_Load(object sender, EventArgs e)
        {
            //if (form_CameraCalibration == null)
            //{
            //    form_CameraCalibration = new Form_CameraCalibration();
            //}
            //tabPage1.Controls.Add(form_CameraCalibration);
            //this.Dock = DockStyle.Fill;

            if (hyGlobalVariable_System.GetData().Count==0)
            {
                hyGlobalVariable_System.Add("String", "标题","视觉检测软件");
                hyGlobalVariable_System.Add("Bool","产品设置","false");
                hyGlobalVariable_System.Add("Bool","数据", "false");
                //hyGlobalVariable_System.Add("Bool","标题","视觉检测软件");
                //hyGlobalVariable_System.Add("Bool","标题","视觉检测软件");
                //hyGlobalVariable_System.Add("Bool","标题","视觉检测软件");
            }
           


        }
    }
}
