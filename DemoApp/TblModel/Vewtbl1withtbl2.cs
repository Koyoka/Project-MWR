using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace DemoApp.TblModel
{

    public class Vewtbl1withtbl2 : BaseDataModule
    {
         public static string getSql(){
             string[] sqlAry = new string[]{
                "SELECT tbl_1.id,tbl_1.str1 AS t1str1,tbl_2.str1 AS t2str2 FROM tbl_1",
                "LEFT JOIN tbl_2 ON tbl_1.id = tbl_2.id",
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
             new DataColumnInfo(true,false,true,false,"id",SqlCommonFn.DataColumnType.INT,10),
             new DataColumnInfo(false,true,false,false,"t1str1",SqlCommonFn.DataColumnType.STRING,20),
             new DataColumnInfo(false,true,false,false,"t2str2",SqlCommonFn.DataColumnType.STRING,20)
         };

         public static DataColumnInfo getIdColumn(){
             return Columns[0];
         }
         public static DataColumnInfo getT1str1Column(){
             return Columns[1];
         }
         public static DataColumnInfo getT2str2Column(){
             return Columns[2];
         }
        private int _id = 0;
        private string _t1str1 = "";
        private string _t2str2 = "";

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string t1str1
        {
            get
            {
                return _t1str1;
            }
            set
            {
                _t1str1 = value;
            }
        }
        public string t2str2
        {
            get
            {
                return _t2str2;
            }
            set
            {
                _t2str2 = value;
            }
        }


         public const string T1STR1_ENUM_PER = "2";//个人用户;
         public const string T1STR1_ENUM_BUS = "1";//企业用户;
     }
}
