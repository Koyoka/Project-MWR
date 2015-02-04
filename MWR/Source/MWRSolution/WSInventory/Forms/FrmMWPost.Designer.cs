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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.c_btnPost = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.c_labTxnCount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c_grdMWPost = new System.Windows.Forms.DataGridView();
            this.c_grdMWPost_C_TxnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_WSCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_EmpyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_TotleQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_TotolSubWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_TotalTxnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWPost_C_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_btnCheck = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWPost)).BeginInit();
            this.SuspendLayout();
            // 
            // c_btnPost
            // 
            this.c_btnPost.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnPost.Image = ((System.Drawing.Image)(resources.GetObject("c_btnPost.Image")));
            this.c_btnPost.Location = new System.Drawing.Point(12, 12);
            this.c_btnPost.Name = "c_btnPost";
            this.c_btnPost.Size = new System.Drawing.Size(140, 65);
            this.c_btnPost.TabIndex = 27;
            this.c_btnPost.Text = "开始出库";
            this.c_btnPost.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnPost.UseVisualStyleBackColor = true;
            this.c_btnPost.Click += new System.EventHandler(this.c_btnPost_Click);
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
            this.panel1.Size = new System.Drawing.Size(984, 426);
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
            this.c_grdMWPost_C_TxnNum,
            this.c_grdMWPost_C_WSCode,
            this.c_grdMWPost_C_EmpyName,
            this.c_grdMWPost_C_StartDate,
            this.c_grdMWPost_C_TotleQty,
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
            this.c_grdMWPost.Size = new System.Drawing.Size(984, 426);
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
            // c_grdMWPost_C_StartDate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWPost_C_StartDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.c_grdMWPost_C_StartDate.FillWeight = 150F;
            this.c_grdMWPost_C_StartDate.HeaderText = "开始时间";
            this.c_grdMWPost_C_StartDate.Name = "c_grdMWPost_C_StartDate";
            this.c_grdMWPost_C_StartDate.Width = 150;
            // 
            // c_grdMWPost_C_TotleQty
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWPost_C_TotleQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.c_grdMWPost_C_TotleQty.FillWeight = 80F;
            this.c_grdMWPost_C_TotleQty.HeaderText = "总数量";
            this.c_grdMWPost_C_TotleQty.Name = "c_grdMWPost_C_TotleQty";
            this.c_grdMWPost_C_TotleQty.Width = 80;
            // 
            // c_grdMWPost_C_TotolSubWeight
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWPost_C_TotolSubWeight.DefaultCellStyle = dataGridViewCellStyle4;
            this.c_grdMWPost_C_TotolSubWeight.FillWeight = 150F;
            this.c_grdMWPost_C_TotolSubWeight.HeaderText = "库存总重量";
            this.c_grdMWPost_C_TotolSubWeight.Name = "c_grdMWPost_C_TotolSubWeight";
            this.c_grdMWPost_C_TotolSubWeight.Width = 150;
            // 
            // c_grdMWPost_C_TotalTxnWeight
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWPost_C_TotalTxnWeight.DefaultCellStyle = dataGridViewCellStyle5;
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
            // c_btnCheck
            // 
            this.c_btnCheck.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnCheck.Image = ((System.Drawing.Image)(resources.GetObject("c_btnCheck.Image")));
            this.c_btnCheck.Location = new System.Drawing.Point(158, 12);
            this.c_btnCheck.Name = "c_btnCheck";
            this.c_btnCheck.Size = new System.Drawing.Size(140, 65);
            this.c_btnCheck.TabIndex = 0;
            this.c_btnCheck.Text = "继续出库";
            this.c_btnCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnCheck.UseVisualStyleBackColor = true;
            this.c_btnCheck.Click += new System.EventHandler(this.c_btnCheck_Click);
            // 
            // FrmMWPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 542);
            this.Controls.Add(this.c_btnCheck);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c_labTxnCount);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c_btnPost);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMWPost";
            this.Text = "FrmMWPost";
            this.Load += new System.EventHandler(this.FrmMWPost_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWPost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button c_btnPost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label c_labTxnCount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView c_grdMWPost;
        private System.Windows.Forms.Button c_btnCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_TxnNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_WSCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_EmpyName;
        //private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_StartDate;
        //private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_TotleQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_TotolSubWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_TotalTxnWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWPost_C_TotleQty;
    }
}