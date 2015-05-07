using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComLib.db;
using YRKJ.MWR.WinBase.WinAppBase;
using ComLib.Log;
using YRKJ.MWR.WinBase.WinAppBase.Config;
using YRKJ.MWR.WinBase.WinAppBase.BaseForm;

namespace MWRSyncMng
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
                         configData.DBPassword,
                         configData.DBPort, ref errMsg))
                    {
                        using (FrmInitDBConfig f = new FrmInitDBConfig())
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
                    }
                    SqlDBMng.setConnectionString(
                     SqlDBMng.GetConnStr(WinAppBase.DBName,
                     configData.DBServerName,
                     configData.DBUserName,
                     configData.DBPassword,
                     configData.DBPort));

                }
                #endregion

            }
            catch (Exception ex)
            {
                MsgBox.Error("系统错误/r/n" + ex.Message);
                return;
            }


            Application.Run(new FrmMain());
        }
    }
}
