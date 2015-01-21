namespace MobilePhoneDemoApp
{
    partial class FrmScanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScanner));
            this.button1 = new System.Windows.Forms.Button();
            this.c_txtDetailInfo = new System.Windows.Forms.TextBox();
            this.c_cmbVendor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 63);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // c_txtDetailInfo
            // 
            this.c_txtDetailInfo.BackColor = System.Drawing.Color.White;
            this.c_txtDetailInfo.Location = new System.Drawing.Point(25, 103);
            this.c_txtDetailInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c_txtDetailInfo.Multiline = true;
            this.c_txtDetailInfo.Name = "c_txtDetailInfo";
            this.c_txtDetailInfo.ReadOnly = true;
            this.c_txtDetailInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.c_txtDetailInfo.Size = new System.Drawing.Size(281, 421);
            this.c_txtDetailInfo.TabIndex = 1;
            // 
            // c_cmbVendor
            // 
            this.c_cmbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c_cmbVendor.FormattingEnabled = true;
            this.c_cmbVendor.Location = new System.Drawing.Point(186, 67);
            this.c_cmbVendor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c_cmbVendor.Name = "c_cmbVendor";
            this.c_cmbVendor.Size = new System.Drawing.Size(120, 25);
            this.c_cmbVendor.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "当前医院";
            // 
            // FrmScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(334, 607);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c_cmbVendor);
            this.Controls.Add(this.c_txtDetailInfo);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmScanner";
            this.Text = "FrmScanner";
            this.Load += new System.EventHandler(this.FrmScanner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox c_txtDetailInfo;
        private System.Windows.Forms.ComboBox c_cmbVendor;
        private System.Windows.Forms.Label label1;
    }
}