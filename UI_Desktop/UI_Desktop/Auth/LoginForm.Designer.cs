using UI_Desktop;

namespace UI_Desktop.Auth;

partial class LoginForm
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
        heroContentLayout = new TableLayoutPanel();
        heroHeaderLayout = new TableLayoutPanel();
        heroBrandTextPanel = new Panel();
        heroMetaLabel = new Label();
        heroAppNameLabel = new Label();
        heroLogoPictureBox = new PictureBox();
        heroBadgeLabel = new Label();
        heroTitleLabel = new Label();
        heroDescriptionLabel = new Label();
        heroBulletOneLabel = new Label();
        heroBulletTwoLabel = new Label();
        heroBulletThreeLabel = new Label();
        cardPanel = new RoundedPanel();
        cardContentLayout = new TableLayoutPanel();
        cardHeaderLayout = new TableLayoutPanel();
        cardBrandTextPanel = new Panel();
        cardMetaLabel = new Label();
        cardAppNameLabel = new Label();
        cardLogoPictureBox = new PictureBox();
        titleLabel = new Label();
        subtitleLabel = new Label();
        emailCaptionLabel = new Label();
        emailFieldPanel = new RoundedPanel();
        emailTextBox = new TextBox();
        passwordCaptionLabel = new Label();
        passwordFieldPanel = new RoundedPanel();
        passwordTextBox = new TextBox();
        optionsLayout = new TableLayoutPanel();
        rememberMeCheckBox = new CheckBox();
        forgotPasswordLink = new LinkLabel();
        loginButton = new GradientButton();
        footerFlowPanel = new FlowLayoutPanel();
        footerPromptLabel = new Label();
        registerLinkLabel = new LinkLabel();
        rootLayout.SuspendLayout();
        heroPanel.SuspendLayout();
        heroContentLayout.SuspendLayout();
        heroHeaderLayout.SuspendLayout();
        heroBrandTextPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)heroLogoPictureBox).BeginInit();
        cardPanel.SuspendLayout();
        cardContentLayout.SuspendLayout();
        cardHeaderLayout.SuspendLayout();
        cardBrandTextPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)cardLogoPictureBox).BeginInit();
        emailFieldPanel.SuspendLayout();
        passwordFieldPanel.SuspendLayout();
        optionsLayout.SuspendLayout();
        footerFlowPanel.SuspendLayout();
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
        rootLayout.Margin = new Padding(0);
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
        heroPanel.Controls.Add(heroContentLayout);
        heroPanel.Dock = DockStyle.Fill;
        heroPanel.Location = new Point(24, 24);
        heroPanel.Margin = new Padding(0, 0, 18, 0);
        heroPanel.Name = "heroPanel";
        heroPanel.Padding = new Padding(34);
        heroPanel.Size = new Size(504, 713);
        heroPanel.TabIndex = 0;
        // 
        // heroContentLayout
        // 
        heroContentLayout.BackColor = Color.Transparent;
        heroContentLayout.ColumnCount = 1;
        heroContentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        heroContentLayout.Controls.Add(heroHeaderLayout, 0, 0);
        heroContentLayout.Controls.Add(heroBadgeLabel, 0, 1);
        heroContentLayout.Controls.Add(heroTitleLabel, 0, 2);
        heroContentLayout.Controls.Add(heroDescriptionLabel, 0, 3);
        heroContentLayout.Controls.Add(heroBulletOneLabel, 0, 4);
        heroContentLayout.Controls.Add(heroBulletTwoLabel, 0, 5);
        heroContentLayout.Controls.Add(heroBulletThreeLabel, 0, 6);
        heroContentLayout.Dock = DockStyle.Fill;
        heroContentLayout.Location = new Point(34, 34);
        heroContentLayout.Margin = new Padding(0);
        heroContentLayout.Name = "heroContentLayout";
        heroContentLayout.RowCount = 8;
        heroContentLayout.RowStyles.Add(new RowStyle());
        heroContentLayout.RowStyles.Add(new RowStyle());
        heroContentLayout.RowStyles.Add(new RowStyle());
        heroContentLayout.RowStyles.Add(new RowStyle());
        heroContentLayout.RowStyles.Add(new RowStyle());
        heroContentLayout.RowStyles.Add(new RowStyle());
        heroContentLayout.RowStyles.Add(new RowStyle());
        heroContentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        heroContentLayout.Size = new Size(436, 645);
        heroContentLayout.TabIndex = 0;
        // 
        // heroHeaderLayout
        // 
        heroHeaderLayout.AutoSize = true;
        heroHeaderLayout.ColumnCount = 2;
        heroHeaderLayout.ColumnStyles.Add(new ColumnStyle());
        heroHeaderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        heroHeaderLayout.Controls.Add(heroBrandTextPanel, 1, 0);
        heroHeaderLayout.Controls.Add(heroLogoPictureBox, 0, 0);
        heroHeaderLayout.Dock = DockStyle.Top;
        heroHeaderLayout.Location = new Point(0, 0);
        heroHeaderLayout.Margin = new Padding(0);
        heroHeaderLayout.Name = "heroHeaderLayout";
        heroHeaderLayout.RowCount = 1;
        heroHeaderLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        heroHeaderLayout.Size = new Size(436, 51);
        heroHeaderLayout.TabIndex = 0;
        // 
        // heroBrandTextPanel
        // 
        heroBrandTextPanel.AutoSize = true;
        heroBrandTextPanel.BackColor = Color.Transparent;
        heroBrandTextPanel.Controls.Add(heroMetaLabel);
        heroBrandTextPanel.Controls.Add(heroAppNameLabel);
        heroBrandTextPanel.Dock = DockStyle.Fill;
        heroBrandTextPanel.Location = new Point(60, 0);
        heroBrandTextPanel.Margin = new Padding(0);
        heroBrandTextPanel.Name = "heroBrandTextPanel";
        heroBrandTextPanel.Size = new Size(376, 51);
        heroBrandTextPanel.TabIndex = 1;
        // 
        // heroMetaLabel
        // 
        heroMetaLabel.AutoSize = true;
        heroMetaLabel.Dock = DockStyle.Top;
        heroMetaLabel.Font = new Font("Segoe UI", 9.5F);
        heroMetaLabel.ForeColor = Color.FromArgb(162, 174, 191);
        heroMetaLabel.Location = new Point(0, 30);
        heroMetaLabel.Margin = new Padding(0);
        heroMetaLabel.Name = "heroMetaLabel";
        heroMetaLabel.Size = new Size(248, 21);
        heroMetaLabel.TabIndex = 1;
        heroMetaLabel.Text = "Desktop authentication workspace";
        // 
        // heroAppNameLabel
        // 
        heroAppNameLabel.AutoSize = true;
        heroAppNameLabel.Dock = DockStyle.Top;
        heroAppNameLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
        heroAppNameLabel.ForeColor = Color.FromArgb(239, 243, 248);
        heroAppNameLabel.Location = new Point(0, 0);
        heroAppNameLabel.Margin = new Padding(0);
        heroAppNameLabel.Name = "heroAppNameLabel";
        heroAppNameLabel.Size = new Size(171, 30);
        heroAppNameLabel.TabIndex = 0;
        heroAppNameLabel.Text = "NestG Launcher";
        // 
        // heroLogoPictureBox
        // 
        heroLogoPictureBox.Location = new Point(0, 0);
        heroLogoPictureBox.Margin = new Padding(0, 0, 14, 0);
        heroLogoPictureBox.Name = "heroLogoPictureBox";
        heroLogoPictureBox.Size = new Size(46, 46);
        heroLogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        heroLogoPictureBox.TabIndex = 0;
        heroLogoPictureBox.TabStop = false;
        // 
        // heroBadgeLabel
        // 
        heroBadgeLabel.AutoSize = true;
        heroBadgeLabel.BackColor = Color.FromArgb(30, 56, 101);
        heroBadgeLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        heroBadgeLabel.ForeColor = Color.FromArgb(185, 213, 255);
        heroBadgeLabel.Location = new Point(0, 81);
        heroBadgeLabel.Margin = new Padding(0, 30, 0, 0);
        heroBadgeLabel.Name = "heroBadgeLabel";
        heroBadgeLabel.Padding = new Padding(14, 8, 14, 8);
        heroBadgeLabel.Size = new Size(196, 36);
        heroBadgeLabel.TabIndex = 1;
        heroBadgeLabel.Text = "ĐĂNG NHẬP AN TOÀN";
        // 
        // heroTitleLabel
        // 
        heroTitleLabel.AutoSize = true;
        heroTitleLabel.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
        heroTitleLabel.ForeColor = Color.FromArgb(239, 243, 248);
        heroTitleLabel.Location = new Point(0, 135);
        heroTitleLabel.Margin = new Padding(0, 18, 0, 0);
        heroTitleLabel.MaximumSize = new Size(390, 0);
        heroTitleLabel.Name = "heroTitleLabel";
        heroTitleLabel.Size = new Size(368, 216);
        heroTitleLabel.TabIndex = 2;
        heroTitleLabel.Text = "Một điểm truy cập gọn gàng cho tài khoản NestG của bạn.";
        // 
        // heroDescriptionLabel
        // 
        heroDescriptionLabel.AutoSize = true;
        heroDescriptionLabel.Font = new Font("Segoe UI", 10.5F);
        heroDescriptionLabel.ForeColor = Color.FromArgb(162, 174, 191);
        heroDescriptionLabel.Location = new Point(0, 367);
        heroDescriptionLabel.Margin = new Padding(0, 16, 0, 0);
        heroDescriptionLabel.MaximumSize = new Size(398, 0);
        heroDescriptionLabel.Name = "heroDescriptionLabel";
        heroDescriptionLabel.Size = new Size(378, 75);
        heroDescriptionLabel.TabIndex = 3;
        heroDescriptionLabel.Text = "Thiết kế mới tập trung vào độ rõ ràng, tốc độ thao tác và cảm giác desktop chuyên nghiệp hơn khi đăng nhập hằng ngày.";
        // 
        // heroBulletOneLabel
        // 
        heroBulletOneLabel.AutoSize = true;
        heroBulletOneLabel.Font = new Font("Segoe UI", 10.25F);
        heroBulletOneLabel.ForeColor = Color.FromArgb(239, 243, 248);
        heroBulletOneLabel.Location = new Point(0, 470);
        heroBulletOneLabel.Margin = new Padding(0, 28, 0, 0);
        heroBulletOneLabel.MaximumSize = new Size(400, 0);
        heroBulletOneLabel.Name = "heroBulletOneLabel";
        heroBulletOneLabel.Size = new Size(361, 50);
        heroBulletOneLabel.TabIndex = 4;
        heroBulletOneLabel.Text = "• Theo dõi đơn mua, trạng thái kích hoạt và thông tin thiết bị trong cùng một luồng.";
        // 
        // heroBulletTwoLabel
        // 
        heroBulletTwoLabel.AutoSize = true;
        heroBulletTwoLabel.Font = new Font("Segoe UI", 10.25F);
        heroBulletTwoLabel.ForeColor = Color.FromArgb(239, 243, 248);
        heroBulletTwoLabel.Location = new Point(0, 536);
        heroBulletTwoLabel.Margin = new Padding(0, 16, 0, 0);
        heroBulletTwoLabel.MaximumSize = new Size(400, 0);
        heroBulletTwoLabel.Name = "heroBulletTwoLabel";
        heroBulletTwoLabel.Size = new Size(383, 50);
        heroBulletTwoLabel.TabIndex = 5;
        heroBulletTwoLabel.Text = "• Lưu phiên làm việc gọn gàng để người dùng quay lại nhanh hơn trên desktop.";
        // 
        // heroBulletThreeLabel
        // 
        heroBulletThreeLabel.AutoSize = true;
        heroBulletThreeLabel.Font = new Font("Segoe UI", 10.25F);
        heroBulletThreeLabel.ForeColor = Color.FromArgb(239, 243, 248);
        heroBulletThreeLabel.Location = new Point(0, 602);
        heroBulletThreeLabel.Margin = new Padding(0, 16, 0, 0);
        heroBulletThreeLabel.MaximumSize = new Size(400, 0);
        heroBulletThreeLabel.Name = "heroBulletThreeLabel";
        heroBulletThreeLabel.Size = new Size(370, 50);
        heroBulletThreeLabel.TabIndex = 6;
        heroBulletThreeLabel.Text = "• Khôi phục mật khẩu hoặc điều hướng sang đăng ký mà không đổi cửa sổ ứng dụng.";
        // 
        // cardPanel
        // 
        cardPanel.BackColor = Color.Transparent;
        cardPanel.Controls.Add(cardContentLayout);
        cardPanel.Dock = DockStyle.Fill;
        cardPanel.Location = new Point(546, 24);
        cardPanel.Margin = new Padding(0);
        cardPanel.Name = "cardPanel";
        cardPanel.Padding = new Padding(38, 34, 38, 34);
        cardPanel.Size = new Size(694, 713);
        cardPanel.TabIndex = 1;
        // 
        // cardContentLayout
        // 
        cardContentLayout.AutoScroll = true;
        cardContentLayout.BackColor = Color.Transparent;
        cardContentLayout.ColumnCount = 1;
        cardContentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        cardContentLayout.Controls.Add(cardHeaderLayout, 0, 0);
        cardContentLayout.Controls.Add(titleLabel, 0, 1);
        cardContentLayout.Controls.Add(subtitleLabel, 0, 2);
        cardContentLayout.Controls.Add(emailCaptionLabel, 0, 3);
        cardContentLayout.Controls.Add(emailFieldPanel, 0, 4);
        cardContentLayout.Controls.Add(passwordCaptionLabel, 0, 5);
        cardContentLayout.Controls.Add(passwordFieldPanel, 0, 6);
        cardContentLayout.Controls.Add(optionsLayout, 0, 7);
        cardContentLayout.Controls.Add(loginButton, 0, 8);
        cardContentLayout.Controls.Add(footerFlowPanel, 0, 9);
        cardContentLayout.Dock = DockStyle.Fill;
        cardContentLayout.Location = new Point(38, 34);
        cardContentLayout.Margin = new Padding(0);
        cardContentLayout.Name = "cardContentLayout";
        cardContentLayout.RowCount = 11;
        cardContentLayout.RowStyles.Add(new RowStyle());
        cardContentLayout.RowStyles.Add(new RowStyle());
        cardContentLayout.RowStyles.Add(new RowStyle());
        cardContentLayout.RowStyles.Add(new RowStyle());
        cardContentLayout.RowStyles.Add(new RowStyle());
        cardContentLayout.RowStyles.Add(new RowStyle());
        cardContentLayout.RowStyles.Add(new RowStyle());
        cardContentLayout.RowStyles.Add(new RowStyle());
        cardContentLayout.RowStyles.Add(new RowStyle());
        cardContentLayout.RowStyles.Add(new RowStyle());
        cardContentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        cardContentLayout.Size = new Size(618, 645);
        cardContentLayout.TabIndex = 0;
        // 
        // cardHeaderLayout
        // 
        cardHeaderLayout.AutoSize = true;
        cardHeaderLayout.ColumnCount = 2;
        cardHeaderLayout.ColumnStyles.Add(new ColumnStyle());
        cardHeaderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        cardHeaderLayout.Controls.Add(cardBrandTextPanel, 1, 0);
        cardHeaderLayout.Controls.Add(cardLogoPictureBox, 0, 0);
        cardHeaderLayout.Dock = DockStyle.Top;
        cardHeaderLayout.Location = new Point(0, 0);
        cardHeaderLayout.Margin = new Padding(0);
        cardHeaderLayout.Name = "cardHeaderLayout";
        cardHeaderLayout.RowCount = 1;
        cardHeaderLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        cardHeaderLayout.Size = new Size(618, 48);
        cardHeaderLayout.TabIndex = 0;
        // 
        // cardBrandTextPanel
        // 
        cardBrandTextPanel.AutoSize = true;
        cardBrandTextPanel.BackColor = Color.Transparent;
        cardBrandTextPanel.Controls.Add(cardMetaLabel);
        cardBrandTextPanel.Controls.Add(cardAppNameLabel);
        cardBrandTextPanel.Dock = DockStyle.Fill;
        cardBrandTextPanel.Location = new Point(46, 0);
        cardBrandTextPanel.Margin = new Padding(0);
        cardBrandTextPanel.Name = "cardBrandTextPanel";
        cardBrandTextPanel.Size = new Size(572, 48);
        cardBrandTextPanel.TabIndex = 1;
        // 
        // cardMetaLabel
        // 
        cardMetaLabel.AutoSize = true;
        cardMetaLabel.Dock = DockStyle.Top;
        cardMetaLabel.Font = new Font("Segoe UI", 8.75F);
        cardMetaLabel.ForeColor = Color.FromArgb(162, 174, 191);
        cardMetaLabel.Location = new Point(0, 28);
        cardMetaLabel.Margin = new Padding(0);
        cardMetaLabel.Name = "cardMetaLabel";
        cardMetaLabel.Size = new Size(156, 20);
        cardMetaLabel.TabIndex = 1;
        cardMetaLabel.Text = "Secure desktop access";
        // 
        // cardAppNameLabel
        // 
        cardAppNameLabel.AutoSize = true;
        cardAppNameLabel.Dock = DockStyle.Top;
        cardAppNameLabel.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
        cardAppNameLabel.ForeColor = Color.FromArgb(239, 243, 248);
        cardAppNameLabel.Location = new Point(0, 0);
        cardAppNameLabel.Margin = new Padding(0);
        cardAppNameLabel.Name = "cardAppNameLabel";
        cardAppNameLabel.Size = new Size(157, 28);
        cardAppNameLabel.TabIndex = 0;
        cardAppNameLabel.Text = "NestG Launcher";
        // 
        // cardLogoPictureBox
        // 
        cardLogoPictureBox.Location = new Point(0, 0);
        cardLogoPictureBox.Margin = new Padding(0, 0, 12, 0);
        cardLogoPictureBox.Name = "cardLogoPictureBox";
        cardLogoPictureBox.Size = new Size(34, 34);
        cardLogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        cardLogoPictureBox.TabIndex = 0;
        cardLogoPictureBox.TabStop = false;
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Segoe UI Semibold", 28F, FontStyle.Bold);
        titleLabel.ForeColor = Color.FromArgb(239, 243, 248);
        titleLabel.Location = new Point(0, 74);
        titleLabel.Margin = new Padding(0, 26, 0, 0);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(261, 62);
        titleLabel.TabIndex = 1;
        titleLabel.Text = "Đăng nhập";
        // 
        // subtitleLabel
        // 
        subtitleLabel.AutoSize = true;
        subtitleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        subtitleLabel.ForeColor = Color.FromArgb(82, 138, 255);
        subtitleLabel.Location = new Point(0, 140);
        subtitleLabel.Margin = new Padding(0, 4, 0, 0);
        subtitleLabel.Name = "subtitleLabel";
        subtitleLabel.Size = new Size(234, 28);
        subtitleLabel.TabIndex = 2;
        subtitleLabel.Text = "Chào mừng bạn quay lại";
        // 
        // emailCaptionLabel
        // 
        emailCaptionLabel.AutoSize = true;
        emailCaptionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        emailCaptionLabel.ForeColor = Color.FromArgb(162, 174, 191);
        emailCaptionLabel.Location = new Point(0, 202);
        emailCaptionLabel.Margin = new Padding(0, 34, 0, 10);
        emailCaptionLabel.Name = "emailCaptionLabel";
        emailCaptionLabel.Size = new Size(108, 23);
        emailCaptionLabel.TabIndex = 3;
        emailCaptionLabel.Text = "Địa chỉ email";
        // 
        // emailFieldPanel
        // 
        emailFieldPanel.BackColor = Color.Transparent;
        emailFieldPanel.Controls.Add(emailTextBox);
        emailFieldPanel.Dock = DockStyle.Top;
        emailFieldPanel.Location = new Point(0, 235);
        emailFieldPanel.Margin = new Padding(0);
        emailFieldPanel.Name = "emailFieldPanel";
        emailFieldPanel.Padding = new Padding(18, 15, 18, 15);
        emailFieldPanel.Size = new Size(618, 54);
        emailFieldPanel.TabIndex = 4;
        // 
        // emailTextBox
        // 
        emailTextBox.BackColor = Color.FromArgb(31, 40, 53);
        emailTextBox.BorderStyle = BorderStyle.None;
        emailTextBox.Dock = DockStyle.Fill;
        emailTextBox.Font = new Font("Segoe UI", 11F);
        emailTextBox.ForeColor = Color.FromArgb(239, 243, 248);
        emailTextBox.Location = new Point(18, 15);
        emailTextBox.Margin = new Padding(0);
        emailTextBox.Name = "emailTextBox";
        emailTextBox.PlaceholderText = "example@gmail.com";
        emailTextBox.Size = new Size(582, 25);
        emailTextBox.TabIndex = 0;
        // 
        // passwordCaptionLabel
        // 
        passwordCaptionLabel.AutoSize = true;
        passwordCaptionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        passwordCaptionLabel.ForeColor = Color.FromArgb(162, 174, 191);
        passwordCaptionLabel.Location = new Point(0, 317);
        passwordCaptionLabel.Margin = new Padding(0, 28, 0, 10);
        passwordCaptionLabel.Name = "passwordCaptionLabel";
        passwordCaptionLabel.Size = new Size(84, 23);
        passwordCaptionLabel.TabIndex = 5;
        passwordCaptionLabel.Text = "Mật khẩu";
        // 
        // passwordFieldPanel
        // 
        passwordFieldPanel.BackColor = Color.Transparent;
        passwordFieldPanel.Controls.Add(passwordTextBox);
        passwordFieldPanel.Dock = DockStyle.Top;
        passwordFieldPanel.Location = new Point(0, 350);
        passwordFieldPanel.Margin = new Padding(0);
        passwordFieldPanel.Name = "passwordFieldPanel";
        passwordFieldPanel.Padding = new Padding(18, 15, 18, 15);
        passwordFieldPanel.Size = new Size(618, 54);
        passwordFieldPanel.TabIndex = 6;
        // 
        // passwordTextBox
        // 
        passwordTextBox.BackColor = Color.FromArgb(31, 40, 53);
        passwordTextBox.BorderStyle = BorderStyle.None;
        passwordTextBox.Dock = DockStyle.Fill;
        passwordTextBox.Font = new Font("Segoe UI", 11F);
        passwordTextBox.ForeColor = Color.FromArgb(239, 243, 248);
        passwordTextBox.Location = new Point(18, 15);
        passwordTextBox.Margin = new Padding(0);
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.PlaceholderText = "Nhập mật khẩu của bạn";
        passwordTextBox.Size = new Size(582, 25);
        passwordTextBox.TabIndex = 0;
        passwordTextBox.UseSystemPasswordChar = true;
        // 
        // optionsLayout
        // 
        optionsLayout.ColumnCount = 2;
        optionsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        optionsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        optionsLayout.Controls.Add(rememberMeCheckBox, 0, 0);
        optionsLayout.Controls.Add(forgotPasswordLink, 1, 0);
        optionsLayout.Dock = DockStyle.Top;
        optionsLayout.Location = new Point(0, 424);
        optionsLayout.Margin = new Padding(0, 20, 0, 0);
        optionsLayout.Name = "optionsLayout";
        optionsLayout.RowCount = 1;
        optionsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        optionsLayout.Size = new Size(618, 28);
        optionsLayout.TabIndex = 7;
        // 
        // rememberMeCheckBox
        // 
        rememberMeCheckBox.AutoSize = true;
        rememberMeCheckBox.Cursor = Cursors.Hand;
        rememberMeCheckBox.FlatStyle = FlatStyle.Flat;
        rememberMeCheckBox.Font = new Font("Segoe UI", 10F);
        rememberMeCheckBox.ForeColor = Color.FromArgb(239, 243, 248);
        rememberMeCheckBox.Location = new Point(0, 0);
        rememberMeCheckBox.Margin = new Padding(0);
        rememberMeCheckBox.Name = "rememberMeCheckBox";
        rememberMeCheckBox.Size = new Size(89, 27);
        rememberMeCheckBox.TabIndex = 0;
        rememberMeCheckBox.Text = "Ghi nhớ";
        rememberMeCheckBox.UseVisualStyleBackColor = true;
        // 
        // forgotPasswordLink
        // 
        forgotPasswordLink.ActiveLinkColor = Color.FromArgb(192, 216, 255);
        forgotPasswordLink.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        forgotPasswordLink.AutoSize = true;
        forgotPasswordLink.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        forgotPasswordLink.LinkBehavior = LinkBehavior.HoverUnderline;
        forgotPasswordLink.LinkColor = Color.FromArgb(220, 232, 255);
        forgotPasswordLink.Location = new Point(480, 0);
        forgotPasswordLink.Margin = new Padding(0);
        forgotPasswordLink.Name = "forgotPasswordLink";
        forgotPasswordLink.Size = new Size(138, 23);
        forgotPasswordLink.TabIndex = 1;
        forgotPasswordLink.TabStop = true;
        forgotPasswordLink.Text = "Quên mật khẩu?";
        forgotPasswordLink.VisitedLinkColor = Color.FromArgb(220, 232, 255);
        forgotPasswordLink.LinkClicked += forgotPasswordLink_LinkClicked;
        // 
        // loginButton
        // 
        loginButton.Dock = DockStyle.Top;
        loginButton.FlatAppearance.BorderSize = 0;
        loginButton.FlatStyle = FlatStyle.Flat;
        loginButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        loginButton.ForeColor = Color.White;
        loginButton.Location = new Point(0, 480);
        loginButton.Margin = new Padding(0, 28, 0, 0);
        loginButton.MinimumSize = new Size(0, 56);
        loginButton.Name = "loginButton";
        loginButton.Size = new Size(618, 56);
        loginButton.TabIndex = 8;
        loginButton.Text = "Đăng nhập";
        loginButton.UseVisualStyleBackColor = true;
        loginButton.Click += loginButton_Click;
        // 
        // footerFlowPanel
        // 
        footerFlowPanel.Anchor = AnchorStyles.Top;
        footerFlowPanel.AutoSize = true;
        footerFlowPanel.Controls.Add(footerPromptLabel);
        footerFlowPanel.Controls.Add(registerLinkLabel);
        footerFlowPanel.Location = new Point(155, 562);
        footerFlowPanel.Margin = new Padding(0, 26, 0, 0);
        footerFlowPanel.Name = "footerFlowPanel";
        footerFlowPanel.Size = new Size(307, 27);
        footerFlowPanel.TabIndex = 9;
        footerFlowPanel.WrapContents = false;
        // 
        // footerPromptLabel
        // 
        footerPromptLabel.AutoSize = true;
        footerPromptLabel.Font = new Font("Segoe UI", 10F);
        footerPromptLabel.ForeColor = Color.FromArgb(143, 156, 176);
        footerPromptLabel.Location = new Point(0, 4);
        footerPromptLabel.Margin = new Padding(0, 4, 4, 0);
        footerPromptLabel.Name = "footerPromptLabel";
        footerPromptLabel.Size = new Size(157, 23);
        footerPromptLabel.TabIndex = 0;
        footerPromptLabel.Text = "Chưa có tài khoản?";
        // 
        // registerLinkLabel
        // 
        registerLinkLabel.ActiveLinkColor = Color.FromArgb(192, 216, 255);
        registerLinkLabel.AutoSize = true;
        registerLinkLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        registerLinkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
        registerLinkLabel.LinkColor = Color.FromArgb(220, 232, 255);
        registerLinkLabel.Location = new Point(161, 3);
        registerLinkLabel.Margin = new Padding(0, 3, 0, 0);
        registerLinkLabel.Name = "registerLinkLabel";
        registerLinkLabel.Size = new Size(146, 23);
        registerLinkLabel.TabIndex = 1;
        registerLinkLabel.TabStop = true;
        registerLinkLabel.Text = "Đăng ký miễn phí";
        registerLinkLabel.VisitedLinkColor = Color.FromArgb(220, 232, 255);
        registerLinkLabel.LinkClicked += registerLinkLabel_LinkClicked;
        // 
        // LoginForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(13, 18, 25);
        ClientSize = new Size(1264, 761);
        Controls.Add(rootLayout);
        MinimumSize = new Size(980, 720);
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "NestG Launcher";
        rootLayout.ResumeLayout(false);
        heroPanel.ResumeLayout(false);
        heroContentLayout.ResumeLayout(false);
        heroContentLayout.PerformLayout();
        heroHeaderLayout.ResumeLayout(false);
        heroHeaderLayout.PerformLayout();
        heroBrandTextPanel.ResumeLayout(false);
        heroBrandTextPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)heroLogoPictureBox).EndInit();
        cardPanel.ResumeLayout(false);
        cardContentLayout.ResumeLayout(false);
        cardContentLayout.PerformLayout();
        cardHeaderLayout.ResumeLayout(false);
        cardHeaderLayout.PerformLayout();
        cardBrandTextPanel.ResumeLayout(false);
        cardBrandTextPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)cardLogoPictureBox).EndInit();
        emailFieldPanel.ResumeLayout(false);
        emailFieldPanel.PerformLayout();
        passwordFieldPanel.ResumeLayout(false);
        passwordFieldPanel.PerformLayout();
        optionsLayout.ResumeLayout(false);
        optionsLayout.PerformLayout();
        footerFlowPanel.ResumeLayout(false);
        footerFlowPanel.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel rootLayout;
    private UI_Desktop.RoundedPanel heroPanel;
    private TableLayoutPanel heroContentLayout;
    private TableLayoutPanel heroHeaderLayout;
    private Panel heroBrandTextPanel;
    private Label heroMetaLabel;
    private Label heroAppNameLabel;
    private PictureBox heroLogoPictureBox;
    private Label heroBadgeLabel;
    private Label heroTitleLabel;
    private Label heroDescriptionLabel;
    private Label heroBulletOneLabel;
    private Label heroBulletTwoLabel;
    private Label heroBulletThreeLabel;
    private UI_Desktop.RoundedPanel cardPanel;
    private TableLayoutPanel cardContentLayout;
    private TableLayoutPanel cardHeaderLayout;
    private Panel cardBrandTextPanel;
    private Label cardMetaLabel;
    private Label cardAppNameLabel;
    private PictureBox cardLogoPictureBox;
    private Label titleLabel;
    private Label subtitleLabel;
    private Label emailCaptionLabel;
    private UI_Desktop.RoundedPanel emailFieldPanel;
    private TextBox emailTextBox;
    private Label passwordCaptionLabel;
    private UI_Desktop.RoundedPanel passwordFieldPanel;
    private TextBox passwordTextBox;
    private TableLayoutPanel optionsLayout;
    private CheckBox rememberMeCheckBox;
    private LinkLabel forgotPasswordLink;
    private UI_Desktop.GradientButton loginButton;
    private FlowLayoutPanel footerFlowPanel;
    private Label footerPromptLabel;
    private LinkLabel registerLinkLabel;
}
