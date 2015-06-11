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
    public partial class FrmMWResidue : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmMWResidue";
        private FormMng _frmMng = null;

        public FrmMWResidue()
        {
            InitializeComponent();
        } 

        #region Event
        private void FrmMWResidue_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmMWResidue_Load", ex);
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
            pictureBox1.BackgroundImage = imageList1.Images[1];
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
