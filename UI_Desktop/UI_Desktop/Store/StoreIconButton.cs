using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

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
    private string badgeText = string.Empty;
    private Image? glyphImage;

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
    public string BadgeText
    {
        get => badgeText;
        set
        {
            badgeText = value ?? string.Empty;
            UpdateInteractiveRegion();
            Invalidate();
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color SurfaceColor { get; set; } = Color.FromArgb(18, 24, 33);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Image? GlyphImage
    {
        get => glyphImage;
        set
        {
            glyphImage = value;
            Invalidate();
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool UseOriginalGlyphColors { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color HoverSurfaceColor { get; set; } = Color.FromArgb(26, 34, 46);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color OutlineColor { get; set; } = Color.FromArgb(35, 47, 61);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color HoverOutlineColor { get; set; } = Color.FromArgb(50, 66, 84);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color GlyphColor { get; set; } = Color.FromArgb(149, 161, 175);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color HoverGlyphColor { get; set; } = Color.FromArgb(220, 228, 236);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public float GlyphSize { get; set; } = 12.5F;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int GlyphYOffset { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public float GlyphStrokeWidth { get; set; } = 1.3F;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int CornerRadius { get; set; } = 22;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ChromeWidth { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int BadgeOffsetX { get; set; } = 10;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int BadgeOffsetY { get; set; } = -6;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Size BadgeSize { get; set; } = new Size(20, 20);

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
        UpdateInteractiveRegion();
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        pevent.Graphics.Clear(Parent?.BackColor ?? AppTheme.WindowBackground);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;

        var chromeRect = GetChromeBounds();
        using var chromePath = RoundedPanel.CreateRoundedPath(chromeRect, Math.Min(CornerRadius, Math.Min(chromeRect.Width, chromeRect.Height) / 2));
        using var backgroundBrush = new SolidBrush(isHovered ? HoverSurfaceColor : SurfaceColor);
        using var borderPen = new Pen(isHovered ? HoverOutlineColor : OutlineColor, 1F)
        {
            Alignment = PenAlignment.Inset,
            LineJoin = LineJoin.Round
        };

        e.Graphics.FillPath(backgroundBrush, chromePath);
        e.Graphics.DrawPath(borderPen, chromePath);

        var glyphColor = isHovered ? HoverGlyphColor : GlyphColor;

        if (!DrawAssetGlyph(e.Graphics, glyphColor, chromeRect))
        {
            using var glyphPen = new Pen(glyphColor, GlyphStrokeWidth)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };
            using var glyphBrush = new SolidBrush(glyphColor);
            DrawGlyph(e.Graphics, glyphPen, glyphBrush, chromeRect);
        }

        DrawBadge(e.Graphics);
    }

    private bool DrawAssetGlyph(Graphics graphics, Color glyphColor, Rectangle chromeRect)
    {
        if (GlyphImage is null)
        {
            return false;
        }

        var drawSize = Math.Max(10, (int)Math.Round(GlyphSize));
        var bounds = new Rectangle(
            chromeRect.X + ((chromeRect.Width - drawSize) / 2),
            chromeRect.Y + ((chromeRect.Height - drawSize) / 2) + GlyphYOffset,
            drawSize,
            drawSize);

        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

        if (UseOriginalGlyphColors)
        {
            graphics.DrawImage(GlyphImage, bounds);
        }
        else
        {
            using var attributes = new ImageAttributes();
            attributes.SetColorMatrix(CreateTintMatrix(glyphColor), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            graphics.DrawImage(
                GlyphImage,
                bounds,
                0,
                0,
                GlyphImage.Width,
                GlyphImage.Height,
                GraphicsUnit.Pixel,
                attributes);
        }

        return true;
    }

    private void DrawGlyph(Graphics graphics, Pen pen, Brush brush, Rectangle chromeRect)
    {
        var state = graphics.Save();

        try
        {
            var baseScale = GlyphSize / 14F;
            graphics.TranslateTransform(
                chromeRect.Left + (chromeRect.Width / 2F),
                chromeRect.Top + (chromeRect.Height / 2F) + GlyphYOffset);
            graphics.ScaleTransform(baseScale, baseScale);

            switch (IconKind)
            {
                case StoreIconKind.Notification:
                    DrawBell(graphics, pen, brush);
                    break;
                case StoreIconKind.Cart:
                    DrawCart(graphics, pen, brush);
                    break;
                default:
                    DrawInfo(graphics, pen, brush);
                    break;
            }
        }
        finally
        {
            graphics.Restore(state);
        }
    }

    private void DrawBadge(Graphics graphics)
    {
        if (string.IsNullOrWhiteSpace(BadgeText))
        {
            return;
        }

        var badgeRect = GetBadgeBounds(GetChromeBounds());
        using var badgeBrush = new SolidBrush(AppTheme.Accent);
        using var outlinePen = new Pen(Color.FromArgb(19, 25, 34), 1F);
        graphics.FillEllipse(badgeBrush, badgeRect);
        graphics.DrawEllipse(outlinePen, badgeRect);

        using var badgeFont = new Font("Segoe UI Semibold", 7.6F, FontStyle.Bold, GraphicsUnit.Point);
        TextRenderer.DrawText(
            graphics,
            BadgeText,
            badgeFont,
            badgeRect,
            Color.White,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
    }

    private Rectangle GetBadgeBounds(Rectangle chromeRect)
    {
        return new Rectangle(
            chromeRect.Right - BadgeOffsetX,
            chromeRect.Top + BadgeOffsetY,
            BadgeSize.Width,
            BadgeSize.Height);
    }

    private Rectangle GetChromeBounds()
    {
        var chromeWidth = ChromeWidth > 0 ? Math.Min(ChromeWidth, Width - 2) : Width - 3;
        chromeWidth = Math.Max(Height - 3, chromeWidth);

        return new Rectangle(1, 1, chromeWidth, Height - 3);
    }

    private void UpdateInteractiveRegion()
    {
        if (Width <= 1 || Height <= 1)
        {
            return;
        }

        var chromeRect = GetChromeBounds();
        using var path = RoundedPanel.CreateRoundedPath(
            chromeRect,
            Math.Min(CornerRadius, Math.Min(chromeRect.Width, chromeRect.Height) / 2));

        if (!string.IsNullOrWhiteSpace(BadgeText))
        {
            path.AddEllipse(GetBadgeBounds(chromeRect));
        }

        Region = new Region(path);
    }

    private static void DrawBell(Graphics graphics, Pen pen, Brush brush)
    {
        graphics.DrawLine(pen, 0F, -6.1F, 0F, -4.8F);
        graphics.DrawArc(pen, -5.1F, -4.9F, 10.2F, 8.9F, 202, 136);
        graphics.DrawLine(pen, -4.35F, -0.25F, -4.35F, 2.8F);
        graphics.DrawLine(pen, 4.35F, -0.25F, 4.35F, 2.8F);
        graphics.DrawArc(pen, -4.9F, 1.2F, 9.8F, 4.8F, 6, 168);
        graphics.DrawLine(pen, -1.85F, 5.9F, 1.85F, 5.9F);
        graphics.FillEllipse(brush, -0.95F, 6.05F, 1.9F, 1.9F);
    }

    private static void DrawCart(Graphics graphics, Pen pen, Brush brush)
    {
        graphics.DrawLine(pen, -6.0F, -4.7F, -3.8F, -4.7F);
        graphics.DrawLine(pen, -3.8F, -4.7F, -1.6F, 1.1F);
        graphics.DrawLine(pen, -1.6F, 1.1F, 5.8F, 1.1F);
        graphics.DrawLine(pen, 5.8F, 1.1F, 7.0F, -2.3F);
        graphics.DrawLine(pen, -2.0F, -1.6F, 6.5F, -1.6F);
        graphics.DrawEllipse(pen, -0.55F, 4.1F, 2.1F, 2.1F);
        graphics.DrawEllipse(pen, 3.95F, 4.1F, 2.1F, 2.1F);
    }

    private static void DrawInfo(Graphics graphics, Pen pen, Brush brush)
    {
        graphics.FillEllipse(brush, -1.1F, -5.6F, 2.2F, 2.2F);
        graphics.DrawLine(pen, 0F, -1.9F, 0F, 4.5F);
        graphics.DrawLine(pen, -1.3F, 4.6F, 1.3F, 4.6F);
    }

    private static ColorMatrix CreateTintMatrix(Color color)
    {
        var red = color.R / 255F;
        var green = color.G / 255F;
        var blue = color.B / 255F;
        var alpha = color.A / 255F;

        return new ColorMatrix(
        [
            [0F, 0F, 0F, red, 0F],
            [0F, 0F, 0F, green, 0F],
            [0F, 0F, 0F, blue, 0F],
            [0F, 0F, 0F, alpha, 0F],
            [0F, 0F, 0F, 0F, 1F]
        ]);
    }
}
