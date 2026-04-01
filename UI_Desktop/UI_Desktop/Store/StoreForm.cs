namespace UI_Desktop.Store;

internal partial class StoreForm : Form
{
    private readonly StorePageData pageData;
    private readonly List<StoreNavButton> navButtons = [];
    private readonly List<StoreGameCard> visibleCards = [];
    private Image? featuredArtwork;
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

        accountPanel.SurfaceColor = Color.FromArgb(20, 28, 39);
        accountPanel.BorderColor = Color.FromArgb(42, 55, 72);
        accountPanel.BorderThickness = 1;
        accountPanel.CornerRadius = 22;

        featuredPanel.SurfaceColor = Color.FromArgb(17, 24, 33);
        featuredPanel.BorderColor = AppTheme.CardBorder;
        featuredPanel.BorderThickness = 1;
        featuredPanel.CornerRadius = 24;

        categoryComboBox.Cursor = Cursors.Hand;
        categoryComboBox.DropDownHeight = 240;

        addGameButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 35, 46);
        addGameButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 31, 42);

        notificationButton.Click += (_, _) => MessageBox.Show("Khu vực thông báo đang ở bản xem trước.", "NestG Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
        cartButton.Click += (_, _) => MessageBox.Show("Giỏ hàng mẫu hiện chưa kết nối dữ liệu thật.", "NestG Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
        helpButton.Click += (_, _) => MessageBox.Show("Đây là bản dựng demo của giao diện cửa hàng.", "NestG Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BindEvents()
    {
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
        originalPriceValueLabel.Text = game.OriginalPriceText;
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

        var hideResultCount = ClientSize.Width < 1120;
        resultCountLabel.Visible = !hideResultCount;

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
            featuredPanel.Height = 568;
            featuredLayout.ColumnCount = 1;
            featuredLayout.RowCount = 2;
            featuredLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            featuredLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, Math.Max(220, Math.Min(300, featuredPanel.Width / 3))));
            featuredLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            featuredPictureBox.Margin = new Padding(0, 0, 0, 16);
            featuredInfoPanel.Margin = new Padding(0);
            featuredLayout.Controls.Add(featuredPictureBox, 0, 0);
            featuredLayout.Controls.Add(featuredInfoPanel, 0, 1);
        }
        else
        {
            featuredPanel.Height = 390;
            featuredLayout.ColumnCount = 2;
            featuredLayout.RowCount = 1;
            featuredLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62F));
            featuredLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
            featuredLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            featuredPictureBox.Margin = new Padding(0, 0, 18, 0);
            featuredInfoPanel.Margin = new Padding(18, 0, 0, 0);
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
}
