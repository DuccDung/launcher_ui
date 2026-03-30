(() => {
  const root = document.querySelector("[data-game-workspace]");

  if (!root) {
    return;
  }

  const STORAGE_KEY = "nestg-admin-game-workspace-v1";
  const hasLocalStorage = typeof window.localStorage !== "undefined";
  const dateFormatter = new Intl.DateTimeFormat("vi-VN", {
    dateStyle: "short",
    timeStyle: "short",
  });
  const currencyFormatter = new Intl.NumberFormat("vi-VN");

  const refs = {
    globalSearch: document.getElementById("workspace-global-search"),
    workspaceStats: root.querySelector("[data-workspace-stats]"),
    workspaceMessage: root.querySelector("[data-workspace-message]"),
    gameSummary: root.querySelector("[data-game-summary]"),
    categoryChoices: root.querySelector("[data-category-choices]"),
    selectedCategories: root.querySelector("[data-selected-categories]"),
    gameList: root.querySelector("[data-game-list]"),
    versionList: root.querySelector("[data-version-list]"),
    accountList: root.querySelector("[data-account-list]"),
    fileList: root.querySelector("[data-file-list]"),
    mediaList: root.querySelector("[data-media-list]"),
    articlePreview: root.querySelector("[data-article-preview]"),
    articlePreviewMeta: root.querySelector("[data-article-preview-meta]"),
    articleStatePill: root.querySelector("[data-article-state-pill]"),
    gameCountPill: root.querySelector("[data-game-count-pill]"),
    versionCountLabel: root.querySelector("[data-version-count-label]"),
    accountCountLabel: root.querySelector("[data-account-count-label]"),
    fileCountLabel: root.querySelector("[data-file-count-label]"),
    mediaCountLabel: root.querySelector("[data-media-count-label]"),
    gameListSearch: document.getElementById("game-list-search"),
    gameListCategoryFilter: document.getElementById("game-list-category-filter"),
    gameId: document.getElementById("game-id"),
    gameName: document.getElementById("game-name"),
    gameRating: document.getElementById("game-rating"),
    gameOldPrice: document.getElementById("game-old-price"),
    gameNewPrice: document.getElementById("game-new-price"),
    gameSlugPreview: document.getElementById("game-slug-preview"),
    gameCreatedAt: document.getElementById("game-created-at"),
    gameUpdatedAt: document.getElementById("game-updated-at"),
    versionId: document.getElementById("version-id"),
    versionGameId: document.getElementById("version-game-id"),
    versionAccountId: document.getElementById("version-account-id"),
    versionIsRemoved: document.getElementById("version-is-removed"),
    versionCreatedAt: document.getElementById("version-created-at"),
    versionUpdatedAt: document.getElementById("version-updated-at"),
    accountId: document.getElementById("account-id"),
    accountIsActive: document.getElementById("account-is-active"),
    accountIsPurchased: document.getElementById("account-is-purchased"),
    accountCreatedAt: document.getElementById("account-created-at"),
    accountUpdatedAt: document.getElementById("account-updated-at"),
    fileId: document.getElementById("file-id"),
    fileAccountId: document.getElementById("file-account-id"),
    fileType: document.getElementById("file-type"),
    fileIsActive: document.getElementById("file-is-active"),
    fileUrl01: document.getElementById("file-url-01"),
    fileUrl02: document.getElementById("file-url-02"),
    fileUrl03: document.getElementById("file-url-03"),
    fileUrl04: document.getElementById("file-url-04"),
    fileUrl05: document.getElementById("file-url-05"),
    mediaId: document.getElementById("media-id"),
    mediaGameId: document.getElementById("media-game-id"),
    mediaType: document.getElementById("media-type"),
    mediaUrl: document.getElementById("media-url"),
    mediaCreatedAt: document.getElementById("media-created-at"),
    mediaUpdatedAt: document.getElementById("media-updated-at"),
    articleId: document.getElementById("article-id"),
    articleGameId: document.getElementById("article-game-id"),
    articleCreatedAt: document.getElementById("article-created-at"),
    articleUpdatedAt: document.getElementById("article-updated-at"),
    articleEyebrow: document.getElementById("article-eyebrow"),
    articleTitle: document.getElementById("article-title"),
    articleSummary: document.getElementById("article-summary"),
    articleBlockCount: root.querySelector("[data-article-block-count]"),
    articleBlockList: root.querySelector("[data-article-block-list]"),
    articleEditorEmpty: root.querySelector("[data-article-editor-empty]"),
    articleBlockType: document.getElementById("article-block-type"),
    articleBlockTitle: document.getElementById("article-block-title"),
    articleBlockText: document.getElementById("article-block-text"),
    articleBlockIntro: document.getElementById("article-block-intro"),
    articleBlockItems: document.getElementById("article-block-items"),
    articleBlockUrl: document.getElementById("article-block-url"),
    articleBlockAlt: document.getElementById("article-block-alt"),
    articleBlockMoveUp: document.getElementById("article-block-move-up"),
    articleBlockMoveDown: document.getElementById("article-block-move-down"),
    articleBlockDuplicate: document.getElementById("article-block-duplicate"),
    articleBlockDelete: document.getElementById("article-block-delete"),
    articleJson: document.getElementById("article-json"),
    articleAddButtons: [...root.querySelectorAll("[data-article-add-block]")],
    articleEditorGroups: [...root.querySelectorAll("[data-article-editor-group]")],
    workspaceNewGame: document.getElementById("workspace-new-game"),
    workspaceResetSeed: document.getElementById("workspace-reset-seed"),
    gameCreate: document.getElementById("game-create"),
    gameUpdate: document.getElementById("game-update"),
    gameDelete: document.getElementById("game-delete"),
    gameResetForm: document.getElementById("game-reset-form"),
    versionCreate: document.getElementById("version-create"),
    versionUpdate: document.getElementById("version-update"),
    versionDelete: document.getElementById("version-delete"),
    versionReset: document.getElementById("version-reset"),
    accountCreate: document.getElementById("account-create"),
    accountUpdate: document.getElementById("account-update"),
    accountDelete: document.getElementById("account-delete"),
    accountReset: document.getElementById("account-reset"),
    fileCreate: document.getElementById("file-create"),
    fileUpdate: document.getElementById("file-update"),
    fileDelete: document.getElementById("file-delete"),
    fileReset: document.getElementById("file-reset"),
    mediaCreate: document.getElementById("media-create"),
    mediaUpdate: document.getElementById("media-update"),
    mediaDelete: document.getElementById("media-delete"),
    mediaReset: document.getElementById("media-reset"),
    articleFormat: document.getElementById("article-format"),
    articleLoadSample: document.getElementById("article-load-sample"),
    articleDelete: document.getElementById("article-delete"),
    articleSave: document.getElementById("article-save"),
  };

  const ui = {
    selectedGameId: null,
    selectedVersionId: null,
    selectedAccountId: null,
    selectedFileId: null,
    selectedMediaId: null,
    selectedArticleBlockId: null,
    articleDraft: null,
    articleDraftGameId: null,
    articleDraftDirty: false,
  };

  const ARTICLE_BLOCK_META = {
    paragraph: {
      label: "Đoạn văn",
      icon: "bi-text-paragraph",
      groups: ["text"],
    },
    heading: {
      label: "Tiêu đề phụ",
      icon: "bi-type-h2",
      groups: ["text"],
    },
    image: {
      label: "Hình ảnh",
      icon: "bi-image",
      groups: ["url", "alt"],
    },
    video: {
      label: "Video",
      icon: "bi-play-btn",
      groups: ["title", "url"],
    },
    list: {
      label: "Danh sách",
      icon: "bi-list-ul",
      groups: ["intro", "items"],
    },
    quote: {
      label: "Trích dẫn",
      icon: "bi-quote",
      groups: ["text"],
    },
  };

  function createGuid() {
    if (window.crypto && typeof window.crypto.randomUUID === "function") {
      return window.crypto.randomUUID();
    }

    return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, (char) => {
      const random = Math.random() * 16 | 0;
      const value = char === "x" ? random : (random & 0x3) | 0x8;
      return value.toString(16);
    });
  }

  function nowIso() {
    return new Date().toISOString();
  }

  function clone(value) {
    return JSON.parse(JSON.stringify(value));
  }

  function escapeHtml(value) {
    return String(value ?? "")
      .replaceAll("&", "&amp;")
      .replaceAll("<", "&lt;")
      .replaceAll(">", "&gt;")
      .replaceAll('"', "&quot;")
      .replaceAll("'", "&#39;");
  }

  function slugify(value) {
    return String(value ?? "")
      .toLowerCase()
      .normalize("NFD")
      .replace(/[\u0300-\u036f]/g, "")
      .replace(/đ/g, "d")
      .replace(/[^a-z0-9]+/g, "-")
      .replace(/^-+|-+$/g, "")
      .replace(/-{2,}/g, "-");
  }

  function formatDate(value) {
    if (!value) {
      return "—";
    }

    const date = new Date(value);

    if (Number.isNaN(date.getTime())) {
      return "—";
    }

    return dateFormatter.format(date);
  }

  function formatCurrency(value) {
    if (value === null || value === undefined || value === "") {
      return "—";
    }

    return `${currencyFormatter.format(Number(value))} đ`;
  }

  function shortId(value) {
    if (!value) {
      return "—";
    }

    return String(value).split("-")[0].toUpperCase();
  }

  function toBoolean(value) {
    return value === true || value === "true";
  }

  function toNumber(value) {
    if (value === "" || value === null || value === undefined) {
      return null;
    }

    const parsed = Number(value);
    return Number.isFinite(parsed) ? parsed : null;
  }

  function normalizeText(value) {
    return String(value ?? "").trim().toLowerCase();
  }

  function sortByUpdatedAt(items) {
    return [...items].sort((left, right) => {
      return new Date(right.updatedAt ?? right.createdAt ?? 0) - new Date(left.updatedAt ?? left.createdAt ?? 0);
    });
  }

  function getFileUrls(fileRecord) {
    return [
      fileRecord.fileUrl01,
      fileRecord.fileUrl02,
      fileRecord.fileUrl03,
      fileRecord.fileUrl04,
      fileRecord.fileUrl05,
    ].filter(Boolean);
  }

  function isYoutubeUrl(url) {
    return /youtu\.be|youtube\.com/i.test(String(url ?? ""));
  }

  function toYoutubeEmbed(url) {
    const source = String(url ?? "").trim();

    if (!source) {
      return "";
    }

    if (source.includes("/embed/")) {
      return source;
    }

    try {
      const parsed = new URL(source);
      const videoId = parsed.hostname.includes("youtu.be")
        ? parsed.pathname.replaceAll("/", "")
        : parsed.searchParams.get("v");

      if (videoId) {
        return `https://www.youtube-nocookie.com/embed/${videoId}?rel=0`;
      }
    } catch (error) {
      return source;
    }

    return source;
  }

  function buildWukongArticleJson() {
    return JSON.stringify(
      {
        eyebrow: "Black Myth Special",
        title: "Hành trình trở thành huyền thoại khi dấn thân vào thế giới của “Black Myth: Wukong”",
        summary:
          "Bước vào thế giới của “Black Myth: Wukong”, người chơi sẽ hóa thân thành “Người Định Mệnh”, dấn thân vào một hành trình đầy thử thách để làm sáng tỏ những bí ẩn đằng sau huyền thoại cổ xưa.",
        blocks: [
          {
            type: "video",
            title: "Black Myth: Wukong - Pre-Order CG Trailer | PS5 Games",
            url: "https://www.youtube.com/watch?v=u83VdXAVq08",
          },
          {
            type: "heading",
            text: "Khám phá cốt truyện thần thoại đầy mê hoặc trong “Black Myth: Wukong”",
          },
          {
            type: "image",
            url: "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2358720/ss_cfbee2025e75f18d493017fb2d74b8f27971e797.jpg",
            alt: "Black Myth Wukong mythical beast scene",
          },
          {
            type: "paragraph",
            text:
              "Bước vào thế giới của “Black Myth: Wukong”, người chơi sẽ hóa thân thành “Người Định Mệnh” (Destined One), dấn thân vào một hành trình đầy thử thách để làm sáng tỏ những bí ẩn đằng sau một huyền thoại cổ xưa. Trò chơi lấy cảm hứng sâu sắc từ bộ tiểu thuyết kinh điển Tây Du Ký, nhưng mang đến một góc nhìn mới mẻ, đen tối và hùng vĩ hơn bao giờ hết.",
          },
          {
            type: "paragraph",
            text:
              "Sở hữu “Black Myth: Wukong” không chỉ là sở hữu một tựa game, mà là mở ra cánh cửa dẫn đến một vùng đất thần tiên nơi các vị thần và yêu quái đối đầu trực diện. Mỗi khu vực bạn đi qua, mỗi câu chuyện bạn khám phá đều góp phần tạo nên một bản hùng ca tráng lệ về lòng dũng cảm và vận mệnh.",
          },
          {
            type: "heading",
            text: "Phân tích những cơ chế chiến đấu đỉnh cao có trong “Black Myth: Wukong”",
          },
          {
            type: "image",
            url: "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2358720/ss_8626df74b9297b0834caea1ecbcf0f8f6a34f204.jpg",
            alt: "Black Myth Wukong combat scene",
          },
          {
            type: "list",
            intro: "Hệ thống gameplay của trò chơi được thiết kế để mang lại cảm giác hành động mãn nhãn nhưng cũng đầy tính chiến thuật:",
            items: [
              "Phép thuật và biến hóa đa dạng: người chơi có thể biến thân thành các sinh vật khác nhau để tận dụng kỹ năng của kẻ thù.",
              "Kỹ năng gậy như ý linh hoạt: các thế đánh từ phòng thủ đến tấn công tạo ra chuỗi combo đẹp mắt và đầy uy lực.",
              "Hệ thống đối đầu với boss cực khủng: mỗi trận đánh trùm là một bài toán về kỹ năng và phản xạ.",
              "Khám phá thế giới mở hùng vĩ: bản đồ được thiết kế dày đặc bí mật và phần thưởng để khuyến khích người chơi đào sâu.",
            ],
          },
          {
            type: "heading",
            text: "Sự kết hợp giữa nghệ thuật và công nghệ đồ họa trong “Black Myth: Wukong”",
          },
          {
            type: "image",
            url: "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2358720/ss_b153b72aa9e29b2081eaa8cf78f7f4e0dbf32812.jpg",
            alt: "Black Myth Wukong close-up artwork",
          },
          {
            type: "quote",
            text:
              "Một bài article tốt cho game không chỉ kể lại nội dung, mà còn phải làm nổi bật cảm xúc, hình ảnh và nhịp độ chiến đấu ngay từ phần preview đầu tiên.",
          },
        ],
      },
      null,
      2
    );
  }

  function buildGhostArticleJson() {
    return JSON.stringify(
      {
        eyebrow: "Samurai Feature",
        title: "Ghost of Tsushima Director's Cut và nghệ thuật kể chuyện bằng nhịp chiến đấu",
        summary:
          "Ghost of Tsushima Director's Cut đưa người chơi vào hành trình của Jin Sakai với cách kể chuyện điện ảnh, tinh tế và giàu cảm xúc.",
        blocks: [
          {
            type: "image",
            url: "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2215430/header.jpg",
            alt: "Ghost of Tsushima hero banner",
          },
          {
            type: "paragraph",
            text:
              "Thế giới Tsushima được dựng nên bằng sắc lá phong, gió, tuyết và màu trời thay đổi liên tục. Bản Director's Cut bổ sung chiều sâu cho cả phần cốt truyện lẫn trải nghiệm khám phá.",
          },
          {
            type: "list",
            intro: "Điểm mạnh nổi bật khi đưa tựa game này lên storefront:",
            items: [
              "Ảnh hero rất mạnh về mặt nhận diện.",
              "Bài mô tả dễ chia block giữa cốt truyện, chiến đấu và đồ họa.",
              "Media gallery đẹp, rất hợp cho preview dạng báo.",
            ],
          },
        ],
      },
      null,
      2
    );
  }

  function buildForzaArticleJson() {
    return JSON.stringify(
      {
        eyebrow: "Festival Highlight",
        title: "Forza Horizon 5 Premium: tốc độ, bản đồ mở và cảm giác lễ hội bất tận",
        summary:
          "Forza Horizon 5 Premium là kiểu sản phẩm dễ bán nhờ hình ảnh rực rỡ, nhiều phiên bản và chuỗi media rất bắt mắt.",
        blocks: [
          {
            type: "video",
            title: "Forza Horizon 5 Official Launch Trailer",
            url: "https://www.youtube.com/watch?v=FYH9n37B7Yw",
          },
          {
            type: "paragraph",
            text:
              "Game đưa người chơi vào một Mexico đầy màu sắc, nơi mọi cung đường đều có thể trở thành điểm nhấn cho chiến dịch truyền thông và bài viết quảng bá.",
          },
          {
            type: "image",
            url: "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1551360/header.jpg",
            alt: "Forza Horizon 5 premium cover",
          },
        ],
      },
      null,
      2
    );
  }

  function buildSeedState() {
    return {
      categories: [
        {
          categoryId: "7608b992-1842-4e7f-94fd-a00000000001",
          name: "Hành động",
          slug: "hanh-dong",
          status: "Published",
          displayOrder: 1,
          shortDescription: "Nhóm game nhấn mạnh chiến đấu, phản xạ và cao trào.",
          createdAt: "2026-03-28T01:15:00.000Z",
          updatedAt: "2026-03-30T02:35:00.000Z",
        },
        {
          categoryId: "7608b992-1842-4e7f-94fd-a00000000002",
          name: "Nhập vai",
          slug: "nhap-vai",
          status: "Published",
          displayOrder: 2,
          shortDescription: "Tập trung phát triển nhân vật và hành trình khám phá.",
          createdAt: "2026-03-28T01:20:00.000Z",
          updatedAt: "2026-03-30T02:35:00.000Z",
        },
        {
          categoryId: "7608b992-1842-4e7f-94fd-a00000000003",
          name: "Phiêu lưu",
          slug: "phieu-luu",
          status: "Published",
          displayOrder: 3,
          shortDescription: "Thiên về thế giới, cốt truyện và trải nghiệm điện ảnh.",
          createdAt: "2026-03-28T01:25:00.000Z",
          updatedAt: "2026-03-30T02:35:00.000Z",
        },
        {
          categoryId: "7608b992-1842-4e7f-94fd-a00000000004",
          name: "Soulslike",
          slug: "soulslike",
          status: "Published",
          displayOrder: 4,
          shortDescription: "Boss khó, nhịp chiến đấu nặng và yêu cầu phản xạ cao.",
          createdAt: "2026-03-28T01:30:00.000Z",
          updatedAt: "2026-03-30T02:35:00.000Z",
        },
        {
          categoryId: "7608b992-1842-4e7f-94fd-a00000000005",
          name: "Open world",
          slug: "open-world",
          status: "Published",
          displayOrder: 5,
          shortDescription: "Bản đồ rộng, nhiều hoạt động và khám phá tự do.",
          createdAt: "2026-03-28T01:35:00.000Z",
          updatedAt: "2026-03-30T02:35:00.000Z",
        },
        {
          categoryId: "7608b992-1842-4e7f-94fd-a00000000006",
          name: "Single player",
          slug: "single-player",
          status: "Published",
          displayOrder: 6,
          shortDescription: "Tập trung trải nghiệm đơn với mạch nội dung rõ ràng.",
          createdAt: "2026-03-28T01:40:00.000Z",
          updatedAt: "2026-03-30T02:35:00.000Z",
        },
      ],
      games: [
        {
          gameId: "4071d204-22f0-4edb-a100-000000000001",
          name: "Black Myth: Wukong",
          rating: 4.95,
          oldPrice: 1599000,
          newPrice: 249000,
          createdAt: "2026-03-29T02:00:00.000Z",
          updatedAt: "2026-03-30T04:28:00.000Z",
        },
        {
          gameId: "4071d204-22f0-4edb-a100-000000000002",
          name: "Ghost of Tsushima Director's Cut",
          rating: 4.88,
          oldPrice: 1399000,
          newPrice: 219000,
          createdAt: "2026-03-29T02:10:00.000Z",
          updatedAt: "2026-03-30T03:42:00.000Z",
        },
        {
          gameId: "4071d204-22f0-4edb-a100-000000000003",
          name: "Forza Horizon 5 Premium",
          rating: 4.61,
          oldPrice: 1199000,
          newPrice: 289000,
          createdAt: "2026-03-29T02:15:00.000Z",
          updatedAt: "2026-03-30T03:15:00.000Z",
        },
      ],
      gameCategories: [
        {
          gameCategoryId: "c0000000-0000-4000-8000-000000000001",
          gameId: "4071d204-22f0-4edb-a100-000000000001",
          categoryId: "7608b992-1842-4e7f-94fd-a00000000002",
          createdAt: "2026-03-29T02:00:00.000Z",
        },
        {
          gameCategoryId: "c0000000-0000-4000-8000-000000000002",
          gameId: "4071d204-22f0-4edb-a100-000000000001",
          categoryId: "7608b992-1842-4e7f-94fd-a00000000003",
          createdAt: "2026-03-29T02:00:00.000Z",
        },
        {
          gameCategoryId: "c0000000-0000-4000-8000-000000000003",
          gameId: "4071d204-22f0-4edb-a100-000000000001",
          categoryId: "7608b992-1842-4e7f-94fd-a00000000004",
          createdAt: "2026-03-29T02:00:00.000Z",
        },
        {
          gameCategoryId: "c0000000-0000-4000-8000-000000000004",
          gameId: "4071d204-22f0-4edb-a100-000000000002",
          categoryId: "7608b992-1842-4e7f-94fd-a00000000001",
          createdAt: "2026-03-29T02:10:00.000Z",
        },
        {
          gameCategoryId: "c0000000-0000-4000-8000-000000000005",
          gameId: "4071d204-22f0-4edb-a100-000000000002",
          categoryId: "7608b992-1842-4e7f-94fd-a00000000003",
          createdAt: "2026-03-29T02:10:00.000Z",
        },
        {
          gameCategoryId: "c0000000-0000-4000-8000-000000000006",
          gameId: "4071d204-22f0-4edb-a100-000000000003",
          categoryId: "7608b992-1842-4e7f-94fd-a00000000001",
          createdAt: "2026-03-29T02:15:00.000Z",
        },
        {
          gameCategoryId: "c0000000-0000-4000-8000-000000000007",
          gameId: "4071d204-22f0-4edb-a100-000000000003",
          categoryId: "7608b992-1842-4e7f-94fd-a00000000005",
          createdAt: "2026-03-29T02:15:00.000Z",
        },
      ],
      accounts: [
        {
          accountId: "6f30c85c-5316-4d16-a200-000000000001",
          isActive: true,
          isPurchased: true,
          createdAt: "2026-03-29T04:00:00.000Z",
          updatedAt: "2026-03-30T03:40:00.000Z",
        },
        {
          accountId: "6f30c85c-5316-4d16-a200-000000000002",
          isActive: true,
          isPurchased: false,
          createdAt: "2026-03-29T04:10:00.000Z",
          updatedAt: "2026-03-30T03:18:00.000Z",
        },
        {
          accountId: "6f30c85c-5316-4d16-a200-000000000003",
          isActive: true,
          isPurchased: true,
          createdAt: "2026-03-29T04:20:00.000Z",
          updatedAt: "2026-03-30T02:44:00.000Z",
        },
        {
          accountId: "6f30c85c-5316-4d16-a200-000000000004",
          isActive: false,
          isPurchased: false,
          createdAt: "2026-03-29T04:30:00.000Z",
          updatedAt: "2026-03-30T01:52:00.000Z",
        },
      ],
      gameVersions: [
        {
          versionId: "8c2c73cf-7ecb-4d26-a300-000000000001",
          gameId: "4071d204-22f0-4edb-a100-000000000001",
          accountId: "6f30c85c-5316-4d16-a200-000000000001",
          createdAt: "2026-03-29T04:40:00.000Z",
          updatedAt: "2026-03-30T04:12:00.000Z",
          isRemoved: false,
        },
        {
          versionId: "8c2c73cf-7ecb-4d26-a300-000000000002",
          gameId: "4071d204-22f0-4edb-a100-000000000001",
          accountId: "6f30c85c-5316-4d16-a200-000000000002",
          createdAt: "2026-03-29T04:50:00.000Z",
          updatedAt: "2026-03-30T03:55:00.000Z",
          isRemoved: false,
        },
        {
          versionId: "8c2c73cf-7ecb-4d26-a300-000000000003",
          gameId: "4071d204-22f0-4edb-a100-000000000001",
          accountId: null,
          createdAt: "2026-03-29T05:00:00.000Z",
          updatedAt: "2026-03-30T03:10:00.000Z",
          isRemoved: false,
        },
        {
          versionId: "8c2c73cf-7ecb-4d26-a300-000000000004",
          gameId: "4071d204-22f0-4edb-a100-000000000002",
          accountId: "6f30c85c-5316-4d16-a200-000000000003",
          createdAt: "2026-03-29T05:05:00.000Z",
          updatedAt: "2026-03-30T03:00:00.000Z",
          isRemoved: false,
        },
        {
          versionId: "8c2c73cf-7ecb-4d26-a300-000000000005",
          gameId: "4071d204-22f0-4edb-a100-000000000003",
          accountId: "6f30c85c-5316-4d16-a200-000000000004",
          createdAt: "2026-03-29T05:10:00.000Z",
          updatedAt: "2026-03-30T02:10:00.000Z",
          isRemoved: true,
        },
      ],
      gameFiles: [
        {
          fileId: "4fcbd8cb-d2fa-4f27-a400-000000000001",
          accountId: "6f30c85c-5316-4d16-a200-000000000001",
          fileUrl01: "https://download.example.com/wukong/standard/part-01",
          fileUrl02: "https://download.example.com/wukong/standard/part-02",
          fileUrl03: "",
          fileUrl04: "",
          fileUrl05: "",
          fileType: "installer",
          createdAt: "2026-03-29T06:00:00.000Z",
          updatedAt: "2026-03-30T03:48:00.000Z",
          isActive: true,
        },
        {
          fileId: "4fcbd8cb-d2fa-4f27-a400-000000000002",
          accountId: "6f30c85c-5316-4d16-a200-000000000002",
          fileUrl01: "https://download.example.com/wukong/deluxe/full-package",
          fileUrl02: "",
          fileUrl03: "",
          fileUrl04: "",
          fileUrl05: "",
          fileType: "installer",
          createdAt: "2026-03-29T06:05:00.000Z",
          updatedAt: "2026-03-30T03:20:00.000Z",
          isActive: true,
        },
        {
          fileId: "4fcbd8cb-d2fa-4f27-a400-000000000003",
          accountId: "6f30c85c-5316-4d16-a200-000000000003",
          fileUrl01: "https://download.example.com/ghost/standard/full-package",
          fileUrl02: "https://download.example.com/ghost/bonus/soundtrack",
          fileUrl03: "",
          fileUrl04: "",
          fileUrl05: "",
          fileType: "bundle",
          createdAt: "2026-03-29T06:10:00.000Z",
          updatedAt: "2026-03-30T02:50:00.000Z",
          isActive: true,
        },
      ],
      media: [
        {
          mediaId: "f0f80193-3826-4d43-a500-000000000001",
          gameId: "4071d204-22f0-4edb-a100-000000000001",
          url: "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2358720/header.jpg",
          mediaType: "cover",
          createdAt: "2026-03-29T06:30:00.000Z",
          updatedAt: "2026-03-30T04:15:00.000Z",
        },
        {
          mediaId: "f0f80193-3826-4d43-a500-000000000002",
          gameId: "4071d204-22f0-4edb-a100-000000000001",
          url: "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2358720/ss_8626df74b9297b0834caea1ecbcf0f8f6a34f204.jpg",
          mediaType: "gallery",
          createdAt: "2026-03-29T06:31:00.000Z",
          updatedAt: "2026-03-30T04:15:00.000Z",
        },
        {
          mediaId: "f0f80193-3826-4d43-a500-000000000003",
          gameId: "4071d204-22f0-4edb-a100-000000000002",
          url: "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2215430/header.jpg",
          mediaType: "cover",
          createdAt: "2026-03-29T06:34:00.000Z",
          updatedAt: "2026-03-30T03:30:00.000Z",
        },
        {
          mediaId: "f0f80193-3826-4d43-a500-000000000004",
          gameId: "4071d204-22f0-4edb-a100-000000000003",
          url: "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1551360/header.jpg",
          mediaType: "cover",
          createdAt: "2026-03-29T06:36:00.000Z",
          updatedAt: "2026-03-30T02:22:00.000Z",
        },
      ],
      articles: [
        {
          articleId: "d36268d8-d868-4ac8-a600-000000000001",
          gameId: "4071d204-22f0-4edb-a100-000000000001",
          summary:
            "Bài spotlight cho Black Myth: Wukong tập trung vào thần thoại, nhịp chiến đấu và hình ảnh điện ảnh.",
          contentJson: buildWukongArticleJson(),
          createdAt: "2026-03-29T07:10:00.000Z",
          updatedAt: "2026-03-30T04:18:00.000Z",
        },
        {
          articleId: "d36268d8-d868-4ac8-a600-000000000002",
          gameId: "4071d204-22f0-4edb-a100-000000000002",
          summary: "Bài giới thiệu điện ảnh cho Ghost of Tsushima Director's Cut.",
          contentJson: buildGhostArticleJson(),
          createdAt: "2026-03-29T07:20:00.000Z",
          updatedAt: "2026-03-30T03:36:00.000Z",
        },
        {
          articleId: "d36268d8-d868-4ac8-a600-000000000003",
          gameId: "4071d204-22f0-4edb-a100-000000000003",
          summary: "Bài festival highlight cho Forza Horizon 5 Premium.",
          contentJson: buildForzaArticleJson(),
          createdAt: "2026-03-29T07:30:00.000Z",
          updatedAt: "2026-03-30T02:35:00.000Z",
        },
      ],
    };
  }

  function loadState() {
    if (!hasLocalStorage) {
      return buildSeedState();
    }

    try {
      const raw = window.localStorage.getItem(STORAGE_KEY);

      if (!raw) {
        return buildSeedState();
      }

      const parsed = JSON.parse(raw);

      if (
        !parsed ||
        !Array.isArray(parsed.games) ||
        !Array.isArray(parsed.categories) ||
        !Array.isArray(parsed.gameCategories) ||
        !Array.isArray(parsed.accounts) ||
        !Array.isArray(parsed.gameVersions) ||
        !Array.isArray(parsed.gameFiles) ||
        !Array.isArray(parsed.media) ||
        !Array.isArray(parsed.articles)
      ) {
        return buildSeedState();
      }

      return parsed;
    } catch (error) {
      return buildSeedState();
    }
  }

  let state = loadState();
  ui.selectedGameId = state.games[0]?.gameId ?? null;

  function saveState() {
    if (!hasLocalStorage) {
      return;
    }

    window.localStorage.setItem(STORAGE_KEY, JSON.stringify(state));
  }

  function setMessage(text, tone = "info") {
    if (!refs.workspaceMessage) {
      return;
    }

    refs.workspaceMessage.textContent = text;
    refs.workspaceMessage.className = `admin-workspace-message is-visible is-${tone}`;
  }

  function clearMessage() {
    if (!refs.workspaceMessage) {
      return;
    }

    refs.workspaceMessage.textContent = "";
    refs.workspaceMessage.className = "admin-workspace-message";
  }

  function getCategoryName(categoryId) {
    return state.categories.find((category) => category.categoryId === categoryId)?.name ?? "Chưa rõ";
  }

  function getCurrentGame() {
    return state.games.find((game) => game.gameId === ui.selectedGameId) ?? null;
  }

  function getSelectedVersion() {
    return state.gameVersions.find((version) => version.versionId === ui.selectedVersionId) ?? null;
  }

  function getSelectedAccount() {
    return state.accounts.find((account) => account.accountId === ui.selectedAccountId) ?? null;
  }

  function getSelectedFile() {
    return state.gameFiles.find((fileRecord) => fileRecord.fileId === ui.selectedFileId) ?? null;
  }

  function getSelectedMedia() {
    return state.media.find((mediaRecord) => mediaRecord.mediaId === ui.selectedMediaId) ?? null;
  }

  function getArticleByGameId(gameId) {
    return state.articles.find((article) => article.gameId === gameId) ?? null;
  }

  function getGameCategoryIds(gameId) {
    return state.gameCategories
      .filter((item) => item.gameId === gameId)
      .map((item) => item.categoryId);
  }

  function getCategoriesForGame(gameId) {
    return getGameCategoryIds(gameId).map(getCategoryName);
  }

  function getVersionsForGame(gameId) {
    return state.gameVersions.filter((version) => version.gameId === gameId);
  }

  function getLinkedAccountIds(gameId) {
    return [...new Set(getVersionsForGame(gameId).map((version) => version.accountId).filter(Boolean))];
  }

  function getFilesForGame(gameId) {
    const accountIds = new Set(getLinkedAccountIds(gameId));
    return state.gameFiles.filter((fileRecord) => accountIds.has(fileRecord.accountId));
  }

  function getMediaForGame(gameId) {
    return state.media.filter((mediaRecord) => mediaRecord.gameId === gameId);
  }

  function getVisibleVersions() {
    return sortByUpdatedAt(ui.selectedGameId ? getVersionsForGame(ui.selectedGameId) : state.gameVersions);
  }

  function getVisibleAccounts() {
    if (!ui.selectedGameId) {
      return sortByUpdatedAt(state.accounts);
    }

    const linkedIds = new Set(getLinkedAccountIds(ui.selectedGameId));

    return [...state.accounts].sort((left, right) => {
      const leftScore = linkedIds.has(left.accountId) ? 1 : 0;
      const rightScore = linkedIds.has(right.accountId) ? 1 : 0;

      if (leftScore !== rightScore) {
        return rightScore - leftScore;
      }

      return new Date(right.updatedAt) - new Date(left.updatedAt);
    });
  }

  function getVisibleFiles() {
    if (!ui.selectedGameId) {
      return sortByUpdatedAt(state.gameFiles);
    }

    return sortByUpdatedAt(getFilesForGame(ui.selectedGameId));
  }

  function getVisibleMedia() {
    return sortByUpdatedAt(ui.selectedGameId ? getMediaForGame(ui.selectedGameId) : state.media);
  }

  function renderEmptyState(message) {
    return `<div class="admin-empty-state">${escapeHtml(message)}</div>`;
  }

  function syncSearchInputs(value) {
    refs.globalSearch.value = value;
    refs.gameListSearch.value = value;
  }

  function renderCategoryFilterOptions() {
    const currentValue = refs.gameListCategoryFilter.value;
    refs.gameListCategoryFilter.innerHTML = [
      '<option value="">Tất cả</option>',
      ...state.categories
        .slice()
        .sort((left, right) => left.displayOrder - right.displayOrder)
        .map((category) => `<option value="${category.categoryId}">${escapeHtml(category.name)}</option>`),
    ].join("");

    if ([...refs.gameListCategoryFilter.options].some((option) => option.value === currentValue)) {
      refs.gameListCategoryFilter.value = currentValue;
    }
  }

  function renderCategoryChoices() {
    const selectedCategoryIds = new Set(getCurrentGame() ? getGameCategoryIds(getCurrentGame().gameId) : []);

    refs.categoryChoices.innerHTML = state.categories
      .slice()
      .sort((left, right) => left.displayOrder - right.displayOrder)
      .map((category) => {
        const isSelected = selectedCategoryIds.has(category.categoryId);

        return `
          <label class="admin-category-toggle${isSelected ? " is-selected" : ""}" data-category-id="${category.categoryId}">
            <input type="checkbox" value="${category.categoryId}" ${isSelected ? "checked" : ""} />
            <strong>${escapeHtml(category.name)}</strong>
            <span>${escapeHtml(category.shortDescription || "Không có mô tả ngắn")}</span>
          </label>
        `;
      })
      .join("");
    refreshCategoryDraftPreview();
  }

  function refreshCategoryDraftPreview() {
    const checkedInputs = [...refs.categoryChoices.querySelectorAll("input")];
    const selectedNames = checkedInputs
      .filter((input) => input.checked)
      .map((input) => getCategoryName(input.value));

    refs.categoryChoices.querySelectorAll(".admin-category-toggle").forEach((toggle) => {
      const input = toggle.querySelector("input");
      toggle.classList.toggle("is-selected", Boolean(input?.checked));
    });

    refs.selectedCategories.innerHTML = selectedNames.length
      ? selectedNames.map((name) => `<span class="admin-soft-chip is-active">${escapeHtml(name)}</span>`).join("")
      : '<span class="admin-soft-chip">Chưa chọn category</span>';
  }

  function renderWorkspaceStats() {
    const articleReady = state.games.filter((game) => getArticleByGameId(game.gameId)).length;
    const linkedVersions = state.gameVersions.filter((version) => version.accountId).length;

    refs.workspaceStats.innerHTML = `
      <article class="admin-crud-kpi">
        <span>Tổng game</span>
        <strong>${state.games.length}</strong>
        <small>${state.gameCategories.length} liên kết category đang hoạt động</small>
      </article>
      <article class="admin-crud-kpi">
        <span>Version</span>
        <strong>${state.gameVersions.length}</strong>
        <small>${linkedVersions} version đã gắn account</small>
      </article>
      <article class="admin-crud-kpi">
        <span>Account / file</span>
        <strong>${state.accounts.length} / ${state.gameFiles.length}</strong>
        <small>Kho account toàn cục, file bám theo account_id</small>
      </article>
      <article class="admin-crud-kpi">
        <span>Article ready</span>
        <strong>${articleReady}/${state.games.length}</strong>
        <small>${state.media.length} media đang nuôi gallery và preview</small>
      </article>
    `;
  }

  function renderGameSummary() {
    const currentGame = getCurrentGame();

    if (!currentGame) {
      refs.gameSummary.innerHTML = `
        <article class="admin-crud-summary-card">
          <span>Trạng thái form</span>
          <strong>Đang ở chế độ tạo game mới</strong>
        </article>
        <article class="admin-crud-summary-card">
          <span>Category</span>
          <strong>Chưa gắn category nào</strong>
        </article>
        <article class="admin-crud-summary-card">
          <span>Quan hệ</span>
          <strong>Version, media và article sẽ mở sau khi tạo game</strong>
        </article>
        <article class="admin-crud-summary-card">
          <span>Slug preview</span>
          <strong>${escapeHtml(slugify(refs.gameName.value || "game-moi"))}</strong>
        </article>
      `;
      return;
    }

    const versions = getVersionsForGame(currentGame.gameId);
    const accountIds = getLinkedAccountIds(currentGame.gameId);
    const files = getFilesForGame(currentGame.gameId);
    const mediaItems = getMediaForGame(currentGame.gameId);
    const article = getArticleByGameId(currentGame.gameId);

    refs.gameSummary.innerHTML = `
      <article class="admin-crud-summary-card">
        <span>Category đã gắn</span>
        <strong>${getCategoriesForGame(currentGame.gameId).join(", ") || "Chưa có"}</strong>
      </article>
      <article class="admin-crud-summary-card">
        <span>Version / account</span>
        <strong>${versions.length} version, ${accountIds.length} account đang nối</strong>
      </article>
      <article class="admin-crud-summary-card">
        <span>File / media</span>
        <strong>${files.length} file package, ${mediaItems.length} media asset</strong>
      </article>
      <article class="admin-crud-summary-card">
        <span>Article spotlight</span>
        <strong>${article ? "Đã có bài quảng cáo" : "Chưa có article cho game này"}</strong>
      </article>
    `;
  }

  function renderGameForm() {
    const currentGame = getCurrentGame();

    refs.gameId.value = currentGame?.gameId ?? "";
    refs.gameName.value = currentGame?.name ?? "";
    refs.gameRating.value = currentGame?.rating ?? "";
    refs.gameOldPrice.value = currentGame?.oldPrice ?? "";
    refs.gameNewPrice.value = currentGame?.newPrice ?? "";
    refs.gameSlugPreview.value = slugify(currentGame?.name ?? refs.gameName.value ?? "");
    refs.gameCreatedAt.value = formatDate(currentGame?.createdAt);
    refs.gameUpdatedAt.value = formatDate(currentGame?.updatedAt);

    renderCategoryChoices();
    renderGameSummary();
  }

  function getFilteredGames() {
    const keyword = normalizeText(refs.gameListSearch.value);
    const categoryId = refs.gameListCategoryFilter.value;

    return sortByUpdatedAt(state.games).filter((game) => {
      const matchesKeyword =
        !keyword ||
        normalizeText(game.name).includes(keyword) ||
        normalizeText(slugify(game.name)).includes(keyword) ||
        normalizeText(game.gameId).includes(keyword);

      const matchesCategory = !categoryId || getGameCategoryIds(game.gameId).includes(categoryId);

      return matchesKeyword && matchesCategory;
    });
  }

  function renderGameList() {
    const games = getFilteredGames();
    refs.gameCountPill.textContent = `${games.length} record`;

    if (!games.length) {
      refs.gameList.innerHTML = renderEmptyState("Không có game phù hợp với bộ lọc hiện tại.");
      return;
    }

    refs.gameList.innerHTML = games
      .map((game) => {
        const categories = getCategoriesForGame(game.gameId);
        const versions = getVersionsForGame(game.gameId);
        const accountCount = getLinkedAccountIds(game.gameId).length;
        const article = getArticleByGameId(game.gameId);
        const isActive = game.gameId === ui.selectedGameId;

        return `
          <article class="admin-mini-card admin-crud-record admin-game-list-card${isActive ? " is-active" : ""}">
            <div class="admin-record-footer">
              <strong>${escapeHtml(game.name)}</strong>
              <span class="admin-status ${article ? "is-ok" : "is-check"}">${article ? "Article ready" : "Thiếu article"}</span>
            </div>
            <div class="admin-crud-record__slug">${escapeHtml(slugify(game.name))} • ${escapeHtml(shortId(game.gameId))}</div>
            <div class="admin-game-list-price">
              <strong>${escapeHtml(formatCurrency(game.newPrice))}</strong>
              <span>${escapeHtml(formatCurrency(game.oldPrice))}</span>
            </div>
            <div class="admin-chip-row admin-crud-meta admin-game-list-meta">
              ${categories
                .map((category) => `<span class="admin-soft-chip${isActive ? " is-active" : ""}">${escapeHtml(category)}</span>`)
                .join("")}
              <span class="admin-soft-chip">${versions.length} version</span>
              <span class="admin-soft-chip">${accountCount} account</span>
            </div>
            <div class="admin-toolbar-actions admin-crud-item-actions">
              <button class="admin-button admin-button--secondary" type="button" data-select-game="${game.gameId}">
                Chọn
              </button>
              <button class="admin-button admin-button--danger" type="button" data-delete-game="${game.gameId}">
                Xóa
              </button>
            </div>
          </article>
        `;
      })
      .join("");
  }

  function fillSelect(selectElement, options, emptyLabel = "Chưa chọn") {
    selectElement.innerHTML = [
      `<option value="">${escapeHtml(emptyLabel)}</option>`,
      ...options.map((option) => `<option value="${option.value}">${escapeHtml(option.label)}</option>`),
    ].join("");
  }

  function renderVersionForm() {
    const currentGame = getCurrentGame();
    const selectedVersion = getSelectedVersion();

    fillSelect(
      refs.versionAccountId,
      state.accounts.map((account) => ({
        value: account.accountId,
        label: `Account ${shortId(account.accountId)} • ${account.isActive ? "active" : "inactive"}`,
      })),
      "Không gắn account"
    );

    refs.versionId.value = selectedVersion?.versionId ?? "";
    refs.versionGameId.value = currentGame?.gameId ?? "";
    refs.versionAccountId.value = selectedVersion?.accountId ?? "";
    refs.versionIsRemoved.value = String(selectedVersion?.isRemoved ?? false);
    refs.versionCreatedAt.value = formatDate(selectedVersion?.createdAt);
    refs.versionUpdatedAt.value = formatDate(selectedVersion?.updatedAt);
  }

  function renderVersionList() {
    const versions = getVisibleVersions();
    refs.versionCountLabel.textContent = `${versions.length} record`;

    if (!versions.length) {
      refs.versionList.innerHTML = renderEmptyState("Chưa có version nào cho bộ lọc hiện tại.");
      return;
    }

    refs.versionList.innerHTML = versions
      .map((version, index) => {
        const account = state.accounts.find((item) => item.accountId === version.accountId);
        const isActive = version.versionId === ui.selectedVersionId;

        return `
          <article class="admin-entity-card${isActive ? " is-active" : ""}">
            <div class="admin-entity-card__head">
              <div>
                <p class="admin-entity-card__title">Version ${index + 1}</p>
                <div class="admin-entity-card__sub">${escapeHtml(shortId(version.versionId))}</div>
              </div>
              <span class="admin-status ${version.isRemoved ? "is-hold" : "is-ok"}">${version.isRemoved ? "Removed" : "Active"}</span>
            </div>
            <div class="admin-entity-card__meta">
              <span>Game: ${escapeHtml(shortId(version.gameId))}</span>
              <span>Account: ${escapeHtml(account ? shortId(account.accountId) : "NULL")}</span>
              <span>Cập nhật: ${escapeHtml(formatDate(version.updatedAt))}</span>
            </div>
            <div class="admin-entity-card__actions">
              <button class="admin-button admin-button--secondary" type="button" data-select-version="${version.versionId}">Sửa</button>
              <button class="admin-button admin-button--danger" type="button" data-delete-version="${version.versionId}">Xóa</button>
            </div>
          </article>
        `;
      })
      .join("");
  }

  function renderAccountForm() {
    const selectedAccount = getSelectedAccount();

    refs.accountId.value = selectedAccount?.accountId ?? "";
    refs.accountIsActive.value = String(selectedAccount?.isActive ?? true);
    refs.accountIsPurchased.value = String(selectedAccount?.isPurchased ?? false);
    refs.accountCreatedAt.value = formatDate(selectedAccount?.createdAt);
    refs.accountUpdatedAt.value = formatDate(selectedAccount?.updatedAt);
  }

  function renderAccountList() {
    const currentGame = getCurrentGame();
    const linkedIds = new Set(currentGame ? getLinkedAccountIds(currentGame.gameId) : []);
    const accounts = getVisibleAccounts();
    refs.accountCountLabel.textContent = `${accounts.length} record`;

    if (!accounts.length) {
      refs.accountList.innerHTML = renderEmptyState("Kho account đang trống.");
      return;
    }

    refs.accountList.innerHTML = accounts
      .map((account) => {
        const fileCount = state.gameFiles.filter((fileRecord) => fileRecord.accountId === account.accountId).length;
        const versionCount = state.gameVersions.filter((version) => version.accountId === account.accountId).length;
        const isActive = account.accountId === ui.selectedAccountId;
        const linked = linkedIds.has(account.accountId);

        return `
          <article class="admin-entity-card${isActive ? " is-active" : ""}">
            <div class="admin-entity-card__head">
              <div>
                <p class="admin-entity-card__title">Account ${escapeHtml(shortId(account.accountId))}</p>
                <div class="admin-entity-card__sub">${escapeHtml(account.accountId)}</div>
              </div>
              <span class="admin-status ${linked ? "is-ok" : "is-open"}">${linked ? "Linked" : "Pool"}</span>
            </div>
            <div class="admin-entity-card__meta">
              <span>IsActive: ${escapeHtml(String(account.isActive))}</span>
              <span>IsPurchased: ${escapeHtml(String(account.isPurchased))}</span>
              <span>${versionCount} version • ${fileCount} file package</span>
            </div>
            <div class="admin-entity-card__actions">
              <button class="admin-button admin-button--secondary" type="button" data-select-account="${account.accountId}">Sửa</button>
              <button class="admin-button admin-button--danger" type="button" data-delete-account="${account.accountId}">Xóa</button>
            </div>
          </article>
        `;
      })
      .join("");
  }

  function renderFileForm() {
    const selectedFile = getSelectedFile();

    fillSelect(
      refs.fileAccountId,
      state.accounts.map((account) => ({
        value: account.accountId,
        label: `Account ${shortId(account.accountId)}`,
      })),
      "Chọn account"
    );

    refs.fileId.value = selectedFile?.fileId ?? "";
    refs.fileAccountId.value = selectedFile?.accountId ?? "";
    refs.fileType.value = selectedFile?.fileType ?? "";
    refs.fileIsActive.value = String(selectedFile?.isActive ?? true);
    refs.fileUrl01.value = selectedFile?.fileUrl01 ?? "";
    refs.fileUrl02.value = selectedFile?.fileUrl02 ?? "";
    refs.fileUrl03.value = selectedFile?.fileUrl03 ?? "";
    refs.fileUrl04.value = selectedFile?.fileUrl04 ?? "";
    refs.fileUrl05.value = selectedFile?.fileUrl05 ?? "";
  }

  function renderFileList() {
    const files = getVisibleFiles();
    refs.fileCountLabel.textContent = `${files.length} record`;

    if (!files.length) {
      refs.fileList.innerHTML = renderEmptyState("Chưa có file package cho ngữ cảnh đang chọn.");
      return;
    }

    refs.fileList.innerHTML = files
      .map((fileRecord) => {
        const urls = getFileUrls(fileRecord);
        const isActive = fileRecord.fileId === ui.selectedFileId;

        return `
          <article class="admin-entity-card${isActive ? " is-active" : ""}">
            <div class="admin-entity-card__head">
              <div>
                <p class="admin-entity-card__title">${escapeHtml(fileRecord.fileType || "Package")}</p>
                <div class="admin-entity-card__sub">${escapeHtml(shortId(fileRecord.fileId))}</div>
              </div>
              <span class="admin-status ${fileRecord.isActive ? "is-ok" : "is-hold"}">${fileRecord.isActive ? "Ready" : "Inactive"}</span>
            </div>
            <div class="admin-entity-card__meta">
              <span>Account: ${escapeHtml(shortId(fileRecord.accountId))}</span>
              <span>${urls.length} URL đang dùng</span>
              <span>Cập nhật: ${escapeHtml(formatDate(fileRecord.updatedAt))}</span>
            </div>
            <div class="admin-entity-card__urls">
              ${urls.slice(0, 2).map((url) => `<a href="${escapeHtml(url)}" target="_blank" rel="noreferrer">${escapeHtml(url)}</a>`).join("")}
            </div>
            <div class="admin-entity-card__actions">
              <button class="admin-button admin-button--secondary" type="button" data-select-file="${fileRecord.fileId}">Sửa</button>
              <button class="admin-button admin-button--danger" type="button" data-delete-file="${fileRecord.fileId}">Xóa</button>
            </div>
          </article>
        `;
      })
      .join("");
  }

  function renderMediaForm() {
    const currentGame = getCurrentGame();
    const selectedMedia = getSelectedMedia();

    refs.mediaId.value = selectedMedia?.mediaId ?? "";
    refs.mediaGameId.value = currentGame?.gameId ?? selectedMedia?.gameId ?? "";
    refs.mediaType.value = selectedMedia?.mediaType ?? "";
    refs.mediaUrl.value = selectedMedia?.url ?? "";
    refs.mediaCreatedAt.value = formatDate(selectedMedia?.createdAt);
    refs.mediaUpdatedAt.value = formatDate(selectedMedia?.updatedAt);
  }

  function renderMediaList() {
    const mediaItems = getVisibleMedia();
    refs.mediaCountLabel.textContent = `${mediaItems.length} record`;

    if (!mediaItems.length) {
      refs.mediaList.innerHTML = renderEmptyState("Chưa có media cho game hiện tại.");
      return;
    }

    refs.mediaList.innerHTML = mediaItems
      .map((mediaRecord) => {
        const isActive = mediaRecord.mediaId === ui.selectedMediaId;
        const showVideo = isYoutubeUrl(mediaRecord.url) || /trailer|video/i.test(mediaRecord.mediaType || "");

        return `
          <article class="admin-entity-card${isActive ? " is-active" : ""}">
            <div class="admin-entity-card__head">
              <div>
                <p class="admin-entity-card__title">${escapeHtml(mediaRecord.mediaType || "Media")}</p>
                <div class="admin-entity-card__sub">${escapeHtml(shortId(mediaRecord.mediaId))}</div>
              </div>
              <span class="admin-status is-progress">${escapeHtml(shortId(mediaRecord.gameId))}</span>
            </div>
            <div class="admin-entity-card__media${showVideo ? " is-video" : ""}">
              ${showVideo ? '<i class="bi bi-play-circle-fill"></i>' : `<img src="${escapeHtml(mediaRecord.url)}" alt="${escapeHtml(mediaRecord.mediaType || "Media preview")}" />`}
            </div>
            <div class="admin-entity-card__meta">
              <span>URL: ${escapeHtml(mediaRecord.url)}</span>
            </div>
            <div class="admin-entity-card__actions">
              <button class="admin-button admin-button--secondary" type="button" data-select-media="${mediaRecord.mediaId}">Sửa</button>
              <button class="admin-button admin-button--danger" type="button" data-delete-media="${mediaRecord.mediaId}">Xóa</button>
            </div>
          </article>
        `;
      })
      .join("");
  }

  function getArticleBlockMeta(type) {
    return ARTICLE_BLOCK_META[type] ?? ARTICLE_BLOCK_META.paragraph;
  }

  function createEmptyArticleDraft(gameName = "") {
    return {
      eyebrow: "",
      title: String(gameName ?? "").trim(),
      summary: "",
      blocks: [],
    };
  }

  function createArticleBlock(type = "paragraph") {
    const safeType = ARTICLE_BLOCK_META[type] ? type : "paragraph";

    return {
      id: createGuid(),
      type: safeType,
      title: "",
      text: "",
      intro: "",
      items: "",
      url: "",
      alt: "",
    };
  }

  function normalizeArticleBlock(block) {
    const normalized = createArticleBlock(block?.type);
    normalized.title = String(block?.title ?? "");
    normalized.text = String(block?.text ?? "");
    normalized.intro = String(block?.intro ?? "");
    normalized.items = Array.isArray(block?.items)
      ? block.items
          .map((item) => String(item ?? "").trim())
          .filter(Boolean)
          .join("\n")
      : String(block?.items ?? "");
    normalized.url = String(block?.url ?? "");
    normalized.alt = String(block?.alt ?? "");
    return normalized;
  }

  function parseArticleJsonToDraft(rawJson, fallbackGameName = "", summaryFallback = "") {
    const draft = createEmptyArticleDraft(fallbackGameName);
    draft.summary = String(summaryFallback ?? "");

    if (!String(rawJson ?? "").trim()) {
      return draft;
    }

    try {
      const parsed = JSON.parse(rawJson);
      draft.eyebrow = String(parsed?.eyebrow ?? "");
      draft.title = String(parsed?.title ?? fallbackGameName ?? "");
      draft.summary = String(summaryFallback || parsed?.summary || "");
      draft.blocks = Array.isArray(parsed?.blocks)
        ? parsed.blocks.map((block) => normalizeArticleBlock(block))
        : [];
      return draft;
    } catch (error) {
      return draft;
    }
  }

  function splitArticleItems(value) {
    return String(value ?? "")
      .split(/\r?\n/)
      .map((item) => item.trim())
      .filter(Boolean);
  }

  function serializeArticleDraft(draft = ui.articleDraft) {
    const currentGame = getCurrentGame();
    const safeDraft = draft ?? createEmptyArticleDraft(currentGame?.name ?? "");
    const payload = {
      title: safeDraft.title.trim() || currentGame?.name || "Article Draft",
      blocks: safeDraft.blocks.map((block) => {
        if (block.type === "heading") {
          return {
            type: "heading",
            text: block.text.trim(),
          };
        }

        if (block.type === "paragraph") {
          return {
            type: "paragraph",
            text: block.text.trim(),
          };
        }

        if (block.type === "image") {
          const imageBlock = {
            type: "image",
            url: block.url.trim(),
          };

          if (block.alt.trim()) {
            imageBlock.alt = block.alt.trim();
          }

          return imageBlock;
        }

        if (block.type === "video") {
          const videoBlock = {
            type: "video",
            url: block.url.trim(),
          };

          if (block.title.trim()) {
            videoBlock.title = block.title.trim();
          }

          return videoBlock;
        }

        if (block.type === "list") {
          const listBlock = {
            type: "list",
            items: splitArticleItems(block.items),
          };

          if (block.intro.trim()) {
            listBlock.intro = block.intro.trim();
          }

          return listBlock;
        }

        return {
          type: "quote",
          text: block.text.trim(),
        };
      }),
    };

    if (safeDraft.eyebrow.trim()) {
      payload.eyebrow = safeDraft.eyebrow.trim();
    }

    if (safeDraft.summary.trim()) {
      payload.summary = safeDraft.summary.trim();
    }

    return JSON.stringify(payload, null, 2);
  }

  function ensureArticleDraft() {
    if (!ui.articleDraft) {
      ui.articleDraft = createEmptyArticleDraft(getCurrentGame()?.name ?? "");
      ui.articleDraftGameId = getCurrentGame()?.gameId ?? null;
    }

    if (!Array.isArray(ui.articleDraft.blocks)) {
      ui.articleDraft.blocks = [];
    }

    return ui.articleDraft;
  }

  function markArticleDraftDirty() {
    ui.articleDraftDirty = true;
    ui.articleDraftGameId = getCurrentGame()?.gameId ?? null;
  }

  function getSelectedArticleBlock() {
    return ensureArticleDraft().blocks.find((block) => block.id === ui.selectedArticleBlockId) ?? null;
  }

  function getSelectedArticleBlockIndex() {
    return ensureArticleDraft().blocks.findIndex((block) => block.id === ui.selectedArticleBlockId);
  }

  function syncArticleHeaderInputs() {
    const draft = ensureArticleDraft();
    refs.articleEyebrow.value = draft.eyebrow;
    refs.articleTitle.value = draft.title;
    refs.articleSummary.value = draft.summary;
  }

  function syncArticleJsonOutput() {
    refs.articleJson.value = serializeArticleDraft();
  }

  function truncateText(value, length = 88) {
    const safeValue = String(value ?? "").trim();

    if (safeValue.length <= length) {
      return safeValue;
    }

    return `${safeValue.slice(0, length - 1).trimEnd()}…`;
  }

  function getArticleBlockHeadline(block) {
    if (block.type === "list") {
      return truncateText(block.intro || splitArticleItems(block.items)[0] || "Danh sách chưa có nội dung");
    }

    if (block.type === "image") {
      return truncateText(block.alt || "Ảnh chưa có mô tả");
    }

    if (block.type === "video") {
      return truncateText(block.title || "Video chưa đặt tiêu đề");
    }

    return truncateText(block.text || `${getArticleBlockMeta(block.type).label} chưa có nội dung`);
  }

  function getArticleBlockDescription(block) {
    if (block.type === "list") {
      const itemCount = splitArticleItems(block.items).length;
      return itemCount ? `${itemCount} bullet đang có trong box này` : "Mỗi dòng trong form sẽ là một bullet";
    }

    if (block.type === "image") {
      return block.url.trim() ? "Preview sẽ lấy trực tiếp từ link ảnh bạn nhập" : "Hãy nhập link ảnh để box này hiển thị";
    }

    if (block.type === "video") {
      return block.url.trim() ? "Hệ thống sẽ tự đổi sang video embed trong preview" : "Hãy nhập link YouTube hoặc video";
    }

    return "Click để mở và chỉnh nội dung của box này";
  }

  function renderArticleBlockList() {
    const draft = ensureArticleDraft();
    refs.articleBlockCount.textContent = `${draft.blocks.length} box`;

    if (!draft.blocks.length) {
      refs.articleBlockList.innerHTML = `
        <div class="admin-empty-state admin-empty-state--soft">
          Chưa có box nào. Hãy bấm một loại box ở phía trên để bắt đầu dựng bài article.
        </div>
      `;
      return;
    }

    refs.articleBlockList.innerHTML = draft.blocks
      .map((block, index) => {
        const meta = getArticleBlockMeta(block.type);
        const isActive = block.id === ui.selectedArticleBlockId;

        return `
          <button
            class="admin-article-block-card${isActive ? " is-active" : ""}"
            type="button"
            data-select-article-block="${block.id}"
          >
            <span class="admin-article-block-card__head">
              <span class="admin-article-block-card__order">Box ${String(index + 1).padStart(2, "0")}</span>
              <span class="admin-article-block-card__badge">
                <i class="bi ${meta.icon}"></i>
                ${escapeHtml(meta.label)}
              </span>
            </span>
            <strong class="admin-article-block-card__title">${escapeHtml(getArticleBlockHeadline(block))}</strong>
            <span class="admin-article-block-card__desc">${escapeHtml(getArticleBlockDescription(block))}</span>
          </button>
        `;
      })
      .join("");
  }

  function renderArticleBlockEditor() {
    const draft = ensureArticleDraft();
    const block = getSelectedArticleBlock();
    const hasBlock = Boolean(block);
    const activeGroups = new Set(block ? getArticleBlockMeta(block.type).groups : []);

    refs.articleEditorEmpty.classList.toggle("is-hidden", hasBlock);
    refs.articleBlockType.disabled = !hasBlock;
    refs.articleBlockTitle.disabled = !hasBlock;
    refs.articleBlockText.disabled = !hasBlock;
    refs.articleBlockIntro.disabled = !hasBlock;
    refs.articleBlockItems.disabled = !hasBlock;
    refs.articleBlockUrl.disabled = !hasBlock;
    refs.articleBlockAlt.disabled = !hasBlock;
    refs.articleBlockMoveUp.disabled = !hasBlock;
    refs.articleBlockMoveDown.disabled = !hasBlock;
    refs.articleBlockDuplicate.disabled = !hasBlock;
    refs.articleBlockDelete.disabled = !hasBlock;

    refs.articleEditorGroups.forEach((group) => {
      group.classList.toggle("is-hidden", !activeGroups.has(group.dataset.articleEditorGroup));
    });

    if (!hasBlock) {
      refs.articleBlockType.value = "paragraph";
      refs.articleBlockTitle.value = "";
      refs.articleBlockText.value = "";
      refs.articleBlockIntro.value = "";
      refs.articleBlockItems.value = "";
      refs.articleBlockUrl.value = "";
      refs.articleBlockAlt.value = "";
      return;
    }

    refs.articleBlockType.value = block.type;
    refs.articleBlockTitle.value = block.title;
    refs.articleBlockText.value = block.text;
    refs.articleBlockIntro.value = block.intro;
    refs.articleBlockItems.value = block.items;
    refs.articleBlockUrl.value = block.url;
    refs.articleBlockAlt.value = block.alt;

    const selectedIndex = getSelectedArticleBlockIndex();
    refs.articleBlockMoveUp.disabled = selectedIndex <= 0;
    refs.articleBlockMoveDown.disabled = selectedIndex >= draft.blocks.length - 1;
  }

  function renderArticleForm() {
    const currentGame = getCurrentGame();
    const article = currentGame ? getArticleByGameId(currentGame.gameId) : null;
    const currentDraftGameId = currentGame?.gameId ?? null;
    const shouldReuseDraft =
      Boolean(ui.articleDraft) &&
      ui.articleDraftDirty &&
      ui.articleDraftGameId === currentDraftGameId;

    refs.articleId.value = article?.articleId ?? "";
    refs.articleGameId.value = currentGame?.gameId ?? "";
    refs.articleCreatedAt.value = formatDate(article?.createdAt);
    refs.articleUpdatedAt.value = formatDate(article?.updatedAt);

    if (!shouldReuseDraft) {
      ui.articleDraft = article
        ? parseArticleJsonToDraft(article.contentJson, currentGame?.name ?? "", article.summary)
        : createEmptyArticleDraft(currentGame?.name ?? "");
      ui.articleDraftGameId = currentDraftGameId;
      ui.articleDraftDirty = false;
      ui.selectedArticleBlockId = ui.articleDraft.blocks[0]?.id ?? null;
    } else if (!getSelectedArticleBlock()) {
      ui.selectedArticleBlockId = ui.articleDraft.blocks[0]?.id ?? null;
    }

    syncArticleHeaderInputs();
    renderArticleBlockList();
    renderArticleBlockEditor();
    syncArticleJsonOutput();
  }

  function buildArticlePreviewBlock(block) {
    if (!block || typeof block !== "object") {
      return "";
    }

    if (block.type === "heading") {
      return block.text.trim()
        ? `<section class="admin-article-block"><h2>${escapeHtml(block.text)}</h2></section>`
        : "";
    }

    if (block.type === "paragraph") {
      const parts = String(block.text || "")
        .split(/\n{2,}/)
        .map((text) => text.trim())
        .filter(Boolean);

      return parts.length
        ? `
          <section class="admin-article-block">
            ${parts.map((text) => `<p>${escapeHtml(text)}</p>`).join("")}
          </section>
        `
        : "";
    }

    if (block.type === "image") {
      return `
        <section class="admin-article-block">
          ${block.url.trim()
            ? `
              <div class="admin-article-image">
                <img src="${escapeHtml(block.url)}" alt="${escapeHtml(block.alt || "Article image")}" />
              </div>
            `
            : '<div class="admin-article-placeholder">Box hình ảnh này chưa có link nên preview chưa thể hiển thị.</div>'}
        </section>
      `;
    }

    if (block.type === "video") {
      return `
        <section class="admin-article-block admin-article-block--video">
          ${block.title.trim() ? `<h2>${escapeHtml(block.title)}</h2>` : ""}
          ${block.url.trim()
            ? `
              <div class="admin-article-video">
                <iframe src="${escapeHtml(toYoutubeEmbed(block.url))}" title="${escapeHtml(block.title || "Article video")}" loading="lazy" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>
              </div>
            `
            : '<div class="admin-article-placeholder">Box video này chưa có link, hãy dán link YouTube để preview.</div>'}
        </section>
      `;
    }

    if (block.type === "list") {
      const items = splitArticleItems(block.items);

      return `
        <section class="admin-article-block">
          ${block.intro.trim() ? `<p class="admin-article-list-intro">${escapeHtml(block.intro)}</p>` : ""}
          ${items.length
            ? `
              <ul class="admin-article-list">
                ${items.map((item) => `<li>${escapeHtml(item)}</li>`).join("")}
              </ul>
            `
            : '<div class="admin-article-placeholder">Danh sách này chưa có bullet nào.</div>'}
        </section>
      `;
    }

    return block.text.trim()
      ? `
        <section class="admin-article-block">
          <div class="admin-article-quote">${escapeHtml(block.text)}</div>
        </section>
      `
      : "";
  }

  function renderArticlePreview() {
    const currentGame = getCurrentGame();
    const draft = ensureArticleDraft();
    const hasContent = Boolean(
      draft.eyebrow.trim() ||
        draft.title.trim() ||
        draft.summary.trim() ||
        draft.blocks.length
    );

    refs.articlePreviewMeta.innerHTML = currentGame
      ? `Đang preview cho <strong>${escapeHtml(currentGame.name)}</strong> • ${escapeHtml(shortId(currentGame.gameId))}`
      : "Preview đang ở chế độ nháp. Khi chọn game, article này sẽ bám vào game đó.";

    if (!hasContent) {
      refs.articleStatePill.textContent = currentGame ? "empty" : "draft";
      refs.articlePreview.innerHTML = '<div class="admin-article-placeholder">Hãy thêm box nội dung để xem preview bài article ở đây.</div>';
      return;
    }

    const previewTitle = draft.title.trim() || currentGame?.name || "Bài article chưa đặt tiêu đề";
    const previewEyebrow = draft.eyebrow.trim() || "Spotlight article";
    const renderedBlocks = draft.blocks.map((block) => buildArticlePreviewBlock(block)).join("");

    refs.articleStatePill.textContent = currentGame ? "ready" : "draft";
    refs.articlePreview.innerHTML = `
      <article class="admin-article-shell">
        <div class="admin-article-shell__eyebrow">${escapeHtml(previewEyebrow)}</div>
        <h1>${escapeHtml(previewTitle)}</h1>
        ${draft.summary.trim() ? `<div class="admin-article-shell__summary">${escapeHtml(draft.summary)}</div>` : ""}
        ${renderedBlocks || '<div class="admin-article-placeholder">Bài article hiện mới có phần đầu, chưa có box nội dung để hiển thị.</div>'}
      </article>
    `;
  }

  function syncArticleOutputs() {
    renderArticleBlockList();
    syncArticleJsonOutput();
    renderArticlePreview();
  }

  function updateArticleBasicField(fieldName, value) {
    const draft = ensureArticleDraft();
    draft[fieldName] = value;
    markArticleDraftDirty();
    syncArticleOutputs();
  }

  function addArticleBlock(type) {
    const draft = ensureArticleDraft();
    const block = createArticleBlock(type);

    draft.blocks.push(block);
    ui.selectedArticleBlockId = block.id;
    markArticleDraftDirty();
    renderArticleBlockEditor();
    syncArticleOutputs();
    setMessage(`Đã thêm box ${getArticleBlockMeta(type).label.toLowerCase()} vào article.`, "info");
  }

  function selectArticleBlock(blockId) {
    ui.selectedArticleBlockId = blockId;
    renderArticleBlockList();
    renderArticleBlockEditor();
    clearMessage();
  }

  function updateSelectedArticleBlockField(fieldName, value) {
    const block = getSelectedArticleBlock();

    if (!block) {
      return;
    }

    block[fieldName] = value;
    markArticleDraftDirty();
    syncArticleOutputs();
  }

  function changeSelectedArticleBlockType(type) {
    const block = getSelectedArticleBlock();

    if (!block || !ARTICLE_BLOCK_META[type]) {
      return;
    }

    block.type = type;
    markArticleDraftDirty();
    renderArticleBlockEditor();
    syncArticleOutputs();
  }

  function moveSelectedArticleBlock(offset) {
    const draft = ensureArticleDraft();
    const currentIndex = getSelectedArticleBlockIndex();
    const nextIndex = currentIndex + offset;

    if (currentIndex < 0 || nextIndex < 0 || nextIndex >= draft.blocks.length) {
      return;
    }

    const [movedBlock] = draft.blocks.splice(currentIndex, 1);
    draft.blocks.splice(nextIndex, 0, movedBlock);
    markArticleDraftDirty();
    renderArticleBlockEditor();
    syncArticleOutputs();
  }

  function duplicateSelectedArticleBlock() {
    const draft = ensureArticleDraft();
    const currentIndex = getSelectedArticleBlockIndex();
    const selectedBlock = getSelectedArticleBlock();

    if (!selectedBlock || currentIndex < 0) {
      return;
    }

    const duplicatedBlock = {
      ...selectedBlock,
      id: createGuid(),
    };

    draft.blocks.splice(currentIndex + 1, 0, duplicatedBlock);
    ui.selectedArticleBlockId = duplicatedBlock.id;
    markArticleDraftDirty();
    renderArticleBlockEditor();
    syncArticleOutputs();
    setMessage("Đã nhân đôi box đang chọn.", "info");
  }

  function deleteSelectedArticleBlock() {
    const draft = ensureArticleDraft();
    const currentIndex = getSelectedArticleBlockIndex();
    const selectedBlock = getSelectedArticleBlock();

    if (!selectedBlock || currentIndex < 0) {
      return;
    }

    if (!window.confirm(`Xóa box ${getArticleBlockMeta(selectedBlock.type).label.toLowerCase()} đang chọn?`)) {
      return;
    }

    draft.blocks.splice(currentIndex, 1);
    ui.selectedArticleBlockId = draft.blocks[currentIndex]?.id ?? draft.blocks[currentIndex - 1]?.id ?? null;
    markArticleDraftDirty();
    renderArticleBlockEditor();
    syncArticleOutputs();
    setMessage("Đã xóa box khỏi article.", "info");
  }

  function copyArticleJson() {
    const rawJson = refs.articleJson.value.trim();

    if (!rawJson) {
      setMessage("Không có JSON để sao chép.", "danger");
      return;
    }

    const fallbackCopy = () => {
      refs.articleJson.focus();
      refs.articleJson.select();

      try {
        const copied = document.execCommand("copy");
        setMessage(copied ? "Đã sao chép content_json." : "Trình duyệt không cho phép sao chép tự động.", copied ? "success" : "danger");
      } catch (error) {
        setMessage("Không thể sao chép JSON tự động trên trình duyệt này.", "danger");
      }
    };

    if (navigator.clipboard && window.isSecureContext) {
      navigator.clipboard
        .writeText(rawJson)
        .then(() => {
          setMessage("Đã sao chép content_json.", "success");
        })
        .catch(() => {
          fallbackCopy();
        });
      return;
    }

    fallbackCopy();
  }

  function saveArticle() {
    const currentGame = getCurrentGame();

    if (!currentGame) {
      setMessage("Hãy chọn game trước khi lưu article.", "danger");
      return;
    }

    const draft = ensureArticleDraft();

    if (!draft.blocks.length) {
      setMessage("Article cần ít nhất 1 box nội dung trước khi lưu.", "danger");
      return;
    }

    const rawJson = serializeArticleDraft(draft);
    const timestamp = nowIso();
    const existing = getArticleByGameId(currentGame.gameId);

    if (existing) {
      existing.summary = draft.summary.trim();
      existing.contentJson = rawJson;
      existing.updatedAt = timestamp;
      ui.articleDraftDirty = false;
      ui.articleDraftGameId = currentGame.gameId;
      persistAndRefresh(`Đã cập nhật article cho ${currentGame.name}.`);
      return;
    }

    state.articles.unshift({
      articleId: createGuid(),
      gameId: currentGame.gameId,
      summary: draft.summary.trim(),
      contentJson: rawJson,
      createdAt: timestamp,
      updatedAt: timestamp,
    });
    ui.articleDraftDirty = false;
    ui.articleDraftGameId = currentGame.gameId;
    persistAndRefresh(`Đã tạo article mới cho ${currentGame.name}.`);
  }

  function deleteArticle() {
    const currentGame = getCurrentGame();

    if (!currentGame) {
      setMessage("Hãy chọn game trước khi xóa article.", "danger");
      return;
    }

    const article = getArticleByGameId(currentGame.gameId);

    if (!article) {
      ui.articleDraft = createEmptyArticleDraft(currentGame.name);
      ui.selectedArticleBlockId = null;
      ui.articleDraftGameId = currentGame.gameId;
      ui.articleDraftDirty = true;
      syncArticleHeaderInputs();
      renderArticleBlockEditor();
      syncArticleOutputs();
      setMessage("Game hiện tại chưa có article để xóa.", "danger");
      return;
    }

    if (!window.confirm(`Xóa article của game "${currentGame.name}"?`)) {
      return;
    }

    state.articles = state.articles.filter((item) => item.articleId !== article.articleId);
    persistAndRefresh(`Đã xóa article của ${currentGame.name}.`, "info");
  }

  function loadSampleArticle() {
    const currentGame = getCurrentGame();
    ui.articleDraft = parseArticleJsonToDraft(
      buildWukongArticleJson(),
      currentGame?.name ?? "Black Myth: Wukong"
    );
    ui.selectedArticleBlockId = ui.articleDraft.blocks[0]?.id ?? null;
    ui.articleDraftGameId = currentGame?.gameId ?? null;
    ui.articleDraftDirty = true;
    syncArticleHeaderInputs();
    renderArticleBlockEditor();
    syncArticleOutputs();
    setMessage("Đã nạp mẫu Wukong vào builder article.", "info");
  }

  function renderAll() {
    renderCategoryFilterOptions();
    renderWorkspaceStats();
    renderGameForm();
    renderGameList();
    renderVersionForm();
    renderVersionList();
    renderAccountForm();
    renderAccountList();
    renderFileForm();
    renderFileList();
    renderMediaForm();
    renderMediaList();
    renderArticleForm();
    renderArticlePreview();
  }

  function setGameCategories(gameId, categoryIds) {
    state.gameCategories = state.gameCategories.filter((item) => item.gameId !== gameId);

    categoryIds.forEach((categoryId) => {
      state.gameCategories.push({
        gameCategoryId: createGuid(),
        gameId,
        categoryId,
        createdAt: nowIso(),
      });
    });
  }

  function collectSelectedCategoryIds() {
    return [...refs.categoryChoices.querySelectorAll("input:checked")].map((input) => input.value);
  }

  function setActiveGame(gameId) {
    ui.selectedGameId = gameId;
    ui.selectedVersionId = null;
    ui.selectedAccountId = null;
    ui.selectedFileId = null;
    ui.selectedMediaId = null;
    ui.selectedArticleBlockId = null;
    ui.articleDraft = null;
    ui.articleDraftGameId = null;
    ui.articleDraftDirty = false;
  }

  function persistAndRefresh(message, tone = "success") {
    saveState();
    renderAll();
    setMessage(message, tone);
  }

  function resetGameForm() {
    setActiveGame(null);
    renderAll();
    setMessage("Form game đã được làm mới để tạo record mới.", "info");
  }

  function createGame() {
    const name = refs.gameName.value.trim();

    if (!name) {
      setMessage("Tên game là bắt buộc trước khi tạo record mới.", "danger");
      return;
    }

    const gameId = createGuid();
    const timestamp = nowIso();

    state.games.unshift({
      gameId,
      name,
      rating: toNumber(refs.gameRating.value),
      oldPrice: toNumber(refs.gameOldPrice.value),
      newPrice: toNumber(refs.gameNewPrice.value),
      createdAt: timestamp,
      updatedAt: timestamp,
    });

    setGameCategories(gameId, collectSelectedCategoryIds());
    setActiveGame(gameId);
    persistAndRefresh(`Đã tạo game mới: ${name}.`);
  }

  function updateGame() {
    const currentGame = getCurrentGame();

    if (!currentGame) {
      setMessage("Bạn đang ở chế độ tạo mới. Hãy bấm 'Tạo game' thay vì cập nhật.", "danger");
      return;
    }

    const name = refs.gameName.value.trim();

    if (!name) {
      setMessage("Tên game không được để trống.", "danger");
      return;
    }

    currentGame.name = name;
    currentGame.rating = toNumber(refs.gameRating.value);
    currentGame.oldPrice = toNumber(refs.gameOldPrice.value);
    currentGame.newPrice = toNumber(refs.gameNewPrice.value);
    currentGame.updatedAt = nowIso();

    setGameCategories(currentGame.gameId, collectSelectedCategoryIds());
    persistAndRefresh(`Đã cập nhật game: ${currentGame.name}.`);
  }

  function deleteGame(gameId = ui.selectedGameId) {
    const game = state.games.find((item) => item.gameId === gameId);

    if (!game) {
      setMessage("Không tìm thấy game để xóa.", "danger");
      return;
    }

    if (!window.confirm(`Xóa game "${game.name}" cùng version, media và article liên quan?`)) {
      return;
    }

    state.games = state.games.filter((item) => item.gameId !== gameId);
    state.gameCategories = state.gameCategories.filter((item) => item.gameId !== gameId);
    state.gameVersions = state.gameVersions.filter((item) => item.gameId !== gameId);
    state.media = state.media.filter((item) => item.gameId !== gameId);
    state.articles = state.articles.filter((item) => item.gameId !== gameId);

    setActiveGame(state.games[0]?.gameId ?? null);
    persistAndRefresh(`Đã xóa game: ${game.name}.`, "info");
  }

  function resetVersionForm() {
    ui.selectedVersionId = null;
    renderVersionForm();
    renderVersionList();
    setMessage("Form version đã được làm mới.", "info");
  }

  function createVersion() {
    const currentGame = getCurrentGame();

    if (!currentGame) {
      setMessage("Hãy chọn hoặc tạo game trước khi thêm version.", "danger");
      return;
    }

    const timestamp = nowIso();
    const record = {
      versionId: createGuid(),
      gameId: currentGame.gameId,
      accountId: refs.versionAccountId.value || null,
      createdAt: timestamp,
      updatedAt: timestamp,
      isRemoved: toBoolean(refs.versionIsRemoved.value),
    };

    state.gameVersions.unshift(record);
    ui.selectedVersionId = record.versionId;
    persistAndRefresh(`Đã tạo version mới cho ${currentGame.name}.`);
  }

  function updateVersion() {
    const version = getSelectedVersion();

    if (!version) {
      setMessage("Hãy chọn version cần cập nhật trước.", "danger");
      return;
    }

    version.accountId = refs.versionAccountId.value || null;
    version.isRemoved = toBoolean(refs.versionIsRemoved.value);
    version.updatedAt = nowIso();
    persistAndRefresh(`Đã cập nhật version ${shortId(version.versionId)}.`);
  }

  function deleteVersion(versionId = ui.selectedVersionId) {
    const version = state.gameVersions.find((item) => item.versionId === versionId);

    if (!version) {
      setMessage("Không tìm thấy version để xóa.", "danger");
      return;
    }

    if (!window.confirm(`Xóa version ${shortId(version.versionId)}?`)) {
      return;
    }

    state.gameVersions = state.gameVersions.filter((item) => item.versionId !== versionId);
    ui.selectedVersionId = null;
    persistAndRefresh(`Đã xóa version ${shortId(version.versionId)}.`, "info");
  }

  function resetAccountForm() {
    ui.selectedAccountId = null;
    renderAccountForm();
    renderAccountList();
    setMessage("Form account đã được làm mới.", "info");
  }

  function createAccount() {
    const timestamp = nowIso();
    const record = {
      accountId: createGuid(),
      isActive: toBoolean(refs.accountIsActive.value),
      isPurchased: toBoolean(refs.accountIsPurchased.value),
      createdAt: timestamp,
      updatedAt: timestamp,
    };

    state.accounts.unshift(record);
    ui.selectedAccountId = record.accountId;
    persistAndRefresh(`Đã tạo account ${shortId(record.accountId)}.`);
  }

  function updateAccount() {
    const account = getSelectedAccount();

    if (!account) {
      setMessage("Hãy chọn account cần cập nhật trước.", "danger");
      return;
    }

    account.isActive = toBoolean(refs.accountIsActive.value);
    account.isPurchased = toBoolean(refs.accountIsPurchased.value);
    account.updatedAt = nowIso();
    persistAndRefresh(`Đã cập nhật account ${shortId(account.accountId)}.`);
  }

  function deleteAccount(accountId = ui.selectedAccountId) {
    const account = state.accounts.find((item) => item.accountId === accountId);

    if (!account) {
      setMessage("Không tìm thấy account để xóa.", "danger");
      return;
    }

    if (!window.confirm(`Xóa account ${shortId(account.accountId)} và toàn bộ file của account này?`)) {
      return;
    }

    state.accounts = state.accounts.filter((item) => item.accountId !== accountId);
    state.gameVersions = state.gameVersions.map((version) =>
      version.accountId === accountId
        ? { ...version, accountId: null, updatedAt: nowIso() }
        : version
    );
    state.gameFiles = state.gameFiles.filter((fileRecord) => fileRecord.accountId !== accountId);
    ui.selectedAccountId = null;
    persistAndRefresh(`Đã xóa account ${shortId(account.accountId)}.`, "info");
  }

  function resetFileForm() {
    ui.selectedFileId = null;
    renderFileForm();
    renderFileList();
    setMessage("Form file đã được làm mới.", "info");
  }

  function createFile() {
    const accountId = refs.fileAccountId.value;

    if (!accountId) {
      setMessage("Hãy chọn account trước khi tạo file package.", "danger");
      return;
    }

    const timestamp = nowIso();
    const record = {
      fileId: createGuid(),
      accountId,
      fileUrl01: refs.fileUrl01.value.trim(),
      fileUrl02: refs.fileUrl02.value.trim(),
      fileUrl03: refs.fileUrl03.value.trim(),
      fileUrl04: refs.fileUrl04.value.trim(),
      fileUrl05: refs.fileUrl05.value.trim(),
      fileType: refs.fileType.value.trim(),
      createdAt: timestamp,
      updatedAt: timestamp,
      isActive: toBoolean(refs.fileIsActive.value),
    };

    state.gameFiles.unshift(record);
    ui.selectedFileId = record.fileId;
    persistAndRefresh(`Đã tạo file package ${shortId(record.fileId)}.`);
  }

  function updateFile() {
    const fileRecord = getSelectedFile();

    if (!fileRecord) {
      setMessage("Hãy chọn file package cần cập nhật trước.", "danger");
      return;
    }

    fileRecord.accountId = refs.fileAccountId.value || fileRecord.accountId;
    fileRecord.fileType = refs.fileType.value.trim();
    fileRecord.fileUrl01 = refs.fileUrl01.value.trim();
    fileRecord.fileUrl02 = refs.fileUrl02.value.trim();
    fileRecord.fileUrl03 = refs.fileUrl03.value.trim();
    fileRecord.fileUrl04 = refs.fileUrl04.value.trim();
    fileRecord.fileUrl05 = refs.fileUrl05.value.trim();
    fileRecord.isActive = toBoolean(refs.fileIsActive.value);
    fileRecord.updatedAt = nowIso();
    persistAndRefresh(`Đã cập nhật file package ${shortId(fileRecord.fileId)}.`);
  }

  function deleteFile(fileId = ui.selectedFileId) {
    const fileRecord = state.gameFiles.find((item) => item.fileId === fileId);

    if (!fileRecord) {
      setMessage("Không tìm thấy file package để xóa.", "danger");
      return;
    }

    if (!window.confirm(`Xóa file package ${shortId(fileRecord.fileId)}?`)) {
      return;
    }

    state.gameFiles = state.gameFiles.filter((item) => item.fileId !== fileId);
    ui.selectedFileId = null;
    persistAndRefresh(`Đã xóa file package ${shortId(fileRecord.fileId)}.`, "info");
  }

  function resetMediaForm() {
    ui.selectedMediaId = null;
    renderMediaForm();
    renderMediaList();
    setMessage("Form media đã được làm mới.", "info");
  }

  function createMedia() {
    const currentGame = getCurrentGame();

    if (!currentGame) {
      setMessage("Hãy chọn game trước khi thêm media.", "danger");
      return;
    }

    if (!refs.mediaUrl.value.trim()) {
      setMessage("URL media là bắt buộc.", "danger");
      return;
    }

    const timestamp = nowIso();
    const record = {
      mediaId: createGuid(),
      gameId: currentGame.gameId,
      url: refs.mediaUrl.value.trim(),
      mediaType: refs.mediaType.value.trim(),
      createdAt: timestamp,
      updatedAt: timestamp,
    };

    state.media.unshift(record);
    ui.selectedMediaId = record.mediaId;
    persistAndRefresh(`Đã tạo media mới cho ${currentGame.name}.`);
  }

  function updateMedia() {
    const mediaRecord = getSelectedMedia();

    if (!mediaRecord) {
      setMessage("Hãy chọn media cần cập nhật trước.", "danger");
      return;
    }

    mediaRecord.mediaType = refs.mediaType.value.trim();
    mediaRecord.url = refs.mediaUrl.value.trim();
    mediaRecord.updatedAt = nowIso();
    persistAndRefresh(`Đã cập nhật media ${shortId(mediaRecord.mediaId)}.`);
  }

  function deleteMedia(mediaId = ui.selectedMediaId) {
    const mediaRecord = state.media.find((item) => item.mediaId === mediaId);

    if (!mediaRecord) {
      setMessage("Không tìm thấy media để xóa.", "danger");
      return;
    }

    if (!window.confirm(`Xóa media ${shortId(mediaRecord.mediaId)}?`)) {
      return;
    }

    state.media = state.media.filter((item) => item.mediaId !== mediaId);
    ui.selectedMediaId = null;
    persistAndRefresh(`Đã xóa media ${shortId(mediaRecord.mediaId)}.`, "info");
  }

  function handleListClick(event) {
    const gameSelect = event.target.closest("[data-select-game]");
    const gameDelete = event.target.closest("[data-delete-game]");
    const versionSelect = event.target.closest("[data-select-version]");
    const versionDelete = event.target.closest("[data-delete-version]");
    const accountSelect = event.target.closest("[data-select-account]");
    const accountDelete = event.target.closest("[data-delete-account]");
    const fileSelect = event.target.closest("[data-select-file]");
    const fileDelete = event.target.closest("[data-delete-file]");
    const mediaSelect = event.target.closest("[data-select-media]");
    const mediaDelete = event.target.closest("[data-delete-media]");

    if (gameSelect) {
      setActiveGame(gameSelect.dataset.selectGame);
      renderAll();
      clearMessage();
      return;
    }

    if (gameDelete) {
      deleteGame(gameDelete.dataset.deleteGame);
      return;
    }

    if (versionSelect) {
      ui.selectedVersionId = versionSelect.dataset.selectVersion;
      renderVersionForm();
      renderVersionList();
      clearMessage();
      return;
    }

    if (versionDelete) {
      deleteVersion(versionDelete.dataset.deleteVersion);
      return;
    }

    if (accountSelect) {
      ui.selectedAccountId = accountSelect.dataset.selectAccount;
      renderAccountForm();
      renderAccountList();
      clearMessage();
      return;
    }

    if (accountDelete) {
      deleteAccount(accountDelete.dataset.deleteAccount);
      return;
    }

    if (fileSelect) {
      ui.selectedFileId = fileSelect.dataset.selectFile;
      renderFileForm();
      renderFileList();
      clearMessage();
      return;
    }

    if (fileDelete) {
      deleteFile(fileDelete.dataset.deleteFile);
      return;
    }

    if (mediaSelect) {
      ui.selectedMediaId = mediaSelect.dataset.selectMedia;
      renderMediaForm();
      renderMediaList();
      clearMessage();
      return;
    }

    if (mediaDelete) {
      deleteMedia(mediaDelete.dataset.deleteMedia);
    }
  }

  function bindEvents() {
    refs.globalSearch.addEventListener("input", (event) => {
      syncSearchInputs(event.target.value);
      renderGameList();
    });

    refs.gameListSearch.addEventListener("input", (event) => {
      syncSearchInputs(event.target.value);
      renderGameList();
    });

    refs.gameListCategoryFilter.addEventListener("change", () => {
      renderGameList();
    });

    refs.categoryChoices.addEventListener("change", () => {
      refreshCategoryDraftPreview();
    });

    refs.gameName.addEventListener("input", () => {
      refs.gameSlugPreview.value = slugify(refs.gameName.value);
      if (!getCurrentGame()) {
        renderGameSummary();
      }
    });

    refs.articleEyebrow.addEventListener("input", (event) => {
      updateArticleBasicField("eyebrow", event.target.value);
    });

    refs.articleTitle.addEventListener("input", (event) => {
      updateArticleBasicField("title", event.target.value);
    });

    refs.articleSummary.addEventListener("input", (event) => {
      updateArticleBasicField("summary", event.target.value);
    });

    refs.workspaceNewGame.addEventListener("click", resetGameForm);
    refs.workspaceResetSeed.addEventListener("click", () => {
      if (!window.confirm("Khôi phục toàn bộ dữ liệu mẫu cho workspace này?")) {
        return;
      }

      state = buildSeedState();
      setActiveGame(state.games[0]?.gameId ?? null);
      persistAndRefresh("Đã khôi phục dữ liệu mẫu mặc định.", "info");
    });

    refs.gameCreate.addEventListener("click", createGame);
    refs.gameUpdate.addEventListener("click", updateGame);
    refs.gameDelete.addEventListener("click", () => deleteGame());
    refs.gameResetForm.addEventListener("click", resetGameForm);

    refs.versionCreate.addEventListener("click", createVersion);
    refs.versionUpdate.addEventListener("click", updateVersion);
    refs.versionDelete.addEventListener("click", () => deleteVersion());
    refs.versionReset.addEventListener("click", resetVersionForm);

    refs.accountCreate.addEventListener("click", createAccount);
    refs.accountUpdate.addEventListener("click", updateAccount);
    refs.accountDelete.addEventListener("click", () => deleteAccount());
    refs.accountReset.addEventListener("click", resetAccountForm);

    refs.fileCreate.addEventListener("click", createFile);
    refs.fileUpdate.addEventListener("click", updateFile);
    refs.fileDelete.addEventListener("click", () => deleteFile());
    refs.fileReset.addEventListener("click", resetFileForm);

    refs.mediaCreate.addEventListener("click", createMedia);
    refs.mediaUpdate.addEventListener("click", updateMedia);
    refs.mediaDelete.addEventListener("click", () => deleteMedia());
    refs.mediaReset.addEventListener("click", resetMediaForm);

    refs.articleAddButtons.forEach((button) => {
      button.addEventListener("click", () => {
        addArticleBlock(button.dataset.articleAddBlock);
      });
    });

    refs.articleBlockList.addEventListener("click", (event) => {
      const blockButton = event.target.closest("[data-select-article-block]");

      if (!blockButton) {
        return;
      }

      selectArticleBlock(blockButton.dataset.selectArticleBlock);
    });

    refs.articleBlockType.addEventListener("change", (event) => {
      changeSelectedArticleBlockType(event.target.value);
    });

    refs.articleBlockTitle.addEventListener("input", (event) => {
      updateSelectedArticleBlockField("title", event.target.value);
    });

    refs.articleBlockText.addEventListener("input", (event) => {
      updateSelectedArticleBlockField("text", event.target.value);
    });

    refs.articleBlockIntro.addEventListener("input", (event) => {
      updateSelectedArticleBlockField("intro", event.target.value);
    });

    refs.articleBlockItems.addEventListener("input", (event) => {
      updateSelectedArticleBlockField("items", event.target.value);
    });

    refs.articleBlockUrl.addEventListener("input", (event) => {
      updateSelectedArticleBlockField("url", event.target.value);
    });

    refs.articleBlockAlt.addEventListener("input", (event) => {
      updateSelectedArticleBlockField("alt", event.target.value);
    });

    refs.articleBlockMoveUp.addEventListener("click", () => {
      moveSelectedArticleBlock(-1);
    });

    refs.articleBlockMoveDown.addEventListener("click", () => {
      moveSelectedArticleBlock(1);
    });

    refs.articleBlockDuplicate.addEventListener("click", duplicateSelectedArticleBlock);
    refs.articleBlockDelete.addEventListener("click", deleteSelectedArticleBlock);

    refs.articleFormat.addEventListener("click", copyArticleJson);
    refs.articleLoadSample.addEventListener("click", loadSampleArticle);
    refs.articleDelete.addEventListener("click", deleteArticle);
    refs.articleSave.addEventListener("click", saveArticle);

    refs.gameList.addEventListener("click", handleListClick);
    refs.versionList.addEventListener("click", handleListClick);
    refs.accountList.addEventListener("click", handleListClick);
    refs.fileList.addEventListener("click", handleListClick);
    refs.mediaList.addEventListener("click", handleListClick);
  }

  bindEvents();
  renderAll();
})();
