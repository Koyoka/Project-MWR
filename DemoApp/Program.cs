using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using ComLib.db;
using DemoApp.TblModel;

namespace DemoApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Debug.WriteLine("-----------");
            Debug.WriteLine("-----------" + (true && true));
            Debug.WriteLine("-----------" + (true && false));
            Debug.WriteLine("-----------" + (false && false));

            Init();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Init()
        {
            SqlDBMng.initDBMng(
                SqlDBMng.GetConnStr("test","127.0.0.1","root","-101868"),
                SqlDBMng.DBTypeEnum.MySQl);
        }
      
    }
}
