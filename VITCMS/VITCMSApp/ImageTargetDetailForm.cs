using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace VITCMSApp
{
    public partial class ImageTargetDetailForm : Form
    {
        private string _imageTargetId = "";
        public ImageTargetDetailForm(string imageTargetId)
        {
            InitializeComponent();
            _imageTargetId = imageTargetId;
        }

        #region event

        private void ImageTargetDetail_Load(object sender, EventArgs e)
        {
            string errMsg = "";
            string result = "";
            if (!VWSAPIHelper.GetImageTargetDetail_Retrieving(_imageTargetId, ref result, ref errMsg))
            {
                MessageBox.Show(errMsg);
                return;
            }

            string result_code = "";
            string status = "";
            JObject jo = JObject.Parse(result);
            if (!JsonHelper.ConventJsonToValue(jo, "result_code", ref result_code))
            {

            }

            if (!JsonHelper.ConventJsonToValue(jo, "status", ref status))
            {

            }
            string target_record = "";
            if (!JsonHelper.ConventJsonToValue(jo, "target_record", ref target_record))
            { }
            JObject jo_target_record = JObject.Parse(target_record);
            string target_id = "";
            bool active_flag = false;
            string name = "";
            float width = 0f;
            int tracking_rating = 0;
            string reco_rating = "";
            if (!JsonHelper.ConventJsonToValue(jo_target_record, "target_id", ref target_id))
            { }
            if (!JsonHelper.ConventJsonToValue(jo_target_record, "active_flag", ref active_flag))
            { }
            if (!JsonHelper.ConventJsonToValue(jo_target_record, "name", ref name))
            { }
            if (!JsonHelper.ConventJsonToValue(jo_target_record, "width", ref width))
            { }
            if (!JsonHelper.ConventJsonToValue(jo_target_record, "tracking_rating", ref tracking_rating))
            { }

            c_labImageTargetId.Text = target_id;
            c_labImageTargetName.Text = name;
            c_labImageTargetRating.Text = tracking_rating.ToString();
            c_labImageTargetStatus.Text = status;
            c_labImageTargetWidth.Text = width.ToString();

        }
        #endregion
    }
}
