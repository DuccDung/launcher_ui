const mobileMenuToggle = document.getElementById("mobileMenuToggle");
const mobileDrawer = document.getElementById("mobileDrawer");
const mobileOverlay = document.getElementById("mobileOverlay");
const closeDrawer = document.getElementById("closeDrawer");
const mobileDropdownToggles = document.querySelectorAll(
  ".mobile-dropdown-toggle"
);
const mobileDrawerLinks = document.querySelectorAll(".mobile-drawer-nav a");
const desktopBreakpoint = window.matchMedia("(min-width: 992px)");

function openDrawer() {
  if (!mobileDrawer || !mobileOverlay) return;

  mobileDrawer.classList.add("active");
  mobileOverlay.classList.add("active");
  mobileDrawer.setAttribute("aria-hidden", "false");

  if (mobileMenuToggle) {
    mobileMenuToggle.setAttribute("aria-expanded", "true");
  }

  document.body.style.overflow = "hidden";
}

function closeMenu() {
  if (!mobileDrawer || !mobileOverlay) return;

  mobileDrawer.classList.remove("active");
  mobileOverlay.classList.remove("active");
  mobileDrawer.setAttribute("aria-hidden", "true");

  if (mobileMenuToggle) {
    mobileMenuToggle.setAttribute("aria-expanded", "false");
  }

  document.body.style.overflow = "";
}

function handleEscape(event) {
  if (event.key === "Escape") {
    closeMenu();
  }
}

if (mobileMenuToggle) {
  mobileMenuToggle.addEventListener("click", openDrawer);
}

if (closeDrawer) {
  closeDrawer.addEventListener("click", closeMenu);
}

if (mobileOverlay) {
  mobileOverlay.addEventListener("click", closeMenu);
}

mobileDropdownToggles.forEach((toggle) => {
  toggle.addEventListener("click", () => {
    const submenu = toggle.nextElementSibling;

    if (!submenu) return;

    const isOpen = toggle.classList.toggle("open");
    submenu.classList.toggle("show", isOpen);
    toggle.setAttribute("aria-expanded", String(isOpen));
  });
});

mobileDrawerLinks.forEach((link) => {
  link.addEventListener("click", closeMenu);
});

document.addEventListener("keydown", handleEscape);

desktopBreakpoint.addEventListener("change", (event) => {
  if (event.matches) {
    closeMenu();
  }
});

const ambientGlow = document.querySelector(".ambient-glow");
const motionPreference = window.matchMedia("(prefers-reduced-motion: reduce)");
let ambientGlowFrame = null;

function updateAmbientGlow(x, y, scale, opacity) {
  if (!ambientGlow) return;

  ambientGlow.style.setProperty("--glow-x", `${x}px`);
  ambientGlow.style.setProperty("--glow-y", `${y}px`);
  ambientGlow.style.setProperty("--glow-scale", scale.toFixed(3));
  ambientGlow.style.setProperty("--glow-opacity", opacity.toFixed(3));
}

function applyStaticAmbientGlow() {
  updateAmbientGlow(
    window.innerWidth * 0.5,
    window.innerHeight * 0.58,
    1.06,
    0.44
  );
}

function stopAmbientGlow() {
  if (!ambientGlowFrame) return;

  window.cancelAnimationFrame(ambientGlowFrame);
  ambientGlowFrame = null;
}

function startAmbientGlow() {
  if (!ambientGlow) return;

  stopAmbientGlow();

  const animate = (time) => {
    const t = time * 0.00072;
    const motionFactor = motionPreference.matches ? 0.65 : 1;
    const centerX = window.innerWidth * 0.5;
    const centerY = window.innerHeight * 0.58;
    const driftX =
      (Math.sin(t * 1.12) * window.innerWidth * 0.075 +
        Math.cos(t * 0.42) * window.innerWidth * 0.028) *
      motionFactor;
    const driftY =
      (Math.cos(t * 0.88) * window.innerHeight * 0.095 +
        Math.sin(t * 0.36) * window.innerHeight * 0.032) *
      motionFactor;
    const scale =
      1.04 +
      (Math.sin(t * 1.88) * 0.12 + Math.cos(t * 0.98) * 0.05) * motionFactor;
    const opacity =
      0.32 +
      (((Math.sin(t * 1.72 - 0.5) + 1) * 0.5) * 0.2 +
        ((Math.cos(t * 0.64) + 1) * 0.5) * 0.05) *
        motionFactor;

    updateAmbientGlow(centerX + driftX, centerY + driftY, scale, opacity);
    ambientGlowFrame = window.requestAnimationFrame(animate);
  };

  ambientGlowFrame = window.requestAnimationFrame(animate);
}

function handleAmbientGlowPreferenceChange() {
  startAmbientGlow();
}

startAmbientGlow();

if (typeof motionPreference.addEventListener === "function") {
  motionPreference.addEventListener("change", handleAmbientGlowPreferenceChange);
} else if (typeof motionPreference.addListener === "function") {
  motionPreference.addListener(handleAmbientGlowPreferenceChange);
}

document.addEventListener("visibilitychange", () => {
  if (document.hidden) {
    stopAmbientGlow();
    return;
  }

  startAmbientGlow();
});
