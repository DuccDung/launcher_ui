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
        heroPanel = new UI_Desktop.RoundedPanel();
        heroLogoPictureBox = new PictureBox();
        heroAppNameLabel = new Label();
        heroMetaLabel = new Label();
        heroBadgeLabel = new Label();
        heroTitleLabel = new Label();
        heroDescriptionLabel = new Label();
        heroBulletOneLabel = new Label();
        heroBulletTwoLabel = new Label();
        heroBulletThreeLabel = new Label();
        cardPanel = new UI_Desktop.RoundedPanel();
        cardLogoPictureBox = new PictureBox();
        cardAppNameLabel = new Label();
        cardMetaLabel = new Label();
        titleLabel = new Label();
        subtitleLabel = new Label();
        displayNameCaptionLabel = new Label();
        displayNameFieldPanel = new UI_Desktop.RoundedPanel();
        displayNameTextBox = new TextBox();
        usernameCaptionLabel = new Label();
        usernameFieldPanel = new UI_Desktop.RoundedPanel();
        usernameTextBox = new TextBox();
        emailCaptionLabel = new Label();
        emailFieldPanel = new UI_Desktop.RoundedPanel();
        emailTextBox = new TextBox();
        passwordCaptionLabel = new Label();
        passwordFieldPanel = new UI_Desktop.RoundedPanel();
        passwordTextBox = new TextBox();
        passwordHintLabel = new Label();
        continueButton = new UI_Desktop.GradientButton();
        footerPromptLabel = new Label();
        loginLinkLabel = new LinkLabel();
        rootLayout.SuspendLayout();
        heroPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)heroLogoPictureBox).BeginInit();
        cardPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)cardLogoPictureBox).BeginInit();
        displayNameFieldPanel.SuspendLayout();
        usernameFieldPanel.SuspendLayout();
        emailFieldPanel.SuspendLayout();
        passwordFieldPanel.SuspendLayout();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.BackColor = AppTheme.WindowBackground;
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
        rootLayout.Size = new Size(1264, 801);
        rootLayout.TabIndex = 0;
        // 
        // heroPanel
        // 
        heroPanel.BackColor = Color.Transparent;
        heroPanel.BorderColor = Color.FromArgb(44, 56, 74);
        heroPanel.BorderThickness = 1;
        heroPanel.Controls.Add(heroBulletThreeLabel);
        heroPanel.Controls.Add(heroBulletTwoLabel);
        heroPanel.Controls.Add(heroBulletOneLabel);
        heroPanel.Controls.Add(heroDescriptionLabel);
        heroPanel.Controls.Add(heroTitleLabel);
        heroPanel.Controls.Add(heroBadgeLabel);
        heroPanel.Controls.Add(heroMetaLabel);
        heroPanel.Controls.Add(heroAppNameLabel);
        heroPanel.Controls.Add(heroLogoPictureBox);
        heroPanel.CornerRadius = 30;
        heroPanel.Dock = DockStyle.Fill;
        heroPanel.Location = new Point(24, 24);
        heroPanel.Margin = new Padding(0, 0, 18, 0);
        heroPanel.Name = "heroPanel";
        heroPanel.Size = new Size(507, 753);
        heroPanel.SurfaceColor = AppTheme.HeroSurface;
        heroPanel.TabIndex = 0;
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
        // heroAppNameLabel
        // 
        heroAppNameLabel.AutoSize = true;
        heroAppNameLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
        heroAppNameLabel.ForeColor = AppTheme.PrimaryText;
        heroAppNameLabel.Location = new Point(94, 36);
        heroAppNameLabel.Name = "heroAppNameLabel";
        heroAppNameLabel.Size = new Size(152, 30);
        heroAppNameLabel.TabIndex = 1;
        heroAppNameLabel.Text = "NestG Launcher";
        // 
        // heroMetaLabel
        // 
        heroMetaLabel.AutoSize = true;
        heroMetaLabel.Font = new Font("Segoe UI", 9.5F);
        heroMetaLabel.ForeColor = AppTheme.SecondaryText;
        heroMetaLabel.Location = new Point(94, 62);
        heroMetaLabel.Name = "heroMetaLabel";
        heroMetaLabel.Size = new Size(219, 21);
        heroMetaLabel.TabIndex = 2;
        heroMetaLabel.Text = "Desktop authentication workspace";
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
        heroBadgeLabel.Size = new Size(131, 36);
        heroBadgeLabel.TabIndex = 3;
        heroBadgeLabel.Text = "TẠO HỒ SƠ MỚI";
        // 
        // heroTitleLabel
        // 
        heroTitleLabel.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
        heroTitleLabel.ForeColor = AppTheme.PrimaryText;
        heroTitleLabel.Location = new Point(34, 172);
        heroTitleLabel.Name = "heroTitleLabel";
        heroTitleLabel.Size = new Size(390, 112);
        heroTitleLabel.TabIndex = 4;
        heroTitleLabel.Text = "Thiết lập tài khoản NestG chỉ trong vài bước rõ ràng.";
        // 
        // heroDescriptionLabel
        // 
        heroDescriptionLabel.Font = new Font("Segoe UI", 10.5F);
        heroDescriptionLabel.ForeColor = AppTheme.SecondaryText;
        heroDescriptionLabel.Location = new Point(34, 300);
        heroDescriptionLabel.Name = "heroDescriptionLabel";
        heroDescriptionLabel.Size = new Size(396, 74);
        heroDescriptionLabel.TabIndex = 5;
        heroDescriptionLabel.Text = "Form đăng ký được giữ tối giản để tập trung vào thông tin cốt lõi, đồng thời vẫn đủ hiện đại để dùng lâu dài trong launcher desktop.";
        // 
        // heroBulletOneLabel
        // 
        heroBulletOneLabel.Font = new Font("Segoe UI", 10.25F);
        heroBulletOneLabel.ForeColor = AppTheme.PrimaryText;
        heroBulletOneLabel.Location = new Point(34, 402);
        heroBulletOneLabel.Name = "heroBulletOneLabel";
        heroBulletOneLabel.Size = new Size(396, 48);
        heroBulletOneLabel.TabIndex = 6;
        heroBulletOneLabel.Text = "• Tách rõ tên hiển thị và username để thuận tiện đồng bộ hồ sơ về sau.";
        // 
        // heroBulletTwoLabel
        // 
        heroBulletTwoLabel.Font = new Font("Segoe UI", 10.25F);
        heroBulletTwoLabel.ForeColor = AppTheme.PrimaryText;
        heroBulletTwoLabel.Location = new Point(34, 462);
        heroBulletTwoLabel.Name = "heroBulletTwoLabel";
        heroBulletTwoLabel.Size = new Size(396, 48);
        heroBulletTwoLabel.TabIndex = 7;
        heroBulletTwoLabel.Text = "• Bố cục co giãn cơ bản giúp form vẫn dễ đọc ở kích thước cửa sổ nhỏ hơn.";
        // 
        // heroBulletThreeLabel
        // 
        heroBulletThreeLabel.Font = new Font("Segoe UI", 10.25F);
        heroBulletThreeLabel.ForeColor = AppTheme.PrimaryText;
        heroBulletThreeLabel.Location = new Point(34, 522);
        heroBulletThreeLabel.Name = "heroBulletThreeLabel";
        heroBulletThreeLabel.Size = new Size(396, 48);
        heroBulletThreeLabel.TabIndex = 8;
        heroBulletThreeLabel.Text = "• Sẵn sàng nối tiếp sang bước xác thực email hoặc API tạo tài khoản.";
        // 
        // cardPanel
        // 
        cardPanel.BackColor = Color.Transparent;
        cardPanel.BorderColor = Color.FromArgb(52, 64, 83);
        cardPanel.BorderThickness = 1;
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
        cardPanel.CornerRadius = 30;
        cardPanel.Dock = DockStyle.Fill;
        cardPanel.Location = new Point(549, 24);
        cardPanel.Margin = new Padding(0);
        cardPanel.Name = "cardPanel";
        cardPanel.Size = new Size(691, 753);
        cardPanel.SurfaceColor = AppTheme.CardSurface;
        cardPanel.TabIndex = 1;
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
        // cardAppNameLabel
        // 
        cardAppNameLabel.AutoSize = true;
        cardAppNameLabel.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
        cardAppNameLabel.ForeColor = AppTheme.PrimaryText;
        cardAppNameLabel.Location = new Point(84, 36);
        cardAppNameLabel.Name = "cardAppNameLabel";
        cardAppNameLabel.Size = new Size(136, 25);
        cardAppNameLabel.TabIndex = 1;
        cardAppNameLabel.Text = "NestG Launcher";
        // 
        // cardMetaLabel
        // 
        cardMetaLabel.AutoSize = true;
        cardMetaLabel.Font = new Font("Segoe UI", 8.75F);
        cardMetaLabel.ForeColor = AppTheme.SecondaryText;
        cardMetaLabel.Location = new Point(84, 58);
        cardMetaLabel.Name = "cardMetaLabel";
        cardMetaLabel.Size = new Size(138, 20);
        cardMetaLabel.TabIndex = 2;
        cardMetaLabel.Text = "Secure desktop access";
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Segoe UI Semibold", 28F, FontStyle.Bold);
        titleLabel.ForeColor = AppTheme.PrimaryText;
        titleLabel.Location = new Point(38, 104);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(275, 62);
        titleLabel.TabIndex = 3;
        titleLabel.Text = "Tạo tài khoản";
        // 
        // subtitleLabel
        // 
        subtitleLabel.AutoSize = true;
        subtitleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        subtitleLabel.ForeColor = AppTheme.Accent;
        subtitleLabel.Location = new Point(38, 166);
        subtitleLabel.Name = "subtitleLabel";
        subtitleLabel.Size = new Size(221, 28);
        subtitleLabel.TabIndex = 4;
        subtitleLabel.Text = "Tham gia cộng đồng NestG";
        // 
        // displayNameCaptionLabel
        // 
        displayNameCaptionLabel.AutoSize = true;
        displayNameCaptionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        displayNameCaptionLabel.ForeColor = AppTheme.SecondaryText;
        displayNameCaptionLabel.Location = new Point(38, 228);
        displayNameCaptionLabel.Name = "displayNameCaptionLabel";
        displayNameCaptionLabel.Size = new Size(106, 23);
        displayNameCaptionLabel.TabIndex = 5;
        displayNameCaptionLabel.Text = "Tên hiển thị";
        // 
        // displayNameFieldPanel
        // 
        displayNameFieldPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        displayNameFieldPanel.BackColor = Color.Transparent;
        displayNameFieldPanel.BorderColor = Color.FromArgb(53, 66, 85);
        displayNameFieldPanel.BorderThickness = 1;
        displayNameFieldPanel.Controls.Add(displayNameTextBox);
        displayNameFieldPanel.CornerRadius = 24;
        displayNameFieldPanel.Location = new Point(38, 261);
        displayNameFieldPanel.Name = "displayNameFieldPanel";
        displayNameFieldPanel.Padding = new Padding(18, 15, 18, 15);
        displayNameFieldPanel.Size = new Size(615, 54);
        displayNameFieldPanel.SurfaceColor = AppTheme.InputSurface;
        displayNameFieldPanel.TabIndex = 6;
        // 
        // displayNameTextBox
        // 
        displayNameTextBox.BackColor = AppTheme.InputSurface;
        displayNameTextBox.BorderStyle = BorderStyle.None;
        displayNameTextBox.Dock = DockStyle.Fill;
        displayNameTextBox.Font = new Font("Segoe UI", 11F);
        displayNameTextBox.ForeColor = AppTheme.PrimaryText;
        displayNameTextBox.Location = new Point(18, 15);
        displayNameTextBox.Name = "displayNameTextBox";
        displayNameTextBox.PlaceholderText = "Ví dụ: Nguyễn Văn A";
        displayNameTextBox.Size = new Size(579, 25);
        displayNameTextBox.TabIndex = 0;
        // 
        // usernameCaptionLabel
        // 
        usernameCaptionLabel.AutoSize = true;
        usernameCaptionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        usernameCaptionLabel.ForeColor = AppTheme.SecondaryText;
        usernameCaptionLabel.Location = new Point(38, 343);
        usernameCaptionLabel.Name = "usernameCaptionLabel";
        usernameCaptionLabel.Size = new Size(185, 23);
        usernameCaptionLabel.TabIndex = 7;
        usernameCaptionLabel.Text = "Tên tài khoản (username)";
        // 
        // usernameFieldPanel
        // 
        usernameFieldPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        usernameFieldPanel.BackColor = Color.Transparent;
        usernameFieldPanel.BorderColor = Color.FromArgb(53, 66, 85);
        usernameFieldPanel.BorderThickness = 1;
        usernameFieldPanel.Controls.Add(usernameTextBox);
        usernameFieldPanel.CornerRadius = 24;
        usernameFieldPanel.Location = new Point(38, 376);
        usernameFieldPanel.Name = "usernameFieldPanel";
        usernameFieldPanel.Padding = new Padding(18, 15, 18, 15);
        usernameFieldPanel.Size = new Size(615, 54);
        usernameFieldPanel.SurfaceColor = AppTheme.InputSurface;
        usernameFieldPanel.TabIndex = 8;
        // 
        // usernameTextBox
        // 
        usernameTextBox.BackColor = AppTheme.InputSurface;
        usernameTextBox.BorderStyle = BorderStyle.None;
        usernameTextBox.Dock = DockStyle.Fill;
        usernameTextBox.Font = new Font("Segoe UI", 11F);
        usernameTextBox.ForeColor = AppTheme.PrimaryText;
        usernameTextBox.Location = new Point(18, 15);
        usernameTextBox.Name = "usernameTextBox";
        usernameTextBox.PlaceholderText = "Ví dụ: nestg.user";
        usernameTextBox.Size = new Size(579, 25);
        usernameTextBox.TabIndex = 0;
        // 
        // emailCaptionLabel
        // 
        emailCaptionLabel.AutoSize = true;
        emailCaptionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        emailCaptionLabel.ForeColor = AppTheme.SecondaryText;
        emailCaptionLabel.Location = new Point(38, 458);
        emailCaptionLabel.Name = "emailCaptionLabel";
        emailCaptionLabel.Size = new Size(109, 23);
        emailCaptionLabel.TabIndex = 9;
        emailCaptionLabel.Text = "Địa chỉ email";
        // 
        // emailFieldPanel
        // 
        emailFieldPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        emailFieldPanel.BackColor = Color.Transparent;
        emailFieldPanel.BorderColor = Color.FromArgb(53, 66, 85);
        emailFieldPanel.BorderThickness = 1;
        emailFieldPanel.Controls.Add(emailTextBox);
        emailFieldPanel.CornerRadius = 24;
        emailFieldPanel.Location = new Point(38, 491);
        emailFieldPanel.Name = "emailFieldPanel";
        emailFieldPanel.Padding = new Padding(18, 15, 18, 15);
        emailFieldPanel.Size = new Size(615, 54);
        emailFieldPanel.SurfaceColor = AppTheme.InputSurface;
        emailFieldPanel.TabIndex = 10;
        // 
        // emailTextBox
        // 
        emailTextBox.BackColor = AppTheme.InputSurface;
        emailTextBox.BorderStyle = BorderStyle.None;
        emailTextBox.Dock = DockStyle.Fill;
        emailTextBox.Font = new Font("Segoe UI", 11F);
        emailTextBox.ForeColor = AppTheme.PrimaryText;
        emailTextBox.Location = new Point(18, 15);
        emailTextBox.Name = "emailTextBox";
        emailTextBox.PlaceholderText = "example@gmail.com";
        emailTextBox.Size = new Size(579, 25);
        emailTextBox.TabIndex = 0;
        // 
        // passwordCaptionLabel
        // 
        passwordCaptionLabel.AutoSize = true;
        passwordCaptionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        passwordCaptionLabel.ForeColor = AppTheme.SecondaryText;
        passwordCaptionLabel.Location = new Point(38, 573);
        passwordCaptionLabel.Name = "passwordCaptionLabel";
        passwordCaptionLabel.Size = new Size(79, 23);
        passwordCaptionLabel.TabIndex = 11;
        passwordCaptionLabel.Text = "Mật khẩu";
        // 
        // passwordFieldPanel
        // 
        passwordFieldPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        passwordFieldPanel.BackColor = Color.Transparent;
        passwordFieldPanel.BorderColor = Color.FromArgb(53, 66, 85);
        passwordFieldPanel.BorderThickness = 1;
        passwordFieldPanel.Controls.Add(passwordTextBox);
        passwordFieldPanel.CornerRadius = 24;
        passwordFieldPanel.Location = new Point(38, 606);
        passwordFieldPanel.Name = "passwordFieldPanel";
        passwordFieldPanel.Padding = new Padding(18, 15, 18, 15);
        passwordFieldPanel.Size = new Size(615, 54);
        passwordFieldPanel.SurfaceColor = AppTheme.InputSurface;
        passwordFieldPanel.TabIndex = 12;
        // 
        // passwordTextBox
        // 
        passwordTextBox.BackColor = AppTheme.InputSurface;
        passwordTextBox.BorderStyle = BorderStyle.None;
        passwordTextBox.Dock = DockStyle.Fill;
        passwordTextBox.Font = new Font("Segoe UI", 11F);
        passwordTextBox.ForeColor = AppTheme.PrimaryText;
        passwordTextBox.Location = new Point(18, 15);
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.PlaceholderText = "Tối thiểu 6 ký tự";
        passwordTextBox.Size = new Size(579, 25);
        passwordTextBox.TabIndex = 0;
        passwordTextBox.UseSystemPasswordChar = true;
        // 
        // passwordHintLabel
        // 
        passwordHintLabel.AutoSize = true;
        passwordHintLabel.Font = new Font("Segoe UI", 9.25F);
        passwordHintLabel.ForeColor = AppTheme.MutedText;
        passwordHintLabel.Location = new Point(38, 668);
        passwordHintLabel.MaximumSize = new Size(520, 0);
        passwordHintLabel.Name = "passwordHintLabel";
        passwordHintLabel.Size = new Size(450, 21);
        passwordHintLabel.TabIndex = 13;
        passwordHintLabel.Text = "Mật khẩu nên có ít nhất 6 ký tự để đủ điều kiện cho bước xác thực tiếp theo.";
        // 
        // continueButton
        // 
        continueButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        continueButton.CornerRadius = 26;
        continueButton.EndColor = Color.FromArgb(50, 103, 242);
        continueButton.FlatAppearance.BorderSize = 0;
        continueButton.FlatStyle = FlatStyle.Flat;
        continueButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        continueButton.ForeColor = Color.White;
        continueButton.Location = new Point(38, 717);
        continueButton.Name = "continueButton";
        continueButton.Size = new Size(615, 56);
        continueButton.StartColor = Color.FromArgb(86, 140, 255);
        continueButton.TabIndex = 14;
        continueButton.Text = "Tiếp theo";
        continueButton.UseVisualStyleBackColor = true;
        continueButton.Click += continueButton_Click;
        // 
        // footerPromptLabel
        // 
        footerPromptLabel.Anchor = AnchorStyles.Bottom;
        footerPromptLabel.AutoSize = true;
        footerPromptLabel.Font = new Font("Segoe UI", 10F);
        footerPromptLabel.ForeColor = AppTheme.MutedText;
        footerPromptLabel.Location = new Point(192, 706);
        footerPromptLabel.Name = "footerPromptLabel";
        footerPromptLabel.Size = new Size(113, 23);
        footerPromptLabel.TabIndex = 15;
        footerPromptLabel.Text = "Đã có tài khoản?";
        // 
        // loginLinkLabel
        // 
        loginLinkLabel.ActiveLinkColor = Color.FromArgb(192, 216, 255);
        loginLinkLabel.Anchor = AnchorStyles.Bottom;
        loginLinkLabel.AutoSize = true;
        loginLinkLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        loginLinkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
        loginLinkLabel.LinkColor = Color.FromArgb(220, 232, 255);
        loginLinkLabel.Location = new Point(309, 706);
        loginLinkLabel.Name = "loginLinkLabel";
        loginLinkLabel.Size = new Size(169, 23);
        loginLinkLabel.TabIndex = 16;
        loginLinkLabel.TabStop = true;
        loginLinkLabel.Text = "Quay lại đăng nhập";
        loginLinkLabel.VisitedLinkColor = Color.FromArgb(220, 232, 255);
        loginLinkLabel.LinkClicked += loginLinkLabel_LinkClicked;
        // 
        // RegisterForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = AppTheme.WindowBackground;
        ClientSize = new Size(1264, 801);
        Controls.Add(rootLayout);
        MinimumSize = new Size(980, 760);
        Name = "RegisterForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "NestG Launcher";
        rootLayout.ResumeLayout(false);
        heroPanel.ResumeLayout(false);
        heroPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)heroLogoPictureBox).EndInit();
        cardPanel.ResumeLayout(false);
        cardPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)cardLogoPictureBox).EndInit();
        displayNameFieldPanel.ResumeLayout(false);
        displayNameFieldPanel.PerformLayout();
        usernameFieldPanel.ResumeLayout(false);
        usernameFieldPanel.PerformLayout();
        emailFieldPanel.ResumeLayout(false);
        emailFieldPanel.PerformLayout();
        passwordFieldPanel.ResumeLayout(false);
        passwordFieldPanel.PerformLayout();
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
