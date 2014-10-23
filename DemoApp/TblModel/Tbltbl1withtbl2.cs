using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace DemoApp.TblModel
{

    public class Tbltbl1withtbl2 : BaseDataModule
    {
         public static string getSql(){
             string[] sqlAry = new string[]{
                "SELECT tbl_1.str1 AS t1str1,tbl_2.str1 AS t2str2 FROM tbl_1",
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
             new DataColumnInfo(false,true,false,false,"t1str1",SqlCommonFn.DataColumnType.STRING,20),
             new DataColumnInfo(false,true,false,false,"t2str2",SqlCommonFn.DataColumnType.STRING,20)
         };

         public static DataColumnInfo getT1str1Column(){
             return Columns[0];
         }
         public static DataColumnInfo getT2str2Column(){
             return Columns[1];
         }

         public string t1str1 = "";
         public string t2str2 = "";

         public string getT1str1() {
             return  t1str1;
         }
         public void setT1str1(string t1str1) {
             this.t1str1 = t1str1;
         }
         public string getT2str2() {
             return  t2str2;
         }
         public void setT2str2(string t2str2) {
             this.t2str2 = t2str2;
         }


         public const string T1STR1_ENUM_PER = "2";//个人用户;
         public const string T1STR1_ENUM_BUS = "1";//企业用户;
     }
}
