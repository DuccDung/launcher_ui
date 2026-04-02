const GIFT_CODE_STORAGE_KEY = "nestg-admin-gift-codes";

const giftCodeElements = {
  giftTypeInput: document.getElementById("giftTypeInput"),
  giftItemInput: document.getElementById("giftItemInput"),
  giftItemLabel: document.getElementById("giftItemLabel"),
  giftQuantityInput: document.getElementById("giftQuantityInput"),
  giftUsageLimitInput: document.getElementById("giftUsageLimitInput"),
  giftAccountLimitInput: document.getElementById("giftAccountLimitInput"),
  giftExpireAtInput: document.getElementById("giftExpireAtInput"),
  giftCodeForm: document.getElementById("giftCodeForm"),
  giftCodeStatus: document.getElementById("giftCodeStatus"),
  giftCodeKeywordInput: document.getElementById("giftCodeKeywordInput"),
  giftCodeTypeFilter: document.getElementById("giftCodeTypeFilter"),
  giftCodeTableBody: document.getElementById("giftCodeTableBody"),
};

let giftCodes = loadGiftCodes();

function createSeedGiftCodes() {
  return [
    buildSeedGiftCode("wallet", "Ví 100.000 đ", 1, 1, ["nguyenvana"]),
    buildSeedGiftCode("game", "Game: Borderlands 4", 1, 1, ["tranminhkhang"]),
    buildSeedGiftCode("game", "Game: Palworld", 1, 1, ["phamquoctoan"]),
    buildSeedGiftCode("game", "Game: Forza Horizon 5", 0, 1, []),
    buildSeedGiftCode("wallet", "Ví 71.500 đ", 1, 1, ["lethanhdat"]),
    buildSeedGiftCode("game", "Game: Black Myth: Wukong", 1, 1, ["nguyenducdung"]),
    buildSeedGiftCode("game", "Game: Resident Evil Requiem", 1, 1, ["hoangkiman"]),
  ];
}

function buildSeedGiftCode(type, content, usedCount, usageLimit, users) {
  return {
    id: createId(),
    code: createGiftCode(),
    type,
    content,
    usedCount,
    usageLimit,
    accountLimit: 1,
    users,
    expiresAt: "",
    tracked: false,
  };
}

function loadGiftCodes() {
  try {
    const raw = window.localStorage.getItem(GIFT_CODE_STORAGE_KEY);
    if (raw) {
      const parsed = JSON.parse(raw);
      if (Array.isArray(parsed)) {
        return parsed;
      }
    }
  } catch {
    // Ignore malformed storage.
  }

  return createSeedGiftCodes();
}

function saveGiftCodes() {
  window.localStorage.setItem(GIFT_CODE_STORAGE_KEY, JSON.stringify(giftCodes));
}

function createId() {
  return `gift-${Date.now()}-${Math.random().toString(16).slice(2, 8)}`;
}

function createGiftCode() {
  const characters = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
  const parts = [];

  for (let partIndex = 0; partIndex < 5; partIndex += 1) {
    let part = "";

    for (let charIndex = 0; charIndex < 4; charIndex += 1) {
      const randomIndex = Math.floor(Math.random() * characters.length);
      part += characters[randomIndex];
    }

    parts.push(part);
  }

  return parts.join("-");
}

function escapeHtml(value) {
  return String(value)
    .replace(/&/g, "&amp;")
    .replace(/</g, "&lt;")
    .replace(/>/g, "&gt;")
    .replace(/"/g, "&quot;")
    .replace(/'/g, "&#39;");
}

function clampInt(value, min, max) {
  const numericValue = Number.parseInt(value, 10);
  if (!Number.isFinite(numericValue)) {
    return min;
  }

  return Math.min(max, Math.max(min, numericValue));
}

function formatDateTime(value) {
  if (!value) {
    return "";
  }

  const date = new Date(value);
  if (Number.isNaN(date.getTime())) {
    return "";
  }

  return new Intl.DateTimeFormat("vi-VN", {
    dateStyle: "short",
    timeStyle: "short",
  }).format(date);
}

function updateGiftItemMeta() {
  const currentType = giftCodeElements.giftTypeInput.value;

  if (currentType === "game") {
    giftCodeElements.giftItemLabel.textContent = "Chọn game (Tên hoặc AppID)";
    giftCodeElements.giftItemInput.placeholder = "Nhập tên hoặc AppID game...";
    return;
  }

  if (currentType === "wallet") {
    giftCodeElements.giftItemLabel.textContent = "Mệnh giá hoặc nội dung";
    giftCodeElements.giftItemInput.placeholder = "Ví dụ: 100.000 đ";
    return;
  }

  if (currentType === "item") {
    giftCodeElements.giftItemLabel.textContent = "Tên vật phẩm";
    giftCodeElements.giftItemInput.placeholder = "Ví dụ: Skin hiếm, key vật phẩm...";
    return;
  }

  giftCodeElements.giftItemLabel.textContent = "Nội dung quà tặng";
  giftCodeElements.giftItemInput.placeholder = "Nhập nội dung quà tặng...";
}

function buildGiftContent(type, rawValue) {
  const value = rawValue.trim();

  switch (type) {
    case "wallet":
      return `Ví: ${value}`;
    case "item":
      return `Vật phẩm: ${value}`;
    case "other":
      return `Quà: ${value}`;
    default:
      return `Game: ${value}`;
  }
}

function getTypeLabel(type) {
  switch (type) {
    case "wallet":
      return "Ví";
    case "item":
      return "Vật phẩm";
    case "other":
      return "Khác";
    default:
      return "Game";
  }
}

function getFilteredGiftCodes() {
  const keyword = giftCodeElements.giftCodeKeywordInput.value.trim().toLowerCase();
  const typeFilter = giftCodeElements.giftCodeTypeFilter.value;

  return giftCodes.filter((giftCode) => {
    const searchableText = [
      giftCode.code,
      giftCode.content,
      giftCode.users.join(" "),
      getTypeLabel(giftCode.type),
    ]
      .join(" ")
      .toLowerCase();

    const matchesKeyword = !keyword || searchableText.includes(keyword);
    const matchesType = typeFilter === "all" || giftCode.type === typeFilter;

    return matchesKeyword && matchesType;
  });
}

function renderGiftCodeTable() {
  const filteredGiftCodes = getFilteredGiftCodes();

  if (!filteredGiftCodes.length) {
    giftCodeElements.giftCodeTableBody.innerHTML = `
      <tr>
        <td colspan="5">Chưa có mã quà tặng phù hợp.</td>
      </tr>
    `;
    return;
  }

  giftCodeElements.giftCodeTableBody.innerHTML = filteredGiftCodes
    .map((giftCode) => {
      const usersMarkup = giftCode.users.length
        ? giftCode.users.map((user) => `<span>${escapeHtml(user)}</span>`).join("")
        : "<span>Chưa có</span>";
      const contentClass = giftCode.type === "wallet" ? "is-money" : "is-game";
      const expireMarkup = giftCode.expiresAt
        ? `<small>Hết hạn: ${escapeHtml(formatDateTime(giftCode.expiresAt))}</small>`
        : "<small>Không giới hạn</small>";

      return `
        <tr class="${giftCode.tracked ? "admin-gift-code-row is-tracked" : "admin-gift-code-row"}">
          <td data-label="Mã">
            <div class="admin-gift-code-code">${escapeHtml(giftCode.code)}</div>
          </td>
          <td data-label="Nội dung">
            <div class="admin-gift-code-content ${contentClass}">
              ${escapeHtml(giftCode.content)}
            </div>
            ${expireMarkup}
          </td>
          <td data-label="Lượt dùng">
            <div class="admin-gift-code-usage">
              <strong>${escapeHtml(`${giftCode.usedCount}/${giftCode.usageLimit}`)}</strong>
              <span>mỗi mã</span>
              <span>tài khoản: ${escapeHtml(String(giftCode.accountLimit))}</span>
            </div>
          </td>
          <td data-label="Người sử dụng">
            <div class="admin-gift-code-users">
              ${usersMarkup}
            </div>
          </td>
          <td data-label="Thao tác">
            <div class="admin-gift-code-actions">
              <button
                class="admin-button admin-button--secondary admin-gift-track-button"
                type="button"
                data-action="track"
                data-id="${escapeHtml(giftCode.id)}"
              >
                ${giftCode.tracked ? "Bỏ theo dõi" : "Theo dõi"}
              </button>
              <button
                class="admin-button admin-button--danger admin-gift-delete-button"
                type="button"
                data-action="delete"
                data-id="${escapeHtml(giftCode.id)}"
              >
                Xóa
              </button>
            </div>
          </td>
        </tr>
      `;
    })
    .join("");
}

function setGiftCodeStatus(message, state = "idle") {
  giftCodeElements.giftCodeStatus.textContent = message;
  giftCodeElements.giftCodeStatus.className = `admin-gift-code-status is-${state}`;
}

function handleCreateGiftCodes(event) {
  event.preventDefault();

  const type = giftCodeElements.giftTypeInput.value;
  const itemValue = giftCodeElements.giftItemInput.value.trim();
  const quantity = clampInt(giftCodeElements.giftQuantityInput.value, 1, 100);
  const usageLimit = clampInt(giftCodeElements.giftUsageLimitInput.value, 1, 50);
  const accountLimit = clampInt(giftCodeElements.giftAccountLimitInput.value, 1, 20);
  const expiresAt = giftCodeElements.giftExpireAtInput.value;

  if (!itemValue) {
    setGiftCodeStatus("Bạn cần nhập nội dung quà tặng.", "error");
    return;
  }

  const createdGiftCodes = Array.from({ length: quantity }, () => ({
    id: createId(),
    code: createGiftCode(),
    type,
    content: buildGiftContent(type, itemValue),
    usedCount: 0,
    usageLimit,
    accountLimit,
    users: [],
    expiresAt,
    tracked: false,
  }));

  giftCodes = [...createdGiftCodes, ...giftCodes];
  saveGiftCodes();
  renderGiftCodeTable();
  setGiftCodeStatus(`Đã tạo ${createdGiftCodes.length} mã quà tặng.`, "success");
}

function handleGiftCodeTableClick(event) {
  const actionButton = event.target.closest("[data-action]");
  if (!actionButton) {
    return;
  }

  const action = actionButton.getAttribute("data-action");
  const id = actionButton.getAttribute("data-id");
  if (!action || !id) {
    return;
  }

  if (action === "track") {
    giftCodes = giftCodes.map((giftCode) =>
      giftCode.id === id ? { ...giftCode, tracked: !giftCode.tracked } : giftCode
    );
    saveGiftCodes();
    renderGiftCodeTable();
    return;
  }

  if (action === "delete") {
    giftCodes = giftCodes.filter((giftCode) => giftCode.id !== id);
    saveGiftCodes();
    renderGiftCodeTable();
    setGiftCodeStatus("Đã xóa mã quà tặng.", "success");
  }
}

function initGiftCodesPage() {
  if (!giftCodeElements.giftCodeForm) {
    return;
  }

  updateGiftItemMeta();
  renderGiftCodeTable();
  setGiftCodeStatus("Sẵn sàng tạo mã quà tặng.", "idle");

  giftCodeElements.giftTypeInput.addEventListener("change", updateGiftItemMeta);
  giftCodeElements.giftCodeForm.addEventListener("submit", handleCreateGiftCodes);
  giftCodeElements.giftCodeKeywordInput.addEventListener("input", renderGiftCodeTable);
  giftCodeElements.giftCodeTypeFilter.addEventListener("change", renderGiftCodeTable);
  giftCodeElements.giftCodeTableBody.addEventListener("click", handleGiftCodeTableClick);
}

if (document.readyState === "loading") {
  document.addEventListener("DOMContentLoaded", initGiftCodesPage);
} else {
  initGiftCodesPage();
}
