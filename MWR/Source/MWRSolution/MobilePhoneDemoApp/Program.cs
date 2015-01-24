using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComLib.db;
using YRKJ.MWR;

namespace MobilePhoneDemoApp
{
    static class Program
    {
        static void foo()
        {
            #region
            ComLib.db.SqlDBMng.initDBMng(ComLib.db.SqlDBMng.DBTypeEnum.MySQl);

            ComLib.db.SqlDBMng.setConnectionString(
                       ComLib.db.SqlDBMng.GetConnStr("MWRDATA",
                       "127.0.0.1",
                       "root",
                       "-101868"));
            #endregion

            DataCtrlInfo dcf = new ComLib.db.DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            List<TblMWTxnDetail> itemList = new List<TblMWTxnDetail>();
            string errMsg = "";
            TblMWTxnDetailCtrl.QueryMore(dcf, sqm, ref itemList, ref errMsg);

            int a = 0;
        }

        class C
        {
            private string _a1 = "";
            public string A1
            {
                get { return _a1; }
                set { _a1 = value; }
            }
            private string _a2 = "";
            public string A2
            {
                get { return _a2; }
                set { _a2 = value; }
            }

        }
        delegate int del(int i, string s);
        static void fooo()
        {


            List<C> clist = new List<C> {
                new C { A1="1",A2="1"},
                new C { A1="2",A2="2"},new C { A1="3",A2="3"}
            };
            C c = clist.Find(x => x.A1 == "1");

            //clist.
            var f = typeof(C).GetProperty("A1").GetValue(c, null).ToString();

            //string s =
            //    from score in clist
            //    where score = ""
            //    select score;
           
            //clist.Select(
            return;

            //del d = (i,s) => {
            //    int a = i; 
            //    return 1; 
            //};



            CallEvent callEvent = () => {
            
            };
        }




        delegate void CallEvent();
      
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //foo();
            fooo();
            return;
            //return;
            //string errMsg = "";
            //string resData = "";
            //MWHttpSendHelper.SendTxn(ref resData,ref errMsg);
            //MessageBox.Show(resData);
            //return;
            //int nextId = 121;
            //string s = "";
            //string TxnNumMask = "xxHX###";
            //string prefix = TxnNumMask.Replace("#", "");
            //string num = TxnNumMask.TrimStart(prefix.ToCharArray());//string.IsNullOrEmpty(prefix) ? TxnNumMask : TxnNumMask.Replace(prefix, "");
            ////s.Replace(
            //int len = num.Length;
            //int nextIdLen = nextId.ToString().Length;
            //if (nextIdLen > len)
            //{
            //    MessageBox.Show("编号超出界限");
            //    return ;
            //}
            //s = prefix + s.PadLeft(len - nextIdLen, '0') + nextId;
            //MessageBox.Show(s);
            //return;
            //return;
            if (args == null)
            {
                MessageBox.Show("请配置[司机][跟车员]的员工编号");
                return;
            }

            if (args.Length != 4)
            {
                MessageBox.Show("请配置[司机][跟车员]的员工编号");
                return;
            }
            //MessageBox.Show(args[0] + " " + args[1]);
            //return;
            #region
            ComLib.db.SqlDBMng.initDBMng(ComLib.db.SqlDBMng.DBTypeEnum.MySQl);

            ComLib.db.SqlDBMng.setConnectionString(
                       ComLib.db.SqlDBMng.GetConnStr("MWRDATA",
                       "127.0.0.1",
                       "root",
                       "-101868"));
            #endregion

            using (FrmInitData f = new FrmInitData(args[0], args[1], args[2],args[3]))
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            //return;
            Application.Run(new Form1());
        }
    }
}


//class MyData
//{
//    public int ID { get; set; }
//    public string Address { get; set; }
//    public string TelNumber { get; set; }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        List<MyData> list = new List<MyData>() 
//            {
//                new MyData() { ID = 1, Address = "beijing", TelNumber = "123" },
//                new MyData() { ID = 2, Address = "shanghai", TelNumber = "456" },
//                new MyData() { ID = 3, Address = "guangzhou", TelNumber = "789" },
//            };
//        var query1 = FindData(list, 1, "Address").First();
//        Console.WriteLine(query1);
//        var query2 = FindData(list, 3, "TelNumber").First();
//        Console.WriteLine(query2);
//    }
//    static List<string> FindData(List<MyData> data, int id, string fieldname)
//    {
//        var param = System.Linq.Expressions.Expression.Parameter(typeof(MyData));
//        var lambda = 
//            System.Linq.Expressions.Expression.Lambda(
//            System.Linq.Expressions.Expression.MakeMemberAccess(param, typeof(MyData).GetProperty(fieldname))
//            , param);

//        var list =
//            from x in data
//            where(x.ID == 1)
//            select x;
//        return data.Where(x => x.ID == id).Select(lambda.Compile() as Func<MyData, string>).ToList();
//    }
//}

/*
 static void Main(string[] args)
        {
            var datas = new List<User>();
            datas.Add(new User { id = 3, A = "a", B = "1", C = 1.1 });
            datas.Add(new User { id = 4, A = "b", B = "2", C = 2.1 });
            datas.Add(new User { id = 5, A = "a", B = "3", C = 3.1 });
            Console.WriteLine(returnX(datas, 3, "A"));
            Console.WriteLine(returnX(datas, 3, "B"));
            Console.WriteLine(returnX(datas, 4, "B"));
            Console.WriteLine(returnX(datas, 4, "A"));
            Console.ReadLine();
        }
 
        private static Dictionary<string, FieldInfo> FieldDescriptors = new Dictionary<string, FieldInfo>();
 
        private static string returnX(IEnumerable<User> datas, int id, string field)
        {
            var t = typeof(User);
            var key = string.Format("类型{0}的字段{1}", t.FullName, field);
            FieldInfo f;
            if (!FieldDescriptors.TryGetValue(key, out f))
            {
                f = t.GetField(field);
                FieldDescriptors.Add(key, f);
            }
            return (string)f.GetValue(datas.First(x => x.id == id));
        }
 */