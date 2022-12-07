using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components;
using CraftSharp.Models;

namespace CraftSharp.Pages
{
    public partial class Connexion
    {
        private readonly ConnexionModel connexion = new();

        private string _connexionId = "test";
        private string _connexionPasswrd = "test";

        private void seConnecter()
        {
            if (connexion.Name == _connexionId && connexion.Password == _connexionPasswrd)
            {
                NavManager.NavigateTo("/counter");
            }
        }
    }
}
