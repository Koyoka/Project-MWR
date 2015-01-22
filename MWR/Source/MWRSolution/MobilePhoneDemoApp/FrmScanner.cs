using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YRKJ.MWR.WinBase.WinAppBase;
using YRKJ.MWR.WinBase.WinUtility;
using ComLib.Log;
using YRKJ.MWR;

namespace MobilePhoneDemoApp
{
    public partial class FrmScanner : Form
    {
        private const string ClassName = "MobilePhoneDemoApp.FrmScanner";
        private FormMng _frmMng = null;

        private ScannerMng _scannerMng = null;

        public FrmScanner()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ControlBox = false;

            _scannerMng = new ScannerMng(this, ClassName, WinAppBase.CrateBarCodeMask);
            _scannerMng.CodeScanned += new ScannerMng.ScannedEventHandler(FrmScanner_CodeScanned);
            _scannerMng.InvalidCodeScanned += new ScannerMng.ScannedEventHandler(FrmScanner_InvalidCodeScanned);
        } 

        #region Event

        private void FrmScanner_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmScanner_Load", ex);
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


        private void FrmScanner_InvalidCodeScanned(string code)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmScanner_InvalidCodeScanned", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void FrmScanner_CodeScanned(string code)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string vendorcode = "";
                vendorcode = (c_cmbVendor.SelectedItem as TblMWVendor).VendorCode;
                using (FrmScannerConfirm f = new FrmScannerConfirm(code, vendorcode))
                {
                    f.ShowDialog();
                    BindDetailInfoData();
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmScanner_CodeScanned", ex);
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
            c_cmbVendor.DisplayMember = TblMWVendor.getVendorColumn().ColumnName;
            c_cmbVendor.ValueMember = TblMWVendor.getVendorCodeColumn().ColumnName;
            c_cmbVendor.DataSource = DemoData.GetInstance().VendorDataList;

            if (!BindDetailInfoData())
            {
                return false;
            }

            return true;
        }

        private bool LoadData()
        {
            return true;
        }

        private bool BindDetailInfoData()
        {
            c_txtDetailInfo.Text = "";
            StringBuilder sb = new StringBuilder();
            foreach (TblMWTxnDetail data in DemoData.GetInstance().TxnDetailList)
            {
                sb.AppendLine("" +
                    "货箱编号：" + data.CrateCode + " ");
                sb.AppendLine("" +
                    "收集医院：" + data.Vendor + "  " +
                    "收集废料：" + data.Waste + " " +
                    "收集重量：" + data.SubWeight);
                sb.AppendLine("===========================");
                sb.AppendLine();
            }

            c_txtDetailInfo.Text = sb.ToString();

            return true;
        }

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "货箱扫描";
        }

        #endregion

      

        #region Form Data Property

        #endregion
    }
}
