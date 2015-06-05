namespace DBUpdate
{
    partial class FrmMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.c_txtDBName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.c_txtSqlPath = new System.Windows.Forms.TextBox();
            this.c_txtService = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.c_treConn = new System.Windows.Forms.TreeView();
            this.label5 = new System.Windows.Forms.Label();
            this.c_btnCreateConn = new System.Windows.Forms.Button();
            this.c_panContent = new System.Windows.Forms.Panel();
            this.c_btnUpdate = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.c_txtConnName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.c_panContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.c_txtDBName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.c_txtSqlPath);
            this.groupBox1.Controls.Add(this.c_txtConnName);
            this.groupBox1.Controls.Add(this.c_txtService);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库信息";
            // 
            // c_txtDBName
            // 
            this.c_txtDBName.Location = new System.Drawing.Point(316, 52);
            this.c_txtDBName.Name = "c_txtDBName";
            this.c_txtDBName.ReadOnly = true;
            this.c_txtDBName.Size = new System.Drawing.Size(144, 21);
            this.c_txtDBName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "数据库";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "Sql脚本地址";
            // 
            // c_txtSqlPath
            // 
            this.c_txtSqlPath.Location = new System.Drawing.Point(86, 81);
            this.c_txtSqlPath.Name = "c_txtSqlPath";
            this.c_txtSqlPath.ReadOnly = true;
            this.c_txtSqlPath.Size = new System.Drawing.Size(374, 21);
            this.c_txtSqlPath.TabIndex = 3;
            // 
            // c_txtService
            // 
            this.c_txtService.Location = new System.Drawing.Point(86, 52);
            this.c_txtService.Name = "c_txtService";
            this.c_txtService.ReadOnly = true;
            this.c_txtService.Size = new System.Drawing.Size(150, 21);
            this.c_txtService.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器地址";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(3, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 359);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "信息";
            // 
            // c_treConn
            // 
            this.c_treConn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_treConn.Font = new System.Drawing.Font("宋体", 10F);
            this.c_treConn.Location = new System.Drawing.Point(3, 32);
            this.c_treConn.Name = "c_treConn";
            this.c_treConn.Size = new System.Drawing.Size(238, 530);
            this.c_treConn.TabIndex = 2;
            this.c_treConn.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.c_treConn_AfterSelect);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "连接";
            // 
            // c_btnCreateConn
            // 
            this.c_btnCreateConn.Location = new System.Drawing.Point(3, 3);
            this.c_btnCreateConn.Name = "c_btnCreateConn";
            this.c_btnCreateConn.Size = new System.Drawing.Size(75, 23);
            this.c_btnCreateConn.TabIndex = 4;
            this.c_btnCreateConn.Text = "新建连接";
            this.c_btnCreateConn.UseVisualStyleBackColor = true;
            this.c_btnCreateConn.Click += new System.EventHandler(this.c_btnCreateConn_Click);
            // 
            // c_panContent
            // 
            this.c_panContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_panContent.BackColor = System.Drawing.Color.White;
            this.c_panContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c_panContent.Controls.Add(this.c_btnUpdate);
            this.c_panContent.Controls.Add(this.groupBox1);
            this.c_panContent.Controls.Add(this.groupBox2);
            this.c_panContent.Location = new System.Drawing.Point(3, 32);
            this.c_panContent.Name = "c_panContent";
            this.c_panContent.Size = new System.Drawing.Size(505, 530);
            this.c_panContent.TabIndex = 5;
            // 
            // c_btnUpdate
            // 
            this.c_btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnUpdate.Enabled = false;
            this.c_btnUpdate.Location = new System.Drawing.Point(425, 501);
            this.c_btnUpdate.Name = "c_btnUpdate";
            this.c_btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.c_btnUpdate.TabIndex = 2;
            this.c_btnUpdate.Text = "开始更新";
            this.c_btnUpdate.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.c_treConn);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.c_panContent);
            this.splitContainer1.Panel2.Controls.Add(this.c_btnCreateConn);
            this.splitContainer1.Size = new System.Drawing.Size(759, 567);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "连接名称";
            // 
            // c_txtConnName
            // 
            this.c_txtConnName.Location = new System.Drawing.Point(86, 24);
            this.c_txtConnName.Name = "c_txtConnName";
            this.c_txtConnName.ReadOnly = true;
            this.c_txtConnName.Size = new System.Drawing.Size(150, 21);
            this.c_txtConnName.TabIndex = 1;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 580);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.c_panContent.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox c_txtService;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox c_txtDBName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView c_treConn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button c_btnCreateConn;
        private System.Windows.Forms.Panel c_panContent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox c_txtSqlPath;
        private System.Windows.Forms.Button c_btnUpdate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox c_txtConnName;
        private System.Windows.Forms.Label label2;
    }
}