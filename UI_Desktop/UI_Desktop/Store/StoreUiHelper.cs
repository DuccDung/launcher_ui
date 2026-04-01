using System.Reflection;

namespace UI_Desktop.Store;

internal static class StoreUiHelper
{
    internal static void ApplyWindowIcon(Form form)
    {
        AppIconProvider.ApplyIcon(form);
    }

    internal static void EnableDoubleBuffer(Control control)
    {
        typeof(Control)
            .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
            ?.SetValue(control, true);
    }

    internal static void LoadLogo(PictureBox pictureBox)
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
            // Keep the shell usable if the asset is missing.
        }
    }

    internal static void ConfigureSearchInput(RoundedPanel shell, Label iconLabel, TextBox textBox)
    {
        const int horizontalInset = 18;
        const int iconWidth = 20;
        const int gap = 10;

        void LayoutChildren()
        {
            var preferredHeight = textBox.PreferredHeight;
            var y = Math.Max(8, (shell.ClientSize.Height - preferredHeight) / 2);

            iconLabel.SetBounds(horizontalInset, y - 1, iconWidth, preferredHeight + 2);

            var textX = iconLabel.Right + gap;
            var textWidth = Math.Max(10, shell.ClientSize.Width - textX - horizontalInset);
            textBox.SetBounds(textX, y, textWidth, preferredHeight + 1);
        }

        void UpdateState(bool focused)
        {
            var background = focused ? Color.FromArgb(22, 29, 39) : AppTheme.CardSurface;
            shell.SurfaceColor = background;
            shell.BorderColor = focused ? AppTheme.InputBorderFocus : AppTheme.CardBorder;
            iconLabel.ForeColor = focused ? AppTheme.PrimaryText : AppTheme.SecondaryText;
            textBox.BackColor = background;
        }

        shell.SurfaceColor = AppTheme.CardSurface;
        shell.BorderColor = AppTheme.CardBorder;
        shell.BorderThickness = 1;
        shell.CornerRadius = 20;

        iconLabel.ForeColor = AppTheme.SecondaryText;
        iconLabel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
        iconLabel.TextAlign = ContentAlignment.MiddleCenter;

        textBox.Dock = DockStyle.None;
        textBox.Multiline = false;
        textBox.BackColor = AppTheme.CardSurface;
        textBox.BorderStyle = BorderStyle.None;
        textBox.ForeColor = AppTheme.PrimaryText;
        textBox.Margin = Padding.Empty;

        textBox.Enter += (_, _) => UpdateState(true);
        textBox.Leave += (_, _) => UpdateState(false);
        shell.Click += (_, _) => textBox.Focus();
        iconLabel.Click += (_, _) => textBox.Focus();
        shell.Resize += (_, _) => LayoutChildren();

        LayoutChildren();
    }
}
