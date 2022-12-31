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
        public CustomStateProvider AuthStateProvider { get; set; }
        int CostInKeys { get; set; } = 1;

        [Inject]
        public IStringLocalizer<Opening> Localizer { get; set; }

        int totalItem;
        List<Item> items;

        protected override async Task OnInitializedAsync()
        {
            totalItem = await DataService.Count();

            items = await DataService.List(0, totalItem);
        }

        bool canOpen()
        {
            return isChestClosed && AuthStateProvider.GetCurrentUser().NumberOfKeys >= CostInKeys;
        }

        async void selectRandom()
        {

            if (canOpen())
            {
                AuthStateProvider.GetCurrentUser().NumberOfKeys -= CostInKeys;
                randomItem = ItemFactory.GetRandomItem(items);
                if (AuthStateProvider.GetCurrentUser().getSizeInventory() <= 64)
                {
                    //Vérifie quel n'existe pas déjà dans la liste
                    if (!AuthStateProvider.GetCurrentUser().Inventory.Any(n => n.Id == randomItem.Id))
                    {
                        AuthStateProvider.GetCurrentUser().addItem(randomItem);
                    }
                }
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
