using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components;
using CraftSharp.Models;
using CraftSharp.Services;
using Blazorise;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Text;
using Microsoft.Extensions.Localization;

namespace CraftSharp.Pages
{
    public partial class Connexion
    {
        [Inject]
        public CustomStateProvider AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public HttpClient httpClient { get; set; }

        [Inject]
        public IStringLocalizer<Connexion> Localizer { get; set; }
        private string error { get; set; }
        private ConnexionModel loginRequest { get; set; } = new ConnexionModel();

        protected override async Task OnInitializedAsync()
        {
            if (AuthStateProvider.GetCurrentUser() != null && AuthStateProvider.GetCurrentUser().IsAuthenticated)
            {
                NavigationManager.NavigateTo("index");
            }
        }

        private async Task OnSubmit()
        {
            error = null;
            try
            {
                await AuthStateProvider.Login(loginRequest);
                var stringified = JsonConvert.SerializeObject(loginRequest);
                var response = await httpClient.PostAsJsonAsync($"{NavigationManager.BaseUri}User/SetUser", stringified);
                NavigationManager.NavigateTo("index");

            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }
    }
}
