using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComLib.db;
using ComLib.Log;
using YRKJ.MWR.WinBase.WinAppBase;
using YRKJ.MWR.WinBase.WinAppBase.Config;
using YRKJ.MWR.WinBase.WinAppBase.BaseForm;

namespace YRKJ.MWR.WSDestory
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

            
            try
            {
                string errMsg = "";

                #region DBMng
                Init();
                #endregion

                #region Log
                {
                    if (!LogMng.InitLog(WinAppFn.GetSettingFolder() + "Log", "MWR", ref errMsg))
                    {
                        ShowErrorMsg("CANNOT init log file.", errMsg);
                        return;
                    }
                }
                #endregion

                #region Database
                {
                    AppConfig configData = null;
                    if (!ConfigMng.ReadAppConfig(ref configData, ref errMsg))
                    {
                        ShowErrorMsg("CANNOT read config file.", errMsg);
                        return;
                    }
                    if (!SqlDBMng.DetectDBServer("test", "1227.0.0.11", "root", "-101868", ref errMsg))
                    {
                        using (FrmInitConfig f = new FrmInitConfig())
                        {
                            f.ShowDialog();
                        }
                    }
                    //DateTime d = SqlDBMng.GetDBNow("test", "127.0.0.1", "root", "-101868",ref errMsg);
                    //if (!Profitek.Qooway.Common.Database.SqlServer.SqlServerMng.DetectDBServer(configData.DBServerName, configData.DBUserName, configData.DBPassword, ref errMsg))
                    //{
                    //    using (FrmDBConfig frm = new FrmDBConfig())
                    //    {
                    //        if (frm.ShowDialog() != DialogResult.OK)
                    //        {
                    //            return;
                    //        }
                    //    }

                    //    if (!ConfigMng.ReadAppConfig(ref configData, ref errMsg))
                    //    {
                    //        ShowErrorMsg("CANNOT read config file.", errMsg);
                    //        return;
                    //    }
                    //}

                    //DbInfoMng.SetDataDb(configData.DBServerName, configData.DBUserName, configData.DBPassword, configData.DBDatabaseNumber);
                }
                #endregion

            }
            catch(Exception ex)
            {
                ShowErrorMsg("System Error", ex.Message);
                return;
            }
            Application.Run(new FrmInitConfig());
           

            //Application.Run(new Form1());
        }

        static void Init()
        {
            SqlDBMng.initDBMng(
                SqlDBMng.GetConnStr("test", "127.0.0.1", "root", "-101868"),
                SqlDBMng.DBTypeEnum.MySQl);
        }

        private static void ShowErrorMsg(string name, string errMsg)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine(name);
            sb.AppendLine(errMsg);

            MessageBox.Show(sb.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
