using CraftSharp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace CraftSharp
{
    public partial class App
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILogger<ErrorLayout> Logger { get; set; }

        [Inject]
        public IStringLocalizer<App> Localizer { get; set; }

        public async Task ErrorHandler(int countdown)
        {
            Logger.Log(LogLevel.Error, $"Navigating to unknown page : {NavigationManager.Uri}");
            while (countdown > 0)
            {
                await Task.Delay(1000);
                countdown--;
            }
            countdown = 5;
            NavigationManager.NavigateTo("index");
        }

    }
}
