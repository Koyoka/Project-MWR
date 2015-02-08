using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComLib.Log;
using YRKJ.MWR.WinBase.WinAppBase;
using System.Text.RegularExpressions;

namespace YRKJ.MWR.WinBase.WinUtility
{
    public class ScannerMng
    {
        public const string ClassName = "YRKJ.MWR.WinBase.WinUtility.ScannerMng";

        private Form _form = null;
        private string _className = "";

        private int _inputInterval = 50;

       
        private string _mask = "";
        private string _pattern = "";
        private string _barCode = "";
        private bool _scannerInput = false;
        private DateTime _barCodeInputDate = DateTime.MinValue;
        private DateTime _stratTime = DateTime.MinValue;
        private System.Windows.Forms.Timer _timer;

        private string _currentBarCode = "";
        public string CurrentBarCode
        {
            get { return _currentBarCode; }
        }

        public delegate void ScannedEventHandler(string code);
        public event ScannedEventHandler CodeScanned = null;
        public event ScannedEventHandler InvalidCodeScanned = null;
        public event ScannedEventHandler CodeScanning = null;

        public ScannerMng(Form form,string className)
            :this(form,className,"#############")
        {
           
        }

        public ScannerMng(Form form, string className, string mask)
        {
            _form = form;
            _className = className;
            _mask = mask;

            _timer = new Timer();
            _timer.Interval = 10;// _inputInterval;
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();

            _form.KeyPreview = true;
            _form.KeyPress += new KeyPressEventHandler(_form_KeyPress);
            _form.FormClosed += new FormClosedEventHandler(_form_FormClosed);

            SetCodeMask(_mask);
        }

       

        #region Events
      
        private void _timer_Tick(object sender, EventArgs e)
        {
            
            try
            {
                if (CodeScanned == null)
                {
                    _timer.Stop();
                    return;
                }
                if (string.IsNullOrEmpty(_barCode))
                {
                    return;
                }
                if (!_scannerInput)
                {
                    return;
                }
                
                string tempBarCode = _barCode;
               

                DateTime tempD = DateTime.Now;
                int inv = tempD.Subtract(_stratTime).Milliseconds;
                if (inv > _inputInterval + 10)
                {
                    bool valid = true;
                    valid = Regex.IsMatch(tempBarCode, _pattern);
                    if (!valid)
                    {
                        _barCode = "";
                        if (InvalidCodeScanned != null)
                        {
                            InvalidCodeScanned("InputCode:[" + tempBarCode + "] Mask:[" + _mask + "]");
                        }
                       
                        return;
                    }
                    else
                    {
                        _barCode = "";
                        _currentBarCode = tempBarCode;
                        CodeScanned(tempBarCode);
                    }
                }
                else if (CodeScanning != null)
                {
                    CodeScanning("time:" + inv + " code:[" + tempBarCode + "]");
                }

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "_timer_Tick", ex);
                //MsgBox.Error(ex);
            }
            finally
            {
            }
        }

      
        private void _form_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
               
                _form.Cursor = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(_barCode))
                {
                    _barCodeInputDate = DateTime.Now;
                    
                }

                DateTime tempDt = DateTime.Now;
                TimeSpan ts = tempDt.Subtract(_barCodeInputDate);
                if (ts.Milliseconds > _inputInterval)
                {
                    _barCode = "";
                    _scannerInput = false;
                }
                else
                {
                   
                    _barCode += e.KeyChar.ToString();
                    _scannerInput = true;
                }
                _stratTime = tempDt;
                _barCodeInputDate = tempDt;
                
                //if (_barCode.Length == _codeLen)
                //{
                //    CodeScanned(_barCode);
                //    _barCode = "";
                //}
                //else if (_barCode.Length > _codeLen)
                //{
                //    _barCode = "";
                //    MsgBox.Show(LngRes.MSG_ReScanerBarCode);
                //}
                //else
                //{
                //    // go on waiting input keychar
                //}

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

        private void _form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        #endregion

        #region Functions
        public void SetCodeMask(string mask)
        {
           
            string pattern = "^";
            for (int i = 0; i < mask.Length; i++)
            {
                string defineMaskChar = mask[i].ToString();
                if (defineMaskChar.Equals("#"))
                {
                    //number
                    pattern += @"\d";
                }
                else if (defineMaskChar.Equals("@"))
                {
                    //char
                    pattern += "[A-Za-z]";
                }
                else 
                {
                    pattern += defineMaskChar;
                }
                
                pattern += "{1}";
            }
            pattern += "$";
            _mask = mask;
            _pattern = pattern;
        }

        public void Close()
        {
            _timer.Stop();
        }

        #endregion

        #region Common
        private class LngRes
        {
            public const string MSG_ReScanerBarCode = "请重新扫描";
        }

        #endregion

    }
}
