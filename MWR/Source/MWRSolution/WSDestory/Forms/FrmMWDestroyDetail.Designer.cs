namespace YRKJ.MWR.WSDestory.Forms
{
    partial class FrmMWDestroyDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMWDestroyDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.c_btnStopDest = new System.Windows.Forms.Button();
            this.c_txtPostNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.c_txtCurCrateCode = new System.Windows.Forms.TextBox();
            this.c_labUnit1 = new System.Windows.Forms.Label();
            this.c_labUnit2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.c_btnCheck = new System.Windows.Forms.Button();
            this.c_btnManually = new System.Windows.Forms.Button();
            this.c_labUnit4 = new System.Windows.Forms.Label();
            this.c_labUnit3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.c_btnDestDone = new System.Windows.Forms.Button();
            this.c_labTxnTotalWeigth = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWRecover)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_btnStopDest
            // 
            this.c_btnStopDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnStopDest.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnStopDest.Image = ((System.Drawing.Image)(resources.GetObject("c_btnStopDest.Image")));
            this.c_btnStopDest.Location = new System.Drawing.Point(856, 15);
            this.c_btnStopDest.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.c_btnStopDest.Name = "c_btnStopDest";
            this.c_btnStopDest.Size = new System.Drawing.Size(140, 65);
            this.c_btnStopDest.TabIndex = 14;
            this.c_btnStopDest.Text = "停止处理";
            this.c_btnStopDest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnStopDest.UseVisualStyleBackColor = true;
            this.c_btnStopDest.Click += new System.EventHandler(this.c_btnStopDest_Click);
            // 
            // c_txtPostNum
            // 
            this.c_txtPostNum.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_txtPostNum.Location = new System.Drawing.Point(140, 56);
            this.c_txtPostNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c_txtPostNum.Name = "c_txtPostNum";
            this.c_txtPostNum.ReadOnly = true;
            this.c_txtPostNum.Size = new System.Drawing.Size(144, 29);
            this.c_txtPostNum.TabIndex = 33;
            this.c_txtPostNum.Text = "WF000001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 32;
            this.label1.Text = "出库计划编号：";
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
            this.panel1.Size = new System.Drawing.Size(984, 212);
            this.panel1.TabIndex = 34;
            // 
            // c_grdMWRecover
            // 
            this.c_grdMWRecover.AllowUserToAddRows = false;
            this.c_grdMWRecover.AllowUserToDeleteRows = false;
            this.c_grdMWRecover.AllowUserToResizeColumns = false;
            this.c_grdMWRecover.AllowUserToResizeRows = false;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("微软雅黑", 11F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.c_grdMWRecover.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
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
            this.c_grdMWRecover.Size = new System.Drawing.Size(984, 212);
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
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_OutDate.DefaultCellStyle = dataGridViewCellStyle20;
            this.c_grdMWRecover_C_OutDate.FillWeight = 150F;
            this.c_grdMWRecover_C_OutDate.HeaderText = "出车时间";
            this.c_grdMWRecover_C_OutDate.Name = "c_grdMWRecover_C_OutDate";
            this.c_grdMWRecover_C_OutDate.Width = 150;
            // 
            // c_grdMWRecover_C_InDate
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_InDate.DefaultCellStyle = dataGridViewCellStyle21;
            this.c_grdMWRecover_C_InDate.FillWeight = 150F;
            this.c_grdMWRecover_C_InDate.HeaderText = "回车时间";
            this.c_grdMWRecover_C_InDate.Name = "c_grdMWRecover_C_InDate";
            this.c_grdMWRecover_C_InDate.Width = 150;
            // 
            // c_grdMWRecover_C_StratDate
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_StratDate.DefaultCellStyle = dataGridViewCellStyle22;
            this.c_grdMWRecover_C_StratDate.FillWeight = 150F;
            this.c_grdMWRecover_C_StratDate.HeaderText = "校验时间";
            this.c_grdMWRecover_C_StratDate.Name = "c_grdMWRecover_C_StratDate";
            this.c_grdMWRecover_C_StratDate.Width = 150;
            // 
            // c_grdMWRecover_C_Status
            // 
            this.c_grdMWRecover_C_Status.FillWeight = 80F;
            this.c_grdMWRecover_C_Status.HeaderText = "状态";
            this.c_grdMWRecover_C_Status.Name = "c_grdMWRecover_C_Status";
            this.c_grdMWRecover_C_Status.Width = 80;
            // 
            // c_grdMWRecover_C_TotleCount
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_TotleCount.DefaultCellStyle = dataGridViewCellStyle23;
            this.c_grdMWRecover_C_TotleCount.FillWeight = 80F;
            this.c_grdMWRecover_C_TotleCount.HeaderText = "总数量";
            this.c_grdMWRecover_C_TotleCount.Name = "c_grdMWRecover_C_TotleCount";
            this.c_grdMWRecover_C_TotleCount.Width = 80;
            // 
            // c_grdMWRecover_C_TotolWeight
            // 
            this.c_grdMWRecover_C_TotolWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_TotolWeight.DefaultCellStyle = dataGridViewCellStyle24;
            this.c_grdMWRecover_C_TotolWeight.FillWeight = 80F;
            this.c_grdMWRecover_C_TotolWeight.HeaderText = "总重量";
            this.c_grdMWRecover_C_TotolWeight.Name = "c_grdMWRecover_C_TotolWeight";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(687, 319);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(163, 95);
            this.panel2.TabIndex = 43;
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
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("微软雅黑", 38F);
            this.label13.ForeColor = System.Drawing.Color.Lime;
            this.label13.Location = new System.Drawing.Point(50, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 78);
            this.label13.TabIndex = 0;
            this.label13.Text = "0";
            this.label13.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(524, 393);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 17);
            this.label18.TabIndex = 36;
            this.label18.Text = "实际总数量：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.c_txtCurCrateCode);
            this.groupBox2.Controls.Add(this.c_labUnit1);
            this.groupBox2.Controls.Add(this.c_labUnit2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.c_btnCheck);
            this.groupBox2.Controls.Add(this.c_btnManually);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.groupBox2.Location = new System.Drawing.Point(12, 307);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 110);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "当前货箱";
            // 
            // c_txtCurCrateCode
            // 
            this.c_txtCurCrateCode.Location = new System.Drawing.Point(92, 24);
            this.c_txtCurCrateCode.Name = "c_txtCurCrateCode";
            this.c_txtCurCrateCode.ReadOnly = true;
            this.c_txtCurCrateCode.Size = new System.Drawing.Size(132, 25);
            this.c_txtCurCrateCode.TabIndex = 18;
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
            this.label8.Text = "0";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "提交重量：";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(230, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(166, 27);
            this.label11.TabIndex = 1;
            this.label11.Text = "未确认";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // 
            // c_labUnit4
            // 
            this.c_labUnit4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labUnit4.AutoSize = true;
            this.c_labUnit4.Location = new System.Drawing.Point(657, 393);
            this.c_labUnit4.Name = "c_labUnit4";
            this.c_labUnit4.Size = new System.Drawing.Size(25, 17);
            this.c_labUnit4.TabIndex = 38;
            this.c_labUnit4.Text = "KG";
            this.c_labUnit4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // c_labUnit3
            // 
            this.c_labUnit3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labUnit3.AutoSize = true;
            this.c_labUnit3.Location = new System.Drawing.Point(657, 363);
            this.c_labUnit3.Name = "c_labUnit3";
            this.c_labUnit3.Size = new System.Drawing.Size(25, 17);
            this.c_labUnit3.TabIndex = 37;
            this.c_labUnit3.Text = "KG";
            this.c_labUnit3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(524, 363);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 17);
            this.label16.TabIndex = 41;
            this.label16.Text = "提交总重量：";
            // 
            // c_btnDestDone
            // 
            this.c_btnDestDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnDestDone.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnDestDone.Image = ((System.Drawing.Image)(resources.GetObject("c_btnDestDone.Image")));
            this.c_btnDestDone.Location = new System.Drawing.Point(856, 349);
            this.c_btnDestDone.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.c_btnDestDone.Name = "c_btnDestDone";
            this.c_btnDestDone.Size = new System.Drawing.Size(140, 65);
            this.c_btnDestDone.TabIndex = 35;
            this.c_btnDestDone.Text = "处理完成";
            this.c_btnDestDone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnDestDone.UseVisualStyleBackColor = true;
            this.c_btnDestDone.Click += new System.EventHandler(this.c_btnDestDone_Click);
            // 
            // c_labTxnTotalWeigth
            // 
            this.c_labTxnTotalWeigth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labTxnTotalWeigth.Location = new System.Drawing.Point(610, 361);
            this.c_labTxnTotalWeigth.Name = "c_labTxnTotalWeigth";
            this.c_labTxnTotalWeigth.Size = new System.Drawing.Size(48, 21);
            this.c_labTxnTotalWeigth.TabIndex = 44;
            this.c_labTxnTotalWeigth.Text = "000.00";
            this.c_labTxnTotalWeigth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(610, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 21);
            this.label2.TabIndex = 44;
            this.label2.Text = "000.00";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmMWDestoryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 429);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.c_labTxnTotalWeigth);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.c_labUnit4);
            this.Controls.Add(this.c_labUnit3);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.c_btnDestDone);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c_txtPostNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c_btnStopDest);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMWDestoryDetail";
            this.Text = "FrmDestoryInventory";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWRecover)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button c_btnStopDest;
        private System.Windows.Forms.TextBox c_txtPostNum;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label c_labUnit1;
        private System.Windows.Forms.Label c_labUnit2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button c_btnCheck;
        private System.Windows.Forms.Button c_btnManually;
        private System.Windows.Forms.Label c_labUnit4;
        private System.Windows.Forms.Label c_labUnit3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button c_btnDestDone;
        private System.Windows.Forms.TextBox c_txtCurCrateCode;
        private System.Windows.Forms.Label c_labTxnTotalWeigth;
        private System.Windows.Forms.Label label2;
    }
}