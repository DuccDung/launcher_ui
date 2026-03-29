const adminSidebar = document.querySelector("[data-admin-sidebar]");
const adminSidebarToggle = document.querySelector("[data-admin-sidebar-toggle]");
const adminSidebarClose = document.querySelector("[data-admin-sidebar-close]");
const adminSidebarBackdrop = document.querySelector("[data-admin-sidebar-backdrop]");
const adminDesktopBreakpoint = window.matchMedia("(min-width: 992px)");

function setAdminSidebarState(isOpen) {
  if (!adminSidebar || !adminSidebarBackdrop) return;

  adminSidebar.classList.toggle("is-open", isOpen);
  adminSidebarBackdrop.classList.toggle("is-visible", isOpen);
}

if (adminSidebarToggle) {
  adminSidebarToggle.addEventListener("click", () => {
    setAdminSidebarState(true);
  });
}

if (adminSidebarClose) {
  adminSidebarClose.addEventListener("click", () => {
    setAdminSidebarState(false);
  });
}

if (adminSidebarBackdrop) {
  adminSidebarBackdrop.addEventListener("click", () => {
    setAdminSidebarState(false);
  });
}

document.addEventListener("keydown", (event) => {
  if (event.key === "Escape") {
    setAdminSidebarState(false);
  }
});

if (typeof adminDesktopBreakpoint.addEventListener === "function") {
  adminDesktopBreakpoint.addEventListener("change", (event) => {
    if (event.matches) {
      setAdminSidebarState(false);
    }
  });
}

function buildLineChart(ctx) {
  return new Chart(ctx, {
    type: "line",
    data: {
      labels: ["T2", "T3", "T4", "T5", "T6", "T7", "CN"],
      datasets: [
        {
          label: "Lượt truy cập",
          data: [9210, 10320, 11480, 12140, 13220, 14890, 16240],
          borderColor: "#5a8cff",
          backgroundColor: "rgba(90, 140, 255, 0.16)",
          pointBackgroundColor: "#5a8cff",
          pointBorderColor: "#5a8cff",
          pointRadius: 3,
          borderWidth: 3,
          fill: true,
          tension: 0.35,
        },
        {
          label: "Đơn hoàn tất",
          data: [284, 310, 348, 372, 405, 452, 498],
          borderColor: "#49d7a8",
          backgroundColor: "rgba(73, 215, 168, 0.12)",
          pointBackgroundColor: "#49d7a8",
          pointBorderColor: "#49d7a8",
          pointRadius: 3,
          borderWidth: 3,
          fill: true,
          tension: 0.35,
        },
      ],
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      interaction: {
        mode: "index",
        intersect: false,
      },
      plugins: {
        legend: {
          labels: {
            color: "#d9e4ff",
            font: {
              family: "Manrope",
              size: 12,
              weight: "600",
            },
          },
        },
        tooltip: {
          backgroundColor: "rgba(11, 17, 27, 0.94)",
          borderColor: "rgba(255,255,255,0.08)",
          borderWidth: 1,
          titleColor: "#ffffff",
          bodyColor: "#d9e4ff",
        },
      },
      scales: {
        x: {
          grid: {
            color: "rgba(255,255,255,0.05)",
          },
          ticks: {
            color: "#93a4c5",
            font: {
              family: "IBM Plex Mono",
              size: 11,
            },
          },
        },
        y: {
          grid: {
            color: "rgba(255,255,255,0.05)",
          },
          ticks: {
            color: "#93a4c5",
            font: {
              family: "IBM Plex Mono",
              size: 11,
            },
          },
        },
      },
    },
  });
}

function buildDoughnutChart(ctx) {
  return new Chart(ctx, {
    type: "doughnut",
    data: {
      labels: ["Doanh thu", "Lợi nhuận", "Hoàn tiền"],
      datasets: [
        {
          data: [286.4, 94.6, 12.8],
          backgroundColor: ["#5a8cff", "#49d7a8", "#ff8b4d"],
          borderWidth: 0,
        },
      ],
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      cutout: "68%",
      plugins: {
        legend: {
          display: false,
        },
        tooltip: {
          backgroundColor: "rgba(11, 17, 27, 0.94)",
          borderColor: "rgba(255,255,255,0.08)",
          borderWidth: 1,
          titleColor: "#ffffff",
          bodyColor: "#d9e4ff",
          callbacks: {
            label(context) {
              return `${context.label}: ${context.raw}M đ`;
            },
          },
        },
      },
    },
  });
}

function buildCategoryChart(ctx) {
  return new Chart(ctx, {
    type: "bar",
    data: {
      labels: [
        "Hành động",
        "Mystery Box",
        "Phiêu lưu",
        "Steam Wallet",
        "Gift Card",
      ],
      datasets: [
        {
          label: "Tỷ trọng truy cập",
          data: [34, 27, 18, 13, 8],
          backgroundColor: ["#5a8cff", "#6f9dff", "#85afff", "#9bc0ff", "#b2d1ff"],
          borderRadius: 8,
          borderSkipped: false,
        },
      ],
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      indexAxis: "y",
      plugins: {
        legend: {
          display: false,
        },
        tooltip: {
          backgroundColor: "rgba(11, 17, 27, 0.94)",
          borderColor: "rgba(255,255,255,0.08)",
          borderWidth: 1,
          titleColor: "#ffffff",
          bodyColor: "#d9e4ff",
          callbacks: {
            label(context) {
              return `${context.raw}% tổng lượt truy cập`;
            },
          },
        },
      },
      scales: {
        x: {
          grid: {
            color: "rgba(255,255,255,0.05)",
          },
          ticks: {
            color: "#93a4c5",
            callback(value) {
              return `${value}%`;
            },
          },
        },
        y: {
          grid: {
            display: false,
          },
          ticks: {
            color: "#d9e4ff",
            font: {
              family: "Manrope",
              size: 12,
              weight: "600",
            },
          },
        },
      },
    },
  });
}

function initAdminCharts() {
  if (typeof Chart === "undefined") return;

  const trafficCanvas = document.getElementById("trafficOrdersChart");
  const revenueCanvas = document.getElementById("revenueProfitChart");
  const categoryCanvas = document.getElementById("categoryAccessChart");

  if (trafficCanvas) {
    buildLineChart(trafficCanvas);
  }

  if (revenueCanvas) {
    buildDoughnutChart(revenueCanvas);
  }

  if (categoryCanvas) {
    buildCategoryChart(categoryCanvas);
  }
}

function slugifyCategoryName(value) {
  return value
    .toLowerCase()
    .normalize("NFD")
    .replace(/[\u0300-\u036f]/g, "")
    .replace(/đ/g, "d")
    .replace(/[^a-z0-9]+/g, "-")
    .replace(/^-+|-+$/g, "")
    .replace(/-{2,}/g, "-");
}

function initCategorySlugSync() {
  const categoryNameInput = document.getElementById("category-name");
  const categorySlugInput = document.getElementById("category-slug");

  if (!categoryNameInput || !categorySlugInput) return;

  const syncSlug = () => {
    categorySlugInput.value = slugifyCategoryName(categoryNameInput.value);
  };

  syncSlug();
  categoryNameInput.addEventListener("input", syncSlug);
}

if (document.readyState === "loading") {
  document.addEventListener("DOMContentLoaded", () => {
    initAdminCharts();
    initCategorySlugSync();
  });
} else {
  initAdminCharts();
  initCategorySlugSync();
}
