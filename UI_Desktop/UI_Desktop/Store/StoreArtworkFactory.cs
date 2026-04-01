using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace UI_Desktop.Store;

internal static class StoreArtworkFactory
{
    internal static Bitmap CreateBanner(StoreGame game, Size size)
    {
        return CreateBannerArtwork(game, size);
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

    private static Bitmap CreateBannerArtwork(StoreGame game, Size size)
    {
        var width = Math.Max(220, size.Width);
        var height = Math.Max(180, size.Height);
        var bitmap = new Bitmap(width, height);

        using var graphics = Graphics.FromImage(bitmap);
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        var bounds = new Rectangle(0, 0, width, height);
        graphics.Clear(Color.FromArgb(10, 14, 20));

        using var baseBrush = new LinearGradientBrush(bounds, Color.Black, Color.Black, 18F);
        baseBrush.InterpolationColors = new ColorBlend
        {
            Positions = [0F, 0.26F, 0.68F, 1F],
            Colors =
            [
                Darken(game.PrimaryColor, 0.52F),
                Blend(game.PrimaryColor, game.SecondaryColor, 0.28F),
                Blend(game.PrimaryColor, game.SecondaryColor, 0.64F),
                Darken(game.SecondaryColor, 0.42F)
            ]
        };
        graphics.FillRectangle(baseBrush, bounds);

        using var atmosphereBrush = new LinearGradientBrush(
            new PointF(0, 0),
            new PointF(0, height),
            Color.FromArgb(34, 255, 255, 255),
            Color.FromArgb(120, 6, 10, 17));
        graphics.FillRectangle(atmosphereBrush, bounds);

        DrawGlow(
            graphics,
            new RectangleF(-width * 0.08F, height * 0.48F, width * 0.58F, height * 0.68F),
            Blend(game.PrimaryColor, game.AccentColor, 0.42F),
            122);
        DrawGlow(
            graphics,
            new RectangleF(width * 0.44F, -height * 0.18F, width * 0.44F, height * 0.54F),
            Blend(game.SecondaryColor, Color.White, 0.16F),
            92);
        DrawGlow(
            graphics,
            new RectangleF(width * 0.62F, height * 0.22F, width * 0.24F, height * 0.44F),
            Blend(game.AccentColor, Color.White, 0.22F),
            68);

        DrawLightSweep(graphics, width, height);
        DrawBottomVignette(graphics, width, height);
        DrawFraming(graphics, width, height);

        using var chipFont = new Font("Segoe UI Semibold", 9.8F, FontStyle.Bold, GraphicsUnit.Point);
        using var eyebrowFont = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
        using var titleFont = new Font("Segoe UI Semibold", 31F, FontStyle.Bold, GraphicsUnit.Point);
        using var subtitleFont = new Font("Segoe UI", 11.5F, FontStyle.Regular, GraphicsUnit.Point);
        using var chipTextBrush = new SolidBrush(Color.FromArgb(236, 246, 252));
        using var eyebrowBrush = new SolidBrush(Color.FromArgb(238, 242, 247));
        using var titleBrush = new SolidBrush(Color.White);
        using var subtitleBrush = new SolidBrush(Color.FromArgb(222, 230, 238));
        using var titleShadowBrush = new SolidBrush(Color.FromArgb(88, 0, 0, 0));
        using var chipFill = new SolidBrush(Color.FromArgb(160, Blend(game.AccentColor, Color.FromArgb(34, 56, 84), 0.38F)));
        using var chipOutline = new Pen(Color.FromArgb(126, 168, 209, 255), 1.1F);

        var chipBounds = new Rectangle(22, 20, Math.Min(96, Math.Max(82, (int)(width * 0.11F))), 32);
        using (var chipPath = RoundedPanel.CreateRoundedPath(chipBounds, 16))
        {
            graphics.FillPath(chipFill, chipPath);
            graphics.DrawPath(chipOutline, chipPath);
        }

        graphics.DrawString(
            game.PromoLabel,
            chipFont,
            chipTextBrush,
            chipBounds,
            new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

        var eyebrowBounds = new RectangleF(chipBounds.Right + 14, chipBounds.Top + 3, width * 0.22F, chipBounds.Height);
        graphics.DrawString("Uu dai noi bat", eyebrowFont, eyebrowBrush, eyebrowBounds);

        var titleBounds = new RectangleF(28, height * 0.53F, width * 0.56F, height * 0.24F);
        var subtitleBounds = new RectangleF(30, height * 0.82F, width * 0.40F, 28);
        var titleShadowBounds = titleBounds with { X = titleBounds.X + 3, Y = titleBounds.Y + 3 };

        using var leftAlignedFormat = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Near,
            Trimming = StringTrimming.EllipsisWord
        };

        graphics.DrawString(game.Title, titleFont, titleShadowBrush, titleShadowBounds, leftAlignedFormat);
        graphics.DrawString(game.Title, titleFont, titleBrush, titleBounds, leftAlignedFormat);
        graphics.DrawString(game.Subtitle, subtitleFont, subtitleBrush, subtitleBounds, leftAlignedFormat);

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

    private static void DrawGlow(Graphics graphics, RectangleF bounds, Color color, int alpha)
    {
        using var path = new GraphicsPath();
        path.AddEllipse(bounds);
        using var brush = new PathGradientBrush(path)
        {
            CenterColor = Color.FromArgb(alpha, color),
            SurroundColors = [Color.FromArgb(0, color)]
        };
        graphics.FillPath(brush, path);
    }

    private static void DrawLightSweep(Graphics graphics, int width, int height)
    {
        var state = graphics.Save();
        graphics.TranslateTransform(width * 0.16F, height * 0.16F);
        graphics.RotateTransform(-20F);

        var sweepBounds = new Rectangle(0, 0, (int)(width * 0.72F), (int)(height * 0.17F));
        using (var sweepPath = RoundedPanel.CreateRoundedPath(sweepBounds, Math.Max(18, sweepBounds.Height / 2)))
        using (var sweepBrush = new LinearGradientBrush(
            new Point(0, 0),
            new Point(0, sweepBounds.Height),
            Color.FromArgb(54, 255, 255, 255),
            Color.FromArgb(0, 255, 255, 255)))
        {
            graphics.FillPath(sweepBrush, sweepPath);
        }

        graphics.Restore(state);
    }

    private static void DrawBottomVignette(Graphics graphics, int width, int height)
    {
        using var bottomBrush = new LinearGradientBrush(
            new Point(0, (int)(height * 0.58F)),
            new Point(0, height),
            Color.FromArgb(0, 6, 9, 14),
            Color.FromArgb(148, 5, 8, 14));
        graphics.FillRectangle(bottomBrush, 0, height * 0.56F, width, height * 0.44F);
    }

    private static Color Darken(Color color, float amount)
    {
        amount = Math.Clamp(amount, 0F, 1F);
        return Color.FromArgb(
            color.A,
            (int)(color.R * (1F - amount)),
            (int)(color.G * (1F - amount)),
            (int)(color.B * (1F - amount)));
    }

    private static Color Blend(Color from, Color to, float amount)
    {
        amount = Math.Clamp(amount, 0F, 1F);
        var inverse = 1F - amount;
        return Color.FromArgb(
            (int)((from.R * inverse) + (to.R * amount)),
            (int)((from.G * inverse) + (to.G * amount)),
            (int)((from.B * inverse) + (to.B * amount)));
    }
}
