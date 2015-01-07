namespace YRKJ.MWR.WSDestory.Forms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMWRecover));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.c_grdMWRecover = new System.Windows.Forms.DataGridView();
            this.c_grdMWRecover_C_CarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_Driver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_Inspector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_OutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_InDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_StratDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_btnStratRecover = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWRecover)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "入库计划 当前提交计划列表";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(248, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 1;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.c_grdMWRecover_C_Status,
            this.c_grdMWRecover_C_StratDate});
            this.c_grdMWRecover.Location = new System.Drawing.Point(12, 38);
            this.c_grdMWRecover.MultiSelect = false;
            this.c_grdMWRecover.Name = "c_grdMWRecover";
            this.c_grdMWRecover.RowHeadersVisible = false;
            this.c_grdMWRecover.RowTemplate.Height = 35;
            this.c_grdMWRecover.RowTemplate.ReadOnly = true;
            this.c_grdMWRecover.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_grdMWRecover.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.c_grdMWRecover.Size = new System.Drawing.Size(878, 289);
            this.c_grdMWRecover.TabIndex = 12;
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
            // c_grdMWRecover_C_Status
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_Status.DefaultCellStyle = dataGridViewCellStyle4;
            this.c_grdMWRecover_C_Status.HeaderText = "货箱状态";
            this.c_grdMWRecover_C_Status.Name = "c_grdMWRecover_C_Status";
            // 
            // c_grdMWRecover_C_StratDate
            // 
            this.c_grdMWRecover_C_StratDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWRecover_C_StratDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.c_grdMWRecover_C_StratDate.HeaderText = "开始入库时间";
            this.c_grdMWRecover_C_StratDate.Name = "c_grdMWRecover_C_StratDate";
            // 
            // c_btnStratRecover
            // 
            this.c_btnStratRecover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnStratRecover.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnStratRecover.Image = ((System.Drawing.Image)(resources.GetObject("c_btnStratRecover.Image")));
            this.c_btnStratRecover.Location = new System.Drawing.Point(751, 333);
            this.c_btnStratRecover.Name = "c_btnStratRecover";
            this.c_btnStratRecover.Size = new System.Drawing.Size(139, 65);
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
            this.label2.Location = new System.Drawing.Point(699, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "当前入库计划数：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(858, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "12";
            // 
            // FrmMWRecover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 410);
            this.Controls.Add(this.c_btnStratRecover);
            this.Controls.Add(this.c_grdMWRecover);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMWRecover";
            this.Text = "FrmMWRecover";
            this.Load += new System.EventHandler(this.FrmMWRecover_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWRecover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView c_grdMWRecover;
        private System.Windows.Forms.Button c_btnStratRecover;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_CarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_Driver;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_Inspector;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_OutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_InDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_StratDate;
    }
}