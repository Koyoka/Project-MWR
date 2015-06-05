using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUpdate.WinAppBase;
using System.IO;
using System.Xml;
using DBUpdate.Module;
using ComLib;

namespace DBUpdate.Mng
{
    public class XmlMng
    {
        private string _xmlName = "";
        private string _xmlPath = "";
        public XmlMng(string xmlName)
        {
            _xmlName = xmlName;
        }

        #region public
        public bool GetFormInfo(ref MdlDBInfo dbInfo, ref string errMsg)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_xmlPath);
                XmlNode rootNode =
                   doc.SelectSingleNode("Root");


                XmlNode n =
                    doc.SelectSingleNode("Root/FormInfo");
               
                dbInfo = new MdlDBInfo();
                dbInfo.Id =
                    ComFn.SafeGetXmlNodeInnerText(n, "Id");
                dbInfo.ConnName =
                    ComFn.SafeGetXmlNodeInnerText(n, "ConnName");
                dbInfo.Service =
                    ComFn.SafeGetXmlNodeInnerText(n, "Service");
                dbInfo.Uid =
                    ComFn.SafeGetXmlNodeInnerText(n, "Uid");
                dbInfo.Password =
                    ComFn.SafeGetXmlNodeInnerText(n, "Password");
                dbInfo.Port =
                    ComFn.SafeGetXmlNodeInnerText(n, "Port");

                dbInfo.DBName =
                    ComFn.SafeGetXmlNodeInnerText(n, "DBName");
                dbInfo.SqlPath =
                    ComFn.SafeGetXmlNodeInnerText(n, "SqlPath");

                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        public bool GetDBConnList(ref List<MdlDBInfo> dbInfoList, ref string errMsg)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_xmlPath);
                XmlNode rootNode =
                   doc.SelectSingleNode("Root");


                XmlNodeList nodeList =
                    doc.SelectNodes("Root/DBInfo");
                dbInfoList = new List<MdlDBInfo>();
                foreach (XmlNode n in nodeList)
                {
                    MdlDBInfo dbInfo = new MdlDBInfo();
                    dbInfo.Id =
                        ComFn.SafeGetXmlNodeInnerText(n, "Id");

                    dbInfo.ConnName =
                        ComFn.SafeGetXmlNodeInnerText(n, "ConnName");
                    dbInfo.Service =
                        ComFn.SafeGetXmlNodeInnerText(n, "Service");
                    dbInfo.Uid =
                        ComFn.SafeGetXmlNodeInnerText(n, "Uid");
                    dbInfo.Password =
                        ComFn.SafeGetXmlNodeInnerText(n, "Password");
                    dbInfo.Port =
                        ComFn.SafeGetXmlNodeInnerText(n, "Port");

                    dbInfo.DBName =
                        ComFn.SafeGetXmlNodeInnerText(n, "DBName");
                    dbInfo.SqlPath =
                        ComFn.SafeGetXmlNodeInnerText(n, "SqlPath");
                    dbInfoList.Add(dbInfo);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AddNewNode(MdlDBInfo dbConn, ref string errMsg)
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(_xmlPath);
                XmlNode rootNode =
                    doc.SelectSingleNode("Root");
                dbConn.Id = Guid.NewGuid().ToString();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //sb.Append(" <DBInfo>");
                sb.AppendLine("");
                sb.AppendLine("     <Id>" + ComFn.GetSafeXml(dbConn.Id) + "</Id>");
                sb.AppendLine("     <ConnName>" + ComFn.GetSafeXml(dbConn.ConnName) + "</ConnName>");
                sb.AppendLine("     <Service>" + ComFn.GetSafeXml(dbConn.Service) + "</Service>");
                sb.AppendLine("     <Uid>" + ComFn.GetSafeXml(dbConn.Uid) + "</Uid>");
                sb.AppendLine("     <Password>" + ComFn.GetSafeXml(dbConn.Password) + "</Password>");
                sb.AppendLine("     <Port>" + ComFn.GetSafeXml(dbConn.Port) + "</Port>");

                sb.AppendLine("     <DBName>" + ComFn.GetSafeXml(dbConn.DBName) + "</DBName>");
                sb.AppendLine("     <SqlPath>" + ComFn.GetSafeXml(dbConn.SqlPath) + "</SqlPath>");
                //sb.Append(" </DBInfo>");
                XmlElement elem = doc.CreateElement("DBInfo");
                elem.InnerXml = sb.ToString();
                rootNode.AppendChild(elem);
                doc.Save(_xmlPath);
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }
        public bool EditFormInfoNode(MdlDBInfo dbConn,ref string errMsg)
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(_xmlPath);
               

                XmlNode node =
                doc.SelectSingleNode("Root/FormInfo");

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //sb.Append(" <DBInfo>");
                sb.AppendLine("");
                sb.AppendLine("     <Id>" + ComFn.GetSafeXml(dbConn.Id) + "</Id>");
                sb.AppendLine("     <ConnName>" + ComFn.GetSafeXml(dbConn.ConnName) + "</ConnName>");
                sb.AppendLine("     <Service>" + ComFn.GetSafeXml(dbConn.Service) + "</Service>");
                sb.AppendLine("     <Uid>" + ComFn.GetSafeXml(dbConn.Uid) + "</Uid>");
                sb.AppendLine("     <Password>" + ComFn.GetSafeXml(dbConn.Password) + "</Password>");
                sb.AppendLine("     <Port>" + ComFn.GetSafeXml(dbConn.Port) + "</Port>");

                sb.AppendLine("     <DBName>" + ComFn.GetSafeXml(dbConn.DBName) + "</DBName>");
                sb.AppendLine("     <SqlPath>" + ComFn.GetSafeXml(dbConn.SqlPath) + "</SqlPath>");

                if (node == null)
                {
                    XmlNode rootNode =
                        doc.SelectSingleNode("Root");
                    //sb.Append(" </DBInfo>");
                    XmlElement elem = doc.CreateElement("FormInfo");
                    elem.InnerXml = sb.ToString();
                    rootNode.AppendChild(elem);
                }
                else
                {
                    node.InnerXml = sb.ToString();
                }
                doc.Save(_xmlPath);
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }
        #endregion

        #region private
        public bool XmlInit(ref string errMsg)
        {
            try
            {
                _xmlPath =
                WinAppFn.GetSettingFolder() + _xmlName;
                if (!File.Exists(_xmlPath))
                {
                    XmlDocument doc = new XmlDocument();
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                    sb.Append("<Root>");
                    sb.Append("</Root>");
                    doc.InnerXml = sb.ToString();
                    doc.Save(_xmlPath);
                }
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        #endregion
    }
}
