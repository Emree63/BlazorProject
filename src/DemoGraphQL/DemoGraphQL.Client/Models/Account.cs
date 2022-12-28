namespace DemoGraphQL.Client.Models
{
    using System;

    public class Account
    {
        public string Description { get; set; }
        public Guid Id { get; set; }
        public TypeOfAccount Type { get; set; }
    }
}