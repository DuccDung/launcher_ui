using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace UI_Desktop.Store;

internal sealed class StoreNavButton : Button
{
    private bool isActive;
    private bool isHovered;

    public StoreNavButton()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor |
            ControlStyles.UserPaint,
            true);

        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        BackColor = Color.Transparent;
        Cursor = Cursors.Hand;
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
        ForeColor = AppTheme.SecondaryText;
        Margin = new Padding(0, 0, 18, 0);
        Padding = new Padding(10, 14, 10, 16);
        TabStop = false;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsActive
    {
        get => isActive;
        set
        {
            isActive = value;
            Invalidate();
        }
    }

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

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        if (Parent is not null)
        {
            pevent.Graphics.Clear(Parent.BackColor);
            return;
        }

        base.OnPaintBackground(pevent);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.Clear(Parent?.BackColor ?? AppTheme.WindowBackground);

        var foreColor = isActive
            ? AppTheme.PrimaryText
            : isHovered
                ? Color.FromArgb(209, 221, 238)
                : AppTheme.SecondaryText;

        TextRenderer.DrawText(
            e.Graphics,
            Text,
            Font,
            ClientRectangle,
            foreColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

        if (!isActive)
        {
            return;
        }

        using var brush = new SolidBrush(Color.FromArgb(38, 214, 196));
        e.Graphics.FillRectangle(brush, 12, Height - 4, Math.Max(18, Width - 24), 3);
    }
}
