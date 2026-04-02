namespace UI_Desktop.Store;

internal partial class StoreForm : Form
{
    private const int FeaturedDesktopMaxWidth = 1320;
    private const int FeaturedDesktopMinWidth = 980;

    private readonly StorePageData pageData;
    private readonly List<StoreNavButton> navButtons = [];
    private readonly List<StoreGameCard> visibleCards = [];
    private Image? featuredArtwork;
    private Image? notificationGlyphImage;
    private Image? cartGlyphImage;
    private Image? infoGlyphImage;
    private StoreGame? selectedGame;
    private bool isBindingCategory;

    public StoreForm()
    {
        pageData = StoreMockData.Create();
        InitializeComponent();
        ConfigureView();
        BindEvents();
        LoadPageData();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        featuredArtwork?.Dispose();
        notificationGlyphImage?.Dispose();
        cartGlyphImage?.Dispose();
        infoGlyphImage?.Dispose();
        base.OnFormClosed(e);
    }

    private void ConfigureView()
    {
        StoreUiHelper.ApplyWindowIcon(this);
        StoreUiHelper.EnableDoubleBuffer(scrollContentPanel);
        StoreUiHelper.EnableDoubleBuffer(contentLayout);
        StoreUiHelper.EnableDoubleBuffer(featuredPanel);
        StoreUiHelper.EnableDoubleBuffer(featuredSpecsLayout);
        StoreUiHelper.EnableDoubleBuffer(catalogFlowPanel);

        StoreUiHelper.LoadLogo(headerLogoPictureBox);
        StoreUiHelper.ConfigureSearchInput(searchPanel, searchIconLabel, searchTextBox);

        featuredPanel.Dock = DockStyle.None;
        featuredPanel.Anchor = AnchorStyles.Top;
        featuredPanel.SurfaceColor = Color.FromArgb(14, 19, 28);
        featuredPanel.BorderColor = Color.FromArgb(49, 70, 98);
        featuredPanel.BorderThickness = 1;
        featuredPanel.CornerRadius = 28;
        featuredInfoPanel.BackColor = Color.FromArgb(14, 20, 29);
        salePriceCaptionLabel.Text = "Giá sau sale";
        saleLimitCaptionLabel.Text = "Hạn sale";

        notificationGlyphImage = StoreUiHelper.LoadAssetImage("icons8-bell-48.png");
        cartGlyphImage = StoreUiHelper.LoadAssetImage("online-shopping.png");
        infoGlyphImage = StoreUiHelper.LoadAssetImage("info.png");

        notificationButton.GlyphImage = notificationGlyphImage;
        cartButton.GlyphImage = cartGlyphImage;
        helpButton.GlyphImage = infoGlyphImage;
    }

    private void BindEvents()
    {
        notificationButton.Click += (_, _) => MessageBox.Show(
            "Khu vực thông báo đang ở bản xem trước.",
            "NestG Launcher",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        cartButton.Click += (_, _) => MessageBox.Show(
            "Giỏ hàng mẫu hiện chưa kết nối dữ liệu thật.",
            "NestG Launcher",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        helpButton.Click += (_, _) => MessageBox.Show(
            "Đây là bản dựng demo của giao diện cửa hàng.",
            "NestG Launcher",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        cartBadgePanel.Click += (_, _) => cartButton.PerformClick();
        cartBadgeLabel.Click += (_, _) => cartButton.PerformClick();

        Resize += (_, _) => UpdateResponsiveLayout();
        scrollContentPanel.SizeChanged += (_, _) => UpdateResponsiveLayout();
        featuredPictureBox.SizeChanged += (_, _) => RenderFeaturedArtwork();
        featuredSpecsLayout.Paint += FeaturedSpecsLayout_Paint;
        categoryComboBox.SelectedIndexChanged += (_, _) =>
        {
            if (!isBindingCategory)
            {
                RenderCatalog();
            }
        };
        searchTextBox.TextChanged += (_, _) => RenderCatalog();
    }

    private void LoadPageData()
    {
        launcherNameLabel.Text = pageData.LauncherName;
        versionLabel.Text = pageData.VersionText;
        accountNameLabel.Text = pageData.UserName;
        balanceLabel.Text = pageData.BalanceText;
        cartBadgeLabel.Text = "0";

        BuildNavigation();

        isBindingCategory = true;
        categoryComboBox.Items.Clear();
        foreach (var category in pageData.Categories)
        {
            categoryComboBox.Items.Add(category);
        }

        if (categoryComboBox.Items.Count > 0)
        {
            categoryComboBox.SelectedIndex = 0;
        }

        isBindingCategory = false;

        SelectFeaturedGame(pageData.FeaturedGame);
        RenderCatalog();
        UpdateResponsiveLayout();
    }

    private void BuildNavigation()
    {
        navFlowPanel.SuspendLayout();
        navFlowPanel.Controls.Clear();
        navButtons.Clear();

        for (var index = 0; index < pageData.NavigationItems.Count; index++)
        {
            var navButton = new StoreNavButton
            {
                Text = pageData.NavigationItems[index],
                IsActive = index == 0
            };

            navButton.Click += (_, _) => ActivateNavigation(navButton);
            navButtons.Add(navButton);
            navFlowPanel.Controls.Add(navButton);
        }

        navFlowPanel.ResumeLayout();
    }

    private void ActivateNavigation(StoreNavButton selectedButton)
    {
        foreach (var button in navButtons)
        {
            button.IsActive = ReferenceEquals(button, selectedButton);
        }
    }

    private void RenderCatalog()
    {
        var filteredGames = GetFilteredGames().ToList();
        emptyStateLabel.Visible = filteredGames.Count == 0;
        resultCountLabel.Text = filteredGames.Count == 0
            ? "Không tìm thấy sản phẩm"
            : $"Hiển thị {filteredGames.Count} sản phẩm";

        catalogHintLabel.Text = filteredGames.Count == 0
            ? "Điều chỉnh từ khóa hoặc bộ lọc"
            : $"{filteredGames.Count} trò chơi đang hiển thị";

        if (filteredGames.Count > 0 && (selectedGame is null || !filteredGames.Contains(selectedGame)))
        {
            SelectFeaturedGame(filteredGames[0]);
        }

        ClearVisibleCards();

        var availableWidth = GetScrollableContentWidth();
        if (filteredGames.Count == 0)
        {
            UpdateCatalogLayout(availableWidth);
            return;
        }

        catalogFlowPanel.SuspendLayout();
        foreach (var game in filteredGames)
        {
            var card = new StoreGameCard(game);
            card.Selected += GameCard_Selected;
            card.SetSelected(selectedGame == game);
            visibleCards.Add(card);
            catalogFlowPanel.Controls.Add(card);
        }

        catalogFlowPanel.ResumeLayout();
        UpdateCatalogLayout(availableWidth);
    }

    private IEnumerable<StoreGame> GetFilteredGames()
    {
        var category = categoryComboBox.SelectedItem?.ToString();
        var query = searchTextBox.Text.Trim();

        IEnumerable<StoreGame> games = pageData.Games;

        if (!string.IsNullOrWhiteSpace(category) && !string.Equals(category, "Tất cả", StringComparison.CurrentCultureIgnoreCase))
        {
            games = games.Where(game => string.Equals(game.Category, category, StringComparison.CurrentCultureIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(query))
        {
            games = games.Where(game =>
                game.Title.Contains(query, StringComparison.CurrentCultureIgnoreCase) ||
                game.Subtitle.Contains(query, StringComparison.CurrentCultureIgnoreCase) ||
                game.Category.Contains(query, StringComparison.CurrentCultureIgnoreCase) ||
                game.Genres.Any(genre => genre.Contains(query, StringComparison.CurrentCultureIgnoreCase)));
        }

        return games;
    }

    private void GameCard_Selected(object? sender, EventArgs e)
    {
        if (sender is StoreGameCard card)
        {
            SelectFeaturedGame(card.Game);
        }
    }

    private void SelectFeaturedGame(StoreGame game)
    {
        selectedGame = game;

        featuredPromoLabel.Text = game.PromoLabel;
        featuredPromoLabel.BackColor = game.DiscountPercent > 0
            ? Color.FromArgb(30, 82, 67)
            : Color.FromArgb(29, 55, 103);
        featuredTitleLabel.Text = game.Title;
        featuredSubtitleLabel.Text = game.Subtitle;
        originalPriceValueLabel.Text = game.OriginalPriceText;
        originalPriceValueLabel.ForeColor = game.DiscountPercent > 0
            ? AppTheme.SecondaryText
            : AppTheme.PrimaryText;
        discountValueLabel.Text = game.DiscountPercent > 0 ? $"-{game.DiscountPercent}%" : "0%";
        discountValueLabel.ForeColor = game.DiscountPercent > 0 ? Color.FromArgb(73, 209, 164) : AppTheme.SecondaryText;
        salePriceValueLabel.Text = game.SalePriceText;
        saleLimitValueLabel.Text = game.DiscountPercent > 0 ? "Không giới hạn" : "Giá hiện hành";
        genresValueLabel.Text = game.GenresText;

        RenderFeaturedArtwork();
        UpdateSelectionState();
    }

    private void RenderFeaturedArtwork()
    {
        if (selectedGame is null || featuredPictureBox.Width <= 8 || featuredPictureBox.Height <= 8)
        {
            return;
        }

        featuredArtwork?.Dispose();
        featuredArtwork = StoreArtworkFactory.CreateBanner(selectedGame, featuredPictureBox.Size);
        featuredPictureBox.Image = featuredArtwork;
    }

    private void UpdateSelectionState()
    {
        foreach (var card in visibleCards)
        {
            card.SetSelected(card.Game == selectedGame);
        }
    }

    private void ClearVisibleCards()
    {
        foreach (var card in visibleCards)
        {
            card.Selected -= GameCard_Selected;
            catalogFlowPanel.Controls.Remove(card);
            card.Dispose();
        }

        visibleCards.Clear();
    }

    private void UpdateResponsiveLayout()
    {
        toolbarLayout.ColumnStyles[0].Width = ClientSize.Width < 1220 ? 148F : 170F;
        resultCountLabel.Visible = ClientSize.Width >= 1120;

        for (var index = 0; index < navButtons.Count; index++)
        {
            navButtons[index].Visible = ShouldShowNavigation(index);
        }

        var availableWidth = GetScrollableContentWidth();
        ConfigureFeaturedLayout(availableWidth < 1180, availableWidth);
        UpdateCatalogLayout(availableWidth);
    }

    private bool ShouldShowNavigation(int index)
    {
        if (ClientSize.Width >= 1420)
        {
            return true;
        }

        if (ClientSize.Width >= 1260)
        {
            return index < 4;
        }

        if (ClientSize.Width >= 1120)
        {
            return index < 3;
        }

        return index < 2;
    }

    private void ConfigureFeaturedLayout(bool stack, int availableWidth)
    {
        featuredPanel.Width = GetFeaturedCardWidth(availableWidth, stack);
        featuredPanel.Height = stack ? 560 : 438;
        featuredPanel.Padding = stack ? new Padding(12) : new Padding(16);

        featuredLayout.SuspendLayout();
        featuredLayout.Controls.Clear();
        featuredLayout.ColumnStyles.Clear();
        featuredLayout.RowStyles.Clear();

        if (stack)
        {
            featuredLayout.ColumnCount = 1;
            featuredLayout.RowCount = 2;
            featuredLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            featuredLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, Math.Max(238, Math.Min(326, (int)(featuredPanel.Width * 0.42F)))));
            featuredLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            featuredPictureBox.Margin = new Padding(0, 0, 0, 16);
            featuredInfoPanel.Margin = new Padding(0);
            featuredInfoPanel.Padding = new Padding(18, 18, 18, 16);
            featuredLayout.Controls.Add(featuredPictureBox, 0, 0);
            featuredLayout.Controls.Add(featuredInfoPanel, 0, 1);
        }
        else
        {
            featuredLayout.ColumnCount = 2;
            featuredLayout.RowCount = 1;
            featuredLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.8F));
            featuredLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.2F));
            featuredLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            featuredPictureBox.Margin = new Padding(0);
            featuredInfoPanel.Margin = new Padding(0);
            featuredInfoPanel.Padding = new Padding(22, 18, 22, 16);
            featuredLayout.Controls.Add(featuredPictureBox, 0, 0);
            featuredLayout.Controls.Add(featuredInfoPanel, 1, 0);
        }

        featuredLayout.ResumeLayout();
        RenderFeaturedArtwork();
    }

    private void UpdateCatalogLayout(int availableWidth)
    {
        catalogFlowPanel.Width = availableWidth;

        if (visibleCards.Count == 0)
        {
            return;
        }

        var columns = availableWidth >= 1360
            ? 4
            : availableWidth >= 1020
                ? 3
                : availableWidth >= 700
                    ? 2
                    : 1;

        const int gap = 18;
        var cardWidth = (availableWidth - (gap * (columns - 1))) / columns;

        foreach (var card in visibleCards)
        {
            card.SetCardWidth(cardWidth);
        }
    }

    private int GetScrollableContentWidth()
    {
        var availableWidth = scrollContentPanel.ClientSize.Width - scrollContentPanel.Padding.Horizontal - 4;
        if (scrollContentPanel.VerticalScroll.Visible)
        {
            availableWidth -= SystemInformation.VerticalScrollBarWidth;
        }

        return Math.Max(320, availableWidth);
    }

    private static int GetFeaturedCardWidth(int availableWidth, bool stack)
    {
        if (stack)
        {
            return availableWidth;
        }

        return Math.Min(FeaturedDesktopMaxWidth, Math.Max(FeaturedDesktopMinWidth, availableWidth - 160));
    }

    private void FeaturedSpecsLayout_Paint(object? sender, PaintEventArgs e)
    {
        if (sender is not TableLayoutPanel layout)
        {
            return;
        }

        var rowHeights = layout.GetRowHeights();
        if (rowHeights.Length < 2)
        {
            return;
        }

        using var pen = new Pen(Color.FromArgb(34, 50, 69), 1F);
        var y = 0;
        for (var index = 0; index < Math.Min(4, rowHeights.Length - 1); index++)
        {
            y += rowHeights[index];
            e.Graphics.DrawLine(pen, 0, y - 1, layout.Width - 1, y - 1);
        }
    }

    private void addGameButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show(
            "Danh sách hiện đang dùng dữ liệu demo để dựng giao diện cửa hàng. Bạn có thể thay bằng dữ liệu API sau này.",
            "NestG Launcher",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void notificationButton_Click(object sender, EventArgs e)
    {
    }
}
