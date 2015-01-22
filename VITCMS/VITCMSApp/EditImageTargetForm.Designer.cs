namespace VITCMSApp
{
    partial class EditImageTargetForm
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
            this.c_labIMName = new System.Windows.Forms.Label();
            this.c_txtIMName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.c_txtIMWidth = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.c_txtImagePath = new System.Windows.Forms.TextBox();
            this.c_btnSelectPicPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.c_txtMetaDataPath = new System.Windows.Forms.TextBox();
            this.c_btnSelectMetaDataPath = new System.Windows.Forms.Button();
            this.c_chkIsActive = new System.Windows.Forms.CheckBox();
            this.c_btnOk = new System.Windows.Forms.Button();
            this.c_btnSend = new System.Windows.Forms.Button();
            this.c_ofdSelectFile = new System.Windows.Forms.OpenFileDialog();
            this.c_txtDefaultWidth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // c_labIMName
            // 
            this.c_labIMName.AutoSize = true;
            this.c_labIMName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.c_labIMName.Location = new System.Drawing.Point(47, 43);
            this.c_labIMName.Name = "c_labIMName";
            this.c_labIMName.Size = new System.Drawing.Size(74, 21);
            this.c_labIMName.TabIndex = 0;
            this.c_labIMName.Text = "图片名称";
            // 
            // c_txtIMName
            // 
            this.c_txtIMName.Location = new System.Drawing.Point(127, 43);
            this.c_txtIMName.Name = "c_txtIMName";
            this.c_txtIMName.Size = new System.Drawing.Size(127, 21);
            this.c_txtIMName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(47, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "缩放宽度";
            // 
            // c_txtIMWidth
            // 
            this.c_txtIMWidth.Location = new System.Drawing.Point(127, 80);
            this.c_txtIMWidth.Mask = "99999";
            this.c_txtIMWidth.Name = "c_txtIMWidth";
            this.c_txtIMWidth.PromptChar = ' ';
            this.c_txtIMWidth.Size = new System.Drawing.Size(127, 21);
            this.c_txtIMWidth.TabIndex = 2;
            this.c_txtIMWidth.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(47, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "选择图片";
            // 
            // c_txtImagePath
            // 
            this.c_txtImagePath.BackColor = System.Drawing.Color.White;
            this.c_txtImagePath.Location = new System.Drawing.Point(127, 117);
            this.c_txtImagePath.Name = "c_txtImagePath";
            this.c_txtImagePath.ReadOnly = true;
            this.c_txtImagePath.Size = new System.Drawing.Size(204, 21);
            this.c_txtImagePath.TabIndex = 4;
            // 
            // c_btnSelectPicPath
            // 
            this.c_btnSelectPicPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnSelectPicPath.Location = new System.Drawing.Point(338, 116);
            this.c_btnSelectPicPath.Name = "c_btnSelectPicPath";
            this.c_btnSelectPicPath.Size = new System.Drawing.Size(34, 23);
            this.c_btnSelectPicPath.TabIndex = 5;
            this.c_btnSelectPicPath.Text = "...";
            this.c_btnSelectPicPath.UseVisualStyleBackColor = true;
            this.c_btnSelectPicPath.Click += new System.EventHandler(this.c_btnSelectPicPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(31, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "选择元数据";
            // 
            // c_txtMetaDataPath
            // 
            this.c_txtMetaDataPath.BackColor = System.Drawing.Color.White;
            this.c_txtMetaDataPath.Location = new System.Drawing.Point(127, 154);
            this.c_txtMetaDataPath.Name = "c_txtMetaDataPath";
            this.c_txtMetaDataPath.ReadOnly = true;
            this.c_txtMetaDataPath.Size = new System.Drawing.Size(204, 21);
            this.c_txtMetaDataPath.TabIndex = 6;
            // 
            // c_btnSelectMetaDataPath
            // 
            this.c_btnSelectMetaDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnSelectMetaDataPath.Location = new System.Drawing.Point(338, 153);
            this.c_btnSelectMetaDataPath.Name = "c_btnSelectMetaDataPath";
            this.c_btnSelectMetaDataPath.Size = new System.Drawing.Size(34, 23);
            this.c_btnSelectMetaDataPath.TabIndex = 7;
            this.c_btnSelectMetaDataPath.Text = "...";
            this.c_btnSelectMetaDataPath.UseVisualStyleBackColor = true;
            this.c_btnSelectMetaDataPath.Click += new System.EventHandler(this.c_btnSelectMetaDataPath_Click);
            // 
            // c_chkIsActive
            // 
            this.c_chkIsActive.AutoSize = true;
            this.c_chkIsActive.Checked = true;
            this.c_chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c_chkIsActive.Location = new System.Drawing.Point(127, 194);
            this.c_chkIsActive.Name = "c_chkIsActive";
            this.c_chkIsActive.Size = new System.Drawing.Size(72, 16);
            this.c_chkIsActive.TabIndex = 8;
            this.c_chkIsActive.Text = "是否激活";
            this.c_chkIsActive.UseVisualStyleBackColor = true;
            // 
            // c_btnOk
            // 
            this.c_btnOk.Location = new System.Drawing.Point(206, 226);
            this.c_btnOk.Name = "c_btnOk";
            this.c_btnOk.Size = new System.Drawing.Size(75, 23);
            this.c_btnOk.TabIndex = 9;
            this.c_btnOk.Text = "提交";
            this.c_btnOk.UseVisualStyleBackColor = true;
            this.c_btnOk.Click += new System.EventHandler(this.c_btnOk_Click);
            // 
            // c_btnSend
            // 
            this.c_btnSend.Location = new System.Drawing.Point(297, 226);
            this.c_btnSend.Name = "c_btnSend";
            this.c_btnSend.Size = new System.Drawing.Size(75, 23);
            this.c_btnSend.TabIndex = 10;
            this.c_btnSend.Text = "取消";
            this.c_btnSend.UseVisualStyleBackColor = true;
            this.c_btnSend.Click += new System.EventHandler(this.c_btnSend_Click);
            // 
            // c_ofdSelectFile
            // 
            this.c_ofdSelectFile.Filter = "图片文件|*.jpg|图片文件|*.png";
            // 
            // c_txtDefaultWidth
            // 
            this.c_txtDefaultWidth.Location = new System.Drawing.Point(260, 78);
            this.c_txtDefaultWidth.Name = "c_txtDefaultWidth";
            this.c_txtDefaultWidth.Size = new System.Drawing.Size(112, 23);
            this.c_txtDefaultWidth.TabIndex = 3;
            this.c_txtDefaultWidth.Text = "width:200";
            this.c_txtDefaultWidth.UseVisualStyleBackColor = true;
            this.c_txtDefaultWidth.Click += new System.EventHandler(this.c_txtDefaultWidth_Click);
            // 
            // EditImageTargetFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 280);
            this.Controls.Add(this.c_txtDefaultWidth);
            this.Controls.Add(this.c_btnSend);
            this.Controls.Add(this.c_btnOk);
            this.Controls.Add(this.c_chkIsActive);
            this.Controls.Add(this.c_btnSelectMetaDataPath);
            this.Controls.Add(this.c_btnSelectPicPath);
            this.Controls.Add(this.c_txtMetaDataPath);
            this.Controls.Add(this.c_txtImagePath);
            this.Controls.Add(this.c_txtIMWidth);
            this.Controls.Add(this.c_txtIMName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c_labIMName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditImageTargetFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片编辑上传";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label c_labIMName;
        private System.Windows.Forms.TextBox c_txtIMName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox c_txtIMWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox c_txtImagePath;
        private System.Windows.Forms.Button c_btnSelectPicPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox c_txtMetaDataPath;
        private System.Windows.Forms.Button c_btnSelectMetaDataPath;
        private System.Windows.Forms.CheckBox c_chkIsActive;
        private System.Windows.Forms.Button c_btnOk;
        private System.Windows.Forms.Button c_btnSend;
        private System.Windows.Forms.OpenFileDialog c_ofdSelectFile;
        private System.Windows.Forms.Button c_txtDefaultWidth;
    }
}