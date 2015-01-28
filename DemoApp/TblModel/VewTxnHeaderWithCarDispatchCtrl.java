package com.yrkj.ar.bean;
import java.util.List;

import com.yrkj.lib.db.BaseDataCtrl;
import com.yrkj.lib.db.DataCtrlInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlDBMng;
import com.yrkj.lib.db.SqlQueryMng;
import com.yrkj.lib.db.SqlUpdateColumn;
import com.yrkj.lib.db.SqlUpdateMng;
import com.yrkj.lib.db.SqlWhere;

public class VewTxnHeaderWithCarDispatchCtrl extends BaseDataCtrl {
    public static List<VewTxnHeaderWithCarDispatch> QueryMore(DataCtrlInfo dcf,SqlWhere sw){
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(dcf,sqm);
    }

    public static List<VewTxnHeaderWithCarDispatch> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        
        String sql = sqm.getVewSql(VewTxnHeaderWithCarDispatch.getSql());
        System.out.println(sql);
        try {
            dcf.set(true, "");
            return SqlDBMng.getInstance().query(sql, VewCustomerWithAccount.class,sqm.getParamsArray());
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
            return null;
        }
    }

    public static VewTxnHeaderWithCarDispatch QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<VewTxnHeaderWithCarDispatch> itemList = QueryMore(dcf,sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static VewTxnHeaderWithCarDispatch QueryOne(DataCtrlInfo dcf,SqlWhere sw){
        List<VewTxnHeaderWithCarDispatch> itemList = QueryMore(dcf,sw);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

}
