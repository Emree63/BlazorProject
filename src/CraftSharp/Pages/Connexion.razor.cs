using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components;
using CraftSharp.Models;
using CraftSharp.Services;

namespace CraftSharp.Pages
{
    public partial class Connexion
    {
        [Inject]
        public CustomStateProvider AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string error { get; set; }
        private ConnexionModel loginRequest { get; set; } = new ConnexionModel();

        private async Task OnSubmit()
        {
            error = null;
            try
            {
                await AuthStateProvider.Login(loginRequest);
                NavigationManager.NavigateTo("");
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }
    }
}
