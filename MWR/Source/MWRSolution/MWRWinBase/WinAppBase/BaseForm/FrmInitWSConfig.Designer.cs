﻿namespace YRKJ.MWR.WinBase.WinAppBase.BaseForm
{
    partial class FrmInitWSConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.c_btnDefaultPwd = new System.Windows.Forms.Button();
            this.c_txtPassword = new System.Windows.Forms.TextBox();
            this.c_txtUserId = new System.Windows.Forms.TextBox();
            this.c_txtService = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.c_btnOk = new System.Windows.Forms.Button();
            this.c_btnCancel = new System.Windows.Forms.Button();
            this.c_btnDetectDB = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.c_txtWSCode = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.c_txtWebService = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.c_txtPort = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_txtWSCode)).BeginInit();
            this.SuspendLayout();
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
            this.groupBox1.Size = new System.Drawing.Size(525, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入需要连接的数据库信息";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.groupBox2.Controls.Add(this.c_btnDefaultPwd);
            this.groupBox2.Controls.Add(this.c_txtPort);
            this.groupBox2.Controls.Add(this.c_txtPassword);
            this.groupBox2.Controls.Add(this.c_txtUserId);
            this.groupBox2.Controls.Add(this.c_txtService);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox2.Location = new System.Drawing.Point(12, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(525, 170);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // c_btnDefaultPwd
            // 
            this.c_btnDefaultPwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnDefaultPwd.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnDefaultPwd.Location = new System.Drawing.Point(352, 67);
            this.c_btnDefaultPwd.Name = "c_btnDefaultPwd";
            this.c_btnDefaultPwd.Size = new System.Drawing.Size(167, 43);
            this.c_btnDefaultPwd.TabIndex = 3;
            this.c_btnDefaultPwd.Text = "默认密码";
            this.c_btnDefaultPwd.UseVisualStyleBackColor = true;
            this.c_btnDefaultPwd.Click += new System.EventHandler(this.c_btnDefaultPwd_Click);
            // 
            // c_txtPassword
            // 
            this.c_txtPassword.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.c_txtPassword.Location = new System.Drawing.Point(115, 87);
            this.c_txtPassword.Name = "c_txtPassword";
            this.c_txtPassword.PasswordChar = '*';
            this.c_txtPassword.Size = new System.Drawing.Size(171, 25);
            this.c_txtPassword.TabIndex = 2;
            // 
            // c_txtUserId
            // 
            this.c_txtUserId.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.c_txtUserId.Location = new System.Drawing.Point(115, 51);
            this.c_txtUserId.Name = "c_txtUserId";
            this.c_txtUserId.Size = new System.Drawing.Size(171, 25);
            this.c_txtUserId.TabIndex = 1;
            // 
            // c_txtService
            // 
            this.c_txtService.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.c_txtService.Location = new System.Drawing.Point(115, 15);
            this.c_txtService.Name = "c_txtService";
            this.c_txtService.Size = new System.Drawing.Size(242, 25);
            this.c_txtService.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.Location = new System.Drawing.Point(72, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.Location = new System.Drawing.Point(58, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "登录名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.Location = new System.Drawing.Point(58, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "服务器";
            // 
            // c_btnOk
            // 
            this.c_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnOk.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnOk.Location = new System.Drawing.Point(429, 331);
            this.c_btnOk.Name = "c_btnOk";
            this.c_btnOk.Size = new System.Drawing.Size(102, 43);
            this.c_btnOk.TabIndex = 3;
            this.c_btnOk.Text = "确认";
            this.c_btnOk.UseVisualStyleBackColor = true;
            this.c_btnOk.Click += new System.EventHandler(this.c_btnOk_Click);
            // 
            // c_btnCancel
            // 
            this.c_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnCancel.Location = new System.Drawing.Point(321, 331);
            this.c_btnCancel.Name = "c_btnCancel";
            this.c_btnCancel.Size = new System.Drawing.Size(102, 43);
            this.c_btnCancel.TabIndex = 4;
            this.c_btnCancel.Text = "取消";
            this.c_btnCancel.UseVisualStyleBackColor = true;
            this.c_btnCancel.Click += new System.EventHandler(this.c_btnCancel_Click);
            // 
            // c_btnDetectDB
            // 
            this.c_btnDetectDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.c_btnDetectDB.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnDetectDB.Location = new System.Drawing.Point(12, 331);
            this.c_btnDetectDB.Name = "c_btnDetectDB";
            this.c_btnDetectDB.Size = new System.Drawing.Size(102, 43);
            this.c_btnDetectDB.TabIndex = 5;
            this.c_btnDetectDB.Text = "测试连接";
            this.c_btnDetectDB.UseVisualStyleBackColor = true;
            this.c_btnDetectDB.Click += new System.EventHandler(this.c_btnDetectDB_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.groupBox3.Controls.Add(this.c_txtWSCode);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.c_txtWebService);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox3.Location = new System.Drawing.Point(12, 238);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(525, 87);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // c_txtWSCode
            // 
            this.c_txtWSCode.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.c_txtWSCode.Location = new System.Drawing.Point(115, 15);
            this.c_txtWSCode.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.c_txtWSCode.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.c_txtWSCode.Name = "c_txtWSCode";
            this.c_txtWSCode.Size = new System.Drawing.Size(50, 25);
            this.c_txtWSCode.TabIndex = 3;
            this.c_txtWSCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_txtWSCode.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.Location = new System.Drawing.Point(15, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Web服务地址";
            // 
            // c_txtWebService
            // 
            this.c_txtWebService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_txtWebService.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.c_txtWebService.Location = new System.Drawing.Point(115, 51);
            this.c_txtWebService.Name = "c_txtWebService";
            this.c_txtWebService.Size = new System.Drawing.Size(404, 25);
            this.c_txtWebService.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.Location = new System.Drawing.Point(30, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "工作站编号";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label7.Location = new System.Drawing.Point(72, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "端口";
            // 
            // c_txtPort
            // 
            this.c_txtPort.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.c_txtPort.Location = new System.Drawing.Point(115, 123);
            this.c_txtPort.Name = "c_txtPort";
            this.c_txtPort.Size = new System.Drawing.Size(171, 25);
            this.c_txtPort.TabIndex = 4;
            this.c_txtPort.Text = "3306";
            // 
            // FrmInitConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(549, 384);
            this.Controls.Add(this.c_btnDetectDB);
            this.Controls.Add(this.c_btnCancel);
            this.Controls.Add(this.c_btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmInitConfig";
            this.Text = "FrmInitConfig";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmInitConfig_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_txtWSCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox c_txtService;
        private System.Windows.Forms.TextBox c_txtUserId;
        private System.Windows.Forms.TextBox c_txtPassword;
        private System.Windows.Forms.Button c_btnDefaultPwd;
        private System.Windows.Forms.Button c_btnOk;
        private System.Windows.Forms.Button c_btnCancel;
        private System.Windows.Forms.Button c_btnDetectDB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox c_txtWebService;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown c_txtWSCode;
        private System.Windows.Forms.TextBox c_txtPort;
        private System.Windows.Forms.Label label7;
    }
}