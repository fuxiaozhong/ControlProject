using ControlStart.ControlForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlStart.Helper;
using HalconDotNet;
using ControlStart.Utils;
using ToolKit.HYControls.HYForm;
using ToolKit.HYControls;
using System.IO;
using System.Threading;
using ControlStart.Config;
using ToolKit.DisplayWindow;

namespace ControlStart.Product
{
    public partial class Form_ProductAddorUpData : UserControl
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0014) // 禁掉清除背景消息
                return;
            base.WndProc(ref m);
        }
        ProductConfig nowProduct;
        public Form_ProductSet form_ProductSet;
        public Form_ProductAddorUpData(ProductConfig product = null)
        {
            InitializeComponent();
            if (product == null)
            {
                uiLabel1.Text = "产品添加";
                nowProduct = new ProductConfig();
            }
            else
            {
                nowProduct = product;
                uiLabel1.Text = "产品修改 - " + product.ProductName;
                halconWindow1.Disp_Image(product.ProductImage?.Clone());
                uiCheckBox1.Checked = nowProduct.Check_SilverPaste;
            }
            //this.Dock = DockStyle.Fill;

        }

        internal void CamWork(string camName, HObject image)
        {
            halconWindow1.Disp_Image(image);
            halconWindow1.Disp_Message(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff"), 14, 0, 0, "green");
            if (HYMessageBox.ShowWarn("是否替换基准图?") == DialogResult.OK)
            {
                if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 0)
                {//ab左
                 //
                    HOperatorSet.CopyImage(image, out nowProduct.ABCam_Left_Model.ModelBaseImage);
                }
                else if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 1)
                {//ab右
                    HOperatorSet.CopyImage(image, out nowProduct.ABCam_Right_Model.ModelBaseImage);
                }
                else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 0)
                {//cd左
                    HOperatorSet.CopyImage(image, out nowProduct.CDCam_Left_Model.ModelBaseImage);
                }
                else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 1)
                {//cd右
                    HOperatorSet.CopyImage(image, out nowProduct.CDCam_Right_Model.ModelBaseImage);
                }
                else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 0)
                {//down左
                    HOperatorSet.CopyImage(image, out nowProduct.DownCam_Left_Model.ModelBaseImage);
                }
                else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 1)
                {//doen右
                    HOperatorSet.CopyImage(image, out nowProduct.DownCam_Right_Model.ModelBaseImage);
                }
            }
            else
            {
                uiButton_Disp_Click(null, null);
            }

        }



        private void btn_Return_Click(object sender, EventArgs e)
        {
            if (nowProduct.ProductName != "")
            {
                nowProduct.ProductImage?.Dispose();
            }


            form_ProductSet.ReturnForm_ProductSet();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (halconWindow1.Image == null)
            {
                HYMessageBox.ShowWarn("请先导入一张图片.");
                return;
            }
            if (nowProduct.ProductName == "")
            {
                try
                {
                step:
                    string name = "";
                    if (HYInputDialog.InputStringDialog(ref name, true, "请输入产品名:", true))
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + name + ".pro"))
                        {
                            HYMessageBox.ShowWarn("改产品名存在,请修改.");
                            goto step;
                        }
                        nowProduct.ProductImage = halconWindow1.Image;
                        nowProduct.Check_SilverPaste = uiCheckBox1.Checked;
                        nowProduct.ProductName = name;
                        nowProduct.CreateTime = DateTime.Now;
                        HYForm_Waiting form_Waiting = new HYForm_Waiting(SaveProduct_Add, "正在保存产品数据,请稍等!");
                        form_Waiting.ShowDialog();
                        //form_ProductSet.ReturnForm_ProductSet();
                    }
                }
                catch (Exception)
                {
                    HYMessageBox.ShowError("保存失败");
                    nowProduct.ProductName = "";
                }
            }
            else
            {
                try
                {
                    nowProduct.ProductImage = halconWindow1.Image;
                    HYForm_Waiting form_Waiting = new HYForm_Waiting(SaveProduct_Updata, "正在保存产品数据,请稍等!");
                    form_Waiting.ShowDialog();

                    //form_ProductSet.ReturnForm_ProductSet();
                }
                catch (Exception)
                {
                    HYMessageBox.ShowNormal("修改失败");
                }
            }
        }

        private void SaveProduct_Updata(object sender, EventArgs e)
        {
            Serialization.Save2(nowProduct, System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + nowProduct.ProductName + ".pro");

            Global.Instance.RunningLog.WriteRunLog("修改产品:[" + nowProduct.ProductName + "],成功");
            HYMessageBox.ShowNormal("修改成功");
        }

        private void SaveProduct_Add(object sender, EventArgs e)
        {
            Serialization.Save2(nowProduct, System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + nowProduct.ProductName + ".pro");

            Global.Instance.RunningLog.WriteRunLog("添加产品:[" + nowProduct.ProductName + "],成功");
            HYMessageBox.ShowNormal("添加成功");
        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 0)
            {
                hyCreateModel21.SetModel(ref nowProduct.ABCam_Left_Model);
            }
            else if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 1)
            {
                hyCreateModel21.SetModel(ref nowProduct.ABCam_Right_Model);
            }
            else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 0)
            {
                hyCreateModel21.SetModel(ref nowProduct.CDCam_Left_Model);
            }
            else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 1)
            {
                hyCreateModel21.SetModel(ref nowProduct.CDCam_Right_Model);
            }
            else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 0)
            {
                hyCreateModel21.SetModel(ref nowProduct.DownCam_Left_Model);
            }
            else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 1)
            {
                hyCreateModel21.SetModel(ref nowProduct.DownCam_Right_Model);
            }
        }

        private void Form_ProductAddorUpData_Load(object sender, EventArgs e)
        {
            //uiComboBox_Cam.Items.Clear();
            //foreach (var item in Cameras.Instance.GetCameras.Keys)
            //{
            //    uiComboBox_Cam.Items.Add(item);
            //}
            //if (uiComboBox_Cam.Items.Count > 0)
            //{
            //    uiComboBox_Cam.SelectedIndex = 0;
            //}

            uiComboBox_Mark.SelectedIndex = 0;
            uiComboBox_Cam.SelectedIndex = 0;
        }

        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton1_Click(object sender, EventArgs e)
        {
            Cameras.Instance[uiComboBox_Cam.Text].Set_Soft_Trigger_Model();
            Cameras.Instance[uiComboBox_Cam.Text].Soft_Trigger();
        }
        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton_Disp_Click(object sender, EventArgs e)
        {
            if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 0)
            {
                halconWindow1.Disp_Image(nowProduct.ABCam_Left_Model.ModelBaseImage);
            }
            else if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 1)
            {
                halconWindow1.Disp_Image(nowProduct.ABCam_Right_Model.ModelBaseImage);
            }
            else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 0)
            {
                halconWindow1.Disp_Image(nowProduct.CDCam_Left_Model.ModelBaseImage);
            }
            else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 1)
            {
                halconWindow1.Disp_Image(nowProduct.CDCam_Right_Model.ModelBaseImage);
            }
            else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 0)
            {
                halconWindow1.Disp_Image(nowProduct.DownCam_Left_Model.ModelBaseImage);
            }
            else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 1)
            {
                halconWindow1.Disp_Image(nowProduct.DownCam_Right_Model.ModelBaseImage);
            }
        }

        /// <summary>
        /// 框选银浆位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton7_Click(object sender, EventArgs e)
        {
            Rectangle1 rectangle = halconWindow1.Draw_Rectangle1("blue");
            if (rectangle.rectangle1 != null)
            {
                if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 0)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.ABCam_Left_SilverPaste_Location, 1, 1);
                }
                else if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 1)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.ABCam_Right_SilverPaste_Location, 1, 1);
                }
                else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 0)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.CDCam_Left_SilverPaste_Location, 1, 1);
                }
                else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 1)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.CDCam_Right_SilverPaste_Location, 1, 1);
                }
                else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 0)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.DownCam_Left_SilverPaste_Location, 1, 1);
                }
                else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 1)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.DownCam_Right_SilverPaste_Location, 1, 1);
                }
            }

            halconWindow1.Disp_Region(rectangle.rectangle1,"blue","margin");
            rectangle.rectangle1.Dispose();

        }
        /// <summary>
        /// 框选银浆范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton9_Click(object sender, EventArgs e)
        {
            Rectangle1 rectangle = halconWindow1.Draw_Rectangle1("blue");
            if (rectangle.rectangle1 != null)
            {
                if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 0)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.ABCam_Left_SilverPaste_Scope, 1, 1);
                }
                else if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 1)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.ABCam_Right_SilverPaste_Scope, 1, 1);
                }
                else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 0)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.CDCam_Left_SilverPaste_Scope, 1, 1);
                }
                else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 1)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.CDCam_Right_SilverPaste_Scope, 1, 1);
                }
                else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 0)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.DownCam_Left_SilverPaste_Scope, 1, 1);
                }
                else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 1)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.DownCam_Right_SilverPaste_Scope, 1, 1);
                }
            }
            halconWindow1.Disp_Region(rectangle.rectangle1, "blue", "margin");
            rectangle.rectangle1.Dispose();
        }
        /// <summary>
        /// 框选屏幕银浆范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton11_Click(object sender, EventArgs e)
        {
            Rectangle1 rectangle = halconWindow1.Draw_Rectangle1("blue");
            if (rectangle.rectangle1 != null)
            {
                if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 0)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.ABCam_Left_SilverPaste_ScreenScope, 1, 1);
                }
                else if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 1)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.ABCam_Right_SilverPaste_ScreenScope, 1, 1);
                }
                else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 0)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.CDCam_Left_SilverPaste_ScreenScope, 1, 1);
                }
                else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 1)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.CDCam_Right_SilverPaste_ScreenScope, 1, 1);
                }
                else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 0)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.DownCam_Left_SilverPaste_ScreenScope, 1, 1);
                }
                else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 1)
                {
                    HOperatorSet.CopyObj(rectangle.rectangle1, out nowProduct.DownCam_Right_SilverPaste_ScreenScope, 1, 1);
                }
            }
            halconWindow1.Disp_Region(rectangle.rectangle1, "blue", "margin");
            rectangle.rectangle1.Dispose();
        }
        /// <summary>
        /// 显示银浆位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton8_Click(object sender, EventArgs e)
        {
            if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 0)
            {
                halconWindow1.Disp_Region(nowProduct.ABCam_Left_SilverPaste_Location,"blue","margin");
            }
            else if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 1)
            {
                halconWindow1.Disp_Region(nowProduct.ABCam_Right_SilverPaste_Location, "blue","margin");
            }
            else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 0)
            {
                halconWindow1.Disp_Region(nowProduct.CDCam_Left_SilverPaste_Location, "blue","margin");
            }
            else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 1)
            {
                halconWindow1.Disp_Region(nowProduct.CDCam_Right_SilverPaste_Location, "blue","margin");
            }
            else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 0)
            {
                halconWindow1.Disp_Region(nowProduct.DownCam_Left_SilverPaste_Location, "blue","margin");
            }
            else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 1)
            {
                halconWindow1.Disp_Region(nowProduct.DownCam_Right_SilverPaste_Location, "blue","margin");
            }
        }

        /// <summary>
        /// 显示银浆范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton10_Click(object sender, EventArgs e)
        {
            if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 0)
            {
                halconWindow1.Disp_Region(nowProduct.ABCam_Left_SilverPaste_Scope, "blue", "margin");
            }
            else if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 1)
            {
                halconWindow1.Disp_Region(nowProduct.ABCam_Right_SilverPaste_Scope, "blue", "margin");
            }
            else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 0)
            {
                halconWindow1.Disp_Region(nowProduct.CDCam_Left_SilverPaste_Scope, "blue", "margin");
            }
            else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 1)
            {
                halconWindow1.Disp_Region(nowProduct.CDCam_Right_SilverPaste_Scope, "blue", "margin");
            }
            else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 0)
            {
                halconWindow1.Disp_Region(nowProduct.DownCam_Left_SilverPaste_Scope, "blue", "margin");
            }
            else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 1)
            {
                halconWindow1.Disp_Region(nowProduct.DownCam_Right_SilverPaste_Scope, "blue", "margin");
            }
        }

        /// <summary>
        /// 显示银浆屏幕范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton12_Click(object sender, EventArgs e)
        {
            if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 0)
            {
                halconWindow1.Disp_Region(nowProduct.ABCam_Left_SilverPaste_ScreenScope, "blue", "margin");
            }
            else if (uiComboBox_Cam.SelectedIndex == 0 && uiComboBox_Mark.SelectedIndex == 1)
            {
                halconWindow1.Disp_Region(nowProduct.ABCam_Right_SilverPaste_ScreenScope, "blue", "margin");
            }
            else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 0)
            {
                halconWindow1.Disp_Region(nowProduct.CDCam_Left_SilverPaste_ScreenScope, "blue", "margin");
            }
            else if (uiComboBox_Cam.SelectedIndex == 1 && uiComboBox_Mark.SelectedIndex == 1)
            {
                halconWindow1.Disp_Region(nowProduct.CDCam_Right_SilverPaste_ScreenScope, "blue", "margin");
            }
            else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 0)
            {
                halconWindow1.Disp_Region(nowProduct.DownCam_Left_SilverPaste_ScreenScope, "blue", "margin");
            }
            else if (uiComboBox_Cam.SelectedIndex == 2 && uiComboBox_Mark.SelectedIndex == 1)
            {
                halconWindow1.Disp_Region(nowProduct.DownCam_Right_SilverPaste_ScreenScope, "blue", "margin");
            }
        }

        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            nowProduct.Check_SilverPaste = uiCheckBox1.Checked;
        }
    }
}
