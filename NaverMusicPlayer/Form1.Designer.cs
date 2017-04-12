namespace NaverMusicPlayer
{
    partial class fTitle
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTitle));
            this.mainBrowser = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.tBoxID = new System.Windows.Forms.ToolStripTextBox();
            this.tBoxPW = new System.Windows.Forms.ToolStripTextBox();
            this.로그인ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChkLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCtrPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCtrPrev = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCtrNext = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTray = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnTrayPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.이전곡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다음곡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainBrowser
            // 
            this.mainBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainBrowser.Location = new System.Drawing.Point(0, 24);
            this.mainBrowser.MinimumSize = new System.Drawing.Size(550, 355);
            this.mainBrowser.Name = "mainBrowser";
            this.mainBrowser.Size = new System.Drawing.Size(550, 355);
            this.mainBrowser.TabIndex = 0;
            this.mainBrowser.Url = new System.Uri("http://player.music.naver.com/player.nhn", System.UriKind.Absolute);
            this.mainBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.mainBrowser_Navigated);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLogin,
            this.btnPlay,
            this.btnTray,
            this.btnInfo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(501, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnLogin
            // 
            this.btnLogin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tBoxID,
            this.tBoxPW,
            this.로그인ToolStripMenuItem,
            this.btnChkLogin});
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(83, 20);
            this.btnLogin.Text = "로그인 설정";
            // 
            // tBoxID
            // 
            this.tBoxID.Name = "tBoxID";
            this.tBoxID.Size = new System.Drawing.Size(100, 23);
            this.tBoxID.ToolTipText = "아이디";
            this.tBoxID.TextChanged += new System.EventHandler(this.tBoxID_TextChanged);
            // 
            // tBoxPW
            // 
            this.tBoxPW.Name = "tBoxPW";
            this.tBoxPW.Size = new System.Drawing.Size(100, 23);
            this.tBoxPW.TextChanged += new System.EventHandler(this.tBoxPW_TextChanged);
            // 
            // 로그인ToolStripMenuItem
            // 
            this.로그인ToolStripMenuItem.Name = "로그인ToolStripMenuItem";
            this.로그인ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.로그인ToolStripMenuItem.Text = "로그인";
            this.로그인ToolStripMenuItem.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnChkLogin
            // 
            this.btnChkLogin.Checked = true;
            this.btnChkLogin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnChkLogin.Name = "btnChkLogin";
            this.btnChkLogin.ShowShortcutKeys = false;
            this.btnChkLogin.Size = new System.Drawing.Size(160, 22);
            this.btnChkLogin.Text = "자동 로그인";
            this.btnChkLogin.Click += new System.EventHandler(this.btnChkLogin_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCtrPlay,
            this.btnCtrPrev,
            this.btnCtrNext});
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(43, 20);
            this.btnPlay.Text = "재생";
            // 
            // btnCtrPlay
            // 
            this.btnCtrPlay.Name = "btnCtrPlay";
            this.btnCtrPlay.ShortcutKeyDisplayString = "Shift + P";
            this.btnCtrPlay.Size = new System.Drawing.Size(153, 22);
            this.btnCtrPlay.Text = "재생";
            this.btnCtrPlay.Click += new System.EventHandler(this.btnCtrPlay_Click);
            // 
            // btnCtrPrev
            // 
            this.btnCtrPrev.Name = "btnCtrPrev";
            this.btnCtrPrev.Size = new System.Drawing.Size(153, 22);
            this.btnCtrPrev.Text = "이전곡";
            this.btnCtrPrev.Click += new System.EventHandler(this.btnCtrPrev_Click);
            // 
            // btnCtrNext
            // 
            this.btnCtrNext.Name = "btnCtrNext";
            this.btnCtrNext.Size = new System.Drawing.Size(153, 22);
            this.btnCtrNext.Text = "다음곡";
            this.btnCtrNext.Click += new System.EventHandler(this.btnCtrNext_Click);
            // 
            // btnTray
            // 
            this.btnTray.Name = "btnTray";
            this.btnTray.Size = new System.Drawing.Size(55, 20);
            this.btnTray.Text = "트레이";
            this.btnTray.Click += new System.EventHandler(this.btnTray_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(40, 20);
            this.btnInfo.Text = "Info";
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTrayPlay,
            this.이전곡ToolStripMenuItem,
            this.다음곡ToolStripMenuItem,
            this.btnExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 92);
            // 
            // btnTrayPlay
            // 
            this.btnTrayPlay.Name = "btnTrayPlay";
            this.btnTrayPlay.Size = new System.Drawing.Size(110, 22);
            this.btnTrayPlay.Text = "재생";
            this.btnTrayPlay.Click += new System.EventHandler(this.btnCtrPlay_Click);
            // 
            // 이전곡ToolStripMenuItem
            // 
            this.이전곡ToolStripMenuItem.Name = "이전곡ToolStripMenuItem";
            this.이전곡ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.이전곡ToolStripMenuItem.Text = "이전곡";
            this.이전곡ToolStripMenuItem.Click += new System.EventHandler(this.btnCtrPrev_Click);
            // 
            // 다음곡ToolStripMenuItem
            // 
            this.다음곡ToolStripMenuItem.Name = "다음곡ToolStripMenuItem";
            this.다음곡ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.다음곡ToolStripMenuItem.Text = "다음곡";
            this.다음곡ToolStripMenuItem.Click += new System.EventHandler(this.btnCtrNext_Click);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 22);
            this.btnExit.Text = "종료";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // fTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 378);
            this.Controls.Add(this.mainBrowser);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(517, 417);
            this.MinimumSize = new System.Drawing.Size(517, 417);
            this.Name = "fTitle";
            this.Text = "네이버 뮤직 플레이어 알파";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fTitle_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnPlay;
        private System.Windows.Forms.ToolStripMenuItem btnCtrPlay;
        private System.Windows.Forms.ToolStripMenuItem btnCtrPrev;
        private System.Windows.Forms.ToolStripMenuItem btnCtrNext;
        private System.Windows.Forms.ToolStripMenuItem btnTray;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnTrayPlay;
        private System.Windows.Forms.ToolStripMenuItem 이전곡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다음곡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem btnInfo;
        public System.Windows.Forms.WebBrowser mainBrowser;
        private System.Windows.Forms.ToolStripMenuItem btnLogin;
        private System.Windows.Forms.ToolStripTextBox tBoxID;
        private System.Windows.Forms.ToolStripTextBox tBoxPW;
        private System.Windows.Forms.ToolStripMenuItem 로그인ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnChkLogin;
    }
}

