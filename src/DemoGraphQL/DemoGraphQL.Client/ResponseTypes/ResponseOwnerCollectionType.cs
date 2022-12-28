namespace DemoGraphQL.Client.ResponseTypes
{
    using DemoGraphQL.Client.Models;
    using System.Collections.Generic;

    public class ResponseOwnerCollectionType
    {
        public List<Owner> Owners { get; set; }
    }
}