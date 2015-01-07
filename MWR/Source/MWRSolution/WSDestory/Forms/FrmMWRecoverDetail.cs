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

namespace YRKJ.MWR.WSDestory.Forms
{
    public partial class FrmMWRecoverDetail : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmMWRecoverDetail";
        private FormMng _frmMng = null;
        private FrmMain _frmMain = null;



        public FrmMWRecoverDetail()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowInTaskbar = false;
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
        }

        public FrmMWRecoverDetail(FrmMain f)
            : this()
        {
            _frmMain = f;
        }

        #region Event

        private void c_btnStopRecover_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Close();
                _frmMain.ShowFrom(FrmMain.TabToggleEnum.RECOVER);

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
            public const string MSG_FormName = "废物货箱回收";
        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
