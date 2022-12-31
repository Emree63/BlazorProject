using CraftSharp.Models;
using CraftSharp.Pages;
using CraftSharp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;
using System.Net.Http;


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

        [Inject]
        public HttpClient httpClient { get; set; }

        [Inject]
        public ILogger<HeaderLayout> Logger { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        private bool isUserAdmin = false;

        protected override async Task OnInitializedAsync()
        {
            if (AuthStateProvider.GetCurrentUser() == null || !AuthStateProvider.GetCurrentUser().IsAuthenticated)
            {
                NavigationManager.NavigateTo("/");
            }
            isAdmin();
        }

        async public void isAdmin()
        {
            var roles = AuthStateProvider.GetCurrentUser().Roles;
            isUserAdmin = roles.Contains(UserRoles.Admin);
        }
        private async Task LogoutClick()
        {
            await AuthStateProvider.Logout();
            Logger.Log(LogLevel.Information, $"Logout : {AuthStateProvider.GetCurrentUser().UserName}");
            await httpClient.DeleteAsync($"{NavigationManager.BaseUri}User/DeleteUser");

            NavigationManager.NavigateTo("/inscription");
        }
    }
}
