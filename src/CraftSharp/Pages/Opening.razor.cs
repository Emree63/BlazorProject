using CraftSharp.Factories;
using CraftSharp.Models;
using CraftSharp.Services;
using Microsoft.AspNetCore.Components;

namespace CraftSharp.Pages
{
    public partial class Opening
    {
        public Item randomItem;

        string closeAnim = "";
        string openAnim = "";
        string itemAnim = "";

        bool canOpen = true;

        int itemOpacity = 0;

        [Inject]
        public IDataService DataService { get; set; }

        int totalItem;
        List<Item> items;

        protected override async Task OnInitializedAsync()
        {
            totalItem = await DataService.Count();

            items = await DataService.List(0, totalItem);
        }

        async void selectRandom()
        {

            if (canOpen)
            {
                randomItem = ItemFactory.GetRandomItem(items);
                Console.WriteLine(randomItem.Name);
                openingAnimation();
            }

        }

        async void openingAnimation()
        {
            itemOpacity = 0;
            canOpen = false;
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
            canOpen = true;
            StateHasChanged();


        }
    }
}
