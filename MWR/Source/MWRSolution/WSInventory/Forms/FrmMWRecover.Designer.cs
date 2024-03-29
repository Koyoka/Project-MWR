﻿namespace YRKJ.MWR.WSInventory.Forms
{
    partial class FrmMWRecover
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMWRecover));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.c_grdMWRecover = new System.Windows.Forms.DataGridView();
            this.c_btnStratRecover = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.c_labHeaderCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.c_bgwGetRecoverTxnHeader = new System.ComponentModel.BackgroundWorker();
            this.c_time = new System.Windows.Forms.Timer(this.components);
            this.c_grdMWRecover_C_CarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_Driver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_Inspector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_OutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_InDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_TotleCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_TotolWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWRecover)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_grdMWRecover
            // 
            this.c_grdMWRecover.AllowUserToAddRows = false;
            this.c_grdMWRecover.AllowUserToDeleteRows = false;
            this.c_grdMWRecover.AllowUserToResizeColumns = false;
            this.c_grdMWRecover.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.c_grdMWRecover.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.c_grdMWRecover.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_grdMWRecover.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_grdMWRecover_C_CarCode,
            this.c_grdMWRecover_C_Driver,
            this.c_grdMWRecover_C_Inspector,
            this.c_grdMWRecover_C_OutDate,
            this.c_grdMWRecover_C_InDate,
            this.c_grdMWRecover_C_StartDate,
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
            this.c_grdMWRecover.Size = new System.Drawing.Size(984, 293);
            this.c_grdMWRecover.TabIndex = 12;
            // 
            // c_btnStratRecover
            // 
            this.c_btnStratRecover.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnStratRecover.Image = ((System.Drawing.Image)(resources.GetObject("c_btnStratRecover.Image")));
            this.c_btnStratRecover.Location = new System.Drawing.Point(12, 12);
            this.c_btnStratRecover.Name = "c_btnStratRecover";
            this.c_btnStratRecover.Size = new System.Drawing.Size(140, 65);
            this.c_btnStratRecover.TabIndex = 13;
            this.c_btnStratRecover.Text = "开始入库";
            this.c_btnStratRecover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnStratRecover.UseVisualStyleBackColor = true;
            this.c_btnStratRecover.Click += new System.EventHandler(this.c_btnStratRecover_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(800, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "计划数：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_labHeaderCount
            // 
            this.c_labHeaderCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labHeaderCount.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_labHeaderCount.Location = new System.Drawing.Point(965, 80);
            this.c_labHeaderCount.Name = "c_labHeaderCount";
            this.c_labHeaderCount.Size = new System.Drawing.Size(40, 20);
            this.c_labHeaderCount.TabIndex = 0;
            this.c_labHeaderCount.Text = "0";
            this.c_labHeaderCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.c_grdMWRecover);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.panel1.Location = new System.Drawing.Point(12, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 293);
            this.panel1.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label4.Location = new System.Drawing.Point(8, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "当前提交计划列表";
            // 
            // c_bgwGetRecoverTxnHeader
            // 
            this.c_bgwGetRecoverTxnHeader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.c_bgwGetRecoverTxnHeader_DoWork);
            // 
            // c_time
            // 
            this.c_time.Interval = 1000;
            this.c_time.Tick += new System.EventHandler(this.c_time_Tick);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_OutDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.c_grdMWRecover_C_OutDate.FillWeight = 150F;
            this.c_grdMWRecover_C_OutDate.HeaderText = "出车时间";
            this.c_grdMWRecover_C_OutDate.Name = "c_grdMWRecover_C_OutDate";
            this.c_grdMWRecover_C_OutDate.Width = 150;
            // 
            // c_grdMWRecover_C_InDate
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_InDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.c_grdMWRecover_C_InDate.FillWeight = 150F;
            this.c_grdMWRecover_C_InDate.HeaderText = "回车时间";
            this.c_grdMWRecover_C_InDate.Name = "c_grdMWRecover_C_InDate";
            this.c_grdMWRecover_C_InDate.Width = 150;
            // 
            // c_grdMWRecover_C_StartDate
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_StartDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.c_grdMWRecover_C_StartDate.FillWeight = 150F;
            this.c_grdMWRecover_C_StartDate.HeaderText = "校验时间";
            this.c_grdMWRecover_C_StartDate.Name = "c_grdMWRecover_C_StartDate";
            this.c_grdMWRecover_C_StartDate.Width = 150;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_TotleCount.DefaultCellStyle = dataGridViewCellStyle5;
            this.c_grdMWRecover_C_TotleCount.FillWeight = 80F;
            this.c_grdMWRecover_C_TotleCount.HeaderText = "总数量";
            this.c_grdMWRecover_C_TotleCount.Name = "c_grdMWRecover_C_TotleCount";
            this.c_grdMWRecover_C_TotleCount.Width = 80;
            // 
            // c_grdMWRecover_C_TotolWeight
            // 
            this.c_grdMWRecover_C_TotolWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_TotolWeight.DefaultCellStyle = dataGridViewCellStyle6;
            this.c_grdMWRecover_C_TotolWeight.FillWeight = 80F;
            this.c_grdMWRecover_C_TotolWeight.HeaderText = "总重量";
            this.c_grdMWRecover_C_TotolWeight.Name = "c_grdMWRecover_C_TotolWeight";
            // 
            // FrmMWRecover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 409);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c_btnStratRecover);
            this.Controls.Add(this.c_labHeaderCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMWRecover";
            this.Text = "FrmMWRecover";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMWRecover_FormClosing);
            this.Load += new System.EventHandler(this.FrmMWRecover_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWRecover)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView c_grdMWRecover;
        private System.Windows.Forms.Button c_btnStratRecover;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label c_labHeaderCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker c_bgwGetRecoverTxnHeader;
        private System.Windows.Forms.Timer c_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_CarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_Driver;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_Inspector;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_OutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_InDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_TotleCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_TotolWeight;
    }
}