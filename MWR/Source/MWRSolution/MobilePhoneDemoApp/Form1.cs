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

namespace MobilePhoneDemoApp
{
    public partial class Form1 : Form
    {
        private const string ClassName = "MobilePhoneDemoApp.Form1";
        private FormMng _frmMng = null;

        public Form1()
        {
            InitializeComponent();
            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ControlBox = false;
        } 

        #region Event
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (FrmScanner f = new FrmScanner())
                {
                    this.Visible = false;
                    f.ShowDialog();
                    this.Visible = true;
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "button1_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Close();
                
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "button5_Click", ex);
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
            c_labDriver.Text = DemoData.GetInstance().Driver;
            c_labInspector.Text = DemoData.GetInstance().Inspector;
            c_labMWSCode.Text = DemoData.GetInstance().MWSCode;

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
            public const string MSG_FormName = "手机终端模拟器";
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "Form1_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "button2_Click", ex);
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
