
namespace ControlStart.Product
{
    partial class Form_ProductHome
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
            this.uiLine1 = new Sunny.UI.UILine();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.label_NowProductName = new Sunny.UI.UILabel();
            this.btn_Add = new Sunny.UI.UISymbolButton();
            this.btn_UpData = new Sunny.UI.UISymbolButton();
            this.btn_Delete = new Sunny.UI.UISymbolButton();
            this.btn_Switch = new Sunny.UI.UISymbolButton();
            this.btn_Refresh = new Sunny.UI.UISymbolButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Copy = new Sunny.UI.UISymbolButton();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.halconWindow1 = new ToolKit.DisplayWindow.HalconWindow();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLine1
            // 
            this.uiLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine1.FillColor = System.Drawing.Color.Transparent;
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.Location = new System.Drawing.Point(0, 56);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(677, 29);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(270, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(404, 315);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel1.ForeColor = System.Drawing.Color.White;
            this.uiLabel1.Location = new System.Drawing.Point(3, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.uiLabel1.Size = new System.Drawing.Size(55, 29);
            this.uiLabel1.TabIndex = 2;
            this.uiLabel1.Text = "产品名:";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label_NowProductName
            // 
            this.label_NowProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_NowProductName.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label_NowProductName.ForeColor = System.Drawing.Color.White;
            this.label_NowProductName.Location = new System.Drawing.Point(64, 0);
            this.label_NowProductName.Name = "label_NowProductName";
            this.label_NowProductName.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label_NowProductName.Size = new System.Drawing.Size(166, 29);
            this.label_NowProductName.TabIndex = 3;
            this.label_NowProductName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btn_Add
            // 
            this.btn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_Add.Location = new System.Drawing.Point(236, 3);
            this.btn_Add.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(64, 23);
            this.btn_Add.Symbol = 61694;
            this.btn_Add.SymbolSize = 20;
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "添加";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_UpData
            // 
            this.btn_UpData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_UpData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_UpData.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btn_UpData.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(174)))), ((int)(((byte)(86)))));
            this.btn_UpData.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(137)))), ((int)(((byte)(43)))));
            this.btn_UpData.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(137)))), ((int)(((byte)(43)))));
            this.btn_UpData.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_UpData.Location = new System.Drawing.Point(306, 3);
            this.btn_UpData.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_UpData.Name = "btn_UpData";
            this.btn_UpData.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btn_UpData.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(174)))), ((int)(((byte)(86)))));
            this.btn_UpData.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(137)))), ((int)(((byte)(43)))));
            this.btn_UpData.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(137)))), ((int)(((byte)(43)))));
            this.btn_UpData.Size = new System.Drawing.Size(64, 23);
            this.btn_UpData.Style = Sunny.UI.UIStyle.Orange;
            this.btn_UpData.Symbol = 61508;
            this.btn_UpData.SymbolSize = 20;
            this.btn_UpData.TabIndex = 5;
            this.btn_UpData.Text = "修改";
            this.btn_UpData.Click += new System.EventHandler(this.btn_UpData_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Delete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Delete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_Delete.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.btn_Delete.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btn_Delete.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btn_Delete.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_Delete.Location = new System.Drawing.Point(376, 3);
            this.btn_Delete.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_Delete.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.btn_Delete.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btn_Delete.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btn_Delete.Size = new System.Drawing.Size(64, 23);
            this.btn_Delete.Style = Sunny.UI.UIStyle.Red;
            this.btn_Delete.Symbol = 62163;
            this.btn_Delete.SymbolSize = 20;
            this.btn_Delete.TabIndex = 6;
            this.btn_Delete.Text = "删除";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Switch
            // 
            this.btn_Switch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Switch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Switch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btn_Switch.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btn_Switch.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btn_Switch.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btn_Switch.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_Switch.Location = new System.Drawing.Point(446, 3);
            this.btn_Switch.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Switch.Name = "btn_Switch";
            this.btn_Switch.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btn_Switch.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btn_Switch.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btn_Switch.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btn_Switch.Size = new System.Drawing.Size(64, 23);
            this.btn_Switch.Style = Sunny.UI.UIStyle.Green;
            this.btn_Switch.Symbol = 361778;
            this.btn_Switch.SymbolSize = 20;
            this.btn_Switch.TabIndex = 7;
            this.btn_Switch.Text = "切换";
            this.btn_Switch.Click += new System.EventHandler(this.btn_Switch_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Refresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btn_Refresh.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btn_Refresh.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btn_Refresh.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btn_Refresh.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_Refresh.Location = new System.Drawing.Point(610, 3);
            this.btn_Refresh.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btn_Refresh.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btn_Refresh.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btn_Refresh.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btn_Refresh.Size = new System.Drawing.Size(64, 23);
            this.btn_Refresh.Style = Sunny.UI.UIStyle.Green;
            this.btn_Refresh.Symbol = 61473;
            this.btn_Refresh.SymbolSize = 20;
            this.btn_Refresh.TabIndex = 8;
            this.btn_Refresh.Text = "刷新";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btn_Copy, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Switch, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Delete, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_UpData, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Add, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_NowProductName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Refresh, 7, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(677, 29);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btn_Copy
            // 
            this.btn_Copy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Copy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Copy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btn_Copy.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btn_Copy.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btn_Copy.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btn_Copy.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_Copy.Location = new System.Drawing.Point(516, 3);
            this.btn_Copy.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btn_Copy.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btn_Copy.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btn_Copy.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btn_Copy.Size = new System.Drawing.Size(64, 23);
            this.btn_Copy.Style = Sunny.UI.UIStyle.Colorful;
            this.btn_Copy.Symbol = 362025;
            this.btn_Copy.SymbolSize = 20;
            this.btn_Copy.TabIndex = 8;
            this.btn_Copy.Text = "复制";
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.uiLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiLabel3.Font = new System.Drawing.Font("楷体", 18F, System.Drawing.FontStyle.Bold);
            this.uiLabel3.ForeColor = System.Drawing.Color.White;
            this.uiLabel3.Location = new System.Drawing.Point(0, 0);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(677, 36);
            this.uiLabel3.TabIndex = 5;
            this.uiLabel3.Text = "  产品设置";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // halconWindow1
            // 
            this.halconWindow1.BackColor = System.Drawing.Color.Transparent;
            this.halconWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halconWindow1.Location = new System.Drawing.Point(1, 1);
            this.halconWindow1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.halconWindow1.Name = "halconWindow1";
            this.halconWindow1.Size = new System.Drawing.Size(269, 314);
            this.halconWindow1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.05935F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.94065F));
            this.tableLayoutPanel2.Controls.Add(this.halconWindow1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 74);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(674, 315);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // Form_ProductHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.uiLine1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Form_ProductHome";
            this.Size = new System.Drawing.Size(677, 392);
            this.Load += new System.EventHandler(this.Form_ProductHome_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILine uiLine1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel label_NowProductName;
        private Sunny.UI.UISymbolButton btn_Add;
        private Sunny.UI.UISymbolButton btn_UpData;
        private Sunny.UI.UISymbolButton btn_Delete;
        private Sunny.UI.UISymbolButton btn_Switch;
        private Sunny.UI.UISymbolButton btn_Refresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UILabel uiLabel3;
        private ToolKit.DisplayWindow.HalconWindow halconWindow1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Sunny.UI.UISymbolButton btn_Copy;
    }
}
