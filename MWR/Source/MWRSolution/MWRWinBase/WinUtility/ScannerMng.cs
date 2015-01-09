using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComLib.Log;
using YRKJ.MWR.WinBase.WinAppBase;

namespace YRKJ.MWR.WinBase.WinUtility
{
    public class ScannerMng
    {
        public const string ClassName = "YRKJ.MWR.WinBase.WinUtility.ScannerMng";

        private Form _form = null;
        private string _className = "";

        private int _codeLen = 13;
        private int _inputInterval = 50;
        private DateTime _barCodeInputInterval = DateTime.MinValue;
        private string _barCode = "";

        public delegate void ScannedEventHandler(string code);
        public ScannedEventHandler CodeScanned = null;

        public ScannerMng(Form form,string className)
        {
            _form = form;
            _className = className;
            
            form.KeyPress +=new KeyPressEventHandler(_form_KeyPress);
        }

        #region Events
        private void _form_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                _form.Cursor = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(_barCode))
                {
                    _barCodeInputInterval = DateTime.Now;
                }

                DateTime tempDt = DateTime.Now;

                TimeSpan ts = tempDt.Subtract(_barCodeInputInterval);
                if (ts.Milliseconds > _inputInterval)
                    _barCode = "";
                else
                    _barCode += e.KeyChar.ToString();

                _barCodeInputInterval = tempDt;

                if (_barCode.Length == _codeLen)
                {
                    CodeScanned(_barCode);
                    _barCode = "";
                }
                else if (_barCode.Length > _codeLen)
                {
                    _barCode = "";
                    MsgBox.Show(LngRes.MSG_ReScanerBarCode);
                }
                else
                { 
                    // go on waiting input keychar
                }
                
            }
            catch (Exception ex)
            {

                LogMng.GetLog().PrintError(ClassName, "_form_KeyPress", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                _form.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region Functions

        #endregion

        #region Common
        private class LngRes
        {
            public const string MSG_ReScanerBarCode = "请重新扫描";
        }

        #endregion

    }
}
