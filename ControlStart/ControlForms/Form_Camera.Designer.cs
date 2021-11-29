
namespace ControlStart.ControlForms
{
    partial class Form_Camera
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
            this.halconWindow1 = new ToolKit.DisplayWindow.HalconWindow();
            this.uiButton_singlePhoto = new Sunny.UI.UIButton();
            this.comboBox_CamList = new Sunny.UI.UIComboBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiDoubleUpDown1 = new Sunny.UI.UIDoubleUpDown();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiIntegerUpDown1 = new Sunny.UI.UIIntegerUpDown();
            this.uiComboBox1 = new Sunny.UI.UIComboBox();
            this.uiRadioButton1 = new Sunny.UI.UIRadioButton();
            this.uiRadioButton2 = new Sunny.UI.UIRadioButton();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.uiButton_SaveConfig = new Sunny.UI.UIButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.uiLabel1.Size = new System.Drawing.Size(677, 33);
            this.uiLabel1.TabIndex = 3;
            this.uiLabel1.Text = "  相  机";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // halconWindow1
            // 
            this.halconWindow1.BackColor = System.Drawing.Color.Transparent;
            this.halconWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halconWindow1.Location = new System.Drawing.Point(0, 0);
            this.halconWindow1.Margin = new System.Windows.Forms.Padding(0);
            this.halconWindow1.Name = "halconWindow1";
            this.tableLayoutPanel1.SetRowSpan(this.halconWindow1, 9);
            this.halconWindow1.Size = new System.Drawing.Size(437, 359);
            this.halconWindow1.TabIndex = 4;
            // 
            // uiButton_singlePhoto
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.uiButton_singlePhoto, 2);
            this.uiButton_singlePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_singlePhoto.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.uiButton_singlePhoto.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.uiButton_singlePhoto.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton_singlePhoto.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton_singlePhoto.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_singlePhoto.Location = new System.Drawing.Point(520, 195);
            this.uiButton_singlePhoto.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_singlePhoto.Name = "uiButton_singlePhoto";
            this.uiButton_singlePhoto.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.uiButton_singlePhoto.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.uiButton_singlePhoto.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton_singlePhoto.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton_singlePhoto.Size = new System.Drawing.Size(120, 26);
            this.uiButton_singlePhoto.Style = Sunny.UI.UIStyle.Colorful;
            this.uiButton_singlePhoto.TabIndex = 5;
            this.uiButton_singlePhoto.Text = "拍    照";
            this.uiButton_singlePhoto.Click += new System.EventHandler(this.uiButton_singlePhoto_Click);
            // 
            // comboBox_CamList
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBox_CamList, 2);
            this.comboBox_CamList.DataSource = null;
            this.comboBox_CamList.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.comboBox_CamList.FillColor = System.Drawing.Color.White;
            this.comboBox_CamList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.comboBox_CamList.Location = new System.Drawing.Point(521, 5);
            this.comboBox_CamList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_CamList.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboBox_CamList.Name = "comboBox_CamList";
            this.comboBox_CamList.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboBox_CamList.Size = new System.Drawing.Size(135, 22);
            this.comboBox_CamList.TabIndex = 6;
            this.comboBox_CamList.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboBox_CamList.SelectedIndexChanged += new System.EventHandler(this.comboBox_CamList_SelectedIndexChanged);
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel2.ForeColor = System.Drawing.Color.White;
            this.uiLabel2.Location = new System.Drawing.Point(440, 0);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(74, 32);
            this.uiLabel2.TabIndex = 7;
            this.uiLabel2.Text = "相机列表:";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel3.ForeColor = System.Drawing.Color.White;
            this.uiLabel3.Location = new System.Drawing.Point(440, 32);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(74, 32);
            this.uiLabel3.TabIndex = 8;
            this.uiLabel3.Text = "曝光时间:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiLabel4
            // 
            this.uiLabel4.AutoSize = true;
            this.uiLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel4.ForeColor = System.Drawing.Color.White;
            this.uiLabel4.Location = new System.Drawing.Point(440, 96);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(74, 32);
            this.uiLabel4.TabIndex = 9;
            this.uiLabel4.Text = "触发模式:";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiLabel5
            // 
            this.uiLabel5.AutoSize = true;
            this.uiLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel5.ForeColor = System.Drawing.Color.White;
            this.uiLabel5.Location = new System.Drawing.Point(440, 128);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(74, 32);
            this.uiLabel5.TabIndex = 10;
            this.uiLabel5.Text = "触 发 源:";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiDoubleUpDown1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.uiDoubleUpDown1, 2);
            this.uiDoubleUpDown1.Decimal = 2;
            this.uiDoubleUpDown1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiDoubleUpDown1.Location = new System.Drawing.Point(521, 37);
            this.uiDoubleUpDown1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiDoubleUpDown1.Maximum = 100000D;
            this.uiDoubleUpDown1.Minimum = 0D;
            this.uiDoubleUpDown1.MinimumSize = new System.Drawing.Size(100, 0);
            this.uiDoubleUpDown1.Name = "uiDoubleUpDown1";
            this.uiDoubleUpDown1.Size = new System.Drawing.Size(135, 22);
            this.uiDoubleUpDown1.TabIndex = 13;
            this.uiDoubleUpDown1.Text = "uiDoubleUpDown1";
            this.uiDoubleUpDown1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiDoubleUpDown1.Value = 0D;
            // 
            // uiLabel6
            // 
            this.uiLabel6.AutoSize = true;
            this.uiLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel6.ForeColor = System.Drawing.Color.White;
            this.uiLabel6.Location = new System.Drawing.Point(440, 64);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(74, 32);
            this.uiLabel6.TabIndex = 14;
            this.uiLabel6.Text = "增      益:";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiIntegerUpDown1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.uiIntegerUpDown1, 2);
            this.uiIntegerUpDown1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiIntegerUpDown1.Location = new System.Drawing.Point(521, 69);
            this.uiIntegerUpDown1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiIntegerUpDown1.Maximum = 40;
            this.uiIntegerUpDown1.Minimum = 0;
            this.uiIntegerUpDown1.MinimumSize = new System.Drawing.Size(100, 0);
            this.uiIntegerUpDown1.Name = "uiIntegerUpDown1";
            this.uiIntegerUpDown1.Size = new System.Drawing.Size(135, 22);
            this.uiIntegerUpDown1.TabIndex = 15;
            this.uiIntegerUpDown1.Text = "uiIntegerUpDown1";
            this.uiIntegerUpDown1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiComboBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.uiComboBox1, 2);
            this.uiComboBox1.DataSource = null;
            this.uiComboBox1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboBox1.FillColor = System.Drawing.Color.White;
            this.uiComboBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboBox1.Items.AddRange(new object[] {
            "Software",
            "Line1",
            "Line2",
            "Line3",
            "Line4"});
            this.uiComboBox1.Location = new System.Drawing.Point(521, 133);
            this.uiComboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox1.Name = "uiComboBox1";
            this.uiComboBox1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox1.Size = new System.Drawing.Size(135, 22);
            this.uiComboBox1.TabIndex = 7;
            this.uiComboBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiRadioButton1
            // 
            this.uiRadioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiRadioButton1.ForeColor = System.Drawing.Color.White;
            this.uiRadioButton1.Location = new System.Drawing.Point(520, 99);
            this.uiRadioButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton1.Name = "uiRadioButton1";
            this.uiRadioButton1.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiRadioButton1.Size = new System.Drawing.Size(74, 26);
            this.uiRadioButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiRadioButton1.TabIndex = 16;
            this.uiRadioButton1.Text = "On";
            // 
            // uiRadioButton2
            // 
            this.uiRadioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiRadioButton2.ForeColor = System.Drawing.Color.White;
            this.uiRadioButton2.Location = new System.Drawing.Point(600, 99);
            this.uiRadioButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton2.Name = "uiRadioButton2";
            this.uiRadioButton2.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiRadioButton2.Size = new System.Drawing.Size(74, 26);
            this.uiRadioButton2.Style = Sunny.UI.UIStyle.Custom;
            this.uiRadioButton2.TabIndex = 17;
            this.uiRadioButton2.Text = "Off";
            // 
            // uiButton1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.uiButton1, 2);
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.uiButton1.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.uiButton1.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton1.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(520, 227);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.uiButton1.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.uiButton1.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton1.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton1.Size = new System.Drawing.Size(120, 26);
            this.uiButton1.Style = Sunny.UI.UIStyle.Colorful;
            this.uiButton1.TabIndex = 18;
            this.uiButton1.Text = "实时模式";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiButton2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.uiButton2, 2);
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.uiButton2.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.uiButton2.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton2.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Location = new System.Drawing.Point(520, 259);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.uiButton2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.uiButton2.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton2.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton2.Size = new System.Drawing.Size(120, 27);
            this.uiButton2.Style = Sunny.UI.UIStyle.Colorful;
            this.uiButton2.TabIndex = 19;
            this.uiButton2.Text = "保存图片";
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uiButton_SaveConfig
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.uiButton_SaveConfig, 2);
            this.uiButton_SaveConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_SaveConfig.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.uiButton_SaveConfig.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.uiButton_SaveConfig.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton_SaveConfig.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton_SaveConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_SaveConfig.Location = new System.Drawing.Point(520, 163);
            this.uiButton_SaveConfig.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_SaveConfig.Name = "uiButton_SaveConfig";
            this.uiButton_SaveConfig.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.uiButton_SaveConfig.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.uiButton_SaveConfig.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton_SaveConfig.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.uiButton_SaveConfig.Size = new System.Drawing.Size(120, 26);
            this.uiButton_SaveConfig.Style = Sunny.UI.UIStyle.Colorful;
            this.uiButton_SaveConfig.TabIndex = 20;
            this.uiButton_SaveConfig.Text = "保存参数";
            this.uiButton_SaveConfig.Click += new System.EventHandler(this.uiButton_SaveConfig_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.uiLabel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.halconWindow1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiButton_SaveConfig, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_CamList, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiDoubleUpDown1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiIntegerUpDown1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiComboBox1, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.uiRadioButton2, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiRadioButton1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiButton_singlePhoto, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.uiButton1, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.uiButton2, 2, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(677, 359);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // Form_Camera
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.uiLabel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_Camera";
            this.Size = new System.Drawing.Size(677, 392);
            this.Load += new System.EventHandler(this.Camera_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private ToolKit.DisplayWindow.HalconWindow halconWindow1;
        private Sunny.UI.UIButton uiButton_singlePhoto;
        private Sunny.UI.UIComboBox comboBox_CamList;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIDoubleUpDown uiDoubleUpDown1;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIIntegerUpDown uiIntegerUpDown1;
        private Sunny.UI.UIComboBox uiComboBox1;
        private Sunny.UI.UIRadioButton uiRadioButton1;
        private Sunny.UI.UIRadioButton uiRadioButton2;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton_SaveConfig;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
