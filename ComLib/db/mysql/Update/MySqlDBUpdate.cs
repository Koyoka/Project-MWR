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
        protected DoUpdateHelper _helper = new DoUpdateHelper();
        protected DoUpdateDBMng _mng = null;

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

            string newDBSql = "";
            _helper.DoStep = DoUpdateHelper.EnumDoStep.Strat;

            #region get db resounse
            _helper.OldDBName = dbName;
            _helper.DBConnStr = SqlDBMng.GetConnStr(dbSource, dbUser, dbPassword, dbPort);
            _mng = new DoUpdateDBMng(_helper.DBConnStr, dbName);

            #region print db information
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(dbName+"@"+dbSource);
                sb.AppendLine("uid:"+dbUser);
                sb.AppendLine("password:"+dbPassword);
                sb.AppendLine("port:"+dbPort);
                sb.AppendLine("sql:" + newDBSqlPath);
                _helper.PrintOutput(sb.ToString());
            }
            #endregion
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
            List<TableDDLHelper> modTableList = null;
            if (!CompareOldDBTableToNewDBAndCreateDDLSql(ref modTableList, ref errMsg))
            {
                return false;
            }
            #endregion

            #region step 3. del templete db
            if (!_mng.DropDB(_helper.TempDBName, ref errMsg))
            {
                return false;
            }
            _helper.PrintOutput("临时表删除完成");
            #endregion

            #region  step 4. backup old db data

            #endregion

            #region step 5. do DDL
            if (!ExDBUpdate(modTableList, ref errMsg))
            {
                return false;
            }
            #endregion


            _helper.PrintOutput("数据库更新完毕");
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
                //_helper.PrintDebugOutput(newDBSql);
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
            DateTime beginTime = DateTime.Now;
            #region convent dbsql to Temp DBSql
            string newTempDBSql = newDBSql;

            string tempDBName = oldDBName + "_" + Guid.NewGuid().ToString();
            _helper.TempDBName = tempDBName;
            {
                //string pattern = "NOT EXISTS `" + oldDBName.ToUpper() + "`";
                string pattern = "NOT EXISTS `[a-zA-Z0-9]+`";
                string replaceStr = "NOT EXISTS `" + tempDBName + "`";
                Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
                newTempDBSql = reg.Replace(newTempDBSql, replaceStr);
            }

            //{
            //    //string pattern = "USE `" + oldDBName.ToUpper() + "`";
            //    string pattern = "USE `[a-zA-Z0-9]+`";
            //    Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
            //    string replaceStr = "USE `" + tempDBName + "`";
            //    newTempDBSql = reg.Replace(newTempDBSql, replaceStr);
            //}
            _helper.PrintDebugOutput(newTempDBSql);
            #endregion

            #region do create
            

            List<string> slist = new List<string>();
            string delimiteSql = "";
            _helper.GetSplitSqlFileToSqlStr(newTempDBSql, ref slist, ref delimiteSql, ref errMsg);
          
            try
            {
                new SqlMySqlDBMng(_helper.DBConnStr).doSql(slist);

                _mng.ExeSqlDelimiteScript(delimiteSql);
                _helper.DoStep = DoUpdateHelper.EnumDoStep.CreateTempDBEnd;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
            #endregion
            TimeSpan ts = DateTime.Now - beginTime;
            _helper.PrintOutput("临时数据库创建完成 执行时间[" + ts.TotalSeconds.ToString("f2") + "秒]");
            return true;
        }

        protected bool CompareOldDBTableToNewDBAndCreateDDLSql(ref List<TableDDLHelper> modTableList, ref string errMsg)
        {
            _helper.PrintOutput("开始数据库结构分析...");
            DateTime beginTime = DateTime.Now;
            _helper.PrintOutput("-----------------");

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
                        _helper.PrintDebugOutput("fields -- " + item1.FieldName
                            + " " + item1.ColumnType
                            + " " + item1.DetaultValue 
                            + " " + item1.NullAble 
                            + " " + item1.IsPRIKey
                            + " " + item1.Extra
                            ,false);
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
                        _helper.PrintDebugOutput("fields -- " + item1.FieldName
                            + " " + item1.ColumnType
                            + " " + item1.DetaultValue
                            + " " + item1.NullAble
                            + " " + item1.IsPRIKey
                            + " " + item1.Extra
                            , false);
                    }
                }
            }
            #endregion

            #region data ddl analysis
            //StringBuilder sb = new StringBuilder();
            modTableList = new List<TableDDLHelper>();
            foreach (var tempTab in tempDBTabList)
            {
                UpTableInfo oldTab = null;
                int tableIndex = 0;
                #region search same item
                for (int i = 0; i < oldDBTabList.Count; i++)
                {
                    tableIndex = i;
                    if (tempTab.TableName.Equals(oldDBTabList[i].TableName))
                    {
                        oldTab = oldDBTabList[i];
                        break;
                    }
                }
                #endregion

                if (oldTab == null)
                {
                    _helper.PrintOutput("创建新表 " + tempTab.TableName);
                    TableDDLHelper atHelper = new TableDDLHelper(_helper.OldDBName, tempTab,true);
                    modTableList.Add(atHelper);
                    //sb.AppendLine(atHelper.GetNewTableSql());
                    continue;
                }
                else
                {
                    TableDDLHelper atHelper = new TableDDLHelper(_helper.OldDBName, oldTab,false);

                    #region Check tempTab
                    foreach (var f in oldTab.TableFieldInfoList)
                    {
                        atHelper.CheckOldFieldInfo(f);
                    }

                    foreach (var f in tempTab.TableFieldInfoList)
                    {
                        atHelper.CheckNewFieldInfo(f);

                        #region compare old & new  field craete ddl
                        int fieldIndex = 0; 
                        UpTableFieldInfo oldFieldInfo = null;

                        #region search same field
                        for (int i = 0; i < oldTab.TableFieldInfoList.Count;i++ )
                        {
                            fieldIndex = i;
                            UpTableFieldInfo of = oldTab.TableFieldInfoList[i];
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
                            _helper.PrintOutput("添加表字段 " + tempTab.TableName+"."+f.FieldName);
                            atHelper.AddNewField(f);
                            #endregion
                            continue;
                        }
                        else
                        {
                            bool hasChange = true;
                            #region check change
                            if (f.ColumnType == oldFieldInfo.ColumnType
                                && f.IsPRIKey == oldFieldInfo.IsPRIKey
                                && f.NullAble == oldFieldInfo.NullAble
                                && f.DetaultValue == oldFieldInfo.DetaultValue
                                && f.Extra == oldFieldInfo.Extra)
                            {
                                hasChange = false;
                            }
                            if (hasChange)
                            {
                                _helper.PrintOutput("修改表字段 " + tempTab.TableName + "." + f.FieldName);
                                atHelper.ChangeField(f);
                                
                            }
                            #endregion

                            #region del old field in list
                            oldTab.TableFieldInfoList.RemoveAt(fieldIndex);
                            #endregion
                        }
                        #endregion

                    }
                    #endregion

                    string sql = atHelper.GetSql();
                    if (!string.IsNullOrEmpty(sql))
                    {
                        modTableList.Add(atHelper);
                        //sb.AppendLine(atHelper.GetModifyTableSql());
                    }
                    
                }

                #region del old table in list
                oldDBTabList.RemoveAt(tableIndex);
                #endregion
            }
            #endregion
            
            TimeSpan ts = DateTime.Now - beginTime;
            _helper.PrintOutput("-----------------");
            _helper.PrintOutput("数据库结构分析完成 执行时间[" + ts.TotalSeconds.ToString("f2") + "秒]");
            return true;
        }

        protected bool ExDBUpdate(List<TableDDLHelper> modTableList, ref string errMsg)
        {
            _helper.PrintOutput("开始数据库更新");
            _helper.PrintOutput("-----------------");
            DateTime beginTime = DateTime.Now;
            foreach (var item in modTableList)
            {
                _helper.PrintOutput(_helper.OldDBName + "." + item.GetUpTableInfo().TableName + " strat");
                _helper.PrintOutput(item.GetSql());
                if (!_mng.DoSql(item.GetSql(), ref errMsg))
                {
                    _helper.PrintOutput(_helper.OldDBName + "." + item.GetUpTableInfo().TableName + " error",Color.Red);
                    _helper.PrintOutput(errMsg, Color.Red);
                    return false;
                }
                else
                {
                    _helper.PrintOutput(_helper.OldDBName + "." + item.GetUpTableInfo().TableName + " done");
                }
                _helper.PrintOutput("");
                
            }
            TimeSpan ts = DateTime.Now - beginTime;
            _helper.PrintOutput("-----------------");
            _helper.PrintOutput("数据库更新完成 执行时间[" + ts.TotalSeconds.ToString("f2") + "秒]");
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
            public bool GetSplitSqlFileToSqlStr(string sqlFileStr, ref List<string> splitSql, ref string delimiteSql, ref string errMsg)
            {
                splitSql = new List<string>();
                //StringBuilder sb = new StringBuilder(sqlFileStr);

                string line = "";
                string l;

                //DELIMITER
                bool isDELIMITER = false;
                StringBuilder delimiteSqlSB = new StringBuilder();
               

                foreach (string s in sqlFileStr.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                {

                    if (!isDELIMITER && s.ToUpper().StartsWith("DELIMITER $$"))
                    {
                        isDELIMITER = true;
                    }

                    if (isDELIMITER)
                    {
                        #region
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
                        line += Environment.NewLine + l;
                        #endregion

                        if (!line.EndsWith("DELIMITER ;")) continue;
                        if (line.StartsWith("/*!")) continue;
                        delimiteSqlSB.AppendLine(line);
                        //delimiterList.Add(line);
                        //splitSql.Add(line);
                        isDELIMITER = false;
                    }
                    else if(!isDELIMITER)
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
                        if (l.StartsWith("CREATE SCHEMA IF NOT EXISTS")) continue;
                        if (l.StartsWith("USE")) continue;

                        // 行数加1   
                        line += Environment.NewLine + l;
                        // 如果不是完整的一条语句，则继续读取  
                        if (!line.EndsWith(";")) continue;
                        if (line.StartsWith("/*!"))
                        {
                            continue;
                        }

                        splitSql.Add(line);
                    }
                }
                #region Create DB Sql
                splitSql.Insert(0,"CREATE SCHEMA IF NOT EXISTS `" + TempDBName + "` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;");
                splitSql.Insert(1,"USE `" + TempDBName + "` ;");

                #endregion

                delimiteSql =  delimiteSqlSB.ToString();
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
                    message = "> <font color='" + htmlColor + "'>" + message + "</font>" + Environment.NewLine;
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
        public class TableDDLHelper
        {
            private const string SPACE = " ";
            private const string DT_INT = "INT";
            private const string DT_DECIMAL = "DECIMAL";
            private const string DT_BIGINT = "BIGINT";
            private const string DT_DOUBLE = "DOUBLE";
            private const string DT_FLOAT = "FLOAT";
            private const string DT_MEDIUMINT = "MEDIUMINT";
            private const string DT_SMALLINT = "SMALLINT";
            private const string DT_TINYINT = "TINYINT";
            private string[] DT_NUM_ARRAY = new string[] { 
                    DT_INT,
                    DT_DECIMAL,
                    DT_BIGINT,
                    DT_DOUBLE,
                    DT_FLOAT,
                    DT_MEDIUMINT,
                    DT_SMALLINT,
                    DT_TINYINT
                };

            private const string EX_AUTO_INCREMENT = "AUTO_INCREMENT";

            private string _cacheSql = null;
            private string _dbName = "";
            private string _tableName = "";
            private UpTableInfo _tabInfo = null;
            private List<string> _ddlSql = new List<string>();
            private bool _isNewTable = false;
            public UpTableInfo GetUpTableInfo()
            {
                return _tabInfo;
            }

            public TableDDLHelper(string dbName, UpTableInfo tabInfo,bool isNewTable)
            {

                _dbName = dbName;
                _tableName = tabInfo.TableName;
                _tabInfo = tabInfo;
                _isNewTable = isNewTable;
            }

            private string GetNewTableSql()
            {
                // CREATE TABLE `demodata`.`demotable_2` (
                //`id` INT NOT NULL,
                //PRIMARY KEY (`id`));

                string sql = "CREATE TABLE `{0}`.`{1}` ({2});";
                string fieldSql = "";

                StringBuilder sb = new StringBuilder();
                #region filed
                List<string> fieldSqlList = new List<string>();
                string pkf = "";

                foreach (var item in _tabInfo.TableFieldInfoList)
                {
                    if (item.IsPRIKey)
                    {
                        pkf += "`" + item.FieldName + "`,";
                    }
                    fieldSqlList.Add(GetNewTableColumnOptionsSql(item));
                }
                if (!string.IsNullOrEmpty(pkf))
                {
                    fieldSqlList.Add(string.Format("PRIMARY KEY ({0})", pkf.TrimEnd(',')));
                }

                sb.AppendLine();
                for (int i = 0; i < fieldSqlList.Count; i++)
                {
                    string end = "";
                    if (i == (fieldSqlList.Count - 1)) sb.Append(fieldSqlList[i]);
                    else sb.AppendLine(fieldSqlList[i] + ","); 
                }
                fieldSql = sb.ToString();
                #endregion

                sql = string.Format(sql, _dbName, _tableName, fieldSql);

                return sql.ToString().TrimEnd((char[])"\r\n".ToCharArray());
            }
            private string GetModifyTableSql()
            {
                string sql = "ALTER TABLE `{0}`.`{1}` ";
                sql = string.Format(sql, _dbName, _tableName);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(sql);

                SetPRIKeyChangeSql();

                for (int i = 0; i < _ddlSql.Count; i++)
                {
                    string end = "";
                    if (i == (_ddlSql.Count - 1)) end = ";";
                    else end = ",";
                    sb.AppendLine(_ddlSql[i] + end);
                }

                if (_ddlSql.Count == 0)
                {
                    return "";
                }

                return sb.ToString().TrimEnd((char[])"\r\n".ToCharArray());
            }
            public string GetSql()
            {
                if (!string.IsNullOrEmpty(_cacheSql))
                {
                    return _cacheSql;
                }
                if (_isNewTable)
                {
                    _cacheSql =  GetNewTableSql();
                }
                else {
                    _cacheSql =  GetModifyTableSql();
                }

                return _cacheSql;
            }
            //private string GetTableOptions()
            //{
            //    return "";
            //}
            //private string GetColumnDefinition()
            //{
            //    return "";
            //}

            #region Table new
            private string GetNewTableColumnOptionsSql(UpTableFieldInfo f)
            {
                string sql = "";
                sql += GetFieldName(f) + SPACE;
                // data type
                sql += GetFieldDataType(f) + SPACE;
                // Null able
                sql += GetFieldNullAble(f) + SPACE;
                // default value
                sql += GetFieldDefaultValue(f) + SPACE;
                // extra
                sql += GetFieldExtra(f) + SPACE;
                return sql;
            }
            
            #endregion

            #region Field change
            public void AddNewField(UpTableFieldInfo f)
            {
                string sql = "";// "ADD COLUMN `int1` INT NULL AUTO_INCREMENT ;";
                // ddl cmd
                sql += "ADD COLUMN" + SPACE;
                // field name
                sql += GetFieldName(f) + SPACE;
                // data type
                sql += GetFieldDataType(f) + SPACE;
                // Null able
                sql += GetFieldNullAble(f) + SPACE;
                // default value
                sql += GetFieldDefaultValue(f) + SPACE;
                // extra
                sql += GetFieldExtra(f) + SPACE;

                _ddlSql.Add(sql);
            }

            public void ChangeField(UpTableFieldInfo f)
            {
                //CHANGE COLUMN `ccc` `ccc` VARCHAR(10) NULL DEFAULT NULL ,
                string sql = "";
                // ddl cmd
                sql += "CHANGE COLUMN" + SPACE;
                // field name
                sql += GetFieldName(f) + SPACE + GetFieldName(f) + SPACE;
                // data type
                sql += GetFieldDataType(f) + SPACE;
                // Null able
                sql += GetFieldNullAble(f) + SPACE;
                // default value
                sql += GetFieldDefaultValue(f) + SPACE;
                // extra
                sql += GetFieldExtra(f) + SPACE;
                _ddlSql.Add(sql);
            }
            #endregion

            #region PRI Change
            private List<string> _newTablePKFList = new List<string>();
            private List<string> _oldTablePKFList = new List<string>();
            private string[] _newTablePKFClone = null;
            public void CheckNewFieldInfo(UpTableFieldInfo f)
            {
                if (f.IsPRIKey)
                {
                    _newTablePKFList.Add(f.FieldName);
                }
            }
            public void CheckOldFieldInfo(UpTableFieldInfo f)
            {
                if (f.IsPRIKey)
                {
                    _oldTablePKFList.Add(f.FieldName);
                }
            }
            private void SetPRIKeyChangeSql()
            {
                _newTablePKFClone = new string[_newTablePKFList.Count];
                _newTablePKFList.CopyTo(_newTablePKFClone);
                if (!CheckPKHasChange())
                {
                    return;
                }
               
                if (_newTablePKFClone.Length == 0) return;

                //DROP PRIMARY KEY,
                //ADD PRIMARY KEY (`Id`, `cccc`);
                _ddlSql.Add("DROP PRIMARY KEY");
                string fSql = "";
                foreach (var item in _newTablePKFClone)
                {
                    fSql += "`" + item + "`,";
                }
                fSql = fSql.TrimEnd(',');

                _ddlSql.Add("ADD PRIMARY KEY (" + fSql + ")");
            }
            private bool CheckPKHasChange()
            {
                if (_newTablePKFList.Count != _oldTablePKFList.Count)
                {
                    return true;
                }

                for (int i = 0; i < _newTablePKFList.Count; i++)
                {
                    string defineNF = _newTablePKFList[i];
                    if (_oldTablePKFList.Count == 0) break;

                    for (int j = 0; j < _oldTablePKFList.Count; j++)
                    {
                        string defineOF = _oldTablePKFList[j];
                        if (defineNF.ToUpper().Equals(defineOF.ToUpper()))
                        {
                            _newTablePKFList.RemoveAt(i);
                            _oldTablePKFList.RemoveAt(j);
                            i--;
                            j--;
                            break;
                        }
                    }
                }

                if (_newTablePKFList.Count != 0 && _oldTablePKFList.Count != 0)
                {
                    return true;
                }

                return false;
            }
            #endregion

            #region common unity
           
            private string GetFieldName(UpTableFieldInfo f)
            {
                return "`" + f.FieldName + "`";
            }
            private string GetFieldDataType(UpTableFieldInfo f)
            {
                return f.ColumnType;
            }
            private string GetFieldNullAble(UpTableFieldInfo f)
            {
                return f.NullAble ? "NULL" : "NOT NULL";
            }
            private string GetFieldDefaultValue(UpTableFieldInfo f)
            {
                
                if (f.NullAble)
                {
                    bool isText = CheckFieldTypeIsText(f);
                    string val = isText ? "'" + f.DetaultValue + "'" : f.DetaultValue;
                    return string.IsNullOrEmpty(f.DetaultValue) ? "DEFAULT NULL" : "DEFAULT " + val;
                }
                else
                {
                    return "";
                }
               
            }
            private string GetFieldExtra(UpTableFieldInfo f)
            {
                string extra = f.Extra;
                return extra;
            }

            private bool CheckFieldTypeIsText(UpTableFieldInfo f)
            {
                foreach (var item in DT_NUM_ARRAY)
                {
                    if (f.ColumnType.ToUpper().StartsWith(item))
                    {
                        return false;
                    }
                }
                return true;
            }
            #endregion
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
                        tfi.DetaultValue = row["Default"].ToString();
                        tfi.Extra = row["Extra"].ToString();
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
            public bool DoSql(string sql, ref string errMsg)
            {
                try
                {
                    new SqlMySqlDBMng(_connStr).update(sql);
                    return true;
                }
                catch (Exception ex)
                {
                    errMsg = ex.Message;
                    return false;
                }

            }
            public bool ExeSqlDelimiteScript( string sql)
            {
                string connStr = _connStr;
                MySql.Data.MySqlClient.MySqlConnection conn
                     = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                MySql.Data.MySqlClient.MySqlScript script =
                    //new MySql.Data.MySqlClient.MySqlScript(connection, File.ReadAllText("script.sql"));
                    //new MySql.Data.MySqlClient.MySqlScript(
                    //    conn 
                    //    , File.ReadAllText(sqlPath));
                    new MySql.Data.MySqlClient.MySqlScript(
                        conn
                        , sql);
                script.Delimiter = "$$";
                script.Execute();
                return true;
            }
            //public static string ExeCommand(string commandText)
            //{
            //    string strOutput = null;
            //    try
            //    {
            //        System.Diagnostics.Process p = new System.Diagnostics.Process();
            //        p.StartInfo.FileName = "cmd.exe";
            //        p.StartInfo.UseShellExecute = false;
            //        p.StartInfo.RedirectStandardInput = true;
            //        p.StartInfo.RedirectStandardOutput = true;
            //        p.StartInfo.RedirectStandardError = true;
            //        p.StartInfo.CreateNoWindow = true;
            //        p.EnableRaisingEvents = true;

            //        p.Exited += delegate
            //        {
            //            //this.btnNext.Enabled = true;
            //            //this.btnNext.Focus();
            //        };

            //        p.Start();
            //        p.StandardInput.WriteLine(commandText);
            //        p.StandardInput.WriteLine("初始化数据库执行完毕.");
            //        p.StandardInput.WriteLine("exit");
            //        strOutput = p.StandardOutput.ReadToEnd();
            //        p.WaitForExit();
            //        p.Close();
            //    }
            //    catch (Exception e)
            //    {
            //        strOutput = "初始化数据库出现错误." + Environment.NewLine + e.Message;
            //    }

            //    return strOutput;
            //}

            
        }
    }
}
