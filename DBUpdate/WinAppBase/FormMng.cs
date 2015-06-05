using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using ComLib.Log;

namespace DBUpdate.WinAppBase
{
    public class FormMng
    {
        private string ClassName = "YRKJ.MWR.WinBase.WinAppBase.FormMng";

        private Form _form = null;
        private string _className = "";

        private static Icon _defaultIcon = null;

        public enum EscExistEnum { YES,NO}

        public bool ClearMemoryOnExist = false;



        public FormMng(Form form, string ClassName)
            : this(form, ClassName, EscExistEnum.NO)
        {

        }

        public FormMng(Form form, string ClassName, EscExistEnum EscExist)
        {
            _form = form;
            _className = ClassName;


            _form.BackColor = Color.FromArgb(240, 240, 240);
            _form.KeyPreview = true;
            _form.Icon = GetDefaultLogo();

            _form.Shown += new EventHandler(_form_Shown);
            _form.KeyDown += new System.Windows.Forms.KeyEventHandler(this._form_KeyDown);
            _form.Resize += new System.EventHandler(this._form_Resize);
            _form.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this._form_FormClosed);
            _form.Disposed += new EventHandler(_form_Disposed);
            if (EscExist == EscExistEnum.YES)
                _form.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._form_KeyPress);
        }

        #region Events

        private void _form_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                _form.Cursor = Cursors.WaitCursor;

                if (e.KeyChar == (char)Keys.Escape)
                {
                    _form.Close();
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

        private void _form_Shown(object sender, EventArgs e)
        { 
            
        }

        public void _form_KeyDown(object sender, KeyEventArgs e)
        {

        }

        public void _form_Resize(object sender, EventArgs e)
        {

        }

        public void _form_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        public void _form_Disposed(object sender, EventArgs e)
        {
            try
            {
                //this.Cursor = Cursors.WaitCursor;

                if (ClearMemoryOnExist)
                {
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "_form_Disposed", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                //this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region Functions

       
        private Icon GetDefaultLogo()
        {
            if (_defaultIcon != null)
            {
                return _defaultIcon;
            }

            try
            {
                _defaultIcon = new Icon(WinAppFn.GetImageFolder() + "logo.ico");
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "GetDefaultLogo", ex);
                _defaultIcon = (new Form()).Icon;
            }

            return _defaultIcon;
        }

        #endregion
    }
}
