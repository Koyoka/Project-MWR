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

           // //System.Diagnostics.Debug.Write(ComLib.ComFn.EncryptStringBy64("鄂州"));
           // byte[] bits = System.Text.Encoding.Default.GetBytes("MWR-STARTSHIFT 鄂A00002 YG0002 YG0006");
           //System.Diagnostics.Debug.Write(Convert.ToBase64String(bits));
           // //System.Diagnostics.Debug.Write(ComLib.ComFn.DecryptStringBy64("TVdSLVNUQVJUU0hJRlQgtvVBMDAwMDIgWUcwMDAyIFlHMDAwNg=="));
           // return;
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
                    }
                    YRKJ.MWR.WSDestory.Business.Sys.SysInfo.GetInstance().Config = configData;
                    SqlDBMng.setConnectionString(
                     SqlDBMng.GetConnStr(WinAppBase.DBName,
                     configData.DBServerName,
                     configData.DBUserName,
                     configData.DBPassword));

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
