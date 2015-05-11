using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class VewEmployFunctionGroupDetail : BaseDataModule
    {
         public static string getSql(){
             string[] sqlAry = new string[]{
                "SELECT `fgd`.*,`up`.`UserGroupId` FROM `mwfunctiongroupdetail` AS fgd",
                "LEFT JOIN `mwuserpermission` AS up ON fgd.`FuncGroupId` = up.`FuncGroupId`",
                ""
             };
             StringBuilder sb = new StringBuilder();
             foreach(string s in sqlAry){
                 sb.AppendLine(s);
                 
             }
             return sb.ToString();
         }

         public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
             new DataColumnInfo(true,false,false,false,"FuncGroupDtlId",SqlCommonFn.DataColumnType.INT,10),
             new DataColumnInfo(false,true,false,false,"FuncGroupId",SqlCommonFn.DataColumnType.INT,10),
             new DataColumnInfo(false,true,false,false,"FuncTag",SqlCommonFn.DataColumnType.STRING,45),
             new DataColumnInfo(false,true,false,false,"UserGroupId",SqlCommonFn.DataColumnType.INT,10)
         };

         public static DataColumnInfo getFuncGroupDtlIdColumn(){
             return Columns[0];
         }
         public static DataColumnInfo getFuncGroupIdColumn(){
             return Columns[1];
         }
         public static DataColumnInfo getFuncTagColumn(){
             return Columns[2];
         }
         public static DataColumnInfo getUserGroupIdColumn(){
             return Columns[3];
         }
        private int _FuncGroupDtlId = 0;
        private int _FuncGroupId = 0;
        private string _FuncTag = "";
        private int _UserGroupId = 0;

        public int FuncGroupDtlId
        {
            get
            {
                return _FuncGroupDtlId;
            }
            set
            {
                _FuncGroupDtlId = value;
            }
        }
        public int FuncGroupId
        {
            get
            {
                return _FuncGroupId;
            }
            set
            {
                _FuncGroupId = value;
            }
        }
        public string FuncTag
        {
            get
            {
                return _FuncTag;
            }
            set
            {
                _FuncTag = value;
            }
        }
        public int UserGroupId
        {
            get
            {
                return _UserGroupId;
            }
            set
            {
                _UserGroupId = value;
            }
        }

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("FuncGroupDtlId"))
                 SetValue(ref _FuncGroupDtlId, row["FuncGroupDtlId"]);
             if(dataCols.Contains("FuncGroupId"))
                 SetValue(ref _FuncGroupId, row["FuncGroupId"]);
             if(dataCols.Contains("FuncTag"))
                 SetValue(ref _FuncTag, row["FuncTag"]);
             if(dataCols.Contains("UserGroupId"))
                 SetValue(ref _UserGroupId, row["UserGroupId"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }

     }
}
