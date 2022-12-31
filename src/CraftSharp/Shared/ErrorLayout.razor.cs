using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Net.Http;

namespace CraftSharp.Shared
{
    public partial class ErrorLayout
    {
        [Inject]
        public ILogger<ErrorLayout> Logger { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Logger.Log(LogLevel.Error, $"Navigating to unknown page : {NavigationManager.Uri}");
        }
    }
}
