using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YRKJ.MWR.WinBase.WinAppBase
{
    public class MsgBox
    {
        public static void Error(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        public static void Show(string msg)
        {
            MessageBox.Show(msg);
        }


    }
}
