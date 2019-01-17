using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Threading;
using GlobalLowLevelHooks;

namespace MyFirstWindowsApp
{
    public class DATA
    {

    }

    public class INFO
    {
        public string Name;
    }

    public class COMMAND
    {

    }

    public partial class Form1 : Form
    {
        private Thread clickerThread;

        private MouseHook mHook;
        private KeyboardHook kHook;

        private bool playClicker = false;

        public Form1()
        {
            //mHook = new MouseHook();
            //mHook.MouseMove += new MouseHook.MouseHookCallback(OnMouseMove);
            //mHook.Install();

            //kHook = new KeyboardHook();
            //kHook.KeyDown += new KeyboardHook.KeyboardHookCallback(OnKeyDown);
            //kHook.Install();

            InitializeComponent();
        }

        private void NewBtnClicked(object sender, System.EventArgs e)
        {
            tbLog.AppendText("Create a new file...\r\n");

            newForm newDialog = new newForm(this);
            newDialog.ShowDialog();
        }

        private void LoadBtnClicked(object sender, System.EventArgs e)
        {
            tbLog.AppendText("Load data file...\r\n");
        }


        //private void OnMouseMove(MouseHook.MSLLHOOKSTRUCT mStruct)
        //{
        //    lbMousePos.Text = mStruct.pt.x.ToString() + ", " + mStruct.pt.y.ToString();

        //    Point pt = VirtualIO.VirtualIO.GetPointerPos();
        //    Color color = ScreenCapture.ScreenCapture.GetColorAt(pt);
        //    pb.BackColor = color;
            
        //    Bitmap bitmap = ScreenCapture.ScreenCapture.GetImageAt(pt, pbImage.Width, pbImage.Height);
        //    pbImage.BackgroundImage = (Image)bitmap;
        //}

        private void OnKeyDown(KeyboardHook.VKeys key)
        {
            switch(key)
            {
                case KeyboardHook.VKeys.KEY_A:
                    playClicker = true;
                    MouseClicker();
                    break;
                case KeyboardHook.VKeys.KEY_S:
                    playClicker = false;
                    break;
            }
        }

        private void MouseClicker()
        {
            if(clickerThread!=null && clickerThread.IsAlive)
            {
                return;
            }
            clickerThread = new Thread(new ThreadStart(MouseClickerRun));
            clickerThread.Start();
        }

        private void MouseClickerRun()
        {
            while (playClicker)
            {
                System.Threading.Thread.Sleep(100);
                VirtualIO.VirtualIO.ClickPoint(2518, 1213);
            }
            clickerThread.Abort();
        }

        public void MsgFromOther(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                string[] split = msg.Split('|');
                switch(split[0])
                {
                    case "newfile":
                        tbLog.AppendText("New data has been created.\r\n");
                        break;
                }
            }
            
        }
    }
}
