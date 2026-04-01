namespace UI_Desktop.Store;

partial class StoreForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        rootLayout = new TableLayoutPanel();
        headerPanel = new Panel();
        headerLayout = new TableLayoutPanel();
        brandLayout = new TableLayoutPanel();
        headerLogoPictureBox = new PictureBox();
        launcherNameLabel = new Label();
        versionLabel = new Label();
        navFlowPanel = new FlowLayoutPanel();
        actionFlowPanel = new FlowLayoutPanel();
        notificationButton = new StoreIconButton();
        cartHostPanel = new Panel();
        cartButton = new StoreIconButton();
        cartBadgePanel = new RoundedPanel();
        cartBadgeLabel = new Label();
        helpButton = new StoreIconButton();
        accountPanel = new RoundedPanel();
        accountLayout = new TableLayoutPanel();
        accountNameLabel = new Label();
        accountSeparatorLabel = new Label();
        balanceLabel = new Label();
        toolbarPanel = new Panel();
        toolbarLayout = new TableLayoutPanel();
        categoryComboBox = new ComboBox();
        searchPanel = new RoundedPanel();
        searchIconLabel = new Label();
        searchTextBox = new TextBox();
        resultCountLabel = new Label();
        scrollContentPanel = new Panel();
        contentLayout = new TableLayoutPanel();
        featuredPanel = new RoundedPanel();
        featuredLayout = new TableLayoutPanel();
        featuredPictureBox = new PictureBox();
        featuredInfoPanel = new Panel();
        featuredInfoLayout = new TableLayoutPanel();
        featuredPromoLabel = new Label();
        featuredTitleLabel = new Label();
        featuredSubtitleLabel = new Label();
        featuredSpecsLayout = new TableLayoutPanel();
        originalPriceCaptionLabel = new Label();
        originalPriceValueLabel = new Label();
        discountCaptionLabel = new Label();
        discountValueLabel = new Label();
        salePriceCaptionLabel = new Label();
        salePriceValueLabel = new Label();
        saleLimitCaptionLabel = new Label();
        saleLimitValueLabel = new Label();
        genresCaptionLabel = new Label();
        genresValueLabel = new Label();
        sectionHeaderFlowPanel = new FlowLayoutPanel();
        catalogTitleLabel = new Label();
        catalogHintLabel = new Label();
        emptyStateLabel = new Label();
        catalogFlowPanel = new FlowLayoutPanel();
        addGameButton = new Button();
        rootLayout.SuspendLayout();
        headerPanel.SuspendLayout();
        headerLayout.SuspendLayout();
        brandLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)headerLogoPictureBox).BeginInit();
        actionFlowPanel.SuspendLayout();
        cartHostPanel.SuspendLayout();
        cartBadgePanel.SuspendLayout();
        accountPanel.SuspendLayout();
        accountLayout.SuspendLayout();
        toolbarPanel.SuspendLayout();
        toolbarLayout.SuspendLayout();
        searchPanel.SuspendLayout();
        scrollContentPanel.SuspendLayout();
        contentLayout.SuspendLayout();
        featuredPanel.SuspendLayout();
        featuredLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)featuredPictureBox).BeginInit();
        featuredInfoPanel.SuspendLayout();
        featuredInfoLayout.SuspendLayout();
        featuredSpecsLayout.SuspendLayout();
        sectionHeaderFlowPanel.SuspendLayout();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.BackColor = Color.FromArgb(13, 18, 25);
        rootLayout.ColumnCount = 1;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayout.Controls.Add(headerPanel, 0, 0);
        rootLayout.Controls.Add(toolbarPanel, 0, 1);
        rootLayout.Controls.Add(scrollContentPanel, 0, 2);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Margin = new Padding(0);
        rootLayout.Name = "rootLayout";
        rootLayout.RowCount = 3;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 74F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayout.Size = new Size(1464, 821);
        rootLayout.TabIndex = 0;
        // 
        // headerPanel
        // 
        headerPanel.BackColor = Color.FromArgb(16, 21, 29);
        headerPanel.Controls.Add(headerLayout);
        headerPanel.Dock = DockStyle.Fill;
        headerPanel.Location = new Point(0, 0);
        headerPanel.Margin = new Padding(0);
        headerPanel.Name = "headerPanel";
        headerPanel.Padding = new Padding(26, 12, 18, 10);
        headerPanel.Size = new Size(1464, 74);
        headerPanel.TabIndex = 0;
        // 
        // headerLayout
        // 
        headerLayout.ColumnCount = 3;
        headerLayout.ColumnStyles.Add(new ColumnStyle());
        headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        headerLayout.ColumnStyles.Add(new ColumnStyle());
        headerLayout.Controls.Add(brandLayout, 0, 0);
        headerLayout.Controls.Add(navFlowPanel, 1, 0);
        headerLayout.Controls.Add(actionFlowPanel, 2, 0);
        headerLayout.Dock = DockStyle.Fill;
        headerLayout.Location = new Point(26, 12);
        headerLayout.Margin = new Padding(0);
        headerLayout.Name = "headerLayout";
        headerLayout.RowCount = 1;
        headerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        headerLayout.Size = new Size(1420, 52);
        headerLayout.TabIndex = 0;
        // 
        // brandLayout
        // 
        brandLayout.AutoSize = true;
        brandLayout.ColumnCount = 3;
        brandLayout.ColumnStyles.Add(new ColumnStyle());
        brandLayout.ColumnStyles.Add(new ColumnStyle());
        brandLayout.ColumnStyles.Add(new ColumnStyle());
        brandLayout.Controls.Add(headerLogoPictureBox, 0, 0);
        brandLayout.Controls.Add(launcherNameLabel, 1, 0);
        brandLayout.Controls.Add(versionLabel, 2, 0);
        brandLayout.Dock = DockStyle.Fill;
        brandLayout.Location = new Point(0, 0);
        brandLayout.Margin = new Padding(0);
        brandLayout.Name = "brandLayout";
        brandLayout.RowCount = 1;
        brandLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        brandLayout.Size = new Size(257, 52);
        brandLayout.TabIndex = 0;
        // 
        // headerLogoPictureBox
        // 
        headerLogoPictureBox.Location = new Point(0, 6);
        headerLogoPictureBox.Margin = new Padding(0, 6, 10, 0);
        headerLogoPictureBox.Name = "headerLogoPictureBox";
        headerLogoPictureBox.Size = new Size(32, 32);
        headerLogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        headerLogoPictureBox.TabIndex = 0;
        headerLogoPictureBox.TabStop = false;
        // 
        // launcherNameLabel
        // 
        launcherNameLabel.Anchor = AnchorStyles.Left;
        launcherNameLabel.AutoSize = true;
        launcherNameLabel.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
        launcherNameLabel.ForeColor = Color.FromArgb(239, 243, 248);
        launcherNameLabel.Location = new Point(42, 7);
        launcherNameLabel.Margin = new Padding(0, 0, 10, 0);
        launcherNameLabel.Name = "launcherNameLabel";
        launcherNameLabel.Size = new Size(164, 37);
        launcherNameLabel.TabIndex = 1;
        launcherNameLabel.Text = "NestG Store";
        // 
        // versionLabel
        // 
        versionLabel.Anchor = AnchorStyles.Left;
        versionLabel.AutoSize = true;
        versionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        versionLabel.ForeColor = Color.FromArgb(143, 156, 176);
        versionLabel.Location = new Point(216, 14);
        versionLabel.Margin = new Padding(0);
        versionLabel.Name = "versionLabel";
        versionLabel.Size = new Size(41, 23);
        versionLabel.TabIndex = 2;
        versionLabel.Text = "v0.0";
        // 
        // navFlowPanel
        // 
        navFlowPanel.AutoSize = true;
        navFlowPanel.BackColor = Color.FromArgb(16, 21, 29);
        navFlowPanel.Dock = DockStyle.Fill;
        navFlowPanel.Location = new Point(281, 0);
        navFlowPanel.Margin = new Padding(24, 0, 0, 0);
        navFlowPanel.Name = "navFlowPanel";
        navFlowPanel.Padding = new Padding(0, 2, 0, 0);
        navFlowPanel.Size = new Size(691, 52);
        navFlowPanel.TabIndex = 1;
        navFlowPanel.WrapContents = false;
        // 
        // actionFlowPanel
        // 
        actionFlowPanel.AutoSize = true;
        actionFlowPanel.BackColor = Color.FromArgb(16, 21, 29);
        actionFlowPanel.Controls.Add(notificationButton);
        actionFlowPanel.Controls.Add(cartHostPanel);
        actionFlowPanel.Controls.Add(helpButton);
        actionFlowPanel.Controls.Add(accountPanel);
        actionFlowPanel.Dock = DockStyle.Fill;
        actionFlowPanel.Location = new Point(982, 0);
        actionFlowPanel.Margin = new Padding(10, 0, 0, 0);
        actionFlowPanel.Name = "actionFlowPanel";
        actionFlowPanel.Padding = new Padding(0, 2, 0, 0);
        actionFlowPanel.Size = new Size(438, 52);
        actionFlowPanel.TabIndex = 2;
        actionFlowPanel.WrapContents = false;
        // 
        // notificationButton
        // 
        notificationButton.BackColor = Color.Transparent;
        notificationButton.FlatAppearance.BorderSize = 0;
        notificationButton.FlatStyle = FlatStyle.Flat;
        notificationButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        notificationButton.ForeColor = SystemColors.ButtonFace;
        notificationButton.Location = new Point(0, 2);
        notificationButton.Margin = new Padding(0, 0, 12, 0);
        notificationButton.Name = "notificationButton";
        notificationButton.Size = new Size(44, 44);
        notificationButton.TabIndex = 0;
        notificationButton.TabStop = false;
        notificationButton.UseVisualStyleBackColor = false;
        notificationButton.Click += notificationButton_Click;
        // 
        // cartHostPanel
        // 
        cartHostPanel.BackColor = Color.FromArgb(16, 21, 29);
        cartHostPanel.Controls.Add(cartButton);
        cartHostPanel.Controls.Add(cartBadgePanel);
        cartHostPanel.Location = new Point(56, 2);
        cartHostPanel.Margin = new Padding(0, 0, 12, 0);
        cartHostPanel.Name = "cartHostPanel";
        cartHostPanel.Size = new Size(64, 44);
        cartHostPanel.TabIndex = 1;
        // 
        // cartButton
        // 
        cartButton.BackColor = Color.Transparent;
        cartButton.FlatAppearance.BorderSize = 0;
        cartButton.FlatStyle = FlatStyle.Flat;
        cartButton.Location = new Point(0, 0);
        cartButton.Margin = new Padding(0);
        cartButton.Name = "cartButton";
        cartButton.Size = new Size(44, 44);
        cartButton.TabIndex = 0;
        cartButton.TabStop = false;
        cartButton.UseVisualStyleBackColor = false;
        // 
        // cartBadgePanel
        // 
        cartBadgePanel.BackColor = Color.Transparent;
        cartBadgePanel.Controls.Add(cartBadgeLabel);
        cartBadgePanel.Location = new Point(38, 1);
        cartBadgePanel.Margin = new Padding(0);
        cartBadgePanel.Name = "cartBadgePanel";
        cartBadgePanel.Size = new Size(22, 22);
        cartBadgePanel.TabIndex = 1;
        // 
        // cartBadgeLabel
        // 
        cartBadgeLabel.Dock = DockStyle.Fill;
        cartBadgeLabel.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
        cartBadgeLabel.ForeColor = Color.White;
        cartBadgeLabel.Location = new Point(0, 0);
        cartBadgeLabel.Margin = new Padding(0);
        cartBadgeLabel.Name = "cartBadgeLabel";
        cartBadgeLabel.Size = new Size(22, 22);
        cartBadgeLabel.TabIndex = 0;
        cartBadgeLabel.Text = "0";
        cartBadgeLabel.TextAlign = ContentAlignment.MiddleCenter;
        cartBadgeLabel.UseCompatibleTextRendering = true;
        // 
        // helpButton
        // 
        helpButton.BackColor = Color.Transparent;
        helpButton.FlatAppearance.BorderSize = 0;
        helpButton.FlatStyle = FlatStyle.Flat;
        helpButton.Location = new Point(132, 2);
        helpButton.Margin = new Padding(0, 0, 14, 0);
        helpButton.Name = "helpButton";
        helpButton.Size = new Size(44, 44);
        helpButton.TabIndex = 2;
        helpButton.TabStop = false;
        helpButton.UseVisualStyleBackColor = false;
        // 
        // accountPanel
        // 
        accountPanel.BackColor = Color.Transparent;
        accountPanel.Controls.Add(accountLayout);
        accountPanel.Location = new Point(190, 3);
        accountPanel.Margin = new Padding(0, 1, 0, 0);
        accountPanel.Name = "accountPanel";
        accountPanel.Padding = new Padding(16, 8, 16, 8);
        accountPanel.Size = new Size(248, 44);
        accountPanel.TabIndex = 3;
        // 
        // accountLayout
        // 
        accountLayout.ColumnCount = 3;
        accountLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        accountLayout.ColumnStyles.Add(new ColumnStyle());
        accountLayout.ColumnStyles.Add(new ColumnStyle());
        accountLayout.Controls.Add(accountNameLabel, 0, 0);
        accountLayout.Controls.Add(accountSeparatorLabel, 1, 0);
        accountLayout.Controls.Add(balanceLabel, 2, 0);
        accountLayout.Dock = DockStyle.Fill;
        accountLayout.Location = new Point(16, 8);
        accountLayout.Margin = new Padding(0);
        accountLayout.Name = "accountLayout";
        accountLayout.RowCount = 1;
        accountLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        accountLayout.Size = new Size(216, 28);
        accountLayout.TabIndex = 0;
        // 
        // accountNameLabel
        // 
        accountNameLabel.Anchor = AnchorStyles.Left;
        accountNameLabel.AutoSize = true;
        accountNameLabel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        accountNameLabel.ForeColor = Color.FromArgb(239, 243, 248);
        accountNameLabel.Location = new Point(0, 3);
        accountNameLabel.Margin = new Padding(0, 0, 12, 0);
        accountNameLabel.Name = "accountNameLabel";
        accountNameLabel.Size = new Size(91, 21);
        accountNameLabel.TabIndex = 1;
        accountNameLabel.Text = "nguyenduc";
        // 
        // accountSeparatorLabel
        // 
        accountSeparatorLabel.Anchor = AnchorStyles.None;
        accountSeparatorLabel.AutoSize = true;
        accountSeparatorLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        accountSeparatorLabel.ForeColor = Color.FromArgb(91, 106, 127);
        accountSeparatorLabel.Location = new Point(156, 2);
        accountSeparatorLabel.Margin = new Padding(0, 0, 12, 0);
        accountSeparatorLabel.Name = "accountSeparatorLabel";
        accountSeparatorLabel.Size = new Size(15, 23);
        accountSeparatorLabel.TabIndex = 2;
        accountSeparatorLabel.Text = "|";
        // 
        // balanceLabel
        // 
        balanceLabel.Anchor = AnchorStyles.Right;
        balanceLabel.AutoSize = true;
        balanceLabel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        balanceLabel.ForeColor = Color.FromArgb(181, 244, 121);
        balanceLabel.Location = new Point(183, 3);
        balanceLabel.Margin = new Padding(0);
        balanceLabel.Name = "balanceLabel";
        balanceLabel.Size = new Size(33, 21);
        balanceLabel.TabIndex = 3;
        balanceLabel.Text = "0 đ";
        // 
        // toolbarPanel
        // 
        toolbarPanel.BackColor = Color.FromArgb(16, 21, 29);
        toolbarPanel.Controls.Add(toolbarLayout);
        toolbarPanel.Dock = DockStyle.Fill;
        toolbarPanel.Location = new Point(0, 74);
        toolbarPanel.Margin = new Padding(0);
        toolbarPanel.Name = "toolbarPanel";
        toolbarPanel.Padding = new Padding(26, 8, 26, 10);
        toolbarPanel.Size = new Size(1464, 60);
        toolbarPanel.TabIndex = 1;
        // 
        // toolbarLayout
        // 
        toolbarLayout.ColumnCount = 3;
        toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
        toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        toolbarLayout.ColumnStyles.Add(new ColumnStyle());
        toolbarLayout.Controls.Add(categoryComboBox, 0, 0);
        toolbarLayout.Controls.Add(searchPanel, 1, 0);
        toolbarLayout.Controls.Add(resultCountLabel, 2, 0);
        toolbarLayout.Dock = DockStyle.Fill;
        toolbarLayout.Location = new Point(26, 8);
        toolbarLayout.Margin = new Padding(0);
        toolbarLayout.Name = "toolbarLayout";
        toolbarLayout.RowCount = 1;
        toolbarLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        toolbarLayout.Size = new Size(1412, 42);
        toolbarLayout.TabIndex = 0;
        // 
        // categoryComboBox
        // 
        categoryComboBox.BackColor = Color.FromArgb(31, 40, 53);
        categoryComboBox.Dock = DockStyle.Left;
        categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        categoryComboBox.FlatStyle = FlatStyle.Flat;
        categoryComboBox.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        categoryComboBox.ForeColor = Color.FromArgb(239, 243, 248);
        categoryComboBox.FormattingEnabled = true;
        categoryComboBox.IntegralHeight = false;
        categoryComboBox.ItemHeight = 23;
        categoryComboBox.Location = new Point(0, 4);
        categoryComboBox.Margin = new Padding(0, 4, 16, 0);
        categoryComboBox.MaxDropDownItems = 12;
        categoryComboBox.Name = "categoryComboBox";
        categoryComboBox.Size = new Size(154, 31);
        categoryComboBox.TabIndex = 0;
        // 
        // searchPanel
        // 
        searchPanel.BackColor = Color.Transparent;
        searchPanel.Controls.Add(searchIconLabel);
        searchPanel.Controls.Add(searchTextBox);
        searchPanel.Dock = DockStyle.Fill;
        searchPanel.Location = new Point(186, 0);
        searchPanel.Margin = new Padding(16, 0, 16, 0);
        searchPanel.Name = "searchPanel";
        searchPanel.Size = new Size(1061, 42);
        searchPanel.TabIndex = 1;
        // 
        // searchIconLabel
        // 
        searchIconLabel.AutoSize = true;
        searchIconLabel.Location = new Point(16, 11);
        searchIconLabel.Name = "searchIconLabel";
        searchIconLabel.Size = new Size(20, 20);
        searchIconLabel.TabIndex = 0;
        searchIconLabel.Text = "⌕";
        // 
        // searchTextBox
        // 
        searchTextBox.BackColor = Color.FromArgb(24, 31, 42);
        searchTextBox.BorderStyle = BorderStyle.None;
        searchTextBox.Font = new Font("Segoe UI", 10.5F);
        searchTextBox.ForeColor = Color.FromArgb(239, 243, 248);
        searchTextBox.Location = new Point(44, 10);
        searchTextBox.Margin = new Padding(0);
        searchTextBox.Name = "searchTextBox";
        searchTextBox.PlaceholderText = "Tìm trò chơi, thể loại hoặc điểm nổi bật...";
        searchTextBox.Size = new Size(280, 24);
        searchTextBox.TabIndex = 1;
        // 
        // resultCountLabel
        // 
        resultCountLabel.Anchor = AnchorStyles.Right;
        resultCountLabel.AutoSize = true;
        resultCountLabel.Font = new Font("Segoe UI", 9.5F);
        resultCountLabel.ForeColor = Color.FromArgb(143, 156, 176);
        resultCountLabel.Location = new Point(1263, 10);
        resultCountLabel.Margin = new Padding(0);
        resultCountLabel.Name = "resultCountLabel";
        resultCountLabel.Size = new Size(149, 21);
        resultCountLabel.TabIndex = 2;
        resultCountLabel.Text = "Hiển thị 0 sản phẩm";
        // 
        // scrollContentPanel
        // 
        scrollContentPanel.AutoScroll = true;
        scrollContentPanel.BackColor = Color.FromArgb(13, 18, 25);
        scrollContentPanel.Controls.Add(contentLayout);
        scrollContentPanel.Dock = DockStyle.Fill;
        scrollContentPanel.ForeColor = SystemColors.ControlLight;
        scrollContentPanel.Location = new Point(0, 134);
        scrollContentPanel.Margin = new Padding(0);
        scrollContentPanel.Name = "scrollContentPanel";
        scrollContentPanel.Padding = new Padding(30, 22, 30, 26);
        scrollContentPanel.Size = new Size(1464, 687);
        scrollContentPanel.TabIndex = 2;
        // 
        // contentLayout
        // 
        contentLayout.AutoSize = true;
        contentLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        contentLayout.ColumnCount = 1;
        contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        contentLayout.Controls.Add(featuredPanel, 0, 0);
        contentLayout.Controls.Add(sectionHeaderFlowPanel, 0, 1);
        contentLayout.Controls.Add(emptyStateLabel, 0, 2);
        contentLayout.Controls.Add(catalogFlowPanel, 0, 3);
        contentLayout.Controls.Add(addGameButton, 0, 4);
        contentLayout.Dock = DockStyle.Top;
        contentLayout.Location = new Point(30, 22);
        contentLayout.Margin = new Padding(0);
        contentLayout.Name = "contentLayout";
        contentLayout.RowCount = 5;
        contentLayout.RowStyles.Add(new RowStyle());
        contentLayout.RowStyles.Add(new RowStyle());
        contentLayout.RowStyles.Add(new RowStyle());
        contentLayout.RowStyles.Add(new RowStyle());
        contentLayout.RowStyles.Add(new RowStyle());
        contentLayout.Size = new Size(1404, 569);
        contentLayout.TabIndex = 0;
        // 
        // featuredPanel
        // 
        featuredPanel.BackColor = Color.Transparent;
        featuredPanel.Controls.Add(featuredLayout);
        featuredPanel.Dock = DockStyle.Top;
        featuredPanel.Location = new Point(0, 0);
        featuredPanel.Margin = new Padding(0, 0, 0, 28);
        featuredPanel.Name = "featuredPanel";
        featuredPanel.Padding = new Padding(14);
        featuredPanel.Size = new Size(1404, 390);
        featuredPanel.TabIndex = 0;
        // 
        // featuredLayout
        // 
        featuredLayout.ColumnCount = 2;
        featuredLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64F));
        featuredLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
        featuredLayout.Controls.Add(featuredPictureBox, 0, 0);
        featuredLayout.Controls.Add(featuredInfoPanel, 1, 0);
        featuredLayout.Dock = DockStyle.Fill;
        featuredLayout.Location = new Point(14, 14);
        featuredLayout.Margin = new Padding(0);
        featuredLayout.Name = "featuredLayout";
        featuredLayout.RowCount = 1;
        featuredLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        featuredLayout.Size = new Size(1376, 362);
        featuredLayout.TabIndex = 0;
        // 
        // featuredPictureBox
        // 
        featuredPictureBox.BackColor = Color.FromArgb(10, 15, 22);
        featuredPictureBox.Dock = DockStyle.Fill;
        featuredPictureBox.Location = new Point(0, 0);
        featuredPictureBox.Margin = new Padding(0);
        featuredPictureBox.Name = "featuredPictureBox";
        featuredPictureBox.Size = new Size(880, 362);
        featuredPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        featuredPictureBox.TabIndex = 0;
        featuredPictureBox.TabStop = false;
        // 
        // featuredInfoPanel
        // 
        featuredInfoPanel.BackColor = Color.FromArgb(14, 20, 29);
        featuredInfoPanel.Controls.Add(featuredInfoLayout);
        featuredInfoPanel.Dock = DockStyle.Fill;
        featuredInfoPanel.Location = new Point(880, 0);
        featuredInfoPanel.Margin = new Padding(0);
        featuredInfoPanel.Name = "featuredInfoPanel";
        featuredInfoPanel.Padding = new Padding(22, 20, 22, 16);
        featuredInfoPanel.Size = new Size(496, 362);
        featuredInfoPanel.TabIndex = 1;
        // 
        // featuredInfoLayout
        // 
        featuredInfoLayout.ColumnCount = 1;
        featuredInfoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        featuredInfoLayout.Controls.Add(featuredPromoLabel, 0, 0);
        featuredInfoLayout.Controls.Add(featuredTitleLabel, 0, 1);
        featuredInfoLayout.Controls.Add(featuredSubtitleLabel, 0, 2);
        featuredInfoLayout.Controls.Add(featuredSpecsLayout, 0, 3);
        featuredInfoLayout.Dock = DockStyle.Fill;
        featuredInfoLayout.Location = new Point(22, 20);
        featuredInfoLayout.Margin = new Padding(0);
        featuredInfoLayout.Name = "featuredInfoLayout";
        featuredInfoLayout.RowCount = 4;
        featuredInfoLayout.RowStyles.Add(new RowStyle());
        featuredInfoLayout.RowStyles.Add(new RowStyle());
        featuredInfoLayout.RowStyles.Add(new RowStyle());
        featuredInfoLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        featuredInfoLayout.Size = new Size(452, 326);
        featuredInfoLayout.TabIndex = 0;
        // 
        // featuredPromoLabel
        // 
        featuredPromoLabel.AutoSize = true;
        featuredPromoLabel.BackColor = Color.FromArgb(30, 82, 67);
        featuredPromoLabel.Font = new Font("Segoe UI Semibold", 9.2F, FontStyle.Bold);
        featuredPromoLabel.ForeColor = Color.FromArgb(220, 250, 240);
        featuredPromoLabel.Location = new Point(0, 0);
        featuredPromoLabel.Margin = new Padding(0);
        featuredPromoLabel.Name = "featuredPromoLabel";
        featuredPromoLabel.Padding = new Padding(12, 6, 12, 6);
        featuredPromoLabel.Size = new Size(106, 33);
        featuredPromoLabel.TabIndex = 0;
        featuredPromoLabel.Text = "SALE HOT";
        // 
        // featuredTitleLabel
        // 
        featuredTitleLabel.AutoSize = true;
        featuredTitleLabel.Font = new Font("Segoe UI Semibold", 21F, FontStyle.Bold);
        featuredTitleLabel.ForeColor = Color.FromArgb(239, 243, 248);
        featuredTitleLabel.Location = new Point(0, 47);
        featuredTitleLabel.Margin = new Padding(0, 14, 0, 0);
        featuredTitleLabel.MaximumSize = new Size(430, 0);
        featuredTitleLabel.Name = "featuredTitleLabel";
        featuredTitleLabel.Size = new Size(234, 47);
        featuredTitleLabel.TabIndex = 1;
        featuredTitleLabel.Text = "Featured title";
        // 
        // featuredSubtitleLabel
        // 
        featuredSubtitleLabel.AutoSize = true;
        featuredSubtitleLabel.Font = new Font("Segoe UI", 10F);
        featuredSubtitleLabel.ForeColor = Color.FromArgb(162, 174, 191);
        featuredSubtitleLabel.Location = new Point(0, 102);
        featuredSubtitleLabel.Margin = new Padding(0, 8, 0, 0);
        featuredSubtitleLabel.MaximumSize = new Size(430, 0);
        featuredSubtitleLabel.Name = "featuredSubtitleLabel";
        featuredSubtitleLabel.Size = new Size(268, 23);
        featuredSubtitleLabel.TabIndex = 2;
        featuredSubtitleLabel.Text = "Bản giới thiệu nổi bật trong ngày.";
        // 
        // featuredSpecsLayout
        // 
        featuredSpecsLayout.ColumnCount = 2;
        featuredSpecsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 124F));
        featuredSpecsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        featuredSpecsLayout.Controls.Add(originalPriceCaptionLabel, 0, 0);
        featuredSpecsLayout.Controls.Add(originalPriceValueLabel, 1, 0);
        featuredSpecsLayout.Controls.Add(discountCaptionLabel, 0, 1);
        featuredSpecsLayout.Controls.Add(discountValueLabel, 1, 1);
        featuredSpecsLayout.Controls.Add(salePriceCaptionLabel, 0, 2);
        featuredSpecsLayout.Controls.Add(salePriceValueLabel, 1, 2);
        featuredSpecsLayout.Controls.Add(saleLimitCaptionLabel, 0, 3);
        featuredSpecsLayout.Controls.Add(saleLimitValueLabel, 1, 3);
        featuredSpecsLayout.Controls.Add(genresCaptionLabel, 0, 4);
        featuredSpecsLayout.Controls.Add(genresValueLabel, 1, 4);
        featuredSpecsLayout.Dock = DockStyle.Fill;
        featuredSpecsLayout.Location = new Point(0, 147);
        featuredSpecsLayout.Margin = new Padding(0, 22, 0, 0);
        featuredSpecsLayout.Name = "featuredSpecsLayout";
        featuredSpecsLayout.RowCount = 5;
        featuredSpecsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        featuredSpecsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        featuredSpecsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        featuredSpecsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        featuredSpecsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        featuredSpecsLayout.Size = new Size(452, 179);
        featuredSpecsLayout.TabIndex = 3;
        // 
        // originalPriceCaptionLabel
        // 
        originalPriceCaptionLabel.Anchor = AnchorStyles.Left;
        originalPriceCaptionLabel.AutoSize = true;
        originalPriceCaptionLabel.Font = new Font("Segoe UI", 10F);
        originalPriceCaptionLabel.ForeColor = Color.FromArgb(143, 156, 176);
        originalPriceCaptionLabel.Location = new Point(0, 9);
        originalPriceCaptionLabel.Margin = new Padding(0);
        originalPriceCaptionLabel.Name = "originalPriceCaptionLabel";
        originalPriceCaptionLabel.Size = new Size(68, 23);
        originalPriceCaptionLabel.TabIndex = 0;
        originalPriceCaptionLabel.Text = "Giá gốc";
        // 
        // originalPriceValueLabel
        // 
        originalPriceValueLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        originalPriceValueLabel.AutoSize = true;
        originalPriceValueLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        originalPriceValueLabel.ForeColor = Color.FromArgb(239, 243, 248);
        originalPriceValueLabel.Location = new Point(124, 9);
        originalPriceValueLabel.Margin = new Padding(0);
        originalPriceValueLabel.Name = "originalPriceValueLabel";
        originalPriceValueLabel.Size = new Size(328, 23);
        originalPriceValueLabel.TabIndex = 1;
        originalPriceValueLabel.Text = "117.000 đ";
        originalPriceValueLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // discountCaptionLabel
        // 
        discountCaptionLabel.Anchor = AnchorStyles.Left;
        discountCaptionLabel.AutoSize = true;
        discountCaptionLabel.Font = new Font("Segoe UI", 10F);
        discountCaptionLabel.ForeColor = Color.FromArgb(143, 156, 176);
        discountCaptionLabel.Location = new Point(0, 51);
        discountCaptionLabel.Margin = new Padding(0);
        discountCaptionLabel.Name = "discountCaptionLabel";
        discountCaptionLabel.Size = new Size(50, 23);
        discountCaptionLabel.TabIndex = 2;
        discountCaptionLabel.Text = "Giảm";
        // 
        // discountValueLabel
        // 
        discountValueLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        discountValueLabel.AutoSize = true;
        discountValueLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
        discountValueLabel.ForeColor = Color.FromArgb(73, 209, 164);
        discountValueLabel.Location = new Point(124, 45);
        discountValueLabel.Margin = new Padding(0);
        discountValueLabel.Name = "discountValueLabel";
        discountValueLabel.Size = new Size(328, 35);
        discountValueLabel.TabIndex = 3;
        discountValueLabel.Text = "-90%";
        discountValueLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // salePriceCaptionLabel
        // 
        salePriceCaptionLabel.Anchor = AnchorStyles.Left;
        salePriceCaptionLabel.AutoSize = true;
        salePriceCaptionLabel.Font = new Font("Segoe UI", 10F);
        salePriceCaptionLabel.ForeColor = Color.FromArgb(143, 156, 176);
        salePriceCaptionLabel.Location = new Point(0, 97);
        salePriceCaptionLabel.Margin = new Padding(0);
        salePriceCaptionLabel.Name = "salePriceCaptionLabel";
        salePriceCaptionLabel.Size = new Size(88, 23);
        salePriceCaptionLabel.TabIndex = 4;
        salePriceCaptionLabel.Text = "Giá ưu đãi";
        // 
        // salePriceValueLabel
        // 
        salePriceValueLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        salePriceValueLabel.AutoSize = true;
        salePriceValueLabel.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold);
        salePriceValueLabel.ForeColor = Color.FromArgb(82, 138, 255);
        salePriceValueLabel.Location = new Point(124, 89);
        salePriceValueLabel.Margin = new Padding(0);
        salePriceValueLabel.Name = "salePriceValueLabel";
        salePriceValueLabel.Size = new Size(328, 40);
        salePriceValueLabel.TabIndex = 5;
        salePriceValueLabel.Text = "11.700 đ";
        salePriceValueLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // saleLimitCaptionLabel
        // 
        saleLimitCaptionLabel.Anchor = AnchorStyles.Left;
        saleLimitCaptionLabel.AutoSize = true;
        saleLimitCaptionLabel.Font = new Font("Segoe UI", 10F);
        saleLimitCaptionLabel.ForeColor = Color.FromArgb(143, 156, 176);
        saleLimitCaptionLabel.Location = new Point(0, 142);
        saleLimitCaptionLabel.Margin = new Padding(0);
        saleLimitCaptionLabel.Name = "saleLimitCaptionLabel";
        saleLimitCaptionLabel.Size = new Size(72, 23);
        saleLimitCaptionLabel.TabIndex = 6;
        saleLimitCaptionLabel.Text = "Hiệu lực";
        // 
        // saleLimitValueLabel
        // 
        saleLimitValueLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        saleLimitValueLabel.AutoSize = true;
        saleLimitValueLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        saleLimitValueLabel.ForeColor = Color.FromArgb(239, 243, 248);
        saleLimitValueLabel.Location = new Point(124, 142);
        saleLimitValueLabel.Margin = new Padding(0);
        saleLimitValueLabel.Name = "saleLimitValueLabel";
        saleLimitValueLabel.Size = new Size(328, 23);
        saleLimitValueLabel.TabIndex = 7;
        saleLimitValueLabel.Text = "Không giới hạn";
        saleLimitValueLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // genresCaptionLabel
        // 
        genresCaptionLabel.Anchor = AnchorStyles.Left;
        genresCaptionLabel.AutoSize = true;
        genresCaptionLabel.Font = new Font("Segoe UI", 10F);
        genresCaptionLabel.ForeColor = Color.FromArgb(143, 156, 176);
        genresCaptionLabel.Location = new Point(0, 175);
        genresCaptionLabel.Margin = new Padding(0, 1, 0, 0);
        genresCaptionLabel.Name = "genresCaptionLabel";
        genresCaptionLabel.Size = new Size(70, 4);
        genresCaptionLabel.TabIndex = 8;
        genresCaptionLabel.Text = "Thể loại";
        // 
        // genresValueLabel
        // 
        genresValueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        genresValueLabel.AutoSize = true;
        genresValueLabel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        genresValueLabel.ForeColor = Color.FromArgb(239, 243, 248);
        genresValueLabel.Location = new Point(124, 175);
        genresValueLabel.Margin = new Padding(0, 1, 0, 0);
        genresValueLabel.MaximumSize = new Size(328, 0);
        genresValueLabel.Name = "genresValueLabel";
        genresValueLabel.Size = new Size(328, 4);
        genresValueLabel.TabIndex = 9;
        genresValueLabel.Text = "Farming Sim, Indie, Casual";
        genresValueLabel.TextAlign = ContentAlignment.TopRight;
        // 
        // sectionHeaderFlowPanel
        // 
        sectionHeaderFlowPanel.AutoSize = true;
        sectionHeaderFlowPanel.Controls.Add(catalogTitleLabel);
        sectionHeaderFlowPanel.Controls.Add(catalogHintLabel);
        sectionHeaderFlowPanel.Location = new Point(0, 418);
        sectionHeaderFlowPanel.Margin = new Padding(0, 0, 0, 16);
        sectionHeaderFlowPanel.Name = "sectionHeaderFlowPanel";
        sectionHeaderFlowPanel.Size = new Size(324, 41);
        sectionHeaderFlowPanel.TabIndex = 1;
        sectionHeaderFlowPanel.WrapContents = false;
        // 
        // catalogTitleLabel
        // 
        catalogTitleLabel.AutoSize = true;
        catalogTitleLabel.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
        catalogTitleLabel.ForeColor = Color.FromArgb(239, 243, 248);
        catalogTitleLabel.Location = new Point(0, 0);
        catalogTitleLabel.Margin = new Padding(0, 0, 12, 0);
        catalogTitleLabel.Name = "catalogTitleLabel";
        catalogTitleLabel.Size = new Size(155, 41);
        catalogTitleLabel.TabIndex = 0;
        catalogTitleLabel.Text = "Khám phá";
        // 
        // catalogHintLabel
        // 
        catalogHintLabel.AutoSize = true;
        catalogHintLabel.Font = new Font("Segoe UI", 10F);
        catalogHintLabel.ForeColor = Color.FromArgb(143, 156, 176);
        catalogHintLabel.Location = new Point(167, 13);
        catalogHintLabel.Margin = new Padding(0, 13, 0, 0);
        catalogHintLabel.Name = "catalogHintLabel";
        catalogHintLabel.Size = new Size(157, 23);
        catalogHintLabel.TabIndex = 1;
        catalogHintLabel.Text = "Danh sách đang có";
        // 
        // emptyStateLabel
        // 
        emptyStateLabel.AutoSize = true;
        emptyStateLabel.Font = new Font("Segoe UI", 11F);
        emptyStateLabel.ForeColor = Color.FromArgb(162, 174, 191);
        emptyStateLabel.Location = new Point(0, 475);
        emptyStateLabel.Margin = new Padding(0, 0, 0, 12);
        emptyStateLabel.Name = "emptyStateLabel";
        emptyStateLabel.Size = new Size(299, 25);
        emptyStateLabel.TabIndex = 2;
        emptyStateLabel.Text = "Không có trò chơi phù hợp bộ lọc.";
        emptyStateLabel.Visible = false;
        // 
        // catalogFlowPanel
        // 
        catalogFlowPanel.AutoSize = true;
        catalogFlowPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        catalogFlowPanel.Dock = DockStyle.Top;
        catalogFlowPanel.Location = new Point(0, 512);
        catalogFlowPanel.Margin = new Padding(0);
        catalogFlowPanel.Name = "catalogFlowPanel";
        catalogFlowPanel.Size = new Size(1404, 0);
        catalogFlowPanel.TabIndex = 3;
        // 
        // addGameButton
        // 
        addGameButton.AutoSize = true;
        addGameButton.BackColor = Color.Transparent;
        addGameButton.FlatAppearance.BorderSize = 0;
        addGameButton.FlatStyle = FlatStyle.Flat;
        addGameButton.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
        addGameButton.ForeColor = Color.FromArgb(162, 174, 191);
        addGameButton.Location = new Point(0, 534);
        addGameButton.Margin = new Padding(0, 22, 0, 0);
        addGameButton.Name = "addGameButton";
        addGameButton.Size = new Size(160, 35);
        addGameButton.TabIndex = 4;
        addGameButton.Text = "+  Thêm trò chơi";
        addGameButton.TextAlign = ContentAlignment.MiddleLeft;
        addGameButton.UseVisualStyleBackColor = false;
        addGameButton.Click += addGameButton_Click;
        // 
        // StoreForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(13, 18, 25);
        ClientSize = new Size(1464, 821);
        Controls.Add(rootLayout);
        MinimumSize = new Size(1020, 760);
        Name = "StoreForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "NestG Launcher";
        rootLayout.ResumeLayout(false);
        headerPanel.ResumeLayout(false);
        headerLayout.ResumeLayout(false);
        headerLayout.PerformLayout();
        brandLayout.ResumeLayout(false);
        brandLayout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)headerLogoPictureBox).EndInit();
        actionFlowPanel.ResumeLayout(false);
        cartHostPanel.ResumeLayout(false);
        cartBadgePanel.ResumeLayout(false);
        accountPanel.ResumeLayout(false);
        accountLayout.ResumeLayout(false);
        accountLayout.PerformLayout();
        toolbarPanel.ResumeLayout(false);
        toolbarLayout.ResumeLayout(false);
        toolbarLayout.PerformLayout();
        searchPanel.ResumeLayout(false);
        searchPanel.PerformLayout();
        scrollContentPanel.ResumeLayout(false);
        scrollContentPanel.PerformLayout();
        contentLayout.ResumeLayout(false);
        contentLayout.PerformLayout();
        featuredPanel.ResumeLayout(false);
        featuredLayout.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)featuredPictureBox).EndInit();
        featuredInfoPanel.ResumeLayout(false);
        featuredInfoLayout.ResumeLayout(false);
        featuredInfoLayout.PerformLayout();
        featuredSpecsLayout.ResumeLayout(false);
        featuredSpecsLayout.PerformLayout();
        sectionHeaderFlowPanel.ResumeLayout(false);
        sectionHeaderFlowPanel.PerformLayout();
        ResumeLayout(false);
    }

    private void InitializeVisualState()
    {
        WindowState = FormWindowState.Maximized;

        var iconAccentColor = Color.FromArgb(255, 255, 255);
        var iconAccentHoverColor = Color.FromArgb(255, 255, 255);
        var actionSurface = Color.FromArgb(19, 25, 34);
        var actionHoverSurface = Color.FromArgb(24, 31, 42);
        var actionOutline = Color.FromArgb(39, 53, 70);
        var actionHoverOutline = Color.FromArgb(59, 77, 101);

        notificationButton.IconKind = StoreIconKind.Notification;
        notificationButton.BadgeText = string.Empty;
        notificationButton.UseOriginalGlyphColors = false;
        notificationButton.ShowChrome = true;
        notificationButton.GlyphSize = 27F;
        notificationButton.GlyphYOffset = -1;
        notificationButton.GlyphStrokeWidth = 1.34F;
        notificationButton.SurfaceColor = actionSurface;
        notificationButton.HoverSurfaceColor = actionHoverSurface;
        notificationButton.OutlineColor = actionOutline;
        notificationButton.HoverOutlineColor = actionHoverOutline;
        notificationButton.GlyphColor = iconAccentColor;
        notificationButton.HoverGlyphColor = iconAccentHoverColor;

        cartButton.IconKind = StoreIconKind.Cart;
        cartButton.BadgeText = string.Empty;
        cartButton.UseOriginalGlyphColors = false;
        cartButton.ShowChrome = true;
        cartButton.GlyphSize = 27F;
        cartButton.GlyphYOffset = -1;
        cartButton.GlyphStrokeWidth = 1.32F;
        cartButton.SurfaceColor = actionSurface;
        cartButton.HoverSurfaceColor = actionHoverSurface;
        cartButton.OutlineColor = actionOutline;
        cartButton.HoverOutlineColor = actionHoverOutline;
        cartButton.GlyphColor = iconAccentColor;
        cartButton.HoverGlyphColor = iconAccentHoverColor;

        helpButton.IconKind = StoreIconKind.Help;
        helpButton.BadgeText = string.Empty;
        helpButton.UseOriginalGlyphColors = false;
        helpButton.ShowChrome = true;
        helpButton.GlyphSize = 27F;
        helpButton.GlyphStrokeWidth = 1.26F;
        helpButton.SurfaceColor = Color.FromArgb(44, 40, 37);
        helpButton.HoverSurfaceColor = Color.FromArgb(61, 54, 49);
        helpButton.OutlineColor = Color.FromArgb(82, 72, 64);
        helpButton.HoverOutlineColor = Color.FromArgb(109, 95, 84);
        helpButton.GlyphColor = iconAccentColor;
        helpButton.HoverGlyphColor = iconAccentHoverColor;

        accountPanel.SurfaceColor = Color.FromArgb(21, 29, 40);
        accountPanel.BorderColor = Color.FromArgb(53, 72, 95);
        accountPanel.BorderThickness = 1;
        accountPanel.CornerRadius = 24;

        cartBadgePanel.SurfaceColor = AppTheme.Accent;
        cartBadgePanel.BorderColor = AppTheme.Accent;
        cartBadgePanel.BorderThickness = 0;
        cartBadgePanel.CornerRadius = 11;

        featuredPanel.SurfaceColor = Color.FromArgb(15, 22, 31);
        featuredPanel.BorderColor = Color.FromArgb(47, 63, 82);
        featuredPanel.BorderThickness = 1;
        featuredPanel.CornerRadius = 24;

        categoryComboBox.Cursor = Cursors.Hand;
        categoryComboBox.DropDownHeight = 240;

        addGameButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 35, 46);
        addGameButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 31, 42);
    }

    #endregion

    private TableLayoutPanel rootLayout;
    private Panel headerPanel;
    private TableLayoutPanel headerLayout;
    private TableLayoutPanel brandLayout;
    private PictureBox headerLogoPictureBox;
    private Label launcherNameLabel;
    private Label versionLabel;
    private FlowLayoutPanel navFlowPanel;
    private FlowLayoutPanel actionFlowPanel;
    private StoreIconButton notificationButton;
    private Panel cartHostPanel;
    private StoreIconButton cartButton;
    private UI_Desktop.RoundedPanel cartBadgePanel;
    private Label cartBadgeLabel;
    private StoreIconButton helpButton;
    private UI_Desktop.RoundedPanel accountPanel;
    private TableLayoutPanel accountLayout;
    private Label accountNameLabel;
    private Label accountSeparatorLabel;
    private Label balanceLabel;
    private Panel toolbarPanel;
    private TableLayoutPanel toolbarLayout;
    private ComboBox categoryComboBox;
    private UI_Desktop.RoundedPanel searchPanel;
    private Label searchIconLabel;
    private TextBox searchTextBox;
    private Label resultCountLabel;
    private Panel scrollContentPanel;
    private TableLayoutPanel contentLayout;
    private UI_Desktop.RoundedPanel featuredPanel;
    private TableLayoutPanel featuredLayout;
    private PictureBox featuredPictureBox;
    private Panel featuredInfoPanel;
    private TableLayoutPanel featuredInfoLayout;
    private Label featuredPromoLabel;
    private Label featuredTitleLabel;
    private Label featuredSubtitleLabel;
    private TableLayoutPanel featuredSpecsLayout;
    private Label originalPriceCaptionLabel;
    private Label originalPriceValueLabel;
    private Label discountCaptionLabel;
    private Label discountValueLabel;
    private Label salePriceCaptionLabel;
    private Label salePriceValueLabel;
    private Label saleLimitCaptionLabel;
    private Label saleLimitValueLabel;
    private Label genresCaptionLabel;
    private Label genresValueLabel;
    private FlowLayoutPanel sectionHeaderFlowPanel;
    private Label catalogTitleLabel;
    private Label catalogHintLabel;
    private Label emptyStateLabel;
    private FlowLayoutPanel catalogFlowPanel;
    private Button addGameButton;
}
