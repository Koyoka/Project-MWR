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
using ComLib.db.mysql.Update;
using System.Threading;

namespace DBUpdate
{
    public partial class FrmMain : Form
    {
        private const string ClassName = "DBUpdate.FrmMain";
        private FormMng _frmMng = null;
        private XmlMng _xmlMng = null;

        private List<MdlDBInfo> _dbInfoList = null;
        private MdlDBInfo _curDBInfo = null;
        private MdlDBInfo _LastDbInfo = null;

        public FrmMain()
        {
            InitializeComponent();
            this.Text = LngRes.MSG_FormName;
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

        private void c_btnCreateConn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (FrmCreatConn f = new FrmCreatConn())
                {
                    if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        MdlDBInfo dbInfo = f.Output();
                        _dbInfoList.Add(dbInfo);
                        c_treConn.Nodes.Add(TreeDataBind_CreateNode(dbInfo));
                    }
                }
                
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnCreateConn_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_treConn_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (c_treConn.SelectedNode == null)
                {
                    c_btnUpdate.Enabled = false;
                    return;
                }

                c_btnUpdate.Enabled = true;
                MdlDBInfo dbInfo =
                    _dbInfoList[c_treConn.SelectedNode.Index];
                c_txtConnName.Text = dbInfo.ConnName;
                c_txtDBName.Text = dbInfo.DBName;
                c_txtService.Text = dbInfo.Service;
                c_txtSqlPath.Text = dbInfo.SqlPath;
                _curDBInfo = dbInfo;
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_treConn_AfterSelect", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (_curDBInfo == null)
                    return;

                string errMsg = "";
                if (!_xmlMng.EditFormInfoNode(_curDBInfo, ref errMsg))
                {
                    MsgBox.Show(errMsg);
                    return;
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMain_FormClosing", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnModifyDBInfo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //_curDBInfo;
                using (FrmCreatConn f = new FrmCreatConn(_curDBInfo))
                {
                    if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        MdlDBInfo dbInfo = f.Output();
                        //_dbInfoList.Add(dbInfo);
                        //c_treConn.Nodes.Add(TreeDataBind_CreateNode(dbInfo));
                        c_treConn.SelectedNode.Text = dbInfo.ConnName + " " + dbInfo.DBName + "@" + dbInfo.Service;
                        c_txtConnName.Text = dbInfo.ConnName;
                        c_txtDBName.Text = dbInfo.DBName;
                        c_txtService.Text = dbInfo.Service;
                        c_txtSqlPath.Text = dbInfo.SqlPath;
                        _curDBInfo = dbInfo;
                    }
                }

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnModifyDBInfo_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private Thread _tread = null;
        private void c_btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (_tread != null)
                {
                    MsgBox.Show("执行更新中");
                    return;
                }
                #region
                string errMsg = "";

                richTextBox1.Text = "";
                richTextBox1.Refresh();
                MySqlDBUpdate dbUpdate = MySqlDBUpdate.GetInstance(false);

                #region print output
                dbUpdate.SetPrint((x) =>
                {
                    ThreadSafe(() =>
                    {
                        int strat = 0;
                        int length = 0;
                        Color c = new Color();
                        string s =
                        ComLib.db.mysql.Update.MySqlDBUpdate.DoUpdateHelper.GetColorOutput(x, ref strat, ref length, ref c);
                        int orgLength = richTextBox1.Text.Length;
                        richTextBox1.AppendText(s);
                        richTextBox1.SelectionStart = strat + orgLength;
                        richTextBox1.SelectionLength = length;
                        richTextBox1.SelectionColor = c;
                    });
                }, (x) =>
                {
                    ThreadSafe(() =>
                    {
                        int strat = 0;
                        int length = 0;
                        Color c = new Color();
                        string s =
                        ComLib.db.mysql.Update.MySqlDBUpdate.DoUpdateHelper.GetColorOutput(x, ref strat, ref length, ref c);
                        int orgLength = richTextBox1.Text.Length;
                        richTextBox1.AppendText(s);
                        richTextBox1.SelectionStart = strat + orgLength;
                        richTextBox1.SelectionLength = length;
                        richTextBox1.SelectionColor = c;
                    });
                });
                #endregion

                #region run thread
                string dbName, dbService, dbUser, dbPassword, dbPort, path;
                dbName = _curDBInfo.DBName;
                dbService = _curDBInfo.Service;
                dbUser = _curDBInfo.Uid;
                dbPassword = _curDBInfo.Password;
                dbPort = _curDBInfo.Port;
                path = _curDBInfo.SqlPath;//WinAppFn.GetSettingFolder() + "cdcs.sql";

                _tread = new Thread(() => { 
                    

                    if (!dbUpdate.DoUpdate(dbName, dbService, dbUser, dbPassword, dbPort, path, ref errMsg))
                    {
                        MessageBox.Show(errMsg);
                    }
                    _tread = null;
                });
                _tread.Start();
                #endregion

                #endregion
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnUpdate_Click", ex);
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
            string errMsg = "";
            _xmlMng = new XmlMng("DBInfo.xml");
            if (!_xmlMng.XmlInit(ref errMsg))
            {
                MsgBox.Show(errMsg);
                return false;
            }

            if (!LoadData())
                return false;



            return true;
        }
        
        private bool InitCtrls()
        {
            DBConnTreeDataBind();

           
            return true;
        }

        private void DBConnTreeDataBind()
        {
            TreeNode lastnode = null;
            foreach (var item in _dbInfoList)
            {
                TreeNode node =
                    TreeDataBind_CreateNode(item);
                //node.ForeColor = Color.Gray;
                c_treConn.Nodes.Add(node);
                if (
                    _LastDbInfo != null
                    && item.Id.Equals(_LastDbInfo.Id)
                    //&& item.Service.Equals(_LastDbInfo.Service)
                    //&& item.DBName.Equals(_LastDbInfo.DBName)
                    //&& item.SqlPath.Equals(_LastDbInfo.SqlPath)
                    )
                {
                    lastnode = node;
                }
                
            }
            if (lastnode != null)
                c_treConn.SelectedNode = lastnode;
           
        }
        private TreeNode TreeDataBind_CreateNode(MdlDBInfo item)
        { 
            TreeNode node = new TreeNode(item.ConnName + " " + item.DBName + "@" +item.Service);
            return node;
        }
        private bool LoadData()
        {
            string errMsg = "";
            if (!_xmlMng.GetFormInfo(ref _LastDbInfo, ref errMsg))
            {
                MsgBox.Show(errMsg);
            }

            if (!LoadData_DBConn(ref errMsg))
            {
                MsgBox.Show(errMsg);
                return false;
            }
            
            return true;
        }

        private bool LoadData_DBConn(ref string errMsg)
        {
            List<MdlDBInfo> dbInfoList = null;
            if (!_xmlMng.GetDBConnList(ref dbInfoList, ref errMsg))
            {
                _dbInfoList = new List<MdlDBInfo>();
                return false;
            }
            _dbInfoList = dbInfoList;
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
            public const string MSG_FormName = "MySql数据库更新工具 v0.1";
        }

        #endregion

        #region Form Data Property

        #endregion

    }
}
