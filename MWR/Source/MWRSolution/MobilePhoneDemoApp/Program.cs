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

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //foo();

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
