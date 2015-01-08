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

namespace YRKJ.MWR.WSDestory.Forms
{
    public partial class FrmMWPostDetail : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmPostDetail";
        private FormMng _frmMng = null;

        private FrmMain _frmMain = null;

        public enum PostTypeEnum { Nocare, Normal,Edit }
        private PostTypeEnum _postType = PostTypeEnum.Nocare;
        private string _editPostNum = "";

        public FrmMWPostDetail()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;


        }
         public FrmMWPostDetail(FrmMain f, PostTypeEnum postType)
            : this()
        {
            _frmMain = f;
            _postType = postType;
        }
        public FrmMWPostDetail(FrmMain f, string editPostNum)
            : this()
        {
            _frmMain = f;
            _editPostNum = editPostNum;
            _postType= PostTypeEnum.Edit;
        }

        #region Event


        private void c_btnStopPost_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.Close();
                _frmMain.ShowFrom(FrmMain.TabToggleEnum.POST);
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnStopPost_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.Close();
                _frmMain.ShowFrom(FrmMain.TabToggleEnum.POST);
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnPost_Click", ex);
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
            

            if (_postType == PostTypeEnum.Edit)
            {
                c_labIsCheckPost.Visible = true;
                c_labPostType.Text = LngRes.MSG_PostType_Edit;
            }
            else
            {
                c_labIsCheckPost.Visible = false;
                c_labPostType.Text = _postType == PostTypeEnum.Nocare ? LngRes.MSG_PostType_Nocare : LngRes.MSG_PostType_Normal;
            }


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
            public const string MSG_FormName = "出库计划";
            public const string MSG_PostType_Normal = "称重出库";
            public const string MSG_PostType_Nocare = "直接出库";
            public const string MSG_PostType_Edit = "审核出库";
        }

        #endregion

        private void FrmMWPostDetail_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmMWPostDetail_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnManually_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (FrmMWCrateView f = new FrmMWCrateView())
                {
                    f.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnManually_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                  using (FrmMWCrateReview f = new FrmMWCrateReview())
                {
                    f.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnCheck_Click", ex);
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
