using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YRKJ.MWR.WinBase.WinUtility
{
    public class WinFn
    {

        public static Control[] GetAllControls(Control.ControlCollection parentList)
        {
            List<Control> tabIndexSortList = new List<Control>(parentList.Count);
            foreach (Control ctl in parentList)
            {
                tabIndexSortList.Add(ctl);
            }

            tabIndexSortList.Sort(
                delegate(Control x, Control y)
                {
                    return x.TabIndex.CompareTo(y.TabIndex);
                }
            );

            List<Control> list = new List<Control>(tabIndexSortList.Count);
            foreach (Control c in tabIndexSortList)
            {
                list.Add(c);

                if (c is System.Windows.Forms.Panel 
                    //||
                    //c is DevExpress.XtraTab.XtraTabControl ||
                    //c is DevExpress.XtraTab.XtraTabPage ||
                    //c is DevExpress.XtraEditors.GroupControl
                    )
                {
                    list.AddRange(GetAllControls(c.Controls));
                }
            }

            return list.ToArray();
        }
        public static Control[] GetFormAllControls(Form frm)
        {
            return GetAllControls(frm.Controls);
        }


        #region Operate Ctrl

        public static void SafeFocus(Control ctl)
        {
            try
            {
                ctl.TabStop = true;
                ctl.Focus();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public static void SafeFocusAndSelectAll(Control ctl)
        {
            if (ctl is TextBox 
                //|| ctl is ButtonEdit
                )
            {

            }
            else
            {
                return;
            }

            SafeFocus(ctl);

            try
            {
                if (ctl is TextBox)
                {
                    ((TextBox)ctl).SelectAll();
                }
                //else if (ctl is ButtonEdit)
                //{
                //    ((Button)ctl).Select();
                //}
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public static void ReadBingdingText(Control ctrl)
        {
            if(ctrl.DataBindings["Text"] != null)
                ctrl.DataBindings["Text"].ReadValue();
        }
        public static void ReadBingdingEnabled(Control ctrl)
        {
            if (ctrl.DataBindings["Enabled"] != null)
                ctrl.DataBindings["Enabled"].ReadValue();
        }
        #endregion
    }
}
