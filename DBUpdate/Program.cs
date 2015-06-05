using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComLib.db;
using ComLib.Log;
using DBUpdate.WinAppBase;

namespace DBUpdate
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string errMsg = "";
            if (!LogMng.InitLog(WinAppFn.GetSettingFolder() + "Log", "DBUpdate", ref errMsg))
            {
                MsgBox.Error("初始化错误/r/n" + errMsg);
                return;
            }

            SqlDBMng.initDBMng(SqlDBMng.DBTypeEnum.MySQl);


            Application.Run(new FrmMain());
        }
    }
}
