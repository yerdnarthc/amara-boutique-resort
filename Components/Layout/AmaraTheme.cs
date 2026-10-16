using MudBlazor;

namespace Amara.Components.Layout;

public static class AmaraTheme
{
    public static MudTheme Theme { get; } = new()
    {
        PaletteLight = new PaletteLight
        {
            Primary = "#d97757",
            PrimaryContrastText = "#141413",
            Secondary = "#788c5d",
            SecondaryContrastText = "#141413",
            Background = "#faf9f5",
            Surface = "#faf9f5",
            TextPrimary = "#141413",
            TextSecondary = "#56564e",
            Divider = "#e8e6dc",
            AppbarBackground = "#faf9f5",
            AppbarText = "#141413"
        },
        Typography = new Typography
        {
            Default = new DefaultTypography { FontFamily = ["Poppins", "Arial", "sans-serif"] },
            H1 = new H1Typography { FontFamily = ["Poppins", "Arial", "sans-serif"] },
            H2 = new H2Typography { FontFamily = ["Poppins", "Arial", "sans-serif"] },
            Body1 = new Body1Typography { FontFamily = ["Lora", "Georgia", "serif"] },
            Button = new ButtonTypography { TextTransform = "none", FontWeight = "500" }
        },
        LayoutProperties = new LayoutProperties { DefaultBorderRadius = "12px" }
    };
}