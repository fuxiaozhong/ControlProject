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

namespace ControlStartTest
{
    public partial class Form1 : Form
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

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainForm1.Initialize();
            mainForm1._ExternalOutputImage += this.MainForm1__ExternalOutputImage;
        }

        private void MainForm1__ExternalOutputImage(string CamName, global::HalconDotNet.HObject image)
        {
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm1.CloseSoftware();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Cameras.Instance[0].Start_Real_Mode();
            //mainForm1.ShowControlForm(ControlStart.FormPage.主页面);
            //mainForm1.ShowControlForm(ControlStart.FormPage.产品设置);
            //mainForm1.ShowControlForm(ControlStart.FormPage.工具);
            //mainForm1.ShowControlForm(ControlStart.FormPage.数据);
            //mainForm1.ShowControlForm(ControlStart.FormPage.相机);
            //mainForm1.ShowControlForm(ControlStart.FormPage.系统设置);
        }
    }
}
