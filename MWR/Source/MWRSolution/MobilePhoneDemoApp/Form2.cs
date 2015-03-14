using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LinqToExcel;

namespace MobilePhoneDemoApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var excel = new ExcelQueryFactory("excelFileName");
            //var indianaCompanies = from c in excel.Worksheet<Company>()
            //                       where c.State == "IN"
            //                       select c;

            //var excelfile = new ExcelQueryFactory(@"E:\project\net\githubWorkspace\VS\MWR\Source\MWRSolution\MobilePhoneDemoApp\bin\Debug\1.xlsx");
            var excelfile = new ExcelQueryFactory("1.xlsx");
            //var tsheet = excelfile.Worksheet(0);//查询30岁以上的人的名字
            #region employ
            {
                var tsheet = excelfile.Worksheet("员工信息");
                var query = from p in tsheet
                            //where p["Age"].Cast<int>() > 30
                            select p;
                foreach (var item in query)
                {
                    System.Diagnostics.Debug.WriteLine(
                        item["员工编号"] + " " + item["员工姓名"] + " " + item["密码"]
                        );
                }
            }
            #endregion

            #region vendor
            {
                var tsheet = excelfile.Worksheet("医院信息");
                var query = from p in tsheet
                            select p;
                foreach (var item in query)
                {
                    System.Diagnostics.Debug.WriteLine(
                        item["医院编号"] + " " + item["医院名称"] + " " + item["医院坐标"]
                        );
                }
            }
            #endregion

            #region wastercategory
            {
                var tsheet = excelfile.Worksheet("废料类型");
                var query = from p in tsheet
                            select p;
                foreach (var item in query)
                {
                    System.Diagnostics.Debug.WriteLine(
                        item["类型编号"] + " " + item["类型名称"] 
                        );
                }
            }
            #endregion

            #region car
            {
                var tsheet = excelfile.Worksheet("车辆信息");
                var query = from p in tsheet
                            select p;
                foreach (var item in query)
                {
                    System.Diagnostics.Debug.WriteLine(
                        item["车辆编号"] + " " + item["车辆名称"]
                        );
                }
            }
            #endregion

            #region depot
            {
                var tsheet = excelfile.Worksheet("仓库信息");
                var query = from p in tsheet
                            select p;
                foreach (var item in query)
                {
                    System.Diagnostics.Debug.WriteLine(
                        item["仓库编号"] + " " + item["仓库名称"]
                        );
                }
            }
            #endregion

            #region crate
            {
                var tsheet = excelfile.Worksheet("货箱信息");
                var query = from p in tsheet
                            select p;
                foreach (var item in query)
                {
                    System.Diagnostics.Debug.WriteLine(
                        item["货箱编号"] + " " + item["货箱名称"]
                        );
                }
            }
            #endregion

            int a = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            textBox2.Text =  new ComLib.db.mysql.SqlMySqlFn().ReplaceSpecialChar(str);
            return;
        }
    }
}
