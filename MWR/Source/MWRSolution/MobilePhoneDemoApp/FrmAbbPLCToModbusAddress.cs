using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MobilePhoneDemoApp
{
    public partial class FrmAbbPLCToModbusAddress : Form
    {
        public FrmAbbPLCToModbusAddress()
        {
            InitializeComponent();
        }

        public class PLCModbusHelper
        {
            public const string PLC_AREA_BIT = "%MX";
            public const string PLC_AREA_WORD = "%MW";
            public const string PLC_AREA_DWORD = "%MD";

            public int LINE_LENGTH = 0x7FFF;

            private int _line = 0;

            public void PLCArea2ModbusAddressHEX(string area)
            { 
                
            }
        }
    }
}
