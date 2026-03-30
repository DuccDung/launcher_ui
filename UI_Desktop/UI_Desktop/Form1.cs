using System.Drawing.Drawing2D;

namespace UI_Desktop
{
    public partial class Form1 : Form
    {
        private readonly List<(Control Control, int Radius)> roundedControls = new();
        private readonly Color formBackColor = Color.FromArgb(6, 8, 12);
        private readonly Color fieldIdleColor = Color.FromArgb(31, 35, 43);
        private readonly Color fieldFocusColor = Color.FromArgb(40, 46, 58);

        public Form1()
        {
            InitializeComponent();
            ConfigureForm();
            ConfigureInteractions();
        }

        private void ConfigureForm()
        {
            DoubleBuffered = true;
            BackColor = formBackColor;
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            MinimumSize = new Size(1360, 860);

            roundedControls.Clear();
            RegisterRounded(contentPanel, 28);
            RegisterRounded(featureCardPanel, 22);
            RegisterRounded(supportCardPanel, 18);
            RegisterRounded(loginCardPanel, 22);
            RegisterRounded(emailFieldPanel, 14);
            RegisterRounded(passwordFieldPanel, 14);
            RegisterRounded(loginButton, 14);
            RegisterRounded(otpButton, 14);
            RegisterRounded(securityNotePanel, 18);

            CenterContentPanel();
            ApplyRoundedShapes();
        }

        private void ConfigureInteractions()
        {
            Resize += (_, _) =>
            {
                CenterContentPanel();
                ApplyRoundedShapes();
            };

            Shown += (_, _) => emailTextBox.Focus();

            emailTextBox.Enter += (_, _) => SetFieldState(emailFieldPanel, emailTextBox, true);
            emailTextBox.Leave += (_, _) => SetFieldState(emailFieldPanel, emailTextBox, false);
            passwordTextBox.Enter += (_, _) => SetFieldState(passwordFieldPanel, passwordTextBox, true);
            passwordTextBox.Leave += (_, _) => SetFieldState(passwordFieldPanel, passwordTextBox, false);

            showPasswordCheckBox.CheckedChanged += (_, _) =>
            {
                passwordTextBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
            };

            loginButton.Click += LoginButton_Click;
            otpButton.Click += OtpButton_Click;
            forgotPasswordLink.LinkClicked += ForgotPasswordLink_LinkClicked;
            registerLink.LinkClicked += RegisterLink_LinkClicked;
            AcceptButton = loginButton;
        }

        private void CenterContentPanel()
        {
            var x = Math.Max(24, (ClientSize.Width - contentPanel.Width) / 2);
            var y = Math.Max(24, (ClientSize.Height - contentPanel.Height) / 2);
            contentPanel.Location = new Point(x, y);
        }

        private void SetFieldState(Panel shell, TextBox input, bool isFocused)
        {
            var backColor = isFocused ? fieldFocusColor : fieldIdleColor;
            shell.BackColor = backColor;
            input.BackColor = backColor;
        }

        private void LoginButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show(
                    "Vui long nhap day du email/so dien thoai va mat khau.",
                    "Thieu thong tin",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                "Form dang nhap da san sang. Ban co the noi nut nay vao API dang nhap user.",
                "Dang nhap",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void OtpButton_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Nut OTP da duoc dat san de ban noi vao luong gui ma sau nay.",
                "Nhan OTP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ForgotPasswordLink_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "Ban co the noi link nay sang flow quen mat khau.",
                "Quen mat khau",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void RegisterLink_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "Ban co the noi link nay sang form dang ky user.",
                "Tao tai khoan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void shellPanel_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawGlow(e.Graphics, new Rectangle(150, 120, 420, 320), Color.FromArgb(70, 226, 132, 50));
            DrawGlow(e.Graphics, new Rectangle(1040, 240, 260, 260), Color.FromArgb(45, 80, 133, 235));
        }

        private void surfacePanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Control control)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var path = BuildRoundedPath(new Rectangle(0, 0, control.Width - 1, control.Height - 1), 20);
            using var pen = new Pen(Color.FromArgb(28, 255, 255, 255), 1F);
            e.Graphics.DrawPath(pen, path);
        }

        private static void DrawGlow(Graphics graphics, Rectangle bounds, Color centerColor)
        {
            using var path = new GraphicsPath();
            path.AddEllipse(bounds);

            using var brush = new PathGradientBrush(path)
            {
                CenterColor = centerColor,
                SurroundColors = new[] { Color.FromArgb(0, centerColor) }
            };

            graphics.FillPath(brush, path);
        }

        private void ApplyRoundedShapes()
        {
            foreach (var (control, radius) in roundedControls)
            {
                if (control.Width <= 0 || control.Height <= 0)
                {
                    continue;
                }

                control.Region?.Dispose();
                using var path = BuildRoundedPath(new Rectangle(Point.Empty, control.Size), radius);
                control.Region = new Region(path);
            }
        }

        private void RegisterRounded(Control control, int radius)
        {
            roundedControls.Add((control, radius));
        }

        private static GraphicsPath BuildRoundedPath(Rectangle bounds, int radius)
        {
            var safeRadius = Math.Min(radius, Math.Min(bounds.Width, bounds.Height) / 2);
            var diameter = Math.Max(2, safeRadius * 2);

            var path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
