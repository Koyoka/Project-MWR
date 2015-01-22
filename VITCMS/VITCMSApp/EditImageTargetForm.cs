using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VITCMSApp
{
    public partial class EditImageTargetForm : Form
    {
        public EditImageTargetForm()
        {
            InitializeComponent();
        }


        #region event



        private void c_btnSelectPicPath_Click(object sender, EventArgs e)
        {
            c_ofdSelectFile.Filter = "图片文件|*.jpg|图片文件|*.png";

            if (c_ofdSelectFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                c_txtImagePath.Text = c_ofdSelectFile.FileName;
            }
        }

        private void c_btnSelectMetaDataPath_Click(object sender, EventArgs e)
        {
            c_ofdSelectFile.Filter = "元数据|*.*";

            if (c_ofdSelectFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                c_txtMetaDataPath.Text = c_ofdSelectFile.FileName;
            }
        }

        #endregion

        private void c_btnOk_Click(object sender, EventArgs e)
        {
            string errMsg = "";

            string name = "";
            float width = 0;
            byte[] image = null;
            int active_flag = -1;
            byte[] application_metadata = null;

            name = c_txtIMName.Text.Trim();
            if (!float.TryParse(c_txtIMWidth.Text.Trim(), out width))
            {
                width = 200f;
            }
            image = VWSAPIHelper.putFileByteArray(c_txtImagePath.Text.Trim());
            active_flag = c_chkIsActive.Checked ? 1 : 0;
            application_metadata = VWSAPIHelper.putFileByteArray(c_txtMetaDataPath.Text.Trim());

            #region valid input data



            #endregion

            

            if (!VWSAPIHelper.AddImageTarget(name, width, image, active_flag, application_metadata, ref errMsg))
            {
                MessageBox.Show(errMsg);
                return;
            }
            MessageBox.Show("done");
        }

        private void c_btnSend_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c_txtDefaultWidth_Click(object sender, EventArgs e)
        {
            c_txtIMWidth.Text = "200";
        }
    }
}
