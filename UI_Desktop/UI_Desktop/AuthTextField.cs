using System.ComponentModel;

namespace UI_Desktop;

internal sealed class AuthTextField : UserControl
{
    private readonly RoundedPanel inputShell;
    private readonly TextBox inputBox;

    public AuthTextField(string labelText, string placeholderText, bool isPassword = false)
    {
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.Transparent;
        Height = 84;
        Margin = new Padding(0, 0, 0, 18);

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2,
            BackColor = Color.Transparent,
            Margin = new Padding(0),
            Padding = new Padding(0)
        };
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52));

        var captionLabel = new Label
        {
            AutoSize = true,
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = AppTheme.SecondaryText,
            Margin = new Padding(0, 0, 0, 10),
            Text = labelText
        };

        inputShell = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            BorderColor = AppTheme.InputBorder,
            BorderThickness = 1,
            CornerRadius = 24,
            SurfaceColor = AppTheme.InputSurface,
            Margin = new Padding(0),
            Padding = new Padding(18, 14, 18, 14)
        };

        inputBox = new TextBox
        {
            BackColor = AppTheme.InputSurface,
            BorderStyle = BorderStyle.None,
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = AppTheme.PrimaryText,
            Margin = new Padding(0),
            PlaceholderText = placeholderText,
            UseSystemPasswordChar = isPassword
        };

        inputBox.Enter += (_, _) => UpdateVisualState(true);
        inputBox.Leave += (_, _) => UpdateVisualState(false);

        inputShell.Controls.Add(inputBox);
        layout.Controls.Add(captionLabel, 0, 0);
        layout.Controls.Add(inputShell, 0, 1);
        Controls.Add(layout);
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TextBox TextBox => inputBox;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Value
    {
        get => inputBox.Text;
        set => inputBox.Text = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool UseSystemPasswordChar
    {
        get => inputBox.UseSystemPasswordChar;
        set => inputBox.UseSystemPasswordChar = value;
    }

    private void UpdateVisualState(bool focused)
    {
        var borderColor = focused ? AppTheme.InputBorderFocus : AppTheme.InputBorder;
        var surfaceColor = focused ? Color.FromArgb(35, 44, 58) : AppTheme.InputSurface;
        inputShell.BorderColor = borderColor;
        inputShell.SurfaceColor = surfaceColor;
        inputBox.BackColor = surfaceColor;
    }
}
