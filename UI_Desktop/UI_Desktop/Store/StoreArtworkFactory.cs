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
        var width = Math.Max(260, size.Width);
        var height = Math.Max(220, size.Height);
        var bitmap = new Bitmap(width, height);

        using var graphics = Graphics.FromImage(bitmap);
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        var bounds = new Rectangle(0, 0, width, height);
        graphics.Clear(Color.FromArgb(10, 14, 20));

        using var baseBrush = new LinearGradientBrush(bounds, Color.Black, Color.Black, 0F);
        baseBrush.InterpolationColors = new ColorBlend
        {
            Positions = [0F, 0.38F, 0.74F, 1F],
            Colors =
            [
                Darken(Blend(game.PrimaryColor, game.AccentColor, 0.14F), 0.42F),
                Blend(game.PrimaryColor, game.SecondaryColor, 0.24F),
                Blend(game.SecondaryColor, game.AccentColor, 0.2F),
                Darken(game.SecondaryColor, 0.4F)
            ]
        };
        graphics.FillRectangle(baseBrush, bounds);

        using var atmosphereBrush = new LinearGradientBrush(
            new PointF(0, 0),
            new PointF(0, height),
            Color.FromArgb(26, 255, 255, 255),
            Color.FromArgb(132, 5, 8, 14));
        graphics.FillRectangle(atmosphereBrush, bounds);

        DrawGlow(
            graphics,
            new RectangleF(-width * 0.08F, height * 0.54F, width * 0.34F, height * 0.44F),
            Blend(game.PrimaryColor, game.AccentColor, 0.35F),
            88);
        DrawGlow(
            graphics,
            new RectangleF(width * 0.58F, -height * 0.16F, width * 0.28F, height * 0.34F),
            Blend(game.SecondaryColor, Color.White, 0.1F),
            74);

        var posterWidth = Math.Max(220, (int)(width * 0.44F));
        var posterBounds = new Rectangle(0, 0, posterWidth, height);
        var mosaicBounds = new Rectangle(posterWidth, 0, width - posterWidth, height);

        DrawFeaturedPoster(graphics, posterBounds, game);
        DrawFeaturedMosaic(graphics, mosaicBounds, game);
        DrawFeaturedEyebrow(graphics, width, game);
        DrawFraming(graphics, width, height);

        using var dividerPen = new Pen(Color.FromArgb(82, 255, 255, 255), 1.1F);
        graphics.DrawLine(dividerPen, posterBounds.Right - 1, 0, posterBounds.Right - 1, height);

        return bitmap;
    }

    private static void DrawFeaturedPoster(Graphics graphics, Rectangle bounds, StoreGame game)
    {
        using var posterBrush = new LinearGradientBrush(
            bounds,
            Blend(game.PrimaryColor, Color.White, 0.08F),
            Darken(game.PrimaryColor, 0.16F),
            LinearGradientMode.Vertical);
        graphics.FillRectangle(posterBrush, bounds);

        using var softOverlay = new LinearGradientBrush(
            new Point(bounds.Left, bounds.Top),
            new Point(bounds.Right, bounds.Bottom),
            Color.FromArgb(30, 255, 255, 255),
            Color.FromArgb(110, 9, 12, 18));
        graphics.FillRectangle(softOverlay, bounds);

        DrawGlow(
            graphics,
            new RectangleF(bounds.X - (bounds.Width * 0.08F), bounds.Y + (bounds.Height * 0.56F), bounds.Width * 0.54F, bounds.Height * 0.34F),
            Blend(game.PrimaryColor, game.AccentColor, 0.42F),
            96);
        DrawGlow(
            graphics,
            new RectangleF(bounds.X + (bounds.Width * 0.28F), bounds.Y + (bounds.Height * 0.26F), bounds.Width * 0.42F, bounds.Height * 0.34F),
            Blend(game.AccentColor, Color.White, 0.12F),
            82);

        DrawPosterSweep(graphics, bounds, Color.FromArgb(78, 255, 255, 255));
        DrawPosterRings(graphics, bounds, game);

        using var titleShadowBrush = new SolidBrush(Color.FromArgb(120, 0, 0, 0));
        using var titleBrush = new SolidBrush(Color.White);
        using var subtitleBrush = new SolidBrush(Color.FromArgb(228, 236, 242));
        using var titleFont = new Font("Segoe UI Semibold", Math.Max(22F, Math.Min(34F, bounds.Width * 0.078F)), FontStyle.Bold, GraphicsUnit.Point);
        using var subtitleFont = new Font("Segoe UI", Math.Max(10.5F, Math.Min(13F, bounds.Width * 0.026F)), FontStyle.Regular, GraphicsUnit.Point);
        using var centeredFormat = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center,
            Trimming = StringTrimming.EllipsisWord
        };

        var titleBounds = new RectangleF(
            bounds.X + (bounds.Width * 0.11F),
            bounds.Y + (bounds.Height * 0.28F),
            bounds.Width * 0.62F,
            bounds.Height * 0.42F);
        var titleShadowBounds = titleBounds with { X = titleBounds.X + 4, Y = titleBounds.Y + 4 };
        graphics.DrawString(game.Title, titleFont, titleShadowBrush, titleShadowBounds, centeredFormat);
        graphics.DrawString(game.Title, titleFont, titleBrush, titleBounds, centeredFormat);

        var subtitleBounds = new RectangleF(
            bounds.X + 28,
            bounds.Bottom - 44,
            bounds.Width * 0.56F,
            24);
        graphics.DrawString(game.Subtitle, subtitleFont, subtitleBrush, subtitleBounds);
    }

    private static void DrawFeaturedMosaic(Graphics graphics, Rectangle bounds, StoreGame game)
    {
        var colors = new[]
        {
            Blend(game.PrimaryColor, Color.White, 0.18F),
            Blend(game.SecondaryColor, Color.White, 0.14F),
            Blend(game.AccentColor, Color.White, 0.12F),
            Darken(game.PrimaryColor, 0.06F),
            Darken(game.SecondaryColor, 0.02F),
            Blend(game.AccentColor, game.SecondaryColor, 0.45F)
        };

        var modes = new[]
        {
            LinearGradientMode.ForwardDiagonal,
            LinearGradientMode.BackwardDiagonal,
            LinearGradientMode.Vertical,
            LinearGradientMode.Horizontal,
            LinearGradientMode.ForwardDiagonal,
            LinearGradientMode.BackwardDiagonal
        };

        const int rows = 3;
        const int columns = 2;
        const int gap = 2;
        var tileWidth = (bounds.Width - (gap * (columns - 1))) / columns;
        var tileHeight = (bounds.Height - (gap * (rows - 1))) / rows;

        for (var row = 0; row < rows; row++)
        {
            for (var column = 0; column < columns; column++)
            {
                var index = (row * columns) + column;
                var tileBounds = new Rectangle(
                    bounds.X + (column * (tileWidth + gap)),
                    bounds.Y + (row * (tileHeight + gap)),
                    tileWidth,
                    tileHeight);

                using var tileBrush = new LinearGradientBrush(
                    tileBounds,
                    colors[index],
                    Blend(colors[(index + 1) % colors.Length], Color.Black, 0.18F),
                    modes[index]);
                graphics.FillRectangle(tileBrush, tileBounds);

                using var tileVignette = new LinearGradientBrush(
                    new Point(tileBounds.Left, tileBounds.Top),
                    new Point(tileBounds.Left, tileBounds.Bottom),
                    Color.FromArgb(12, 255, 255, 255),
                    Color.FromArgb(118, 7, 10, 16));
                graphics.FillRectangle(tileVignette, tileBounds);

                DrawFeaturedTileAccent(graphics, tileBounds, game, index);
            }
        }
    }

    private static void DrawFeaturedTileAccent(Graphics graphics, Rectangle bounds, StoreGame game, int index)
    {
        var accent = Blend(game.AccentColor, Color.White, 0.14F);
        var highlight = Color.FromArgb(118, 255, 255, 255);

        switch (index)
        {
            case 0:
            {
                using var slashBrush = new SolidBrush(Color.FromArgb(52, highlight));
                graphics.FillPolygon(slashBrush,
                [
                    new PointF(bounds.Left, bounds.Bottom),
                    new PointF(bounds.Left + (bounds.Width * 0.56F), bounds.Top),
                    new PointF(bounds.Left + (bounds.Width * 0.82F), bounds.Top),
                    new PointF(bounds.Left + (bounds.Width * 0.18F), bounds.Bottom)
                ]);
                DrawGlow(
                    graphics,
                    new RectangleF(bounds.Right - (bounds.Width * 0.42F), bounds.Top - 10, bounds.Width * 0.36F, bounds.Height * 0.42F),
                    accent,
                    70);
                break;
            }
            case 1:
            {
                using var starPen = new Pen(Color.FromArgb(220, Blend(accent, Color.White, 0.2F)), 2.4F)
                {
                    StartCap = LineCap.Round,
                    EndCap = LineCap.Round
                };
                var center = new PointF(bounds.Left + (bounds.Width * 0.66F), bounds.Top + (bounds.Height * 0.24F));
                graphics.DrawLine(starPen, center.X - 26, center.Y, center.X + 26, center.Y);
                graphics.DrawLine(starPen, center.X, center.Y - 26, center.X, center.Y + 26);
                graphics.DrawLine(starPen, center.X - 18, center.Y - 18, center.X + 18, center.Y + 18);
                graphics.DrawLine(starPen, center.X - 18, center.Y + 18, center.X + 18, center.Y - 18);
                break;
            }
            case 2:
            {
                using var wavePen = new Pen(Color.FromArgb(170, accent), 3.2F)
                {
                    StartCap = LineCap.Round,
                    EndCap = LineCap.Round
                };
                var path = new GraphicsPath();
                path.AddBezier(
                    bounds.Left - 10, bounds.Bottom - 12,
                    bounds.Left + (bounds.Width * 0.24F), bounds.Top + (bounds.Height * 0.28F),
                    bounds.Left + (bounds.Width * 0.56F), bounds.Bottom - 6,
                    bounds.Right + 8, bounds.Top + 10);
                graphics.DrawPath(wavePen, path);
                break;
            }
            case 3:
            {
                using var shardBrush = new SolidBrush(Color.FromArgb(80, highlight));
                graphics.FillPolygon(shardBrush,
                [
                    new PointF(bounds.Left, bounds.Top + (bounds.Height * 0.68F)),
                    new PointF(bounds.Left + (bounds.Width * 0.34F), bounds.Top),
                    new PointF(bounds.Right, bounds.Top),
                    new PointF(bounds.Right - (bounds.Width * 0.28F), bounds.Bottom)
                ]);
                break;
            }
            case 4:
            {
                using var boltPen = new Pen(Color.FromArgb(210, Blend(accent, Color.White, 0.16F)), 3.2F)
                {
                    StartCap = LineCap.Round,
                    EndCap = LineCap.Round
                };
                graphics.DrawLines(boltPen,
                [
                    new PointF(bounds.Left + (bounds.Width * 0.48F), bounds.Top + 10),
                    new PointF(bounds.Left + (bounds.Width * 0.40F), bounds.Top + (bounds.Height * 0.42F)),
                    new PointF(bounds.Left + (bounds.Width * 0.54F), bounds.Top + (bounds.Height * 0.42F)),
                    new PointF(bounds.Left + (bounds.Width * 0.34F), bounds.Bottom - 10)
                ]);
                break;
            }
            default:
            {
                using var ringPen = new Pen(Color.FromArgb(156, accent), 2F);
                using var eyeBrush = new SolidBrush(Color.FromArgb(128, highlight));
                var ringBounds = new RectangleF(
                    bounds.Left + (bounds.Width * 0.32F),
                    bounds.Top + (bounds.Height * 0.30F),
                    bounds.Width * 0.34F,
                    bounds.Height * 0.34F);
                graphics.DrawEllipse(ringPen, ringBounds);
                graphics.FillEllipse(eyeBrush, ringBounds.X + (ringBounds.Width * 0.33F), ringBounds.Y + (ringBounds.Height * 0.33F), ringBounds.Width * 0.34F, ringBounds.Height * 0.34F);
                break;
            }
        }
    }

    private static void DrawFeaturedEyebrow(Graphics graphics, int width, StoreGame game)
    {
        using var chipFont = new Font("Segoe UI Semibold", 9.6F, FontStyle.Bold, GraphicsUnit.Point);
        using var eyebrowFont = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
        using var chipFill = new SolidBrush(Color.FromArgb(116, 68, 115, 196));
        using var chipOutline = new Pen(Color.FromArgb(142, 129, 185, 255), 1F);
        using var chipTextBrush = new SolidBrush(Color.FromArgb(236, 246, 252));
        using var eyebrowBrush = new SolidBrush(Color.FromArgb(236, 240, 244));

        var chipBounds = new Rectangle(22, 18, Math.Min(96, Math.Max(82, (int)(width * 0.105F))), 32);
        using (var chipPath = RoundedPanel.CreateRoundedPath(chipBounds, 16))
        {
            graphics.FillPath(chipFill, chipPath);
            graphics.DrawPath(chipOutline, chipPath);
        }

        graphics.DrawString(
            "SALE NOW",
            chipFont,
            chipTextBrush,
            chipBounds,
            new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

        var eyebrowBounds = new RectangleF(chipBounds.Right + 14, chipBounds.Top + 3, width * 0.22F, chipBounds.Height);
        graphics.DrawString("Ưu đãi nổi bật", eyebrowFont, eyebrowBrush, eyebrowBounds);
    }

    private static void DrawPosterSweep(Graphics graphics, Rectangle bounds, Color color)
    {
        var state = graphics.Save();
        graphics.TranslateTransform(bounds.Left + (bounds.Width * 0.10F), bounds.Top + (bounds.Height * 0.08F));
        graphics.RotateTransform(-18F);

        var sweepBounds = new Rectangle(0, 0, (int)(bounds.Width * 0.78F), (int)(bounds.Height * 0.12F));
        using var sweepPath = RoundedPanel.CreateRoundedPath(sweepBounds, Math.Max(18, sweepBounds.Height / 2));
        using var sweepBrush = new LinearGradientBrush(
            new Point(0, 0),
            new Point(0, sweepBounds.Height),
            color,
            Color.FromArgb(0, color));
        graphics.FillPath(sweepBrush, sweepPath);

        graphics.Restore(state);
    }

    private static void DrawPosterRings(Graphics graphics, Rectangle bounds, StoreGame game)
    {
        using var outerPen = new Pen(Color.FromArgb(224, Blend(game.AccentColor, Color.Orange, 0.34F)), Math.Max(4.2F, bounds.Width * 0.014F))
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };
        using var innerPen = new Pen(Color.FromArgb(108, 255, 255, 255), Math.Max(1.4F, bounds.Width * 0.004F));

        var outerBounds = new RectangleF(
            bounds.Left + (bounds.Width * 0.14F),
            bounds.Top + (bounds.Height * 0.23F),
            bounds.Width * 0.42F,
            bounds.Width * 0.42F);
        var innerBounds = new RectangleF(
            outerBounds.X + (outerBounds.Width * 0.12F),
            outerBounds.Y + (outerBounds.Height * 0.12F),
            outerBounds.Width * 0.76F,
            outerBounds.Height * 0.76F);

        graphics.DrawArc(outerPen, outerBounds, 196, 284);
        graphics.DrawArc(innerPen, innerBounds, 204, 268);
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
