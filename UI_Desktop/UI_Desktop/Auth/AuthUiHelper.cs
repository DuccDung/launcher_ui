using UI_Desktop;
using System.Reflection;

namespace UI_Desktop.Auth;

internal static class AuthUiHelper
{
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
            // Keep the UI usable when the linked asset is unavailable.
        }
    }

    internal static void ApplyWindowIcon(Form form)
    {
        AppIconProvider.ApplyIcon(form);
    }

    internal static void ConfigureInput(UI_Desktop.RoundedPanel shell, TextBox textBox)
    {
        const int horizontalInset = 20;

        void LayoutTextBox()
        {
            var preferredHeight = textBox.PreferredHeight;
            var y = Math.Max(8, (shell.ClientSize.Height - preferredHeight) / 2);
            var width = Math.Max(10, shell.ClientSize.Width - (horizontalInset * 2));
            textBox.SetBounds(horizontalInset, y, width, preferredHeight + 1);
        }

        void UpdateState(bool focused)
        {
            var background = focused ? Color.FromArgb(36, 46, 61) : AppTheme.InputSurface;
            shell.SurfaceColor = background;
            shell.BorderColor = focused ? AppTheme.InputBorderFocus : AppTheme.InputBorder;
            textBox.BackColor = background;
        }

        shell.SurfaceColor = AppTheme.InputSurface;
        shell.BorderColor = AppTheme.InputBorder;
        shell.BorderThickness = 1;
        shell.CornerRadius = 24;

        textBox.Dock = DockStyle.None;
        textBox.Multiline = false;
        textBox.BackColor = AppTheme.InputSurface;
        textBox.BorderStyle = BorderStyle.None;
        textBox.ForeColor = AppTheme.PrimaryText;
        textBox.Margin = Padding.Empty;

        textBox.Enter += (_, _) => UpdateState(true);
        textBox.Leave += (_, _) => UpdateState(false);
        shell.Click += (_, _) => textBox.Focus();
        shell.Resize += (_, _) => LayoutTextBox();

        foreach (Control child in shell.Controls)
        {
            child.Click += (_, _) => textBox.Focus();
        }

        LayoutTextBox();
    }

    internal static void UpdateResponsiveLayout(Form form, TableLayoutPanel rootLayout, Control heroPanel)
    {
        var showHero = form.ClientSize.Width >= 1120;
        heroPanel.Visible = showHero;

        rootLayout.ColumnStyles[0].Width = showHero ? 43F : 0F;
        rootLayout.ColumnStyles[1].Width = showHero ? 57F : 100F;
    }

    internal static void Navigate(Form current, Form next)
    {
        next.StartPosition = FormStartPosition.Manual;
        next.Bounds = current.Bounds;
        next.WindowState = current.WindowState;
        next.FormClosed += (_, _) => current.Close();

        current.Hide();
        next.Show();
    }
}
