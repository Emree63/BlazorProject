using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;


namespace CraftSharp.Shared
{
    public partial class HeaderLayout
    {
        [Inject]
        public IStringLocalizer<Index> Localizer { get; set; }
    }
}
