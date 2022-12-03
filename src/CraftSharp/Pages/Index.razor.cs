using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using CraftSharp.Models;

namespace CraftSharp.Pages
{
    public partial class Index
    {
        [Inject]
        public IStringLocalizer<Index> Localizer { get; set; }

    }
}
