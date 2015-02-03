namespace YRKJ.MWR.WSInventory.Forms
{
    partial class FrmMWPost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMWPost));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.c_btnStratPost = new System.Windows.Forms.Button();
            this.c_btnStratCheckPost = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.c_labTxnCount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c_grdMWPost = new System.Windows.Forms.DataGridView();
            this.c_grdMWPost_C_TxnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_WSCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_EmpyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_StratDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_TotleCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_TotolSubWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_TotalTxnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.c_labUnit1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.c_labUnit2 = new System.Windows.Forms.Label();
            this.c_labTotalQty = new System.Windows.Forms.Label();
            this.c_labTxnWeight = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.c_labEmpyName = new System.Windows.Forms.Label();
            this.c_labSubWeight = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.c_labStatus = new System.Windows.Forms.Label();
            this.c_labTxnNum = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.c_btnPost = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWPost)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_btnStratPost
            // 
            this.c_btnStratPost.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnStratPost.Image = ((System.Drawing.Image)(resources.GetObject("c_btnStratPost.Image")));
            this.c_btnStratPost.Location = new System.Drawing.Point(158, 12);
            this.c_btnStratPost.Name = "c_btnStratPost";
            this.c_btnStratPost.Size = new System.Drawing.Size(140, 65);
            this.c_btnStratPost.TabIndex = 27;
            this.c_btnStratPost.Text = "直接出库";
            this.c_btnStratPost.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnStratPost.UseVisualStyleBackColor = true;
            this.c_btnStratPost.Visible = false;
            this.c_btnStratPost.Click += new System.EventHandler(this.c_btnStratPost_Click);
            // 
            // c_btnStratCheckPost
            // 
            this.c_btnStratCheckPost.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnStratCheckPost.Image = ((System.Drawing.Image)(resources.GetObject("c_btnStratCheckPost.Image")));
            this.c_btnStratCheckPost.Location = new System.Drawing.Point(12, 12);
            this.c_btnStratCheckPost.Name = "c_btnStratCheckPost";
            this.c_btnStratCheckPost.Size = new System.Drawing.Size(140, 65);
            this.c_btnStratCheckPost.TabIndex = 27;
            this.c_btnStratCheckPost.Text = "称重出库";
            this.c_btnStratCheckPost.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnStratCheckPost.UseVisualStyleBackColor = true;
            this.c_btnStratCheckPost.Click += new System.EventHandler(this.c_btnStratCheckPost_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(8, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 28;
            this.label1.Text = "当前出库计划列表";
            // 
            // c_labTxnCount
            // 
            this.c_labTxnCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labTxnCount.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_labTxnCount.Location = new System.Drawing.Point(956, 80);
            this.c_labTxnCount.Name = "c_labTxnCount";
            this.c_labTxnCount.Size = new System.Drawing.Size(40, 20);
            this.c_labTxnCount.TabIndex = 29;
            this.c_labTxnCount.Text = "0";
            this.c_labTxnCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label14.Location = new System.Drawing.Point(821, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 21);
            this.label14.TabIndex = 30;
            this.label14.Text = "计划数：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.c_grdMWPost);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.panel1.Location = new System.Drawing.Point(12, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 310);
            this.panel1.TabIndex = 31;
            // 
            // c_grdMWPost
            // 
            this.c_grdMWPost.AllowUserToAddRows = false;
            this.c_grdMWPost.AllowUserToDeleteRows = false;
            this.c_grdMWPost.AllowUserToResizeColumns = false;
            this.c_grdMWPost.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.c_grdMWPost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.c_grdMWPost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_grdMWPost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_grdMWPost_C_TxnNum,
            this.c_grdMWPost_C_WSCode,
            this.c_grdMWPost_C_EmpyName,
            this.c_grdMWPost_C_StratDate,
            this.c_grdMWPost_C_TotleCount,
            this.c_grdMWPost_C_TotolSubWeight,
            this.c_grdMWPost_C_TotalTxnWeight,
            this.c_grdMWPost_C_Status});
            this.c_grdMWPost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_grdMWPost.Location = new System.Drawing.Point(0, 0);
            this.c_grdMWPost.MultiSelect = false;
            this.c_grdMWPost.Name = "c_grdMWPost";
            this.c_grdMWPost.RowHeadersVisible = false;
            this.c_grdMWPost.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWPost.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.c_grdMWPost.RowTemplate.Height = 60;
            this.c_grdMWPost.RowTemplate.ReadOnly = true;
            this.c_grdMWPost.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_grdMWPost.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.c_grdMWPost.Size = new System.Drawing.Size(984, 310);
            this.c_grdMWPost.TabIndex = 12;
            // 
            // c_grdMWPost_C_TxnNum
            // 
            this.c_grdMWPost_C_TxnNum.HeaderText = "交易编号";
            this.c_grdMWPost_C_TxnNum.Name = "c_grdMWPost_C_TxnNum";
            this.c_grdMWPost_C_TxnNum.Width = 101;
            // 
            // c_grdMWPost_C_WSCode
            // 
            this.c_grdMWPost_C_WSCode.FillWeight = 80F;
            this.c_grdMWPost_C_WSCode.HeaderText = "工作站";
            this.c_grdMWPost_C_WSCode.Name = "c_grdMWPost_C_WSCode";
            this.c_grdMWPost_C_WSCode.Width = 80;
            // 
            // c_grdMWPost_C_EmpyName
            // 
            this.c_grdMWPost_C_EmpyName.FillWeight = 80F;
            this.c_grdMWPost_C_EmpyName.HeaderText = "操作员";
            this.c_grdMWPost_C_EmpyName.Name = "c_grdMWPost_C_EmpyName";
            this.c_grdMWPost_C_EmpyName.Width = 80;
            // 
            // c_grdMWPost_C_StratDate
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWPost_C_StratDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.c_grdMWPost_C_StratDate.FillWeight = 150F;
            this.c_grdMWPost_C_StratDate.HeaderText = "开始时间";
            this.c_grdMWPost_C_StratDate.Name = "c_grdMWPost_C_StratDate";
            this.c_grdMWPost_C_StratDate.Width = 150;
            // 
            // c_grdMWPost_C_TotleCount
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWPost_C_TotleCount.DefaultCellStyle = dataGridViewCellStyle8;
            this.c_grdMWPost_C_TotleCount.FillWeight = 80F;
            this.c_grdMWPost_C_TotleCount.HeaderText = "总数量";
            this.c_grdMWPost_C_TotleCount.Name = "c_grdMWPost_C_TotleCount";
            this.c_grdMWPost_C_TotleCount.Width = 80;
            // 
            // c_grdMWPost_C_TotolSubWeight
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWPost_C_TotolSubWeight.DefaultCellStyle = dataGridViewCellStyle9;
            this.c_grdMWPost_C_TotolSubWeight.FillWeight = 150F;
            this.c_grdMWPost_C_TotolSubWeight.HeaderText = "库存总重量";
            this.c_grdMWPost_C_TotolSubWeight.Name = "c_grdMWPost_C_TotolSubWeight";
            this.c_grdMWPost_C_TotolSubWeight.Width = 150;
            // 
            // c_grdMWPost_C_TotalTxnWeight
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWPost_C_TotalTxnWeight.DefaultCellStyle = dataGridViewCellStyle10;
            this.c_grdMWPost_C_TotalTxnWeight.FillWeight = 150F;
            this.c_grdMWPost_C_TotalTxnWeight.HeaderText = "校验总重量";
            this.c_grdMWPost_C_TotalTxnWeight.Name = "c_grdMWPost_C_TotalTxnWeight";
            this.c_grdMWPost_C_TotalTxnWeight.Width = 150;
            // 
            // c_grdMWPost_C_Status
            // 
            this.c_grdMWPost_C_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_grdMWPost_C_Status.FillWeight = 110F;
            this.c_grdMWPost_C_Status.HeaderText = "状态";
            this.c_grdMWPost_C_Status.Name = "c_grdMWPost_C_Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.c_labUnit1);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.c_labUnit2);
            this.groupBox2.Controls.Add(this.c_labTotalQty);
            this.groupBox2.Controls.Add(this.c_labTxnWeight);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.c_labEmpyName);
            this.groupBox2.Controls.Add(this.c_labSubWeight);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.c_labStatus);
            this.groupBox2.Controls.Add(this.c_labTxnNum);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.c_btnPost);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.groupBox2.Location = new System.Drawing.Point(12, 420);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(527, 110);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "当前出库计划";
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
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(306, 84);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 20);
            this.label16.TabIndex = 1;
            this.label16.Text = "箱";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // c_labTotalQty
            // 
            this.c_labTotalQty.Location = new System.Drawing.Point(275, 84);
            this.c_labTotalQty.Name = "c_labTotalQty";
            this.c_labTotalQty.Size = new System.Drawing.Size(34, 21);
            this.c_labTotalQty.TabIndex = 1;
            this.c_labTotalQty.Text = "0";
            this.c_labTotalQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(190, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "出库数量：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "出库重量：";
            // 
            // c_labEmpyName
            // 
            this.c_labEmpyName.AutoSize = true;
            this.c_labEmpyName.Location = new System.Drawing.Point(275, 55);
            this.c_labEmpyName.Name = "c_labEmpyName";
            this.c_labEmpyName.Size = new System.Drawing.Size(37, 20);
            this.c_labEmpyName.TabIndex = 1;
            this.c_labEmpyName.Text = "张三";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "库管员：";
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
            this.c_labStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labStatus.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.c_labStatus.ForeColor = System.Drawing.Color.Blue;
            this.c_labStatus.Location = new System.Drawing.Point(431, 22);
            this.c_labStatus.Name = "c_labStatus";
            this.c_labStatus.Size = new System.Drawing.Size(90, 27);
            this.c_labStatus.TabIndex = 1;
            this.c_labStatus.Text = "未确认";
            // 
            // c_labTxnNum
            // 
            this.c_labTxnNum.Location = new System.Drawing.Point(86, 26);
            this.c_labTxnNum.Name = "c_labTxnNum";
            this.c_labTxnNum.Size = new System.Drawing.Size(81, 21);
            this.c_labTxnNum.TabIndex = 1;
            this.c_labTxnNum.Text = "WF00001";
            this.c_labTxnNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(352, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "计划状态：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "计划编号：";
            // 
            // c_btnPost
            // 
            this.c_btnPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnPost.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnPost.Location = new System.Drawing.Point(355, 55);
            this.c_btnPost.Name = "c_btnPost";
            this.c_btnPost.Size = new System.Drawing.Size(166, 49);
            this.c_btnPost.TabIndex = 0;
            this.c_btnPost.Text = "继续出库";
            this.c_btnPost.UseVisualStyleBackColor = true;
            this.c_btnPost.Click += new System.EventHandler(this.c_btnCheck_Click);
            // 
            // FrmMWPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 542);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c_labTxnCount);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c_btnStratCheckPost);
            this.Controls.Add(this.c_btnStratPost);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMWPost";
            this.Text = "FrmMWPost";
            this.Load += new System.EventHandler(this.FrmMWPost_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWPost)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button c_btnStratPost;
        private System.Windows.Forms.Button c_btnStratCheckPost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label c_labTxnCount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView c_grdMWPost;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label c_labUnit1;
        private System.Windows.Forms.Label c_labUnit2;
        private System.Windows.Forms.Label c_labTxnWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label c_labSubWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label c_labStatus;
        private System.Windows.Forms.Label c_labTxnNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button c_btnPost;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label c_labTotalQty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label c_labEmpyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_TxnNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_WSCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_EmpyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_TotleQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_TotolSubWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_TotalTxnWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_StratDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_TotleCount;
    }
}