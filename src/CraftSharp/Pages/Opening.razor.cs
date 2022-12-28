using CraftSharp.Factories;
using CraftSharp.Models;
using CraftSharp.Services;
using CraftSharp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;

namespace CraftSharp.Pages
{
    public partial class Opening
    {
        public Item randomItem;

        string closeAnim = "";
        string openAnim = "";
        string itemAnim = "";
        string buttonAnim = "";

        bool isChestClosed = true;

        int itemOpacity = 0;

        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public CustomStateProvider AuthService { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState> Context { get; set; }

        int NumberOfKeys { get; set; } = 0;
        int CostInKeys { get; set; } = 1;

        [Inject]
        public IStringLocalizer<Opening> Localizer { get; set; }

        int totalItem;
        List<Item> items;

        protected override async Task OnInitializedAsync()
        {
            totalItem = await DataService.Count();

            items = await DataService.List(0, totalItem);

            var authState = await Context;
            NumberOfKeys = AuthService.GetCurrentUser().NumberOfKeys;
        }

        bool canOpen()
        {
            return isChestClosed && NumberOfKeys >= CostInKeys;
        }

        async void selectRandom()
        {

            if (canOpen())
            {
                NumberOfKeys=NumberOfKeys-CostInKeys;
                randomItem = ItemFactory.GetRandomItem(items);
                Console.WriteLine(randomItem.Name);
                openingAnimation();
            }
            else
            {
                cantOpenAnimation();
            }

        }

        async void cantOpenAnimation()
        {
            buttonAnim = "buttonShake";
            StateHasChanged();

            await Task.Delay(500);
            buttonAnim = "";
            StateHasChanged();

        }

        async void openingAnimation()
        {
            itemOpacity = 0;
            isChestClosed = false;
            openAnim = "chestAppear";
            closeAnim = "chestDisppear";
            StateHasChanged();

            await Task.Delay(200);
            itemAnim = "itemShow";
            StateHasChanged();

            await Task.Delay(2000);
            openAnim = "chestDisppear";
            closeAnim = "chestAppear";
            itemAnim = "itemIdle";
            itemOpacity = 1;
            isChestClosed = true;
            StateHasChanged();


        }
    }
}
