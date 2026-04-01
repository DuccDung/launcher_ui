namespace UI_Desktop.Store;

internal sealed class StoreGameCard : RoundedPanel
{
    private readonly StoreGame game;
    private readonly PictureBox artworkPictureBox;
    private readonly Label titleLabel;
    private readonly Label originalPriceLabel;
    private readonly Label salePriceLabel;
    private readonly Label purchaseLabel;
    private readonly Label likesLabel;
    private readonly Label dislikesLabel;
    private readonly Label promoLabel;
    private Image? coverImage;
    private bool isSelected;
    private bool isHovered;
    private Size renderedSize;

    public StoreGameCard(StoreGame game)
    {
        this.game = game;

        BackColor = Color.Transparent;
        SurfaceColor = AppTheme.CardSurface;
        BorderColor = AppTheme.CardBorder;
        BorderThickness = 1;
        CornerRadius = 20;
        Cursor = Cursors.Hand;
        Margin = new Padding(0, 0, 18, 18);
        Padding = new Padding(0);

        artworkPictureBox = new PictureBox
        {
            Dock = DockStyle.Top,
            Height = 178,
            Margin = new Padding(0),
            SizeMode = PictureBoxSizeMode.StretchImage
        };

        promoLabel = new Label
        {
            AutoSize = false,
            BackColor = Color.FromArgb(140, 17, 24, 34),
            ForeColor = Color.White,
            Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold, GraphicsUnit.Point),
            Size = new Size(84, 26),
            Location = new Point(14, 14),
            Text = game.PromoLabel,
            TextAlign = ContentAlignment.MiddleCenter
        };

        titleLabel = new Label
        {
            AutoSize = false,
            ForeColor = AppTheme.PrimaryText,
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point),
            Location = new Point(18, 194),
            Size = new Size(280, 54),
            Text = game.Title
        };

        originalPriceLabel = new Label
        {
            AutoSize = true,
            ForeColor = AppTheme.MutedText,
            Font = new Font("Segoe UI", 9F, FontStyle.Strikeout, GraphicsUnit.Point),
            Location = new Point(18, 252),
            Text = game.OriginalPrice > game.SalePrice ? game.OriginalPriceText : string.Empty,
            Visible = game.OriginalPrice > game.SalePrice
        };

        salePriceLabel = new Label
        {
            AutoSize = true,
            ForeColor = AppTheme.Accent,
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point),
            Location = new Point(18, 278),
            Text = game.SalePriceText
        };

        purchaseLabel = new Label
        {
            AutoSize = true,
            ForeColor = AppTheme.MutedText,
            Font = new Font("Segoe UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point),
            Text = game.PurchaseText
        };

        likesLabel = new Label
        {
            AutoSize = true,
            ForeColor = Color.FromArgb(171, 215, 52),
            Font = new Font("Segoe UI Semibold", 8.75F, FontStyle.Bold, GraphicsUnit.Point),
            Text = $"+ {game.Likes}"
        };

        dislikesLabel = new Label
        {
            AutoSize = true,
            ForeColor = Color.FromArgb(255, 96, 96),
            Font = new Font("Segoe UI Semibold", 8.75F, FontStyle.Bold, GraphicsUnit.Point),
            Text = $"- {game.Dislikes}"
        };

        Controls.Add(dislikesLabel);
        Controls.Add(likesLabel);
        Controls.Add(purchaseLabel);
        Controls.Add(salePriceLabel);
        Controls.Add(originalPriceLabel);
        Controls.Add(titleLabel);
        Controls.Add(promoLabel);
        Controls.Add(artworkPictureBox);

        AttachSelection(this);
        MouseEnter += (_, _) => UpdateHover(true);
        MouseLeave += (_, _) => UpdateHover(false);
    }

    public StoreGame Game => game;

    public event EventHandler? Selected;

    public void SetSelected(bool selected)
    {
        isSelected = selected;
        ApplyChrome();
    }

    public void SetCardWidth(int width)
    {
        Width = Math.Max(256, width);
        var artworkHeight = Math.Max(146, (int)(Width * 0.56F));
        artworkPictureBox.Height = artworkHeight;
        titleLabel.Size = new Size(Width - 36, 56);
        titleLabel.Location = new Point(18, artworkPictureBox.Bottom + 14);
        originalPriceLabel.Location = new Point(18, titleLabel.Bottom + 8);
        salePriceLabel.Location = new Point(18, originalPriceLabel.Visible ? originalPriceLabel.Bottom + 4 : titleLabel.Bottom + 12);
        likesLabel.Location = new Point(18, salePriceLabel.Bottom + 18);
        dislikesLabel.Location = new Point(likesLabel.Right + 14, salePriceLabel.Bottom + 18);
        purchaseLabel.Location = new Point(Width - purchaseLabel.Width - 18, salePriceLabel.Bottom + 16);
        Height = likesLabel.Bottom + 24;

        UpdateArtwork();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            coverImage?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void UpdateArtwork()
    {
        if (artworkPictureBox.Width <= 0 || artworkPictureBox.Height <= 0)
        {
            return;
        }

        var requestedSize = artworkPictureBox.Size;
        if (requestedSize == renderedSize && coverImage is not null)
        {
            return;
        }

        coverImage?.Dispose();
        coverImage = StoreArtworkFactory.CreateCover(game, requestedSize);
        artworkPictureBox.Image = coverImage;
        renderedSize = requestedSize;
    }

    private void AttachSelection(Control control)
    {
        control.Click += (_, _) => Selected?.Invoke(this, EventArgs.Empty);

        foreach (Control child in control.Controls)
        {
            AttachSelection(child);
        }
    }

    private void UpdateHover(bool hovered)
    {
        isHovered = hovered;
        ApplyChrome();
    }

    private void ApplyChrome()
    {
        BorderColor = isSelected
            ? AppTheme.Accent
            : isHovered
                ? Color.FromArgb(86, 118, 180)
                : AppTheme.CardBorder;
        Invalidate();
    }
}
