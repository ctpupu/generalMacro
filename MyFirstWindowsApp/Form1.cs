﻿using System;
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
using System.IO;
using GlobalLowLevelHooks;

namespace GeneralMacro
{
    public partial class Form1 : Form
    {
        private Thread loopThread;

        private MouseHook mHook;
        private KeyboardHook kHook;
        private INFO info;
        private DATA data;
        private ACTION action;
        private CONDITION condition;

        private Form targetForm;

        //private bool playClicker = false;

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
            tbLog.AppendText("Create a data...\r\n");

            newForm newDialog = new newForm(this);
            newDialog.ShowDialog();
        }

        private void LoadBtnClicked(object sender, System.EventArgs e)
        {
            tbLog.AppendText("Load data...\r\n");

            loadForm loadDialog = new loadForm(this);
            loadDialog.ShowDialog();
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

        private void OnSelectApp(MouseHook.MSLLHOOKSTRUCT mStruct)
        {
            string appName = AppInfo.AppInfo.GetForegroundAppName();
            string curName = System.Reflection.Assembly.GetCallingAssembly().GetName().Name;
            
            if(appName != curName)
            {
                mHook.Uninstall();
                mHook = null;

                info.AppName = appName;
                //targetForm.Dispose();
                //loopThread.Interrupt();
            }
        }

        //private void OnKeyDown(KeyboardHook.VKeys key)
        //{
        //    switch (key)
        //    {
        //        case KeyboardHook.VKeys.KEY_A:
        //            playClicker = true;
        //            //MouseClicker();
        //            break;
        //        case KeyboardHook.VKeys.KEY_S:
        //            playClicker = false;
        //            break;
        //    }
        //}

        private void StartMacro()
        {
            if (loopThread != null && loopThread.IsAlive)
            {
                return;
            }
            loopThread = new Thread(new ThreadStart(ProcessLoop));
            loopThread.Start();
        }

        private void ProcessLoop()
        {
            while (true)
            {
                if (info == null || data == null || action == null)
                {
                    break;
                }

                if (string.IsNullOrEmpty(info.AppName))
                {
                    //targetForm = new BlockerForm("Choose App to run Macro");
                    //targetForm.ShowDialog();
                    
                    mHook = new MouseHook();
                    mHook.LeftButtonUp += new MouseHook.MouseHookCallback(OnSelectApp);
                    mHook.Install();

                    MessageBox.Show("Choose target app");
                    //System.Threading.Thread.Sleep(Timeout.Infinite);


                }

                System.Threading.Thread.Sleep(100);
            }
            loopThread.Abort();
        }

        private bool ReadData(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string line;
                    string mode = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == "[Info]")
                        {
                            mode = "info";
                            info = new INFO();
                            info.fileName = path;
                            continue;
                        }
                        else if (line == "[Action]")
                        {
                            mode = "action";
                            action = new ACTION();
                            continue;
                        }
                        else if (line == "[Data]")
                        {
                            mode = "data";
                            data = new DATA();
                            continue;
                        }
                        else if (line == "[Condition]")
                        {
                            mode = "condition";
                            condition = new CONDITION();

                        }

                        switch (mode)
                        {
                            case "info":
                                break;
                            case "action":
                                break;
                            case "data":
                                break;
                            case "condition":
                                break;
                            default: break;
                        }
                    }
                    sr.Close();
                }

                StartMacro();
            }
            else
            {
                return false;
            }
            return true;
        }

        public void MsgFromOther(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                string[] split = msg.Split('|');
                switch (split[0])
                {
                    case "newfile":
                        ReadData(split[1]);
                        tbLog.AppendText("New data has been created.\r\n");
                        break;
                    case "load":
                        ReadData(split[1]);
                        tbLog.AppendText("Data loaded...\r\n");
                        break;
                }
            }

        }
    }

    public class DATA
    {

    }

    public class INFO
    {
        public string fileName;
        public string AppName;
    }

    public class ACTION
    {

    }

    public class CONDITION
    {

    }
}
