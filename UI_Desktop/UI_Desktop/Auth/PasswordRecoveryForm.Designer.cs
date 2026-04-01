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
        backToLoginLinkLabel = new LinkLabel();
        sendCodeButton = new GradientButton();
        emailFieldPanel = new RoundedPanel();
        emailTextBox = new TextBox();
        emailCaptionLabel = new Label();
        descriptionLabel = new Label();
        subtitleLabel = new Label();
        titleLabel = new Label();
        cardMetaLabel = new Label();
        cardAppNameLabel = new Label();
        cardLogoPictureBox = new PictureBox();
        rootLayout.SuspendLayout();
        heroPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)heroLogoPictureBox).BeginInit();
        cardPanel.SuspendLayout();
        emailFieldPanel.SuspendLayout();
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
        heroBulletThreeLabel.Text = "• Sau khi xác minh, bạn có thể quay lại đăng nhập ngay.";
        // 
        // heroBulletTwoLabel
        // 
        heroBulletTwoLabel.Font = new Font("Segoe UI", 10.25F);
        heroBulletTwoLabel.ForeColor = Color.FromArgb(239, 243, 248);
        heroBulletTwoLabel.Location = new Point(34, 462);
        heroBulletTwoLabel.Name = "heroBulletTwoLabel";
        heroBulletTwoLabel.Size = new Size(396, 48);
        heroBulletTwoLabel.TabIndex = 7;
        heroBulletTwoLabel.Text = "• Mã OTP sẽ được gửi về hộp thư của bạn trong ít phút.";
        // 
        // heroBulletOneLabel
        // 
        heroBulletOneLabel.Font = new Font("Segoe UI", 10.25F);
        heroBulletOneLabel.ForeColor = Color.FromArgb(239, 243, 248);
        heroBulletOneLabel.Location = new Point(34, 402);
        heroBulletOneLabel.Name = "heroBulletOneLabel";
        heroBulletOneLabel.Size = new Size(396, 48);
        heroBulletOneLabel.TabIndex = 6;
        heroBulletOneLabel.Text = "• Kiểm tra đúng email bạn đã dùng khi tạo tài khoản.";
        // 
        // heroDescriptionLabel
        // 
        heroDescriptionLabel.Font = new Font("Segoe UI", 10.5F);
        heroDescriptionLabel.ForeColor = Color.FromArgb(162, 174, 191);
        heroDescriptionLabel.Location = new Point(34, 300);
        heroDescriptionLabel.Name = "heroDescriptionLabel";
        heroDescriptionLabel.Size = new Size(396, 74);
        heroDescriptionLabel.TabIndex = 5;
        heroDescriptionLabel.Text = "Nhập email đã đăng ký để hệ thống gửi mã xác thực và hướng dẫn bạn tạo mật khẩu mới.";
        // 
        // heroTitleLabel
        // 
        heroTitleLabel.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
        heroTitleLabel.ForeColor = Color.FromArgb(239, 243, 248);
        heroTitleLabel.Location = new Point(34, 172);
        heroTitleLabel.Name = "heroTitleLabel";
        heroTitleLabel.Size = new Size(390, 112);
        heroTitleLabel.TabIndex = 4;
        heroTitleLabel.Text = "Nhận mã OTP để đặt lại mật khẩu.";
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
        heroBadgeLabel.Size = new Size(141, 36);
        heroBadgeLabel.TabIndex = 3;
        heroBadgeLabel.Text = "NHẬN MÃ OTP";
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
        cardPanel.Dock = DockStyle.Fill;
        cardPanel.Location = new Point(546, 24);
        cardPanel.Margin = new Padding(0);
        cardPanel.Name = "cardPanel";
        cardPanel.Size = new Size(694, 713);
        cardPanel.TabIndex = 1;
        // 
        // backToLoginLinkLabel
        // 
        backToLoginLinkLabel.ActiveLinkColor = Color.FromArgb(192, 216, 255);
        backToLoginLinkLabel.Anchor = AnchorStyles.Top;
        backToLoginLinkLabel.AutoSize = true;
        backToLoginLinkLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        backToLoginLinkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
        backToLoginLinkLabel.LinkColor = Color.FromArgb(220, 232, 255);
        backToLoginLinkLabel.Location = new Point(271, 516);
        backToLoginLinkLabel.Name = "backToLoginLinkLabel";
        backToLoginLinkLabel.Size = new Size(161, 23);
        backToLoginLinkLabel.TabIndex = 9;
        backToLoginLinkLabel.TabStop = true;
        backToLoginLinkLabel.Text = "Quay lại đăng nhập";
        backToLoginLinkLabel.VisitedLinkColor = Color.FromArgb(220, 232, 255);
        backToLoginLinkLabel.LinkClicked += backToLoginLinkLabel_LinkClicked;
        // 
        // sendCodeButton
        // 
        sendCodeButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        sendCodeButton.BackColor = Color.Transparent;
        sendCodeButton.FlatAppearance.BorderSize = 0;
        sendCodeButton.FlatStyle = FlatStyle.Flat;
        sendCodeButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        sendCodeButton.ForeColor = Color.White;
        sendCodeButton.Location = new Point(38, 432);
        sendCodeButton.MinimumSize = new Size(0, 56);
        sendCodeButton.Name = "sendCodeButton";
        sendCodeButton.Size = new Size(618, 56);
        sendCodeButton.TabIndex = 8;
        sendCodeButton.Text = "Gửi mã OTP";
        sendCodeButton.UseVisualStyleBackColor = true;
        sendCodeButton.Click += sendCodeButton_Click;
        // 
        // emailFieldPanel
        // 
        emailFieldPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        emailFieldPanel.BackColor = Color.Transparent;
        emailFieldPanel.Controls.Add(emailTextBox);
        emailFieldPanel.Location = new Point(38, 338);
        emailFieldPanel.Name = "emailFieldPanel";
        emailFieldPanel.Padding = new Padding(18, 15, 18, 15);
        emailFieldPanel.Size = new Size(618, 54);
        emailFieldPanel.TabIndex = 7;
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
        emailCaptionLabel.Location = new Point(38, 305);
        emailCaptionLabel.Name = "emailCaptionLabel";
        emailCaptionLabel.Size = new Size(108, 23);
        emailCaptionLabel.TabIndex = 6;
        emailCaptionLabel.Text = "Địa chỉ email";
        // 
        // descriptionLabel
        // 
        descriptionLabel.Font = new Font("Segoe UI", 10.5F);
        descriptionLabel.ForeColor = Color.FromArgb(162, 174, 191);
        descriptionLabel.Location = new Point(38, 226);
        descriptionLabel.Name = "descriptionLabel";
        descriptionLabel.Size = new Size(552, 48);
        descriptionLabel.TabIndex = 5;
        descriptionLabel.Text = "Nhập email của bạn để nhận mã OTP đặt lại mật khẩu.";
        // 
        // subtitleLabel
        // 
        subtitleLabel.AutoSize = true;
        subtitleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        subtitleLabel.ForeColor = Color.FromArgb(82, 138, 255);
        subtitleLabel.Location = new Point(38, 166);
        subtitleLabel.Name = "subtitleLabel";
        subtitleLabel.Size = new Size(233, 28);
        subtitleLabel.TabIndex = 4;
        subtitleLabel.Text = "Nhận mã OTP qua email";
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Segoe UI Semibold", 28F, FontStyle.Bold);
        titleLabel.ForeColor = Color.FromArgb(239, 243, 248);
        titleLabel.Location = new Point(38, 104);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(240, 62);
        titleLabel.TabIndex = 3;
        titleLabel.Text = "Khôi phục";
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
        // PasswordRecoveryForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(13, 18, 25);
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
        emailFieldPanel.ResumeLayout(false);
        emailFieldPanel.PerformLayout();
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
    private Label descriptionLabel;
    private Label emailCaptionLabel;
    private UI_Desktop.RoundedPanel emailFieldPanel;
    private TextBox emailTextBox;
    private UI_Desktop.GradientButton sendCodeButton;
    private LinkLabel backToLoginLinkLabel;
}
