using UI_Desktop;

namespace UI_Desktop.Auth;

partial class PasswordRecoveryForm
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
        descriptionLabel = new Label();
        emailCaptionLabel = new Label();
        emailFieldPanel = new UI_Desktop.RoundedPanel();
        emailTextBox = new TextBox();
        sendCodeButton = new UI_Desktop.GradientButton();
        backToLoginLinkLabel = new LinkLabel();
        rootLayout.SuspendLayout();
        heroPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)heroLogoPictureBox).BeginInit();
        cardPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)cardLogoPictureBox).BeginInit();
        emailFieldPanel.SuspendLayout();
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
        rootLayout.Size = new Size(1264, 761);
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
        heroPanel.Size = new Size(507, 713);
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
        heroBadgeLabel.Size = new Size(197, 36);
        heroBadgeLabel.TabIndex = 3;
        heroBadgeLabel.Text = "KHÔI PHỤC QUYỀN TRUY CẬP";
        // 
        // heroTitleLabel
        // 
        heroTitleLabel.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
        heroTitleLabel.ForeColor = AppTheme.PrimaryText;
        heroTitleLabel.Location = new Point(34, 172);
        heroTitleLabel.Name = "heroTitleLabel";
        heroTitleLabel.Size = new Size(390, 112);
        heroTitleLabel.TabIndex = 4;
        heroTitleLabel.Text = "Đặt lại mật khẩu theo một luồng an toàn và dễ hiểu.";
        // 
        // heroDescriptionLabel
        // 
        heroDescriptionLabel.Font = new Font("Segoe UI", 10.5F);
        heroDescriptionLabel.ForeColor = AppTheme.SecondaryText;
        heroDescriptionLabel.Location = new Point(34, 300);
        heroDescriptionLabel.Name = "heroDescriptionLabel";
        heroDescriptionLabel.Size = new Size(396, 74);
        heroDescriptionLabel.TabIndex = 5;
        heroDescriptionLabel.Text = "Màn hình khôi phục được tinh giản cho tác vụ chính: nhập email, gửi mã xác thực và quay lại đăng nhập khi cần.";
        // 
        // heroBulletOneLabel
        // 
        heroBulletOneLabel.Font = new Font("Segoe UI", 10.25F);
        heroBulletOneLabel.ForeColor = AppTheme.PrimaryText;
        heroBulletOneLabel.Location = new Point(34, 402);
        heroBulletOneLabel.Name = "heroBulletOneLabel";
        heroBulletOneLabel.Size = new Size(396, 48);
        heroBulletOneLabel.TabIndex = 6;
        heroBulletOneLabel.Text = "• Giữ đúng tinh thần giao diện mẫu nhưng cải thiện spacing, màu sắc và độ tương phản.";
        // 
        // heroBulletTwoLabel
        // 
        heroBulletTwoLabel.Font = new Font("Segoe UI", 10.25F);
        heroBulletTwoLabel.ForeColor = AppTheme.PrimaryText;
        heroBulletTwoLabel.Location = new Point(34, 462);
        heroBulletTwoLabel.Name = "heroBulletTwoLabel";
        heroBulletTwoLabel.Size = new Size(396, 48);
        heroBulletTwoLabel.TabIndex = 7;
        heroBulletTwoLabel.Text = "• Sẵn sàng nối tiếp sang bước nhập OTP hoặc đặt lại mật khẩu mới.";
        // 
        // heroBulletThreeLabel
        // 
        heroBulletThreeLabel.Font = new Font("Segoe UI", 10.25F);
        heroBulletThreeLabel.ForeColor = AppTheme.PrimaryText;
        heroBulletThreeLabel.Location = new Point(34, 522);
        heroBulletThreeLabel.Name = "heroBulletThreeLabel";
        heroBulletThreeLabel.Size = new Size(396, 48);
        heroBulletThreeLabel.TabIndex = 8;
        heroBulletThreeLabel.Text = "• Phần giới thiệu sẽ tự ẩn ở cửa sổ nhỏ để khu vực thao tác luôn đủ rộng.";
        // 
        // cardPanel
        // 
        cardPanel.BackColor = Color.Transparent;
        cardPanel.BorderColor = Color.FromArgb(52, 64, 83);
        cardPanel.BorderThickness = 1;
        cardPanel.Controls.Add(backToLoginLinkLabel);
        cardPanel.Controls.Add(sendCodeButton);
        cardPanel.Controls.Add(emailFieldPanel);
        cardPanel.Controls.Add(emailCaptionLabel);
        cardPanel.Controls.Add(descriptionLabel);
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
        cardPanel.Size = new Size(691, 713);
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
        titleLabel.Size = new Size(196, 62);
        titleLabel.TabIndex = 3;
        titleLabel.Text = "Khôi phục";
        // 
        // subtitleLabel
        // 
        subtitleLabel.AutoSize = true;
        subtitleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        subtitleLabel.ForeColor = AppTheme.Accent;
        subtitleLabel.Location = new Point(38, 166);
        subtitleLabel.Name = "subtitleLabel";
        subtitleLabel.Size = new Size(216, 28);
        subtitleLabel.TabIndex = 4;
        subtitleLabel.Text = "Đặt lại mật khẩu của bạn";
        // 
        // descriptionLabel
        // 
        descriptionLabel.Font = new Font("Segoe UI", 10.5F);
        descriptionLabel.ForeColor = AppTheme.SecondaryText;
        descriptionLabel.Location = new Point(38, 226);
        descriptionLabel.Name = "descriptionLabel";
        descriptionLabel.Size = new Size(552, 48);
        descriptionLabel.TabIndex = 5;
        descriptionLabel.Text = "Nhập email của bạn để nhận mã xác thực đặt lại mật khẩu.";
        // 
        // emailCaptionLabel
        // 
        emailCaptionLabel.AutoSize = true;
        emailCaptionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        emailCaptionLabel.ForeColor = AppTheme.SecondaryText;
        emailCaptionLabel.Location = new Point(38, 305);
        emailCaptionLabel.Name = "emailCaptionLabel";
        emailCaptionLabel.Size = new Size(109, 23);
        emailCaptionLabel.TabIndex = 6;
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
        emailFieldPanel.Location = new Point(38, 338);
        emailFieldPanel.Name = "emailFieldPanel";
        emailFieldPanel.Padding = new Padding(18, 15, 18, 15);
        emailFieldPanel.Size = new Size(615, 54);
        emailFieldPanel.SurfaceColor = AppTheme.InputSurface;
        emailFieldPanel.TabIndex = 7;
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
        // sendCodeButton
        // 
        sendCodeButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        sendCodeButton.CornerRadius = 26;
        sendCodeButton.EndColor = Color.FromArgb(50, 103, 242);
        sendCodeButton.FlatAppearance.BorderSize = 0;
        sendCodeButton.FlatStyle = FlatStyle.Flat;
        sendCodeButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        sendCodeButton.ForeColor = Color.White;
        sendCodeButton.Location = new Point(38, 432);
        sendCodeButton.Name = "sendCodeButton";
        sendCodeButton.Size = new Size(615, 56);
        sendCodeButton.StartColor = Color.FromArgb(86, 140, 255);
        sendCodeButton.TabIndex = 8;
        sendCodeButton.Text = "Gửi mã xác thực";
        sendCodeButton.UseVisualStyleBackColor = true;
        sendCodeButton.Click += sendCodeButton_Click;
        // 
        // backToLoginLinkLabel
        // 
        backToLoginLinkLabel.ActiveLinkColor = Color.FromArgb(192, 216, 255);
        backToLoginLinkLabel.Anchor = AnchorStyles.Top;
        backToLoginLinkLabel.AutoSize = true;
        backToLoginLinkLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        backToLoginLinkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
        backToLoginLinkLabel.LinkColor = Color.FromArgb(220, 232, 255);
        backToLoginLinkLabel.Location = new Point(269, 516);
        backToLoginLinkLabel.Name = "backToLoginLinkLabel";
        backToLoginLinkLabel.Size = new Size(154, 23);
        backToLoginLinkLabel.TabIndex = 9;
        backToLoginLinkLabel.TabStop = true;
        backToLoginLinkLabel.Text = "Quay lại đăng nhập";
        backToLoginLinkLabel.VisitedLinkColor = Color.FromArgb(220, 232, 255);
        backToLoginLinkLabel.LinkClicked += backToLoginLinkLabel_LinkClicked;
        // 
        // PasswordRecoveryForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = AppTheme.WindowBackground;
        ClientSize = new Size(1264, 761);
        Controls.Add(rootLayout);
        MinimumSize = new Size(980, 720);
        Name = "PasswordRecoveryForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "NestG Launcher";
        rootLayout.ResumeLayout(false);
        heroPanel.ResumeLayout(false);
        heroPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)heroLogoPictureBox).EndInit();
        cardPanel.ResumeLayout(false);
        cardPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)cardLogoPictureBox).EndInit();
        emailFieldPanel.ResumeLayout(false);
        emailFieldPanel.PerformLayout();
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
    private Label descriptionLabel;
    private Label emailCaptionLabel;
    private UI_Desktop.RoundedPanel emailFieldPanel;
    private TextBox emailTextBox;
    private UI_Desktop.GradientButton sendCodeButton;
    private LinkLabel backToLoginLinkLabel;
}
