namespace UI_Desktop.Store;

internal partial class StoreForm : Form
{
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
        StoreUiHelper.EnableDoubleBuffer(catalogFlowPanel);

        StoreUiHelper.LoadLogo(headerLogoPictureBox);
        StoreUiHelper.ConfigureSearchInput(searchPanel, searchIconLabel, searchTextBox);

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

        if (filteredGames.Count == 0)
        {
            UpdateCatalogLayout();
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
        UpdateCatalogLayout();
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
        featuredSubtitleLabel.Text = $"{game.Subtitle}. Xem nhanh giá, mức giảm và nhóm thể loại trước khi thêm vào thư viện.";
        featuredSubtitleLabel.Text = game.Subtitle;
        originalPriceValueLabel.Text = game.OriginalPriceText;
        discountValueLabel.Text = game.DiscountPercent > 0 ? $"-{game.DiscountPercent}%" : "0%";
        discountValueLabel.ForeColor = game.DiscountPercent > 0 ? Color.FromArgb(73, 209, 164) : AppTheme.SecondaryText;
        salePriceValueLabel.Text = game.SalePriceText;
        saleLimitValueLabel.Text = game.DiscountPercent > 0 ? "Không giới hạn" : "Giá hiện hành";
        saleLimitValueLabel.Text = game.DiscountPercent > 0 ? "Khong gioi han" : "Gia hien hanh";
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

        ConfigureFeaturedLayout(ClientSize.Width < 1180);
        UpdateCatalogLayout();
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

    private void ConfigureFeaturedLayout(bool stack)
    {
        featuredLayout.SuspendLayout();
        featuredLayout.Controls.Clear();
        featuredLayout.ColumnStyles.Clear();
        featuredLayout.RowStyles.Clear();

        if (stack)
        {
            featuredPanel.Height = 554;
            featuredLayout.ColumnCount = 1;
            featuredLayout.RowCount = 2;
            featuredLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            featuredLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, Math.Max(230, Math.Min(308, featuredPanel.Width / 3))));
            featuredLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            featuredPictureBox.Margin = new Padding(0, 0, 0, 14);
            featuredInfoPanel.Margin = new Padding(0);
            featuredLayout.Controls.Add(featuredPictureBox, 0, 0);
            featuredLayout.Controls.Add(featuredInfoPanel, 0, 1);
        }
        else
        {
            featuredPanel.Height = 390;
            featuredLayout.ColumnCount = 2;
            featuredLayout.RowCount = 1;
            featuredLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64F));
            featuredLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
            featuredLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            featuredPictureBox.Margin = new Padding(0);
            featuredInfoPanel.Margin = new Padding(0);
            featuredLayout.Controls.Add(featuredPictureBox, 0, 0);
            featuredLayout.Controls.Add(featuredInfoPanel, 1, 0);
        }

        featuredLayout.ResumeLayout();
        RenderFeaturedArtwork();
    }

    private void UpdateCatalogLayout()
    {
        var availableWidth = scrollContentPanel.ClientSize.Width - scrollContentPanel.Padding.Horizontal - 4;
        if (scrollContentPanel.VerticalScroll.Visible)
        {
            availableWidth -= SystemInformation.VerticalScrollBarWidth;
        }

        availableWidth = Math.Max(320, availableWidth);
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
