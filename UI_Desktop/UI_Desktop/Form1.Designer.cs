namespace UI_Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null!;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            shellPanel = new Panel();
            topBarPanel = new Panel();
            toolbarInfoLabel = new Label();
            toolbarModeLabel = new Label();
            closeWindowButton = new Button();
            minimizeWindowButton = new Button();
            appSubtitleLabel = new Label();
            appNameLabel = new Label();
            brandLogoPictureBox = new PictureBox();
            contentPanel = new Panel();
            showcasePanel = new Panel();
            supportCardPanel = new Panel();
            supportDescriptionLabel = new Label();
            supportTitleLabel = new Label();
            featureCardPanel = new Panel();
            featureItemThreeLabel = new Label();
            featureItemTwoLabel = new Label();
            featureItemOneLabel = new Label();
            featureDescriptionLabel = new Label();
            featureTitleLabel = new Label();
            supportChipLabel = new Label();
            securityChipLabel = new Label();
            speedChipLabel = new Label();
            showcaseDescriptionLabel = new Label();
            showcaseTitleLabel = new Label();
            overlineLabel = new Label();
            launcherChipLabel = new Label();
            brandChipLabel = new Label();
            showcaseFooterLabel = new Label();
            loginCardPanel = new Panel();
            registerLink = new LinkLabel();
            registerPromptLabel = new Label();
            securityNotePanel = new Panel();
            securityNoteBodyLabel = new Label();
            securityNoteTitleLabel = new Label();
            otpButton = new Button();
            loginButton = new Button();
            showPasswordCheckBox = new CheckBox();
            forgotPasswordLink = new LinkLabel();
            rememberMeCheckBox = new CheckBox();
            passwordFieldPanel = new Panel();
            passwordTextBox = new TextBox();
            passwordCaptionLabel = new Label();
            emailFieldPanel = new Panel();
            emailTextBox = new TextBox();
            emailCaptionLabel = new Label();
            loginDescriptionLabel = new Label();
            loginTitleLabel = new Label();
            loginSecurityChipLabel = new Label();
            loginTagChipLabel = new Label();
            shellPanel.SuspendLayout();
            topBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)brandLogoPictureBox).BeginInit();
            contentPanel.SuspendLayout();
            showcasePanel.SuspendLayout();
            supportCardPanel.SuspendLayout();
            featureCardPanel.SuspendLayout();
            loginCardPanel.SuspendLayout();
            securityNotePanel.SuspendLayout();
            passwordFieldPanel.SuspendLayout();
            emailFieldPanel.SuspendLayout();
            SuspendLayout();
            // 
            // shellPanel
            // 
            shellPanel.BackColor = Color.FromArgb(6, 8, 12);
            shellPanel.Controls.Add(topBarPanel);
            shellPanel.Controls.Add(contentPanel);
            shellPanel.Dock = DockStyle.Fill;
            shellPanel.Location = new Point(0, 0);
            shellPanel.Name = "shellPanel";
            shellPanel.Size = new Size(1440, 900);
            shellPanel.TabIndex = 0;
            shellPanel.Paint += shellPanel_Paint;
            // 
            // topBarPanel
            // 
            topBarPanel.BackColor = Color.FromArgb(12, 15, 21);
            topBarPanel.Controls.Add(toolbarInfoLabel);
            topBarPanel.Controls.Add(toolbarModeLabel);
            topBarPanel.Controls.Add(closeWindowButton);
            topBarPanel.Controls.Add(minimizeWindowButton);
            topBarPanel.Controls.Add(appSubtitleLabel);
            topBarPanel.Controls.Add(appNameLabel);
            topBarPanel.Controls.Add(brandLogoPictureBox);
            topBarPanel.Location = new Point(100, 26);
            topBarPanel.Name = "topBarPanel";
            topBarPanel.Size = new Size(1240, 64);
            topBarPanel.TabIndex = 1;
            topBarPanel.Paint += surfacePanel_Paint;
            // 
            // toolbarInfoLabel
            // 
            toolbarInfoLabel.AutoSize = true;
            toolbarInfoLabel.ForeColor = Color.FromArgb(185, 185, 185);
            toolbarInfoLabel.Location = new Point(608, 23);
            toolbarInfoLabel.Name = "toolbarInfoLabel";
            toolbarInfoLabel.Size = new Size(156, 20);
            toolbarInfoLabel.TabIndex = 6;
            toolbarInfoLabel.Text = "Secure desktop access";
            // 
            // toolbarModeLabel
            // 
            toolbarModeLabel.BackColor = Color.FromArgb(32, 40, 36);
            toolbarModeLabel.ForeColor = Color.FromArgb(146, 228, 180);
            toolbarModeLabel.Location = new Point(854, 17);
            toolbarModeLabel.Name = "toolbarModeLabel";
            toolbarModeLabel.Size = new Size(108, 30);
            toolbarModeLabel.TabIndex = 5;
            toolbarModeLabel.Text = "Player Mode";
            toolbarModeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // closeWindowButton
            // 
            closeWindowButton.BackColor = Color.FromArgb(159, 49, 49);
            closeWindowButton.FlatAppearance.BorderSize = 0;
            closeWindowButton.FlatStyle = FlatStyle.Flat;
            closeWindowButton.ForeColor = Color.White;
            closeWindowButton.Location = new Point(1188, 12);
            closeWindowButton.Name = "closeWindowButton";
            closeWindowButton.Size = new Size(36, 36);
            closeWindowButton.TabIndex = 4;
            closeWindowButton.Text = "X";
            closeWindowButton.UseVisualStyleBackColor = false;
            // 
            // minimizeWindowButton
            // 
            minimizeWindowButton.BackColor = Color.FromArgb(37, 43, 57);
            minimizeWindowButton.FlatAppearance.BorderSize = 0;
            minimizeWindowButton.FlatStyle = FlatStyle.Flat;
            minimizeWindowButton.ForeColor = Color.White;
            minimizeWindowButton.Location = new Point(1146, 12);
            minimizeWindowButton.Name = "minimizeWindowButton";
            minimizeWindowButton.Size = new Size(36, 36);
            minimizeWindowButton.TabIndex = 3;
            minimizeWindowButton.Text = "_";
            minimizeWindowButton.UseVisualStyleBackColor = false;
            // 
            // appSubtitleLabel
            // 
            appSubtitleLabel.AutoSize = true;
            appSubtitleLabel.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            appSubtitleLabel.ForeColor = Color.FromArgb(138, 161, 255);
            appSubtitleLabel.Location = new Point(72, 43);
            appSubtitleLabel.Name = "appSubtitleLabel";
            appSubtitleLabel.Size = new Size(88, 17);
            appSubtitleLabel.TabIndex = 2;
            appSubtitleLabel.Text = "User launcher";
            // 
            // appNameLabel
            // 
            appNameLabel.AutoSize = true;
            appNameLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            appNameLabel.ForeColor = Color.White;
            appNameLabel.Location = new Point(72, 8);
            appNameLabel.Name = "appNameLabel";
            appNameLabel.Size = new Size(84, 35);
            appNameLabel.TabIndex = 1;
            appNameLabel.Text = "NestG";
            // 
            // brandLogoPictureBox
            // 
            brandLogoPictureBox.Location = new Point(18, 12);
            brandLogoPictureBox.Name = "brandLogoPictureBox";
            brandLogoPictureBox.Size = new Size(40, 40);
            brandLogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            brandLogoPictureBox.TabIndex = 0;
            brandLogoPictureBox.TabStop = false;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(12, 15, 21);
            contentPanel.Controls.Add(showcasePanel);
            contentPanel.Controls.Add(loginCardPanel);
            contentPanel.Location = new Point(100, 106);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1240, 720);
            contentPanel.TabIndex = 0;
            contentPanel.Paint += surfacePanel_Paint;
            // 
            // showcasePanel
            // 
            showcasePanel.BackColor = Color.Transparent;
            showcasePanel.Controls.Add(supportCardPanel);
            showcasePanel.Controls.Add(featureCardPanel);
            showcasePanel.Controls.Add(supportChipLabel);
            showcasePanel.Controls.Add(securityChipLabel);
            showcasePanel.Controls.Add(speedChipLabel);
            showcasePanel.Controls.Add(showcaseDescriptionLabel);
            showcasePanel.Controls.Add(showcaseTitleLabel);
            showcasePanel.Controls.Add(overlineLabel);
            showcasePanel.Controls.Add(launcherChipLabel);
            showcasePanel.Controls.Add(brandChipLabel);
            showcasePanel.Controls.Add(showcaseFooterLabel);
            showcasePanel.Location = new Point(27, 28);
            showcasePanel.Name = "showcasePanel";
            showcasePanel.Size = new Size(727, 664);
            showcasePanel.TabIndex = 0;
            // 
            // supportCardPanel
            // 
            supportCardPanel.BackColor = Color.FromArgb(18, 22, 30);
            supportCardPanel.Controls.Add(supportDescriptionLabel);
            supportCardPanel.Controls.Add(supportTitleLabel);
            supportCardPanel.Location = new Point(0, 568);
            supportCardPanel.Name = "supportCardPanel";
            supportCardPanel.Size = new Size(680, 86);
            supportCardPanel.TabIndex = 9;
            supportCardPanel.Paint += surfacePanel_Paint;
            // 
            // supportDescriptionLabel
            // 
            supportDescriptionLabel.ForeColor = Color.FromArgb(185, 185, 185);
            supportDescriptionLabel.Location = new Point(20, 38);
            supportDescriptionLabel.Name = "supportDescriptionLabel";
            supportDescriptionLabel.Size = new Size(634, 34);
            supportDescriptionLabel.TabIndex = 1;
            supportDescriptionLabel.Text = "Neu user quen mat khau hoac can tro giup, ban co the noi tiep flow OTP va ticket ho tro ngay tai day.";
            // 
            // supportTitleLabel
            // 
            supportTitleLabel.AutoSize = true;
            supportTitleLabel.Font = new Font("Segoe UI Semibold", 12.5F, FontStyle.Bold);
            supportTitleLabel.ForeColor = Color.White;
            supportTitleLabel.Location = new Point(20, 10);
            supportTitleLabel.Name = "supportTitleLabel";
            supportTitleLabel.Size = new Size(142, 30);
            supportTitleLabel.TabIndex = 0;
            supportTitleLabel.Text = "Can tro giup?";
            // 
            // featureCardPanel
            // 
            featureCardPanel.BackColor = Color.FromArgb(18, 21, 27);
            featureCardPanel.Controls.Add(featureItemThreeLabel);
            featureCardPanel.Controls.Add(featureItemTwoLabel);
            featureCardPanel.Controls.Add(featureItemOneLabel);
            featureCardPanel.Controls.Add(featureDescriptionLabel);
            featureCardPanel.Controls.Add(featureTitleLabel);
            featureCardPanel.Location = new Point(0, 342);
            featureCardPanel.Name = "featureCardPanel";
            featureCardPanel.Size = new Size(680, 208);
            featureCardPanel.TabIndex = 8;
            featureCardPanel.Paint += surfacePanel_Paint;
            // 
            // featureItemThreeLabel
            // 
            featureItemThreeLabel.ForeColor = Color.White;
            featureItemThreeLabel.Location = new Point(24, 170);
            featureItemThreeLabel.Name = "featureItemThreeLabel";
            featureItemThreeLabel.Size = new Size(620, 22);
            featureItemThreeLabel.TabIndex = 4;
            featureItemThreeLabel.Text = "- San sang mo rong cho OTP, dang ky va xac minh thiet bi ve sau.";
            // 
            // featureItemTwoLabel
            // 
            featureItemTwoLabel.ForeColor = Color.White;
            featureItemTwoLabel.Location = new Point(24, 144);
            featureItemTwoLabel.Name = "featureItemTwoLabel";
            featureItemTwoLabel.Size = new Size(620, 22);
            featureItemTwoLabel.TabIndex = 3;
            featureItemTwoLabel.Text = "- Nhan thong bao don mua, giao dich va voucher ngay khi mo launcher.";
            // 
            // featureItemOneLabel
            // 
            featureItemOneLabel.ForeColor = Color.White;
            featureItemOneLabel.Location = new Point(24, 118);
            featureItemOneLabel.Name = "featureItemOneLabel";
            featureItemOneLabel.Size = new Size(620, 22);
            featureItemOneLabel.TabIndex = 2;
            featureItemOneLabel.Text = "- Dang nhap vao kho game, don mua va lich su account tren mot giao dien thong nhat.";
            // 
            // featureDescriptionLabel
            // 
            featureDescriptionLabel.ForeColor = Color.FromArgb(185, 185, 185);
            featureDescriptionLabel.Location = new Point(24, 56);
            featureDescriptionLabel.Name = "featureDescriptionLabel";
            featureDescriptionLabel.Size = new Size(620, 42);
            featureDescriptionLabel.TabIndex = 1;
            featureDescriptionLabel.Text = "Form dang nhap nay duoc viet lai theo theme dark premium cua web\r\nnhung toi uu de launcher desktop hien ro rang va de thao tac.";
            // 
            // featureTitleLabel
            // 
            featureTitleLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            featureTitleLabel.ForeColor = Color.White;
            featureTitleLabel.Location = new Point(24, 18);
            featureTitleLabel.Name = "featureTitleLabel";
            featureTitleLabel.Size = new Size(360, 30);
            featureTitleLabel.TabIndex = 0;
            featureTitleLabel.Text = "Tai sao user nen dang nhap?";
            featureTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // supportChipLabel
            // 
            supportChipLabel.BackColor = Color.FromArgb(32, 40, 36);
            supportChipLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            supportChipLabel.ForeColor = Color.FromArgb(146, 228, 180);
            supportChipLabel.Location = new Point(294, 276);
            supportChipLabel.Name = "supportChipLabel";
            supportChipLabel.Size = new Size(112, 36);
            supportChipLabel.TabIndex = 7;
            supportChipLabel.Text = "Ho tro 24/7";
            supportChipLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // securityChipLabel
            // 
            securityChipLabel.BackColor = Color.FromArgb(31, 39, 55);
            securityChipLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            securityChipLabel.ForeColor = Color.FromArgb(152, 193, 255);
            securityChipLabel.Location = new Point(152, 276);
            securityChipLabel.Name = "securityChipLabel";
            securityChipLabel.Size = new Size(128, 36);
            securityChipLabel.TabIndex = 6;
            securityChipLabel.Text = "Bao mat 2 lop";
            securityChipLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // speedChipLabel
            // 
            speedChipLabel.BackColor = Color.FromArgb(45, 34, 23);
            speedChipLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            speedChipLabel.ForeColor = Color.FromArgb(255, 184, 125);
            speedChipLabel.Location = new Point(0, 276);
            speedChipLabel.Name = "speedChipLabel";
            speedChipLabel.Size = new Size(136, 36);
            speedChipLabel.TabIndex = 5;
            speedChipLabel.Text = "Kich hoat nhanh";
            speedChipLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // showcaseDescriptionLabel
            // 
            showcaseDescriptionLabel.ForeColor = Color.FromArgb(185, 185, 185);
            showcaseDescriptionLabel.Location = new Point(0, 210);
            showcaseDescriptionLabel.Name = "showcaseDescriptionLabel";
            showcaseDescriptionLabel.Size = new Size(640, 54);
            showcaseDescriptionLabel.TabIndex = 4;
            showcaseDescriptionLabel.Text = "Dang nhap de vao kho game, account va uu dai cua ban tren mot giao\r\ndien desktop ro rang, dam chat gaming premium.";
            // 
            // showcaseTitleLabel
            // 
            showcaseTitleLabel.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            showcaseTitleLabel.ForeColor = Color.White;
            showcaseTitleLabel.Location = new Point(0, 88);
            showcaseTitleLabel.Name = "showcaseTitleLabel";
            showcaseTitleLabel.Size = new Size(660, 108);
            showcaseTitleLabel.TabIndex = 3;
            showcaseTitleLabel.Text = "Dang nhap de vao kho game,\r\naccount va uu dai cua ban.";
            // 
            // overlineLabel
            // 
            overlineLabel.AutoSize = true;
            overlineLabel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            overlineLabel.ForeColor = Color.FromArgb(130, 182, 255);
            overlineLabel.Location = new Point(0, 58);
            overlineLabel.Name = "overlineLabel";
            overlineLabel.Size = new Size(172, 21);
            overlineLabel.TabIndex = 2;
            overlineLabel.Text = "TRUY CAP TAI KHOAN";
            // 
            // launcherChipLabel
            // 
            launcherChipLabel.AutoSize = true;
            launcherChipLabel.BackColor = Color.FromArgb(36, 44, 61);
            launcherChipLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            launcherChipLabel.ForeColor = Color.FromArgb(138, 161, 255);
            launcherChipLabel.Location = new Point(156, 0);
            launcherChipLabel.Name = "launcherChipLabel";
            launcherChipLabel.Padding = new Padding(14, 8, 14, 8);
            launcherChipLabel.Size = new Size(135, 36);
            launcherChipLabel.TabIndex = 1;
            launcherChipLabel.Text = "User Launcher";
            // 
            // brandChipLabel
            // 
            brandChipLabel.AutoSize = true;
            brandChipLabel.BackColor = Color.FromArgb(52, 76, 198);
            brandChipLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            brandChipLabel.ForeColor = Color.White;
            brandChipLabel.Location = new Point(0, 0);
            brandChipLabel.Name = "brandChipLabel";
            brandChipLabel.Padding = new Padding(14, 8, 14, 8);
            brandChipLabel.Size = new Size(82, 36);
            brandChipLabel.TabIndex = 0;
            brandChipLabel.Text = "NESTG";
            // 
            // showcaseFooterLabel
            // 
            showcaseFooterLabel.AutoSize = true;
            showcaseFooterLabel.ForeColor = Color.FromArgb(130, 136, 149);
            showcaseFooterLabel.Location = new Point(0, 644);
            showcaseFooterLabel.Name = "showcaseFooterLabel";
            showcaseFooterLabel.Size = new Size(0, 20);
            showcaseFooterLabel.TabIndex = 10;
            // 
            // loginCardPanel
            // 
            loginCardPanel.BackColor = Color.FromArgb(23, 25, 31);
            loginCardPanel.Controls.Add(registerLink);
            loginCardPanel.Controls.Add(registerPromptLabel);
            loginCardPanel.Controls.Add(securityNotePanel);
            loginCardPanel.Controls.Add(otpButton);
            loginCardPanel.Controls.Add(loginButton);
            loginCardPanel.Controls.Add(showPasswordCheckBox);
            loginCardPanel.Controls.Add(forgotPasswordLink);
            loginCardPanel.Controls.Add(rememberMeCheckBox);
            loginCardPanel.Controls.Add(passwordFieldPanel);
            loginCardPanel.Controls.Add(passwordCaptionLabel);
            loginCardPanel.Controls.Add(emailFieldPanel);
            loginCardPanel.Controls.Add(emailCaptionLabel);
            loginCardPanel.Controls.Add(loginDescriptionLabel);
            loginCardPanel.Controls.Add(loginTitleLabel);
            loginCardPanel.Controls.Add(loginSecurityChipLabel);
            loginCardPanel.Controls.Add(loginTagChipLabel);
            loginCardPanel.Location = new Point(770, 28);
            loginCardPanel.Name = "loginCardPanel";
            loginCardPanel.Size = new Size(436, 664);
            loginCardPanel.TabIndex = 1;
            loginCardPanel.Paint += surfacePanel_Paint;
            // 
            // registerLink
            // 
            registerLink.ActiveLinkColor = Color.FromArgb(138, 186, 255);
            registerLink.AutoSize = true;
            registerLink.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            registerLink.LinkColor = Color.FromArgb(93, 157, 255);
            registerLink.Location = new Point(176, 623);
            registerLink.Name = "registerLink";
            registerLink.Size = new Size(137, 21);
            registerLink.TabIndex = 15;
            registerLink.TabStop = true;
            registerLink.Text = "Tao tai khoan moi";
            registerLink.VisitedLinkColor = Color.FromArgb(93, 157, 255);
            // 
            // registerPromptLabel
            // 
            registerPromptLabel.AutoSize = true;
            registerPromptLabel.ForeColor = Color.FromArgb(185, 185, 185);
            registerPromptLabel.Location = new Point(36, 624);
            registerPromptLabel.Name = "registerPromptLabel";
            registerPromptLabel.Size = new Size(134, 20);
            registerPromptLabel.TabIndex = 14;
            registerPromptLabel.Text = "Chua co tai khoan?";
            // 
            // securityNotePanel
            // 
            securityNotePanel.BackColor = Color.FromArgb(18, 21, 27);
            securityNotePanel.Controls.Add(securityNoteBodyLabel);
            securityNotePanel.Controls.Add(securityNoteTitleLabel);
            securityNotePanel.Location = new Point(36, 522);
            securityNotePanel.Name = "securityNotePanel";
            securityNotePanel.Size = new Size(364, 88);
            securityNotePanel.TabIndex = 13;
            securityNotePanel.Paint += surfacePanel_Paint;
            // 
            // securityNoteBodyLabel
            // 
            securityNoteBodyLabel.ForeColor = Color.FromArgb(185, 185, 185);
            securityNoteBodyLabel.Location = new Point(16, 40);
            securityNoteBodyLabel.Name = "securityNoteBodyLabel";
            securityNoteBodyLabel.Size = new Size(332, 34);
            securityNoteBodyLabel.TabIndex = 1;
            securityNoteBodyLabel.Text = "San sang noi OTP, canh bao thiet bi la va xac minh\r\ndang nhap ve sau.";
            // 
            // securityNoteTitleLabel
            // 
            securityNoteTitleLabel.AutoSize = true;
            securityNoteTitleLabel.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            securityNoteTitleLabel.ForeColor = Color.White;
            securityNoteTitleLabel.Location = new Point(16, 10);
            securityNoteTitleLabel.Name = "securityNoteTitleLabel";
            securityNoteTitleLabel.Size = new Size(187, 28);
            securityNoteTitleLabel.TabIndex = 0;
            securityNoteTitleLabel.Text = "Dang nhap an toan";
            // 
            // otpButton
            // 
            otpButton.BackColor = Color.FromArgb(202, 92, 33);
            otpButton.FlatAppearance.BorderSize = 0;
            otpButton.FlatStyle = FlatStyle.Flat;
            otpButton.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            otpButton.ForeColor = Color.White;
            otpButton.Location = new Point(278, 458);
            otpButton.Name = "otpButton";
            otpButton.Size = new Size(122, 46);
            otpButton.TabIndex = 12;
            otpButton.Text = "Nhan OTP";
            otpButton.UseVisualStyleBackColor = false;
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.FromArgb(49, 90, 152);
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            loginButton.ForeColor = Color.White;
            loginButton.Location = new Point(36, 458);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(226, 46);
            loginButton.TabIndex = 11;
            loginButton.Text = "Dang nhap";
            loginButton.UseVisualStyleBackColor = false;
            // 
            // showPasswordCheckBox
            // 
            showPasswordCheckBox.AutoSize = true;
            showPasswordCheckBox.FlatStyle = FlatStyle.Flat;
            showPasswordCheckBox.ForeColor = Color.FromArgb(230, 230, 230);
            showPasswordCheckBox.Location = new Point(36, 424);
            showPasswordCheckBox.Name = "showPasswordCheckBox";
            showPasswordCheckBox.Size = new Size(123, 24);
            showPasswordCheckBox.TabIndex = 10;
            showPasswordCheckBox.Text = "Hien mat khau";
            showPasswordCheckBox.UseVisualStyleBackColor = true;
            // 
            // forgotPasswordLink
            // 
            forgotPasswordLink.ActiveLinkColor = Color.FromArgb(138, 186, 255);
            forgotPasswordLink.AutoSize = true;
            forgotPasswordLink.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            forgotPasswordLink.LinkColor = Color.FromArgb(93, 157, 255);
            forgotPasswordLink.Location = new Point(284, 396);
            forgotPasswordLink.Name = "forgotPasswordLink";
            forgotPasswordLink.Size = new Size(126, 21);
            forgotPasswordLink.TabIndex = 9;
            forgotPasswordLink.TabStop = true;
            forgotPasswordLink.Text = "Quen mat khau?";
            forgotPasswordLink.VisitedLinkColor = Color.FromArgb(93, 157, 255);
            // 
            // rememberMeCheckBox
            // 
            rememberMeCheckBox.AutoSize = true;
            rememberMeCheckBox.FlatStyle = FlatStyle.Flat;
            rememberMeCheckBox.ForeColor = Color.FromArgb(230, 230, 230);
            rememberMeCheckBox.Location = new Point(36, 394);
            rememberMeCheckBox.Name = "rememberMeCheckBox";
            rememberMeCheckBox.Size = new Size(156, 24);
            rememberMeCheckBox.TabIndex = 8;
            rememberMeCheckBox.Text = "Ghi nho thiet bi nay";
            rememberMeCheckBox.UseVisualStyleBackColor = true;
            // 
            // passwordFieldPanel
            // 
            passwordFieldPanel.BackColor = Color.FromArgb(31, 35, 43);
            passwordFieldPanel.Controls.Add(passwordTextBox);
            passwordFieldPanel.Location = new Point(36, 326);
            passwordFieldPanel.Name = "passwordFieldPanel";
            passwordFieldPanel.Size = new Size(364, 50);
            passwordFieldPanel.TabIndex = 7;
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = Color.FromArgb(31, 35, 43);
            passwordTextBox.BorderStyle = BorderStyle.None;
            passwordTextBox.ForeColor = Color.White;
            passwordTextBox.Location = new Point(16, 16);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PlaceholderText = "Nhap mat khau";
            passwordTextBox.Size = new Size(332, 20);
            passwordTextBox.TabIndex = 0;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // passwordCaptionLabel
            // 
            passwordCaptionLabel.AutoSize = true;
            passwordCaptionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            passwordCaptionLabel.ForeColor = Color.White;
            passwordCaptionLabel.Location = new Point(36, 302);
            passwordCaptionLabel.Name = "passwordCaptionLabel";
            passwordCaptionLabel.Size = new Size(84, 23);
            passwordCaptionLabel.TabIndex = 6;
            passwordCaptionLabel.Text = "Mat khau";
            // 
            // emailFieldPanel
            // 
            emailFieldPanel.BackColor = Color.FromArgb(31, 35, 43);
            emailFieldPanel.Controls.Add(emailTextBox);
            emailFieldPanel.Location = new Point(36, 232);
            emailFieldPanel.Name = "emailFieldPanel";
            emailFieldPanel.Size = new Size(364, 50);
            emailFieldPanel.TabIndex = 5;
            // 
            // emailTextBox
            // 
            emailTextBox.BackColor = Color.FromArgb(31, 35, 43);
            emailTextBox.BorderStyle = BorderStyle.None;
            emailTextBox.ForeColor = Color.White;
            emailTextBox.Location = new Point(16, 16);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.PlaceholderText = "Nhap email hoac so dien thoai";
            emailTextBox.Size = new Size(332, 20);
            emailTextBox.TabIndex = 0;
            // 
            // emailCaptionLabel
            // 
            emailCaptionLabel.AutoSize = true;
            emailCaptionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            emailCaptionLabel.ForeColor = Color.White;
            emailCaptionLabel.Location = new Point(36, 208);
            emailCaptionLabel.Name = "emailCaptionLabel";
            emailCaptionLabel.Size = new Size(197, 23);
            emailCaptionLabel.TabIndex = 4;
            emailCaptionLabel.Text = "Email hoac so dien thoai";
            // 
            // loginDescriptionLabel
            // 
            loginDescriptionLabel.ForeColor = Color.FromArgb(185, 185, 185);
            loginDescriptionLabel.Location = new Point(36, 134);
            loginDescriptionLabel.Name = "loginDescriptionLabel";
            loginDescriptionLabel.Size = new Size(364, 52);
            loginDescriptionLabel.TabIndex = 3;
            loginDescriptionLabel.Text = "Dang nhap de quan ly tai khoan,\r\ndon mua, account game va uu dai danh rieng cho ban.";
            // 
            // loginTitleLabel
            // 
            loginTitleLabel.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            loginTitleLabel.ForeColor = Color.White;
            loginTitleLabel.Location = new Point(36, 74);
            loginTitleLabel.Name = "loginTitleLabel";
            loginTitleLabel.Size = new Size(320, 44);
            loginTitleLabel.TabIndex = 2;
            loginTitleLabel.Text = "Chao mung den NestG";
            loginTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // loginSecurityChipLabel
            // 
            loginSecurityChipLabel.AutoSize = true;
            loginSecurityChipLabel.BackColor = Color.FromArgb(45, 34, 23);
            loginSecurityChipLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            loginSecurityChipLabel.ForeColor = Color.FromArgb(255, 184, 125);
            loginSecurityChipLabel.Location = new Point(150, 28);
            loginSecurityChipLabel.Name = "loginSecurityChipLabel";
            loginSecurityChipLabel.Padding = new Padding(14, 8, 14, 8);
            loginSecurityChipLabel.Size = new Size(131, 36);
            loginSecurityChipLabel.TabIndex = 1;
            loginSecurityChipLabel.Text = "Bao mat 2 lop";
            // 
            // loginTagChipLabel
            // 
            loginTagChipLabel.AutoSize = true;
            loginTagChipLabel.BackColor = Color.FromArgb(37, 43, 57);
            loginTagChipLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            loginTagChipLabel.ForeColor = Color.FromArgb(130, 182, 255);
            loginTagChipLabel.Location = new Point(36, 28);
            loginTagChipLabel.Name = "loginTagChipLabel";
            loginTagChipLabel.Padding = new Padding(14, 8, 14, 8);
            loginTagChipLabel.Size = new Size(121, 36);
            loginTagChipLabel.TabIndex = 0;
            loginTagChipLabel.Text = "USER LOGIN";
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(6, 8, 12);
            ClientSize = new Size(1440, 900);
            Controls.Add(shellPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NestG";
            shellPanel.ResumeLayout(false);
            topBarPanel.ResumeLayout(false);
            topBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)brandLogoPictureBox).EndInit();
            contentPanel.ResumeLayout(false);
            showcasePanel.ResumeLayout(false);
            showcasePanel.PerformLayout();
            supportCardPanel.ResumeLayout(false);
            supportCardPanel.PerformLayout();
            featureCardPanel.ResumeLayout(false);
            loginCardPanel.ResumeLayout(false);
            loginCardPanel.PerformLayout();
            securityNotePanel.ResumeLayout(false);
            securityNotePanel.PerformLayout();
            passwordFieldPanel.ResumeLayout(false);
            passwordFieldPanel.PerformLayout();
            emailFieldPanel.ResumeLayout(false);
            emailFieldPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel shellPanel;
        private Panel topBarPanel;
        private Label toolbarInfoLabel;
        private Label toolbarModeLabel;
        private Button closeWindowButton;
        private Button minimizeWindowButton;
        private Label appSubtitleLabel;
        private Label appNameLabel;
        private PictureBox brandLogoPictureBox;
        private Panel contentPanel;
        private Panel showcasePanel;
        private Panel supportCardPanel;
        private Label supportDescriptionLabel;
        private Label supportTitleLabel;
        private Panel featureCardPanel;
        private Label featureItemThreeLabel;
        private Label featureItemTwoLabel;
        private Label featureItemOneLabel;
        private Label featureDescriptionLabel;
        private Label featureTitleLabel;
        private Label supportChipLabel;
        private Label securityChipLabel;
        private Label speedChipLabel;
        private Label showcaseDescriptionLabel;
        private Label showcaseTitleLabel;
        private Label overlineLabel;
        private Label launcherChipLabel;
        private Label brandChipLabel;
        private Label showcaseFooterLabel;
        private Panel loginCardPanel;
        private LinkLabel registerLink;
        private Label registerPromptLabel;
        private Panel securityNotePanel;
        private Label securityNoteBodyLabel;
        private Label securityNoteTitleLabel;
        private Button otpButton;
        private Button loginButton;
        private CheckBox showPasswordCheckBox;
        private LinkLabel forgotPasswordLink;
        private CheckBox rememberMeCheckBox;
        private Panel passwordFieldPanel;
        private TextBox passwordTextBox;
        private Label passwordCaptionLabel;
        private Panel emailFieldPanel;
        private TextBox emailTextBox;
        private Label emailCaptionLabel;
        private Label loginDescriptionLabel;
        private Label loginTitleLabel;
        private Label loginSecurityChipLabel;
        private Label loginTagChipLabel;
    }
}
