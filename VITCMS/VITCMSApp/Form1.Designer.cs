namespace VITCMSApp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.c_txtFileName = new System.Windows.Forms.TextBox();
            this.c_btnSelectFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "图片文件|*.jpg|图片文件|*.png";
            // 
            // c_txtFileName
            // 
            this.c_txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c_txtFileName.Location = new System.Drawing.Point(12, 269);
            this.c_txtFileName.Name = "c_txtFileName";
            this.c_txtFileName.Size = new System.Drawing.Size(352, 21);
            this.c_txtFileName.TabIndex = 1;
            // 
            // c_btnSelectFile
            // 
            this.c_btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnSelectFile.Location = new System.Drawing.Point(370, 267);
            this.c_btnSelectFile.Name = "c_btnSelectFile";
            this.c_btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.c_btnSelectFile.TabIndex = 2;
            this.c_btnSelectFile.Text = "上传文件";
            this.c_btnSelectFile.UseVisualStyleBackColor = true;
            this.c_btnSelectFile.Click += new System.EventHandler(this.c_btnSelectFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 302);
            this.Controls.Add(this.c_btnSelectFile);
            this.Controls.Add(this.c_txtFileName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox c_txtFileName;
        private System.Windows.Forms.Button c_btnSelectFile;
    }
}

