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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.c_btnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c_grdMWRecover = new System.Windows.Forms.DataGridView();
            this.c_grdMWRecover_C_CarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWRecover_C_Driver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWRecover)).BeginInit();
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
            this.panel1.Controls.Add(this.c_grdMWRecover);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 363);
            this.panel1.TabIndex = 15;
            // 
            // c_grdMWRecover
            // 
            this.c_grdMWRecover.AllowUserToAddRows = false;
            this.c_grdMWRecover.AllowUserToDeleteRows = false;
            this.c_grdMWRecover.AllowUserToResizeColumns = false;
            this.c_grdMWRecover.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.c_grdMWRecover.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.c_grdMWRecover.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_grdMWRecover.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_grdMWRecover_C_CarCode,
            this.c_grdMWRecover_C_Driver});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 11F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.c_grdMWRecover.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.c_grdMWRecover.Size = new System.Drawing.Size(381, 363);
            this.c_grdMWRecover.TabIndex = 12;
            // 
            // c_grdMWRecover_C_CarCode
            // 
            this.c_grdMWRecover_C_CarCode.HeaderText = "仓库编号";
            this.c_grdMWRecover_C_CarCode.Name = "c_grdMWRecover_C_CarCode";
            this.c_grdMWRecover_C_CarCode.Width = 101;
            // 
            // c_grdMWRecover_C_Driver
            // 
            this.c_grdMWRecover_C_Driver.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_grdMWRecover_C_Driver.FillWeight = 80F;
            this.c_grdMWRecover_C_Driver.HeaderText = "仓库名称";
            this.c_grdMWRecover_C_Driver.Name = "c_grdMWRecover_C_Driver";
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
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWRecover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button c_btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView c_grdMWRecover;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_CarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWRecover_C_Driver;
        private System.Windows.Forms.Button c_btnCancel;
    }
}