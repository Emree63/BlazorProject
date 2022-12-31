using CraftSharp.Components;
using CraftSharp.Models;
using CraftSharp.Services;
using Microsoft.AspNetCore.Components;

namespace CraftSharp.Components
{
    public partial class DeleteItem
    {
        [Parameter]
        public int Index { get; set; }

        [Parameter]
        public Item Item { get; set; }

        [Parameter]
        public bool NoDrop { get; set; }

        [CascadingParameter]
        public Crafting Parent { get; set; }

        [Inject]
        public CustomStateProvider AuthStateProvider { get; set; }

        internal void OnDrop()
        {
            if (NoDrop)
            {
                return;
            }

            this.Item = Parent.CurrentDragItem;

            if (AuthStateProvider.GetCurrentUser().Inventory.Any(n => n.Id == this.Item.Id))
            {
                AuthStateProvider.GetCurrentUser().DeleteItem(this.Item);
                this.Item = null;
                Parent.Suppression();
            }

        }


    }
}
