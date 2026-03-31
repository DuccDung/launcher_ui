using UI_Desktop;

namespace UI_Desktop.Auth;

internal partial class RegisterForm : Form
{
    public RegisterForm()
    {
        InitializeComponent();
        ConfigureView();
        BindEvents();
    }

    private void ConfigureView()
    {
        AuthUiHelper.EnableDoubleBuffer(this);
        AuthUiHelper.EnableDoubleBuffer(heroPanel);
        AuthUiHelper.EnableDoubleBuffer(cardPanel);

        AuthUiHelper.LoadLogo(heroLogoPictureBox);
        AuthUiHelper.LoadLogo(cardLogoPictureBox);
        AuthUiHelper.ConfigureInput(displayNameFieldPanel, displayNameTextBox);
        AuthUiHelper.ConfigureInput(usernameFieldPanel, usernameTextBox);
        AuthUiHelper.ConfigureInput(emailFieldPanel, emailTextBox);
        AuthUiHelper.ConfigureInput(passwordFieldPanel, passwordTextBox);

        AcceptButton = continueButton;
        UpdateResponsiveLayout();
    }

    private void BindEvents()
    {
        Resize += (_, _) => UpdateResponsiveLayout();
        Shown += (_, _) => displayNameTextBox.Focus();
    }

    private void UpdateResponsiveLayout()
    {
        AuthUiHelper.UpdateResponsiveLayout(this, rootLayout, heroPanel);
    }

    private void continueButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(displayNameTextBox.Text) ||
            string.IsNullOrWhiteSpace(usernameTextBox.Text) ||
            string.IsNullOrWhiteSpace(emailTextBox.Text) ||
            string.IsNullOrWhiteSpace(passwordTextBox.Text))
        {
            MessageBox.Show(
                "Vui lòng điền đầy đủ tên hiển thị, username, email và mật khẩu.",
                "Thiếu thông tin",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        if (passwordTextBox.Text.Length < 6)
        {
            MessageBox.Show(
                "Mật khẩu cần có ít nhất 6 ký tự.",
                "Mật khẩu chưa hợp lệ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        MessageBox.Show(
            "Màn hình đăng ký đã sẵn sàng để nối với luồng tạo tài khoản hoặc xác thực email.",
            "Đăng ký",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void loginLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        AuthUiHelper.Navigate(this, new LoginForm());
    }
}
