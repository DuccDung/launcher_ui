namespace UI_Desktop;

internal sealed class LoginForm : AuthFormBase
{
    private readonly AuthTextField emailField;
    private readonly AuthTextField passwordField;

    public LoginForm()
    {
        ConfigureHero(
            "ĐĂNG NHẬP AN TOÀN",
            "Một điểm truy cập gọn gàng cho tài khoản NestG của bạn.",
            "Thiết kế mới tập trung vào độ rõ ràng, tốc độ thao tác và cảm giác desktop chuyên nghiệp hơn khi đăng nhập hằng ngày.",
            "Theo dõi đơn mua, trạng thái kích hoạt và thông tin thiết bị trong cùng một luồng.",
            "Lưu phiên làm việc gọn gàng để người dùng quay lại nhanh hơn trên desktop.",
            "Khôi phục mật khẩu hoặc điều hướng sang đăng ký mà không phải đổi cửa sổ ứng dụng.");

        ConfigurePage(
            "Đăng nhập",
            "Chào mừng bạn quay lại",
            string.Empty);

        emailField = CreateField("Địa chỉ email", "example@gmail.com");
        passwordField = CreateField("Mật khẩu", "Nhập mật khẩu của bạn", true);

        AddFormRow(emailField);
        AddFormRow(passwordField);

        var rememberCheckBox = CreateCheckBox("Ghi nhớ");
        var forgotPasswordLink = CreateLinkLabel("Quên mật khẩu?");
        forgotPasswordLink.LinkClicked += (_, _) => NavigateTo(() => new PasswordRecoveryForm());

        AddFormRow(CreateSplitRow(rememberCheckBox, forgotPasswordLink), 28);

        ConfigurePrimaryAction("Đăng nhập", LoginButton_Click);
        ConfigureFooter("Chưa có tài khoản?", "Đăng ký miễn phí", (_, _) => NavigateTo(() => new RegisterForm()));

        Shown += (_, _) => emailField.TextBox.Focus();
    }

    private void LoginButton_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(emailField.Value) || string.IsNullOrWhiteSpace(passwordField.Value))
        {
            ShowPlaceholderMessage(
                "Thiếu thông tin",
                "Vui lòng nhập đầy đủ địa chỉ email và mật khẩu trước khi tiếp tục.",
                MessageBoxIcon.Warning);
            return;
        }

        ShowPlaceholderMessage(
            "Đăng nhập",
            "Giao diện đăng nhập đã sẵn sàng để nối với API xác thực của hệ thống.",
            MessageBoxIcon.Information);
    }
}
