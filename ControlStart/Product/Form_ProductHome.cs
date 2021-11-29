using ControlStart.Config;
using ControlStart.ControlForms;
using ControlStart.Helper;
using ControlStart.Utils;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolKit.HYControls;
using ToolKit.HYControls.HYForm;

namespace ControlStart.Product
{
    public partial class Form_ProductHome : UserControl
    {
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var parms = base.CreateParams;
        //        parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN
        //        return parms;
        //    }
        //}
        public Form_ProductHome()
        {
            InitializeComponent();
            //this.Dock = DockStyle.Fill;

        }
        public Form_ProductAddorUpData form_ProductAddorUpData;
        public Form_ProductSet form_ProductSet;
        private void btn_Add_Click(object sender, EventArgs e)
        {
            form_ProductSet.SwitchForm_ProductAddorUpData();
        }

        private void btn_UpData_Click(object sender, EventArgs e)
        {
            if (label_NowProductName.Text != "")
            {
                form_ProductSet.SwitchForm_ProductAddorUpData(label_NowProductName.Text);
                Global.Instance.RunningLog.WriteRunLog("修改产品:" + label_NowProductName.Text);
            }
            else
            {
                HYMessageBox.ShowWarn("请先选择产品!");
            }
        }

        public void btn_Refresh_Click(object sender, EventArgs e)
        {
            HYForm_Waiting form_Waiting = new HYForm_Waiting(RefreshWork, "加载全部产品中,请稍等...");
            form_Waiting.ShowDialog();

        }

        private void RefreshWork(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate { flowLayoutPanel1.Controls.Clear(); }));
            DirectoryInfo theFolder = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + "\\Vision_Product");
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();//获取所在目录的文件夹
            FileInfo[] file = theFolder.GetFiles();//获取所在目录的文件
            foreach (FileInfo fileItem in file) //遍历文件
            {
                if (fileItem.Name.EndsWith(".pro"))
                {
                    Task.Run(() =>
                    {
                        string filepath = fileItem.DirectoryName + @"\" + fileItem.Name;
                        try
                        {
                            ProductConfig productConfig = (ProductConfig)Serialization.Read2(filepath);
                            HYProductInfo hYProductInfo = new HYProductInfo();
                            hYProductInfo.ProductName = productConfig.ProductName;
                            hYProductInfo.CreateTime = productConfig.CreateTime;
                            productConfig.ProductImage.Dispose();
                            hYProductInfo.DblClick += this.ProductInfo_DblClick;
                            hYProductInfo.Click += this.ProductInfo_Click;
                            flowLayoutPanel1.Invoke(new Action(delegate { flowLayoutPanel1.Controls.Add(hYProductInfo); }));
                        }
                        catch (Exception)
                        {
                            File.Delete(filepath);
                            Global.Instance.RunningLog.WriteErrorLog("产品:" + fileItem.Name + "初始化错误,已自动删除.");

                        }
                    });
                }
            }
        }

        private void ProductInfo_Click(object sender, EventArgs e)
        {
            foreach (HYProductInfo item in flowLayoutPanel1.Controls)
            {
                if (item == (sender as HYProductInfo))
                    item.ShowBorder = true;
                else
                    item.ShowBorder = false;
            }

            ProductConfig clickProduct = (ProductConfig)Serialization.Read2(System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + (sender as HYProductInfo).ProductName + ".pro");
            halconWindow1.Disp_Image(clickProduct.ProductImage);
            clickProduct.ProductImage.Dispose();
        }

        private void ProductInfo_DblClick(object sender, EventArgs e)
        {
            label_NowProductName.Invoke(new Action(delegate
            {
                label_NowProductName.Text = (sender as HYProductInfo).ProductName;
            }));

        }



        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (label_NowProductName.Text != "")
            {
                if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + label_NowProductName.Text + ".pro"))
                {
                    if (HYMessageBox.ShowWarn("确认删除产品?") == DialogResult.OK)
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + label_NowProductName.Text + ".pro");
                        if (label_NowProductName.Text == Global.Instance.NowProduct?.ProductName)
                        {
                            Global.Instance.NowProduct = null;
                        }
                        Global.Instance.RunningLog.WriteRunLog("删除产品:" + label_NowProductName.Text);
                        label_NowProductName.Text = "";
                        HYMessageBox.ShowNormal("删除成功");
                        btn_Refresh_Click(sender, e);
                    }
                }
            }
            else
            {
                HYMessageBox.ShowWarn("请先选择产品!");
            }

        }

        private void Form_ProductHome_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.GetType().GetProperty
             ("DoubleBuffered", System.Reflection.BindingFlags.Instance
              | System.Reflection.BindingFlags.NonPublic)
             .SetValue(flowLayoutPanel1, true, null);
            btn_Refresh_Click(sender, e);
        }

        private void btn_Switch_Click(object sender, EventArgs e)
        {
            if (label_NowProductName.Text != "")
            {
                if (label_NowProductName.Text == Global.Instance.NowProduct?.ProductName)
                {
                    Global.Instance.NowProduct = (ProductConfig)Serialization.Read2(System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + label_NowProductName.Text + ".pro");
                    HYMessageBox.ShowWarn("带切换产品就是当前产品无需切换,已重新加载数据");
                    return;
                }

                if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + label_NowProductName.Text + ".pro"))
                {
                    Form_ProductSwitch form_ProductSwitch = new Form_ProductSwitch();
                    if (Global.Instance.NowProduct == null)
                    {
                        try
                        {
                            Global.Instance.NowProduct = (ProductConfig)Serialization.Read2(System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + label_NowProductName.Text + ".pro");
                            HYMessageBox.ShowNormal("切换成功");
                            Global.Instance.RunningLog.WriteRunLog("切换产品:" + label_NowProductName.Text + ",成功");
                        }
                        catch (Exception)
                        {
                            HYMessageBox.ShowNormal("切换失败");
                            Global.Instance.RunningLog.WriteRunLog("切换产品:" + label_NowProductName.Text + ",失败");
                        }
                    }
                    else
                    {
                        if (form_ProductSwitch.Popup(Global.Instance.NowProduct?.ProductName, label_NowProductName.Text) == DialogResult.OK)
                        {
                            try
                            {
                                Global.Instance.NowProduct = (ProductConfig)Serialization.Read2(System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + label_NowProductName.Text + ".pro");
                                HYMessageBox.ShowNormal("切换成功");
                                Global.Instance.RunningLog.WriteRunLog("切换产品:" + label_NowProductName.Text + ",成功");
                            }
                            catch (Exception)
                            {
                                HYMessageBox.ShowNormal("切换失败");
                                Global.Instance.RunningLog.WriteRunLog("切换产品:" + label_NowProductName.Text + ",失败");
                            }
                        }
                    }
                }
            }
            else
            {
                HYMessageBox.ShowWarn("请先选择产品!");
            }

        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            if (label_NowProductName.Text != "")
            {
                if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + label_NowProductName.Text + ".pro"))
                {
                    ProductConfig NowProduct = (ProductConfig)Serialization.Read2(System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + label_NowProductName.Text + ".pro");
                    try
                    {
                    step:
                        string name = "";
                        if (HYInputDialog.InputStringDialog(ref name, true, "请输入新的产品名:", true))
                        {
                            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + name + ".pro"))
                            {
                                HYMessageBox.ShowWarn("改产品名存在,请修改.");
                                goto step;
                            }
                            NowProduct.ProductName = name;
                            NowProduct.CreateTime = DateTime.Now;
                            HYForm_Waiting form_Waiting = new HYForm_Waiting(delegate
                            {
                                Serialization.Save2(NowProduct, System.Windows.Forms.Application.StartupPath + "\\Vision_Product\\" + NowProduct.ProductName + ".pro");
                                Global.Instance.RunningLog.WriteRunLog("复制产品:[" + NowProduct.ProductName + "],成功");
                                HYMessageBox.ShowNormal("复制成功");

                            }, "正在复制产品数据,请稍等!");
                            form_Waiting.ShowDialog();
                            btn_Refresh_Click(sender, e);
                        }
                    }
                    catch (Exception)
                    {
                        HYMessageBox.ShowError("复制失败");
                    }
                }
            }
            else
            {
                HYMessageBox.ShowWarn("请先选择产品!");
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
