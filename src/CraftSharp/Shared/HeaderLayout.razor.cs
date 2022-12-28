using CraftSharp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;


namespace CraftSharp.Shared
{
    public partial class HeaderLayout
    {
        [Inject]
        public IStringLocalizer<HeaderLayout> Localizer { get; set; }

        [Inject]
        public CustomStateProvider AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        void goInscription()
        {
            NavigationManager.NavigateTo("inscription");
        }

        void goConnexion()
        {
            NavigationManager.NavigateTo("connexion");
        }

       /* protected override async Task OnParametersSetAsync()
        {
            if (!(await AuthenticationState).User.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/inscription");
            }
        }*/

        private async Task LogoutClick()
        {
            await AuthStateProvider.Logout();
            NavigationManager.NavigateTo("/inscription");
        }
    }
}
