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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using YRKJ.MWR;
using ComLib.db;

namespace MobilePhoneDemoApp
{
    public partial class Form1 : Form
    {
        private const string ClassName = "MobilePhoneDemoApp.Form1";
        private FormMng _frmMng = null;

        public Form1()
        {
            InitializeComponent();
            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ControlBox = false;
        } 

        #region Event
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!InitFrm())
                {
                    return;
                }

                if (!InitCtrls())
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "Form1_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (FrmScanner f = new FrmScanner())
                {
                    this.Visible = false;
                    f.ShowDialog();
                    this.Visible = true;
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "button1_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Close();
                
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "button5_Click", ex);
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
            if (!LoadData())
                return false;



            return true;
        }

        private bool InitCtrls()
        {
            c_labDriver.Text = DemoData.GetInstance().Driver;
            c_labInspector.Text = DemoData.GetInstance().Inspector;
            c_labMWSCode.Text = DemoData.GetInstance().MWSCode;
            c_labCarCode.Text = DemoData.GetInstance().CarCode;
            return true;
        }

        private bool LoadData()
        {
            return true;
        }

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "手机终端模拟器";
        }

        #endregion

        private class ResponseHttpValueJsonData
        {
            private string _action = "";
            public string action
            {
                get { return _action; }
                set { _action = value; }
            }

            private object _value = null;
            public object value
            {
                get { return _value; }
                set { _value = value; }
            }
        }

        private class TxnData
        {
            private string _driver = "";
            public string drvier
            {
                get { return _driver; }
                set { _driver = value; }
            }
            private string _drivercode = "";
            public string drivercode
            {
                get { return _drivercode; }
                set { _drivercode = value; }
            }

            private string _inspector = "";
            public string inspector
            {
                get { return _inspector; }
                set { _inspector = value; }
            }

            private string _inspectorcode = "";
            public string inspectorcode
            {
                get { return _inspectorcode; }
                set { _inspectorcode = value; }
            }

            private string _mwscode = "";
            public string mwscode
            {
                get { return _mwscode; }
                set { _mwscode = value; }
            }

            private string _carCode = "";
            public string carcode
            {
                get { return _carCode; }
                set { _carCode = value; }
            }

            private List<DemoData.DemoMWTxnDetail> _txndetaillist = new List<DemoData.DemoMWTxnDetail>();
            public List<DemoData.DemoMWTxnDetail> txndetaillist
            {
                get { return _txndetaillist; }
                set { _txndetaillist = value; }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string errMsg = "";
                #region test
                //{
                //    DataCtrlInfo dcf = new DataCtrlInfo();
                //    TblMWCarDispatch carDispatchInfo = new TblMWCarDispatch();
                //    carDispatchInfo.CarDisId = 1;
                //    //carDispatchInfo.InDate = DateTime.Now;
                //    int updCount = 0;

                //    SqlWhere sw = new SqlWhere();
                //    sw.AddCompareValue(TblMWCarDispatch.getCarDisIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, carDispatchInfo.CarDisId);

                //    SqlUpdateColumn suc = new SqlUpdateColumn();
                //    //suc.Add(TblMWCarDispatch.getCarCodeColumn(),"asdf");
                //    suc.Add(TblMWCarDispatch.getInDateColumn(),DateTime.Now);

                //    if (!TblMWCarDispatchCtrl.Update(dcf, carDispatchInfo, suc, sw, ref updCount, ref errMsg))
                //    {
                //        MessageBox.Show(errMsg);
                //        return ;
                //    }
                //}
                //return;
                #endregion
                {
                    string body = "";
                    TxnData txnData = new TxnData();
                    txnData.carcode = DemoData.GetInstance().CarCode;
                    txnData.drvier = DemoData.GetInstance().Driver;
                    txnData.drivercode = DemoData.GetInstance().DriverCode;
                    txnData.inspector = DemoData.GetInstance().Inspector;
                    txnData.inspectorcode = DemoData.GetInstance().InspectorCode;
                    txnData.mwscode = DemoData.GetInstance().MWSCode;
                    txnData.txndetaillist = DemoData.GetInstance().TxnDetailList;

                    ResponseHttpValueJsonData jData = new ResponseHttpValueJsonData();
                    jData.action = "RecoverInventorySubmit";
                    jData.value = txnData;
                    body = JsonConvert.SerializeObject(jData);

                    string resData = "";

                    if (!MWHttpSendHelper.RequestToJson(
                        ComLib.AuthorizationHelper.S_ACCESS_KEY,
                        ComLib.AuthorizationHelper.S_SECRET_KEY,
                        body, "POST", @"http://localhost:15809/Services/MWMobileWSHandler.ashx", ref resData, ref errMsg))
                    {
                        MessageBox.Show(errMsg);
                    }

                    string resultData = "";
                    if (!MWHttpSendHelper.DoMWServerResponseData(resData, ref resultData, ref errMsg))
                    {
                        MsgBox.Error(errMsg);
                        return;
                    }
                    MsgBox.Show(resultData);
                    //if (resData.ToLower().Equals("success"))
                    //{
                    //    DemoData.GetInstance().TxnDetailList.Clear();
                    //}

                    using (FrmText f = new FrmText(resData))
                    {
                        f.ShowDialog();
                    }

                }

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "button2_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string errMsg = "";
                #region test
                //{
                //    DataCtrlInfo dcf = new DataCtrlInfo();
                //    TblMWCarDispatch carDispatchInfo = new TblMWCarDispatch();
                //    carDispatchInfo.CarDisId = 1;
                //    //carDispatchInfo.InDate = DateTime.Now;
                //    int updCount = 0;

                //    SqlWhere sw = new SqlWhere();
                //    sw.AddCompareValue(TblMWCarDispatch.getCarDisIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, carDispatchInfo.CarDisId);

                //    SqlUpdateColumn suc = new SqlUpdateColumn();
                //    //suc.Add(TblMWCarDispatch.getCarCodeColumn(),"asdf");
                //    suc.Add(TblMWCarDispatch.getInDateColumn(),DateTime.Now);

                //    if (!TblMWCarDispatchCtrl.Update(dcf, carDispatchInfo, suc, sw, ref updCount, ref errMsg))
                //    {
                //        MessageBox.Show(errMsg);
                //        return ;
                //    }
                //}
                //return;
                #endregion
                {
                    string body = "";
                    TxnData txnData = new TxnData();
                    txnData.carcode = DemoData.GetInstance().CarCode;
                    txnData.drvier = DemoData.GetInstance().Driver;
                    txnData.drivercode = DemoData.GetInstance().DriverCode;
                    txnData.inspector = DemoData.GetInstance().Inspector;
                    txnData.inspectorcode = DemoData.GetInstance().InspectorCode;
                    txnData.mwscode = DemoData.GetInstance().MWSCode;
                    txnData.txndetaillist = DemoData.GetInstance().TxnDetailList;

                    ResponseHttpValueJsonData jData = new ResponseHttpValueJsonData();
                    jData.action = "RecoverDestroySubmit";
                    jData.value = txnData;
                    body = JsonConvert.SerializeObject(jData);

                    string resData = "";

                    if (!MWHttpSendHelper.RequestToJson(
                        ComLib.AuthorizationHelper.S_ACCESS_KEY,
                        ComLib.AuthorizationHelper.S_SECRET_KEY,
                        body, "POST", @"http://localhost:15809/Services/MWMobileWSHandler.ashx", ref resData, ref errMsg))
                    {
                        MessageBox.Show(errMsg);
                    }

                    if (resData.ToLower().Equals("success"))
                    {
                        DemoData.GetInstance().TxnDetailList.Clear();
                    }

                    using (FrmText f = new FrmText(resData))
                    {
                        f.ShowDialog();
                    }

                }

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "button2_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

      

        #region Form Data Property

        #endregion
    }
}
