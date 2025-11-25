using Avalonia;
using Avalonia.Styling;

namespace SurfRater.Avalonia.Services;

public static class ThemeController
{
    public static ThemeVariant GetCurrentTheme()
    {
        var app = Application.Current;
        if (app == null)
        {
            return ThemeVariant.Default;
        }

        var currentTheme = app.RequestedThemeVariant;
        if (currentTheme == null)
        {
            return ThemeVariant.Default;
        }

        return currentTheme;
    }

    public static void SetTheme(ThemeVariant themeVariant)
    {
        var app = Application.Current;

        if (app != null)
        {
            app.RequestedThemeVariant = themeVariant;
        }
    }
}