using ControlStart.Helper;
using ControlStart.Product;
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

namespace ControlStart.ControlForms
{
    public partial class Form_ProductSet : UserControl
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }
        public Form_ProductSet()
        {
            InitializeComponent();
        }
        public void CamWork(string CamName, HalconDotNet.HObject image)
        {

            form_ProductAddorUpData.CamWork(CamName, image);
        }
        Form_ProductAddorUpData form_ProductAddorUpData;
        Form_ProductHome form_ProductHome;

        internal void ReturnForm_ProductSet()
        {
            if (form_ProductHome == null)
            {
                form_ProductHome = new Form_ProductHome();
                form_ProductHome.Dock = DockStyle.Fill;
                form_ProductHome.form_ProductSet = this;
            }
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(form_ProductHome);
            form_ProductHome.btn_Refresh_Click(null,null);
        }

        internal void SwitchForm_ProductAddorUpData(string productName = null)
        {
            if (productName == null)
            {

                form_ProductAddorUpData = new Form_ProductAddorUpData();
                form_ProductAddorUpData.Dock = DockStyle.Fill;
                form_ProductAddorUpData.form_ProductSet = this;
                uiPanel1.Controls.Clear();
                uiPanel1.Controls.Add(form_ProductAddorUpData);
            }
            else
            {
                ProductConfig productConfig=    (ProductConfig)Serialization.Read2(System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + productName + ".pro");
                form_ProductAddorUpData = new Form_ProductAddorUpData(productConfig);
                form_ProductAddorUpData.Dock = DockStyle.Fill;
                form_ProductAddorUpData.form_ProductSet = this;
                uiPanel1.Controls.Clear();
                uiPanel1.Controls.Add(form_ProductAddorUpData);
            }
        }

        private void Form_ProductSet_Load(object sender, EventArgs e)
        {
            if (form_ProductHome == null)
            {
                form_ProductHome = new Form_ProductHome();
                form_ProductHome.Dock = DockStyle.Fill;
                form_ProductHome.form_ProductSet = this;
            }
            if (form_ProductAddorUpData == null)
            {
                form_ProductAddorUpData = new Form_ProductAddorUpData();
                form_ProductAddorUpData.Dock = DockStyle.Fill;
                form_ProductAddorUpData.form_ProductSet = this;
            }
            form_ProductHome.form_ProductAddorUpData = form_ProductAddorUpData;
            uiPanel1.Controls.Clear();
            uiPanel1.Controls.Add(form_ProductHome);
            //this.Dock = DockStyle.Fill;

        }
    }
}
