using CraftSharp.Components;
using CraftSharp.Models;
using CraftSharp.Services;
using Microsoft.AspNetCore.Components;

namespace CraftSharp.Pages
{
    public partial class TableDeCraft
    {
        [Inject]
        public IDataService DataService { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        [Inject]
        public CustomStateProvider AuthStateProvider { get; set; }
        private List<CraftingRecipe> Recipes { get; set; } = new List<CraftingRecipe>();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            base.OnAfterRenderAsync(firstRender);

            if (!firstRender)
            {
                return;
            }

            //Items = await DataService.List(0, await DataService.Count());
            Items = AuthStateProvider.GetCurrentUser().Inventory;
            Recipes = await DataService.GetRecipes();

            StateHasChanged();
        }
    }
}
