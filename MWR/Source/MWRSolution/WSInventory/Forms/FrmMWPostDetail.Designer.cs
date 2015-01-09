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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.c_btnPost = new System.Windows.Forms.Button();
            this.c_btnStopPost = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.c_txtPostNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.c_labPostType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c_grdMWRecover = new System.Windows.Forms.DataGridView();
            this.c_grdMWRecover_C_CarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_Driver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_Inspector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_OutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_InDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_StratDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_TotleCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_TotolWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.c_btnCheck = new System.Windows.Forms.Button();
            this.c_btnManually = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.c_labIsCheckPost = new System.Windows.Forms.Label();
            this.c_txtCrateCode = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWRecover)).BeginInit();
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
            this.panel1.Controls.Add(this.c_grdMWRecover);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.panel1.Location = new System.Drawing.Point(12, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 224);
            this.panel1.TabIndex = 32;
            // 
            // c_grdMWRecover
            // 
            this.c_grdMWRecover.AllowUserToAddRows = false;
            this.c_grdMWRecover.AllowUserToDeleteRows = false;
            this.c_grdMWRecover.AllowUserToResizeColumns = false;
            this.c_grdMWRecover.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 11F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.c_grdMWRecover.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.c_grdMWRecover.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_grdMWRecover.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_grdMWRecover_C_CarCode,
            this.c_grdMWRecover_C_Driver,
            this.c_grdMWRecover_C_Inspector,
            this.c_grdMWRecover_C_OutDate,
            this.c_grdMWRecover_C_InDate,
            this.c_grdMWRecover_C_StratDate,
            this.c_grdMWRecover_C_Status,
            this.c_grdMWRecover_C_TotleCount,
            this.c_grdMWRecover_C_TotolWeight});
            this.c_grdMWRecover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_grdMWRecover.Location = new System.Drawing.Point(0, 0);
            this.c_grdMWRecover.MultiSelect = false;
            this.c_grdMWRecover.Name = "c_grdMWRecover";
            this.c_grdMWRecover.RowHeadersVisible = false;
            this.c_grdMWRecover.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.c_grdMWRecover.RowTemplate.Height = 60;
            this.c_grdMWRecover.RowTemplate.ReadOnly = true;
            this.c_grdMWRecover.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_grdMWRecover.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.c_grdMWRecover.Size = new System.Drawing.Size(984, 224);
            this.c_grdMWRecover.TabIndex = 12;
            // 
            // c_grdMWRecover_C_CarCode
            // 
            this.c_grdMWRecover_C_CarCode.HeaderText = "车辆编号";
            this.c_grdMWRecover_C_CarCode.Name = "c_grdMWRecover_C_CarCode";
            this.c_grdMWRecover_C_CarCode.Width = 101;
            // 
            // c_grdMWRecover_C_Driver
            // 
            this.c_grdMWRecover_C_Driver.FillWeight = 80F;
            this.c_grdMWRecover_C_Driver.HeaderText = "司机";
            this.c_grdMWRecover_C_Driver.Name = "c_grdMWRecover_C_Driver";
            this.c_grdMWRecover_C_Driver.Width = 80;
            // 
            // c_grdMWRecover_C_Inspector
            // 
            this.c_grdMWRecover_C_Inspector.FillWeight = 80F;
            this.c_grdMWRecover_C_Inspector.HeaderText = "跟车员";
            this.c_grdMWRecover_C_Inspector.Name = "c_grdMWRecover_C_Inspector";
            this.c_grdMWRecover_C_Inspector.Width = 80;
            // 
            // c_grdMWRecover_C_OutDate
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_OutDate.DefaultCellStyle = dataGridViewCellStyle14;
            this.c_grdMWRecover_C_OutDate.FillWeight = 150F;
            this.c_grdMWRecover_C_OutDate.HeaderText = "出车时间";
            this.c_grdMWRecover_C_OutDate.Name = "c_grdMWRecover_C_OutDate";
            this.c_grdMWRecover_C_OutDate.Width = 150;
            // 
            // c_grdMWRecover_C_InDate
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_InDate.DefaultCellStyle = dataGridViewCellStyle15;
            this.c_grdMWRecover_C_InDate.FillWeight = 150F;
            this.c_grdMWRecover_C_InDate.HeaderText = "回车时间";
            this.c_grdMWRecover_C_InDate.Name = "c_grdMWRecover_C_InDate";
            this.c_grdMWRecover_C_InDate.Width = 150;
            // 
            // c_grdMWRecover_C_StratDate
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_StratDate.DefaultCellStyle = dataGridViewCellStyle16;
            this.c_grdMWRecover_C_StratDate.FillWeight = 150F;
            this.c_grdMWRecover_C_StratDate.HeaderText = "校验时间";
            this.c_grdMWRecover_C_StratDate.Name = "c_grdMWRecover_C_StratDate";
            this.c_grdMWRecover_C_StratDate.Width = 150;
            // 
            // c_grdMWRecover_C_Status
            // 
            this.c_grdMWRecover_C_Status.FillWeight = 110F;
            this.c_grdMWRecover_C_Status.HeaderText = "状态";
            this.c_grdMWRecover_C_Status.Name = "c_grdMWRecover_C_Status";
            this.c_grdMWRecover_C_Status.Width = 110;
            // 
            // c_grdMWRecover_C_TotleCount
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_TotleCount.DefaultCellStyle = dataGridViewCellStyle17;
            this.c_grdMWRecover_C_TotleCount.FillWeight = 80F;
            this.c_grdMWRecover_C_TotleCount.HeaderText = "总数量";
            this.c_grdMWRecover_C_TotleCount.Name = "c_grdMWRecover_C_TotleCount";
            this.c_grdMWRecover_C_TotleCount.Width = 80;
            // 
            // c_grdMWRecover_C_TotolWeight
            // 
            this.c_grdMWRecover_C_TotolWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_TotolWeight.DefaultCellStyle = dataGridViewCellStyle18;
            this.c_grdMWRecover_C_TotolWeight.FillWeight = 80F;
            this.c_grdMWRecover_C_TotolWeight.HeaderText = "总重量";
            this.c_grdMWRecover_C_TotolWeight.Name = "c_grdMWRecover_C_TotolWeight";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.c_txtCrateCode);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.c_btnCheck);
            this.groupBox2.Controls.Add(this.c_btnManually);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.groupBox2.Location = new System.Drawing.Point(12, 319);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 110);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "当前货箱";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(139, 55);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(28, 20);
            this.label21.TabIndex = 2;
            this.label21.Text = "KG";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(139, 84);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(28, 20);
            this.label20.TabIndex = 1;
            this.label20.Text = "KG";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(85, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 21);
            this.label9.TabIndex = 1;
            this.label9.Text = "0";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(85, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "10";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(306, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 27);
            this.label11.TabIndex = 1;
            this.label11.Text = "未确认";
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
            this.c_btnCheck.Location = new System.Drawing.Point(176, 55);
            this.c_btnCheck.Name = "c_btnCheck";
            this.c_btnCheck.Size = new System.Drawing.Size(102, 49);
            this.c_btnCheck.TabIndex = 0;
            this.c_btnCheck.Text = "审核确认";
            this.c_btnCheck.UseVisualStyleBackColor = true;
            this.c_btnCheck.Click += new System.EventHandler(this.c_btnCheck_Click);
            // 
            // c_btnManually
            // 
            this.c_btnManually.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnManually.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnManually.Location = new System.Drawing.Point(294, 56);
            this.c_btnManually.Name = "c_btnManually";
            this.c_btnManually.Size = new System.Drawing.Size(102, 49);
            this.c_btnManually.TabIndex = 0;
            this.c_btnManually.Text = "手动确认";
            this.c_btnManually.UseVisualStyleBackColor = true;
            this.c_btnManually.Click += new System.EventHandler(this.c_btnManually_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
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
            this.label3.Location = new System.Drawing.Point(27, 51);
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
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("微软雅黑", 38F);
            this.label13.ForeColor = System.Drawing.Color.Lime;
            this.label13.Location = new System.Drawing.Point(50, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 78);
            this.label13.TabIndex = 0;
            this.label13.Text = "2";
            this.label13.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(555, 405);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 17);
            this.label18.TabIndex = 3;
            this.label18.Text = "确认总数量：";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(657, 375);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(25, 17);
            this.label19.TabIndex = 5;
            this.label19.Text = "KG";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.Location = new System.Drawing.Point(625, 373);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 21);
            this.label17.TabIndex = 6;
            this.label17.Text = "10";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(555, 375);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 17);
            this.label16.TabIndex = 7;
            this.label16.Text = "库存总重量：";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Location = new System.Drawing.Point(625, 403);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 21);
            this.label14.TabIndex = 6;
            this.label14.Text = "10";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(657, 405);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(25, 17);
            this.label15.TabIndex = 5;
            this.label15.Text = "KG";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // c_txtCrateCode
            // 
            this.c_txtCrateCode.Location = new System.Drawing.Point(89, 24);
            this.c_txtCrateCode.Name = "c_txtCrateCode";
            this.c_txtCrateCode.ReadOnly = true;
            this.c_txtCrateCode.Size = new System.Drawing.Size(132, 25);
            this.c_txtCrateCode.TabIndex = 33;
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
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.c_labIsCheckPost);
            this.Controls.Add(this.c_txtPostNum);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label17);
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
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWRecover)).EndInit();
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
        private System.Windows.Forms.DataGridView c_grdMWRecover;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_CarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_Driver;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_Inspector;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_OutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_InDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_StratDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_TotleCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_TotolWeight;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button c_btnCheck;
        private System.Windows.Forms.Button c_btnManually;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label c_labIsCheckPost;
        private System.Windows.Forms.TextBox c_txtCrateCode;
    }
}