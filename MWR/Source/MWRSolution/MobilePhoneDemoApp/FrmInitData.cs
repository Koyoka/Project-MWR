using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YRKJ.MWR.WinBase.WinAppBase;
using ComLib.Log;
using ComLib.db;
using YRKJ.MWR;
using ComLib.Error;

namespace MobilePhoneDemoApp
{
    public partial class FrmInitData : Form
    {
        private const string ClassName = "MobilePhoneDemoApp.FrmInitData";
        private FormMng _frmMng = null;

        private string _driverCode = "";
        private string _inspectorCode = "";
        private string _mwsCode = "";
        private string _carCode = "";

        public FrmInitData(string driverCode, string inspectorCode,string mwscode,string carCode)
        {
            InitializeComponent();
            _driverCode = driverCode;
            _inspectorCode = inspectorCode;
            _mwsCode = mwscode;
            _carCode = carCode;

            this.Text = LngRes.MSG_FormName;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ControlBox = false;
        } 

        #region Event
        private void FrmInitData_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!InitFrm())
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmInitData_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region Functions

        private bool InitFrm()
        {
            string errMsg = "";
            if (!LoadData(ref errMsg))
            {
                MessageBox.Show(errMsg);
                return false;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }


            return true;
        }

        private bool InitCtrls()
        {
            return true;
        }

        private bool LoadData(ref string errMsg)
        {


            DataCtrlInfo dcf = new DataCtrlInfo();
            {
                List<TblMWVendor> dataList = new List<TblMWVendor>();
                SqlQueryMng sqm = new SqlQueryMng();
                if (!TblMWVendorCtrl.QueryMore(dcf, sqm, ref dataList, ref errMsg))
                {
                    return false;
                }
                DemoData.GetInstance().VendorDataList.AddRange(dataList);
            }

            {
                List<TblMWWasteCategory> dataList = new List<TblMWWasteCategory>();
                SqlQueryMng sqm = new SqlQueryMng();
                if (!TblMWWasteCategoryCtrl.QueryMore(dcf, sqm, ref dataList, ref errMsg))
                {
                    return false;
                }
                DemoData.GetInstance().WasteDataList.AddRange(dataList);
            }

            {
                TblMWEmploy data = null;
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, _driverCode);
                if (!TblMWEmployCtrl.QueryOne(dcf, sqm, ref data, ref errMsg))
                {
                    return false;
                }

                if (data == null)
                {
                    errMsg = "没有当前编号的司机";
                    return false;
                }
                DemoData.GetInstance().Driver = data.EmpyName;
                DemoData.GetInstance().DriverCode = data.EmpyCode;
            }

            {
                TblMWEmploy data = null;
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, _inspectorCode);
                if (!TblMWEmployCtrl.QueryOne(dcf, sqm, ref data, ref errMsg))
                {
                    return false;
                }

                if (data == null)
                {
                    errMsg = "没有当前编号的跟车员";
                    return false;
                }
                DemoData.GetInstance().Inspector = data.EmpyName;
                DemoData.GetInstance().InspectorCode = data.EmpyCode;
            }

            {

                TblMWWorkStation ws = null;

                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWWorkStation.getWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, _mwsCode);
                if (!TblMWWorkStationCtrl.QueryOne(dcf, sqm, ref ws, ref errMsg))
                {
                    return false;
                }
                if (ws == null)
                {
                    errMsg = "没有当前编号的移动终端";
                    return false;
                }
                DemoData.GetInstance().MWSCode = _mwsCode;
            }

            {
                TblMWCar car = null;
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWCar.getCarCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, _carCode);
                if (!TblMWCarCtrl.QueryOne(dcf, sqm, ref car, ref errMsg))
                {
                    return false;
                }
                if (car == null)
                {
                    errMsg = "没有找到当前编号的车辆信息";
                    return false;
                }
                DemoData.GetInstance().CarCode = car.CarCode;

            }
            return true;
        }

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "当前终端数据初始化";
        }

        #endregion

       
        #region Form Data Property

        #endregion
    }
}
