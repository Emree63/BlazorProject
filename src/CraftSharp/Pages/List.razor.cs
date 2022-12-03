using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace CraftSharp.Pages
{
    public partial class List
    {

        [Inject]
        public IStringLocalizer<List> Localizer { get; set; }
    }
}
