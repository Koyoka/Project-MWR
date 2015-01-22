using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRKJ.MWR;
using System.ComponentModel;

namespace MobilePhoneDemoApp
{
    public class DemoData
    {

        private string _driverCode = "";
        public string DriverCode
        {
            get { return _driverCode; }
            set { _driverCode = value; }
        }
        private string _inspectorCode = "";
        public string InspectorCode
        {
            get { return _inspectorCode; }
            set { _inspectorCode = value; }
        }
        private string _carCode = "";
        public string CarCode
        {
            get { return _carCode; }
            set { _carCode = value; }
        }
        public string Driver = "";
        public string Inspector = "";
        public string MWSCode = "";

        private List<TblMWWasteCategory> _wasteDataList = new List<TblMWWasteCategory>();
        public List<TblMWWasteCategory> WasteDataList
        {
            get { return _wasteDataList; }
            set { _wasteDataList = value; }
        }
        private List<TblMWVendor> _vendorDataList = new List<TblMWVendor>();
        public List<TblMWVendor> VendorDataList
        {
            get { return _vendorDataList; }
            set { _vendorDataList = value; }
        }
        private List<TblMWTxnDetail> _txnDetailList = new List<TblMWTxnDetail>();
        public List<TblMWTxnDetail> TxnDetailList
        {
            get { return _txnDetailList; }
            set { _txnDetailList = value; }
        }


        private static DemoData _data= null;
        public static DemoData GetInstance()
        { 
            if(_data == null)
            {
                _data = new DemoData();
            }

            return _data;
        }

        public void AddTxnData(TblMWTxnDetail txnData)
        {
            _txnDetailList.Add(txnData);
        }
        //private List<>



        

    }
}
