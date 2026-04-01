using UI_Desktop;

namespace UI_Desktop.Auth;

partial class RegisterForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        rootLayout = new TableLayoutPanel();
        heroPanel = new RoundedPanel();
        heroBulletThreeLabel = new Label();
        heroBulletTwoLabel = new Label();
        heroBulletOneLabel = new Label();
        heroDescriptionLabel = new Label();
        heroTitleLabel = new Label();
        heroBadgeLabel = new Label();
        heroMetaLabel = new Label();
        heroAppNameLabel = new Label();
        heroLogoPictureBox = new PictureBox();
        cardPanel = new RoundedPanel();
        loginLinkLabel = new LinkLabel();
        footerPromptLabel = new Label();
        continueButton = new GradientButton();
        passwordHintLabel = new Label();
        passwordFieldPanel = new RoundedPanel();
        passwordTextBox = new TextBox();
        passwordCaptionLabel = new Label();
        emailFieldPanel = new RoundedPanel();
        emailTextBox = new TextBox();
        emailCaptionLabel = new Label();
        usernameFieldPanel = new RoundedPanel();
        usernameTextBox = new TextBox();
        usernameCaptionLabel = new Label();
        displayNameFieldPanel = new RoundedPanel();
        displayNameTextBox = new TextBox();
        displayNameCaptionLabel = new Label();
        subtitleLabel = new Label();
        titleLabel = new Label();
        cardMetaLabel = new Label();
        cardAppNameLabel = new Label();
        cardLogoPictureBox = new PictureBox();
        rootLayout.SuspendLayout();
        heroPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)heroLogoPictureBox).BeginInit();
        cardPanel.SuspendLayout();
        passwordFieldPanel.SuspendLayout();
        emailFieldPanel.SuspendLayout();
        usernameFieldPanel.SuspendLayout();
        displayNameFieldPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)cardLogoPictureBox).BeginInit();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.BackColor = Color.FromArgb(13, 18, 25);
        rootLayout.ColumnCount = 2;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43F));
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57F));
        rootLayout.Controls.Add(heroPanel, 0, 0);
        rootLayout.Controls.Add(cardPanel, 1, 0);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.Padding = new Padding(24);
        rootLayout.RowCount = 1;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayout.Size = new Size(1264, 761);
        rootLayout.TabIndex = 0;
        // 
        // heroPanel
        // 
        heroPanel.BackColor = Color.Transparent;
        heroPanel.Controls.Add(heroBulletThreeLabel);
        heroPanel.Controls.Add(heroBulletTwoLabel);
        heroPanel.Controls.Add(heroBulletOneLabel);
        heroPanel.Controls.Add(heroDescriptionLabel);
        heroPanel.Controls.Add(heroTitleLabel);
        heroPanel.Controls.Add(heroBadgeLabel);
        heroPanel.Controls.Add(heroMetaLabel);
        heroPanel.Controls.Add(heroAppNameLabel);
        heroPanel.Controls.Add(heroLogoPictureBox);
        heroPanel.Dock = DockStyle.Fill;
        heroPanel.Location = new Point(24, 24);
        heroPanel.Margin = new Padding(0, 0, 18, 0);
        heroPanel.Name = "heroPanel";
        heroPanel.Size = new Size(504, 713);
        heroPanel.TabIndex = 0;
        // 
        // heroBulletThreeLabel
        // 
        heroBulletThreeLabel.Font = new Font("Segoe UI", 10.25F);
        heroBulletThreeLabel.ForeColor = Color.FromArgb(239, 243, 248);
        heroBulletThreeLabel.Location = new Point(34, 522);
        heroBulletThreeLabel.Name = "heroBulletThreeLabel";
        heroBulletThreeLabel.Size = new Size(396, 48);
        heroBulletThreeLabel.TabIndex = 8;
        heroBulletThreeLabel.Text = "• Hoàn tất đăng ký để đăng nhập và bắt đầu sử dụng ngay.";
        // 
        // heroBulletTwoLabel
        // 
        heroBulletTwoLabel.Font = new Font("Segoe UI", 10.25F);
        heroBulletTwoLabel.ForeColor = Color.FromArgb(239, 243, 248);
        heroBulletTwoLabel.Location = new Point(34, 462);
        heroBulletTwoLabel.Name = "heroBulletTwoLabel";
        heroBulletTwoLabel.Size = new Size(396, 48);
        heroBulletTwoLabel.TabIndex = 7;
        heroBulletTwoLabel.Text = "• Dùng email đang hoạt động để nhận xác thực và hỗ trợ tài khoản.";
        // 
        // heroBulletOneLabel
        // 
        heroBulletOneLabel.Font = new Font("Segoe UI", 10.25F);
        heroBulletOneLabel.ForeColor = Color.FromArgb(239, 243, 248);
        heroBulletOneLabel.Location = new Point(34, 402);
        heroBulletOneLabel.Name = "heroBulletOneLabel";
        heroBulletOneLabel.Size = new Size(396, 48);
        heroBulletOneLabel.TabIndex = 6;
        heroBulletOneLabel.Text = "• Chọn tên hiển thị để mọi người dễ nhận ra bạn.";
        // 
        // heroDescriptionLabel
        // 
        heroDescriptionLabel.Font = new Font("Segoe UI", 10.5F);
        heroDescriptionLabel.ForeColor = Color.FromArgb(162, 174, 191);
        heroDescriptionLabel.Location = new Point(34, 300);
        heroDescriptionLabel.Name = "heroDescriptionLabel";
        heroDescriptionLabel.Size = new Size(396, 74);
        heroDescriptionLabel.TabIndex = 5;
        heroDescriptionLabel.Text = "Điền thông tin cơ bản để bắt đầu sử dụng launcher và nhận các thông báo cần thiết từ hệ thống.";
        // 
        // heroTitleLabel
        // 
        heroTitleLabel.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
        heroTitleLabel.ForeColor = Color.FromArgb(239, 243, 248);
        heroTitleLabel.Location = new Point(34, 172);
        heroTitleLabel.Name = "heroTitleLabel";
        heroTitleLabel.Size = new Size(390, 112);
        heroTitleLabel.TabIndex = 4;
        heroTitleLabel.Text = "Tạo tài khoản NestG";
        // 
        // heroBadgeLabel
        // 
        heroBadgeLabel.AutoSize = true;
        heroBadgeLabel.BackColor = Color.FromArgb(30, 56, 101);
        heroBadgeLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        heroBadgeLabel.ForeColor = Color.FromArgb(185, 213, 255);
        heroBadgeLabel.Location = new Point(34, 116);
        heroBadgeLabel.Name = "heroBadgeLabel";
        heroBadgeLabel.Padding = new Padding(14, 8, 14, 8);
        heroBadgeLabel.Size = new Size(148, 36);
        heroBadgeLabel.TabIndex = 3;
        heroBadgeLabel.Text = "TẠO TÀI KHOẢN";
        // 
        // heroMetaLabel
        // 
        heroMetaLabel.AutoSize = true;
        heroMetaLabel.Font = new Font("Segoe UI", 9.5F);
        heroMetaLabel.ForeColor = Color.FromArgb(162, 174, 191);
        heroMetaLabel.Location = new Point(94, 62);
        heroMetaLabel.Name = "heroMetaLabel";
        heroMetaLabel.Size = new Size(162, 21);
        heroMetaLabel.TabIndex = 2;
        heroMetaLabel.Text = "Cổng tài khoản NestG";
        // 
        // heroAppNameLabel
        // 
        heroAppNameLabel.AutoSize = true;
        heroAppNameLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
        heroAppNameLabel.ForeColor = Color.FromArgb(239, 243, 248);
        heroAppNameLabel.Location = new Point(94, 36);
        heroAppNameLabel.Name = "heroAppNameLabel";
        heroAppNameLabel.Size = new Size(171, 30);
        heroAppNameLabel.TabIndex = 1;
        heroAppNameLabel.Text = "NestG Launcher";
        // 
        // heroLogoPictureBox
        // 
        heroLogoPictureBox.Location = new Point(34, 34);
        heroLogoPictureBox.Name = "heroLogoPictureBox";
        heroLogoPictureBox.Size = new Size(46, 46);
        heroLogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        heroLogoPictureBox.TabIndex = 0;
        heroLogoPictureBox.TabStop = false;
        // 
        // cardPanel
        // 
        cardPanel.BackColor = Color.Transparent;
        cardPanel.Controls.Add(loginLinkLabel);
        cardPanel.Controls.Add(footerPromptLabel);
        cardPanel.Controls.Add(continueButton);
        cardPanel.Controls.Add(passwordHintLabel);
        cardPanel.Controls.Add(passwordFieldPanel);
        cardPanel.Controls.Add(passwordCaptionLabel);
        cardPanel.Controls.Add(emailFieldPanel);
        cardPanel.Controls.Add(emailCaptionLabel);
        cardPanel.Controls.Add(usernameFieldPanel);
        cardPanel.Controls.Add(usernameCaptionLabel);
        cardPanel.Controls.Add(displayNameFieldPanel);
        cardPanel.Controls.Add(displayNameCaptionLabel);
        cardPanel.Controls.Add(subtitleLabel);
        cardPanel.Controls.Add(titleLabel);
        cardPanel.Controls.Add(cardMetaLabel);
        cardPanel.Controls.Add(cardAppNameLabel);
        cardPanel.Controls.Add(cardLogoPictureBox);
        cardPanel.Dock = DockStyle.Fill;
        cardPanel.Location = new Point(546, 24);
        cardPanel.Margin = new Padding(0);
        cardPanel.Name = "cardPanel";
        cardPanel.Size = new Size(694, 713);
        cardPanel.TabIndex = 1;
        // 
        // loginLinkLabel
        // 
        loginLinkLabel.ActiveLinkColor = Color.FromArgb(192, 216, 255);
        loginLinkLabel.Anchor = AnchorStyles.Bottom;
        loginLinkLabel.AutoSize = true;
        loginLinkLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        loginLinkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
        loginLinkLabel.LinkColor = Color.FromArgb(220, 232, 255);
        loginLinkLabel.Location = new Point(311, 684);
        loginLinkLabel.Name = "loginLinkLabel";
        loginLinkLabel.Size = new Size(161, 23);
        loginLinkLabel.TabIndex = 16;
        loginLinkLabel.TabStop = true;
        loginLinkLabel.Text = "Quay lại đăng nhập";
        loginLinkLabel.VisitedLinkColor = Color.FromArgb(220, 232, 255);
        loginLinkLabel.LinkClicked += loginLinkLabel_LinkClicked;
        // 
        // footerPromptLabel
        // 
        footerPromptLabel.Anchor = AnchorStyles.Bottom;
        footerPromptLabel.AutoSize = true;
        footerPromptLabel.Font = new Font("Segoe UI", 10F);
        footerPromptLabel.ForeColor = Color.FromArgb(143, 156, 176);
        footerPromptLabel.Location = new Point(194, 684);
        footerPromptLabel.Name = "footerPromptLabel";
        footerPromptLabel.Size = new Size(138, 23);
        footerPromptLabel.TabIndex = 15;
        footerPromptLabel.Text = "Đã có tài khoản?";
        // 
        // continueButton
        // 
        continueButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        continueButton.BackColor = Color.Transparent;
        continueButton.FlatAppearance.BorderSize = 0;
        continueButton.FlatStyle = FlatStyle.Flat;
        continueButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        continueButton.ForeColor = Color.White;
        continueButton.Location = new Point(38, 621);
        continueButton.MinimumSize = new Size(0, 56);
        continueButton.Name = "continueButton";
        continueButton.Size = new Size(618, 56);
        continueButton.TabIndex = 14;
        continueButton.Text = "Tiếp theo";
        continueButton.UseVisualStyleBackColor = true;
        continueButton.Click += continueButton_Click;
        // 
        // passwordHintLabel
        // 
        passwordHintLabel.AutoSize = true;
        passwordHintLabel.Font = new Font("Segoe UI", 9.25F);
        passwordHintLabel.ForeColor = Color.FromArgb(143, 156, 176);
        passwordHintLabel.Location = new Point(38, 668);
        passwordHintLabel.MaximumSize = new Size(520, 0);
        passwordHintLabel.Name = "passwordHintLabel";
        passwordHintLabel.Size = new Size(0, 21);
        passwordHintLabel.TabIndex = 13;
        passwordHintLabel.Visible = false;
        // 
        // passwordFieldPanel
        // 
        passwordFieldPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        passwordFieldPanel.BackColor = Color.Transparent;
        passwordFieldPanel.Controls.Add(passwordTextBox);
        passwordFieldPanel.Location = new Point(38, 558);
        passwordFieldPanel.Name = "passwordFieldPanel";
        passwordFieldPanel.Padding = new Padding(18, 15, 18, 15);
        passwordFieldPanel.Size = new Size(618, 54);
        passwordFieldPanel.TabIndex = 12;
        // 
        // passwordTextBox
        // 
        passwordTextBox.BackColor = Color.FromArgb(31, 40, 53);
        passwordTextBox.BorderStyle = BorderStyle.None;
        passwordTextBox.Dock = DockStyle.Fill;
        passwordTextBox.Font = new Font("Segoe UI", 11F);
        passwordTextBox.ForeColor = Color.FromArgb(239, 243, 248);
        passwordTextBox.Location = new Point(18, 15);
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.PlaceholderText = "Tối thiểu 6 ký tự";
        passwordTextBox.Size = new Size(582, 25);
        passwordTextBox.TabIndex = 0;
        passwordTextBox.UseSystemPasswordChar = true;
        // 
        // passwordCaptionLabel
        // 
        passwordCaptionLabel.AutoSize = true;
        passwordCaptionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        passwordCaptionLabel.ForeColor = Color.FromArgb(162, 174, 191);
        passwordCaptionLabel.Location = new Point(38, 525);
        passwordCaptionLabel.Name = "passwordCaptionLabel";
        passwordCaptionLabel.Size = new Size(84, 23);
        passwordCaptionLabel.TabIndex = 11;
        passwordCaptionLabel.Text = "Mật khẩu";
        // 
        // emailFieldPanel
        // 
        emailFieldPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        emailFieldPanel.BackColor = Color.Transparent;
        emailFieldPanel.Controls.Add(emailTextBox);
        emailFieldPanel.Location = new Point(38, 453);
        emailFieldPanel.Name = "emailFieldPanel";
        emailFieldPanel.Padding = new Padding(18, 15, 18, 15);
        emailFieldPanel.Size = new Size(618, 54);
        emailFieldPanel.TabIndex = 10;
        // 
        // emailTextBox
        // 
        emailTextBox.BackColor = Color.FromArgb(31, 40, 53);
        emailTextBox.BorderStyle = BorderStyle.None;
        emailTextBox.Dock = DockStyle.Fill;
        emailTextBox.Font = new Font("Segoe UI", 11F);
        emailTextBox.ForeColor = Color.FromArgb(239, 243, 248);
        emailTextBox.Location = new Point(18, 15);
        emailTextBox.Name = "emailTextBox";
        emailTextBox.PlaceholderText = "example@gmail.com";
        emailTextBox.Size = new Size(582, 25);
        emailTextBox.TabIndex = 0;
        // 
        // emailCaptionLabel
        // 
        emailCaptionLabel.AutoSize = true;
        emailCaptionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        emailCaptionLabel.ForeColor = Color.FromArgb(162, 174, 191);
        emailCaptionLabel.Location = new Point(38, 420);
        emailCaptionLabel.Name = "emailCaptionLabel";
        emailCaptionLabel.Size = new Size(108, 23);
        emailCaptionLabel.TabIndex = 9;
        emailCaptionLabel.Text = "Địa chỉ email";
        // 
        // usernameFieldPanel
        // 
        usernameFieldPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        usernameFieldPanel.BackColor = Color.Transparent;
        usernameFieldPanel.Controls.Add(usernameTextBox);
        usernameFieldPanel.Location = new Point(38, 348);
        usernameFieldPanel.Name = "usernameFieldPanel";
        usernameFieldPanel.Padding = new Padding(18, 15, 18, 15);
        usernameFieldPanel.Size = new Size(618, 54);
        usernameFieldPanel.TabIndex = 8;
        // 
        // usernameTextBox
        // 
        usernameTextBox.BackColor = Color.FromArgb(31, 40, 53);
        usernameTextBox.BorderStyle = BorderStyle.None;
        usernameTextBox.Dock = DockStyle.Fill;
        usernameTextBox.Font = new Font("Segoe UI", 11F);
        usernameTextBox.ForeColor = Color.FromArgb(239, 243, 248);
        usernameTextBox.Location = new Point(18, 15);
        usernameTextBox.Name = "usernameTextBox";
        usernameTextBox.PlaceholderText = "Ví dụ: nestg123";
        usernameTextBox.Size = new Size(582, 25);
        usernameTextBox.TabIndex = 0;
        // 
        // usernameCaptionLabel
        // 
        usernameCaptionLabel.AutoSize = true;
        usernameCaptionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        usernameCaptionLabel.ForeColor = Color.FromArgb(162, 174, 191);
        usernameCaptionLabel.Location = new Point(38, 315);
        usernameCaptionLabel.Name = "usernameCaptionLabel";
        usernameCaptionLabel.Size = new Size(124, 23);
        usernameCaptionLabel.TabIndex = 7;
        usernameCaptionLabel.Text = "Tên đăng nhập";
        // 
        // displayNameFieldPanel
        // 
        displayNameFieldPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        displayNameFieldPanel.BackColor = Color.Transparent;
        displayNameFieldPanel.Controls.Add(displayNameTextBox);
        displayNameFieldPanel.Location = new Point(38, 243);
        displayNameFieldPanel.Name = "displayNameFieldPanel";
        displayNameFieldPanel.Padding = new Padding(18, 15, 18, 15);
        displayNameFieldPanel.Size = new Size(618, 54);
        displayNameFieldPanel.TabIndex = 6;
        // 
        // displayNameTextBox
        // 
        displayNameTextBox.BackColor = Color.FromArgb(31, 40, 53);
        displayNameTextBox.BorderStyle = BorderStyle.None;
        displayNameTextBox.Dock = DockStyle.Fill;
        displayNameTextBox.Font = new Font("Segoe UI", 11F);
        displayNameTextBox.ForeColor = Color.FromArgb(239, 243, 248);
        displayNameTextBox.Location = new Point(18, 15);
        displayNameTextBox.Name = "displayNameTextBox";
        displayNameTextBox.PlaceholderText = "Ví dụ: Nguyễn Văn A";
        displayNameTextBox.Size = new Size(582, 25);
        displayNameTextBox.TabIndex = 0;
        // 
        // displayNameCaptionLabel
        // 
        displayNameCaptionLabel.AutoSize = true;
        displayNameCaptionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        displayNameCaptionLabel.ForeColor = Color.FromArgb(162, 174, 191);
        displayNameCaptionLabel.Location = new Point(38, 210);
        displayNameCaptionLabel.Name = "displayNameCaptionLabel";
        displayNameCaptionLabel.Size = new Size(99, 23);
        displayNameCaptionLabel.TabIndex = 5;
        displayNameCaptionLabel.Text = "Tên hiển thị";
        // 
        // subtitleLabel
        // 
        subtitleLabel.AutoSize = true;
        subtitleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        subtitleLabel.ForeColor = Color.FromArgb(82, 138, 255);
        subtitleLabel.Location = new Point(38, 166);
        subtitleLabel.Name = "subtitleLabel";
        subtitleLabel.Size = new Size(176, 28);
        subtitleLabel.TabIndex = 4;
        subtitleLabel.Text = "Bắt đầu với NestG";
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Segoe UI Semibold", 28F, FontStyle.Bold);
        titleLabel.ForeColor = Color.FromArgb(239, 243, 248);
        titleLabel.Location = new Point(38, 104);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(318, 62);
        titleLabel.TabIndex = 3;
        titleLabel.Text = "Tạo tài khoản";
        // 
        // cardMetaLabel
        // 
        cardMetaLabel.AutoSize = true;
        cardMetaLabel.Font = new Font("Segoe UI", 8.75F);
        cardMetaLabel.ForeColor = Color.FromArgb(162, 174, 191);
        cardMetaLabel.Location = new Point(84, 58);
        cardMetaLabel.Name = "cardMetaLabel";
        cardMetaLabel.Size = new Size(153, 20);
        cardMetaLabel.TabIndex = 2;
        cardMetaLabel.Text = "Cổng tài khoản NestG";
        // 
        // cardAppNameLabel
        // 
        cardAppNameLabel.AutoSize = true;
        cardAppNameLabel.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
        cardAppNameLabel.ForeColor = Color.FromArgb(239, 243, 248);
        cardAppNameLabel.Location = new Point(84, 36);
        cardAppNameLabel.Name = "cardAppNameLabel";
        cardAppNameLabel.Size = new Size(157, 28);
        cardAppNameLabel.TabIndex = 1;
        cardAppNameLabel.Text = "NestG Launcher";
        // 
        // cardLogoPictureBox
        // 
        cardLogoPictureBox.Location = new Point(38, 34);
        cardLogoPictureBox.Name = "cardLogoPictureBox";
        cardLogoPictureBox.Size = new Size(34, 34);
        cardLogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        cardLogoPictureBox.TabIndex = 0;
        cardLogoPictureBox.TabStop = false;
        // 
        // RegisterForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(13, 18, 25);
        ClientSize = new Size(1264, 761);
        Controls.Add(rootLayout);
        MinimumSize = new Size(980, 720);
        Name = "RegisterForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "NestG Launcher";
        rootLayout.ResumeLayout(false);
        heroPanel.ResumeLayout(false);
        heroPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)heroLogoPictureBox).EndInit();
        cardPanel.ResumeLayout(false);
        cardPanel.PerformLayout();
        passwordFieldPanel.ResumeLayout(false);
        passwordFieldPanel.PerformLayout();
        emailFieldPanel.ResumeLayout(false);
        emailFieldPanel.PerformLayout();
        usernameFieldPanel.ResumeLayout(false);
        usernameFieldPanel.PerformLayout();
        displayNameFieldPanel.ResumeLayout(false);
        displayNameFieldPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)cardLogoPictureBox).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel rootLayout;
    private UI_Desktop.RoundedPanel heroPanel;
    private PictureBox heroLogoPictureBox;
    private Label heroAppNameLabel;
    private Label heroMetaLabel;
    private Label heroBadgeLabel;
    private Label heroTitleLabel;
    private Label heroDescriptionLabel;
    private Label heroBulletOneLabel;
    private Label heroBulletTwoLabel;
    private Label heroBulletThreeLabel;
    private UI_Desktop.RoundedPanel cardPanel;
    private PictureBox cardLogoPictureBox;
    private Label cardAppNameLabel;
    private Label cardMetaLabel;
    private Label titleLabel;
    private Label subtitleLabel;
    private Label displayNameCaptionLabel;
    private UI_Desktop.RoundedPanel displayNameFieldPanel;
    private TextBox displayNameTextBox;
    private Label usernameCaptionLabel;
    private UI_Desktop.RoundedPanel usernameFieldPanel;
    private TextBox usernameTextBox;
    private Label emailCaptionLabel;
    private UI_Desktop.RoundedPanel emailFieldPanel;
    private TextBox emailTextBox;
    private Label passwordCaptionLabel;
    private UI_Desktop.RoundedPanel passwordFieldPanel;
    private TextBox passwordTextBox;
    private Label passwordHintLabel;
    private UI_Desktop.GradientButton continueButton;
    private Label footerPromptLabel;
    private LinkLabel loginLinkLabel;
}
