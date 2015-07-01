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
            sqm.QueryColumn.AddSum(TblMWInventory.getPostWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getDestWeightColumn());
           
            if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool GetInvAuthorizeWeightReportData(ref List<VewIvnAuthorizeWithTxnDetail> itemList,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.QueryColumn.AddSum(VewIvnAuthorizeWithTxnDetail.getSubWeightColumn());
            sqm.QueryColumn.AddSum(VewIvnAuthorizeWithTxnDetail.getTxnWeightColumn());
            sqm.QueryColumn.AddSum(VewIvnAuthorizeWithTxnDetail.getDiffWeightColumn());
            sqm.QueryColumn.Add(VewIvnAuthorizeWithTxnDetail.getTxnTypeColumn());
            sqm.Condition.GroupBy.Add(VewIvnAuthorizeWithTxnDetail.getTxnTypeColumn());
           
            if (!VewIvnAuthorizeWithTxnDetailCtrl.QueryMore(dcf, sqm, ref itemList, ref errMsg))
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
            sqm.Condition.OrderBy.Add(TblMWInventoryTrack.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.DESC);
            #region filter
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
            #endregion
            if (!TblMWInventoryTrackCtrl.QueryPage(dcf, sqm,page,pageSize, ref dataList, ref errMsg))
            {
                return false;
            }

            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }
        public static bool GetRecoverInventoryTrack(string filter,int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWInventoryTrack> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWInventoryTrack.getTxnTypeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWInventoryTrack.TXNTYPE_ENUM_Recover);
            sqm.Condition.OrderBy.Add(TblMWInventoryTrack.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.DESC);
            #region filter
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
                        if (reg.IsMatch(defineF))
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
            #endregion
            if (!TblMWInventoryTrackCtrl.QueryPage(dcf, sqm, page, pageSize, ref dataList, ref errMsg))
            {
                return false;
            }

            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }
        public static bool GetPostInventoryTrack(string filter,int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWInventoryTrack> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWInventoryTrack.getTxnTypeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWInventoryTrack.TXNTYPE_ENUM_Post);
            sqm.Condition.OrderBy.Add(TblMWInventoryTrack.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.DESC);
            #region filter
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
                        if (reg.IsMatch(defineF))
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
            #endregion
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
        
        #endregion

        #region Txn
        public static bool GetTxnType(string txnNum, ref string txnType, ref string errMsg)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT ");

            sb.AppendLine(string.Format("(SELECT COUNT(*) FROM {0} WHERE TxnNum = '{1}'), ", TblMWTxnRecoverHeader.getFormatTableName(), txnNum));
            sb.AppendLine(string.Format("(SELECT COUNT(*) FROM {0} WHERE TxnNum = '{1}'), ", TblMWTxnPostHeader.getFormatTableName(), txnNum));
            sb.AppendLine(string.Format("(SELECT COUNT(*) FROM {0} WHERE TxnNum = '{1}') ", TblMWTxnDestroyHeader.getFormatTableName(), txnNum));
            try
            {
                System.Data.DataSet ds = SqlDBMng.getInstance().query(sb.ToString(), null);
                int trCount = ComLib.ComFn.ObjectToInt(ds.Tables[0].Rows[0][0]);
                int tpCount = ComLib.ComFn.ObjectToInt(ds.Tables[0].Rows[0][1]);
                int tdCount = ComLib.ComFn.ObjectToInt(ds.Tables[0].Rows[0][2]);

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
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
            return true;
        }

        public static bool GetTodayTxnRecoverRepotData(ref TblMWTxnRecoverHeader recHeader, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.QueryColumn.AddCount(TblMWTxnRecoverHeader.getRecoHeaderIdColumn());
            sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getTotalSubWeightColumn());
            sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getTotalTxnWeightColumn());
            sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getTotalCrateQtyColumn());
            DateTime now = SqlDBMng.GetDBNow();
            sqm.Condition.Where.AddDateTimeCompareValue(
                TblMWTxnRecoverHeader.getEntryDateColumn(),
                SqlCommonFn.SqlWhereCompareEnum.Equals, 
                now, SqlCommonFn.SqlWhereDateTimeFormatEnum.YMD);
            if (!TblMWTxnRecoverHeaderCtrl.QueryOne(dcf, sqm, ref recHeader, ref errMsg))
            {
                return false;
            }
            return true;
        }
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

        public static bool GetTodayTxnDestroyReportData(ref TblMWTxnDestroyHeader desHeader, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.QueryColumn.AddCount(TblMWTxnDestroyHeader.getDestHeaderIdColumn());
            sqm.QueryColumn.AddSum(TblMWTxnDestroyHeader.getTotalSubWeightColumn());
            sqm.QueryColumn.AddSum(TblMWTxnDestroyHeader.getTotalTxnWeightColumn());
            sqm.QueryColumn.AddSum(TblMWTxnDestroyHeader.getTotalCrateQtyColumn());
            DateTime now = SqlDBMng.GetDBNow();
            sqm.Condition.Where.AddDateTimeCompareValue(TblMWTxnDestroyHeader.getStartDateColumn(),
                SqlCommonFn.SqlWhereCompareEnum.Equals,
                now, SqlCommonFn.SqlWhereDateTimeFormatEnum.YMD);
            if (!TblMWTxnDestroyHeaderCtrl.QueryOne(dcf, sqm, ref desHeader, ref errMsg))
            {
                return false;
            }
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

        #region Authorize
        public static bool GetProcessAuthorizeCount(ref int count,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.QueryColumn.AddCount(TblMWInvAuthorize.getTxnDetailIdColumn());
            sqm.Condition.Where.AddCompareValue(VewIvnAuthorizeWithTxnDetail.getStatusColumn(),
                 SqlCommonFn.SqlWhereCompareEnum.Equals, VewIvnAuthorizeWithTxnDetail.STATUS_ENUM_Precess);
            TblMWInvAuthorize item = null;
            if (!TblMWInvAuthorizeCtrl.QueryOne(dcf, sqm, ref item, ref errMsg))
            {
                return false;
            }

            count = item.TxnDetailId;
            return true;
        }

        public static bool GetProcessAuthorizeList(int page, int pageSize, ref long pageCount, ref long rowCount, ref List<VewIvnAuthorizeWithTxnDetail> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(VewIvnAuthorizeWithTxnDetail.getStatusColumn(),
                 SqlCommonFn.SqlWhereCompareEnum.Equals, VewIvnAuthorizeWithTxnDetail.STATUS_ENUM_Precess);
            sqm.Condition.OrderBy.Add(VewIvnAuthorizeWithTxnDetail.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.ASC);

            if (!VewIvnAuthorizeWithTxnDetailCtrl.QueryPage(dcf, sqm, page, pageSize, ref dataList, ref errMsg))
            {
                return false;
            }
            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;

            return true;
        }

        public static bool GetAuthorize(int invAuthId, ref VewIvnAuthorizeWithTxnDetail item, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(VewIvnAuthorizeWithTxnDetail.getInvAuthIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invAuthId);

            if (!VewIvnAuthorizeWithTxnDetailCtrl.QueryOne(dcf, sqm, ref item, ref errMsg))
            {
                return false;
            }

            return true;
        }

        public static bool GetAuthorizeDataList(string filter,int invAuthoId, int page, int pageSize, ref long pageCount, ref long rowCount, ref List<VewIvnAuthorizeWithTxnDetail> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            if (invAuthoId != 0) 
            {
                sqm.Condition.Where.AddCompareValue(VewIvnAuthorizeWithTxnDetail.getInvAuthIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invAuthoId);
            }
            #region filter
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
                        if (reg.IsMatch(defineF))
                        {
                            SqlWhere subSw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
                            string preFix = defineF.Substring(0, 1);
                            decimal value = ComLib.ComFn.StringToDecimal(defineF.Substring(1, defineF.Length - 1));
                            if (preFix.Equals("="))
                            {
                                subSw.AddCompareValue(VewIvnAuthorizeWithTxnDetail.getSubWeightColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, value);
                                subSw.AddCompareValue(VewIvnAuthorizeWithTxnDetail.getTxnWeightColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, value);
                            }
                            else if (preFix.Equals(">"))
                            {
                                subSw.AddCompareValue(VewIvnAuthorizeWithTxnDetail.getSubWeightColumn(), SqlCommonFn.SqlWhereCompareEnum.MoreEquals, value);
                                subSw.AddCompareValue(VewIvnAuthorizeWithTxnDetail.getTxnWeightColumn(), SqlCommonFn.SqlWhereCompareEnum.MoreEquals, value);
                            }
                            else if (preFix.Equals("<"))
                            {
                                subSw.AddCompareValue(VewIvnAuthorizeWithTxnDetail.getSubWeightColumn(), SqlCommonFn.SqlWhereCompareEnum.LessEquals, value);
                                subSw.AddCompareValue(VewIvnAuthorizeWithTxnDetail.getTxnWeightColumn(), SqlCommonFn.SqlWhereCompareEnum.LessEquals, value);
                            }
                            sqm.Condition.Where.AddWhere(subSw);

                            continue;
                        }
                    }
                    sw.AddLikeValue(VewIvnAuthorizeWithTxnDetail.getTxnNumColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(VewIvnAuthorizeWithTxnDetail.getCrateCodeColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(VewIvnAuthorizeWithTxnDetail.getAuthEmpyNameColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(VewIvnAuthorizeWithTxnDetail.getEmpyNameColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(VewIvnAuthorizeWithTxnDetail.getWSCodeColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());

                }
                sqm.Condition.Where.AddWhere(sw);
            }
            #endregion
            sqm.Condition.OrderBy.Add(VewIvnAuthorizeWithTxnDetail.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.DESC);
            if (!VewIvnAuthorizeWithTxnDetailCtrl.QueryPage(dcf, sqm, page, pageSize, ref dataList, ref errMsg))
            {
                return false;
            }
            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }

        public static bool getAuthorizeAttachDataList(int invAuthId, ref List<TblMWInvAuthorizeAttach> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWInvAuthorizeAttach.getInvAuthIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invAuthId);
            if (!TblMWInvAuthorizeAttachCtrl.QueryMore(dcf, sqm, ref dataList, ref errMsg))
            {
                return false;
            }
            return true;
        }
       
        #endregion

        #region car
        public static bool GetCarDispatchReport(ref int carDisWholeCount, ref int carDisTodayCount, ref int carDisNoOutCount, ref int carDisLeftCount, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT ");
            #region carDis whole count
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.setQueryTableName(TblMWCarDispatch.getFormatTableName());
                SqlQueryColumn sqc = new SqlQueryColumn();
                sqm.QueryColumn.AddCount(TblMWCarDispatch.getCarDisIdColumn());
                string s = sqm.getInSql();
                sb.AppendLine("(" + s + ") AS COL1,");
                System.Diagnostics.Debug.WriteLine(s);
            }
            #endregion

            #region carDis today count
            {
                DateTime now = SqlDBMng.GetDBNow();
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.setQueryTableName(TblMWCarDispatch.getFormatTableName());
                sqm.QueryColumn.AddCount(TblMWCarDispatch.getCarDisIdColumn());
                sqm.Condition.Where.AddDateTimeCompareValue(TblMWCarDispatch.getOutDateColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, now, SqlCommonFn.SqlWhereDateTimeFormatEnum.YMD);
                string s = sqm.getInSql();
                sb.AppendLine("(" + s + ") AS COL2,");
                System.Diagnostics.Debug.WriteLine(s);
            }
            #endregion

            #region car no out count
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.setQueryTableName(TblMWCar.getFormatTableName());
                sqm.QueryColumn.AddCount(TblMWCar.getCarCodeColumn());
                sqm.Condition.Where.AddCompareValue(TblMWCar.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals, TblMWCar.STATUS_ENUM_Void);
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWCar.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals, TblMWCar.STATUS_ENUM_Void);
                {
                    SqlQueryMng subSqm = new SqlQueryMng();
                    subSqm.setQueryTableName(TblMWCarDispatch.getFormatTableName());
                    subSqm.QueryColumn.Add(TblMWCarDispatch.getCarCodeColumn());
                    subSqm.Condition.Where.AddCompareValue(
                        TblMWCarDispatch.getStatusColumn(),
                        SqlCommonFn.SqlWhereCompareEnum.Equals,
                        TblMWCarDispatch.STATUS_ENUM_ShiftStrat);

                    sqm.Condition.Where.AddNotInValues(TblMWCar.getCarCodeColumn(), subSqm);
                }

                string s = sqm.getInSql();
                sb.AppendLine("(" + s + ") AS COL3,");
                System.Diagnostics.Debug.WriteLine(s);
            }
            #endregion

            #region car count
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.setQueryTableName(TblMWCar.getFormatTableName());
                sqm.QueryColumn.AddCount(TblMWCar.getCarCodeColumn());
                sqm.Condition.Where.AddCompareValue(TblMWCar.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals, TblMWCar.STATUS_ENUM_Void);
                string s = sqm.getInSql();
                sb.AppendLine("(" + s + ") AS COL4;");
                System.Diagnostics.Debug.WriteLine(s);
            }
            #endregion

            string sql = sb.ToString();
            try
            {
                System.Data.DataSet ds = SqlDBMng.getInstance().query(sql, null);
                carDisWholeCount = ComLib.ComFn.ObjectToInt(ds.Tables[0].Rows[0][0]);
                carDisTodayCount = ComLib.ComFn.ObjectToInt(ds.Tables[0].Rows[0][1]);
                carDisNoOutCount = ComLib.ComFn.ObjectToInt(ds.Tables[0].Rows[0][2]);
                //int defineCarAllCount = ComLib.ComFn.ObjectToInt(ds.Tables[0].Rows[0][3]);
                carDisNoOutCount = ComLib.ComFn.ObjectToInt(ds.Tables[0].Rows[0][2]);
                carDisLeftCount = ComLib.ComFn.ObjectToInt(ds.Tables[0].Rows[0][3]) - carDisNoOutCount;
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
