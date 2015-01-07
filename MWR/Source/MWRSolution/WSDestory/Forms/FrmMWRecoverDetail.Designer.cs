namespace YRKJ.MWR.WSDestory.Forms
{
    partial class FrmMWRecoverDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMWRecoverDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            this.c_btnStopRecover = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.c_grdMWRecover = new System.Windows.Forms.DataGridView();
            this.c_grdMWRecover_C_CarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_Driver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_Inspector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_OutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_InDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_StratDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWRecover)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_btnStopRecover
            // 
            this.c_btnStopRecover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnStopRecover.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnStopRecover.Image = ((System.Drawing.Image)(resources.GetObject("c_btnStopRecover.Image")));
            this.c_btnStopRecover.Location = new System.Drawing.Point(743, 47);
            this.c_btnStopRecover.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c_btnStopRecover.Name = "c_btnStopRecover";
            this.c_btnStopRecover.Size = new System.Drawing.Size(133, 65);
            this.c_btnStopRecover.TabIndex = 0;
            this.c_btnStopRecover.Text = "停止入库";
            this.c_btnStopRecover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnStopRecover.UseVisualStyleBackColor = true;
            this.c_btnStopRecover.Click += new System.EventHandler(this.c_btnStopRecover_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当前计划";
            // 
            // c_grdMWRecover
            // 
            this.c_grdMWRecover.AllowUserToAddRows = false;
            this.c_grdMWRecover.AllowUserToDeleteRows = false;
            this.c_grdMWRecover.AllowUserToResizeColumns = false;
            this.c_grdMWRecover.AllowUserToResizeRows = false;
            this.c_grdMWRecover.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle56.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle56.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle56.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle56.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle56.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.c_grdMWRecover.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle56;
            this.c_grdMWRecover.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_grdMWRecover.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_grdMWRecover_C_CarCode,
            this.c_grdMWRecover_C_Driver,
            this.c_grdMWRecover_C_Inspector,
            this.c_grdMWRecover_C_OutDate,
            this.c_grdMWRecover_C_InDate,
            this.c_grdMWRecover_C_Status,
            this.c_grdMWRecover_C_StratDate});
            this.c_grdMWRecover.Location = new System.Drawing.Point(12, 118);
            this.c_grdMWRecover.MultiSelect = false;
            this.c_grdMWRecover.Name = "c_grdMWRecover";
            this.c_grdMWRecover.RowHeadersVisible = false;
            this.c_grdMWRecover.RowTemplate.Height = 35;
            this.c_grdMWRecover.RowTemplate.ReadOnly = true;
            this.c_grdMWRecover.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_grdMWRecover.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.c_grdMWRecover.Size = new System.Drawing.Size(864, 308);
            this.c_grdMWRecover.TabIndex = 13;
            // 
            // c_grdMWRecover_C_CarCode
            // 
            this.c_grdMWRecover_C_CarCode.HeaderText = "车辆编号";
            this.c_grdMWRecover_C_CarCode.Name = "c_grdMWRecover_C_CarCode";
            // 
            // c_grdMWRecover_C_Driver
            // 
            this.c_grdMWRecover_C_Driver.HeaderText = "司机";
            this.c_grdMWRecover_C_Driver.Name = "c_grdMWRecover_C_Driver";
            // 
            // c_grdMWRecover_C_Inspector
            // 
            this.c_grdMWRecover_C_Inspector.HeaderText = "跟车员";
            this.c_grdMWRecover_C_Inspector.Name = "c_grdMWRecover_C_Inspector";
            // 
            // c_grdMWRecover_C_OutDate
            // 
            dataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_OutDate.DefaultCellStyle = dataGridViewCellStyle57;
            this.c_grdMWRecover_C_OutDate.FillWeight = 150F;
            this.c_grdMWRecover_C_OutDate.HeaderText = "出车时间";
            this.c_grdMWRecover_C_OutDate.Name = "c_grdMWRecover_C_OutDate";
            this.c_grdMWRecover_C_OutDate.Width = 150;
            // 
            // c_grdMWRecover_C_InDate
            // 
            dataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_InDate.DefaultCellStyle = dataGridViewCellStyle58;
            this.c_grdMWRecover_C_InDate.FillWeight = 150F;
            this.c_grdMWRecover_C_InDate.HeaderText = "回车时间";
            this.c_grdMWRecover_C_InDate.Name = "c_grdMWRecover_C_InDate";
            this.c_grdMWRecover_C_InDate.Width = 150;
            // 
            // c_grdMWRecover_C_Status
            // 
            dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_Status.DefaultCellStyle = dataGridViewCellStyle59;
            this.c_grdMWRecover_C_Status.HeaderText = "货箱状态";
            this.c_grdMWRecover_C_Status.Name = "c_grdMWRecover_C_Status";
            // 
            // c_grdMWRecover_C_StratDate
            // 
            this.c_grdMWRecover_C_StratDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_StratDate.DefaultCellStyle = dataGridViewCellStyle60;
            this.c_grdMWRecover_C_StratDate.HeaderText = "开始入库时间";
            this.c_grdMWRecover_C_StratDate.Name = "c_grdMWRecover_C_StratDate";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(743, 465);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 65);
            this.button1.TabIndex = 0;
            this.button1.Text = "确认入库";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.c_btnStopRecover_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 435);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 100);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "当前货箱";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(555, 435);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 95);
            this.panel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(148, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "箱";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("微软雅黑", 38F);
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(69, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 78);
            this.label2.TabIndex = 0;
            this.label2.Text = "18";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(38, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "剩余：";
            // 
            // FrmMWRecoverDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 543);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.c_grdMWRecover);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.c_btnStopRecover);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMWRecoverDetail";
            this.Text = "FrmMWRecoverDetail";
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWRecover)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button c_btnStopRecover;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView c_grdMWRecover;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_CarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_Driver;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_Inspector;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_OutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_InDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_StratDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}