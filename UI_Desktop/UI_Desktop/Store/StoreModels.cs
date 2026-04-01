namespace UI_Desktop.Store;

internal sealed class StorePageData
{
    public required string LauncherName { get; init; }
    public required string VersionText { get; init; }
    public required string UserName { get; init; }
    public required string BalanceText { get; init; }
    public required IReadOnlyList<string> NavigationItems { get; init; }
    public required IReadOnlyList<string> Categories { get; init; }
    public required StoreGame FeaturedGame { get; init; }
    public required IReadOnlyList<StoreGame> Games { get; init; }
}

internal sealed class StoreGame
{
    public required string Title { get; init; }
    public required string Subtitle { get; init; }
    public required string Category { get; init; }
    public required IReadOnlyList<string> Genres { get; init; }
    public required decimal OriginalPrice { get; init; }
    public required decimal SalePrice { get; init; }
    public required int Likes { get; init; }
    public required int Dislikes { get; init; }
    public required int PurchaseCount { get; init; }
    public required string PromoLabel { get; init; }
    public required Color PrimaryColor { get; init; }
    public required Color SecondaryColor { get; init; }
    public required Color AccentColor { get; init; }

    public int DiscountPercent =>
        OriginalPrice <= 0
            ? 0
            : (int)Math.Round((1 - (SalePrice / OriginalPrice)) * 100M, MidpointRounding.AwayFromZero);

    public string OriginalPriceText => FormatPrice(OriginalPrice);

    public string SalePriceText => FormatPrice(SalePrice);

    public string GenresText => string.Join(", ", Genres);

    public string PurchaseText => $"{PurchaseCount} lượt mua";

    private static string FormatPrice(decimal value)
    {
        return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:N0} đ", value)
            .Replace(",", ".");
    }
}
