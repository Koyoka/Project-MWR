using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComLib.db;
using ComLib.Log;
using YRKJ.MWR.WinBase.WinAppBase;
using YRKJ.MWR.WinBase.WinAppBase.Config;
using YRKJ.MWR.WinBase.WinAppBase.BaseForm;
using YRKJ.MWR.Business.BO;

namespace YRKJ.MWR.WSDestory
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region test
            //{
            //    YRKJ.MWR.WSDestory.Business.Modbus.ModbusHelper m = new Business.Modbus.ModbusHelper();
            //    m.foo();
            //}
            #endregion
            try
            {
                if (args != null)
                {
                    if (args.Length >= 1)
                    {
                        WinAppBase.DBName = args[0];
                    }
                }

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
                        using (FrmInitDWSConfig f = new FrmInitDWSConfig())
                        {
                            f.OnInitValid = x => {
                                DataCtrlInfo dcf = new DataCtrlInfo();
                                dcf.SetDBSession(
                                        SqlDBMng.GetConnStr(
                                        WinAppBase.DBName,
                                        x.DBServerName,
                                        x.DBUserName,
                                        x.DBPassword,
                                        x.DBPort)
                                    );
                                if (!WSMng.RegistDWS(dcf,x.WSCode, ref errMsg))
                                {
                                    MsgBox.Error("工作站编号注册失败，请查看是否已注册。");
                                    return false;
                                }
                                return true;
                            };
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
                    YRKJ.MWR.WSDestory.Business.Sys.SysInfo.GetInstance().Config = configData;
                    SqlDBMng.setConnectionString(
                     SqlDBMng.GetConnStr(WinAppBase.DBName,
                     configData.DBServerName,
                     configData.DBUserName,
                     configData.DBPassword,
                     configData.DBPort));

                }
                #endregion

                #region user login

                using (YRKJ.MWR.WSDestory.Forms.FrmLogin f = new Forms.FrmLogin())
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
