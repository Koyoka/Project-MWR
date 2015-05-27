namespace MWRSyncMng
{
    partial class FrmSetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.c_txtSyncCity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.c_btnCancel = new System.Windows.Forms.Button();
            this.c_btnOk = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.c_txtWebService = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "同步服务参数配置";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 44);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.groupBox2.Controls.Add(this.c_txtWebService);
            this.groupBox2.Controls.Add(this.c_txtSyncCity);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox2.Location = new System.Drawing.Point(12, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 133);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // c_txtSyncCity
            // 
            this.c_txtSyncCity.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.c_txtSyncCity.Location = new System.Drawing.Point(121, 11);
            this.c_txtSyncCity.Name = "c_txtSyncCity";
            this.c_txtSyncCity.Size = new System.Drawing.Size(278, 25);
            this.c_txtSyncCity.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline);
            this.label3.Location = new System.Drawing.Point(7, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "厂区所属城市，数据中心根据所属城市信息分类统计。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(73, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "城市";
            // 
            // c_btnCancel
            // 
            this.c_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnCancel.Location = new System.Drawing.Point(207, 225);
            this.c_btnCancel.Name = "c_btnCancel";
            this.c_btnCancel.Size = new System.Drawing.Size(102, 43);
            this.c_btnCancel.TabIndex = 5;
            this.c_btnCancel.Text = "取消";
            this.c_btnCancel.UseVisualStyleBackColor = true;
            this.c_btnCancel.Click += new System.EventHandler(this.c_btnCancel_Click);
            // 
            // c_btnOk
            // 
            this.c_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnOk.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnOk.Location = new System.Drawing.Point(315, 225);
            this.c_btnOk.Name = "c_btnOk";
            this.c_btnOk.Size = new System.Drawing.Size(102, 43);
            this.c_btnOk.TabIndex = 4;
            this.c_btnOk.Text = "确认";
            this.c_btnOk.UseVisualStyleBackColor = true;
            this.c_btnOk.Click += new System.EventHandler(this.c_btnOk_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label4.Location = new System.Drawing.Point(6, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Web服务地址";
            // 
            // c_txtWebService
            // 
            this.c_txtWebService.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.c_txtWebService.Location = new System.Drawing.Point(121, 74);
            this.c_txtWebService.Name = "c_txtWebService";
            this.c_txtWebService.Size = new System.Drawing.Size(278, 25);
            this.c_txtWebService.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline);
            this.label5.Location = new System.Drawing.Point(7, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(342, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "数据中心提供的服务地址，如：http://127.0.0.1/serciver.ashx";
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 280);
            this.Controls.Add(this.c_btnCancel);
            this.Controls.Add(this.c_btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.FrmSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button c_btnCancel;
        private System.Windows.Forms.Button c_btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox c_txtSyncCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox c_txtWebService;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}