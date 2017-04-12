/**
Made : G
Name : NaverMusicPlayer
**/
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Security;
using System.Net;
using System.Runtime.InteropServices;

namespace NaverMusicPlayer
{
    public partial class fTitle : Form
    {
        [DllImport("User32.dll")]
        public static extern void keybd_event(
         byte bVk, // virtual-key code
         byte bScan, // hardware scan code
         int dwFlags, // function options
         ref int dwExtraInfo // additional keystroke data
        );

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const string InternetExplorerRootKey = @"Software\Microsoft\Internet Explorer";
        private const string BrowserEmulationKey = InternetExplorerRootKey + @"\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
        protected static bool SetBrowserEmulationVersion(BrowserEmulationVersion browserEmulationVersion)
        {
            bool result;



            result = false;



            try
            {

                RegistryKey key;



                key = Registry.CurrentUser.OpenSubKey(BrowserEmulationKey, true);



                if (key != null)
                {

                    string programName;



                    programName = Path.GetFileName(Environment.GetCommandLineArgs()[0]);



                    if (browserEmulationVersion != BrowserEmulationVersion.Default)
                    {

                        // if it's a valid value, update or create the value

                        key.SetValue(programName, (int)browserEmulationVersion, RegistryValueKind.DWord);

                    }

                    else
                    {

                        // otherwise, remove the existing value

                        key.DeleteValue(programName, false);

                    }



                    result = true;

                }

            }

            catch (SecurityException)
            {

                // The user does not have the permissions required to read from the registry key.

            }

            catch (UnauthorizedAccessException)
            {

                // The user does not have the necessary registry rights.

            }



            return result;

        }
        protected static bool SetBrowserEmulationVersion()
        {

            int ieVersion;

            BrowserEmulationVersion emulationCode;



            ieVersion = GetInternetExplorerMajorVersion();



            if (ieVersion >= 11)
            {

                emulationCode = BrowserEmulationVersion.Version11;

            }

            else
            {

                switch (ieVersion)
                {

                    case 10:

                        emulationCode = BrowserEmulationVersion.Version10;

                        break;

                    case 9:

                        emulationCode = BrowserEmulationVersion.Version9;

                        break;

                    case 8:

                        emulationCode = BrowserEmulationVersion.Version8;

                        break;

                    default:

                        emulationCode = BrowserEmulationVersion.Version7;

                        break;

                }

            }

            return SetBrowserEmulationVersion(emulationCode);

        }
        protected enum BrowserEmulationVersion
        {

            Default = 0,

            Version7 = 7000,

            Version8 = 8000,

            Version8Standards = 8888,

            Version9 = 9000,

            Version9Standards = 9999,

            Version10 = 10000,

            Version10Standards = 10001,

            Version11 = 11000,

            Version11Edge = 11001

        }
        protected static int GetInternetExplorerMajorVersion()
        {

            int result;
            result = 0;
            try
            {

                RegistryKey key;



                key = Registry.LocalMachine.OpenSubKey(InternetExplorerRootKey);



                if (key != null)
                {

                    object value;



                    value = key.GetValue("svcVersion", null) ?? key.GetValue("Version", null);



                    if (value != null)
                    {

                        string version;

                        int separator;



                        version = value.ToString();

                        separator = version.IndexOf('.');

                        if (separator != -1)
                        {

                            int.TryParse(version.Substring(0, separator), out result);

                        }

                    }

                }

            }

            catch (SecurityException)
            {

                // The user does not have the permissions required to read from the registry key.

            }

            catch (UnauthorizedAccessException)
            {

                // The user does not have the necessary registry rights.

            }



            return result;

        }
        protected static BrowserEmulationVersion GetBrowserEmulationVersion()
        {

            BrowserEmulationVersion result;



            result = BrowserEmulationVersion.Default;



            try
            {

                RegistryKey key;



                key = Registry.CurrentUser.OpenSubKey(BrowserEmulationKey, true);

                if (key != null)
                {

                    string programName;

                    object value;



                    programName = Path.GetFileName(Environment.GetCommandLineArgs()[0]);

                    value = key.GetValue(programName, null);



                    if (value != null)
                    {

                        result = (BrowserEmulationVersion)Convert.ToInt32(value);

                    }

                }

            }

            catch (SecurityException)
            {

                // The user does not have the permissions required to read from the registry key.

            }

            catch (UnauthorizedAccessException)
            {

                // The user does not have the necessary registry rights.

            }



            return result;

        }
        protected static bool IsBrowserEmulationSet()
        {

            return GetBrowserEmulationVersion() != BrowserEmulationVersion.Default;

        }

        protected HtmlElementCollection el = null;
        private bool isPlay = false;
        private bool isTray = false;
        //private bool isLogin = false;
        private string ID = "";
        private string PW = "";
        private Uri logUri = new Uri("https://nid.naver.com/nidlogin.login?svctype=64&url=http://player.music.naver.com/player.nhn");
        private object sender = new object();
        private EventArgs e = new EventArgs();

        public fTitle()
        {
            InitializeComponent();
            SetBrowserEmulationVersion(BrowserEmulationVersion.Version11); //IE11

            RegisterHotKey(this.Handle, 0, (int)KeyModifier.Control, Keys.T.GetHashCode());       // Register Shift + A as global hotkey.
            RegisterHotKey(this.Handle, 1, (int)KeyModifier.Control, Keys.P.GetHashCode());
            RegisterHotKey(this.Handle, 2, (int)KeyModifier.Control, Keys.OemOpenBrackets.GetHashCode());
            RegisterHotKey(this.Handle, 3, (int)KeyModifier.Control, Keys.OemCloseBrackets.GetHashCode());

            notifyIcon1.Text = "네이버 뮤직 플레이어";
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            tBoxID.Text = ID;
            tBoxPW.Text = PW;
        }

        private void mainBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            el = mainBrowser.Document.GetElementsByTagName("button");
        }

        private void btnCtrPlay_Click(object sender, EventArgs e)
        {
            if (el == null)
                return;

            Object obj = el[3].DomElement;
            System.Reflection.MethodInfo mi = obj.GetType().GetMethod("click");
            mi.Invoke(obj, new object[0]);

            if (isPlay)
                btnTrayPlay.Text = btnCtrPlay.Text = "재생";
            else
                btnTrayPlay.Text = btnCtrPlay.Text = "일시정지";
            isPlay ^= true;
        }

        private void btnCtrPrev_Click(object sender, EventArgs e)
        {
            if (el == null)
                return;
            Object obj = el[2].DomElement;
            System.Reflection.MethodInfo mi = obj.GetType().GetMethod("click");
            mi.Invoke(obj, new object[0]);
        }
        private void btnCtrNext_Click(object sender, EventArgs e)
        {
            if (el == null)
                return;
            Object obj = el[4].DomElement;
            System.Reflection.MethodInfo mi = obj.GetType().GetMethod("click");
            mi.Invoke(obj, new object[0]);
        }
        private void btnTray_Click(object sender, EventArgs e)
        {
            isTray ^= true;
            if (isTray)
            {
                notifyIcon1_DoubleClick(sender, e);
                return;
            }
            // this.ShowInTaskbar = false;
            this.Visible = false;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("제작 : 하얀깃발 (powe0101@naver.com)\n 알파 0.4 버전");
        } // 도움말

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.Show();

        }
        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            notifyIcon1.Text = mainBrowser.Document.Title;
        }

        private void fTitle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.ApplicationExitCall)
            {
                UnregisterHotKey(this.Handle, 0);       // Unregister hotkey with id 0 before closing the form. You might want to call this more than once with different id values if you are planning to register more than one hotkey.
                UnregisterHotKey(this.Handle, 1);
                UnregisterHotKey(this.Handle, 2);
                UnregisterHotKey(this.Handle, 3);

                Application.Exit();
                e.Cancel = false;
                return;
            }

            this.Visible = false;
            this.notifyIcon1.Visible = true;
            e.Cancel = true;
        }// only can exit at tray

        private void PressKey(byte _Key)
        {
            const int KEYUP = 0x0002;
            int Info = 0;

            keybd_event(_Key, 0, 0, ref Info);   // key 다운
            keybd_event(_Key, 0, KEYUP, ref Info);  // key 업
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            mainBrowser.Hide();
            mainBrowser.Navigate("https://nid.naver.com/nidlogin.login?svctype=64&url=http://player.music.naver.com/player.nhn");

            while (mainBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents(); // 웹페이지 로딩이 완료될 때 까지 대기
            }

            HtmlElementCollection inputList = mainBrowser.Document.GetElementsByTagName("input");
            inputList[18].Focus();
            inputList[18].InnerText = ID;
            inputList[19].Focus();
            inputList[19].InnerText = PW;
            PressKey(13);//Enter

            Delay(1000);
            mainBrowser.Show();
        }

        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);
            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }

        private void tBoxID_TextChanged(object sender, EventArgs e)
        {
            ID = tBoxID.Text;
        }

        private void tBoxPW_TextChanged(object sender, EventArgs e)
        {
            PW = tBoxPW.Text;
        }

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                /* Note that the three lines below are not needed if you only want to register one hotkey.
                 * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */

                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.
                switch (id)
                {
                    case 0://트레이
                        btnTray_Click(sender, e);
                        break;
                    case 1://재생/일시정지
                        btnCtrPlay_Click(sender, e);
                        break;
                    case 2://이전
                        btnCtrPrev_Click(sender, e);
                        break;
                    case 3: //다음
                        btnCtrNext_Click(sender, e);
                        break;
                }
                // do something
            }
        }

        private void btnChkLogin_Click(object sender, EventArgs e)
        {
            btnChkLogin.Checked ^= true;
            //btnLogin.DropDown.Visible = true;
        }


    }
}
