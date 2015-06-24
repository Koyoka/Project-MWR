namespace MobilePhoneDemoApp
{
    partial class FrmSMSTP
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.c_txtContent = new System.Windows.Forms.TextBox();
            this.c_txtPhone = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 95);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(347, 196);
            this.textBox1.TabIndex = 1;
            // 
            // c_txtContent
            // 
            this.c_txtContent.Location = new System.Drawing.Point(12, 68);
            this.c_txtContent.Name = "c_txtContent";
            this.c_txtContent.Size = new System.Drawing.Size(263, 21);
            this.c_txtContent.TabIndex = 2;
            this.c_txtContent.Text = "输入发送内容";
            // 
            // c_txtPhone
            // 
            this.c_txtPhone.Location = new System.Drawing.Point(12, 41);
            this.c_txtPhone.Name = "c_txtPhone";
            this.c_txtPhone.Size = new System.Drawing.Size(174, 21);
            this.c_txtPhone.TabIndex = 3;
            this.c_txtPhone.Text = "13720205013";
            // 
            // FrmSMSTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 303);
            this.Controls.Add(this.c_txtPhone);
            this.Controls.Add(this.c_txtContent);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "FrmSMSTP";
            this.Text = "FrmSMSTP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox c_txtContent;
        private System.Windows.Forms.TextBox c_txtPhone;
    }
}