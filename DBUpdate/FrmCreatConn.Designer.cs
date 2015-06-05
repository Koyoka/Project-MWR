namespace DBUpdate
{
    partial class FrmCreatConn
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.c_txtConnName = new System.Windows.Forms.TextBox();
            this.c_btnLocService = new System.Windows.Forms.Button();
            this.c_btnSqlPath = new System.Windows.Forms.Button();
            this.c_btnDefaultPassword = new System.Windows.Forms.Button();
            this.c_txtPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.c_txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.c_txtSqlPath = new System.Windows.Forms.TextBox();
            this.c_txtUid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.c_txtService = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.c_btnCreate = new System.Windows.Forms.Button();
            this.c_btnDetectDB = new System.Windows.Forms.Button();
            this.c_btnCancel = new System.Windows.Forms.Button();
            this.c_ofdSqlPath = new System.Windows.Forms.OpenFileDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.c_cmbDB = new System.Windows.Forms.ComboBox();
            this.c_grbDBInfo = new System.Windows.Forms.GroupBox();
            this.c_grbTabInfo = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.c_grbDBInfo.SuspendLayout();
            this.c_grbTabInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.c_grbTabInfo);
            this.panel1.Controls.Add(this.c_grbDBInfo);
            this.panel1.Controls.Add(this.c_txtConnName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 301);
            this.panel1.TabIndex = 0;
            // 
            // c_txtConnName
            // 
            this.c_txtConnName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_txtConnName.Location = new System.Drawing.Point(89, 10);
            this.c_txtConnName.Name = "c_txtConnName";
            this.c_txtConnName.Size = new System.Drawing.Size(322, 21);
            this.c_txtConnName.TabIndex = 0;
            // 
            // c_btnLocService
            // 
            this.c_btnLocService.Location = new System.Drawing.Point(269, 24);
            this.c_btnLocService.Name = "c_btnLocService";
            this.c_btnLocService.Size = new System.Drawing.Size(75, 23);
            this.c_btnLocService.TabIndex = 3;
            this.c_btnLocService.Text = "本地";
            this.c_btnLocService.UseVisualStyleBackColor = true;
            this.c_btnLocService.Click += new System.EventHandler(this.c_txtLocService_Click);
            // 
            // c_btnSqlPath
            // 
            this.c_btnSqlPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnSqlPath.Location = new System.Drawing.Point(353, 55);
            this.c_btnSqlPath.Name = "c_btnSqlPath";
            this.c_btnSqlPath.Size = new System.Drawing.Size(49, 23);
            this.c_btnSqlPath.TabIndex = 2;
            this.c_btnSqlPath.Text = "...";
            this.c_btnSqlPath.UseVisualStyleBackColor = true;
            this.c_btnSqlPath.Click += new System.EventHandler(this.c_txtSqlPath_Click);
            // 
            // c_btnDefaultPassword
            // 
            this.c_btnDefaultPassword.Location = new System.Drawing.Point(186, 80);
            this.c_btnDefaultPassword.Name = "c_btnDefaultPassword";
            this.c_btnDefaultPassword.Size = new System.Drawing.Size(77, 23);
            this.c_btnDefaultPassword.TabIndex = 6;
            this.c_btnDefaultPassword.Text = "默认密码";
            this.c_btnDefaultPassword.UseVisualStyleBackColor = true;
            this.c_btnDefaultPassword.Click += new System.EventHandler(this.c_btnDefaultPassword_Click);
            // 
            // c_txtPort
            // 
            this.c_txtPort.Location = new System.Drawing.Point(81, 110);
            this.c_txtPort.Name = "c_txtPort";
            this.c_txtPort.Size = new System.Drawing.Size(50, 21);
            this.c_txtPort.TabIndex = 7;
            this.c_txtPort.Text = "3306";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "端口";
            // 
            // c_txtPassword
            // 
            this.c_txtPassword.Location = new System.Drawing.Point(81, 82);
            this.c_txtPassword.Name = "c_txtPassword";
            this.c_txtPassword.Size = new System.Drawing.Size(99, 21);
            this.c_txtPassword.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Sql脚本地址";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "密码";
            // 
            // c_txtSqlPath
            // 
            this.c_txtSqlPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_txtSqlPath.Location = new System.Drawing.Point(87, 56);
            this.c_txtSqlPath.Name = "c_txtSqlPath";
            this.c_txtSqlPath.Size = new System.Drawing.Size(257, 21);
            this.c_txtSqlPath.TabIndex = 1;
            // 
            // c_txtUid
            // 
            this.c_txtUid.Location = new System.Drawing.Point(81, 54);
            this.c_txtUid.Name = "c_txtUid";
            this.c_txtUid.Size = new System.Drawing.Size(99, 21);
            this.c_txtUid.TabIndex = 4;
            this.c_txtUid.Text = "root";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "用户名";
            // 
            // c_txtService
            // 
            this.c_txtService.Location = new System.Drawing.Point(81, 26);
            this.c_txtService.Name = "c_txtService";
            this.c_txtService.Size = new System.Drawing.Size(182, 21);
            this.c_txtService.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "连接名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "服务器地址";
            // 
            // c_btnCreate
            // 
            this.c_btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnCreate.Location = new System.Drawing.Point(349, 319);
            this.c_btnCreate.Name = "c_btnCreate";
            this.c_btnCreate.Size = new System.Drawing.Size(75, 23);
            this.c_btnCreate.TabIndex = 1;
            this.c_btnCreate.Text = "创建";
            this.c_btnCreate.UseVisualStyleBackColor = true;
            this.c_btnCreate.Click += new System.EventHandler(this.c_btnCreate_Click);
            // 
            // c_btnDetectDB
            // 
            this.c_btnDetectDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.c_btnDetectDB.Location = new System.Drawing.Point(327, 119);
            this.c_btnDetectDB.Name = "c_btnDetectDB";
            this.c_btnDetectDB.Size = new System.Drawing.Size(75, 23);
            this.c_btnDetectDB.TabIndex = 8;
            this.c_btnDetectDB.Text = "测试连接";
            this.c_btnDetectDB.UseVisualStyleBackColor = true;
            this.c_btnDetectDB.Click += new System.EventHandler(this.c_btnDetectDB_Click);
            // 
            // c_btnCancel
            // 
            this.c_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnCancel.Location = new System.Drawing.Point(268, 319);
            this.c_btnCancel.Name = "c_btnCancel";
            this.c_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.c_btnCancel.TabIndex = 2;
            this.c_btnCancel.Text = "取消";
            this.c_btnCancel.UseVisualStyleBackColor = true;
            this.c_btnCancel.Click += new System.EventHandler(this.c_btnCancel_Click);
            // 
            // c_ofdSqlPath
            // 
            this.c_ofdSqlPath.Filter = "Sql文件 *.sql|*.SQL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "数据库";
            // 
            // c_cmbDB
            // 
            this.c_cmbDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c_cmbDB.FormattingEnabled = true;
            this.c_cmbDB.Location = new System.Drawing.Point(87, 30);
            this.c_cmbDB.Name = "c_cmbDB";
            this.c_cmbDB.Size = new System.Drawing.Size(183, 20);
            this.c_cmbDB.TabIndex = 0;
            // 
            // c_grbDBInfo
            // 
            this.c_grbDBInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_grbDBInfo.Controls.Add(this.c_btnDetectDB);
            this.c_grbDBInfo.Controls.Add(this.label1);
            this.c_grbDBInfo.Controls.Add(this.c_txtService);
            this.c_grbDBInfo.Controls.Add(this.label2);
            this.c_grbDBInfo.Controls.Add(this.c_txtUid);
            this.c_grbDBInfo.Controls.Add(this.c_btnLocService);
            this.c_grbDBInfo.Controls.Add(this.label3);
            this.c_grbDBInfo.Controls.Add(this.c_txtPassword);
            this.c_grbDBInfo.Controls.Add(this.c_btnDefaultPassword);
            this.c_grbDBInfo.Controls.Add(this.label4);
            this.c_grbDBInfo.Controls.Add(this.c_txtPort);
            this.c_grbDBInfo.Location = new System.Drawing.Point(9, 37);
            this.c_grbDBInfo.Name = "c_grbDBInfo";
            this.c_grbDBInfo.Size = new System.Drawing.Size(408, 148);
            this.c_grbDBInfo.TabIndex = 1;
            this.c_grbDBInfo.TabStop = false;
            this.c_grbDBInfo.Text = "服务器信息";
            // 
            // c_grbTabInfo
            // 
            this.c_grbTabInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c_grbTabInfo.Controls.Add(this.label8);
            this.c_grbTabInfo.Controls.Add(this.c_cmbDB);
            this.c_grbTabInfo.Controls.Add(this.label6);
            this.c_grbTabInfo.Controls.Add(this.c_btnSqlPath);
            this.c_grbTabInfo.Controls.Add(this.c_txtSqlPath);
            this.c_grbTabInfo.Location = new System.Drawing.Point(9, 191);
            this.c_grbTabInfo.Name = "c_grbTabInfo";
            this.c_grbTabInfo.Size = new System.Drawing.Size(408, 88);
            this.c_grbTabInfo.TabIndex = 2;
            this.c_grbTabInfo.TabStop = false;
            this.c_grbTabInfo.Text = "数据库信息";
            // 
            // FrmCreatConn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 354);
            this.Controls.Add(this.c_btnCancel);
            this.Controls.Add(this.c_btnCreate);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreatConn";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCreatConn";
            this.Load += new System.EventHandler(this.FrmCreatConn_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.c_grbDBInfo.ResumeLayout(false);
            this.c_grbDBInfo.PerformLayout();
            this.c_grbTabInfo.ResumeLayout(false);
            this.c_grbTabInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox c_txtPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox c_txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox c_txtSqlPath;
        private System.Windows.Forms.TextBox c_txtUid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox c_txtService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button c_btnDefaultPassword;
        private System.Windows.Forms.Button c_btnSqlPath;
        private System.Windows.Forms.Button c_btnLocService;
        private System.Windows.Forms.Button c_btnCreate;
        private System.Windows.Forms.Button c_btnDetectDB;
        private System.Windows.Forms.TextBox c_txtConnName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button c_btnCancel;
        private System.Windows.Forms.OpenFileDialog c_ofdSqlPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox c_cmbDB;
        private System.Windows.Forms.GroupBox c_grbDBInfo;
        private System.Windows.Forms.GroupBox c_grbTabInfo;
    }
}