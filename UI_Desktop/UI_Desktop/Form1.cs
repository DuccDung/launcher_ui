using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace UI_Desktop
{
    public partial class Form1 : Form
    {
        private const int WmNclButtonDown = 0xA1;
        private const int HtCaption = 0x2;

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
            AppIconProvider.ApplyIcon(this);
            DoubleBuffered = true;
            BackColor = formBackColor;
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            MinimumSize = new Size(1360, 860);
            FormBorderStyle = FormBorderStyle.None;
            Text = "NestG";

            ApplyBranding();
            if (!IsInDesignMode())
            {
                SimplifyForUsers();
            }

            LayoutShell();
        }

        private void ConfigureInteractions()
        {
            Resize += (_, _) =>
            {
                LayoutShell();
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
            forgotPasswordLink.LinkClicked += ForgotPasswordLink_LinkClicked;
            minimizeWindowButton.Click += (_, _) => WindowState = FormWindowState.Minimized;
            closeWindowButton.Click += (_, _) => Close();

            AttachDragHandlers(topBarPanel);
            AttachDragHandlers(brandLogoPictureBox);
            AttachDragHandlers(appNameLabel);
            AttachDragHandlers(appSubtitleLabel);
            AttachDragHandlers(toolbarInfoLabel);
            AttachDragHandlers(toolbarModeLabel);

            AcceptButton = loginButton;
        }

        private void ApplyBranding()
        {
            LoadBrandLogo();
        }

        private void SimplifyForUsers()
        {
            toolbarInfoLabel.Visible = false;
            toolbarModeLabel.Visible = false;
            launcherChipLabel.Visible = false;
            loginSecurityChipLabel.Visible = false;
            supportCardPanel.Visible = false;
            securityNotePanel.Visible = false;
            registerPromptLabel.Visible = false;
            registerLink.Visible = false;
            otpButton.Visible = false;
            otpButton.Enabled = false;
            showcaseFooterLabel.Visible = false;

            loginButton.Location = new Point(36, 458);
            loginButton.Size = new Size(364, 46);
        }

        private static bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }

        private void LayoutShell()
        {
            var topBarX = Math.Max(20, (ClientSize.Width - topBarPanel.Width) / 2);
            topBarPanel.Location = new Point(topBarX, 26);

            var contentX = Math.Max(20, (ClientSize.Width - contentPanel.Width) / 2);
            var contentY = topBarPanel.Bottom + 16;
            contentPanel.Location = new Point(contentX, contentY);
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
                    "Vui lòng nhập đầy đủ email hoặc số điện thoại và mật khẩu.",
                    "Thiếu thông tin",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                "Biểu mẫu đăng nhập đã sẵn sàng để kết nối với API người dùng.",
                "Đăng nhập",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ForgotPasswordLink_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "Bạn có thể kết nối liên kết này với luồng quên mật khẩu.",
                "Quên mật khẩu",
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
            using var pen = new Pen(Color.FromArgb(28, 255, 255, 255), 1F);
            e.Graphics.DrawRectangle(pen, 0, 0, control.Width - 1, control.Height - 1);
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

        private void LoadBrandLogo()
        {
            try
            {
                var assetPath = Path.Combine(AppContext.BaseDirectory, "Assets", "logo.png");
                if (!File.Exists(assetPath))
                {
                    return;
                }

                using var original = Image.FromFile(assetPath);
                brandLogoPictureBox.Image = new Bitmap(original);
            }
            catch
            {
                // Keep the launcher usable even if the image asset is unavailable.
            }
        }

        private void AttachDragHandlers(Control control)
        {
            control.MouseDown += TopBarDrag_MouseDown;
        }

        private void TopBarDrag_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            ReleaseCapture();
            SendMessage(Handle, WmNclButtonDown, HtCaption, 0);
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern nint SendMessage(nint hWnd, int msg, int wParam, int lParam);

    }
}

