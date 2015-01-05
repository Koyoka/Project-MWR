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
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "系统初始化";
        }

        #region Events

        private void FrmInitConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void c_btnCancel_Click(object sender, EventArgs e)
        {
            LogMng.GetLog().PrintInfo(ClassName, "GetDefaultLogo","cc");
            this.Close();
        }

        private void c_btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c_btnDefaultPwd_Click(object sender, EventArgs e)
        {

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

        #endregion

        #region Common

        #endregion

        #region Form Data Property

        #endregion


    }
}
