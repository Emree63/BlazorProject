namespace DemoGraphQL.Client.Pages
{
    using DemoGraphQL.Client.Models;
    using Microsoft.AspNetCore.Components;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public partial class Consume
    {
        private List<Owner> Owner;

        [Inject]
        public OwnerConsumer Consumer { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.Owner = await Consumer.GetAllOwners();
        }
    }
}