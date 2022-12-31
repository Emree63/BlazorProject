using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components;
using CraftSharp.Models;
using CraftSharp.Services;
using Newtonsoft.Json;
using System.Net.Http;

namespace CraftSharp.Pages
{
    public partial class Inscription
    {
        [Inject]
        public CustomStateProvider AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public HttpClient httpClient { get; set; }

        private string error { get; set; }
        private InscriptionModel registerRequest { get; set; } = new InscriptionModel();

        private async Task OnSubmit()
        {

            await AuthStateProvider.Register(registerRequest);
            var stringified = JsonConvert.SerializeObject(new ConnexionModel() { 
                Password=registerRequest.Password, 
                UserName=registerRequest.UserName}
            );
            var response = await httpClient.PostAsJsonAsync($"{NavigationManager.BaseUri}User/SetUser", stringified);
            NavigationManager.NavigateTo("index");

        }
    }
}
