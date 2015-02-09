namespace YRKJ.MWR.WSDestory.Forms
{
    partial class FrmMWDestroyDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMWDestroyDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.c_btnStopDest = new System.Windows.Forms.Button();
            this.c_txtDestNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c_grdMWTxnDetail = new System.Windows.Forms.DataGridView();
            this.c_grdMWTxnDetail_C_CrateCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWTxnDetail_C_Vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWTxnDetail_C_Waste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWTxnDetail_C_SubWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWTxnDetail_C_TxnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWTxnDetail_C_EntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_grdMWTxnDetail_C_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.c_labTotalQty = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.c_grpCurTxnDetail = new System.Windows.Forms.GroupBox();
            this.c_txtCurCrateCode = new System.Windows.Forms.TextBox();
            this.c_labUnit1 = new System.Windows.Forms.Label();
            this.c_labUnit2 = new System.Windows.Forms.Label();
            this.c_labCurTxnWeight = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.c_labCurSubWeight = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.c_labCurStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.c_btnCheck = new System.Windows.Forms.Button();
            this.c_btnManually = new System.Windows.Forms.Button();
            this.c_labUnit4 = new System.Windows.Forms.Label();
            this.c_labUnit3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.c_btnDestDone = new System.Windows.Forms.Button();
            this.c_labTotalSubWeigth = new System.Windows.Forms.Label();
            this.c_labTotalTxnWeight = new System.Windows.Forms.Label();
            this.c_bgwRefTxnDetail = new System.ComponentModel.BackgroundWorker();
            this.c_time = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWTxnDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.c_grpCurTxnDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_btnStopDest
            // 
            this.c_btnStopDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnStopDest.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnStopDest.Image = ((System.Drawing.Image)(resources.GetObject("c_btnStopDest.Image")));
            this.c_btnStopDest.Location = new System.Drawing.Point(856, 15);
            this.c_btnStopDest.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.c_btnStopDest.Name = "c_btnStopDest";
            this.c_btnStopDest.Size = new System.Drawing.Size(140, 65);
            this.c_btnStopDest.TabIndex = 14;
            this.c_btnStopDest.Text = "停止处理";
            this.c_btnStopDest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnStopDest.UseVisualStyleBackColor = true;
            this.c_btnStopDest.Click += new System.EventHandler(this.c_btnStopDest_Click);
            // 
            // c_txtDestNum
            // 
            this.c_txtDestNum.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_txtDestNum.Location = new System.Drawing.Point(140, 56);
            this.c_txtDestNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c_txtDestNum.Name = "c_txtDestNum";
            this.c_txtDestNum.ReadOnly = true;
            this.c_txtDestNum.Size = new System.Drawing.Size(144, 29);
            this.c_txtDestNum.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 32;
            this.label1.Text = "出库计划编号：";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.c_grdMWTxnDetail);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.panel1.Location = new System.Drawing.Point(12, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 212);
            this.panel1.TabIndex = 34;
            // 
            // c_grdMWTxnDetail
            // 
            this.c_grdMWTxnDetail.AllowUserToAddRows = false;
            this.c_grdMWTxnDetail.AllowUserToDeleteRows = false;
            this.c_grdMWTxnDetail.AllowUserToResizeColumns = false;
            this.c_grdMWTxnDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.c_grdMWTxnDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.c_grdMWTxnDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_grdMWTxnDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_grdMWTxnDetail_C_CrateCode,
            this.c_grdMWTxnDetail_C_Vendor,
            this.c_grdMWTxnDetail_C_Waste,
            this.c_grdMWTxnDetail_C_SubWeight,
            this.c_grdMWTxnDetail_C_TxnWeight,
            this.c_grdMWTxnDetail_C_EntryDate,
            this.c_grdMWTxnDetail_C_Status});
            this.c_grdMWTxnDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_grdMWTxnDetail.Location = new System.Drawing.Point(0, 0);
            this.c_grdMWTxnDetail.MultiSelect = false;
            this.c_grdMWTxnDetail.Name = "c_grdMWTxnDetail";
            this.c_grdMWTxnDetail.RowHeadersVisible = false;
            this.c_grdMWTxnDetail.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWTxnDetail.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.c_grdMWTxnDetail.RowTemplate.Height = 60;
            this.c_grdMWTxnDetail.RowTemplate.ReadOnly = true;
            this.c_grdMWTxnDetail.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_grdMWTxnDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.c_grdMWTxnDetail.Size = new System.Drawing.Size(984, 212);
            this.c_grdMWTxnDetail.TabIndex = 14;
            // 
            // c_grdMWTxnDetail_C_CrateCode
            // 
            this.c_grdMWTxnDetail_C_CrateCode.FillWeight = 150F;
            this.c_grdMWTxnDetail_C_CrateCode.HeaderText = "货箱编号";
            this.c_grdMWTxnDetail_C_CrateCode.Name = "c_grdMWTxnDetail_C_CrateCode";
            this.c_grdMWTxnDetail_C_CrateCode.Width = 120;
            // 
            // c_grdMWTxnDetail_C_Vendor
            // 
            this.c_grdMWTxnDetail_C_Vendor.FillWeight = 150F;
            this.c_grdMWTxnDetail_C_Vendor.HeaderText = "收集医院";
            this.c_grdMWTxnDetail_C_Vendor.Name = "c_grdMWTxnDetail_C_Vendor";
            this.c_grdMWTxnDetail_C_Vendor.Width = 150;
            // 
            // c_grdMWTxnDetail_C_Waste
            // 
            this.c_grdMWTxnDetail_C_Waste.FillWeight = 150F;
            this.c_grdMWTxnDetail_C_Waste.HeaderText = "废品类型";
            this.c_grdMWTxnDetail_C_Waste.Name = "c_grdMWTxnDetail_C_Waste";
            this.c_grdMWTxnDetail_C_Waste.Width = 150;
            // 
            // c_grdMWTxnDetail_C_SubWeight
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWTxnDetail_C_SubWeight.DefaultCellStyle = dataGridViewCellStyle2;
            this.c_grdMWTxnDetail_C_SubWeight.HeaderText = "提交重量";
            this.c_grdMWTxnDetail_C_SubWeight.Name = "c_grdMWTxnDetail_C_SubWeight";
            // 
            // c_grdMWTxnDetail_C_TxnWeight
            // 
            this.c_grdMWTxnDetail_C_TxnWeight.HeaderText = "实际重量";
            this.c_grdMWTxnDetail_C_TxnWeight.Name = "c_grdMWTxnDetail_C_TxnWeight";
            // 
            // c_grdMWTxnDetail_C_EntryDate
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWTxnDetail_C_EntryDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.c_grdMWTxnDetail_C_EntryDate.FillWeight = 150F;
            this.c_grdMWTxnDetail_C_EntryDate.HeaderText = "提交时间";
            this.c_grdMWTxnDetail_C_EntryDate.Name = "c_grdMWTxnDetail_C_EntryDate";
            this.c_grdMWTxnDetail_C_EntryDate.Width = 150;
            // 
            // c_grdMWTxnDetail_C_Status
            // 
            this.c_grdMWTxnDetail_C_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.c_grdMWTxnDetail_C_Status.DefaultCellStyle = dataGridViewCellStyle4;
            this.c_grdMWTxnDetail_C_Status.FillWeight = 250F;
            this.c_grdMWTxnDetail_C_Status.HeaderText = "货箱状态";
            this.c_grdMWTxnDetail_C_Status.Name = "c_grdMWTxnDetail_C_Status";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.c_labTotalQty);
            this.panel2.Location = new System.Drawing.Point(687, 319);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(163, 95);
            this.panel2.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(3, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "共：";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.ForeColor = System.Drawing.Color.Lime;
            this.label12.Location = new System.Drawing.Point(129, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "箱";
            // 
            // c_labTotalQty
            // 
            this.c_labTotalQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labTotalQty.Font = new System.Drawing.Font("微软雅黑", 38F);
            this.c_labTotalQty.ForeColor = System.Drawing.Color.Lime;
            this.c_labTotalQty.Location = new System.Drawing.Point(50, 10);
            this.c_labTotalQty.Name = "c_labTotalQty";
            this.c_labTotalQty.Size = new System.Drawing.Size(90, 78);
            this.c_labTotalQty.TabIndex = 0;
            this.c_labTotalQty.Text = "0";
            this.c_labTotalQty.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(524, 393);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 17);
            this.label18.TabIndex = 36;
            this.label18.Text = "实际总数量：";
            // 
            // c_grpCurTxnDetail
            // 
            this.c_grpCurTxnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.c_grpCurTxnDetail.Controls.Add(this.c_txtCurCrateCode);
            this.c_grpCurTxnDetail.Controls.Add(this.c_labUnit1);
            this.c_grpCurTxnDetail.Controls.Add(this.c_labUnit2);
            this.c_grpCurTxnDetail.Controls.Add(this.c_labCurTxnWeight);
            this.c_grpCurTxnDetail.Controls.Add(this.label6);
            this.c_grpCurTxnDetail.Controls.Add(this.c_labCurSubWeight);
            this.c_grpCurTxnDetail.Controls.Add(this.label5);
            this.c_grpCurTxnDetail.Controls.Add(this.c_labCurStatus);
            this.c_grpCurTxnDetail.Controls.Add(this.label4);
            this.c_grpCurTxnDetail.Controls.Add(this.c_btnCheck);
            this.c_grpCurTxnDetail.Controls.Add(this.c_btnManually);
            this.c_grpCurTxnDetail.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.c_grpCurTxnDetail.Location = new System.Drawing.Point(12, 307);
            this.c_grpCurTxnDetail.Name = "c_grpCurTxnDetail";
            this.c_grpCurTxnDetail.Size = new System.Drawing.Size(402, 110);
            this.c_grpCurTxnDetail.TabIndex = 42;
            this.c_grpCurTxnDetail.TabStop = false;
            this.c_grpCurTxnDetail.Text = "当前货箱";
            // 
            // c_txtCurCrateCode
            // 
            this.c_txtCurCrateCode.Location = new System.Drawing.Point(92, 24);
            this.c_txtCurCrateCode.Name = "c_txtCurCrateCode";
            this.c_txtCurCrateCode.ReadOnly = true;
            this.c_txtCurCrateCode.Size = new System.Drawing.Size(132, 25);
            this.c_txtCurCrateCode.TabIndex = 18;
            // 
            // c_labUnit1
            // 
            this.c_labUnit1.AutoSize = true;
            this.c_labUnit1.Location = new System.Drawing.Point(139, 55);
            this.c_labUnit1.Name = "c_labUnit1";
            this.c_labUnit1.Size = new System.Drawing.Size(28, 20);
            this.c_labUnit1.TabIndex = 2;
            this.c_labUnit1.Text = "KG";
            this.c_labUnit1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // c_labUnit2
            // 
            this.c_labUnit2.AutoSize = true;
            this.c_labUnit2.Location = new System.Drawing.Point(139, 84);
            this.c_labUnit2.Name = "c_labUnit2";
            this.c_labUnit2.Size = new System.Drawing.Size(28, 20);
            this.c_labUnit2.TabIndex = 1;
            this.c_labUnit2.Text = "KG";
            this.c_labUnit2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // c_labCurTxnWeight
            // 
            this.c_labCurTxnWeight.Location = new System.Drawing.Point(85, 84);
            this.c_labCurTxnWeight.Name = "c_labCurTxnWeight";
            this.c_labCurTxnWeight.Size = new System.Drawing.Size(57, 21);
            this.c_labCurTxnWeight.TabIndex = 1;
            this.c_labCurTxnWeight.Text = "0";
            this.c_labCurTxnWeight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "实际重量：";
            // 
            // c_labCurSubWeight
            // 
            this.c_labCurSubWeight.Location = new System.Drawing.Point(85, 55);
            this.c_labCurSubWeight.Name = "c_labCurSubWeight";
            this.c_labCurSubWeight.Size = new System.Drawing.Size(57, 21);
            this.c_labCurSubWeight.TabIndex = 1;
            this.c_labCurSubWeight.Text = "0";
            this.c_labCurSubWeight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "提交重量：";
            // 
            // c_labCurStatus
            // 
            this.c_labCurStatus.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.c_labCurStatus.ForeColor = System.Drawing.Color.Blue;
            this.c_labCurStatus.Location = new System.Drawing.Point(230, 23);
            this.c_labCurStatus.Name = "c_labCurStatus";
            this.c_labCurStatus.Size = new System.Drawing.Size(166, 27);
            this.c_labCurStatus.TabIndex = 1;
            this.c_labCurStatus.Text = "未确认";
            this.c_labCurStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "货箱编号：";
            // 
            // c_btnCheck
            // 
            this.c_btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnCheck.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnCheck.Location = new System.Drawing.Point(176, 55);
            this.c_btnCheck.Name = "c_btnCheck";
            this.c_btnCheck.Size = new System.Drawing.Size(102, 49);
            this.c_btnCheck.TabIndex = 0;
            this.c_btnCheck.Text = "审核确认";
            this.c_btnCheck.UseVisualStyleBackColor = true;
            this.c_btnCheck.Click += new System.EventHandler(this.c_btnCheck_Click);
            // 
            // c_btnManually
            // 
            this.c_btnManually.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnManually.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnManually.Location = new System.Drawing.Point(294, 56);
            this.c_btnManually.Name = "c_btnManually";
            this.c_btnManually.Size = new System.Drawing.Size(102, 49);
            this.c_btnManually.TabIndex = 0;
            this.c_btnManually.Text = "手动确认";
            this.c_btnManually.UseVisualStyleBackColor = true;
            this.c_btnManually.Click += new System.EventHandler(this.c_btnManually_Click);
            // 
            // c_labUnit4
            // 
            this.c_labUnit4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labUnit4.AutoSize = true;
            this.c_labUnit4.Location = new System.Drawing.Point(657, 393);
            this.c_labUnit4.Name = "c_labUnit4";
            this.c_labUnit4.Size = new System.Drawing.Size(25, 17);
            this.c_labUnit4.TabIndex = 38;
            this.c_labUnit4.Text = "KG";
            this.c_labUnit4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // c_labUnit3
            // 
            this.c_labUnit3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labUnit3.AutoSize = true;
            this.c_labUnit3.Location = new System.Drawing.Point(657, 363);
            this.c_labUnit3.Name = "c_labUnit3";
            this.c_labUnit3.Size = new System.Drawing.Size(25, 17);
            this.c_labUnit3.TabIndex = 37;
            this.c_labUnit3.Text = "KG";
            this.c_labUnit3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(524, 363);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 17);
            this.label16.TabIndex = 41;
            this.label16.Text = "提交总重量：";
            // 
            // c_btnDestDone
            // 
            this.c_btnDestDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_btnDestDone.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.c_btnDestDone.Image = ((System.Drawing.Image)(resources.GetObject("c_btnDestDone.Image")));
            this.c_btnDestDone.Location = new System.Drawing.Point(856, 349);
            this.c_btnDestDone.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.c_btnDestDone.Name = "c_btnDestDone";
            this.c_btnDestDone.Size = new System.Drawing.Size(140, 65);
            this.c_btnDestDone.TabIndex = 35;
            this.c_btnDestDone.Text = "处理完成";
            this.c_btnDestDone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.c_btnDestDone.UseVisualStyleBackColor = true;
            this.c_btnDestDone.Click += new System.EventHandler(this.c_btnDestDone_Click);
            // 
            // c_labTotalSubWeigth
            // 
            this.c_labTotalSubWeigth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labTotalSubWeigth.Location = new System.Drawing.Point(610, 361);
            this.c_labTotalSubWeigth.Name = "c_labTotalSubWeigth";
            this.c_labTotalSubWeigth.Size = new System.Drawing.Size(48, 21);
            this.c_labTotalSubWeigth.TabIndex = 44;
            this.c_labTotalSubWeigth.Text = "000.00";
            this.c_labTotalSubWeigth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_labTotalTxnWeight
            // 
            this.c_labTotalTxnWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c_labTotalTxnWeight.Location = new System.Drawing.Point(610, 391);
            this.c_labTotalTxnWeight.Name = "c_labTotalTxnWeight";
            this.c_labTotalTxnWeight.Size = new System.Drawing.Size(48, 21);
            this.c_labTotalTxnWeight.TabIndex = 44;
            this.c_labTotalTxnWeight.Text = "000.00";
            this.c_labTotalTxnWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c_bgwRefTxnDetail
            // 
            this.c_bgwRefTxnDetail.DoWork += new System.ComponentModel.DoWorkEventHandler(this.c_bgwRefTxnDetail_DoWork);
            // 
            // c_time
            // 
            this.c_time.Interval = 2000;
            this.c_time.Tick += new System.EventHandler(this.c_time_Tick);
            // 
            // FrmMWDestroyDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 429);
            this.Controls.Add(this.c_labTotalTxnWeight);
            this.Controls.Add(this.c_labTotalSubWeigth);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.c_grpCurTxnDetail);
            this.Controls.Add(this.c_labUnit4);
            this.Controls.Add(this.c_labUnit3);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.c_btnDestDone);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c_txtDestNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c_btnStopDest);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMWDestroyDetail";
            this.Text = "FrmDestoryInventory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMWDestroyDetail_FormClosing);
            this.Load += new System.EventHandler(this.FrmMWDestroyDetail_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_grdMWTxnDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.c_grpCurTxnDetail.ResumeLayout(false);
            this.c_grpCurTxnDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button c_btnStopDest;
        private System.Windows.Forms.TextBox c_txtDestNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label c_labTotalQty;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox c_grpCurTxnDetail;
        private System.Windows.Forms.Label c_labUnit1;
        private System.Windows.Forms.Label c_labUnit2;
        private System.Windows.Forms.Label c_labCurTxnWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label c_labCurSubWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label c_labCurStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button c_btnCheck;
        private System.Windows.Forms.Button c_btnManually;
        private System.Windows.Forms.Label c_labUnit4;
        private System.Windows.Forms.Label c_labUnit3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button c_btnDestDone;
        private System.Windows.Forms.TextBox c_txtCurCrateCode;
        private System.Windows.Forms.Label c_labTotalSubWeigth;
        private System.Windows.Forms.Label c_labTotalTxnWeight;
        private System.Windows.Forms.DataGridView c_grdMWTxnDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWTxnDetail_C_CrateCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWTxnDetail_C_Vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWTxnDetail_C_Waste;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWTxnDetail_C_SubWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWTxnDetail_C_TxnWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWTxnDetail_C_EntryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_grdMWTxnDetail_C_Status;
        private System.ComponentModel.BackgroundWorker c_bgwRefTxnDetail;
        private System.Windows.Forms.Timer c_time;
    }
}