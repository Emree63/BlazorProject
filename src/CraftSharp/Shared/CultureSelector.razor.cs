using CraftSharp.Services;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace CraftSharp.Shared
{
    public partial class CultureSelector
    {
        [Inject]
        ILogger<CultureSelector> Logger { get; set; }   

        private CultureInfo[] supportedCultures = new[]
{
        new CultureInfo("en-US"),
        new CultureInfo("fr-FR"),
        new CultureInfo("tr-TR")
    };

        private CultureInfo Culture
        {
            get => CultureInfo.CurrentCulture;
            set
            {
                if (CultureInfo.CurrentUICulture == value)
                {
                    return;
                }

                var culture = value.Name.ToLower(CultureInfo.InvariantCulture);

                var uri = new Uri(this.NavigationManager.Uri).GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
                var query = $"?culture={Uri.EscapeDataString(culture)}&" + $"redirectUri={Uri.EscapeDataString(uri)}";

                Logger.Log(LogLevel.Debug, $"Culture change - {culture}");
                // Redirect the user to the culture controller to set the cookie
                this.NavigationManager.NavigateTo("/Culture/SetCulture" + query, forceLoad: true);

            }
        }
    }
}
