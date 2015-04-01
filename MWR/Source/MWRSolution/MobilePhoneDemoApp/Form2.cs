using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LinqToExcel;
using YRKJ.MWR;
using YRKJ.MWR.Business.Report;
using ComLib;

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
            List<TblMWInventory> invDataList = null;
            string errMsg = "";
            if (!ReportDataMng.GetInventoryGroupByVendorAndWasteReportData(ref invDataList, ref errMsg))
            {
                
            }

            var q = from x in invDataList
                    group x by x.VendorCode into g
                    select g;
            foreach (var item in q)
            {
                foreach (var subItem in item)
                { 
                    //subItem.
                }
            }

            string str = textBox1.Text;
            textBox2.Text =  new ComLib.db.mysql.SqlMySqlFn().ReplaceSpecialChar(str);
            return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Type tp = this.GetType();
            System.Reflection.MethodInfo me;
            me = tp.GetMethod("Foo");
        }

        public bool Foo(string p1, int p2)
        {
            return true;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string s = textBox1.Text;
            //System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^(>|=|<)\d+(\.\d+)?$");
            //textBox2.Text = reg.IsMatch(s).ToString();
            int page = ComFn.StringToInt(textBox1.Text);
            ShowPage(page,14);
            string s = "";
            System.Diagnostics.Debug.WriteLine("");
            for (int i = 1 + fPage; i <= PageCount + fPage; i++)
            {
                s += " " + i;
            }
            System.Diagnostics.Debug.Write(s);
        }

        protected int CurrentPage = 0;
        protected int PageCount = 0;
        protected int NextPage = 0;
        protected int PrePage = 0;
        protected string DisPre = "";
        protected string DisNext = "";

        protected int fPage = 0;
        const int PageCountSize = 10;
        const int tabCount = 5;

        const string DisClass = "disabled";
        const int p = 10;
        public void ShowPage(int curPage, int pageCount)
        {
            CurrentPage = curPage;// 1;// ComLib.ComFn.StringToInt(page);
            PageCount = pageCount;// p;
            NextPage = CurrentPage + 1;//> PageCount ? PageCount : CurrentPage + 1;
            PrePage = CurrentPage - 1;//< 0 ? 0 : CurrentPage - 1;
            DisNext = NextPage > PageCount ? DisClass : "";
            DisPre = PrePage < 1 ? DisClass : "";

            if (PageCount < PageCountSize)
            {
                return;
            }

            if (curPage >= PageCountSize)
            {
                fPage = (curPage - tabCount);
            }
            else if (curPage >= tabCount)
            {
                fPage = (curPage - tabCount);
            }
            else
            {
                fPage = 0;
            }

            if (fPage + PageCountSize > PageCount)
            {
                fPage = PageCount - PageCountSize;
                PageCount = PageCountSize;
            }
            else
            {
                PageCount = PageCountSize;
            }
            //if (curPage >= PageCountSize)
            //{
            //    fPage = (curPage - tabCount);
            //}
            //else if (curPage >= tabCount)
            //{
            //    fPage = (curPage - tabCount);
            //}
            //else
            //{
            //    fPage = 0;
            //}

            //if (fPage + PageCountSize > PageCount)
            //{
            //    PageCount = PageCount - fPage;;
            //}
            //else
            //{
            //    PageCount = PageCountSize;
            //}
         
        }
    }
}
