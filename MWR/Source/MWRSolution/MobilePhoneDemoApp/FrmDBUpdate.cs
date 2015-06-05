using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComLib.db.mysql.Update;
using YRKJ.MWR.WinBase.WinAppBase;

namespace MobilePhoneDemoApp
{
    public partial class FrmDBUpdate : Form
    {
        public FrmDBUpdate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            MySqlDBUpdate dbUpdate = MySqlDBUpdate.GetInstance(false);
            
            dbUpdate.SetPrint((x) =>
            {
                int strat = 0;
                int length = 0;
                Color c = new Color();
                string s = 
                ComLib.db.mysql.Update.MySqlDBUpdate.DoUpdateHelper.GetColorOutput(x, ref strat, ref length,ref c);
                int orgLength = richTextBox1.Text.Length;
                richTextBox1.AppendText(s);
                richTextBox1.SelectionStart = strat + orgLength;
                richTextBox1.SelectionLength = length;
                richTextBox1.SelectionColor = c;
                
                //using (WebBrowser webBrowser = new WebBrowser())
                //{
                //    webBrowser.Visible = false;

                //    webBrowser.DocumentText = x;

                //    webBrowser.Document.Write(x);

                //    //this.richTextBox1.Text = webBrowser.Document.Body.OuterText;
                //    richTextBox1.AppendText(webBrowser.Document.Body.OuterText);
                //}  

                //richTextBox1.SelectionStart = 1;
               
            }, (x) =>
            {
                int strat = 0;
                int length = 0;
                Color c = new Color();
                string s =
                ComLib.db.mysql.Update.MySqlDBUpdate.DoUpdateHelper.GetColorOutput(x, ref strat, ref length, ref c);
                int orgLength = richTextBox1.Text.Length;
                richTextBox1.AppendText(s);
                richTextBox1.SelectionStart = strat + orgLength;
                richTextBox1.SelectionLength = length;
                richTextBox1.SelectionColor = c;
            });
            //dbUpdate.DebugOutput = new MySqlDBUpdate.DelegateDebugOutput((x) => {
            //    textBox1.AppendText(x);
            //});

            //dbUpdate.Output = new MySqlDBUpdate.DelegateOutput((x) => {
            //    textBox1.AppendText(x);
            //});

            string errMsg = "";
            string dbName, dbService, dbUser, dbPassword, dbPort, path;

            //dbName = "mwrdata";
            //dbService = "127.0.0.1";
            //dbUser = "root";
            //dbPassword = "-101868";
            //dbPort = "3306";
            //path = WinAppFn.GetSettingFolder() + "mwr.sql";
            //dbName = "demodata";
            //dbService = "127.0.0.1";
            //dbUser = "root";
            //dbPassword = "-101868";
            //dbPort = "3306";
            //path = WinAppFn.GetSettingFolder() + "demodata.sql";
            dbName = "cdcs";
            dbService = "192.168.1.152";
            dbUser = "root";
            dbPassword = "123456";
            dbPort = "3306";
            path = WinAppFn.GetSettingFolder() + "cdcs.sql";
            
            if (!dbUpdate.DoUpdate(dbName,dbService, dbUser, dbPassword, dbPort, path, ref errMsg))
            {
                MessageBox.Show(errMsg);
            }
        }
    }
}
