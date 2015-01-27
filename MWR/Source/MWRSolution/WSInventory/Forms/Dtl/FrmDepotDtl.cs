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
using YRKJ.MWR.Business.BaseData;
using YRKJ.MWR.WSInventory.Business.Sys;

namespace YRKJ.MWR.WSInventory.Forms.Dtl
{
    public partial class FrmDepotDtl : Form
    {
        private const string ClassName = "YRKJ.MWR.WSInventory.Forms.Dtl.FrmDepotDtl";
        private FormMng _frmMng = null;
        private TblMWDepot _selectDepot = null;

        private BindingList<GridDepotData> _gridDepotDataList = new BindingList<GridDepotData>();

        public FrmDepotDtl()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName, FormMng.EscExistEnum.YES);
            this.Text = LngRes.MSG_FormName;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowInTaskbar = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        #region Event
        private void FrmDepotDtl_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmDepotDtl_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string errMsg = "";

                List<TblMWDepot> dataList = null;
                if (!SysCacheData.GetInstance().GetDepotList(ref dataList, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return ;
                }
                string code = (this.c_grdDepot.CurrentRow.DataBoundItem as GridDepotData).DeptCode;
                _selectDepot = 
                    dataList.Where(x => x.DeptCode == code).First();

                //string code = (this.c_grdDepot.CurrentRow.DataBoundItem as GridDepotData).DeptCode;
                //_selectDepot =
                    //_gridDepotDataList.Where(x => x.DeptCode == "").First();
                    //this.c_grdDepot.CurrentRow.DataBoundItem as GridDepotData;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnOk_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.Close();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnCancel_Click", ex);
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
            c_grdDepot_C_DepotCode.DataPropertyName = "DeptCode";
            c_grdDepot_C_Desc.DataPropertyName = "Desc";

            c_grdDepot.DataSource = _gridDepotDataList;
            return true;
        }

        private bool LoadData()
        {
            string errMsg = "";

            List<TblMWDepot> dataList = null;
            if (!SysCacheData.GetInstance().GetDepotList(ref dataList, ref errMsg))
            {
                MsgBox.Error(errMsg);
                return false;
            }
           
            foreach (TblMWDepot data in dataList)
            {
                _gridDepotDataList.Add(new GridDepotData() { 
                    DeptCode = data.DeptCode,
                    Desc = data.Desc
                });
            }
           

            return true;
        }

        public TblMWDepot GetSelectDepot()
        {
            return _selectDepot;
        }

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "仓库列表";
        }

        private class GridDepotData
        {
            private string _deptCode = "";
            public string DeptCode
            {
                get { return _deptCode; }
                set { _deptCode = value; }
            }

            private string _desc = "";
            public string Desc
            {
                get { return _desc; }
                set { _desc = value; }
            }
        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
