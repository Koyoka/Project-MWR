namespace VITCMSApp
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.c_grd_txtIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grd_txtImageTargetId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grd_btnDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.c_btnRef = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_grd_txtIndex,
            this.c_grd_txtImageTargetId,
            this.c_grd_btnDetail});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(502, 318);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // c_grd_txtIndex
            // 
            this.c_grd_txtIndex.DataPropertyName = "Index";
            this.c_grd_txtIndex.Frozen = true;
            this.c_grd_txtIndex.HeaderText = "序号";
            this.c_grd_txtIndex.Name = "c_grd_txtIndex";
            this.c_grd_txtIndex.ReadOnly = true;
            // 
            // c_grd_txtImageTargetId
            // 
            this.c_grd_txtImageTargetId.DataPropertyName = "ImageTargetId";
            this.c_grd_txtImageTargetId.Frozen = true;
            this.c_grd_txtImageTargetId.HeaderText = "id";
            this.c_grd_txtImageTargetId.MinimumWidth = 200;
            this.c_grd_txtImageTargetId.Name = "c_grd_txtImageTargetId";
            this.c_grd_txtImageTargetId.ReadOnly = true;
            this.c_grd_txtImageTargetId.Width = 200;
            // 
            // c_grd_btnDetail
            // 
            this.c_grd_btnDetail.Frozen = true;
            this.c_grd_btnDetail.HeaderText = "查看";
            this.c_grd_btnDetail.Name = "c_grd_btnDetail";
            this.c_grd_btnDetail.Text = "detail";
            this.c_grd_btnDetail.UseColumnTextForButtonValue = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(343, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // c_btnRef
            // 
            this.c_btnRef.Location = new System.Drawing.Point(166, 336);
            this.c_btnRef.Name = "c_btnRef";
            this.c_btnRef.Size = new System.Drawing.Size(171, 23);
            this.c_btnRef.TabIndex = 1;
            this.c_btnRef.Text = "刷新";
            this.c_btnRef.UseVisualStyleBackColor = true;
            this.c_btnRef.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 371);
            this.Controls.Add(this.c_btnRef);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grd_txtIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grd_txtImageTargetId;
        private System.Windows.Forms.DataGridViewButtonColumn c_grd_btnDetail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button c_btnRef;
    }
}