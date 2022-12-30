using Microsoft.AspNetCore.Components;

namespace CraftSharp.Components
{
    public partial class ShopOffer
    {
        [Parameter]
        public int inputAmount { get; set; }

        [Parameter]
        public int outputAmount{ get; set; }

        [Parameter]
        public string centerText { get; set; }

        [Parameter]
        public string inputIcon { get; set; }

        [Parameter]
        public string outputIcon { get; set; }
    }
}
