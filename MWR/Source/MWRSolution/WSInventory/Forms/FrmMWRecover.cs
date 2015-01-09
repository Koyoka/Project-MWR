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
    public partial class FrmMWRecover : Form
    {
        private const string ClassName = "YRKJ.MWR.WSInventory.Forms.FrmMWRevocer";
        private FormMng _frmMng = null;

        private FrmMain _frmMain = null;

        public FrmMWRecover()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

            //this.c_grdMWRecover.RowHeadersVisible = false;
        }

        public FrmMWRecover(FrmMain f) : this()
        {
            _frmMain = f;
        }

        #region Event

        private void FrmMWRecover_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //WinFn.SafeFocusAndSelectAll(textBox1);

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
                LogMng.GetLog().PrintError(ClassName, "FrmMWRecover_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void ControlActivity()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //WinFn.SafeFocusAndSelectAll(textBox1);

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

        private void c_btnStratRecover_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (_frmMain != null)
                {
                    string defineRecoNum = "WF00001";
                    _frmMain.ShowFrom(FrmMain.TabToggleEnum.RECOVE_RDETAIL, new FrmMWRecoverDetail(_frmMain, defineRecoNum));
                    //FrmMWRecoverDetail f = new FrmMWRecoverDetail();
                    //this.Tag = f;
                    //_frmMain.ShowInMdiForm(f);
                }
               
                //{
                //    //f.ShowDialog();
                //    f.MdiParent = this.MdiParent;
                //    f.WindowState = FormWindowState.Maximized;
                //    //f.Parent = this.Parent;
                //    f.FormBorderStyle = FormBorderStyle.None;
                //    f.Show();
                //}

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnStratRecover_Click", ex);
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
            c_grdMWRecover_C_CarCode.DataPropertyName = "CarCode";
            c_grdMWRecover_C_Driver.DataPropertyName = "Driver";
            c_grdMWRecover_C_Inspector.DataPropertyName = "Inspector";
            c_grdMWRecover_C_TotleCount.DataPropertyName = "TotalCount";
            c_grdMWRecover_C_TotolWeight.DataPropertyName = "TotalWeight";
            c_grdMWRecover_C_OutDate.DataPropertyName = "OutDate";
            c_grdMWRecover_C_InDate.DataPropertyName = "InDate";
            c_grdMWRecover_C_StratDate.DataPropertyName = "StratDate";
            c_grdMWRecover_C_Status.DataPropertyName = "Status";

            c_grdMWRecover.DataSource = _gridMWRecoverData;

            return true;
        }
        BindingList<GridMWRecoverData> _gridMWRecoverData = new BindingList<GridMWRecoverData>();
        private bool LoadData()
        {

            for (int i = 0; i < 4; i++)
            {
                GridMWRecoverData item = new GridMWRecoverData();
                item.CarCode = "A0000" + i;
                item.Driver = "司机" + i;
                item.Inspector = "跟车员";
                item.OutDate = "2015-01-01 12:00:00";
                item.InDate = "2015-01-01 12:00:00";
                item.StratDate = "2015-01-01 12:00:00";
                item.Status = "OK";
                _gridMWRecoverData.Add(item);
            }
            return true;
        }


        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "入库计划";
        }

        private class GridMWRecoverData
        {
            private string _carCode = "";
            public string CarCode
            {
                get { return _carCode; }
                set { _carCode = value; }
            }

            private string _driver = "";
            public string Driver
            {
                get { return _driver; }
                set { _driver = value; }
            }

            private string _inspector = "";
            public string Inspector
            {
                get { return _inspector; }
                set { _inspector = value; }
            }

            private string _outDate = "";
            public string OutDate
            {
                get { return _outDate; }
                set { _outDate = value; }
            }

            private string _inDate = "";
            public string InDate
            {
                get { return _inDate; }
                set { _inDate = value; }
            }

            private string _stratDate = "";
            public string StratDate
            {
                get { return _stratDate; }
                set { _stratDate = value; }
            }

            private string _status = "";
            public string Status
            {
                get { return _status; }
                set { _status = value; }
            }

            private int _totalCount = 0;
            public int TotalCount
            {
                get { return _totalCount; }
                set { _totalCount = value; }
            }

            private float _totalWeight = 0;
            public float TotalWeight
            {
                get { return _totalWeight; }
                set { _totalWeight = value; }
            }
        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
