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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region function
        class ImageTarget
        {
            private int _index = 0;

            public int Index
            {
                get { return _index; }
                set { _index = value; }
            }
            private string _imageTargetId = "";

            public string ImageTargetId
            {
                get { return _imageTargetId; }
                set { _imageTargetId = value; }
            }
        }

        private void loadData()
        {
            string errMsg = "";
            string result = "";
            if (!VWSAPIHelper.GetImageTargetList(ref result, ref errMsg))
            {
                MessageBox.Show(errMsg);
                return;
            }

            JObject jo = JObject.Parse(result);

            string result_code = "";
            string transaction_id = "";
            List<string> targetIdList = new List<string>();

            if (!JsonHelper.ConventJsonToValue(jo, "result_code", ref result_code))
            { 
                
            }

            if (!JsonHelper.ConventJsonToValue(jo, "transaction_id", ref transaction_id))
            {

            }

            if (!JsonHelper.ConventJsonToValue(jo, "results", ref targetIdList))
            {

            }

            List<ImageTarget> bindDataSource = new List<ImageTarget>();
            //foreach (string item in targetIdList)
            for (int i = 0; i < targetIdList.Count; i++)
            {
                string item = targetIdList[i];
                ImageTarget defineImageTarget = new ImageTarget();
                defineImageTarget.Index = i+1;
                defineImageTarget.ImageTargetId = item;
                bindDataSource.Add(defineImageTarget);
            }

            dataGridView1.DataSource = bindDataSource;

            MessageBox.Show("done");
           
        }
        #endregion

        #region event
        private void MainForm_Load(object sender, EventArgs e)
        {
            loadData();
        }
        #endregion

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.Columns[e.ColumnIndex].GetType()
            int index = e.RowIndex;
            if (index < -1)
            {
                return;
            }
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                
                string s = (dataGridView1.DataSource as List<ImageTarget>)[index].ImageTargetId;
                ImageTargetDetailForm f = new ImageTargetDetailForm(s);
                f.ShowDialog();
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditImageTargetForm f = new EditImageTargetForm();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
