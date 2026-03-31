using System.Drawing.Drawing2D;

namespace UI_Desktop;

internal abstract class AuthFormBase : Form
{
    private readonly TableLayoutPanel shellLayout;
    private readonly RoundedPanel heroPanel;
    private readonly TableLayoutPanel heroLayout;
    private readonly Label heroBadgeLabel;
    private readonly Label heroTitleLabel;
    private readonly Label heroDescriptionLabel;
    private readonly TableLayoutPanel heroBulletLayout;

    private readonly RoundedPanel authCard;
    private readonly TableLayoutPanel authCardLayout;
    private readonly PictureBox brandPictureBox;
    private readonly PictureBox heroLogoPictureBox;
    private readonly FlowLayoutPanel footerFlow;
    private readonly Label footerPromptLabel;
    private readonly LinkLabel footerLinkLabel;

    protected readonly Label TitleLabel;
    protected readonly Label SubtitleLabel;
    protected readonly Label DescriptionLabel;
    protected readonly TableLayoutPanel FormBodyLayout;
    protected readonly GradientButton PrimaryButton;

    protected AuthFormBase()
    {
        AutoScaleMode = AutoScaleMode.None;
        BackColor = AppTheme.WindowBackground;
        DoubleBuffered = true;
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        MinimumSize = new Size(920, 680);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "NestG Launcher";

        shellLayout = new TableLayoutPanel
        {
            BackColor = AppTheme.WindowBackground,
            ColumnCount = 2,
            Dock = DockStyle.Fill,
            Margin = new Padding(0),
            Padding = new Padding(24),
            RowCount = 1
        };
        shellLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43F));
        shellLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57F));
        shellLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        heroPanel = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, 18, 0),
            Padding = new Padding(34),
            BorderColor = Color.FromArgb(42, 53, 70),
            BorderThickness = 1,
            CornerRadius = 30,
            SurfaceColor = AppTheme.HeroSurface
        };
        heroPanel.Paint += HeroPanel_Paint;

        heroLayout = new TableLayoutPanel
        {
            BackColor = Color.Transparent,
            ColumnCount = 1,
            Dock = DockStyle.Fill,
            Margin = new Padding(0),
            Padding = new Padding(0),
            RowCount = 4
        };
        heroLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        heroLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        heroLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        heroLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        heroLogoPictureBox = new PictureBox
        {
            BackColor = Color.Transparent,
            Margin = new Padding(0, 0, 14, 0),
            Size = new Size(46, 46),
            SizeMode = PictureBoxSizeMode.Zoom
        };
        heroLayout.Controls.Add(CreateHeroBrandHeader(), 0, 0);

        heroBadgeLabel = new Label
        {
            AutoSize = true,
            BackColor = AppTheme.AccentSoft,
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(176, 207, 255),
            Margin = new Padding(0, 30, 0, 14),
            Padding = new Padding(14, 8, 14, 8),
            Text = "NESTG"
        };
        heroLayout.Controls.Add(heroBadgeLabel, 0, 1);

        var heroTextPanel = new Panel
        {
            AutoSize = true,
            BackColor = Color.Transparent,
            Dock = DockStyle.Top,
            Margin = new Padding(0)
        };

        heroTitleLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = AppTheme.PrimaryText,
            Margin = new Padding(0),
            MaximumSize = new Size(540, 0)
        };

        heroDescriptionLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = AppTheme.SecondaryText,
            Margin = new Padding(0, 16, 0, 0),
            MaximumSize = new Size(540, 0)
        };

        heroTextPanel.Controls.Add(heroDescriptionLabel);
        heroTextPanel.Controls.Add(heroTitleLabel);
        heroDescriptionLabel.Dock = DockStyle.Top;
        heroTitleLabel.Dock = DockStyle.Top;
        heroLayout.Controls.Add(heroTextPanel, 0, 2);

        heroBulletLayout = new TableLayoutPanel
        {
            AutoSize = true,
            BackColor = Color.Transparent,
            ColumnCount = 1,
            Dock = DockStyle.Top,
            Margin = new Padding(0, 28, 0, 0)
        };
        heroLayout.Controls.Add(heroBulletLayout, 0, 3);

        heroPanel.Controls.Add(heroLayout);

        authCard = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(0),
            Padding = new Padding(0),
            BorderColor = AppTheme.CardBorder,
            BorderThickness = 1,
            CornerRadius = 30,
            SurfaceColor = AppTheme.CardSurface
        };

        authCardLayout = new TableLayoutPanel
        {
            AutoScroll = true,
            BackColor = Color.Transparent,
            ColumnCount = 1,
            Dock = DockStyle.Fill,
            Margin = new Padding(0),
            Padding = new Padding(40, 34, 40, 34)
        };

        brandPictureBox = new PictureBox
        {
            BackColor = Color.Transparent,
            Margin = new Padding(0, 0, 12, 0),
            Size = new Size(34, 34),
            SizeMode = PictureBoxSizeMode.Zoom
        };
        AddCardRow(CreateCardBrandHeader());

        TitleLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI Semibold", 28F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = AppTheme.PrimaryText,
            Margin = new Padding(0, 26, 0, 4)
        };
        AddCardRow(TitleLabel);

        SubtitleLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = AppTheme.Accent,
            Margin = new Padding(0, 0, 0, 18)
        };
        AddCardRow(SubtitleLabel);

        DescriptionLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = AppTheme.SecondaryText,
            Margin = new Padding(0, 0, 0, 26),
            MaximumSize = new Size(620, 0)
        };
        AddCardRow(DescriptionLabel);

        FormBodyLayout = new TableLayoutPanel
        {
            AutoSize = true,
            BackColor = Color.Transparent,
            ColumnCount = 1,
            Dock = DockStyle.Top,
            Margin = new Padding(0, 0, 0, 26)
        };
        AddCardRow(FormBodyLayout);

        PrimaryButton = new GradientButton
        {
            Dock = DockStyle.Top,
            Margin = new Padding(0, 0, 0, 22)
        };
        AddCardRow(PrimaryButton);

        footerFlow = new FlowLayoutPanel
        {
            AutoSize = true,
            BackColor = Color.Transparent,
            FlowDirection = FlowDirection.LeftToRight,
            Margin = new Padding(0),
            WrapContents = false
        };

        footerPromptLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = AppTheme.MutedText,
            Margin = new Padding(0, 4, 4, 0)
        };

        footerLinkLabel = CreateLinkLabel(string.Empty);
        footerLinkLabel.Margin = new Padding(0, 3, 0, 0);

        footerFlow.Controls.Add(footerPromptLabel);
        footerFlow.Controls.Add(footerLinkLabel);
        AddCardRow(CreateCenteredHost(footerFlow));

        authCard.Controls.Add(authCardLayout);

        shellLayout.Controls.Add(heroPanel, 0, 0);
        shellLayout.Controls.Add(authCard, 1, 0);
        Controls.Add(shellLayout);

        LoadBrandImage(brandPictureBox);
        LoadBrandImage(heroLogoPictureBox);

        Resize += (_, _) => UpdateResponsiveLayout();
        Shown += (_, _) => UpdateResponsiveLayout();
    }

    protected void ConfigurePage(string title, string subtitle, string description)
    {
        TitleLabel.Text = title;
        SubtitleLabel.Text = subtitle;
        DescriptionLabel.Text = description;
        DescriptionLabel.Visible = !string.IsNullOrWhiteSpace(description);
    }

    protected void ConfigureHero(string badge, string title, string description, params string[] bullets)
    {
        heroBadgeLabel.Text = badge;
        heroTitleLabel.Text = title;
        heroDescriptionLabel.Text = description;

        heroBulletLayout.SuspendLayout();
        heroBulletLayout.Controls.Clear();
        heroBulletLayout.RowCount = 0;
        heroBulletLayout.RowStyles.Clear();

        foreach (var bullet in bullets)
        {
            heroBulletLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            heroBulletLayout.Controls.Add(CreateHeroBullet(bullet), 0, heroBulletLayout.RowCount++);
        }

        heroBulletLayout.ResumeLayout();
    }

    protected void ConfigurePrimaryAction(string buttonText, EventHandler onClick)
    {
        PrimaryButton.Text = buttonText;
        PrimaryButton.Click += onClick;
        AcceptButton = PrimaryButton;
    }

    protected void ConfigureFooter(string promptText, string linkText, LinkLabelLinkClickedEventHandler onClick)
    {
        footerPromptLabel.Text = promptText;
        footerPromptLabel.Visible = !string.IsNullOrWhiteSpace(promptText);
        footerLinkLabel.Text = linkText;
        footerLinkLabel.LinkClicked += onClick;
    }

    protected AuthTextField CreateField(string labelText, string placeholderText, bool isPassword = false)
    {
        return new AuthTextField(labelText, placeholderText, isPassword)
        {
            Dock = DockStyle.Top
        };
    }

    protected Label CreateHintLabel(string text)
    {
        return new Label
        {
            AutoSize = true,
            Dock = DockStyle.Top,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = AppTheme.MutedText,
            Margin = new Padding(0, -8, 0, 16),
            Text = text
        };
    }

    protected CheckBox CreateCheckBox(string text)
    {
        return new CheckBox
        {
            AutoSize = true,
            Cursor = Cursors.Hand,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = AppTheme.PrimaryText,
            Margin = new Padding(0, 2, 0, 0),
            Text = text
        };
    }

    protected LinkLabel CreateLinkLabel(string text)
    {
        return new LinkLabel
        {
            ActiveLinkColor = Color.FromArgb(192, 216, 255),
            AutoSize = true,
            Cursor = Cursors.Hand,
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point),
            LinkBehavior = LinkBehavior.HoverUnderline,
            LinkColor = Color.FromArgb(220, 232, 255),
            Margin = new Padding(0),
            Text = text,
            VisitedLinkColor = Color.FromArgb(220, 232, 255)
        };
    }

    protected Control CreateSplitRow(Control left, Control right)
    {
        var layout = new TableLayoutPanel
        {
            AutoSize = true,
            BackColor = Color.Transparent,
            ColumnCount = 2,
            Dock = DockStyle.Top,
            Margin = new Padding(0, 0, 0, 26)
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

        left.Dock = DockStyle.Left;
        right.Dock = DockStyle.Right;

        layout.Controls.Add(left, 0, 0);
        layout.Controls.Add(right, 1, 0);
        return layout;
    }

    protected void AddFormRow(Control control, int bottomSpacing = 18)
    {
        control.Margin = new Padding(0, 0, 0, bottomSpacing);
        control.Dock = DockStyle.Top;
        FormBodyLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        FormBodyLayout.Controls.Add(control, 0, FormBodyLayout.RowCount++);
    }

    protected void NavigateTo(Func<AuthFormBase> formFactory)
    {
        var nextForm = formFactory();
        nextForm.StartPosition = FormStartPosition.Manual;
        nextForm.Bounds = Bounds;
        nextForm.WindowState = WindowState;

        nextForm.FormClosed += (_, _) => Close();

        Hide();
        nextForm.Show();
    }

    protected void ShowPlaceholderMessage(string title, string message, MessageBoxIcon icon = MessageBoxIcon.Information)
    {
        MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
    }

    private void AddCardRow(Control control)
    {
        control.Dock = DockStyle.Top;
        authCardLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        authCardLayout.Controls.Add(control, 0, authCardLayout.RowCount++);
    }

    private Control CreateHeroBrandHeader()
    {
        var layout = new TableLayoutPanel
        {
            AutoSize = true,
            BackColor = Color.Transparent,
            ColumnCount = 2,
            Dock = DockStyle.Top,
            Margin = new Padding(0)
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

        var textPanel = new Panel
        {
            AutoSize = true,
            BackColor = Color.Transparent,
            Dock = DockStyle.Fill
        };

        var brandTitle = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = AppTheme.PrimaryText,
            Text = "NestG Launcher"
        };

        var brandSubtitle = new Label
        {
            AutoSize = true,
            Dock = DockStyle.Top,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = AppTheme.SecondaryText,
            Margin = new Padding(0, 4, 0, 0),
            Text = "Desktop authentication workspace"
        };

        textPanel.Controls.Add(brandSubtitle);
        textPanel.Controls.Add(brandTitle);
        brandSubtitle.Dock = DockStyle.Top;
        brandTitle.Dock = DockStyle.Top;

        layout.Controls.Add(heroLogoPictureBox, 0, 0);
        layout.Controls.Add(textPanel, 1, 0);
        return layout;
    }

    private Control CreateCardBrandHeader()
    {
        var layout = new TableLayoutPanel
        {
            AutoSize = true,
            BackColor = Color.Transparent,
            ColumnCount = 2,
            Dock = DockStyle.Top,
            Margin = new Padding(0)
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

        var labelPanel = new Panel
        {
            AutoSize = true,
            BackColor = Color.Transparent,
            Dock = DockStyle.Fill
        };

        var appNameLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = AppTheme.PrimaryText,
            Text = "NestG Launcher"
        };

        var statusLabel = new Label
        {
            AutoSize = true,
            Dock = DockStyle.Top,
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = AppTheme.SecondaryText,
            Margin = new Padding(0, 3, 0, 0),
            Text = "Secure desktop access"
        };

        labelPanel.Controls.Add(statusLabel);
        labelPanel.Controls.Add(appNameLabel);
        statusLabel.Dock = DockStyle.Top;
        appNameLabel.Dock = DockStyle.Top;

        layout.Controls.Add(brandPictureBox, 0, 0);
        layout.Controls.Add(labelPanel, 1, 0);
        return layout;
    }

    private static Control CreateCenteredHost(Control control)
    {
        var layout = new TableLayoutPanel
        {
            AutoSize = true,
            BackColor = Color.Transparent,
            ColumnCount = 3,
            Dock = DockStyle.Top,
            Margin = new Padding(0)
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layout.Controls.Add(control, 1, 0);
        return layout;
    }

    private Control CreateHeroBullet(string text)
    {
        var bulletHost = new Panel
        {
            AutoSize = true,
            BackColor = Color.Transparent,
            Dock = DockStyle.Top,
            Margin = new Padding(0, 0, 0, 12)
        };

        var accentDot = new Panel
        {
            BackColor = AppTheme.Accent,
            Location = new Point(0, 9),
            Size = new Size(8, 8)
        };

        accentDot.Paint += (_, e) =>
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(AppTheme.Accent);
            e.Graphics.FillEllipse(brush, 0, 0, accentDot.Width - 1, accentDot.Height - 1);
        };

        var bulletLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10.25F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = AppTheme.PrimaryText,
            Location = new Point(20, 0),
            MaximumSize = new Size(520, 0),
            Text = text
        };

        bulletHost.Controls.Add(accentDot);
        bulletHost.Controls.Add(bulletLabel);
        return bulletHost;
    }

    private void UpdateResponsiveLayout()
    {
        var showHero = ClientSize.Width >= 1120;

        heroPanel.Visible = showHero;
        shellLayout.ColumnStyles[0].Width = showHero ? 43F : 0F;
        shellLayout.ColumnStyles[1].Width = showHero ? 57F : 100F;
        authCardLayout.Padding = showHero ? new Padding(40, 34, 40, 34) : new Padding(28);

        var contentWidth = Math.Max(280, authCard.Width - authCardLayout.Padding.Horizontal - 20);
        DescriptionLabel.MaximumSize = new Size(contentWidth, 0);

        var heroWidth = Math.Max(280, heroPanel.Width - heroPanel.Padding.Horizontal - 16);
        heroTitleLabel.MaximumSize = new Size(heroWidth, 0);
        heroDescriptionLabel.MaximumSize = new Size(heroWidth, 0);
    }

    private void HeroPanel_Paint(object? sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        DrawGlow(
            e.Graphics,
            new Rectangle(heroPanel.Width - 250, -40, 260, 260),
            Color.FromArgb(76, 76, 130, 255));

        DrawGlow(
            e.Graphics,
            new Rectangle(-60, heroPanel.Height - 220, 240, 240),
            Color.FromArgb(52, 31, 119, 206));
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

    private static void LoadBrandImage(PictureBox pictureBox)
    {
        try
        {
            var assetPath = Path.Combine(AppContext.BaseDirectory, "Assets", "logo.png");
            if (!File.Exists(assetPath))
            {
                return;
            }

            using var image = Image.FromFile(assetPath);
            pictureBox.Image = new Bitmap(image);
        }
        catch
        {
            // Keep the forms functional even if the linked logo is missing.
        }
    }
}
