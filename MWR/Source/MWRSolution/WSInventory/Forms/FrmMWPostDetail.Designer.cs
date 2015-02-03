namespace YRKJ.MWR.WSInventory.Forms
{
    partial class FrmMWPostDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMWPostDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.c_btnPost = new System.Windows.Forms.Button();
            this.c_btnStopPost = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.c_txtPostNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.c_labPostType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c_grdMWTxnDetail = new System.Windows.Forms.DataGridView();
            this.c_grdMWTxnDetail_C_CrateCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWTxnDetail_C_Vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWTxnDetail_C_Waste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWTxnDetail_C_SubWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWTxnDetail_C_TxnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWTxnDetail_C_EntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWTxnDetail_C_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.c_txtCrateCode = new System.Windows.Forms.TextBox();
            this.c_labUnit1 = new System.Windows.Forms.Label();
            this.c_labUnit2 = new System.Windows.Forms.Label();
            this.c_labTxnWeight = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.c_labSubWeight = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.c_labStatus = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.c_btnCheck = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.c_labTotalQty = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.c_labUnit3 = new System.Windows.Forms.Label();
            this.c_labTotalSubWeight = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.c_labTotalTxnWeight = new System.Windows.Forms.Label();
            this.c_labUnit4 = new System.Windows.Forms.Label();
            this.c_labIsCheckPost = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWTxnDetail)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_btnPost
            // 
            this.c_btnPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnPost.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnPost.Image = ((System.Drawing.Image)(resources.GetObject("c_btnPost.Image")));
            this.c_btnPost.Location = new System.Drawing.Point(856, 361);
            this.c_btnPost.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.c_btnPost.Name = "c_btnPost";
            this.c_btnPost.Size = new System.Drawing.Size(140, 65);
            this.c_btnPost.TabIndex = 1;
            this.c_btnPost.Text = "确认出库";
            this.c_btnPost.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnPost.UseVisualStyleBackColor = true;
            this.c_btnPost.Click += new System.EventHandler(this.c_btnPost_Click);
            // 
            // c_btnStopPost
            // 
            this.c_btnStopPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnStopPost.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnStopPost.Image = ((System.Drawing.Image)(resources.GetObject("c_btnStopPost.Image")));
            this.c_btnStopPost.Location = new System.Drawing.Point(856, 15);
            this.c_btnStopPost.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.c_btnStopPost.Name = "c_btnStopPost";
            this.c_btnStopPost.Size = new System.Drawing.Size(140, 65);
            this.c_btnStopPost.TabIndex = 2;
            this.c_btnStopPost.Text = "停止出库";
            this.c_btnStopPost.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnStopPost.UseVisualStyleBackColor = true;
            this.c_btnStopPost.Click += new System.EventHandler(this.c_btnStopPost_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 30;
            this.label1.Text = "出库计划编号：";
            // 
            // c_txtPostNum
            // 
            this.c_txtPostNum.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_txtPostNum.Location = new System.Drawing.Point(140, 12);
            this.c_txtPostNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c_txtPostNum.Name = "c_txtPostNum";
            this.c_txtPostNum.ReadOnly = true;
            this.c_txtPostNum.Size = new System.Drawing.Size(144, 29);
            this.c_txtPostNum.TabIndex = 31;
            this.c_txtPostNum.Text = "WF000001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(44, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 30;
            this.label2.Text = "出库方式：";
            // 
            // c_labPostType
            // 
            this.c_labPostType.AutoSize = true;
            this.c_labPostType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_labPostType.Location = new System.Drawing.Point(136, 59);
            this.c_labPostType.Name = "c_labPostType";
            this.c_labPostType.Size = new System.Drawing.Size(74, 21);
            this.c_labPostType.TabIndex = 30;
            this.c_labPostType.Text = "称重出库";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.c_grdMWTxnDetail);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.panel1.Location = new System.Drawing.Point(12, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 224);
            this.panel1.TabIndex = 32;
            // 
            // c_grdMWTxnDetail
            // 
            this.c_grdMWTxnDetail.AllowUserToAddRows = false;
            this.c_grdMWTxnDetail.AllowUserToDeleteRows = false;
            this.c_grdMWTxnDetail.AllowUserToResizeColumns = false;
            this.c_grdMWTxnDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 11F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.c_grdMWTxnDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.c_grdMWTxnDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_grdMWTxnDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_grdMWTxnDetail_C_CrateCode,
            this.c_grdMWTxnDetail_C_Vendor,
            this.c_grdMWTxnDetail_C_Waste,
            this.c_grdMWTxnDetail_C_SubWeight,
            this.c_grdMWTxnDetail_C_TxnWeight,
            this.c_grdMWTxnDetail_C_EntryDate,
            this.c_grdMWTxnDetail_C_Status});
            this.c_grdMWTxnDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_grdMWTxnDetail.Location = new System.Drawing.Point(0, 0);
            this.c_grdMWTxnDetail.MultiSelect = false;
            this.c_grdMWTxnDetail.Name = "c_grdMWTxnDetail";
            this.c_grdMWTxnDetail.RowHeadersVisible = false;
            this.c_grdMWTxnDetail.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWTxnDetail.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.c_grdMWTxnDetail.RowTemplate.Height = 60;
            this.c_grdMWTxnDetail.RowTemplate.ReadOnly = true;
            this.c_grdMWTxnDetail.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_grdMWTxnDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.c_grdMWTxnDetail.Size = new System.Drawing.Size(984, 224);
            this.c_grdMWTxnDetail.TabIndex = 14;
            // 
            // c_grdMWTxnDetail_C_CrateCode
            // 
            this.c_grdMWTxnDetail_C_CrateCode.FillWeight = 150F;
            this.c_grdMWTxnDetail_C_CrateCode.HeaderText = "货箱编号";
            this.c_grdMWTxnDetail_C_CrateCode.Name = "c_grdMWTxnDetail_C_CrateCode";
            this.c_grdMWTxnDetail_C_CrateCode.Width = 120;
            // 
            // c_grdMWTxnDetail_C_Vendor
            // 
            this.c_grdMWTxnDetail_C_Vendor.FillWeight = 150F;
            this.c_grdMWTxnDetail_C_Vendor.HeaderText = "收集医院";
            this.c_grdMWTxnDetail_C_Vendor.Name = "c_grdMWTxnDetail_C_Vendor";
            this.c_grdMWTxnDetail_C_Vendor.Width = 150;
            // 
            // c_grdMWTxnDetail_C_Waste
            // 
            this.c_grdMWTxnDetail_C_Waste.FillWeight = 150F;
            this.c_grdMWTxnDetail_C_Waste.HeaderText = "废品类型";
            this.c_grdMWTxnDetail_C_Waste.Name = "c_grdMWTxnDetail_C_Waste";
            this.c_grdMWTxnDetail_C_Waste.Width = 150;
            // 
            // c_grdMWTxnDetail_C_SubWeight
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWTxnDetail_C_SubWeight.DefaultCellStyle = dataGridViewCellStyle6;
            this.c_grdMWTxnDetail_C_SubWeight.HeaderText = "收集重量";
            this.c_grdMWTxnDetail_C_SubWeight.Name = "c_grdMWTxnDetail_C_SubWeight";
            // 
            // c_grdMWTxnDetail_C_TxnWeight
            // 
            this.c_grdMWTxnDetail_C_TxnWeight.HeaderText = "确认重量";
            this.c_grdMWTxnDetail_C_TxnWeight.Name = "c_grdMWTxnDetail_C_TxnWeight";
            // 
            // c_grdMWTxnDetail_C_EntryDate
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWTxnDetail_C_EntryDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.c_grdMWTxnDetail_C_EntryDate.FillWeight = 150F;
            this.c_grdMWTxnDetail_C_EntryDate.HeaderText = "提交时间";
            this.c_grdMWTxnDetail_C_EntryDate.Name = "c_grdMWTxnDetail_C_EntryDate";
            this.c_grdMWTxnDetail_C_EntryDate.Width = 150;
            // 
            // c_grdMWTxnDetail_C_Status
            // 
            this.c_grdMWTxnDetail_C_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWTxnDetail_C_Status.DefaultCellStyle = dataGridViewCellStyle8;
            this.c_grdMWTxnDetail_C_Status.FillWeight = 250F;
            this.c_grdMWTxnDetail_C_Status.HeaderText = "货箱状态";
            this.c_grdMWTxnDetail_C_Status.Name = "c_grdMWTxnDetail_C_Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.c_txtCrateCode);
            this.groupBox2.Controls.Add(this.c_labUnit1);
            this.groupBox2.Controls.Add(this.c_labUnit2);
            this.groupBox2.Controls.Add(this.c_labTxnWeight);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.c_labSubWeight);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.c_labStatus);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.c_btnCheck);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.groupBox2.Location = new System.Drawing.Point(12, 319);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 110);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "当前货箱";
            // 
            // c_txtCrateCode
            // 
            this.c_txtCrateCode.Location = new System.Drawing.Point(89, 24);
            this.c_txtCrateCode.Name = "c_txtCrateCode";
            this.c_txtCrateCode.ReadOnly = true;
            this.c_txtCrateCode.Size = new System.Drawing.Size(132, 25);
            this.c_txtCrateCode.TabIndex = 33;
            // 
            // c_labUnit1
            // 
            this.c_labUnit1.AutoSize = true;
            this.c_labUnit1.Location = new System.Drawing.Point(139, 55);
            this.c_labUnit1.Name = "c_labUnit1";
            this.c_labUnit1.Size = new System.Drawing.Size(28, 20);
            this.c_labUnit1.TabIndex = 2;
            this.c_labUnit1.Text = "KG";
            this.c_labUnit1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // c_labUnit2
            // 
            this.c_labUnit2.AutoSize = true;
            this.c_labUnit2.Location = new System.Drawing.Point(139, 84);
            this.c_labUnit2.Name = "c_labUnit2";
            this.c_labUnit2.Size = new System.Drawing.Size(28, 20);
            this.c_labUnit2.TabIndex = 1;
            this.c_labUnit2.Text = "KG";
            this.c_labUnit2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // c_labTxnWeight
            // 
            this.c_labTxnWeight.Location = new System.Drawing.Point(85, 84);
            this.c_labTxnWeight.Name = "c_labTxnWeight";
            this.c_labTxnWeight.Size = new System.Drawing.Size(57, 21);
            this.c_labTxnWeight.TabIndex = 1;
            this.c_labTxnWeight.Text = "0";
            this.c_labTxnWeight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "实际重量：";
            // 
            // c_labSubWeight
            // 
            this.c_labSubWeight.Location = new System.Drawing.Point(85, 55);
            this.c_labSubWeight.Name = "c_labSubWeight";
            this.c_labSubWeight.Size = new System.Drawing.Size(57, 21);
            this.c_labSubWeight.TabIndex = 1;
            this.c_labSubWeight.Text = "10";
            this.c_labSubWeight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "库存重量：";
            // 
            // c_labStatus
            // 
            this.c_labStatus.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.c_labStatus.ForeColor = System.Drawing.Color.Blue;
            this.c_labStatus.Location = new System.Drawing.Point(306, 20);
            this.c_labStatus.Name = "c_labStatus";
            this.c_labStatus.Size = new System.Drawing.Size(90, 27);
            this.c_labStatus.TabIndex = 1;
            this.c_labStatus.Text = "未确认";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(227, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "货箱状态：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "货箱编号：";
            // 
            // c_btnCheck
            // 
            this.c_btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnCheck.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnCheck.Location = new System.Drawing.Point(231, 54);
            this.c_btnCheck.Name = "c_btnCheck";
            this.c_btnCheck.Size = new System.Drawing.Size(148, 49);
            this.c_btnCheck.TabIndex = 0;
            this.c_btnCheck.Text = "审核确认";
            this.c_btnCheck.UseVisualStyleBackColor = true;
            this.c_btnCheck.Click += new System.EventHandler(this.c_btnCheck_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(501, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "WF00001";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.c_labTotalQty);
            this.panel2.Location = new System.Drawing.Point(687, 331);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(163, 95);
            this.panel2.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(3, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "共：";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.ForeColor = System.Drawing.Color.Lime;
            this.label12.Location = new System.Drawing.Point(129, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "箱";
            // 
            // c_labTotalQty
            // 
            this.c_labTotalQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labTotalQty.Font = new System.Drawing.Font("微软雅黑", 38F);
            this.c_labTotalQty.ForeColor = System.Drawing.Color.Lime;
            this.c_labTotalQty.Location = new System.Drawing.Point(50, 10);
            this.c_labTotalQty.Name = "c_labTotalQty";
            this.c_labTotalQty.Size = new System.Drawing.Size(90, 78);
            this.c_labTotalQty.TabIndex = 0;
            this.c_labTotalQty.Text = "2";
            this.c_labTotalQty.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(525, 405);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 17);
            this.label18.TabIndex = 3;
            this.label18.Text = "校验总重量：";
            // 
            // c_labUnit3
            // 
            this.c_labUnit3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labUnit3.AutoSize = true;
            this.c_labUnit3.Location = new System.Drawing.Point(657, 375);
            this.c_labUnit3.Name = "c_labUnit3";
            this.c_labUnit3.Size = new System.Drawing.Size(25, 17);
            this.c_labUnit3.TabIndex = 5;
            this.c_labUnit3.Text = "KG";
            this.c_labUnit3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // c_labTotalSubWeight
            // 
            this.c_labTotalSubWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labTotalSubWeight.Location = new System.Drawing.Point(611, 373);
            this.c_labTotalSubWeight.Name = "c_labTotalSubWeight";
            this.c_labTotalSubWeight.Size = new System.Drawing.Size(49, 21);
            this.c_labTotalSubWeight.TabIndex = 6;
            this.c_labTotalSubWeight.Text = "000.00";
            this.c_labTotalSubWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(525, 375);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 17);
            this.label16.TabIndex = 7;
            this.label16.Text = "库存总重量：";
            // 
            // c_labTotalTxnWeight
            // 
            this.c_labTotalTxnWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labTotalTxnWeight.Location = new System.Drawing.Point(614, 403);
            this.c_labTotalTxnWeight.Name = "c_labTotalTxnWeight";
            this.c_labTotalTxnWeight.Size = new System.Drawing.Size(46, 21);
            this.c_labTotalTxnWeight.TabIndex = 6;
            this.c_labTotalTxnWeight.Text = "000.00";
            this.c_labTotalTxnWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_labUnit4
            // 
            this.c_labUnit4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labUnit4.AutoSize = true;
            this.c_labUnit4.Location = new System.Drawing.Point(657, 405);
            this.c_labUnit4.Name = "c_labUnit4";
            this.c_labUnit4.Size = new System.Drawing.Size(25, 17);
            this.c_labUnit4.TabIndex = 5;
            this.c_labUnit4.Text = "KG";
            this.c_labUnit4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // c_labIsCheckPost
            // 
            this.c_labIsCheckPost.AutoSize = true;
            this.c_labIsCheckPost.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.c_labIsCheckPost.ForeColor = System.Drawing.Color.Red;
            this.c_labIsCheckPost.Location = new System.Drawing.Point(290, 11);
            this.c_labIsCheckPost.Name = "c_labIsCheckPost";
            this.c_labIsCheckPost.Size = new System.Drawing.Size(101, 30);
            this.c_labIsCheckPost.TabIndex = 1;
            this.c_labIsCheckPost.Text = "审核计划";
            this.c_labIsCheckPost.Visible = false;
            // 
            // FrmMWPostDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 441);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c_labUnit4);
            this.Controls.Add(this.c_labUnit3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.c_labIsCheckPost);
            this.Controls.Add(this.c_txtPostNum);
            this.Controls.Add(this.c_labTotalTxnWeight);
            this.Controls.Add(this.c_labTotalSubWeight);
            this.Controls.Add(this.c_labPostType);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c_btnStopPost);
            this.Controls.Add(this.c_btnPost);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMWPostDetail";
            this.Text = "FrmPostDetail";
            this.Load += new System.EventHandler(this.FrmMWPostDetail_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWTxnDetail)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button c_btnPost;
        private System.Windows.Forms.Button c_btnStopPost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox c_txtPostNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label c_labPostType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label c_labUnit1;
        private System.Windows.Forms.Label c_labUnit2;
        private System.Windows.Forms.Label c_labTxnWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label c_labSubWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label c_labStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button c_btnCheck;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label c_labTotalQty;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label c_labUnit3;
        private System.Windows.Forms.Label c_labTotalSubWeight;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label c_labTotalTxnWeight;
        private System.Windows.Forms.Label c_labUnit4;
        private System.Windows.Forms.Label c_labIsCheckPost;
        private System.Windows.Forms.TextBox c_txtCrateCode;
        private System.Windows.Forms.DataGridView c_grdMWTxnDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWTxnDetail_C_CrateCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWTxnDetail_C_Vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWTxnDetail_C_Waste;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWTxnDetail_C_SubWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWTxnDetail_C_TxnWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWTxnDetail_C_EntryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWTxnDetail_C_Status;
    }
}