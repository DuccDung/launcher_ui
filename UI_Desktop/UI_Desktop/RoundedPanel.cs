using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace UI_Desktop;

internal class RoundedPanel : Panel
{
    private int cornerRadius = 24;
    private int borderThickness = 1;
    private Color surfaceColor = AppTheme.CardSurface;
    private Color borderColor = AppTheme.CardBorder;

    public RoundedPanel()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor |
            ControlStyles.UserPaint,
            true);

        BackColor = Color.Transparent;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int CornerRadius
    {
        get => cornerRadius;
        set
        {
            cornerRadius = Math.Max(2, value);
            UpdateRegion();
            Invalidate();
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int BorderThickness
    {
        get => borderThickness;
        set
        {
            borderThickness = Math.Max(0, value);
            Invalidate();
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color SurfaceColor
    {
        get => surfaceColor;
        set
        {
            surfaceColor = value;
            Invalidate();
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color BorderColor
    {
        get => borderColor;
        set
        {
            borderColor = value;
            Invalidate();
        }
    }

    protected override void OnResize(EventArgs eventargs)
    {
        base.OnResize(eventargs);
        UpdateRegion();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (Width <= 1 || Height <= 1)
        {
            return;
        }

        PaintParentBackground(e.Graphics);

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;

        var rect = new Rectangle(borderThickness, borderThickness, Width - (borderThickness * 2) - 1, Height - (borderThickness * 2) - 1);
        if (rect.Width <= 0 || rect.Height <= 0)
        {
            return;
        }

        using var path = CreateRoundedPath(rect, cornerRadius);
        using var brush = new SolidBrush(surfaceColor);
        e.Graphics.FillPath(brush, path);

        if (borderThickness <= 0)
        {
            return;
        }

        using var pen = new Pen(borderColor, borderThickness)
        {
            Alignment = PenAlignment.Inset,
            LineJoin = LineJoin.Round
        };
        e.Graphics.DrawPath(pen, path);
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        if (BackColor.A == 255 || Parent is null)
        {
            base.OnPaintBackground(e);
        }
    }

    private void UpdateRegion()
    {
        if (Width <= 1 || Height <= 1)
        {
            return;
        }

        using var path = CreateRoundedPath(new Rectangle(0, 0, Width - 1, Height - 1), cornerRadius);
        Region = new Region(path);
    }

    private void PaintParentBackground(Graphics graphics)
    {
        if (Parent is null)
        {
            graphics.Clear(surfaceColor);
            return;
        }

        var parentColor = Parent is RoundedPanel roundedParent
            ? roundedParent.SurfaceColor
            : Parent.BackColor;

        graphics.Clear(parentColor);
    }

    internal static GraphicsPath CreateRoundedPath(Rectangle bounds, int radius)
    {
        var path = new GraphicsPath();
        var diameter = radius * 2;

        if (diameter > bounds.Width)
        {
            diameter = bounds.Width;
        }

        if (diameter > bounds.Height)
        {
            diameter = bounds.Height;
        }

        var arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

        path.AddArc(arc, 180, 90);
        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);
        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);
        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);
        path.CloseFigure();

        return path;
    }
}
