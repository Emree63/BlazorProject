using CraftSharp.Shared;
using Microsoft.AspNetCore.Components;

namespace CraftSharp.Pages
{
    public partial class UnknownPage
    {

        int countdown = 10;

        [Inject]
        public ILogger<UnknownPage> Logger { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Logger.Log(LogLevel.Error, $"Navigating to unknown page : {NavigationManager.Uri}");

            while (countdown > 0)
            {
                await Task.Delay(1000);
                countdown--;
                StateHasChanged();

            }
            NavigationManager.NavigateTo("index");
        }
    }
}
