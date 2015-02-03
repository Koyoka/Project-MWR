namespace YRKJ.MWR.WSInventory.Forms
{
    partial class FrmMWCrateView
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
            this.c_btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.c_txtCrateCode = new System.Windows.Forms.TextBox();
            this.c_labSubWeight = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.c_labWaster = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.c_labVendor = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.c_btnError = new System.Windows.Forms.Button();
            this.c_btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c_labScalesStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.c_labSysUnit = new System.Windows.Forms.Label();
            this.c_labTxnWeight = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_btnOk
            // 
            this.c_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnOk.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnOk.Location = new System.Drawing.Point(253, 182);
            this.c_btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c_btnOk.Name = "c_btnOk";
            this.c_btnOk.Size = new System.Drawing.Size(100, 50);
            this.c_btnOk.TabIndex = 0;
            this.c_btnOk.Text = "确认";
            this.c_btnOk.UseVisualStyleBackColor = true;
            this.c_btnOk.Click += new System.EventHandler(this.c_btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.c_txtCrateCode);
            this.groupBox1.Controls.Add(this.c_labSubWeight);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.c_labWaster);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.c_labVendor);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.c_btnError);
            this.groupBox1.Controls.Add(this.c_btnCancel);
            this.groupBox1.Controls.Add(this.c_btnOk);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 239);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当前货箱";
            // 
            // c_txtCrateCode
            // 
            this.c_txtCrateCode.Location = new System.Drawing.Point(127, 33);
            this.c_txtCrateCode.Name = "c_txtCrateCode";
            this.c_txtCrateCode.ReadOnly = true;
            this.c_txtCrateCode.Size = new System.Drawing.Size(132, 23);
            this.c_txtCrateCode.TabIndex = 18;
            // 
            // c_labSubWeight
            // 
            this.c_labSubWeight.AutoSize = true;
            this.c_labSubWeight.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_labSubWeight.Location = new System.Drawing.Point(123, 145);
            this.c_labSubWeight.Name = "c_labSubWeight";
            this.c_labSubWeight.Size = new System.Drawing.Size(50, 21);
            this.c_labSubWeight.TabIndex = 3;
            this.c_labSubWeight.Text = "12KG";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label7.Location = new System.Drawing.Point(27, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 3;
            this.label7.Text = "提交重量：";
            // 
            // c_labWaster
            // 
            this.c_labWaster.AutoSize = true;
            this.c_labWaster.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_labWaster.Location = new System.Drawing.Point(123, 108);
            this.c_labWaster.Name = "c_labWaster";
            this.c_labWaster.Size = new System.Drawing.Size(74, 21);
            this.c_labWaster.TabIndex = 3;
            this.c_labWaster.Text = "医疗器械";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label5.Location = new System.Drawing.Point(59, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "类别：";
            // 
            // c_labVendor
            // 
            this.c_labVendor.AutoSize = true;
            this.c_labVendor.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_labVendor.Location = new System.Drawing.Point(123, 71);
            this.c_labVendor.Name = "c_labVendor";
            this.c_labVendor.Size = new System.Drawing.Size(74, 21);
            this.c_labVendor.TabIndex = 3;
            this.c_labVendor.Text = "中南医院";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label13.Location = new System.Drawing.Point(27, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 21);
            this.label13.TabIndex = 3;
            this.label13.Text = "货箱编号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label4.Location = new System.Drawing.Point(59, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "来源：";
            // 
            // c_btnError
            // 
            this.c_btnError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.c_btnError.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnError.Location = new System.Drawing.Point(6, 182);
            this.c_btnError.Name = "c_btnError";
            this.c_btnError.Size = new System.Drawing.Size(100, 50);
            this.c_btnError.TabIndex = 2;
            this.c_btnError.Text = "审核";
            this.c_btnError.UseVisualStyleBackColor = true;
            this.c_btnError.Click += new System.EventHandler(this.c_btnError_Click);
            // 
            // c_btnCancel
            // 
            this.c_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.c_btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnCancel.Location = new System.Drawing.Point(133, 182);
            this.c_btnCancel.Name = "c_btnCancel";
            this.c_btnCancel.Size = new System.Drawing.Size(100, 50);
            this.c_btnCancel.TabIndex = 1;
            this.c_btnCancel.Text = "取消";
            this.c_btnCancel.UseVisualStyleBackColor = true;
            this.c_btnCancel.Click += new System.EventHandler(this.c_btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.c_labScalesStatus);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.c_labSysUnit);
            this.panel1.Controls.Add(this.c_labTxnWeight);
            this.panel1.Location = new System.Drawing.Point(12, 257);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 95);
            this.panel1.TabIndex = 16;
            // 
            // c_labScalesStatus
            // 
            this.c_labScalesStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labScalesStatus.BackColor = System.Drawing.Color.Black;
            this.c_labScalesStatus.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.c_labScalesStatus.ForeColor = System.Drawing.Color.Red;
            this.c_labScalesStatus.Location = new System.Drawing.Point(231, 0);
            this.c_labScalesStatus.Name = "c_labScalesStatus";
            this.c_labScalesStatus.Size = new System.Drawing.Size(120, 20);
            this.c_labScalesStatus.TabIndex = 0;
            this.c_labScalesStatus.Text = "设备连接中...";
            this.c_labScalesStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "当前重量：";
            // 
            // c_labSysUnit
            // 
            this.c_labSysUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labSysUnit.AutoSize = true;
            this.c_labSysUnit.BackColor = System.Drawing.Color.Black;
            this.c_labSysUnit.ForeColor = System.Drawing.Color.Lime;
            this.c_labSysUnit.Location = new System.Drawing.Point(326, 61);
            this.c_labSysUnit.Name = "c_labSysUnit";
            this.c_labSysUnit.Size = new System.Drawing.Size(25, 17);
            this.c_labSysUnit.TabIndex = 0;
            this.c_labSysUnit.Text = "KG";
            // 
            // c_labTxnWeight
            // 
            this.c_labTxnWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labTxnWeight.Font = new System.Drawing.Font("微软雅黑", 38F);
            this.c_labTxnWeight.ForeColor = System.Drawing.Color.Lime;
            this.c_labTxnWeight.Location = new System.Drawing.Point(144, 22);
            this.c_labTxnWeight.Name = "c_labTxnWeight";
            this.c_labTxnWeight.Size = new System.Drawing.Size(192, 68);
            this.c_labTxnWeight.TabIndex = 0;
            this.c_labTxnWeight.Text = "0.00";
            this.c_labTxnWeight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FrmMWCrateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 364);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMWCrateView";
            this.Text = "FrmMWCrateDetail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMWCrateView_FormClosing);
            this.Load += new System.EventHandler(this.FrmMWCrateView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button c_btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label c_labSysUnit;
        private System.Windows.Forms.Label c_labTxnWeight;
        private System.Windows.Forms.Button c_btnCancel;
        private System.Windows.Forms.Button c_btnError;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label c_labSubWeight;
        private System.Windows.Forms.Label c_labWaster;
        private System.Windows.Forms.Label c_labVendor;
        private System.Windows.Forms.Label c_labScalesStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox c_txtCrateCode;
    }
}