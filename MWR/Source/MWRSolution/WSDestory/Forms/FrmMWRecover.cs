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

namespace YRKJ.MWR.WSDestory.Forms
{
    public partial class FrmMWRecover : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmMWRevocer";
        private FormMng _frmMng = null;

        public FrmMWRecover()
        {
            InitializeComponent();
        }

        #region Event

        private void FrmMWRecover_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                WinFn.SafeFocusAndSelectAll(textBox1);

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
                WinFn.SafeFocusAndSelectAll(textBox1);

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
            public const string MSG_FormName = "入库计划";
        }

        #endregion




        #region Form Data Property

        #endregion
    }
}
