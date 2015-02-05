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
using YRKJ.MWR.WSDestory.Business.Sys;
using YRKJ.MWR.Business.WS;

namespace YRKJ.MWR.WSDestory.Forms
{
    public partial class FrmMWDestroy : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmMWDestory";
        private FormMng _frmMng = null;

        private FrmMain _frmMain = null;


        FrmMWDestroy()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;
        }

        public FrmMWDestroy(FrmMain f)
            : this()
        {
            _frmMain = f;
        }

        #region Event
        private void FrmMWDestory_Load(object sender, EventArgs e)
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

                c_time.Start();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWDestory_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FrmMWDestory_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                c_time.Stop();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWDestory_FormClosing", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnDestInv_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _frmMain.ShowFrom(FrmMain.TabToggleEnum.DESTORY_DETAIL, new FrmMWDestroyDetail(_frmMain));

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnDestInv_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnDestRecover_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _frmMain.ShowFrom(FrmMain.TabToggleEnum.DESTORY_RECOVER, new FrmMWDestroyRecover(_frmMain));

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnDestRecover_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_bgwRecoverToDest_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                string errMsg = "";
                int count = 0;
                string wscode = SysInfo.GetInstance().Config.WSCode;
                if (!TxnMng.GetGetRecoverToDestroyTxnCount(wscode, ref count, ref errMsg))
                {
                    return;
                }
                ThreadSafe(() =>
                {
                    c_labRecoverTxnCount.Visible = count != 0 ? true : false;
                    c_labRecoverTxnCount.Text = count + "";
                    BroadcastMng.GetInstance().Send(SysInfo.Broadcast_RecoverTxnCount, new BroadcastMng.BroadcastMessage
                    {
                        Message = count,
                        Data = count
                    });
                });

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_bgwRecoverToDest_DoWork", ex);
            }
            finally
            {
            }
        }

        private void c_time_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!c_bgwRecoverToDest.IsBusy)
                    c_bgwRecoverToDest.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_time_Tick", ex);
            }
            finally
            {
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

        private void ThreadSafe(MethodInvoker method)
        {
            //try
            //{
            if (this.InvokeRequired)
            {
                this.Invoke(method);
            }
            else
            {
                method();
            }
            //}
            //catch (Exception ex)
            //{ }
        }

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "医疗废物处理";
        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
