using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YRKJ.MWR.WinBase.WinAppBase.Config;
using ComLib.Log;
using YRKJ.MWR.WinBase.WinUtility;

namespace YRKJ.MWR.WinBase.WinAppBase.BaseForm
{
    public partial class FrmInitConfig : Form
    {
        private const string ClassName = "YRKJ.MWR.WinBase.WinAppBase.BaseForm.FrmInitConfig";
        private FormMng _frmMng = null;


        public FrmInitConfig()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
           
        }

        #region Events

        private void FrmInitConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.KeyChar == (char)Keys.Escape)
                {
                    this.Close();
                } 
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmInitConfig_KeyPress", ex);
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
                LogMng.GetLog().PrintError(ClassName, "c_btnCancel_CLick", ex);
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

                AppConfig cfg = GetCfgDataFromControl();

                #region valid db config
                if (!ComLib.db.SqlDBMng.DetectDBServer(WinAppBase.DBName, cfg.DBServerName, cfg.DBUserName, cfg.DBPassword, ref errMsg))
                {
                    MsgBox.Error(LngRes.MSG_DetectDBError);
                    WinFn.SafeFocusAndSelectAll(c_txtService);
                    return;
                }
                #endregion

                #region save config
                if (!ConfigMng.SaveAppConfig(cfg, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
                }
                #endregion

                MsgBox.Show(LngRes.MSG_ConfigDone);

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

        private void c_btnDetectDB_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string errMsg = "";

                AppConfig cfg = GetCfgDataFromControl();
                if (!ComLib.db.SqlDBMng.DetectDBServer(WinAppBase.DBName, cfg.DBServerName, cfg.DBUserName, cfg.DBPassword, ref errMsg))
                {
                    MsgBox.Error(LngRes.MSG_DetectDBError);
                    WinFn.SafeFocusAndSelectAll(c_txtService);
                }
                else
                {
                    MsgBox.Show(LngRes.MSG_DetectDBSuccess);
                    WinFn.SafeFocus(c_btnOk);
                }

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnDetectDB_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnDefaultPwd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.c_txtPassword.Text = ComLib.ComFn.DecryptDBPassword(WinAppBase.DBKey, WinAppBase.DefaultEPassword); 
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnDefaultPwd_Click", ex);
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
            string errMsg = "";

            AppConfig cfg = null;

            if (!ConfigMng.ReadAppConfig(ref cfg, ref errMsg))
            {
                return false;
            }

            c_txtService.Text = cfg.DBServerName;
            c_txtUserId.Text = cfg.DBUserName;
            c_txtPassword.Text = cfg.DBPassword;

            return true;
        }

        private bool LoadData()
        {
            return true;
        }

        private AppConfig GetCfgDataFromControl()
        {
            AppConfig cfg = new AppConfig();
            cfg.DBServerName = c_txtService.Text.Trim();
            cfg.DBUserName = c_txtUserId.Text.Trim();
            cfg.DBPassword = c_txtPassword.Text;
            return cfg;
        }

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "系统初始化";
            public const string MSG_DetectDBError = "数据库连接失败";
            public const string MSG_DetectDBSuccess = "连接成功";
            public const string MSG_ConfigDone = "配置成功";
        }
        #endregion

        #region Form Data Property

        #endregion


    }
}
