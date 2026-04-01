namespace UI_Desktop;

internal static class AppIconProvider
{
    private static Icon? appIcon;

    internal static Icon? GetAppIcon()
    {
        if (appIcon is not null)
        {
            return appIcon;
        }

        var iconPath = Path.Combine(AppContext.BaseDirectory, "Assets", "AppIcon.ico");
        if (!File.Exists(iconPath))
        {
            iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "AppIcon.ico");
        }

        if (!File.Exists(iconPath))
        {
            return null;
        }

        using var sourceIcon = new Icon(iconPath);
        appIcon = (Icon)sourceIcon.Clone();
        return appIcon;
    }

    internal static void ApplyIcon(Form form)
    {
        var icon = GetAppIcon();
        if (icon is null)
        {
            return;
        }

        form.Icon = icon;
    }
}
