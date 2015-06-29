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
using YRKJ.MWR.WSDestory.Business.Sys;
using YRKJ.MWR.Business.Permit;
using YRKJ.MWR.WinBase.WinUtility;

namespace YRKJ.MWR.WSDestory.Forms
{
    public partial class FrmLogin : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmLogin";
        private FormMng _frmMng = null;

        public FrmLogin()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName, FormMng.EscExistEnum.YES);
            this.Text = LngRes.MSG_FormName;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        } 

        #region Event

        private void c_btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string errMsg = "";

                TblMWEmploy empy = null;
                string code = c_txtUserId.Text.Trim();
                string password = c_txtPassword.Text;
                if (!PermitMng.WSDLogin(code, password, ref errMsg))
                {
                    WinFn.SafeFocus(c_txtUserId);
                    MsgBox.Error(errMsg);
                    return;
                }
                if (!BaseDataMng.GetEmpyData(code, ref empy, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
                }
                if (empy == null)
                {
                    MsgBox.Show(LngRes.MSG_InvalidEmpy);
                    return;
                }
                SysInfo.GetInstance().Employ = empy;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnLogin_Click", ex);
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
            public const string MSG_FormName = "用户登录";
            public const string MSG_InvalidEmpy = "无效的用户登录";
        }

        #endregion

       
        #region Form Data Property

        #endregion


    }
}
