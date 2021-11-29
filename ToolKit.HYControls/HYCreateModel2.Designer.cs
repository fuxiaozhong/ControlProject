
namespace ToolKit.HYControls
{
    partial class HYCreateModel2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button8 = new System.Windows.Forms.Button();
            this.model_DispFindRegion = new System.Windows.Forms.CheckBox();
            this.model_DispModel = new System.Windows.Forms.CheckBox();
            this.model_findRegionEnable = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.model_contrastAuto = new System.Windows.Forms.CheckBox();
            this.model_contrast = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.model_polarity = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.model_maxScale = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.model_minScale = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.model_angleRange = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.model_startAngle = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.model_angleStep = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.model_matchNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.model_minScore = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示模板图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示模板区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示搜索区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试查找ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new ToolKit.HYControls.HYTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.displayWindow2 = new ToolKit.DisplayWindow.HalconWindow();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.model_Shple = new System.Windows.Forms.RadioButton();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.model_contrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_maxScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_minScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_angleRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_startAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_angleStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_matchNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_minScore)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel2.SetColumnSpan(this.button8, 2);
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(150)))));
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(200)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(163, 183);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.tableLayoutPanel2.SetRowSpan(this.button8, 2);
            this.button8.Size = new System.Drawing.Size(90, 25);
            this.button8.TabIndex = 16;
            this.button8.Text = "框选搜索范围";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // model_DispFindRegion
            // 
            this.model_DispFindRegion.Checked = true;
            this.model_DispFindRegion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel2.SetColumnSpan(this.model_DispFindRegion, 2);
            this.model_DispFindRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.model_DispFindRegion.Location = new System.Drawing.Point(4, 208);
            this.model_DispFindRegion.Margin = new System.Windows.Forms.Padding(4);
            this.model_DispFindRegion.Name = "model_DispFindRegion";
            this.model_DispFindRegion.Size = new System.Drawing.Size(123, 32);
            this.model_DispFindRegion.TabIndex = 23;
            this.model_DispFindRegion.Text = "显示搜索区域";
            this.model_DispFindRegion.UseVisualStyleBackColor = true;
            this.model_DispFindRegion.CheckedChanged += new System.EventHandler(this.model_findRegionEnable_CheckedChanged);
            // 
            // model_DispModel
            // 
            this.model_DispModel.Checked = true;
            this.model_DispModel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel2.SetColumnSpan(this.model_DispModel, 2);
            this.model_DispModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.model_DispModel.Location = new System.Drawing.Point(4, 183);
            this.model_DispModel.Margin = new System.Windows.Forms.Padding(4);
            this.model_DispModel.Name = "model_DispModel";
            this.model_DispModel.Size = new System.Drawing.Size(123, 17);
            this.model_DispModel.TabIndex = 22;
            this.model_DispModel.Text = "显示模板";
            this.model_DispModel.UseVisualStyleBackColor = true;
            this.model_DispModel.CheckedChanged += new System.EventHandler(this.model_findRegionEnable_CheckedChanged);
            // 
            // model_findRegionEnable
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.model_findRegionEnable, 2);
            this.model_findRegionEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.model_findRegionEnable.Location = new System.Drawing.Point(135, 156);
            this.model_findRegionEnable.Margin = new System.Windows.Forms.Padding(4);
            this.model_findRegionEnable.Name = "model_findRegionEnable";
            this.model_findRegionEnable.Size = new System.Drawing.Size(118, 19);
            this.model_findRegionEnable.TabIndex = 21;
            this.model_findRegionEnable.Text = "启用";
            this.model_findRegionEnable.UseVisualStyleBackColor = true;
            this.model_findRegionEnable.CheckedChanged += new System.EventHandler(this.model_findRegionEnable_CheckedChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "矩形",
            "仿矩",
            "圆",
            "椭圆"});
            this.comboBox2.Location = new System.Drawing.Point(58, 156);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(69, 25);
            this.comboBox2.TabIndex = 20;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(4, 152);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 27);
            this.label11.TabIndex = 19;
            this.label11.Text = "搜索:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // model_contrastAuto
            // 
            this.model_contrastAuto.Checked = true;
            this.model_contrastAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel2.SetColumnSpan(this.model_contrastAuto, 2);
            this.model_contrastAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.model_contrastAuto.Location = new System.Drawing.Point(135, 131);
            this.model_contrastAuto.Margin = new System.Windows.Forms.Padding(4);
            this.model_contrastAuto.Name = "model_contrastAuto";
            this.model_contrastAuto.Size = new System.Drawing.Size(118, 17);
            this.model_contrastAuto.TabIndex = 18;
            this.model_contrastAuto.Text = "自动";
            this.model_contrastAuto.UseVisualStyleBackColor = true;
            this.model_contrastAuto.CheckedChanged += new System.EventHandler(this.Model_contrastAuto_CheckedChanged);
            // 
            // model_contrast
            // 
            this.model_contrast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.model_contrast.Enabled = false;
            this.model_contrast.Location = new System.Drawing.Point(58, 131);
            this.model_contrast.Margin = new System.Windows.Forms.Padding(4);
            this.model_contrast.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.model_contrast.Name = "model_contrast";
            this.model_contrast.Size = new System.Drawing.Size(69, 23);
            this.model_contrast.TabIndex = 17;
            this.model_contrast.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.model_contrast.ValueChanged += new System.EventHandler(this.model_minScore_ValueChanged);
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(4, 127);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 25);
            this.label10.TabIndex = 16;
            this.label10.Text = "阈值:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // model_polarity
            // 
            this.model_polarity.DropDownHeight = 80;
            this.model_polarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.model_polarity.FormattingEnabled = true;
            this.model_polarity.IntegralHeight = false;
            this.model_polarity.Items.AddRange(new object[] {
            "使用极性",
            "忽略极性"});
            this.model_polarity.Location = new System.Drawing.Point(58, 104);
            this.model_polarity.Margin = new System.Windows.Forms.Padding(4);
            this.model_polarity.Name = "model_polarity";
            this.model_polarity.Size = new System.Drawing.Size(69, 25);
            this.model_polarity.TabIndex = 15;
            this.model_polarity.SelectedIndexChanged += new System.EventHandler(this.model_polarity_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(4, 100);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 27);
            this.label9.TabIndex = 14;
            this.label9.Text = "极性:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // model_maxScale
            // 
            this.model_maxScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.model_maxScale.DecimalPlaces = 2;
            this.model_maxScale.Location = new System.Drawing.Point(179, 79);
            this.model_maxScale.Margin = new System.Windows.Forms.Padding(4);
            this.model_maxScale.Name = "model_maxScale";
            this.model_maxScale.Size = new System.Drawing.Size(74, 23);
            this.model_maxScale.TabIndex = 13;
            this.model_maxScale.Value = new decimal(new int[] {
            11,
            0,
            0,
            65536});
            this.model_maxScale.ValueChanged += new System.EventHandler(this.model_minScore_ValueChanged);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(135, 75);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "~";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // model_minScale
            // 
            this.model_minScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.model_minScale.DecimalPlaces = 2;
            this.model_minScale.Location = new System.Drawing.Point(58, 79);
            this.model_minScale.Margin = new System.Windows.Forms.Padding(4);
            this.model_minScale.Name = "model_minScale";
            this.model_minScale.Size = new System.Drawing.Size(69, 23);
            this.model_minScale.TabIndex = 11;
            this.model_minScale.Value = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            this.model_minScale.ValueChanged += new System.EventHandler(this.model_minScore_ValueChanged);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(4, 75);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "缩放:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // model_angleRange
            // 
            this.model_angleRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.model_angleRange.Location = new System.Drawing.Point(179, 54);
            this.model_angleRange.Margin = new System.Windows.Forms.Padding(4);
            this.model_angleRange.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.model_angleRange.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.model_angleRange.Name = "model_angleRange";
            this.model_angleRange.Size = new System.Drawing.Size(74, 23);
            this.model_angleRange.TabIndex = 9;
            this.model_angleRange.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.model_angleRange.ValueChanged += new System.EventHandler(this.model_minScore_ValueChanged);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(135, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "~";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // model_startAngle
            // 
            this.model_startAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.model_startAngle.Location = new System.Drawing.Point(58, 54);
            this.model_startAngle.Margin = new System.Windows.Forms.Padding(4);
            this.model_startAngle.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.model_startAngle.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.model_startAngle.Name = "model_startAngle";
            this.model_startAngle.Size = new System.Drawing.Size(69, 23);
            this.model_startAngle.TabIndex = 7;
            this.model_startAngle.Value = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.model_startAngle.ValueChanged += new System.EventHandler(this.model_minScore_ValueChanged);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(4, 50);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "角度:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // model_angleStep
            // 
            this.model_angleStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.model_angleStep.Location = new System.Drawing.Point(58, 29);
            this.model_angleStep.Margin = new System.Windows.Forms.Padding(4);
            this.model_angleStep.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.model_angleStep.Name = "model_angleStep";
            this.model_angleStep.Size = new System.Drawing.Size(69, 23);
            this.model_angleStep.TabIndex = 5;
            this.model_angleStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.model_angleStep.ValueChanged += new System.EventHandler(this.model_minScore_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "步长:";
            // 
            // model_matchNum
            // 
            this.model_matchNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.model_matchNum.Location = new System.Drawing.Point(179, 4);
            this.model_matchNum.Margin = new System.Windows.Forms.Padding(4);
            this.model_matchNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.model_matchNum.Name = "model_matchNum";
            this.model_matchNum.Size = new System.Drawing.Size(74, 23);
            this.model_matchNum.TabIndex = 3;
            this.model_matchNum.ValueChanged += new System.EventHandler(this.model_minScore_ValueChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(135, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "个数:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // model_minScore
            // 
            this.model_minScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.model_minScore.DecimalPlaces = 1;
            this.model_minScore.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.model_minScore.Location = new System.Drawing.Point(58, 4);
            this.model_minScore.Margin = new System.Windows.Forms.Padding(4);
            this.model_minScore.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.model_minScore.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.model_minScore.Name = "model_minScore";
            this.model_minScore.Size = new System.Drawing.Size(69, 23);
            this.model_minScore.TabIndex = 1;
            this.model_minScore.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.model_minScore.ValueChanged += new System.EventHandler(this.model_minScore_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "分数:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示模板图像ToolStripMenuItem,
            this.显示模板区域ToolStripMenuItem,
            this.显示搜索区域ToolStripMenuItem,
            this.测试查找ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 92);
            // 
            // 显示模板图像ToolStripMenuItem
            // 
            this.显示模板图像ToolStripMenuItem.Name = "显示模板图像ToolStripMenuItem";
            this.显示模板图像ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.显示模板图像ToolStripMenuItem.Text = "显示模板图像";
            this.显示模板图像ToolStripMenuItem.Click += new System.EventHandler(this.显示模板图像ToolStripMenuItem_Click);
            // 
            // 显示模板区域ToolStripMenuItem
            // 
            this.显示模板区域ToolStripMenuItem.Name = "显示模板区域ToolStripMenuItem";
            this.显示模板区域ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.显示模板区域ToolStripMenuItem.Text = "显示模板区域";
            this.显示模板区域ToolStripMenuItem.Click += new System.EventHandler(this.显示模板区域ToolStripMenuItem_Click);
            // 
            // 显示搜索区域ToolStripMenuItem
            // 
            this.显示搜索区域ToolStripMenuItem.Name = "显示搜索区域ToolStripMenuItem";
            this.显示搜索区域ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.显示搜索区域ToolStripMenuItem.Text = "显示搜索区域";
            this.显示搜索区域ToolStripMenuItem.Click += new System.EventHandler(this.显示搜索区域ToolStripMenuItem_Click);
            // 
            // 测试查找ToolStripMenuItem
            // 
            this.测试查找ToolStripMenuItem.Name = "测试查找ToolStripMenuItem";
            this.测试查找ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.测试查找ToolStripMenuItem.Text = "导图测试查找";
            this.测试查找ToolStripMenuItem.Click += new System.EventHandler(this.测试查找ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tabControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tabControl1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tabControl1.HeadSelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tabControl1.ItemSize = new System.Drawing.Size(150, 20);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(20, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowClose = false;
            this.tabControl1.ShowIndex = false;
            this.tabControl1.Size = new System.Drawing.Size(265, 272);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(257, 244);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = " 模板";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.63813F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.36187F));
            this.tableLayoutPanel1.Controls.Add(this.displayWindow2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button6, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(257, 244);
            this.tableLayoutPanel1.TabIndex = 17;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // displayWindow2
            // 
            this.displayWindow2.BackColor = System.Drawing.Color.Transparent;
            this.displayWindow2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayWindow2.Location = new System.Drawing.Point(0, 0);
            this.displayWindow2.Margin = new System.Windows.Forms.Padding(0);
            this.displayWindow2.Name = "displayWindow2";
            this.tableLayoutPanel1.SetRowSpan(this.displayWindow2, 2);
            this.displayWindow2.Size = new System.Drawing.Size(124, 102);
            this.displayWindow2.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(4, 162);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(249, 78);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "绘制模板";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(150)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(200)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(182, 46);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 25);
            this.button4.TabIndex = 8;
            this.button4.Text = "椭圆";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(150)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(200)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(124, 46);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 25);
            this.button3.TabIndex = 7;
            this.button3.Text = "圆";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(150)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(200)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(66, 46);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 25);
            this.button2.TabIndex = 6;
            this.button2.Text = "仿矩";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(150)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(200)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(8, 46);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "矩形";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 2);
            this.label1.TabIndex = 4;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.Color.Transparent;
            this.radioButton3.Font = new System.Drawing.Font("宋体", 20F);
            this.radioButton3.Location = new System.Drawing.Point(128, 5);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(44, 31);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "-";
            this.radioButton3.UseVisualStyleBackColor = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.BackColor = System.Drawing.Color.Transparent;
            this.radioButton4.Checked = true;
            this.radioButton4.Font = new System.Drawing.Font("宋体", 20F);
            this.radioButton4.Location = new System.Drawing.Point(69, 4);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(44, 31);
            this.radioButton4.TabIndex = 2;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "+";
            this.radioButton4.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.model_Shple);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(4, 106);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(249, 48);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "匹配方式";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(124, 20);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(74, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "基于灰度";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // model_Shple
            // 
            this.model_Shple.AutoSize = true;
            this.model_Shple.Checked = true;
            this.model_Shple.Location = new System.Drawing.Point(8, 20);
            this.model_Shple.Margin = new System.Windows.Forms.Padding(4);
            this.model_Shple.Name = "model_Shple";
            this.model_Shple.Size = new System.Drawing.Size(74, 21);
            this.model_Shple.TabIndex = 0;
            this.model_Shple.TabStop = true;
            this.model_Shple.Text = "基于轮廓";
            this.model_Shple.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(150)))));
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(200)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(128, 55);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 24);
            this.button5.TabIndex = 14;
            this.button5.Text = "学习模型";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(150)))));
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(200)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(128, 4);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(80, 24);
            this.button6.TabIndex = 15;
            this.button6.Text = "导入图像";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(257, 244);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = " 参数";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.04478F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.95522F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button8, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.model_minScore, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.model_DispFindRegion, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.model_DispModel, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.model_contrast, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.model_findRegionEnable, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.model_contrastAuto, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.comboBox2, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.model_matchNum, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.model_angleStep, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.model_startAngle, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.model_polarity, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.model_angleRange, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.model_maxScale, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.model_minScale, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(257, 244);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(4, 284);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 12);
            this.label12.TabIndex = 12;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(185, 276);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(80, 24);
            this.button7.TabIndex = 15;
            this.button7.Text = "测试查找";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // HYCreateModel2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button7);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "HYCreateModel2";
            this.Size = new System.Drawing.Size(269, 304);
            ((System.ComponentModel.ISupportInitialize)(this.model_contrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_maxScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_minScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_angleRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_startAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_angleStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_matchNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.model_minScore)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown model_minScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown model_matchNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown model_angleStep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown model_angleRange;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown model_startAngle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown model_maxScale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown model_minScale;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox model_polarity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox model_contrastAuto;
        private System.Windows.Forms.NumericUpDown model_contrast;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox model_findRegionEnable;
        private System.Windows.Forms.CheckBox model_DispFindRegion;
        private System.Windows.Forms.CheckBox model_DispModel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 显示模板图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示模板区域ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示搜索区域ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试查找ToolStripMenuItem;
        private HYTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton model_Shple;
        private DisplayWindow.HalconWindow displayWindow2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}