using CraftSharp.Models;
using CraftSharp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System.Reflection.Metadata;

namespace CraftSharp.Pages
{
    public partial class Shop
    {
        [Inject]
        public CustomStateProvider AuthService { get; set; }

        [Inject]
        public IStringLocalizer<Shop> Localizer { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }
        int NumberOfEmeralds { get; set; } = 0;

        List<ShopOfferModel> offers = new List<ShopOfferModel>()
        {
            new ShopOfferModel()
            {
                InputAmount=5,
                InputIconPath="/Images/shop_icon.png",
                OutputAmount=1,
                OutputIconPath="/Images/opening_icon.png",
            },
            new ShopOfferModel()
            {
                InputAmount=20,
                InputIconPath="/Images/shop_icon.png",
                OutputAmount=5,
                OutputIconPath="/Images/opening_icon.png",
            },
            new ShopOfferModel()
            {
                InputAmount=50,
                InputIconPath="/Images/shop_icon.png",
                OutputAmount=15,
                OutputIconPath="/Images/opening_icon.png",
            },
        };

        Dictionary<ShopOfferModel, string> animation = new Dictionary<ShopOfferModel, string>();
        
        protected override async Task OnInitializedAsync()
        {
            NumberOfEmeralds = AuthService.GetCurrentUser().numberOfEmeralds;
            foreach(ShopOfferModel offer in offers)
            {
                animation[offer] = "";
            }
        }

        private async void buyKeys(ShopOfferModel offer)
        {
            if (offer.InputAmount <= NumberOfEmeralds)
            {
                NumberOfEmeralds -= offer.InputAmount;
                AuthService.GetCurrentUser().NumberOfKeys += offer.OutputAmount;
            }
            else
            {
                animation[offer] = "buttonShake";
                StateHasChanged();

                await Task.Delay(500);
                animation[offer] = "";
                StateHasChanged();
            }
        }
    }
}
