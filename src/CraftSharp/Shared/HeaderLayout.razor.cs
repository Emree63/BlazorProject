using CraftSharp.Models;
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
        public IAuthService AuthService { get; set; }

        [Inject]
        public CustomStateProvider AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        private bool isUserAdmin = false;

        protected override async Task OnInitializedAsync()
        {
            isAdmin();
        }

        void goInscription()
        {
            NavigationManager.NavigateTo("inscription");
        }

        void goConnexion()
        {
            NavigationManager.NavigateTo("connexion");
        }

        async public void isAdmin()
        {
            var authState = await AuthenticationState;
            var roles = AuthService.GetCurrentUser(authState.User.Identity.Name).Roles;
            isUserAdmin = roles.Contains(UserRoles.Admin);
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
