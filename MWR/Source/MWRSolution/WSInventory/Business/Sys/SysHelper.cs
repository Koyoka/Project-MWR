using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YRKJ.MWR.WSInventory.Business.Sys
{
    public class SysHelper
    {
        public static void SetCtrlUnitText(params Control[] ctrls)
        {
            string unit = SysParams.GetInstance().GetSysWeightUnit();
            foreach (Control c in ctrls)
            {
                c.Text = unit;
            }
        }
    }
}
