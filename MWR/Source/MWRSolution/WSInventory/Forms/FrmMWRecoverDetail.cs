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
using YRKJ.MWR.WinBase.WinUtility;

namespace YRKJ.MWR.WSInventory.Forms
{
    public partial class FrmMWRecoverDetail : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmMWRecoverDetail";
        private FormMng _frmMng = null;
        private FrmMain _frmMain = null;
        private ScannerMng _scannerMng = null;
        private string _recoNum = "";
       
        public FrmMWRecoverDetail()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          
        }

        public FrmMWRecoverDetail(FrmMain f, string recoNum)
            : this()
        {
            _frmMain = f;
            _recoNum = recoNum;

            _scannerMng = new ScannerMng(this, ClassName, WinAppStatic.BarCodeMask);
            _scannerMng.CodeScanned += new ScannerMng.ScannedEventHandler(FrmMWRecoverDetail_CodeScanned);
            _scannerMng.InvalidCodeScanned += new ScannerMng.ScannedEventHandler(FrmMWRecoverDetail_InvalidCodeScanned);
        }

        #region Event

        private void FrmMWRecoverDetail_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmMWRecoverDetail_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FrmMWRecoverDetail_InvalidCodeScanned(string code)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //MsgBox.Show(LngRes.MSG_InvalidBarCode + " " + code);
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWRecoverDetail_InvalidCodeScanned", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void FrmMWRecoverDetail_CodeScanned(string code)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                c_txtCrateCode.Text = code;
                using (FrmMWCrateView f = new FrmMWCrateView(code))
                {
                    f.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWRecoverDetail_CodeScanned", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnRecover_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.Close();
                if (_frmMain != null)
                {
                    _frmMain.ShowFrom(FrmMain.TabToggleEnum.RECOVER);
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnRecover_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnStopRecover_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Close();
                if (_frmMain != null)
                {
                    _frmMain.ShowFrom(FrmMain.TabToggleEnum.RECOVER);
                }

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnStopRecover_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnSelectDepot_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (Dtl.FrmDepotDtl f = new Dtl.FrmDepotDtl())
                {
                    f.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnSelectDepot_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnManually_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (FrmMWCrateView f = new FrmMWCrateView())
                {
                    f.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnManually_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (FrmMWCrateReview f = new FrmMWCrateReview())
                {
                    f.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnCheck_Click", ex);
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
            c_grpRecoInfo.Text += "-" + _recoNum; 

            return true;
        }

        private bool LoadData()
        {
            return true;
        }

        public void ControlActivity()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.Focus();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "ControlActivity", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "废物货箱回收";
            public const string MSG_InvalidBarCode = "无效的条形码，请重新扫描";
        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
