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
using YRKJ.MWR;
using ComLib.db;

namespace MobilePhoneDemoApp
{
    public partial class FrmScannerConfirm : Form
    {
        private const string ClassName = "MobilePhoneDemoApp.FrmScannerConfirm";
        private FormMng _frmMng = null;

        private string _code = "";
        private string _vendorcode = "";
        string _vendor = "";

        public FrmScannerConfirm()
        {
            InitializeComponent();
            this.Text = LngRes.MSG_FormName;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ControlBox = false;
        }

        public FrmScannerConfirm(string code,string vendorcode)
            : this()
        {
            _vendorcode = vendorcode;
            _code = code;
        }

        #region Event

        private void FrmScannerConfirm_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmScannerConfirm_Load", ex);
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
                string errMsg = "";

                #region valid

                foreach (TblMWTxnDetail data in DemoData.GetInstance().TxnDetailList)
                {
                    if (data.CrateCode.Equals(_code))
                    {
                        MessageBox.Show("当前货箱已添加");
                        return;
                    }
                }

                #endregion

                
                TblMWTxnDetail txnDetail = new TblMWTxnDetail();
                txnDetail.CrateCode = _code;
                txnDetail.Vendor = _vendor;
                txnDetail.VendorCode = _vendorcode;
                txnDetail.SubWeight = (float)c_txtWeight.Value;
                txnDetail.Waste = (c_cmbWaster.SelectedItem as TblMWWasteCategory).Waste;//c_cmbWaster.SelectedText;
                txnDetail.WasteCode = (c_cmbWaster.SelectedItem as TblMWWasteCategory).WasteCode;//c_cmbWaster.SelectedValue+"";
                txnDetail.EntryDate = SqlDBMng.GetDBNow();
                //DemoData.GetInstance().TxnDetailList.Add(txnDetail);

                DemoData.GetInstance().TxnDetailList.Insert(0, txnDetail);
                this.Close();
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Close();

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

      

        #endregion

        #region Functions

        private bool InitFrm()
        {
            string errMsg = "";
            if (!LoadData(ref errMsg))
                return false;



            return true;
        }

        private bool InitCtrls()
        {
            c_txtVendor.Text = _vendor;
            c_txtCode.Text = _code;
            c_cmbWaster.DisplayMember = TblMWWasteCategory.getWasteColumn().ColumnName;
            c_cmbWaster.ValueMember = TblMWWasteCategory.getWasteCodeColumn().ColumnName;
            c_cmbWaster.DataSource = DemoData.GetInstance().WasteDataList;

            return true;
        }

        private bool LoadData(ref string errMsg)
        {
            
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                SqlQueryMng sqm = new SqlQueryMng();

                TblMWVendor item = null;
                if (!TblMWVendorCtrl.QueryOne(dcf, sqm, ref item, ref errMsg))
                {
                    
                    return false;
                }

                if (item == null)
                {
                    errMsg = "当前医院编号错误";
                    return false;
                }

                _vendor = item.Vendor;
            }

            return true;
        }

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "";
        }

        #endregion

        
     
        #region Form Data Property

        #endregion
    }
}
