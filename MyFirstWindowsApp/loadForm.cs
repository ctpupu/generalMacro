using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GeneralMacro
{
    public partial class loadForm : Form
    {
        Form1 mainForm;
        public loadForm(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        private void OnFormLoaded(object sender, System.EventArgs e)
        {
            FileInfo[] files = new DirectoryInfo(Directory.GetCurrentDirectory()).GetFiles("*.txt");
            foreach(FileInfo info in files)
            {
                lbData.Items.Add(info.Name);
            }
        }

        private void OnListChanged(object sender, System.EventArgs e)
        {
            if(lbData.SelectedIndex >= 0)
            {
                btnLoad.Enabled = true;
            } 
            else
            {
                btnLoad.Enabled = false;
            }
        }

        private void OnLoadBtnClicked(object sender, System.EventArgs e)
        {
            mainForm.MsgFromOther("load|" + lbData.SelectedItem.ToString());
            this.Dispose();
        }
    }
}
