//using System;
//using System.Collections.Generic;
//using System.Text;
//using ComLib.db;
//using ComLib.db.BaseModule;
//using YRKJ.MWR;

//namespace ComLib.db
//{

//    public class SqlJoin : SqlQueryBase
//    {
//        private List<string> buildColumnsList = new List<string>();
//        public void Add<T>(SqlJoinOn<T> joinOn) where T : BaseDataModule, new()
//        {
//            buildSqlList.Add(joinOn.getSql());
//            buildColumnsList.Add(joinOn.getColumnsSql());
//        }

//        public string GetSql()
//        {
//            return "";
//        }
//    }
//    public class SqlJoinOn<T> : SqlQueryBase where T : BaseDataModule, new()
//    {
//        T _t = null;
//        public SqlJoinOn()
//        {
//            _t = new T();
//            _t.GetTableName();
//            _t.GetColumns();
//        }

//        public SqlJoinOnWhere AddCompare(DataColumnInfo mainColumn)
//        {
//            _joinOnWhere.SetCompareColumn(mainColumn);
//            return _joinOnWhere;
//        }

//        SqlJoinOnWhere _joinOnWhere = new SqlJoinOnWhere();
//        public class SqlJoinOnWhere : SqlQueryBase
//        {
//            private SqlCommonFn.SqlWhereLinkType _linkType = SqlCommonFn.SqlWhereLinkType.AND;
//            private DataColumnInfo _mainColumn = null;
//            public SqlJoinOnWhere()
//            {
//            }
//            public void SetCompareColumn(DataColumnInfo mainCloumn)
//            {
//                _mainColumn = mainCloumn;
//            }
//            public void On(SqlCommonFn.SqlWhereCompareEnum compareType, DataColumnInfo column)
//            {
//                buildSqlList.Add(""
//                   + SqlCommonFn.FormatSqlTableNameString("{0}") + "." + SqlCommonFn.FormatSqlColumnNameString(_mainColumn.ColumnName)
//                   + SqlCommonFn.FormatSqlCompareEnumString(compareType)
//                   + SqlCommonFn.FormatSqlTableNameString("{1}") + "." + SqlCommonFn.FormatSqlColumnNameString(column.ColumnName));
//            }
//            public string GetSql()
//            {
//                bool hasBeanAppend = false;
//                StringBuilder sb = new StringBuilder();
//                foreach (string s in buildSqlList)
//                {

//                    if (hasBeanAppend)
//                    {
//                        sb.Append(_linkType == SqlCommonFn.SqlWhereLinkType.AND ? " AND " : " OR ");

//                    }
//                    sb.Append(s);
//                    hasBeanAppend = true;

//                }
//                return sb.ToString();
//            }
//        }

//        public string getSql()
//        {
//            //LEFT JOIN `mwcardispatch` ON `mwcar`.CarCode = `mwcardispatch`.CarCode 
//            //LEFT JOIN `mwcardispatch` ON `mwcar`.CarCode = `mwcardispatch`.CarCode 
//            string joinTableName = _t.GetTableName();
//            StringBuilder sb = new StringBuilder();
          
//            sb.AppendLine("LEFT JOIN " +
//                joinTableName + " AS " + SqlCommonFn.FormatSqlTableNameString("{0}"));
//            sb.AppendLine("ON ");
//            {
//                sb.AppendLine(_joinOnWhere.GetSql());
//            }
//            return sb.ToString();
//        }
//        public string getColumnsSql()
//        {
//            StringBuilder sb = new StringBuilder();
//            foreach (DataColumnInfo col in _t.GetColumns())
//            {
//                sb.Append(SqlCommonFn.FormatSqlTableNameString("{0}")
//                    + "."
//                    + SqlCommonFn.FormatSqlColumnNameString(col.ColumnName) + ",");
//            }
//            return sb.ToString().TrimEnd(',');
//        }

//    }
//    public class Demo
//    {

//        public static void foo()
//        { 
//            /*
//             SELECT * FROM `mwcar` 
//            LEFT JOIN `mwcardispatch` ON `mwcar`.CarCode = `mwcardispatch`.CarCode 
//            LEFT JOIN `mwtxnrecoverheader` ON `mwtxnrecoverheader`.CarCode = `mwcar`.CarCode
//            WHERE `mwcardispatch`.cardisid = 1
             
//             */
//            //SqlJoinOn<TblMWCar> sjm = new SqlJoinOn<TblMWCar>();
//            //sjm.AddCompare(TblMWCar.getCarCodeColumn())
//            //    .On(SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWCarDispatch.getCarCodeColumn());

//            //SqlQueryMng sqm = new SqlQueryMng();
//            ////sqm.Condition.LeftJoin.Add(sjm);
//            //sqm.Condition.LeftJoin.Add(sjm);

//            //DataCtrlInfo dcf = new DataCtrlInfo();

//            //string errMsg = "";
//            //List<TblMWCar> dlist = null;
//            //TblMWCarCtrl.QueryMoreJoin(dcf, sqm, sjm, ref dlist, ref errMsg);

//            //SqlJoinOnMng<TblSysNextId> Join = new SqlJoinOnMng<TblSysNextId>();
//            //Join.AddCompare(TblSysNextId.getIdNameColumn())
//            //    .On(SqlCommonFn.SqlWhereCompareEnum.Equals, TblSysNextId.getIdNameColumn());
//            //Join.AddCompare(TblSysNextId.getIdValueColumn())
//            //    .On(SqlCommonFn.SqlWhereCompareEnum.Equals, TblSysNextId.getIdValueColumn());

//            //string s1 = Join.getColumns("jTab");
//            //string s2 = Join.getSql("mTab","jTab");

//        }

       

//    }
//}
