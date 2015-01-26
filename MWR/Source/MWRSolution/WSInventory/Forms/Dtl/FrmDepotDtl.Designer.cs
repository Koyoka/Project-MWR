namespace YRKJ.MWR.WSInventory.Forms.Dtl
{
    partial class FrmDepotDtl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.c_btnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c_grdDepot = new System.Windows.Forms.DataGridView();
            this.c_btnCancel = new System.Windows.Forms.Button();
            this.c_grdDepot_C_DepotCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdDepot_C_Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_grdDepot)).BeginInit();
            this.SuspendLayout();
            // 
            // c_btnOk
            // 
            this.c_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnOk.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.c_btnOk.Location = new System.Drawing.Point(258, 384);
            this.c_btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c_btnOk.Name = "c_btnOk";
            this.c_btnOk.Size = new System.Drawing.Size(140, 60);
            this.c_btnOk.TabIndex = 0;
            this.c_btnOk.Text = "确认";
            this.c_btnOk.UseVisualStyleBackColor = true;
            this.c_btnOk.Click += new System.EventHandler(this.c_btnOk_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.c_grdDepot);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 363);
            this.panel1.TabIndex = 15;
            // 
            // c_grdDepot
            // 
            this.c_grdDepot.AllowUserToAddRows = false;
            this.c_grdDepot.AllowUserToDeleteRows = false;
            this.c_grdDepot.AllowUserToResizeColumns = false;
            this.c_grdDepot.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.c_grdDepot.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.c_grdDepot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_grdDepot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_grdDepot_C_DepotCode,
            this.c_grdDepot_C_Desc});
            this.c_grdDepot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_grdDepot.Location = new System.Drawing.Point(0, 0);
            this.c_grdDepot.MultiSelect = false;
            this.c_grdDepot.Name = "c_grdDepot";
            this.c_grdDepot.RowHeadersVisible = false;
            this.c_grdDepot.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdDepot.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.c_grdDepot.RowTemplate.Height = 60;
            this.c_grdDepot.RowTemplate.ReadOnly = true;
            this.c_grdDepot.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_grdDepot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.c_grdDepot.Size = new System.Drawing.Size(381, 363);
            this.c_grdDepot.TabIndex = 12;
            // 
            // c_btnCancel
            // 
            this.c_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.c_btnCancel.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.c_btnCancel.Location = new System.Drawing.Point(12, 382);
            this.c_btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c_btnCancel.Name = "c_btnCancel";
            this.c_btnCancel.Size = new System.Drawing.Size(140, 60);
            this.c_btnCancel.TabIndex = 0;
            this.c_btnCancel.Text = "取消";
            this.c_btnCancel.UseVisualStyleBackColor = true;
            this.c_btnCancel.Click += new System.EventHandler(this.c_btnCancel_Click);
            // 
            // c_grdDepot_C_DepotCode
            // 
            this.c_grdDepot_C_DepotCode.HeaderText = "仓库编号";
            this.c_grdDepot_C_DepotCode.Name = "c_grdDepot_C_DepotCode";
            this.c_grdDepot_C_DepotCode.Width = 101;
            // 
            // c_grdDepot_C_Desc
            // 
            this.c_grdDepot_C_Desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_grdDepot_C_Desc.FillWeight = 80F;
            this.c_grdDepot_C_Desc.HeaderText = "仓库名称";
            this.c_grdDepot_C_Desc.Name = "c_grdDepot_C_Desc";
            // 
            // FrmDepotDtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 455);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c_btnCancel);
            this.Controls.Add(this.c_btnOk);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmDepotDtl";
            this.Text = "FrmDepotDtl";
            this.Load += new System.EventHandler(this.FrmDepotDtl_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_grdDepot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button c_btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView c_grdDepot;
        private System.Windows.Forms.Button c_btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdDepot_C_DepotCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdDepot_C_Desc;
    }
}