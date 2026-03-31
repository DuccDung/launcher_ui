using UI_Desktop;

namespace UI_Desktop.Auth;

internal partial class PasswordRecoveryForm : Form
{
    public PasswordRecoveryForm()
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
        AuthUiHelper.ConfigureInput(emailFieldPanel, emailTextBox);

        AcceptButton = sendCodeButton;
        UpdateResponsiveLayout();
    }

    private void BindEvents()
    {
        Resize += (_, _) => UpdateResponsiveLayout();
        Shown += (_, _) => emailTextBox.Focus();
    }

    private void UpdateResponsiveLayout()
    {
        AuthUiHelper.UpdateResponsiveLayout(this, rootLayout, heroPanel);
    }

    private void sendCodeButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(emailTextBox.Text))
        {
            MessageBox.Show(
                "Vui lòng nhập địa chỉ email để nhận mã xác thực.",
                "Thiếu email",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        MessageBox.Show(
            "Màn hình khôi phục đã sẵn sàng để nối với dịch vụ gửi mã xác thực qua email.",
            "Khôi phục mật khẩu",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void backToLoginLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        AuthUiHelper.Navigate(this, new LoginForm());
    }
}
