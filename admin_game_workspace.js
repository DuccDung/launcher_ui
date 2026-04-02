const STORE_GAMES_KEY = "nestg-admin-store-games";
const defaultPreviewImage = "./assets/img/g_item_02.png";

const workspaceElements = {
  steamAppIdInput: document.getElementById("steamAppIdInput"),
  gameStatusInput: document.getElementById("gameStatusInput"),
  gameTitleInput: document.getElementById("gameTitleInput"),
  gameSlugInput: document.getElementById("gameSlugInput"),
  globalDiscountInput: document.getElementById("globalDiscountInput"),
  versionStandardEnabled: document.getElementById("versionStandardEnabled"),
  versionStandardName: document.getElementById("versionStandardName"),
  versionStandardPrice: document.getElementById("versionStandardPrice"),
  versionFullEnabled: document.getElementById("versionFullEnabled"),
  versionFullName: document.getElementById("versionFullName"),
  versionFullPrice: document.getElementById("versionFullPrice"),
  steamFetchButton: document.getElementById("steamFetchButton"),
  steamFetchStatus: document.getElementById("steamFetchStatus"),
  saveGameButton: document.getElementById("saveGameButton"),
  resetFormButton: document.getElementById("resetFormButton"),
  deleteGameButton: document.getElementById("deleteGameButton"),
  storeKeywordInput: document.getElementById("storeKeywordInput"),
  storeStatusFilter: document.getElementById("storeStatusFilter"),
  storeGameList: document.getElementById("storeGameList"),
  storeListPill: document.getElementById("storeListPill"),
  steamPreviewImage: document.getElementById("steamPreviewImage"),
  steamPreviewTitle: document.getElementById("steamPreviewTitle"),
  steamPreviewMeta: document.getElementById("steamPreviewMeta"),
  steamPreviewTags: document.getElementById("steamPreviewTags"),
  steamPreviewStatus: document.getElementById("steamPreviewStatus"),
  steamOriginalPrice: document.getElementById("steamOriginalPrice"),
  steamOriginalPriceNote: document.getElementById("steamOriginalPriceNote"),
  steamSalePrice: document.getElementById("steamSalePrice"),
  steamSalePriceNote: document.getElementById("steamSalePriceNote"),
  storeDiscountPreview: document.getElementById("storeDiscountPreview"),
  storeFinalPrice: document.getElementById("storeFinalPrice"),
  storeFinalPriceNote: document.getElementById("storeFinalPriceNote"),
};

let steamDraft = createEmptySteamDraft();
let storeGames = loadStoreGames();
let selectedRecordId = null;
let slugTouched = false;
let fullPriceTouched = false;

function createEmptySteamDraft() {
  return {
    appId: "",
    name: "",
    developers: [],
    publishers: [],
    genres: [],
    releaseDate: "",
    headerImage: defaultPreviewImage,
    originalPriceValue: 0,
    salePriceValue: 0,
    originalPriceText: "0 đ",
    salePriceText: "0 đ",
    isFree: false,
  };
}

function loadStoreGames() {
  try {
    const raw = window.localStorage.getItem(STORE_GAMES_KEY);
    if (raw) {
      const parsed = JSON.parse(raw);
      if (Array.isArray(parsed)) {
        return parsed;
      }
    }
  } catch {
    // Ignore malformed localStorage.
  }

  return [];
}

function saveStoreGames() {
  window.localStorage.setItem(STORE_GAMES_KEY, JSON.stringify(storeGames));
}

function createId() {
  return `game-${Date.now()}-${Math.random().toString(16).slice(2, 8)}`;
}

function clampNumber(value, min, max) {
  const numericValue = Number.parseFloat(value);
  if (!Number.isFinite(numericValue)) {
    return min;
  }

  return Math.min(max, Math.max(min, numericValue));
}

function parseMoneyInput(value) {
  const numericValue = Number.parseFloat(value);
  return Number.isFinite(numericValue) ? Math.max(0, numericValue) : 0;
}

function parseCurrencyInput(value) {
  const normalizedValue = String(value || "").replace(/[^\d]/g, "");
  return normalizedValue ? Number.parseInt(normalizedValue, 10) : 0;
}

function formatMoney(value, currency = "VND") {
  const safeValue = Number.isFinite(value) ? value : 0;

  try {
    return new Intl.NumberFormat(currency === "VND" ? "vi-VN" : "en-US", {
      style: "currency",
      currency,
      maximumFractionDigits: currency === "VND" ? 0 : 2,
    }).format(safeValue);
  } catch {
    return `${Math.round(safeValue).toLocaleString("vi-VN")} đ`;
  }
}

function normalizeSteamAmount(value) {
  const numericValue = Number(value);
  if (!Number.isFinite(numericValue)) {
    return 0;
  }

  return numericValue / 100;
}

function slugify(value) {
  return String(value || "")
    .toLowerCase()
    .normalize("NFD")
    .replace(/[\u0300-\u036f]/g, "")
    .replace(/đ/g, "d")
    .replace(/[^a-z0-9]+/g, "-")
    .replace(/^-+|-+$/g, "")
    .replace(/-{2,}/g, "-");
}

function escapeHtml(value) {
  return String(value)
    .replace(/&/g, "&amp;")
    .replace(/</g, "&lt;")
    .replace(/>/g, "&gt;")
    .replace(/"/g, "&quot;")
    .replace(/'/g, "&#39;");
}

function applyDiscount(amount, discountPercent) {
  const normalizedAmount = Number.isFinite(amount) ? amount : 0;
  const normalizedDiscount = clampNumber(discountPercent, 0, 100);
  return Math.round(normalizedAmount * (1 - normalizedDiscount / 100));
}

function setFetchStatus(message, state = "idle") {
  workspaceElements.steamFetchStatus.textContent = message;
  workspaceElements.steamFetchStatus.className = `admin-game-fetch-status is-${state}`;
}

function getVersionState() {
  const baseSteamPrice = steamDraft.salePriceValue || 0;
  const storeDiscount = clampNumber(workspaceElements.globalDiscountInput.value, 0, 100);
  const standardPriceValue = applyDiscount(baseSteamPrice, storeDiscount);
  const defaultFullPriceValue = standardPriceValue;
  const fullPriceValue = fullPriceTouched
    ? parseCurrencyInput(workspaceElements.versionFullPrice.value)
    : defaultFullPriceValue;

  return {
    storeDiscount,
    standardVersion: {
      code: "standard",
      enabled: workspaceElements.versionStandardEnabled.checked,
      name: workspaceElements.versionStandardName.value.trim() || "Bản thường",
      finalPriceValue: standardPriceValue,
      finalPriceText: formatMoney(standardPriceValue, "VND"),
    },
    fullVersion: {
      code: "full_dlc",
      enabled: workspaceElements.versionFullEnabled.checked,
      name: workspaceElements.versionFullName.value.trim() || "Bản full DLC",
      finalPriceValue: fullPriceValue,
      finalPriceText: formatMoney(fullPriceValue, "VND"),
    },
  };
}

function renderSteamPreview() {
  const hasSteamData = Boolean(steamDraft.appId && steamDraft.name);
  const title = workspaceElements.gameTitleInput.value.trim() || steamDraft.name;
  const metaItems = [];

  if (steamDraft.appId) {
    metaItems.push(`app_id: ${steamDraft.appId}`);
  }

  if (steamDraft.developers.length) {
    metaItems.push(steamDraft.developers[0]);
  }

  if (steamDraft.publishers.length) {
    metaItems.push(steamDraft.publishers[0]);
  }

  workspaceElements.steamPreviewImage.src = steamDraft.headerImage || defaultPreviewImage;
  workspaceElements.steamPreviewTitle.textContent = title || "Chưa có game";
  workspaceElements.steamPreviewMeta.textContent = hasSteamData
    ? metaItems.join(" • ")
    : "Nhập app id để lấy dữ liệu.";
  workspaceElements.steamPreviewStatus.textContent = hasSteamData ? "Đã lấy từ Steam" : "Steam";

  const tags = hasSteamData
    ? [...steamDraft.genres.slice(0, 4), steamDraft.releaseDate || "Chưa rõ ngày phát hành"]
    : ["Tags"];

  workspaceElements.steamPreviewTags.innerHTML = tags
    .filter(Boolean)
    .map((tag) => `<span class="admin-soft-chip">${escapeHtml(tag)}</span>`)
    .join("");
}

function renderPricePreview() {
  const { storeDiscount, standardVersion, fullVersion } = getVersionState();
  const isFree = steamDraft.isFree;

  workspaceElements.steamOriginalPrice.textContent = isFree ? "Miễn phí" : steamDraft.originalPriceText;
  workspaceElements.steamOriginalPriceNote.textContent = steamDraft.originalPriceValue
    ? "Steam list price"
    : "Chưa có dữ liệu";

  workspaceElements.steamSalePrice.textContent = isFree ? "Miễn phí" : steamDraft.salePriceText;
  workspaceElements.steamSalePriceNote.textContent = steamDraft.appId
    ? `Region VN • app_id ${steamDraft.appId}`
    : "Chưa import";

  workspaceElements.storeDiscountPreview.textContent = `${storeDiscount}%`;
  workspaceElements.storeFinalPrice.textContent = standardVersion.finalPriceText;
  workspaceElements.storeFinalPriceNote.textContent = standardVersion.enabled
    ? "Bản thường"
    : "Đang tắt";

  workspaceElements.versionStandardPrice.value = standardVersion.enabled
    ? standardVersion.finalPriceText
    : "Đang tắt";

  if (fullVersion.enabled) {
    if (
      !fullPriceTouched ||
      !workspaceElements.versionFullPrice.value.trim() ||
      workspaceElements.versionFullPrice.value === "Đang tắt"
    ) {
      workspaceElements.versionFullPrice.value = fullVersion.finalPriceText;
    }
  } else {
    workspaceElements.versionFullPrice.value = "Đang tắt";
  }
}

function getFilteredStoreGames() {
  const keyword = workspaceElements.storeKeywordInput.value.trim().toLowerCase();
  const status = workspaceElements.storeStatusFilter.value;

  return storeGames.filter((game) => {
    const searchableText = [game.title, game.slug, game.steamAppId].join(" ").toLowerCase();
    const matchesKeyword = !keyword || searchableText.includes(keyword);
    const matchesStatus = status === "ALL" || game.status === status;
    return matchesKeyword && matchesStatus;
  });
}

function mapStatusClass(status) {
  switch (status) {
    case "Published":
      return "is-ok";
    case "Hidden":
      return "is-hold";
    default:
      return "is-check";
  }
}

function renderStoreGameList() {
  const filteredGames = getFilteredStoreGames();
  workspaceElements.storeListPill.textContent = `${storeGames.length} record`;

  if (!filteredGames.length) {
    workspaceElements.storeGameList.innerHTML = `
      <article class="admin-mini-card admin-crud-record">
        <strong>Chưa có game</strong>
        <span class="admin-card-subtitle">Thêm game mới để hiển thị ở đây.</span>
      </article>
    `;
    return;
  }

  workspaceElements.storeGameList.innerHTML = filteredGames
    .map((game) => {
      const versionChips = game.versions
        .filter((version) => version.enabled)
        .map(
          (version) =>
            `<span class="admin-soft-chip">${escapeHtml(version.name)} • ${escapeHtml(
              version.finalPriceText
            )}</span>`
        )
        .join("");

      return `
        <article class="admin-mini-card admin-crud-record admin-game-list-card ${
          game.id === selectedRecordId ? "is-active" : ""
        }">
          <div class="admin-game-store-item">
            <div class="admin-game-store-item__thumb">
              <img src="${escapeHtml(game.image || defaultPreviewImage)}" alt="${escapeHtml(
                game.title
              )}" />
            </div>
            <div class="admin-game-store-item__body">
              <div class="admin-record-footer">
                <strong>${escapeHtml(game.title)}</strong>
                <span class="admin-status ${mapStatusClass(game.status)}">${escapeHtml(
                  game.status
                )}</span>
              </div>
              <div class="admin-crud-record__slug">
                steam_app_id: ${escapeHtml(game.steamAppId)} • /${escapeHtml(game.slug)}
              </div>
              <div class="admin-game-list-price">
                <strong>${escapeHtml(game.storePriceText)}</strong>
                <span>${escapeHtml(game.steamFinalPriceText)}</span>
              </div>
              <div class="admin-chip-row admin-game-list-meta">
                ${versionChips}
              </div>
              <div class="admin-toolbar-actions admin-crud-item-actions">
                <button class="admin-button admin-button--secondary" type="button" data-action="edit" data-record-id="${escapeHtml(
                  game.id
                )}">
                  Sửa
                </button>
                <button class="admin-button admin-button--danger" type="button" data-action="delete" data-record-id="${escapeHtml(
                  game.id
                )}">
                  Xóa
                </button>
              </div>
            </div>
          </div>
        </article>
      `;
    })
    .join("");
}

function updateWorkspaceView() {
  renderSteamPreview();
  renderPricePreview();
  renderStoreGameList();
}

function resetForm(keepFilters = true) {
  steamDraft = createEmptySteamDraft();
  selectedRecordId = null;
  slugTouched = false;
  fullPriceTouched = false;

  workspaceElements.steamAppIdInput.value = "";
  workspaceElements.gameStatusInput.value = "Draft";
  workspaceElements.gameTitleInput.value = "";
  workspaceElements.gameSlugInput.value = "";
  workspaceElements.globalDiscountInput.value = "10";
  workspaceElements.versionStandardEnabled.checked = true;
  workspaceElements.versionStandardName.value = "Bản thường";
  workspaceElements.versionFullEnabled.checked = true;
  workspaceElements.versionFullName.value = "Bản full DLC";
  workspaceElements.versionFullPrice.value = "";
  workspaceElements.saveGameButton.innerHTML =
    '<i class="bi bi-plus-circle"></i> Thêm vào store';

  if (!keepFilters) {
    workspaceElements.storeKeywordInput.value = "";
    workspaceElements.storeStatusFilter.value = "ALL";
  }

  setFetchStatus("Chưa lấy dữ liệu từ Steam.", "idle");
  updateWorkspaceView();
}

function buildRecordPayload() {
  const { storeDiscount, standardVersion, fullVersion } = getVersionState();
  const versions = [];

  if (standardVersion.enabled) {
    versions.push({
      code: standardVersion.code,
      enabled: true,
      name: standardVersion.name,
      finalPriceValue: standardVersion.finalPriceValue,
      finalPriceText: standardVersion.finalPriceText,
    });
  }

  if (fullVersion.enabled) {
    versions.push({
      code: fullVersion.code,
      enabled: true,
      name: fullVersion.name,
      finalPriceValue: fullVersion.finalPriceValue,
      finalPriceText: fullVersion.finalPriceText,
    });
  }

  const primaryVersion = versions[0] || {
    finalPriceValue: 0,
    finalPriceText: formatMoney(0, "VND"),
  };

  return {
    id: selectedRecordId || createId(),
    steamAppId: workspaceElements.steamAppIdInput.value.trim(),
    title: workspaceElements.gameTitleInput.value.trim(),
    slug: workspaceElements.gameSlugInput.value.trim(),
    status: workspaceElements.gameStatusInput.value,
    image: steamDraft.headerImage || defaultPreviewImage,
    steamOriginalPriceValue: steamDraft.originalPriceValue,
    steamFinalPriceValue: steamDraft.salePriceValue,
    steamOriginalPriceText: steamDraft.originalPriceText,
    steamFinalPriceText: steamDraft.salePriceText,
    storeDiscount,
    storePriceValue: primaryVersion.finalPriceValue,
    storePriceText: primaryVersion.finalPriceText,
    developers: steamDraft.developers,
    publishers: steamDraft.publishers,
    genres: steamDraft.genres,
    releaseDate: steamDraft.releaseDate,
    versions,
  };
}

function validatePayload(payload) {
  if (!payload.steamAppId) {
    return "Bạn cần nhập steam_app_id.";
  }

  if (!payload.title) {
    return "Bạn cần import Steam hoặc nhập tên game.";
  }

  if (!payload.slug) {
    return "Bạn cần nhập slug.";
  }

  if (!payload.versions.length) {
    return "Hãy bật ít nhất một version.";
  }

  return "";
}

function upsertStoreGame() {
  const payload = buildRecordPayload();
  const validationMessage = validatePayload(payload);

  if (validationMessage) {
    setFetchStatus(validationMessage, "error");
    return;
  }

  const existingIndex = storeGames.findIndex((game) => game.id === payload.id);
  if (existingIndex >= 0) {
    storeGames[existingIndex] = payload;
    setFetchStatus("Đã cập nhật game.", "success");
  } else {
    storeGames.unshift(payload);
    setFetchStatus("Đã thêm game vào store.", "success");
  }

  selectedRecordId = payload.id;
  workspaceElements.saveGameButton.innerHTML =
    '<i class="bi bi-check2-circle"></i> Cập nhật game';

  saveStoreGames();
  updateWorkspaceView();
}

function deleteCurrentGame(recordId = selectedRecordId) {
  if (!recordId) {
    setFetchStatus("Chưa chọn game để xóa.", "error");
    return;
  }

  storeGames = storeGames.filter((game) => game.id !== recordId);
  saveStoreGames();

  if (selectedRecordId === recordId) {
    resetForm();
  } else {
    updateWorkspaceView();
  }

  setFetchStatus("Đã xóa game.", "success");
}

function loadRecordIntoForm(recordId) {
  const record = storeGames.find((game) => game.id === recordId);
  if (!record) {
    return;
  }

  selectedRecordId = record.id;
  slugTouched = true;
  fullPriceTouched = Boolean(record.versions.find((version) => version.code === "full_dlc"));
  steamDraft = {
    appId: record.steamAppId,
    name: record.title,
    developers: record.developers || [],
    publishers: record.publishers || [],
    genres: record.genres || [],
    releaseDate: record.releaseDate || "",
    headerImage: record.image || defaultPreviewImage,
    originalPriceValue: record.steamOriginalPriceValue || 0,
    salePriceValue: record.steamFinalPriceValue || 0,
    originalPriceText: record.steamOriginalPriceText || "0 đ",
    salePriceText: record.steamFinalPriceText || "0 đ",
    isFree: record.steamFinalPriceValue === 0,
  };

  workspaceElements.steamAppIdInput.value = record.steamAppId || "";
  workspaceElements.gameStatusInput.value = record.status || "Draft";
  workspaceElements.gameTitleInput.value = record.title || "";
  workspaceElements.gameSlugInput.value = record.slug || "";
  workspaceElements.globalDiscountInput.value = String(record.storeDiscount ?? 0);

  const standardVersion = record.versions.find((version) => version.code === "standard");
  const fullVersion = record.versions.find((version) => version.code === "full_dlc");

  workspaceElements.versionStandardEnabled.checked = Boolean(standardVersion?.enabled);
  workspaceElements.versionStandardName.value = standardVersion?.name || "Bản thường";
  workspaceElements.versionFullEnabled.checked = Boolean(fullVersion?.enabled);
  workspaceElements.versionFullName.value = fullVersion?.name || "Bản full DLC";
  workspaceElements.versionFullPrice.value = fullVersion?.finalPriceText || "";

  workspaceElements.saveGameButton.innerHTML =
    '<i class="bi bi-check2-circle"></i> Cập nhật game';
  setFetchStatus("Đã nạp game vào form.", "success");
  updateWorkspaceView();
}

async function fetchSteamGameDetails(appId) {
  const endpoint = `https://store.steampowered.com/api/appdetails?appids=${encodeURIComponent(
    appId
  )}&cc=vn&l=vietnamese&filters=basic,price_overview,genres,release_date`;

  const response = await fetch(endpoint, {
    method: "GET",
    headers: {
      Accept: "application/json",
    },
  });

  if (!response.ok) {
    throw new Error(`Steam API trả về HTTP ${response.status}.`);
  }

  const payload = await response.json();
  const gameEnvelope = payload?.[appId];
  if (!gameEnvelope?.success || !gameEnvelope.data) {
    throw new Error("Steam không trả dữ liệu hợp lệ cho app_id này.");
  }

  return gameEnvelope.data;
}

async function handleSteamFetch() {
  const appId = workspaceElements.steamAppIdInput.value.trim();

  if (!/^\d+$/.test(appId)) {
    setFetchStatus("steam_app_id phải là số.", "error");
    return;
  }

  setFetchStatus("Đang gọi Steam API...", "loading");
  workspaceElements.steamFetchButton.disabled = true;

  try {
    const data = await fetchSteamGameDetails(appId);
    const priceOverview = data.price_overview || null;
    const originalPriceValue = priceOverview ? normalizeSteamAmount(priceOverview.initial) : 0;
    const salePriceValue = priceOverview ? normalizeSteamAmount(priceOverview.final) : 0;
    const originalPriceText = data.is_free
      ? "Miễn phí"
      : priceOverview?.initial_formatted || formatMoney(originalPriceValue, "VND");
    const salePriceText = data.is_free
      ? "Miễn phí"
      : priceOverview?.final_formatted || formatMoney(salePriceValue, "VND");

    steamDraft = {
      appId,
      name: data.name || "",
      developers: Array.isArray(data.developers) ? data.developers : [],
      publishers: Array.isArray(data.publishers) ? data.publishers : [],
      genres: Array.isArray(data.genres) ? data.genres.map((genre) => genre.description) : [],
      releaseDate: data.release_date?.date || "",
      headerImage: data.header_image || defaultPreviewImage,
      originalPriceValue,
      salePriceValue,
      originalPriceText,
      salePriceText,
      isFree: Boolean(data.is_free),
    };

    workspaceElements.gameTitleInput.value = steamDraft.name;
    workspaceElements.gameSlugInput.value = slugify(steamDraft.name || appId);
    slugTouched = false;
    fullPriceTouched = false;

    setFetchStatus("Đã lấy dữ liệu từ Steam.", "success");
    updateWorkspaceView();
  } catch (error) {
    const message =
      error instanceof Error
        ? error.message
        : "Không thể gọi Steam API. Nếu bị CORS, bước sau nên thêm proxy backend.";

    setFetchStatus(message, "error");
  } finally {
    workspaceElements.steamFetchButton.disabled = false;
  }
}

function handleRecordListClick(event) {
  const actionButton = event.target.closest("[data-action]");
  if (!actionButton) {
    return;
  }

  const recordId = actionButton.getAttribute("data-record-id");
  const action = actionButton.getAttribute("data-action");
  if (!recordId || !action) {
    return;
  }

  if (action === "edit") {
    loadRecordIntoForm(recordId);
    return;
  }

  if (action === "delete") {
    deleteCurrentGame(recordId);
  }
}

function bindWorkspaceEvents() {
  workspaceElements.steamFetchButton?.addEventListener("click", handleSteamFetch);

  workspaceElements.steamAppIdInput?.addEventListener("keydown", (event) => {
    if (event.key === "Enter") {
      event.preventDefault();
      handleSteamFetch();
    }
  });

  workspaceElements.gameTitleInput?.addEventListener("input", () => {
    if (!slugTouched) {
      workspaceElements.gameSlugInput.value = slugify(workspaceElements.gameTitleInput.value);
    }
    renderSteamPreview();
  });

  workspaceElements.gameSlugInput?.addEventListener("input", () => {
    slugTouched = workspaceElements.gameSlugInput.value.trim().length > 0;
  });

  workspaceElements.globalDiscountInput?.addEventListener("input", renderPricePreview);
  workspaceElements.versionStandardEnabled?.addEventListener("change", renderPricePreview);
  workspaceElements.versionStandardName?.addEventListener("input", renderPricePreview);
  workspaceElements.versionFullEnabled?.addEventListener("change", renderPricePreview);
  workspaceElements.versionFullName?.addEventListener("input", renderPricePreview);
  workspaceElements.versionFullPrice?.addEventListener("input", () => {
    fullPriceTouched = true;
  });
  workspaceElements.versionFullPrice?.addEventListener("blur", () => {
    if (!workspaceElements.versionFullPrice.value.trim()) {
      fullPriceTouched = false;
      renderPricePreview();
      return;
    }

    const parsedValue = parseCurrencyInput(workspaceElements.versionFullPrice.value);
    workspaceElements.versionFullPrice.value = formatMoney(parsedValue, "VND");
    renderPricePreview();
  });

  workspaceElements.saveGameButton?.addEventListener("click", upsertStoreGame);
  workspaceElements.resetFormButton?.addEventListener("click", () => resetForm());
  workspaceElements.deleteGameButton?.addEventListener("click", () => deleteCurrentGame());
  workspaceElements.storeGameList?.addEventListener("click", handleRecordListClick);
  workspaceElements.storeKeywordInput?.addEventListener("input", renderStoreGameList);
  workspaceElements.storeStatusFilter?.addEventListener("change", renderStoreGameList);
}

function initGameWorkspace() {
  if (!workspaceElements.steamAppIdInput) {
    return;
  }

  bindWorkspaceEvents();
  saveStoreGames();
  resetForm();
}

if (document.readyState === "loading") {
  document.addEventListener("DOMContentLoaded", initGameWorkspace);
} else {
  initGameWorkspace();
}
