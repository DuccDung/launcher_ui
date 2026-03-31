namespace UI_Desktop;

internal sealed class PasswordRecoveryForm : AuthFormBase
{
    private readonly AuthTextField emailField;

    public PasswordRecoveryForm()
    {
        ConfigureHero(
            "KHÔI PHỤC QUYỀN TRUY CẬP",
            "Đặt lại mật khẩu theo một luồng an toàn và dễ hiểu.",
            "Màn hình khôi phục được tinh giản cho tác vụ chính: nhập email, gửi mã xác thực và quay lại đăng nhập khi cần.",
            "Giữ đúng tinh thần giao diện mẫu nhưng cải thiện spacing, màu sắc và độ tương phản.",
            "Sẵn sàng nối tiếp sang bước nhập OTP hoặc đặt lại mật khẩu mới.",
            "Phần giới thiệu sẽ tự ẩn ở cửa sổ nhỏ để khu vực thao tác luôn đủ rộng.");

        ConfigurePage(
            "Khôi phục",
            "Đặt lại mật khẩu của bạn",
            "Nhập email của bạn để nhận mã xác thực đặt lại mật khẩu.");

        emailField = CreateField("Địa chỉ email", "example@gmail.com");
        AddFormRow(emailField, 28);

        ConfigurePrimaryAction("Gửi mã xác thực", SendCodeButton_Click);
        ConfigureFooter(string.Empty, "Quay lại đăng nhập", (_, _) => NavigateTo(() => new LoginForm()));

        Shown += (_, _) => emailField.TextBox.Focus();
    }

    private void SendCodeButton_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(emailField.Value))
        {
            ShowPlaceholderMessage(
                "Thiếu email",
                "Vui lòng nhập địa chỉ email để nhận mã xác thực.",
                MessageBoxIcon.Warning);
            return;
        }

        ShowPlaceholderMessage(
            "Khôi phục mật khẩu",
            "Màn hình khôi phục đã sẵn sàng để nối với dịch vụ gửi mã xác thực qua email.",
            MessageBoxIcon.Information);
    }
}
