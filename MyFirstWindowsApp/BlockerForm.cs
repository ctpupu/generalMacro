using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralMacro
{
    public partial class BlockerForm : Form
    {
        private string msg;
        public BlockerForm(string message)
        {
            msg = message;
            InitializeComponent();
        }

        private void OnLoad(object sender, System.EventArgs e)
        {
            tbMsg.Text = msg;
        }
    }
}
