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
    public partial class FrmText : Form
    {
        public FrmText(string s)
        {
            InitializeComponent();
            textBox1.Text = s;
        }
    }
}
