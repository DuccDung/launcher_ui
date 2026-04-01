using UI_Desktop.Store;

namespace UI_Desktop.Auth;

internal partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
        ConfigureView();
        BindEvents();
    }

    private void ConfigureView()
    {
        AuthUiHelper.ApplyWindowIcon(this);
        AuthUiHelper.EnableDoubleBuffer(this);
        AuthUiHelper.EnableDoubleBuffer(heroPanel);
        AuthUiHelper.EnableDoubleBuffer(cardPanel);

        AuthUiHelper.LoadLogo(heroLogoPictureBox);
        AuthUiHelper.LoadLogo(cardLogoPictureBox);
        AuthUiHelper.ConfigureInput(emailFieldPanel, emailTextBox);
        AuthUiHelper.ConfigureInput(passwordFieldPanel, passwordTextBox);

        AcceptButton = loginButton;
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

    private void loginButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(emailTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text))
        {
            MessageBox.Show(
                "Vui lòng nhập đầy đủ địa chỉ email và mật khẩu trước khi tiếp tục.",
                "Thiếu thông tin",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        AuthUiHelper.Navigate(this, new StoreForm());
    }

    private void forgotPasswordLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        AuthUiHelper.Navigate(this, new PasswordRecoveryForm());
    }

    private void registerLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        AuthUiHelper.Navigate(this, new RegisterForm());
    }
}
