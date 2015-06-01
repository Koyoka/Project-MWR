using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db.dbUpdate;
using ComLib.db.BaseModule;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;

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
            _helper.DBConnStr = 
            SqlDBMng.GetConnStr(dbSource, dbUser, dbPassword, dbPort);

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

            #endregion

            #region step 3. create modify old table DDL

            #endregion

            #region  step 4. backup old db data

            #endregion

            #region step 5. do DDL

            #endregion

            #region step 6. del templete db

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
            return true;
        }
       
        public class DoUpdateHelper
        {
            public bool IsDebug = true;

            public enum EnumDoStep {Strat,CreateTempDBEnd }
            public EnumDoStep DoStep { get; set; }

            public string DBConnStr { get; set; }
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
                strat = TitleMatch.Index-1;
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
                    message = GetNow() + Environment.NewLine +  "<font color='" + htmlColor + "'>" + message + "</font>" + Environment.NewLine + Environment.NewLine;
                    Output(message);
                }
            }
            public void PrintDebugOutput(string message)
            {
                PrintDebugOutput(message,Color.Blue);
               
            }
            public void PrintDebugOutput(string message, Color color)
            {
                if (IsDebug && DebugOutput != null)
                {
                    string htmlColor = ColorTranslator.ToHtml(color);
                    //Environment.NewLine;
                    //Color.FromArgb
                    message = GetNow() + Environment.NewLine +  "<font color='" + htmlColor + "'>" + message + "</font>" + Environment.NewLine + Environment.NewLine;
                    DebugOutput(message);
                }
            }
            public string GetNow()
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
             
    }
}
