using System.Windows.Forms;
using System.IO;

namespace GeneralMacro
{
    public partial class newForm : Form
    {
        private Form1 mainForm;
        public newForm(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        private void OnNameChange(object sender, System.EventArgs e)
        {
            if(string.IsNullOrEmpty(tbName.Text) || File.Exists(@tbName.Text + ".txt"))
            {
                btnCreate.Enabled = false;
            }
            else
            {
                btnCreate.Enabled = true;
            }
        }

        private void OnNewBtnClicked(object sender, System.EventArgs e)
        {
            using (StreamWriter sw = File.CreateText(@tbName.Text + ".txt"))
            {
                sw.WriteLine("[Info]");
                sw.WriteLine("[Data]");
                sw.WriteLine("[Command]");
                sw.Close();
            }
            mainForm.MsgFromOther("newfile|" + tbName.Text + ".txt");
            this.Dispose();
        }
    }
}
