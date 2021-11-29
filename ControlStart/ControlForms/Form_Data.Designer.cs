
namespace ControlStart.ControlForms
{
    partial class Form_Data
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
            this.uiRoundProcess2 = new Sunny.UI.UIRoundProcess();
            this.uiRoundProcess1 = new Sunny.UI.UIRoundProcess();
            this.uiRoundProcess3 = new Sunny.UI.UIRoundProcess();
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
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 4;
            this.uiLabel1.Text = "  数  据";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiRoundProcess2
            // 
            this.uiRoundProcess2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRoundProcess2.Location = new System.Drawing.Point(11, 39);
            this.uiRoundProcess2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRoundProcess2.Name = "uiRoundProcess2";
            this.uiRoundProcess2.Outer = 40;
            this.uiRoundProcess2.ShowProcess = true;
            this.uiRoundProcess2.Size = new System.Drawing.Size(81, 81);
            this.uiRoundProcess2.TabIndex = 11;
            this.uiRoundProcess2.Text = "50.0%";
            this.uiRoundProcess2.Value = 50;
            // 
            // uiRoundProcess1
            // 
            this.uiRoundProcess1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRoundProcess1.Location = new System.Drawing.Point(98, 39);
            this.uiRoundProcess1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRoundProcess1.Name = "uiRoundProcess1";
            this.uiRoundProcess1.Outer = 40;
            this.uiRoundProcess1.ShowProcess = true;
            this.uiRoundProcess1.Size = new System.Drawing.Size(81, 81);
            this.uiRoundProcess1.TabIndex = 12;
            this.uiRoundProcess1.Text = "75.0%";
            this.uiRoundProcess1.Value = 75;
            // 
            // uiRoundProcess3
            // 
            this.uiRoundProcess3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRoundProcess3.Location = new System.Drawing.Point(185, 39);
            this.uiRoundProcess3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRoundProcess3.Name = "uiRoundProcess3";
            this.uiRoundProcess3.Outer = 40;
            this.uiRoundProcess3.ShowProcess = true;
            this.uiRoundProcess3.Size = new System.Drawing.Size(81, 81);
            this.uiRoundProcess3.TabIndex = 13;
            this.uiRoundProcess3.Text = "22.0%";
            this.uiRoundProcess3.Value = 22;
            // 
            // Form_Data
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.uiRoundProcess3);
            this.Controls.Add(this.uiRoundProcess1);
            this.Controls.Add(this.uiRoundProcess2);
            this.Controls.Add(this.uiLabel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form_Data";
            this.Size = new System.Drawing.Size(677, 392);
            this.Load += new System.EventHandler(this.Form_Data_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIRoundProcess uiRoundProcess2;
        private Sunny.UI.UIRoundProcess uiRoundProcess1;
        private Sunny.UI.UIRoundProcess uiRoundProcess3;
    }
}
