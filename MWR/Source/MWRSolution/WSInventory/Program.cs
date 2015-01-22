using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComLib.db;
using ComLib.Log;
using YRKJ.MWR.WinBase.WinAppBase;
using YRKJ.MWR.WinBase.WinAppBase.Config;
using YRKJ.MWR.WinBase.WinAppBase.BaseForm;

namespace YRKJ.MWR.WSInventory
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

            //Application.Run(new WSInventory.Form1());
            //return;

            try
            {
                string errMsg = "";

                #region DBMng Init

                SqlDBMng.initDBMng(SqlDBMng.DBTypeEnum.MySQl);

                #endregion

                #region Log
                {
                    if (!LogMng.InitLog(WinAppFn.GetSettingFolder() + "Log", "MWR", ref errMsg))
                    {
                        MsgBox.Error("初始化错误/r/n" + errMsg);
                        return;
                    }
                }
                #endregion

                #region Database
                {
                    AppConfig configData = null;
                    if (!ConfigMng.ReadAppConfig(ref configData, ref errMsg))
                    {
                        MsgBox.Error("配置文件读取失败/r/n" + errMsg);
                        return;
                    }
                    if (!SqlDBMng.DetectDBServer(
                        WinAppBase.DBName,
                         configData.DBServerName,
                         configData.DBUserName,
                         configData.DBPassword, ref errMsg))
                    {
                        using (FrmInitConfig f = new FrmInitConfig())
                        {
                            if (f.ShowDialog() != DialogResult.OK)
                            {
                                return;
                            }
                        }

                        if (!ConfigMng.ReadAppConfig(ref configData, ref errMsg))
                        {
                            MsgBox.Error("配置文件读取失败/r/n" + errMsg);
                            return;
                        }

                        SqlDBMng.setConnectionString(
                         SqlDBMng.GetConnStr(WinAppBase.DBName,
                         configData.DBServerName,
                         configData.DBUserName,
                         configData.DBPassword));
                    }

                }
                #endregion

                #region user login

                using (YRKJ.MWR.WSInventory.Forms.FrmLogin f = new Forms.FrmLogin())
                {
                    if (f.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }

                #endregion

            }
            catch (Exception ex)
            {
                MsgBox.Error("系统错误/r/n" + ex.Message);
                return;
            }
            Application.Run(new Forms.FrmMain());
        }
    }
}
