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

namespace YRKJ.MWR.WSInventory.Forms
{
    public partial class FrmInventorySearch : Form
    {
        private const string ClassName = "YRKJ.MWR.WSInventory.Forms.FrmInventorySearch";
        private FormMng _frmMng = null;

        public FrmInventorySearch()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;
        } 

        #region Event

        private void FrmInventorySearch_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //WinFn.SafeFocusAndSelectAll(textBox1);

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmInventorySearch_Load", ex);
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
            public const string MSG_FormName = "出入库查询";
        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
