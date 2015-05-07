namespace MWRSyncMng
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.参数PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.c_txtMain = new System.Windows.Forms.TextBox();
            this.c_back = new System.ComponentModel.BackgroundWorker();
            this.c_time = new System.Windows.Forms.Timer(this.components);
            this.c_sspMain_R_txtStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.服务ToolStripMenuItem,
            this.配置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(546, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 服务ToolStripMenuItem
            // 
            this.服务ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.启动BToolStripMenuItem,
            this.停止SToolStripMenuItem});
            this.服务ToolStripMenuItem.Name = "服务ToolStripMenuItem";
            this.服务ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.服务ToolStripMenuItem.Text = "服务(&S)";
            // 
            // 启动BToolStripMenuItem
            // 
            this.启动BToolStripMenuItem.Name = "启动BToolStripMenuItem";
            this.启动BToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.启动BToolStripMenuItem.Text = "启动(&B)";
            // 
            // 停止SToolStripMenuItem
            // 
            this.停止SToolStripMenuItem.Name = "停止SToolStripMenuItem";
            this.停止SToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.停止SToolStripMenuItem.Text = "停止(&S)";
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.参数PToolStripMenuItem});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.配置ToolStripMenuItem.Text = "配置(&C)";
            // 
            // 参数PToolStripMenuItem
            // 
            this.参数PToolStripMenuItem.Name = "参数PToolStripMenuItem";
            this.参数PToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.参数PToolStripMenuItem.Text = "参数(&P)";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_sspMain_R_txtStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 347);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(546, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // c_txtMain
            // 
            this.c_txtMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_txtMain.Location = new System.Drawing.Point(0, 25);
            this.c_txtMain.Multiline = true;
            this.c_txtMain.Name = "c_txtMain";
            this.c_txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.c_txtMain.Size = new System.Drawing.Size(546, 322);
            this.c_txtMain.TabIndex = 2;
            // 
            // c_back
            // 
            this.c_back.WorkerReportsProgress = true;
            this.c_back.WorkerSupportsCancellation = true;
            this.c_back.DoWork += new System.ComponentModel.DoWorkEventHandler(this.c_back_DoWork);
            // 
            // c_time
            // 
            this.c_time.Tick += new System.EventHandler(this.c_time_Tick);
            // 
            // c_sspMain_R_txtStatus
            // 
            this.c_sspMain_R_txtStatus.Name = "c_sspMain_R_txtStatus";
            this.c_sspMain_R_txtStatus.Size = new System.Drawing.Size(500, 17);
            this.c_sspMain_R_txtStatus.Spring = true;
            this.c_sspMain_R_txtStatus.Text = "状态";
            this.c_sspMain_R_txtStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 369);
            this.Controls.Add(this.c_txtMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动BToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 参数PToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox c_txtMain;
        private System.ComponentModel.BackgroundWorker c_back;
        private System.Windows.Forms.Timer c_time;
        private System.Windows.Forms.ToolStripStatusLabel c_sspMain_R_txtStatus;
    }
}