using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBUpdate.WinAppBase
{
    public class MsgBox
    {
        public static void Error(Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void Error(string msg)
        {
          
            MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Show(string msg)
        {
            MessageBox.Show(msg);
        }

        public static bool Confirm(string title,string msg)
        {
            if (MessageBox.Show(msg, title, MessageBoxButtons.OKCancel)
            ==
            DialogResult.OK)
                return true;
            else
                return false;
        }


    }
}
