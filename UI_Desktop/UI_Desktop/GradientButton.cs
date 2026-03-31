using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace UI_Desktop;

internal sealed class GradientButton : Button
{
    private bool isHovered;
    private bool isPressed;

    public GradientButton()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.UserPaint,
            true);

        Cursor = Cursors.Hand;
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
        ForeColor = Color.White;
        Height = 56;
        MinimumSize = new Size(0, 56);
        TabStop = true;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color StartColor { get; set; } = Color.FromArgb(86, 140, 255);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color EndColor { get; set; } = Color.FromArgb(50, 103, 242);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int CornerRadius { get; set; } = 26;

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        isHovered = true;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        isHovered = false;
        isPressed = false;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        base.OnMouseDown(mevent);
        isPressed = true;
        Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs mevent)
    {
        base.OnMouseUp(mevent);
        isPressed = false;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        var rect = new Rectangle(0, 0, Width - 1, Height - 1);

        using var path = RoundedPanel.CreateRoundedPath(rect, CornerRadius);
        using var brush = CreateBackgroundBrush(rect);
        e.Graphics.FillPath(brush, path);

        using var borderPen = new Pen(Color.FromArgb(70, 255, 255, 255));
        e.Graphics.DrawPath(borderPen, path);

        TextRenderer.DrawText(
            e.Graphics,
            Text,
            Font,
            rect,
            Enabled ? ForeColor : AppTheme.SecondaryText,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
    }

    private Brush CreateBackgroundBrush(Rectangle rect)
    {
        if (!Enabled)
        {
            return new SolidBrush(Color.FromArgb(63, 76, 95));
        }

        var start = StartColor;
        var end = EndColor;

        if (isHovered)
        {
            start = Lighten(start, 0.08F);
            end = Lighten(end, 0.08F);
        }

        if (isPressed)
        {
            start = Darken(start, 0.08F);
            end = Darken(end, 0.08F);
        }

        return new LinearGradientBrush(rect, start, end, LinearGradientMode.Vertical);
    }

    private static Color Lighten(Color color, float factor)
    {
        var r = color.R + (255 - color.R) * factor;
        var g = color.G + (255 - color.G) * factor;
        var b = color.B + (255 - color.B) * factor;
        return Color.FromArgb(color.A, (int)r, (int)g, (int)b);
    }

    private static Color Darken(Color color, float factor)
    {
        var r = color.R * (1 - factor);
        var g = color.G * (1 - factor);
        var b = color.B * (1 - factor);
        return Color.FromArgb(color.A, (int)r, (int)g, (int)b);
    }
}
