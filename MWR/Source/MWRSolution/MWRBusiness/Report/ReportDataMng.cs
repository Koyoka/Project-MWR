using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR.Business.Report
{
    public class ReportDataMng
    {
        public const string ClassName = "YRKJ.MWR.Business.Report.ReportDataMng";

        #region Inventory
        public static bool GetInventoryGroupByVendorAndWasteReportData(ref List<TblMWInventory> invDataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.QueryColumn.AddSum(TblMWInventory.getRecoWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getInvWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getDestWeightColumn());
            sqm.QueryColumn.Add(TblMWInventory.getVendorColumn());
            sqm.QueryColumn.Add(TblMWInventory.getVendorCodeColumn());
            sqm.QueryColumn.Add(TblMWInventory.getWasteColumn());
            sqm.QueryColumn.Add(TblMWInventory.getWasteCodeColumn());

            sqm.Condition.GroupBy.Add(TblMWInventory.getVendorCodeColumn());
            sqm.Condition.GroupBy.Add(TblMWInventory.getWasteCodeColumn());
            if (!TblMWInventoryCtrl.QueryMore(dcf, sqm, ref invDataList, ref errMsg))
            {
                return false;
            }

            return true;
        }

        public static bool GetInventoryWeightReportData(ref TblMWInventory inv, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.QueryColumn.AddSum(TblMWInventory.getRecoWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getInvWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getDestWeightColumn());
           
            if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool GetInventoryVendorWeightReportData(string vendorCode,ref TblMWInventory inv, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.QueryColumn.AddSum(TblMWInventory.getRecoWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getInvWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getDestWeightColumn());
            sqm.Condition.Where.AddCompareValue(TblMWInventory.getVendorCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, vendorCode);
            if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool GetInventoryWasteWeightReportData(string wasteCode, ref TblMWInventory inv, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.QueryColumn.AddSum(TblMWInventory.getRecoWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getInvWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getDestWeightColumn());
            sqm.Condition.Where.AddCompareValue(TblMWInventory.getWasteCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wasteCode);
            if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool GetInventoryByVendor(string vendorCode, int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWInventory> invDataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWInventory.getVendorCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, vendorCode);
            sqm.Condition.OrderBy.Add(TblMWInventory.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.DESC);
            if (!TblMWInventoryCtrl.QueryPage(dcf, sqm, page, pageSize, ref invDataList, ref errMsg))
            {
                return false;
            }
            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }

        public static bool GetInventoryByWaste(string wasteCode, int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWInventory> invDataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWInventory.getWasteCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wasteCode);
            sqm.Condition.OrderBy.Add(TblMWInventory.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.DESC);
            if (!TblMWInventoryCtrl.QueryPage(dcf, sqm, page, pageSize, ref invDataList, ref errMsg))
            {
                return false;
            }
            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }
        
        
        #endregion

        #region InventoryTrack
        public static bool GetInventoryTrack(int invRecordId,ref List<TblMWInventoryTrack> dataList,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWInventoryTrack.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invRecordId);
            sqm.Condition.OrderBy.Add(TblMWInventoryTrack.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.ASC);
            if (!TblMWInventoryTrackCtrl.QueryMore(dcf, sqm, ref dataList, ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool GetDestroyInventoryTrack(string filter,int page,int pageSize,ref long pageCount,ref long rowCount,ref List<TblMWInventoryTrack> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWInventoryTrack.getTxnTypeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWInventoryTrack.TXNTYPE_ENUM_Destroy);
            if (!string.IsNullOrEmpty(filter.Trim()))
            {
                SqlWhere sw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
                string[] filterGroup = filter.Trim().Split(' ');
                foreach (var f in filterGroup)
                {
                    string defineF = f.Trim();
                    if (defineF == "")
                    {
                        continue;
                    }

                    if (defineF.Length >= 2)
                    {
                        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^(>|=|<)\d+(\.\d+)?$");
                        if(reg.IsMatch(defineF))
                        {
                            SqlWhere subSw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
                            string preFix = defineF.Substring(0, 1);
                            decimal value = ComLib.ComFn.StringToDecimal(defineF.Substring(1, defineF.Length - 1));
                            if (preFix.Equals("="))
                            {
                                subSw.AddCompareValue(TblMWInventoryTrack.getSubWeightColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, value);
                                subSw.AddCompareValue(TblMWInventoryTrack.getTxnWeightColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, value);
                            }
                            else if (preFix.Equals(">"))
                            {
                                subSw.AddCompareValue(TblMWInventoryTrack.getSubWeightColumn(), SqlCommonFn.SqlWhereCompareEnum.MoreEquals, value);
                                subSw.AddCompareValue(TblMWInventoryTrack.getTxnWeightColumn(), SqlCommonFn.SqlWhereCompareEnum.MoreEquals, value);
                            }
                            else if (preFix.Equals("<"))
                            {
                                subSw.AddCompareValue(TblMWInventoryTrack.getSubWeightColumn(), SqlCommonFn.SqlWhereCompareEnum.LessEquals, value);
                                subSw.AddCompareValue(TblMWInventoryTrack.getTxnWeightColumn(), SqlCommonFn.SqlWhereCompareEnum.LessEquals, value);
                            }
                            sqm.Condition.Where.AddWhere(subSw);

                            continue;
                        }
                    }
                    sw.AddLikeValue(TblMWInventoryTrack.getTxnNumColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWInventoryTrack.getCrateCodeColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWInventoryTrack.getDepotCodeColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWInventoryTrack.getVendorColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWInventoryTrack.getWasteColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWInventoryTrack.getEmpyNameColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWInventoryTrack.getWSCodeColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());

                }
                sqm.Condition.Where.AddWhere(sw);
            }

            if (!TblMWInventoryTrackCtrl.QueryPage(dcf, sqm,page,pageSize, ref dataList, ref errMsg))
            {
                return false;
            }

            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }
        public static bool GetRecoverInventoryTrack(int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWInventoryTrack> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWInventoryTrack.getTxnTypeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWInventoryTrack.TXNTYPE_ENUM_Recover);

            if (!TblMWInventoryTrackCtrl.QueryPage(dcf, sqm, page, pageSize, ref dataList, ref errMsg))
            {
                return false;
            }

            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }
        public static bool GetPostInventoryTrack(int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWInventoryTrack> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWInventoryTrack.getTxnTypeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWInventoryTrack.TXNTYPE_ENUM_Post);

            if (!TblMWInventoryTrackCtrl.QueryPage(dcf, sqm, page, pageSize, ref dataList, ref errMsg))
            {
                return false;
            }

            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }
        #endregion

        #region Txn log
        public static bool GetTxnLogList(int txnDetailId,ref List<TblMWTxnLog> dataList,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWTxnLog.getTxnDetailIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnDetailId);
            if (!TblMWTxnLogCtrl.QueryMore(dcf, sqm, ref dataList, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool GetTxnType(string txnNum, ref string txnType, ref string errMsg)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT ");

            sb.AppendLine(string.Format("(SELECT COUNT(*) FROM {0} WHERE TxnNum = '{1}'), ", TblMWTxnRecoverHeader.getFormatTableName(), txnNum));
            sb.AppendLine(string.Format("(SELECT COUNT(*) FROM {0} WHERE TxnNum = '{1}'), ", TblMWTxnPostHeader.getFormatTableName(), txnNum));
            sb.AppendLine(string.Format("(SELECT COUNT(*) FROM {0} WHERE TxnNum = '{1}') ", TblMWTxnDestroyHeader.getFormatTableName(), txnNum));
            System.Data.DataSet ds = SqlDBMng.getInstance().query(sb.ToString(), null);
            int trCount = (int)ds.Tables[0].Rows[0][0];
            int tpCount = (int)ds.Tables[0].Rows[0][0];
            int tdCount = (int)ds.Tables[0].Rows[0][0];


            if (trCount != 0)
            {
                txnType = TblMWTxnDetail.TXNTYPE_ENUM_Recover;
            }
            else if (tpCount != 0)
            {
                txnType = TblMWTxnDetail.TXNTYPE_ENUM_Post;
            }
            else if (tdCount != 0)
            {
                txnType = TblMWTxnDetail.TXNTYPE_ENUM_Destroy;
            }
            else
            {
                errMsg = "无效的交易编号";
                return false;
            }


            return true;
        }
        #endregion

        #region Txn
        public static bool GetTxnRecoverReportData(ref TblMWTxnRecoverHeader recHeader, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.QueryColumn.AddCount(TblMWTxnRecoverHeader.getRecoHeaderIdColumn());
            sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getTotalSubWeightColumn());
            sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getTotalTxnWeightColumn());
            sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getTotalCrateQtyColumn());
            if (!TblMWTxnRecoverHeaderCtrl.QueryOne(dcf, sqm, ref recHeader, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool GetTxnRecoverDataList(string filter,int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWTxnRecoverHeader> recHeaderList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            if (!string.IsNullOrEmpty(filter.Trim()))
            {
                SqlWhere sw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
                string[] filterGroup = filter.Trim().Split(' ');
                foreach (var f in filterGroup)
                {
                    if (f.Trim() == "")
                    {
                        continue;
                    }
                    sw.AddLikeValue(TblMWTxnRecoverHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWTxnRecoverHeader.getCarCodeColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWTxnRecoverHeader.getDriverColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWTxnRecoverHeader.getDriverCodeColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWTxnRecoverHeader.getInspectorColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWTxnRecoverHeader.getInspectorCodeColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                }
                sqm.Condition.Where.AddWhere(sw);
            }

            sqm.Condition.OrderBy.Add(TblMWTxnRecoverHeader.getStartDateColumn(), SqlCommonFn.SqlOrderByType.DESC);

            if (!TblMWTxnRecoverHeaderCtrl.QueryPage(dcf, sqm, page, pageSize, ref recHeaderList, ref errMsg))
            {
                return false;
            }

            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;

            return true;
        }

        public static bool GetTxnDestroyReportData(ref TblMWTxnDestroyHeader desHeader, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.QueryColumn.AddCount(TblMWTxnDestroyHeader.getDestHeaderIdColumn());
            sqm.QueryColumn.AddSum(TblMWTxnDestroyHeader.getTotalSubWeightColumn());
            sqm.QueryColumn.AddSum(TblMWTxnDestroyHeader.getTotalTxnWeightColumn());
            sqm.QueryColumn.AddSum(TblMWTxnDestroyHeader.getTotalCrateQtyColumn());
            if (!TblMWTxnDestroyHeaderCtrl.QueryOne(dcf, sqm, ref desHeader, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool GetTxnDestroyDataList(string filter, int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWTxnDestroyHeader> desHeaderList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            if (!string.IsNullOrEmpty(filter.Trim()))
            {
                SqlWhere sw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
                string[] filterGroup = filter.Trim().Split(' ');
                foreach (var f in filterGroup)
                {
                    if (f.Trim() == "")
                    {
                        continue;
                    }
                    sw.AddLikeValue(TblMWTxnDestroyHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWTxnDestroyHeader.getDestEmpyCodeColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWTxnDestroyHeader.getDestEmpyNameColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                }
                sqm.Condition.Where.AddWhere(sw);
            }

            sqm.Condition.OrderBy.Add(TblMWTxnDestroyHeader.getStartDateColumn(), SqlCommonFn.SqlOrderByType.DESC);

            if (!TblMWTxnDestroyHeaderCtrl.QueryPage(dcf, sqm, page, pageSize, ref desHeaderList, ref errMsg))
            {
                return false;
            }

            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }

        public static bool GetTxnPostReportData(ref TblMWTxnPostHeader postHeader, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();

            sqm.QueryColumn.AddCount(TblMWTxnPostHeader.getPostHeaderIdColumn());
            sqm.QueryColumn.AddSum(TblMWTxnPostHeader.getTotalSubWeightColumn());
            sqm.QueryColumn.AddSum(TblMWTxnPostHeader.getTotalTxnWeightColumn());
            sqm.QueryColumn.AddSum(TblMWTxnPostHeader.getTotalCrateQtyColumn());
            if (!TblMWTxnPostHeaderCtrl.QueryOne(dcf, sqm, ref postHeader, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool GetTxnPostDataList(string filter, int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWTxnPostHeader> postHeaderList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();

            if (!string.IsNullOrEmpty(filter.Trim()))
            {
                SqlWhere sw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
                string[] filterGroup = filter.Trim().Split(' ');
                foreach (var f in filterGroup)
                {
                    if (f.Trim() == "")
                    {
                        continue;
                    }
                    sw.AddLikeValue(TblMWTxnPostHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWTxnPostHeader.getPostEmpyNameColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWTxnPostHeader.getPostWSCodeColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                }
                sqm.Condition.Where.AddWhere(sw);
            }

            sqm.Condition.OrderBy.Add(TblMWTxnPostHeader.getStartDateColumn(), SqlCommonFn.SqlOrderByType.DESC);

            if (!TblMWTxnPostHeaderCtrl.QueryPage(dcf, sqm, page, pageSize, ref postHeaderList, ref errMsg))
            {
                return false;
            }

            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }

        public static bool GetTxnRecoverHeader(string txnNum, ref TblMWTxnRecoverHeader header, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWTxnRecoverHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
            if (!TblMWTxnRecoverHeaderCtrl.QueryOne(dcf, sqm, ref header, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool GetTxnPostHeader(string txnNum, ref TblMWTxnPostHeader header, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWTxnPostHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
            if (!TblMWTxnPostHeaderCtrl.QueryOne(dcf, sqm, ref header, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool GetTxnDestroyHeader(string txnNum, ref TblMWTxnDestroyHeader header, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWTxnDestroyHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
            if (!TblMWTxnDestroyHeaderCtrl.QueryOne(dcf, sqm, ref header, ref errMsg))
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
