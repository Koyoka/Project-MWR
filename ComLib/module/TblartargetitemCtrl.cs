using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace ComLib.module
{
    public class TblartargetitemCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<Tblartargetitem> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(Tblartargetitem.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new Tblartargetitem(), sqm.getParamsArray());
                if (itemList.Count != 0)
                {
                    dcf.RowCount = itemList[0].TEM_COLUMN_COUNT;
                    dcf.PageCount = ComFn.getPageCount(pageSize, dcf.RowCount);
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true ;
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<Tblartargetitem> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<Tblartargetitem> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(Tblartargetitem.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new Tblartargetitem(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref Tblartargetitem item,ref string errMsg)
        {
            List<Tblartargetitem> itemList = null;
            if (!QueryMore(dcf, sqm, ref itemList, ref errMsg))
            {
                return false;
            }

            if (itemList.Count > 0)
            {
                item = itemList[0];
            }
            else
            {
                item = null;
            }

            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref Tblartargetitem item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, Tblartargetitem item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.id,
                item.targetGroupId,
                item.userId,
                item.targetMetaDataId,
                item.target_id,
                item.active_flag,
                item.name,
                item.width,
                item.tracking_rating,
                item.reco_rating,
                item.imageLocName,
                item.createDate,
                item.status,
                item.targetMetaData,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            string id,
            int targetGroupId,
            string userId,
            int targetMetaDataId,
            string target_id,
            bool active_flag,
            string name,
            float width,
            int tracking_rating,
            string reco_rating,
            string imageLocName,
            DateTime createDate,
            string status,
            string targetMetaData,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tblartargetitem.getFormatTableName());
            sum.Add(Tblartargetitem.getIdColumn(), id);
            sum.Add(Tblartargetitem.getTargetGroupIdColumn(), targetGroupId);
            sum.Add(Tblartargetitem.getUserIdColumn(), userId);
            sum.Add(Tblartargetitem.getTargetMetaDataIdColumn(), targetMetaDataId);
            sum.Add(Tblartargetitem.getTarget_idColumn(), target_id);
            sum.Add(Tblartargetitem.getActive_flagColumn(), active_flag);
            sum.Add(Tblartargetitem.getNameColumn(), name);
            sum.Add(Tblartargetitem.getWidthColumn(), width);
            sum.Add(Tblartargetitem.getTracking_ratingColumn(), tracking_rating);
            sum.Add(Tblartargetitem.getReco_ratingColumn(), reco_rating);
            sum.Add(Tblartargetitem.getImageLocNameColumn(), imageLocName);
            sum.Add(Tblartargetitem.getCreateDateColumn(), createDate);
            sum.Add(Tblartargetitem.getStatusColumn(), status);
            sum.Add(Tblartargetitem.getTargetMetaDataColumn(), targetMetaData);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, Tblartargetitem item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(Tblartargetitem.getIdColumn(), item.id);
            suc.Add(Tblartargetitem.getTargetGroupIdColumn(), item.targetGroupId);
            suc.Add(Tblartargetitem.getUserIdColumn(), item.userId);
            suc.Add(Tblartargetitem.getTargetMetaDataIdColumn(), item.targetMetaDataId);
            suc.Add(Tblartargetitem.getTarget_idColumn(), item.target_id);
            suc.Add(Tblartargetitem.getActive_flagColumn(), item.active_flag);
            suc.Add(Tblartargetitem.getNameColumn(), item.name);
            suc.Add(Tblartargetitem.getWidthColumn(), item.width);
            suc.Add(Tblartargetitem.getTracking_ratingColumn(), item.tracking_rating);
            suc.Add(Tblartargetitem.getReco_ratingColumn(), item.reco_rating);
            suc.Add(Tblartargetitem.getImageLocNameColumn(), item.imageLocName);
            suc.Add(Tblartargetitem.getCreateDateColumn(), item.createDate);
            suc.Add(Tblartargetitem.getStatusColumn(), item.status);
            suc.Add(Tblartargetitem.getTargetMetaDataColumn(), item.targetMetaData);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tblartargetitem.getFormatTableName());
            string sql = sum.getUpdateSql(suc, sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }

        public static bool Delete(DataCtrlInfo dcf, SqlWhere sw, ref int count, ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tblartargetitem.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
