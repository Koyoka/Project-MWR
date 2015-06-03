using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db.dbUpdate;
using ComLib.db.BaseModule;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;

namespace ComLib.db.mysql.Update
{
    public class MySqlDBUpdate : IDBUpdate
    {
        public static MySqlDBUpdate GetInstance()
        {
            MySqlDBUpdate up = new MySqlDBUpdate();
            //up.Helper = new DoUpdateHelper();

            return up;
        }

        public static MySqlDBUpdate GetInstance(bool debug)
        {
            MySqlDBUpdate up = new MySqlDBUpdate();
            //up.Helper = new DoUpdateHelper();
            up._helper.IsDebug = debug;
           
            return up;
        }


        protected  DoUpdateHelper _helper = new DoUpdateHelper();
        protected DoUpdateDBMng _mng = null;

        public void SetPrint(DoUpdateHelper.DelegateOutput op,DoUpdateHelper.DelegateDebugOutput dop)
        {
            _helper.DebugOutput = dop;
            _helper.Output = op;

        }

        public bool DoUpdate(string dbName,
            string dbSource,string dbUser,string dbPassword,string  dbPort,
            string newDBSqlPath,
            ref string errMsg)
        {
            
            List<UpTableInfo> tabList = null;
            string newDBSql = "";
            _helper.DoStep = DoUpdateHelper.EnumDoStep.Strat;

            #region get db resounse
            _helper.OldDBName = dbName;
            _helper.DBConnStr = SqlDBMng.GetConnStr(dbSource, dbUser, dbPassword, dbPort);
            _mng = new DoUpdateDBMng(_helper.DBConnStr, dbName);

            if (!ReadNewVerSql(newDBSqlPath, ref newDBSql, ref errMsg))
            {
                return false;
            }
            #endregion

            #region step 1. create Temp  new verstion db
            
            if (!CreateNewVerstionTempDB(newDBSql, dbName, ref errMsg))
            {
                return false;
            }
            #endregion

            #region step 2. compare db tables diff
            if (!CompareOldDBTableToNewDB(ref errMsg))
            {
                return false;
            }
            #endregion

            #region step 3. create modify old table DDL

            #endregion

            #region  step 4. backup old db data

            #endregion

            #region step 5. do DDL

            #endregion

            #region step 6. del templete db
            if (!_mng.DropDB(_helper.TempDBName, ref errMsg))
            {
                return false;
            }
            #endregion

            return true;
        }

        protected bool ReadNewVerSql(string path,ref string newDBSql, ref string errMsg)
        {
            _helper.PrintOutput("开始读取本地SQL文件");
            if (!File.Exists(path))
            {
                errMsg = "the path unexist sql file!";
                return false;
            }

            try
            {
                StringBuilder sb = new StringBuilder();
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    StreamReader sr = new StreamReader(fs);

                    string readLine = sr.ReadLine();
                    while (readLine != null)
                    {
                        sb.AppendLine(readLine);
                        readLine = sr.ReadLine();
                    }
                    sr.Close();
                    fs.Close();
                }
                newDBSql = sb.ToString();
                _helper.PrintDebugOutput(newDBSql);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }

            _helper.PrintOutput("Sql文件读取成功");
            return true;
        }

        protected bool CreateNewVerstionTempDB(string newDBSql,string oldDBName,ref string errMsg)
        {
            _helper.PrintOutput("开始创建临时数据库");

            #region convent dbsql to Temp DBSql
            string newTempDBSql = newDBSql;

            string tempDBName = oldDBName + "_" + Guid.NewGuid().ToString();
            _helper.TempDBName = tempDBName;
            {
                string pattern = "NOT EXISTS `" + oldDBName.ToUpper() + "`";
                string replaceStr = "NOT EXISTS `" + tempDBName + "`";
                Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
                newTempDBSql = reg.Replace(newTempDBSql, replaceStr);
            }

            {
                string pattern = "USE `" + oldDBName.ToUpper() + "`";
                Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
                string replaceStr = "USE `" + tempDBName + "`";
                newTempDBSql = reg.Replace(newTempDBSql, replaceStr);
            }
            _helper.PrintDebugOutput(newTempDBSql);
            #endregion

            #region do create
            List<string> slist = new List<string>();
            _helper.GetSplitSqlFileToSqlStr(newTempDBSql, ref slist, ref errMsg);

            try
            {
                new SqlMySqlDBMng(_helper.DBConnStr).doSql(slist);
                _helper.DoStep = DoUpdateHelper.EnumDoStep.CreateTempDBEnd;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
            #endregion

            _helper.PrintOutput("临时数据库创建完成");
            return true;
        }

        protected bool CompareOldDBTableToNewDB(ref string errMsg)
        {
            _helper.PrintOutput("开始数据库结构分析...");

            #region Old DB Table information
            List<UpTableInfo> oldDBTabList = null;
            if (!_mng.GetTables(_helper.OldDBName, ref oldDBTabList, ref errMsg))
            {
                return false;
            }
            #endregion

            #region New Temp DB Table information
            List<UpTableInfo> tempDBTabList = null;
            if (!_mng.GetTables(_helper.TempDBName, ref tempDBTabList, ref errMsg))
            {
                return false;
            }
            #endregion

            #region Get tables feilds information
            foreach (var item in oldDBTabList)
            {
                _helper.PrintDebugOutput("old db table -- " + item.TableName);
                List<UpTableFieldInfo> defineList = null;
                if (!_mng.GetColumns(_helper.OldDBName, item.TableName, ref defineList, ref errMsg))
                {
                    
                    return false;
                }
                item.TableFieldInfoList = defineList;

                if (_helper.IsDebug)
                {
                    foreach (var item1 in item.TableFieldInfoList)
                    {
                        _helper.PrintDebugOutput("fields -- " + item1.FieldName,false);
                    }
                }
                
                
            }
            foreach (var item in tempDBTabList)
            {
                _helper.PrintDebugOutput("temp db table -- " + item.TableName);
                List<UpTableFieldInfo> defineList = null;
                if (!_mng.GetColumns(_helper.TempDBName, item.TableName, ref defineList, ref errMsg))
                {
                    return false;
                }
                item.TableFieldInfoList = defineList;
                if (_helper.IsDebug)
                {
                    foreach (var item1 in item.TableFieldInfoList)
                    {
                        _helper.PrintDebugOutput("fields -- " + item1.FieldName,false);
                    }
                }
            }
            #endregion

            #region data analysis
            StringBuilder sb = new StringBuilder();
            foreach (var item in tempDBTabList)
            {
                UpTableInfo oldTabInfo = null;
                int tableIndex = 0;
                #region search same item
                for (int i = 0; i < oldDBTabList.Count; i++)
                {
                    tableIndex = i;
                    if (item.TableName.Equals(oldDBTabList[i].TableName))
                    {
                        oldTabInfo = oldDBTabList[i];
                        break;
                    }
                }
                #endregion

                if (oldTabInfo == null)
                {
                    #region add new table

                    #endregion
                    continue;
                }
                else
                {
                    #region Compare field
                    foreach (var f in item.TableFieldInfoList)
                    {
                        
                        int fieldIndex = 0; 

                        UpTableFieldInfo oldFieldInfo = null;
                        #region search same field
                        for (int i = 0; i < oldTabInfo.TableFieldInfoList.Count;i++ )
                        {
                            fieldIndex = i;
                            UpTableFieldInfo of = oldTabInfo.TableFieldInfoList[i];
                            if (of.FieldName.Equals(f.FieldName))
                            {
                                oldFieldInfo = of;
                                break;
                            }

                        }
                        #endregion

                        if (oldFieldInfo == null)
                        {
                            #region new field
                            sb.AppendLine(DDLHelper.NewField(f));
                            #endregion
                            continue;
                        }
                        else
                        {
                            bool hasChange = true;
                            #region check change
                            if (f.ColumnType == oldFieldInfo.ColumnType
                                && f.IsPRIKey == oldFieldInfo.IsPRIKey
                                && f.NullAble == oldFieldInfo.NullAble)
                            {
                                hasChange = false;
                            }
                            if (hasChange)
                            {
                                //#region check PRI

                                //#endregion

                                #region check field change

                                #endregion
                            }
                            #endregion

                            #region del old field in list
                            oldTabInfo.TableFieldInfoList.RemoveAt(fieldIndex);
                            #endregion
                        }

                    }

                    #endregion
                }

                #region del old table in list
                oldDBTabList.RemoveAt(tableIndex);
                #endregion
            }

            #endregion

            return true;
        }
       
        public class DoUpdateHelper
        {
            public bool IsDebug = true;

            public enum EnumDoStep {Strat,CreateTempDBEnd }
            public EnumDoStep DoStep { get; set; }

            public string DBConnStr { get; set; }
            public string OldDBName { get; set; }
            public string TempDBName { get; set; }
            
            public delegate void DelegateDebugOutput(string message);
            public delegate void DelegateOutput(string message);
            public DelegateDebugOutput DebugOutput { get; set; }
            public DelegateOutput Output { get; set; }

            public static string GetColorOutput(string s, ref int strat,ref  int length,ref Color c)
            {
                string ss =  GetTitleContent(s,"font",ref strat,ref length);
                string color = GetTitleContent(s, "font","color");
                //c =  Color.FromName(color);
                c = ColorTranslator.FromHtml(color);
                return ss;
                //string pattern = @">.[^<>]+<";
                //Regex reg = new Regex(pattern);
                //string colorStr = reg.Match(s).Value;
                //return colorStr;
            }
            private static string GetTitleContent(string str, string title,ref int strat,ref int length)
            {
                string tmpStr = string.Format("<{0}[^>]*?>(?<Text>[^<]*)</{1}>", title, title); //获取<title>之间内容  

                Match TitleMatch = Regex.Match(str, tmpStr, RegexOptions.IgnoreCase);

                string result = TitleMatch.Groups["Text"].Value;

                string s = Regex.Replace(str, tmpStr, result);
                strat = TitleMatch.Index;// -1;
                length = TitleMatch.Length;
                return s;

                return result;
            }
            private static string GetTitleContent(string str, string title, string attrib)
            {

                string tmpStr = string.Format("<{0}[^>]*?{1}=(['\"\"]?)(?<url>[^'\"\"\\s>]+)\\1[^>]*>", title, attrib); //获取<title>之间内容  

                Match TitleMatch = Regex.Match(str, tmpStr, RegexOptions.IgnoreCase);

                string result = TitleMatch.Groups["url"].Value;
                return result;
            }
            public bool GetSplitSqlFileToSqlStr(string sqlFileStr, ref List<string> splitSql, ref string errMsg)
            {
                splitSql = new List<string>();
                StringBuilder sb = new StringBuilder(sqlFileStr);

                string line = "";
                string l;  
                foreach (string s in sqlFileStr.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (line.EndsWith(";"))
                        line = "";

                    l = s;// reader.ReadLine();

                    // 如果到了最后一行，则退出循环  
                    if (l == null) break;
                    // 去除空格  
                    l = l.TrimEnd();
                    // 如果是空行，则跳出循环  
                    if (l == "") continue;
                    // 如果是注释，则跳出循环  
                    if (l.StartsWith("--")) continue;

                    if (l.StartsWith("SET")) continue;

                    // 行数加1   
                    line += l;
                    // 如果不是完整的一条语句，则继续读取  
                    if (!line.EndsWith(";")) continue;
                    if (line.StartsWith("/*!"))
                    {
                        continue;
                    }
                    splitSql.Add(line);
                }
                
                return true;
            }

            public void PrintOutput(string message)
            {
                PrintOutput(message, Color.Green);
            }
            public void PrintOutput(string message,Color color)
            {
                if (Output != null)
                {
                    //Color.FromArgb
                    string htmlColor = ColorTranslator.ToHtml(color);
                    //GetNow() + Environment.NewLine +  
                    message = "<font color='" + htmlColor + "'>" + message + "</font>" + Environment.NewLine + Environment.NewLine;
                    Output(message);
                }
            }
            public void PrintDebugOutput(string message)
            {
                PrintDebugOutput(message,Color.Blue,true);
               
            }
            public void PrintDebugOutput(string message,bool newLine)
            {
                PrintDebugOutput(message, Color.Blue, newLine);

            }
            public void PrintDebugOutput(string message, Color color,bool newLine)
            {
                if (IsDebug && DebugOutput != null)
                {
                    string htmlColor = ColorTranslator.ToHtml(color);
                    //Environment.NewLine;
                    //Color.FromArgb
                    //GetNow() + Environment.NewLine + 
                    message = (newLine ? Environment.NewLine : "") + Environment.NewLine + "<font color='" + htmlColor + "'>" + message + "</font>";
                    DebugOutput(message);
                }
            }
            public string GetNow()
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        public class DDLHelper
        {
            public static string NewField(UpTableFieldInfo f)
            {
                //ALTER TABLE `demodata`.`demotable_1` 
                //ADD COLUMN `ColStr1` VARCHAR(45) NULL AFTER `ColDecimal`;
                string sql = "ADD COLUMN `{0}` {1} NULL;";
                sql = string.Format(sql, f.FieldName, f.ColumnType);
                return sql;
            }
        }
        
        public class DoUpdateDBMng
        {
            private string _connStr = "";
            public DoUpdateDBMng(string connStr,string dbName)
            {
                _connStr = connStr;
            }

            public bool GetTables(string dbName,ref List<UpTableInfo> tabList,ref string errMsg)
            {
                try
                {
                    string sql = "SELECT `TABLE_NAME` FROM `INFORMATION_SCHEMA`.`TABLES` WHERE TABLE_SCHEMA='" + dbName + "' ;";
                    DataSet ds =
                        new SqlMySqlDBMng(_connStr).query(sql);

                    //ds.Tables[0].Rows[0
                    List<UpTableInfo> tbiList = new List<UpTableInfo>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        UpTableInfo tbi = new UpTableInfo();
                        tbi.TableName = row["TABLE_NAME"].ToString();
                        tbiList.Add(tbi);
                    }
                    tabList = tbiList;
                    return true;
                }
                catch (Exception ex)
                {
                    errMsg = ex.Message;
                    return false;
                }
            }
            public bool GetColumns(string dbName,string tableName,ref List<UpTableFieldInfo> tabFieldInfoList,ref string errMsg)
            {
                try
                {
                    string sql = "desc `" + dbName + "`.`" + tableName + "`;";
                    DataSet ds =
                           new SqlMySqlDBMng(_connStr).query(sql);

                    List<UpTableFieldInfo> tfiList = new List<UpTableFieldInfo>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        UpTableFieldInfo tfi = new UpTableFieldInfo();
                        tfi.FieldName = row["field"].ToString();
                        tfi.ColumnType = row["type"].ToString();
                        tfi.NullAble = row["Null"].ToString() == "YES" ? true : false;
                        tfi.IsPRIKey = row["Key"].ToString() == "PRI" ? true : false;
                        tfiList.Add(tfi);
                    }
                    tabFieldInfoList = tfiList;
                    return true;
                }
                catch (Exception ex)
                {
                    errMsg = ex.Message;
                    return false;
                }
            }
            public bool DropDB(string dbName,ref string errMsg)
            {
                try
                {

                    string sql = "drop database `" + dbName + "`";

                    new SqlMySqlDBMng(_connStr).update(sql);

                    return true;
                }
                catch (Exception ex)
                {
                    errMsg = ex.Message;
                    return false;
                }
            }
        }
    }
}
