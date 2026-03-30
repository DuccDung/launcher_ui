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
            DoubleBuffered = true;
            BackColor = formBackColor;
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            MinimumSize = new Size(1360, 860);
            FormBorderStyle = FormBorderStyle.None;
            Text = "NestG";

            ApplyBranding();
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
            otpButton.Click += OtpButton_Click;
            forgotPasswordLink.LinkClicked += ForgotPasswordLink_LinkClicked;
            registerLink.LinkClicked += RegisterLink_LinkClicked;
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
            appNameLabel.Text = "NestG";
            appSubtitleLabel.Text = "User launcher";
            toolbarInfoLabel.Text = "Secure desktop access";
            toolbarModeLabel.Text = "Player Mode";
            brandChipLabel.Text = "NESTG";
            launcherChipLabel.Text = "User Launcher";
            loginTagChipLabel.Text = "NESTG USER";
            showcaseTitleLabel.Text = "Dang nhap vao NestG,\r\nquan ly game va account cua ban.";
            showcaseDescriptionLabel.Text = "NestG gom dang nhap, don mua, account game va uu dai vao mot giao dien" +
                "\r\ndesktop ro rang, gon va de su dung.";
            featureDescriptionLabel.Text = "NestG giu chat dark premium cua web nhung toi uu lai cho launcher" +
                "\r\ndesktop de thao tac nhanh va nhin chac chan hon.";
            supportDescriptionLabel.Text = "Neu user quen mat khau hoac can tro giup, ban co the noi tiep flow OTP" +
                "\r\nva ticket ho tro ngay tai day.";
            loginTitleLabel.Text = "Chao mung den NestG";
            loginDescriptionLabel.Text = "Dang nhap de quan ly tai khoan,\r\ndon mua, account game va uu dai rieng cua ban.";
            showcaseFooterLabel.Text = "NestG launcher duoc dong bo tu asset logo va theme dark cua he thong.";

            LoadBrandLogo();
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
