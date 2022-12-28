using Microsoft.AspNetCore.Components;

namespace CraftSharp.Components
{
    public partial class ValueIndicator
    {
        [Parameter]
        public int Value { get; set; }

        [Parameter]
        public String IconPath { get; set; }
    }
}
