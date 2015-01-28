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
using YRKJ.MWR.WSInventory.Business.Sys;

namespace YRKJ.MWR.WSInventory.Forms
{
    public partial class FrmMWPost : Form
    {
        private const string ClassName = "YRKJ.MWR.WSInventory.Forms.FrmMWPost";
        private FormMng _frmMng = null;

        private FrmMain _frmMain = null;

        public FrmMWPost()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

        }

        public FrmMWPost(FrmMain f)
            : this()
        {
            _frmMain = f;
        }

        #region Event

        private void FrmMWPost_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmMWPost_Load", ex);
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
            YRKJ.MWR.WinBase.WinUtility.BroadcastMng.GetInstance().Listen(SysInfo.Broadcast_RecoverTxnCount, (x) =>
            {
                this.c_labTxnCount.Text = x.Data.ToString();
            });

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
            public const string MSG_FormName = "出库计划";
        }

        #endregion

        private void c_btnStratPost_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_frmMain != null)
                {
                    _frmMain.ShowFrom(FrmMain.TabToggleEnum.POST_DETAIL,
                        new FrmMWPostDetail(_frmMain, FrmMWPostDetail.PostTypeEnum.Nocare));
                } 
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnStratPost_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnStratCheckPost_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_frmMain != null)
                {
                    _frmMain.ShowFrom(FrmMain.TabToggleEnum.POST_DETAIL,
                        new FrmMWPostDetail(_frmMain, FrmMWPostDetail.PostTypeEnum.Normal));
                } 
                
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnStratCheckPost_Click", ex);
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

                if (_frmMain != null)
                {
                    _frmMain.ShowFrom(FrmMain.TabToggleEnum.POST_DETAIL,new FrmMWPostDetail(_frmMain,"Eleven9000"));
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

        #region Form Data Property

        #endregion
    }
}
