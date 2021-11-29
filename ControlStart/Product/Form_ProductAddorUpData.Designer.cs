
namespace ControlStart.Product
{
    partial class Form_ProductAddorUpData
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
            this.btn_Return = new Sunny.UI.UISymbolButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.halconWindow1 = new ToolKit.DisplayWindow.HalconWindow();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hyCreateModel21 = new ToolKit.HYControls.HYCreateModel2();
            this.btn_Save = new Sunny.UI.UISymbolButton();
            this.uiButton12 = new Sunny.UI.UIButton();
            this.uiButton11 = new Sunny.UI.UIButton();
            this.uiButton10 = new Sunny.UI.UIButton();
            this.uiComboBox_Cam = new Sunny.UI.UIComboBox();
            this.uiButton8 = new Sunny.UI.UIButton();
            this.uiComboBox_Mark = new Sunny.UI.UIComboBox();
            this.uiButton_Disp = new Sunny.UI.UIButton();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiButton9 = new Sunny.UI.UIButton();
            this.uiButton7 = new Sunny.UI.UIButton();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiButton_TakePhotos = new Sunny.UI.UIButton();
            this.uiCheckBox1 = new Sunny.UI.UICheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiLabel1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold);
            this.uiLabel1.ForeColor = System.Drawing.Color.White;
            this.uiLabel1.Location = new System.Drawing.Point(0, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(677, 30);
            this.uiLabel1.TabIndex = 5;
            this.uiLabel1.Text = "  产品添加";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Return
            // 
            this.btn_Return.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Return.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_Return.CircleRectWidth = 0;
            this.btn_Return.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Return.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_Return.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(160)))), ((int)(((byte)(165)))));
            this.btn_Return.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(123)))), ((int)(((byte)(129)))));
            this.btn_Return.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(123)))), ((int)(((byte)(129)))));
            this.btn_Return.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Return.Location = new System.Drawing.Point(602, 0);
            this.btn_Return.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Return.Name = "btn_Return";
            this.btn_Return.Radius = 0;
            this.btn_Return.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.btn_Return.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btn_Return.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(160)))), ((int)(((byte)(165)))));
            this.btn_Return.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(123)))), ((int)(((byte)(129)))));
            this.btn_Return.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(123)))), ((int)(((byte)(129)))));
            this.btn_Return.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btn_Return.Size = new System.Drawing.Size(80, 29);
            this.btn_Return.Style = Sunny.UI.UIStyle.Custom;
            this.btn_Return.StyleCustomMode = true;
            this.btn_Return.Symbol = 61730;
            this.btn_Return.SymbolSize = 20;
            this.btn_Return.TabIndex = 6;
            this.btn_Return.Text = "返回";
            this.btn_Return.Click += new System.EventHandler(this.btn_Return_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.91581F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.08419F));
            this.tableLayoutPanel1.Controls.Add(this.halconWindow1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(677, 362);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // halconWindow1
            // 
            this.halconWindow1.BackColor = System.Drawing.Color.Transparent;
            this.halconWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halconWindow1.Location = new System.Drawing.Point(0, 0);
            this.halconWindow1.Margin = new System.Windows.Forms.Padding(0);
            this.halconWindow1.Name = "halconWindow1";
            this.halconWindow1.Size = new System.Drawing.Size(277, 362);
            this.halconWindow1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiCheckBox1);
            this.panel1.Controls.Add(this.hyCreateModel21);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.uiButton12);
            this.panel1.Controls.Add(this.uiButton11);
            this.panel1.Controls.Add(this.uiButton10);
            this.panel1.Controls.Add(this.uiComboBox_Cam);
            this.panel1.Controls.Add(this.uiButton8);
            this.panel1.Controls.Add(this.uiComboBox_Mark);
            this.panel1.Controls.Add(this.uiButton_Disp);
            this.panel1.Controls.Add(this.uiLabel3);
            this.panel1.Controls.Add(this.uiButton9);
            this.panel1.Controls.Add(this.uiButton7);
            this.panel1.Controls.Add(this.uiLabel2);
            this.panel1.Controls.Add(this.uiButton_TakePhotos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(280, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 356);
            this.panel1.TabIndex = 9;
            // 
            // hyCreateModel21
            // 
            this.hyCreateModel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.hyCreateModel21.Draw = false;
            this.hyCreateModel21.HalconWindow = this.halconWindow1;
            this.hyCreateModel21.Index = 0;
            this.hyCreateModel21.Location = new System.Drawing.Point(3, 30);
            this.hyCreateModel21.Margin = new System.Windows.Forms.Padding(0);
            this.hyCreateModel21.Name = "hyCreateModel21";
            this.hyCreateModel21.Size = new System.Drawing.Size(266, 293);
            this.hyCreateModel21.TabIndex = 25;
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_Save.CircleRectWidth = 0;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_Save.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(160)))), ((int)(((byte)(165)))));
            this.btn_Save.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(123)))), ((int)(((byte)(129)))));
            this.btn_Save.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(123)))), ((int)(((byte)(129)))));
            this.btn_Save.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Save.Location = new System.Drawing.Point(269, 326);
            this.btn_Save.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Radius = 0;
            this.btn_Save.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.btn_Save.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btn_Save.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(160)))), ((int)(((byte)(165)))));
            this.btn_Save.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(123)))), ((int)(((byte)(129)))));
            this.btn_Save.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(123)))), ((int)(((byte)(129)))));
            this.btn_Save.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btn_Save.Size = new System.Drawing.Size(122, 27);
            this.btn_Save.Style = Sunny.UI.UIStyle.Custom;
            this.btn_Save.StyleCustomMode = true;
            this.btn_Save.Symbol = 61639;
            this.btn_Save.SymbolSize = 20;
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "保存";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // uiButton12
            // 
            this.uiButton12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton12.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiButton12.Location = new System.Drawing.Point(272, 293);
            this.uiButton12.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton12.Name = "uiButton12";
            this.uiButton12.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiButton12.Size = new System.Drawing.Size(110, 25);
            this.uiButton12.TabIndex = 24;
            this.uiButton12.Text = "显示屏幕银浆范围";
            // 
            // uiButton11
            // 
            this.uiButton11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton11.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiButton11.Location = new System.Drawing.Point(272, 161);
            this.uiButton11.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton11.Name = "uiButton11";
            this.uiButton11.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiButton11.Size = new System.Drawing.Size(110, 25);
            this.uiButton11.TabIndex = 23;
            this.uiButton11.Text = "框选屏幕银浆范围";
            // 
            // uiButton10
            // 
            this.uiButton10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiButton10.Location = new System.Drawing.Point(272, 260);
            this.uiButton10.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton10.Name = "uiButton10";
            this.uiButton10.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiButton10.Size = new System.Drawing.Size(110, 25);
            this.uiButton10.TabIndex = 22;
            this.uiButton10.Text = "显示银浆范围";
            // 
            // uiComboBox_Cam
            // 
            this.uiComboBox_Cam.DataSource = null;
            this.uiComboBox_Cam.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboBox_Cam.FillColor = System.Drawing.Color.White;
            this.uiComboBox_Cam.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiComboBox_Cam.Items.AddRange(new object[] {
            "ABCam",
            "CDCam",
            "DownCam"});
            this.uiComboBox_Cam.Location = new System.Drawing.Point(51, 5);
            this.uiComboBox_Cam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_Cam.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_Cam.Name = "uiComboBox_Cam";
            this.uiComboBox_Cam.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_Cam.Size = new System.Drawing.Size(69, 21);
            this.uiComboBox_Cam.TabIndex = 9;
            this.uiComboBox_Cam.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_Cam.SelectedIndexChanged += new System.EventHandler(this.uiComboBox1_SelectedIndexChanged);
            // 
            // uiButton8
            // 
            this.uiButton8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiButton8.Location = new System.Drawing.Point(272, 227);
            this.uiButton8.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton8.Name = "uiButton8";
            this.uiButton8.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiButton8.Size = new System.Drawing.Size(110, 25);
            this.uiButton8.TabIndex = 20;
            this.uiButton8.Text = "显示银浆位置";
            // 
            // uiComboBox_Mark
            // 
            this.uiComboBox_Mark.DataSource = null;
            this.uiComboBox_Mark.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboBox_Mark.FillColor = System.Drawing.Color.White;
            this.uiComboBox_Mark.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiComboBox_Mark.Items.AddRange(new object[] {
            "左Mark",
            "右Mark"});
            this.uiComboBox_Mark.Location = new System.Drawing.Point(183, 5);
            this.uiComboBox_Mark.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_Mark.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_Mark.Name = "uiComboBox_Mark";
            this.uiComboBox_Mark.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_Mark.Size = new System.Drawing.Size(78, 21);
            this.uiComboBox_Mark.TabIndex = 11;
            this.uiComboBox_Mark.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_Mark.SelectedIndexChanged += new System.EventHandler(this.uiComboBox1_SelectedIndexChanged);
            // 
            // uiButton_Disp
            // 
            this.uiButton_Disp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_Disp.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiButton_Disp.Location = new System.Drawing.Point(272, 194);
            this.uiButton_Disp.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_Disp.Name = "uiButton_Disp";
            this.uiButton_Disp.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiButton_Disp.Size = new System.Drawing.Size(110, 25);
            this.uiButton_Disp.TabIndex = 14;
            this.uiButton_Disp.Text = "显示图片";
            this.uiButton_Disp.Click += new System.EventHandler(this.uiButton_Disp_Click);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel3.ForeColor = System.Drawing.Color.White;
            this.uiLabel3.Location = new System.Drawing.Point(127, 5);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(49, 21);
            this.uiLabel3.TabIndex = 12;
            this.uiLabel3.Text = "Mark:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiButton9
            // 
            this.uiButton9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiButton9.Location = new System.Drawing.Point(272, 128);
            this.uiButton9.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton9.Name = "uiButton9";
            this.uiButton9.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiButton9.Size = new System.Drawing.Size(110, 25);
            this.uiButton9.TabIndex = 21;
            this.uiButton9.Text = "框选银浆范围";
            // 
            // uiButton7
            // 
            this.uiButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiButton7.Location = new System.Drawing.Point(272, 95);
            this.uiButton7.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton7.Name = "uiButton7";
            this.uiButton7.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiButton7.Size = new System.Drawing.Size(110, 25);
            this.uiButton7.TabIndex = 19;
            this.uiButton7.Text = "框选银浆位置";
            this.uiButton7.Click += new System.EventHandler(this.uiButton7_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel2.ForeColor = System.Drawing.Color.White;
            this.uiLabel2.Location = new System.Drawing.Point(6, 5);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(38, 21);
            this.uiLabel2.TabIndex = 10;
            this.uiLabel2.Text = "相机:";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiButton_TakePhotos
            // 
            this.uiButton_TakePhotos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_TakePhotos.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiButton_TakePhotos.Location = new System.Drawing.Point(272, 30);
            this.uiButton_TakePhotos.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_TakePhotos.Name = "uiButton_TakePhotos";
            this.uiButton_TakePhotos.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiButton_TakePhotos.Size = new System.Drawing.Size(110, 25);
            this.uiButton_TakePhotos.TabIndex = 13;
            this.uiButton_TakePhotos.Text = "拍    照";
            this.uiButton_TakePhotos.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiCheckBox1.ForeColor = System.Drawing.Color.White;
            this.uiCheckBox1.Location = new System.Drawing.Point(269, 61);
            this.uiCheckBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox1.Size = new System.Drawing.Size(113, 29);
            this.uiCheckBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiCheckBox1.TabIndex = 26;
            this.uiCheckBox1.Text = "银浆检测";
            // 
            // Form_ProductAddorUpData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_Return);
            this.Controls.Add(this.uiLabel1);
            this.DoubleBuffered = true;
            this.Name = "Form_ProductAddorUpData";
            this.Size = new System.Drawing.Size(677, 392);
            this.Load += new System.EventHandler(this.Form_ProductAddorUpData_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UISymbolButton btn_Return;
        private ToolKit.DisplayWindow.HalconWindow halconWindow1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UISymbolButton btn_Save;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox uiComboBox_Cam;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIComboBox uiComboBox_Mark;
        private Sunny.UI.UIButton uiButton_TakePhotos;
        private Sunny.UI.UIButton uiButton_Disp;
        private Sunny.UI.UIButton uiButton12;
        private Sunny.UI.UIButton uiButton11;
        private Sunny.UI.UIButton uiButton10;
        private Sunny.UI.UIButton uiButton9;
        private Sunny.UI.UIButton uiButton8;
   
        private Sunny.UI.UIButton uiButton7;
        private ToolKit.HYControls.HYCreateModel2 hyCreateModel21;
        private Sunny.UI.UICheckBox uiCheckBox1;
    }
}
