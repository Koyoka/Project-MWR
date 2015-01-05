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

    }
}
