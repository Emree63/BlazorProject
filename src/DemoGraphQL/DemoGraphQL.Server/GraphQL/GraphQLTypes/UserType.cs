namespace DemoGraphQL.Server.GraphQL.GraphQLTypes
{
    using DemoGraphQL.Server.Contracts;
    using DemoGraphQL.Server.Entities;
    using global::GraphQL.DataLoader;
    using global::GraphQL.Types;
    using System;

    public class UserType : ObjectGraphType<User>
    {
        public UserType(IDataLoaderContextAccessor dataLoader)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the user object.");
            Field(x => x.Username).Description("Username property from the user object.");
            Field(x => x.numberOfKeys).Description("Number of keys property from the user object.");
            Field(x => x.role).Description("Role property from the user object.");
            Field(x => x.inventory).Description("Inventory property from the user object.");


        }
    }
}