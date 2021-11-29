
namespace ControlStart.ControlForms
{
    partial class Form_Home
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.autoHalconWindow1 = new ToolKit.DisplayWindow.AutoHalconWindow();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiLabel1.Font = new System.Drawing.Font("楷体", 18F, System.Drawing.FontStyle.Bold);
            this.uiLabel1.ForeColor = System.Drawing.Color.White;
            this.uiLabel1.Location = new System.Drawing.Point(0, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(677, 36);
            this.uiLabel1.TabIndex = 4;
            this.uiLabel1.Text = "  主 页 面";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // autoHalconWindow1
            // 
            this.autoHalconWindow1.CameraNames = new string[0];
            this.autoHalconWindow1.Count = 0;
            this.autoHalconWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoHalconWindow1.Location = new System.Drawing.Point(0, 36);
            this.autoHalconWindow1.Margin = new System.Windows.Forms.Padding(0);
            this.autoHalconWindow1.Name = "autoHalconWindow1";
            this.autoHalconWindow1.Size = new System.Drawing.Size(677, 356);
            this.autoHalconWindow1.TabIndex = 5;
            // 
            // Form_Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.autoHalconWindow1);
            this.Controls.Add(this.uiLabel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_Home";
            this.Size = new System.Drawing.Size(677, 392);
            this.Load += new System.EventHandler(this.Form_Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private ToolKit.DisplayWindow.AutoHalconWindow autoHalconWindow1;
    }
}
