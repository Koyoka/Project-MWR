using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBUpdate.WinAppBase;
using ComLib.Log;
using DBUpdate.Mng;
using DBUpdate.Module;

namespace DBUpdate
{
    public partial class FrmCreatConn : Form
    {
        private const string ClassName = "DBUpdate.FrmCreatConn";
        private FormMng _frmMng = null;
        private MdlDBInfo _dbInfo = null;

        public FrmCreatConn()
        {
            InitializeComponent();
            this.Text = LngRes.MSG_FormName;
        } 

        #region Event
        private void FrmCreatConn_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmCreatConn_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnDefaultPassword_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.c_txtPassword.Text = "-101868";
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnDefaultPassword_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_txtLocService_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.c_txtService.Text = "127.0.0.1";
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_txtLocService_Click", ex);
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

        private void c_btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string errMsg = "";

                MdlDBInfo dbInfo = new MdlDBInfo() { 
                    ConnName = c_txtConnName.Text,
                    Service = c_txtService.Text,
                    Uid = c_txtUid.Text,
                    Password = c_txtPassword.Text,
                    Port = c_txtPort.Text,
                    DBName = c_cmbDB.SelectedItem.ToString(),
                    SqlPath = c_txtSqlPath.Text
                };
                _dbInfo = dbInfo;
                if (string.IsNullOrEmpty(dbInfo.ConnName))
                {
                    MsgBox.Show("请填写连接名称");
                    return;
                }

                XmlMng xmlMng = new XmlMng("DBInfo.xml");
                if (!xmlMng.XmlInit(ref errMsg))
                {
                    MsgBox.Show(errMsg);
                    return;
                }

                if (!xmlMng.AddNewNode(dbInfo, ref errMsg))
                {
                    MsgBox.Show(errMsg);
                    return;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnCreate_Click", ex);
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

                string service = this.c_txtService.Text;
                string uid = this.c_txtUid.Text;
                string password = this.c_txtPassword.Text;
                string port = this.c_txtPort.Text;

                if (!DBMng.DetectDBConn( service, uid, password, port, ref errMsg))
                {
                    MsgBox.Show(errMsg);
                    SetFocus();
                }
                else
                {
                   
                    
                    MsgBox.Show("连接成功");
                    SetStep(EnumStep.ConnDBDone);
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

        private void c_txtSqlPath_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (c_ofdSqlPath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.c_txtSqlPath.Text =
                    c_ofdSqlPath.FileName;
                }

                if (c_cmbDB.SelectedItem.ToString() != "" && c_txtSqlPath.Text != "")
                {
                    SetStep(EnumStep.SelectDBDone);
                }

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_txtSqlPath_Click", ex);
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
            c_txtSqlPath.ReadOnly = true;
            SetStep(EnumStep.Init);
            return true;
        }

        private bool LoadData()
        {
            return true;
        }

        private enum EnumStep
        { 
            Init,ConnDBDone,SelectDBDone
        }
        EnumStep _step = EnumStep.Init;
        private void SetStep(EnumStep step)
        {
            switch (step)
            { 
                case EnumStep.Init:
                    c_grbTabInfo.Enabled = false;
                    c_btnCreate.Enabled = false;
                    
                    break;
                case  EnumStep.ConnDBDone:
                    c_grbTabInfo.Enabled = true;
                    BindDBInfo();
                    break;
                case EnumStep.SelectDBDone:
                    c_btnCreate.Enabled = true;
                    break;
            }
            _step = step;
        }

        private void SetFocus()
        {
            switch (_step)
            {
                case EnumStep.Init:
                    c_txtService.Focus();
                    break;
                case EnumStep.ConnDBDone:
                    c_cmbDB.Focus();
                    break;
                case EnumStep.SelectDBDone:
                    c_txtConnName.Focus();
                    break;
            }
        }

        private void BindDBInfo()
        {
            string errMsg = "";

            string service = this.c_txtService.Text;
            string uid = this.c_txtUid.Text;
            string password = this.c_txtPassword.Text;
            string port = this.c_txtPort.Text;
            string connStr = ComLib.db.SqlDBMng.GetConnStr(service, uid, password, port);

            DBMng dbMng = new DBMng(connStr);

            List<string> dbInfoList = null;
            if (!dbMng.GetDBNameList(ref dbInfoList, ref errMsg))
            {
                MsgBox.Show(errMsg);
                return;
            }

            c_cmbDB.DataSource = dbInfoList;
        }

        public MdlDBInfo Output()
        {
            return _dbInfo;
        }
        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "创建新连接";
        }

        #endregion

        

        

      

        #region Form Data Property

        #endregion
    }
}
