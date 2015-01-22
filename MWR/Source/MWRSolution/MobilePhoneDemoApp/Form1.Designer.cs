namespace MobilePhoneDemoApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.c_labMWSCode = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.c_labDriver = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.c_labInspector = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.lable4 = new System.Windows.Forms.Label();
            this.c_labCarCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(223, 74);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 101);
            this.button1.TabIndex = 0;
            this.button1.Text = "开始扫描";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(30, 183);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(300, 101);
            this.button2.TabIndex = 0;
            this.button2.Text = "提交出入库工作站";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(30, 292);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(299, 101);
            this.button3.TabIndex = 0;
            this.button3.Text = "提交处置工作站";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "终端编号：";
            // 
            // c_labMWSCode
            // 
            this.c_labMWSCode.AutoSize = true;
            this.c_labMWSCode.BackColor = System.Drawing.Color.White;
            this.c_labMWSCode.Location = new System.Drawing.Point(101, 74);
            this.c_labMWSCode.Name = "c_labMWSCode";
            this.c_labMWSCode.Size = new System.Drawing.Size(60, 17);
            this.c_labMWSCode.TabIndex = 2;
            this.c_labMWSCode.Text = "MWS001";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(31, 401);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(299, 101);
            this.button4.TabIndex = 0;
            this.button4.Text = "查看当前回收详情";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(51, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "司机：";
            // 
            // c_labDriver
            // 
            this.c_labDriver.AutoSize = true;
            this.c_labDriver.BackColor = System.Drawing.Color.White;
            this.c_labDriver.Location = new System.Drawing.Point(101, 99);
            this.c_labDriver.Name = "c_labDriver";
            this.c_labDriver.Size = new System.Drawing.Size(26, 17);
            this.c_labDriver.TabIndex = 2;
            this.c_labDriver.Text = "xxx";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(39, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "跟车员：";
            // 
            // c_labInspector
            // 
            this.c_labInspector.AutoSize = true;
            this.c_labInspector.BackColor = System.Drawing.Color.White;
            this.c_labInspector.Location = new System.Drawing.Point(101, 124);
            this.c_labInspector.Name = "c_labInspector";
            this.c_labInspector.Size = new System.Drawing.Size(26, 17);
            this.c_labInspector.TabIndex = 2;
            this.c_labInspector.Text = "xxx";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(31, 509);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(297, 48);
            this.button5.TabIndex = 3;
            this.button5.Text = "退出";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lable4
            // 
            this.lable4.AutoSize = true;
            this.lable4.BackColor = System.Drawing.Color.White;
            this.lable4.Location = new System.Drawing.Point(39, 146);
            this.lable4.Name = "lable4";
            this.lable4.Size = new System.Drawing.Size(44, 17);
            this.lable4.TabIndex = 1;
            this.lable4.Text = "车辆：";
            // 
            // c_labCarCode
            // 
            this.c_labCarCode.AutoSize = true;
            this.c_labCarCode.BackColor = System.Drawing.Color.White;
            this.c_labCarCode.Location = new System.Drawing.Point(101, 146);
            this.c_labCarCode.Name = "c_labCarCode";
            this.c_labCarCode.Size = new System.Drawing.Size(26, 17);
            this.c_labCarCode.TabIndex = 2;
            this.c_labCarCode.Text = "xxx";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(350, 645);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.c_labCarCode);
            this.Controls.Add(this.c_labInspector);
            this.Controls.Add(this.c_labDriver);
            this.Controls.Add(this.c_labMWSCode);
            this.Controls.Add(this.lable4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label c_labMWSCode;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label c_labDriver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label c_labInspector;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lable4;
        private System.Windows.Forms.Label c_labCarCode;
    }
}

