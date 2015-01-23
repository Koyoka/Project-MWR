using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.Log;

namespace YRKJ.MWR.WinBase.WinAppBase.Config
{
    public class ConfigMng
    {
        private const string ClassName = "YRKJ.MWR.WinBase.WinAppBase.Config.ConfigMng";

        private const string cfgFileName = "mwr.cfg";
        public static bool ReadAppConfig(ref AppConfig data, ref string errMsg)
        {
            try
            {
                string path = WinAppFn.GetSettingFolder() + cfgFileName;

                if (!System.IO.File.Exists(path))
                {
                    AppConfig tempData = new AppConfig();
                    tempData.DBServerName = ".";
                    tempData.DBUserName = "root";
                    tempData.DBPassword = ComFn.DecryptDBPassword(WinAppBase.DBKey, WinAppBase.DefaultEPassword);
                    tempData.ServiceRoot = "127.0.0.1";
                    //tempData.DBDatabaseNumber = "0";
                    if (!SaveAppConfig(tempData, ref  errMsg))
                    {
                        return false;
                    }
                }

                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(path);

                data = new AppConfig();

                data.DBServerName = ComFn.SafeGetXmlNodeInnerText(doc, "Root/Database/ServerName");
                //data.DBDatabaseNumber = ComFn.SafeGetXmlNodeInnerText(doc, "Root/Database/DatabaseNumber");
                data.DBUserName = ComFn.SafeGetXmlNodeInnerText(doc, "Root/Database/UserName");
                data.DBPassword = ComFn.DecryptDBPassword(WinAppBase.DBKey,ComFn.SafeGetXmlNodeInnerText(doc, "Root/Database/Password"));
                data.ServiceRoot = ComFn.SafeGetXmlNodeInnerText(doc, "Root/WebService/ServiceRoot");

                data.WSCode = ComFn.SafeGetXmlNodeInnerText(doc, "Root/WorkStation/Code");
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                LogMng.GetLog().PrintError(ClassName, "ReadAppConfig", ex);
                return false;
            }
        }
        public static bool SaveAppConfig(AppConfig data, ref string errMsg)
        {
            try
            {
                string path = WinAppFn.GetSettingFolder() + cfgFileName;

                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sb.Append("<Root>");
                #region DataBase
                sb.Append("	<Database>");
                sb.Append("		<ServerName>" + ComFn.GetSafeXml(data.DBServerName) + "</ServerName>");
                //sb.Append("		<DatabaseNumber>" + ComFn.GetSafeXml(ComFn.AppendBegin(data.DBDatabaseNumber, 4, '0')) + "</DatabaseNumber>");
                sb.Append("		<UserName>" + ComFn.GetSafeXml(data.DBUserName) + "</UserName>");
                sb.Append("		<Password>" + ComFn.GetSafeXml(ComFn.EncryptDBPassword(WinAppBase.DBKey,data.DBPassword)) + "</Password>");
                //sb.Append("		<SQLDatabaseFolder>" + ComFn.GetSafeXml("") + "</SQLDatabaseFolder>");
                sb.Append("	</Database>");
                #endregion
                sb.Append(" <WebService>");
                sb.Append("     <ServiceRoot>" + ComFn.GetSafeXml(data.ServiceRoot) + "</ServiceRoot>");
                sb.Append(" </WebService>");
                sb.Append("	<WorkStation>");
                sb.Append("		<Code>" + ComFn.GetSafeXml(data.WSCode) + "</Code>");
                sb.Append("	</WorkStation>");
                sb.Append("</Root>");

                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.InnerXml = sb.ToString();
                doc.Save(path);

                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                LogMng.GetLog().PrintError(ClassName, "SaveAppConfig", ex);
                return false;
            }
        }

    }
}
