using System.Drawing.Drawing2D;

namespace UI_Desktop.Store;

internal static class StoreArtworkFactory
{
    internal static Bitmap CreateBanner(StoreGame game, Size size)
    {
        return CreateArtwork(game, size, 34F, 13F, 18F, true);
    }

    internal static Bitmap CreateCover(StoreGame game, Size size)
    {
        return CreateArtwork(game, size, 18F, 8.5F, 11F, false);
    }

    private static Bitmap CreateArtwork(StoreGame game, Size size, float titleSize, float subtitleSize, float chipSize, bool isBanner)
    {
        var width = Math.Max(120, size.Width);
        var height = Math.Max(120, size.Height);
        var bitmap = new Bitmap(width, height);

        using var graphics = Graphics.FromImage(bitmap);
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.Clear(Color.FromArgb(18, 23, 30));

        using var backgroundBrush = new LinearGradientBrush(
            new Rectangle(0, 0, width, height),
            game.PrimaryColor,
            game.SecondaryColor,
            LinearGradientMode.ForwardDiagonal);
        graphics.FillRectangle(backgroundBrush, 0, 0, width, height);

        using var overlayBrush = new SolidBrush(Color.FromArgb(70, 8, 12, 18));
        graphics.FillRectangle(overlayBrush, 0, 0, width, height);

        DrawOrbs(graphics, width, height, game);
        DrawDiagonalSlices(graphics, width, height, game);
        DrawFraming(graphics, width, height);

        using var chipFont = new Font("Segoe UI Semibold", chipSize, FontStyle.Bold, GraphicsUnit.Point);
        using var titleFont = new Font("Segoe UI Semibold", titleSize, FontStyle.Bold, GraphicsUnit.Point);
        using var subtitleFont = new Font("Segoe UI", subtitleSize, FontStyle.Regular, GraphicsUnit.Point);
        using var chipBrush = new SolidBrush(Color.FromArgb(220, 240, 248, 255));
        using var titleBrush = new SolidBrush(Color.White);
        using var subtitleBrush = new SolidBrush(Color.FromArgb(222, 230, 238));
        using var accentChipBrush = new SolidBrush(Color.FromArgb(165, game.AccentColor));
        using var outlinePen = new Pen(Color.FromArgb(42, 255, 255, 255));

        var chipBounds = new RectangleF(18, 16, Math.Min(width - 36, width * 0.28F), isBanner ? 34 : 26);
        using (var chipPath = RoundedPanel.CreateRoundedPath(Rectangle.Round(chipBounds), 14))
        {
            graphics.FillPath(accentChipBrush, chipPath);
            graphics.DrawPath(outlinePen, chipPath);
        }

        graphics.DrawString(game.PromoLabel, chipFont, chipBrush, chipBounds, new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        });

        var titleBounds = isBanner
            ? new RectangleF(24, height - (height * 0.32F), width * 0.62F, height * 0.22F)
            : new RectangleF(18, height - (height * 0.33F), width * 0.72F, height * 0.22F);
        var subtitleBounds = isBanner
            ? new RectangleF(24, titleBounds.Bottom + 8, width * 0.45F, 24)
            : new RectangleF(18, titleBounds.Bottom + 6, width * 0.58F, 18);

        using var shadowBrush = new SolidBrush(Color.FromArgb(90, 0, 0, 0));
        var shadowOffset = isBanner ? 3 : 2;
        var shadowTitle = titleBounds with { X = titleBounds.X + shadowOffset, Y = titleBounds.Y + shadowOffset };
        graphics.DrawString(game.Title, titleFont, shadowBrush, shadowTitle);
        graphics.DrawString(game.Title, titleFont, titleBrush, titleBounds);
        graphics.DrawString(game.Subtitle, subtitleFont, subtitleBrush, subtitleBounds);

        if (isBanner)
        {
            using var linePen = new Pen(Color.FromArgb(70, 255, 255, 255), 2F);
            graphics.DrawLine(linePen, width * 0.62F, 30, width - 24, height - 30);
        }

        return bitmap;
    }

    private static void DrawOrbs(Graphics graphics, int width, int height, StoreGame game)
    {
        using var warmBrush = new SolidBrush(Color.FromArgb(70, game.AccentColor));
        using var coolBrush = new SolidBrush(Color.FromArgb(50, game.SecondaryColor));
        graphics.FillEllipse(warmBrush, -width * 0.12F, height * 0.56F, width * 0.42F, height * 0.58F);
        graphics.FillEllipse(coolBrush, width * 0.62F, -height * 0.1F, width * 0.34F, height * 0.44F);
    }

    private static void DrawDiagonalSlices(Graphics graphics, int width, int height, StoreGame game)
    {
        using var brush = new SolidBrush(Color.FromArgb(38, 255, 255, 255));
        using var accentBrush = new SolidBrush(Color.FromArgb(65, game.AccentColor));

        var leftSlice = new[]
        {
            new PointF(0, height * 0.18F),
            new PointF(width * 0.22F, 0),
            new PointF(width * 0.42F, 0),
            new PointF(width * 0.06F, height * 0.46F)
        };

        var rightSlice = new[]
        {
            new PointF(width * 0.64F, height),
            new PointF(width, height * 0.58F),
            new PointF(width, height * 0.84F),
            new PointF(width * 0.82F, height)
        };

        graphics.FillPolygon(brush, leftSlice);
        graphics.FillPolygon(accentBrush, rightSlice);
    }

    private static void DrawFraming(Graphics graphics, int width, int height)
    {
        using var borderPen = new Pen(Color.FromArgb(60, 255, 255, 255), 1.2F);
        graphics.DrawRectangle(borderPen, 0, 0, width - 1, height - 1);
    }
}
