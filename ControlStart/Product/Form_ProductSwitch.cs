using ControlStart.Helper;
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
using ToolKit.HYControls.HYForm;

namespace ControlStart.Product
{
    public partial class Form_ProductSwitch : HYBaseForm
    {
        public Form_ProductSwitch()
        {
            InitializeComponent();
        }

        public DialogResult Popup(string oldName,string newName)
        {
            ProductConfig oldProductConfig = (ProductConfig)Serialization.Read2(System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + oldName+".pro");
            ProductConfig newProductConfig = (ProductConfig)Serialization.Read2(System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + newName + ".pro");

            label_oldName.Text = oldProductConfig?.ProductName;
            label_newName.Text = newProductConfig?.ProductName;
            halconWindow1.Disp_Image(oldProductConfig?.ProductImage);
            halconWindow2.Disp_Image(newProductConfig?.ProductImage);
            oldProductConfig?.ProductImage.Dispose();
            newProductConfig?.ProductImage.Dispose();
            return this.ShowDialog();
        }

        private void Form_ProductSwitch_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
