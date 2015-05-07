namespace YRKJ.MWR.WSDestory.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.c_panForm = new System.Windows.Forms.Panel();
            this.c_sspMain = new System.Windows.Forms.StatusStrip();
            this.c_sspMain_L_txtEmpy = new System.Windows.Forms.ToolStripStatusLabel();
            this.c_sspMain_R_txtTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c_labRecoverTxnCount = new System.Windows.Forms.Label();
            this.c_btnMWPost = new System.Windows.Forms.Button();
            this.c_btnMWRecover = new System.Windows.Forms.Button();
            this.c_btnInvSearch = new System.Windows.Forms.Button();
            this.c_labBg2 = new System.Windows.Forms.Label();
            this.c_labBg1 = new System.Windows.Forms.Label();
            this.c_labBg3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.c_btnLogout = new System.Windows.Forms.Button();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.c_sspMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // c_panForm
            // 
            this.c_panForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_panForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c_panForm.Location = new System.Drawing.Point(0, 113);
            this.c_panForm.Name = "c_panForm";
            this.c_panForm.Size = new System.Drawing.Size(1008, 595);
            this.c_panForm.TabIndex = 2;
            // 
            // c_sspMain
            // 
            this.c_sspMain.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.c_sspMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_sspMain_L_txtEmpy,
            this.c_sspMain_R_txtTime});
            this.c_sspMain.Location = new System.Drawing.Point(0, 705);
            this.c_sspMain.Name = "c_sspMain";
            this.c_sspMain.Size = new System.Drawing.Size(1008, 25);
            this.c_sspMain.TabIndex = 3;
            this.c_sspMain.Text = "statusStrip1";
            // 
            // c_sspMain_L_txtEmpy
            // 
            this.c_sspMain_L_txtEmpy.Name = "c_sspMain_L_txtEmpy";
            this.c_sspMain_L_txtEmpy.Size = new System.Drawing.Size(758, 20);
            this.c_sspMain_L_txtEmpy.Spring = true;
            this.c_sspMain_L_txtEmpy.Text = "登陆员工:xxx";
            this.c_sspMain_L_txtEmpy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c_sspMain_R_txtTime
            // 
            this.c_sspMain_R_txtTime.Name = "c_sspMain_R_txtTime";
            this.c_sspMain_R_txtTime.Size = new System.Drawing.Size(204, 20);
            this.c_sspMain_R_txtTime.Text = "时间：2015-01-01 12:00:00";
            this.c_sspMain_R_txtTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.c_labRecoverTxnCount);
            this.panel1.Controls.Add(this.c_btnMWPost);
            this.panel1.Controls.Add(this.c_btnMWRecover);
            this.panel1.Controls.Add(this.c_btnInvSearch);
            this.panel1.Controls.Add(this.c_labBg2);
            this.panel1.Controls.Add(this.c_labBg1);
            this.panel1.Controls.Add(this.c_labBg3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.c_btnLogout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 113);
            this.panel1.TabIndex = 2;
            // 
            // c_labRecoverTxnCount
            // 
            this.c_labRecoverTxnCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.c_labRecoverTxnCount.ForeColor = System.Drawing.Color.White;
            this.c_labRecoverTxnCount.Image = ((System.Drawing.Image)(resources.GetObject("c_labRecoverTxnCount.Image")));
            this.c_labRecoverTxnCount.Location = new System.Drawing.Point(275, 31);
            this.c_labRecoverTxnCount.Name = "c_labRecoverTxnCount";
            this.c_labRecoverTxnCount.Size = new System.Drawing.Size(37, 27);
            this.c_labRecoverTxnCount.TabIndex = 3;
            this.c_labRecoverTxnCount.Text = "0";
            this.c_labRecoverTxnCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.c_labRecoverTxnCount.Visible = false;
            // 
            // c_btnMWPost
            // 
            this.c_btnMWPost.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnMWPost.Image = ((System.Drawing.Image)(resources.GetObject("c_btnMWPost.Image")));
            this.c_btnMWPost.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.c_btnMWPost.Location = new System.Drawing.Point(316, 37);
            this.c_btnMWPost.Name = "c_btnMWPost";
            this.c_btnMWPost.Size = new System.Drawing.Size(135, 61);
            this.c_btnMWPost.TabIndex = 0;
            this.c_btnMWPost.Text = "残渣管理";
            this.c_btnMWPost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.c_btnMWPost.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnMWPost.UseVisualStyleBackColor = true;
            this.c_btnMWPost.Click += new System.EventHandler(this.c_btnMWPost_Click);
            // 
            // c_btnMWRecover
            // 
            this.c_btnMWRecover.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnMWRecover.Image = ((System.Drawing.Image)(resources.GetObject("c_btnMWRecover.Image")));
            this.c_btnMWRecover.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.c_btnMWRecover.Location = new System.Drawing.Point(160, 37);
            this.c_btnMWRecover.Name = "c_btnMWRecover";
            this.c_btnMWRecover.Size = new System.Drawing.Size(135, 61);
            this.c_btnMWRecover.TabIndex = 0;
            this.c_btnMWRecover.Text = "废品处置";
            this.c_btnMWRecover.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.c_btnMWRecover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnMWRecover.UseVisualStyleBackColor = true;
            this.c_btnMWRecover.Click += new System.EventHandler(this.c_btnMWRecover_Click);
            // 
            // c_btnInvSearch
            // 
            this.c_btnInvSearch.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnInvSearch.Image = ((System.Drawing.Image)(resources.GetObject("c_btnInvSearch.Image")));
            this.c_btnInvSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.c_btnInvSearch.Location = new System.Drawing.Point(471, 37);
            this.c_btnInvSearch.Name = "c_btnInvSearch";
            this.c_btnInvSearch.Size = new System.Drawing.Size(135, 61);
            this.c_btnInvSearch.TabIndex = 0;
            this.c_btnInvSearch.Text = "历史查询";
            this.c_btnInvSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.c_btnInvSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnInvSearch.UseVisualStyleBackColor = true;
            this.c_btnInvSearch.Click += new System.EventHandler(this.c_btnInvSearch_Click);
            // 
            // c_labBg2
            // 
            this.c_labBg2.BackColor = System.Drawing.Color.Gray;
            this.c_labBg2.Location = new System.Drawing.Point(310, 94);
            this.c_labBg2.Name = "c_labBg2";
            this.c_labBg2.Size = new System.Drawing.Size(146, 8);
            this.c_labBg2.TabIndex = 4;
            this.c_labBg2.Visible = false;
            // 
            // c_labBg1
            // 
            this.c_labBg1.BackColor = System.Drawing.Color.Gray;
            this.c_labBg1.Location = new System.Drawing.Point(154, 94);
            this.c_labBg1.Name = "c_labBg1";
            this.c_labBg1.Size = new System.Drawing.Size(146, 8);
            this.c_labBg1.TabIndex = 4;
            this.c_labBg1.Visible = false;
            // 
            // c_labBg3
            // 
            this.c_labBg3.BackColor = System.Drawing.Color.Gray;
            this.c_labBg3.Location = new System.Drawing.Point(465, 94);
            this.c_labBg3.Name = "c_labBg3";
            this.c_labBg3.Size = new System.Drawing.Size(146, 8);
            this.c_labBg3.TabIndex = 4;
            this.c_labBg3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(156, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "医疗废物回收处理系统";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(33, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 95);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // c_btnLogout
            // 
            this.c_btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnLogout.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("c_btnLogout.Image")));
            this.c_btnLogout.Location = new System.Drawing.Point(877, 12);
            this.c_btnLogout.Name = "c_btnLogout";
            this.c_btnLogout.Size = new System.Drawing.Size(122, 86);
            this.c_btnLogout.TabIndex = 0;
            this.c_btnLogout.Text = "注销";
            this.c_btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnLogout.UseVisualStyleBackColor = true;
            this.c_btnLogout.Click += new System.EventHandler(this.c_btnLogout_Click);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(269, 125);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.c_panForm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c_sspMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.c_sspMain.ResumeLayout(false);
            this.c_sspMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel c_panForm;
        private System.Windows.Forms.StatusStrip c_sspMain;
        private System.Windows.Forms.ToolStripStatusLabel c_sspMain_L_txtEmpy;
        private System.Windows.Forms.ToolStripStatusLabel c_sspMain_R_txtTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button c_btnInvSearch;
        private System.Windows.Forms.Button c_btnMWPost;
        private System.Windows.Forms.Button c_btnMWRecover;
        private System.Windows.Forms.Button c_btnLogout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.Label c_labRecoverTxnCount;
        private System.Windows.Forms.Label c_labBg3;
        private System.Windows.Forms.Label c_labBg1;
        private System.Windows.Forms.Label c_labBg2;
    }
}