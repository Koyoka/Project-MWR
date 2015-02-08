namespace YRKJ.MWR.WSDestory.Forms
{
    partial class FrmMWDestroy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMWDestroy));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.c_btnDestRecover = new System.Windows.Forms.Button();
            this.c_btnDestInv = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c_grdMWDestroy = new System.Windows.Forms.DataGridView();
            this.c_grdMWDestroy_C_TxnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWDestroy_C_WSCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWDestroy_C_EmpyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWDestroy_C_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWDestroy_C_TotleQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWDestroy_C_TotolSubWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWDestroy_C_TotalTxnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWDestroy_C_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.c_btnCheck = new System.Windows.Forms.Button();
            this.c_labRecoverTxnCount = new System.Windows.Forms.Label();
            this.c_bgwRecoverToDest = new System.ComponentModel.BackgroundWorker();
            this.c_time = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWDestroy)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_btnDestRecover
            // 
            this.c_btnDestRecover.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnDestRecover.Image = ((System.Drawing.Image)(resources.GetObject("c_btnDestRecover.Image")));
            this.c_btnDestRecover.Location = new System.Drawing.Point(12, 12);
            this.c_btnDestRecover.Name = "c_btnDestRecover";
            this.c_btnDestRecover.Size = new System.Drawing.Size(140, 65);
            this.c_btnDestRecover.TabIndex = 29;
            this.c_btnDestRecover.Text = "车辆回收废品处置";
            this.c_btnDestRecover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnDestRecover.UseVisualStyleBackColor = true;
            this.c_btnDestRecover.Click += new System.EventHandler(this.c_btnDestRecover_Click);
            // 
            // c_btnDestInv
            // 
            this.c_btnDestInv.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnDestInv.Image = ((System.Drawing.Image)(resources.GetObject("c_btnDestInv.Image")));
            this.c_btnDestInv.Location = new System.Drawing.Point(158, 12);
            this.c_btnDestInv.Name = "c_btnDestInv";
            this.c_btnDestInv.Size = new System.Drawing.Size(140, 65);
            this.c_btnDestInv.TabIndex = 28;
            this.c_btnDestInv.Text = "库存出库废品处置";
            this.c_btnDestInv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnDestInv.UseVisualStyleBackColor = true;
            this.c_btnDestInv.Click += new System.EventHandler(this.c_btnDestInv_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(8, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 30;
            this.label1.Text = "当前处置计划列表";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.c_grdMWDestroy);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.panel1.Location = new System.Drawing.Point(12, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 225);
            this.panel1.TabIndex = 31;
            // 
            // c_grdMWDestroy
            // 
            this.c_grdMWDestroy.AllowUserToAddRows = false;
            this.c_grdMWDestroy.AllowUserToDeleteRows = false;
            this.c_grdMWDestroy.AllowUserToResizeColumns = false;
            this.c_grdMWDestroy.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.c_grdMWDestroy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.c_grdMWDestroy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_grdMWDestroy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_grdMWDestroy_C_TxnNum,
            this.c_grdMWDestroy_C_WSCode,
            this.c_grdMWDestroy_C_EmpyName,
            this.c_grdMWDestroy_C_StartDate,
            this.c_grdMWDestroy_C_TotleQty,
            this.c_grdMWDestroy_C_TotolSubWeight,
            this.c_grdMWDestroy_C_TotalTxnWeight,
            this.c_grdMWDestroy_C_Status});
            this.c_grdMWDestroy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_grdMWDestroy.Location = new System.Drawing.Point(0, 0);
            this.c_grdMWDestroy.MultiSelect = false;
            this.c_grdMWDestroy.Name = "c_grdMWDestroy";
            this.c_grdMWDestroy.RowHeadersVisible = false;
            this.c_grdMWDestroy.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWDestroy.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.c_grdMWDestroy.RowTemplate.Height = 60;
            this.c_grdMWDestroy.RowTemplate.ReadOnly = true;
            this.c_grdMWDestroy.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_grdMWDestroy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.c_grdMWDestroy.Size = new System.Drawing.Size(984, 225);
            this.c_grdMWDestroy.TabIndex = 13;
            // 
            // c_grdMWDestroy_C_TxnNum
            // 
            this.c_grdMWDestroy_C_TxnNum.HeaderText = "交易编号";
            this.c_grdMWDestroy_C_TxnNum.Name = "c_grdMWDestroy_C_TxnNum";
            this.c_grdMWDestroy_C_TxnNum.Width = 101;
            // 
            // c_grdMWDestroy_C_WSCode
            // 
            this.c_grdMWDestroy_C_WSCode.FillWeight = 80F;
            this.c_grdMWDestroy_C_WSCode.HeaderText = "工作站";
            this.c_grdMWDestroy_C_WSCode.Name = "c_grdMWDestroy_C_WSCode";
            this.c_grdMWDestroy_C_WSCode.Visible = false;
            this.c_grdMWDestroy_C_WSCode.Width = 80;
            // 
            // c_grdMWDestroy_C_EmpyName
            // 
            this.c_grdMWDestroy_C_EmpyName.FillWeight = 80F;
            this.c_grdMWDestroy_C_EmpyName.HeaderText = "操作员";
            this.c_grdMWDestroy_C_EmpyName.Name = "c_grdMWDestroy_C_EmpyName";
            this.c_grdMWDestroy_C_EmpyName.Width = 80;
            // 
            // c_grdMWDestroy_C_StartDate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWDestroy_C_StartDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.c_grdMWDestroy_C_StartDate.FillWeight = 150F;
            this.c_grdMWDestroy_C_StartDate.HeaderText = "开始时间";
            this.c_grdMWDestroy_C_StartDate.Name = "c_grdMWDestroy_C_StartDate";
            this.c_grdMWDestroy_C_StartDate.Width = 150;
            // 
            // c_grdMWDestroy_C_TotleQty
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWDestroy_C_TotleQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.c_grdMWDestroy_C_TotleQty.FillWeight = 80F;
            this.c_grdMWDestroy_C_TotleQty.HeaderText = "总数量";
            this.c_grdMWDestroy_C_TotleQty.Name = "c_grdMWDestroy_C_TotleQty";
            this.c_grdMWDestroy_C_TotleQty.Width = 80;
            // 
            // c_grdMWDestroy_C_TotolSubWeight
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWDestroy_C_TotolSubWeight.DefaultCellStyle = dataGridViewCellStyle4;
            this.c_grdMWDestroy_C_TotolSubWeight.FillWeight = 150F;
            this.c_grdMWDestroy_C_TotolSubWeight.HeaderText = "库存总重量";
            this.c_grdMWDestroy_C_TotolSubWeight.Name = "c_grdMWDestroy_C_TotolSubWeight";
            this.c_grdMWDestroy_C_TotolSubWeight.Width = 150;
            // 
            // c_grdMWDestroy_C_TotalTxnWeight
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWDestroy_C_TotalTxnWeight.DefaultCellStyle = dataGridViewCellStyle5;
            this.c_grdMWDestroy_C_TotalTxnWeight.FillWeight = 150F;
            this.c_grdMWDestroy_C_TotalTxnWeight.HeaderText = "校验总重量";
            this.c_grdMWDestroy_C_TotalTxnWeight.Name = "c_grdMWDestroy_C_TotalTxnWeight";
            this.c_grdMWDestroy_C_TotalTxnWeight.Width = 150;
            // 
            // c_grdMWDestroy_C_Status
            // 
            this.c_grdMWDestroy_C_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_grdMWDestroy_C_Status.FillWeight = 110F;
            this.c_grdMWDestroy_C_Status.HeaderText = "状态";
            this.c_grdMWDestroy_C_Status.Name = "c_grdMWDestroy_C_Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.c_btnCheck);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.groupBox2.Location = new System.Drawing.Point(12, 335);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(527, 110);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "当前处置计划";
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
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(275, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 21);
            this.label15.TabIndex = 1;
            this.label15.Text = "0";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "张三";
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
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(431, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 27);
            this.label11.TabIndex = 1;
            this.label11.Text = "未确认";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(86, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "WF00001";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // c_btnCheck
            // 
            this.c_btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnCheck.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnCheck.Location = new System.Drawing.Point(355, 55);
            this.c_btnCheck.Name = "c_btnCheck";
            this.c_btnCheck.Size = new System.Drawing.Size(166, 49);
            this.c_btnCheck.TabIndex = 0;
            this.c_btnCheck.Text = "审核处置计划";
            this.c_btnCheck.UseVisualStyleBackColor = true;
            this.c_btnCheck.Click += new System.EventHandler(this.c_btnCheck_Click);
            // 
            // c_labRecoverTxnCount
            // 
            this.c_labRecoverTxnCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.c_labRecoverTxnCount.ForeColor = System.Drawing.Color.White;
            this.c_labRecoverTxnCount.Image = ((System.Drawing.Image)(resources.GetObject("c_labRecoverTxnCount.Image")));
            this.c_labRecoverTxnCount.Location = new System.Drawing.Point(128, 0);
            this.c_labRecoverTxnCount.Name = "c_labRecoverTxnCount";
            this.c_labRecoverTxnCount.Size = new System.Drawing.Size(37, 27);
            this.c_labRecoverTxnCount.TabIndex = 34;
            this.c_labRecoverTxnCount.Text = "0";
            this.c_labRecoverTxnCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.c_labRecoverTxnCount.Visible = false;
            // 
            // c_bgwRecoverToDest
            // 
            this.c_bgwRecoverToDest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.c_bgwRecoverToDest_DoWork);
            // 
            // c_time
            // 
            this.c_time.Interval = 2000;
            this.c_time.Tick += new System.EventHandler(this.c_time_Tick);
            // 
            // FrmMWDestroy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 457);
            this.Controls.Add(this.c_labRecoverTxnCount);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c_btnDestRecover);
            this.Controls.Add(this.c_btnDestInv);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMWDestroy";
            this.Text = "FrmMWDestory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMWDestory_FormClosing);
            this.Load += new System.EventHandler(this.FrmMWDestory_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWDestroy)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button c_btnDestRecover;
        private System.Windows.Forms.Button c_btnDestInv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button c_btnCheck;
        private System.Windows.Forms.Label c_labRecoverTxnCount;
        private System.ComponentModel.BackgroundWorker c_bgwRecoverToDest;
        private System.Windows.Forms.Timer c_time;
        private System.Windows.Forms.DataGridView c_grdMWDestroy;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWDestroy_C_TxnNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWDestroy_C_WSCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWDestroy_C_EmpyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWDestroy_C_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWDestroy_C_TotleQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWDestroy_C_TotolSubWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWDestroy_C_TotalTxnWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWDestroy_C_Status;
    }
}