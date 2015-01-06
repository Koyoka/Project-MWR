using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YRKJ.MWR.WinBase.WinAppBase;

namespace WSDestory
{
    public partial class Form1 : Form
    {
        private const string ClassName = "Form1";
        private FormMng _frmMng = null;

        public Form1()
        {
            InitializeComponent();
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

        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
