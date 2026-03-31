namespace UI_Desktop;

internal sealed class RegisterForm : AuthFormBase
{
    private readonly AuthTextField displayNameField;
    private readonly AuthTextField usernameField;
    private readonly AuthTextField emailField;
    private readonly AuthTextField passwordField;

    public RegisterForm()
    {
        ConfigureHero(
            "TẠO HỒ SƠ MỚI",
            "Thiết lập tài khoản NestG chỉ trong vài bước rõ ràng.",
            "Form đăng ký được giữ tối giản để tập trung vào thông tin cốt lõi, đồng thời vẫn đủ hiện đại để dùng lâu dài trong launcher desktop.",
            "Tách rõ tên hiển thị và username để thuận tiện đồng bộ hồ sơ về sau.",
            "Bố cục co giãn cơ bản giúp form vẫn dễ đọc ở kích thước cửa sổ nhỏ hơn.",
            "Sẵn sàng nối tiếp sang bước xác thực email hoặc API tạo tài khoản.");

        ConfigurePage(
            "Tạo tài khoản",
            "Tham gia cộng đồng NestG",
            string.Empty);

        displayNameField = CreateField("Tên hiển thị", "Ví dụ: Nguyễn Văn A");
        usernameField = CreateField("Tên tài khoản (username)", "Ví dụ: nestg.user");
        emailField = CreateField("Địa chỉ email", "example@gmail.com");
        passwordField = CreateField("Mật khẩu", "Tối thiểu 6 ký tự", true);

        AddFormRow(displayNameField);
        AddFormRow(usernameField);
        AddFormRow(emailField);
        AddFormRow(passwordField, 8);
        AddFormRow(CreateHintLabel("Mật khẩu nên có ít nhất 6 ký tự để đủ điều kiện cho bước xác thực tiếp theo."), 28);

        ConfigurePrimaryAction("Tiếp theo", ContinueButton_Click);
        ConfigureFooter("Đã có tài khoản?", "Quay lại đăng nhập", (_, _) => NavigateTo(() => new LoginForm()));

        Shown += (_, _) => displayNameField.TextBox.Focus();
    }

    private void ContinueButton_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(displayNameField.Value) ||
            string.IsNullOrWhiteSpace(usernameField.Value) ||
            string.IsNullOrWhiteSpace(emailField.Value) ||
            string.IsNullOrWhiteSpace(passwordField.Value))
        {
            ShowPlaceholderMessage(
                "Thiếu thông tin",
                "Vui lòng điền đầy đủ tên hiển thị, username, email và mật khẩu.",
                MessageBoxIcon.Warning);
            return;
        }

        if (passwordField.Value.Length < 6)
        {
            ShowPlaceholderMessage(
                "Mật khẩu chưa hợp lệ",
                "Mật khẩu cần có ít nhất 6 ký tự.",
                MessageBoxIcon.Warning);
            return;
        }

        ShowPlaceholderMessage(
            "Đăng ký",
            "Màn hình đăng ký đã sẵn sàng để nối với luồng tạo tài khoản hoặc xác thực email.",
            MessageBoxIcon.Information);
    }
}
