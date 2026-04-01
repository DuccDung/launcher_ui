using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace UI_Desktop.Store;

internal enum StoreIconKind
{
    Notification,
    Cart,
    Help
}

internal sealed class StoreIconButton : Button
{
    private bool isHovered;

    public StoreIconButton()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor |
            ControlStyles.UserPaint,
            true);

        BackColor = Color.Transparent;
        Cursor = Cursors.Hand;
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Margin = new Padding(0, 0, 10, 0);
        Size = new Size(42, 42);
        TabStop = false;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public StoreIconKind IconKind { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string BadgeText { get; set; } = string.Empty;

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
        Invalidate();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        if (Width <= 1 || Height <= 1)
        {
            return;
        }

        var radius = Math.Min(Width, Height) / 2;
        using var path = RoundedPanel.CreateRoundedPath(new Rectangle(0, 0, Width - 1, Height - 1), radius);
        Region = new Region(path);
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        pevent.Graphics.Clear(Parent?.BackColor ?? AppTheme.WindowBackground);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        var rect = new Rectangle(0, 0, Width - 1, Height - 1);
        using var path = RoundedPanel.CreateRoundedPath(rect, Math.Min(Width, Height) / 2);
        using var backgroundBrush = new SolidBrush(isHovered ? Color.FromArgb(28, 36, 48) : Color.FromArgb(19, 25, 34));
        using var borderPen = new Pen(Color.FromArgb(40, 55, 72));

        e.Graphics.FillPath(backgroundBrush, path);
        e.Graphics.DrawPath(borderPen, path);

        using var iconPen = new Pen(Color.FromArgb(228, 233, 240), 1.85F)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };

        switch (IconKind)
        {
            case StoreIconKind.Notification:
                DrawBell(e.Graphics, iconPen);
                break;
            case StoreIconKind.Cart:
                DrawCart(e.Graphics, iconPen);
                break;
            default:
                DrawHelp(e.Graphics);
                break;
        }

        if (string.IsNullOrWhiteSpace(BadgeText))
        {
            return;
        }

        var badgeRect = new Rectangle(Width - 17, 1, 18, 18);
        using var badgeBrush = new SolidBrush(AppTheme.Accent);
        using var badgeTextBrush = new SolidBrush(Color.White);
        e.Graphics.FillEllipse(badgeBrush, badgeRect);

        using var badgeFont = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold, GraphicsUnit.Point);
        TextRenderer.DrawText(
            e.Graphics,
            BadgeText,
            badgeFont,
            badgeRect,
            badgeTextBrush.Color,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }

    private static void DrawBell(Graphics graphics, Pen pen)
    {
        graphics.DrawArc(pen, 12.5F, 11.5F, 16.5F, 15F, 200, 140);
        graphics.DrawLine(pen, 15, 20, 15, 24);
        graphics.DrawLine(pen, 27, 20, 27, 24);
        graphics.DrawArc(pen, 16.2F, 22.3F, 9.6F, 5.8F, 0, 180);
        graphics.DrawLine(pen, 19, 29, 23, 29);
    }

    private static void DrawCart(Graphics graphics, Pen pen)
    {
        graphics.DrawLine(pen, 10.5F, 13.5F, 14.5F, 13.5F);
        graphics.DrawLine(pen, 14.5F, 13.5F, 18F, 22.5F);
        graphics.DrawLine(pen, 18F, 22.5F, 28F, 22.5F);
        graphics.DrawLine(pen, 28F, 22.5F, 30F, 17F);
        graphics.DrawLine(pen, 17F, 17.5F, 31F, 17.5F);
        graphics.DrawEllipse(pen, 18.3F, 25.7F, 3.4F, 3.4F);
        graphics.DrawEllipse(pen, 25.2F, 25.7F, 3.4F, 3.4F);
    }

    private static void DrawHelp(Graphics graphics)
    {
        using var font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold, GraphicsUnit.Point);
        TextRenderer.DrawText(
            graphics,
            "?",
            font,
            new Rectangle(0, 0, 42, 42),
            Color.FromArgb(228, 233, 240),
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
}
