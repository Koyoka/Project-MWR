using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YRKJ.MWR.WinBase.WinAppBase;
using YRKJ.MWR.Business.Sys;
using ComLib.Log;
using YRKJ.MWR.WinBase.WinAppBase.Config;

namespace MWRSyncMng
{
    public partial class FrmSetting : Form
    {
        private const string ClassName = "MWRSyncMng.FrmSetting";
        private FormMng _frmMng = null;

        public FrmSetting()
        {
            InitializeComponent();
        } 

        #region Event
        private void FrmSetting_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmSetting_Load", ex);
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
                #region
                if (!MWParams.SetSyncCity(c_txtSyncCity.Text.Trim(), ref errMsg))
                {
                    MessageBox.Show(errMsg);
                    return;
                }
                #endregion
                SysInfo.GetInstance().Config.ServiceRoot = c_txtWebService.Text;
                AppConfig cfg = SysInfo.GetInstance().Config;
                if (!ConfigMng.SaveAppConfig(cfg, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
                }
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
            c_txtSyncCity.Text = MWParams.GetSyncCity();
            c_txtWebService.Text = SysInfo.GetInstance().Config.ServiceRoot;
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
            public const string MSG_FormName = "";
        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
