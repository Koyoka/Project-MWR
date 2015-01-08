namespace YRKJ.MWR.WSDestory.Forms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.c_btnStratPost = new System.Windows.Forms.Button();
            this.c_btnStratCheckPost = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c_grdMWPost = new System.Windows.Forms.DataGridView();
            this.c_grdMWPost_C_CarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_Driver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_Inspector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_OutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_InDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_StratDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_TotleCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_TotolWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label13.Location = new System.Drawing.Point(965, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 21);
            this.label13.TabIndex = 29;
            this.label13.Text = "12";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label14.Location = new System.Drawing.Point(807, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(159, 21);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.c_grdMWPost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.c_grdMWPost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_grdMWPost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_grdMWPost_C_CarCode,
            this.c_grdMWPost_C_Driver,
            this.c_grdMWPost_C_Inspector,
            this.c_grdMWPost_C_OutDate,
            this.c_grdMWPost_C_InDate,
            this.c_grdMWPost_C_StratDate,
            this.c_grdMWPost_C_Status,
            this.c_grdMWPost_C_TotleCount,
            this.c_grdMWPost_C_TotolWeight});
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
            // c_grdMWPost_C_CarCode
            // 
            this.c_grdMWPost_C_CarCode.HeaderText = "车辆编号";
            this.c_grdMWPost_C_CarCode.Name = "c_grdMWPost_C_CarCode";
            this.c_grdMWPost_C_CarCode.Width = 101;
            // 
            // c_grdMWPost_C_Driver
            // 
            this.c_grdMWPost_C_Driver.FillWeight = 80F;
            this.c_grdMWPost_C_Driver.HeaderText = "司机";
            this.c_grdMWPost_C_Driver.Name = "c_grdMWPost_C_Driver";
            this.c_grdMWPost_C_Driver.Width = 80;
            // 
            // c_grdMWPost_C_Inspector
            // 
            this.c_grdMWPost_C_Inspector.FillWeight = 80F;
            this.c_grdMWPost_C_Inspector.HeaderText = "跟车员";
            this.c_grdMWPost_C_Inspector.Name = "c_grdMWPost_C_Inspector";
            this.c_grdMWPost_C_Inspector.Width = 80;
            // 
            // c_grdMWPost_C_OutDate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWPost_C_OutDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.c_grdMWPost_C_OutDate.FillWeight = 150F;
            this.c_grdMWPost_C_OutDate.HeaderText = "出车时间";
            this.c_grdMWPost_C_OutDate.Name = "c_grdMWPost_C_OutDate";
            this.c_grdMWPost_C_OutDate.Width = 150;
            // 
            // c_grdMWPost_C_InDate
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWPost_C_InDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.c_grdMWPost_C_InDate.FillWeight = 150F;
            this.c_grdMWPost_C_InDate.HeaderText = "回车时间";
            this.c_grdMWPost_C_InDate.Name = "c_grdMWPost_C_InDate";
            this.c_grdMWPost_C_InDate.Width = 150;
            // 
            // c_grdMWPost_C_StratDate
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWPost_C_StratDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.c_grdMWPost_C_StratDate.FillWeight = 150F;
            this.c_grdMWPost_C_StratDate.HeaderText = "校验时间";
            this.c_grdMWPost_C_StratDate.Name = "c_grdMWPost_C_StratDate";
            this.c_grdMWPost_C_StratDate.Width = 150;
            // 
            // c_grdMWPost_C_Status
            // 
            this.c_grdMWPost_C_Status.FillWeight = 110F;
            this.c_grdMWPost_C_Status.HeaderText = "状态";
            this.c_grdMWPost_C_Status.Name = "c_grdMWPost_C_Status";
            this.c_grdMWPost_C_Status.Width = 110;
            // 
            // c_grdMWPost_C_TotleCount
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWPost_C_TotleCount.DefaultCellStyle = dataGridViewCellStyle5;
            this.c_grdMWPost_C_TotleCount.FillWeight = 80F;
            this.c_grdMWPost_C_TotleCount.HeaderText = "总数量";
            this.c_grdMWPost_C_TotleCount.Name = "c_grdMWPost_C_TotleCount";
            this.c_grdMWPost_C_TotleCount.Width = 80;
            // 
            // c_grdMWPost_C_TotolWeight
            // 
            this.c_grdMWPost_C_TotolWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWPost_C_TotolWeight.DefaultCellStyle = dataGridViewCellStyle6;
            this.c_grdMWPost_C_TotolWeight.FillWeight = 80F;
            this.c_grdMWPost_C_TotolWeight.HeaderText = "总重量";
            this.c_grdMWPost_C_TotolWeight.Name = "c_grdMWPost_C_TotolWeight";
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
            this.groupBox2.Location = new System.Drawing.Point(12, 420);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(527, 110);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "当前出库计划";
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
            this.c_btnCheck.Text = "审核出库计划";
            this.c_btnCheck.UseVisualStyleBackColor = true;
            this.c_btnCheck.Click += new System.EventHandler(this.c_btnCheck_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(384, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 33;
            // 
            // FrmMWPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 542);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label13);
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
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView c_grdMWPost;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_CarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_Driver;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_Inspector;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_OutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_InDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_StratDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_TotleCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_TotolWeight;
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
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}