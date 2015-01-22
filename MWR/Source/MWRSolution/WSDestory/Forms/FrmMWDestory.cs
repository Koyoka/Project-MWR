﻿using System;
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
    public partial class FrmMWDestory : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmMWDestory";
        private FormMng _frmMng = null;

        private FrmMain _frmMain = null;


        public FrmMWDestory()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;
        }

        public FrmMWDestory(FrmMain f)
            : this()
        {
            _frmMain = f;
        }

        #region Event

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
            public const string MSG_FormName = "医疗废物处理";
        }

        #endregion

        private void c_btnDestInv_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _frmMain.ShowFrom(FrmMain.TabToggleEnum.DESTORY_DETAIL, new FrmMWDestoryDetail(_frmMain));

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

                _frmMain.ShowFrom(FrmMain.TabToggleEnum.DESTORY_RECOVER, new FrmMWDestoryRecover(_frmMain));

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

        #region Form Data Property

        #endregion
    }
}