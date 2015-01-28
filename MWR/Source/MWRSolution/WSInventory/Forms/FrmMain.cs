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
using YRKJ.MWR.WSInventory.Business.Sys;
using YRKJ.MWR.WinBase.WinUtility;

namespace YRKJ.MWR.WSInventory.Forms
{
    public partial class FrmMain : Form
    {
        private const string ClassName = "YRKJ.MWR.WSInventory.Forms.FrmMain";
        private FormMng _frmMng = null;

        private Control[] _tabBgCtrl = null;
        private List<Form> _childForms = new List<Form>();
        private Form _curForm = null;

        public enum TabToggleEnum { RECOVER, POST, SEARCH, RECOVE_RDETAIL, POST_DETAIL}

        public FrmMain()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            c_labRecoverTxnCount.Visible = false;
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
        }

        #region Event

        private void FrmMain_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmMain_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.Close();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnLogout_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnMWRecover_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                
                ShowFrom(TabToggleEnum.RECOVER);

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnMWRecover_CLick", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnMWPost_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ShowFrom(TabToggleEnum.POST);
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnMWPost_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnInvSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ShowFrom(TabToggleEnum.SEARCH);
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnInvSearch_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        //private void c_panForm_Resize(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;

        //        if (_curForm == null)
        //        {
        //            return;
        //        }

        //        //foreach (Form f in this.c_panForm.Controls)
        //        //{
        //        //    f.Hide();
        //        //}
        //        //this.c_panForm.Controls.Clear();
        //        //resizeMdiForm(_curForm);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogMng.GetLog().PrintError(ClassName, "c_panForm_Resize", ex);
        //        MsgBox.Error(ex);
        //    }
        //    finally
        //    {
        //        this.Cursor = Cursors.Default;
        //    }
        //}

        #endregion

        #region Functions

        private bool InitFrm()
        {
            try
            {

                if (!LoadData())
                    return false;

                BroadcastMng.GetInstance().Listen(SysInfo.Broadcast_RecoverTxnCount, (x) =>
                {
                    this.c_labRecoverTxnCount.Visible = x.Message == 0 ? false : true;
                    this.c_labRecoverTxnCount.Text = x.Data.ToString();
                });

                _tabBgCtrl = new Control[] { c_labBg1, c_labBg2, c_labBg3 };

                ShowFrom(TabToggleEnum.RECOVER); 
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "InitFrm", ex);
                MsgBox.Error(ex);
                return false;
            }
            finally
            {
            }

            return true;
        }

        private bool InitCtrls()
        {
            try
            {
               
                
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "InitCtrls", ex);
                MsgBox.Error(ex);
                return false;
            }
            finally
            {
            }
            return true; 
        }

        private bool LoadData()
        {
            try
            {

                
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "LoadData", ex);
                MsgBox.Error(ex);
                return false;
            }
            finally
            {
               
            }
            return true;
        }

        public void ShowFrom(TabToggleEnum tabToggle)
        {
            ShowFrom(tabToggle, null);
        }
        public void ShowFrom(TabToggleEnum tabToggle,Form defineForm)
        {
            #region show current tab bg
            if (
                (tabToggle == TabToggleEnum.RECOVER
                || tabToggle == TabToggleEnum.POST
                || tabToggle == TabToggleEnum.SEARCH
                )
                && _tabBgCtrl != null && _tabBgCtrl.Length == 3)
            {
                int tabIndex = 0;

                switch (tabToggle)
                {
                    case TabToggleEnum.RECOVER:
                        tabIndex = 0;
                        break;
                    case TabToggleEnum.POST:
                        tabIndex = 1;
                        break;
                    case TabToggleEnum.SEARCH:
                        tabIndex = 2;
                        break;
                }

                foreach (Control ctrl in _tabBgCtrl)
                {
                    if (ctrl.Name != _tabBgCtrl[tabIndex].Name)
                    {
                        ctrl.Visible = false;
                    }
                    else if (!ctrl.Visible)
                    {
                        ctrl.Visible = true;
                    }
                }
            }
            #endregion

            #region remove dispose form

            for (int i = 0; i < _childForms.Count; i++)
            {
                Form f = _childForms[i];
                if (f.IsDisposed)
                {
                    _childForms.Remove(f);
                    i--;
                }
            }

            #endregion

            #region has been open detail form

            if (tabToggle == TabToggleEnum.RECOVER)
            {
                foreach (Form f in this.c_panForm.Controls)
                {
                    if (f is FrmMWRecoverDetail)
                    {
                        ShowFrom(TabToggleEnum.RECOVE_RDETAIL);
                        return;
                    }
                }
            }
            else if (tabToggle == TabToggleEnum.POST)
            {
                foreach (Form f in this.c_panForm.Controls)
                {
                    if (f is FrmMWPostDetail)
                    {
                        ShowFrom(TabToggleEnum.POST_DETAIL);
                        return;
                    }
                }
            }

            #endregion

            #region has been add mdi controls
            foreach (Form f in this.c_panForm.Controls)
            {
                if (tabToggle == TabToggleEnum.RECOVER
                    && f is FrmMWRecover)
                {
                    _curForm = f;
                    f.BringToFront();
                    (f as FrmMWRecover).ControlActivity();
                    return;
                }
                else if (tabToggle == TabToggleEnum.POST
                   && f is FrmMWPost)
                {
                    _curForm = f;
                    f.BringToFront();
                    (f as FrmMWPost).ControlActivity();
                    return;
                }
                else if (tabToggle == TabToggleEnum.SEARCH
                    && f is FrmInventorySearch)
                {
                    _curForm = f;
                    f.BringToFront();
                    (f as FrmInventorySearch).ControlActivity();
                    return;
                }
                else if (tabToggle == TabToggleEnum.RECOVE_RDETAIL
                    && f is FrmMWRecoverDetail)
                {
                    _curForm = f;
                    f.BringToFront();
                    (f as FrmMWRecoverDetail).ControlActivity();
                    return;
                }
                else if (tabToggle == TabToggleEnum.POST_DETAIL
                   && f is FrmMWPostDetail)
                {
                    _curForm = f;
                    f.BringToFront();
                    (f as FrmMWPostDetail).ControlActivity();
                    return;
                }

            }
            #endregion

            #region has clear all because resize mdi control
            //foreach (Form f in _childForms)
            //{

            //    if (tabToggle == TabToggleEnum.RECOVER
            //        && f is FrmMWRecover)
            //    {
            //        _curForm = f;
            //        resizeMdiForm(f);
            //        (f as FrmMWRecover).ControlActivity();
            //        return;
            //    }
            //    else if (tabToggle == TabToggleEnum.POST
            //       && f is FrmMWPost)
            //    {
            //        _curForm = f;
            //        resizeMdiForm(f);
            //        (f as FrmMWPost).ControlActivity();
            //        return;
            //    }
            //    else if (tabToggle == TabToggleEnum.SEARCH
            //        && f is FrmInventorySearch)
            //    {
            //        _curForm = f;
            //        resizeMdiForm(f);
            //        (f as FrmInventorySearch).ControlActivity();
            //        return;
            //    }
            //    else if (tabToggle == TabToggleEnum.RECOVE_RDETAIL
            //        && f is FrmMWRecoverDetail)
            //    {
            //        _curForm = f;
            //        resizeMdiForm(f);
            //        (f as FrmMWRecoverDetail).ControlActivity();
            //        return;
            //    }
            //    else if (tabToggle == TabToggleEnum.POST_DETAIL
            //       && f is FrmMWPostDetail)
            //    {
            //        _curForm = f;
            //        resizeMdiForm(f);
            //        (f as FrmMWPostDetail).ControlActivity();
            //        return;
            //    }
            //}
            #endregion

            #region add new form to mdi control
            {
                Form f;
                if (defineForm != null)
                {
                    f = defineForm;
                }
                else
                {
                    switch (tabToggle)
                    {
                        case TabToggleEnum.RECOVER:
                            f = new FrmMWRecover(this);
                            break;
                        case TabToggleEnum.POST:
                            f = new FrmMWPost(this);
                            break;
                        case TabToggleEnum.SEARCH:
                            f = new FrmInventorySearch();
                            break;
                        case TabToggleEnum.RECOVE_RDETAIL:
                            f = new FrmMWRecoverDetail();
                            break;
                        case TabToggleEnum.POST_DETAIL:
                            f = new FrmMWPostDetail();
                            break;
                        default:
                            return;
                    }
                }
                
                f.MdiParent = this;
                f.WindowState = FormWindowState.Normal;
                f.Parent = this.c_panForm;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Show();
                f.Dock = DockStyle.Fill;
                f.BringToFront();
                f.Focus();
                _curForm = f;
                _childForms.Add(f);
            }

            #endregion
        }

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "医疗废物库存工作站";
            public const string MSG_DoingRecover = "正在进行回收处理";
        }

        #endregion

        #region Form Data Property

        #endregion

    }
}
