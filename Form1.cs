using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace Hotkey
{
    public partial class HotKey : Form
    {

        //Import Key Registery for global keypresses 
        [DllImport("user32.dll")]
        //Set to true if your shortcut got triggerd 
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        public HotKey()
        {

            InitializeComponent();
            
            //Register the hotkeys
            int HotKey1 = 1;
            int HotKey2 = 2;
            int HotKey1Key = (int)Keys.F3;
            int HotKey2Key = (int)Keys.F4;

            //Register the KEYS
            Boolean Key1Registered = RegisterHotKey(
                this.Handle, HotKey1, 0x0000, HotKey1Key
            );
            Boolean Key2Registered = RegisterHotKey(
                this.Handle, HotKey2, 0x0000, HotKey2Key
            );

            //Verify the if the hotkeys are registered
            if (!Key1Registered)
            {
                //Console.WriteLine("Global Hotkey F9 couldn't be registered !");
            }

            if (!Key2Registered)
            {
                //Console.WriteLine("Global Hotkey F10 couldn't be registered !");
            }

        }

        protected override void WndProc(ref Message m)
        {
            //Trigger when a hotkey get pressed
            if (m.Msg == 0x0312)
            {
                //Get the shortcut id
                int id = m.WParam.ToInt32();

                //Do the correct tasks corresponding with the shortcut
                switch (id)
                {
                    case 1:
                        //Console.WriteLine("F3 Key Pressed ! ");
                        Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "https://www.youtube.com/watch?v=dQw4w9WgXcQ");
                        Task.Delay(100);
                        break;
                    case 2:
                       // Console.WriteLine("F4 Key Pressed ! ");
                        Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "https://www.youtube.com/watch?v=EpX1_YJPGAY");
                        break;
                }
            }

            base.WndProc(ref m);
        }
        //Make the Form invisible
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HotKey";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }
    }
}