namespace DemoGraphQL.Server.GraphQL.GraphQLSchema
{
    using DemoGraphQL.Server.GraphQL.GraphQLQueries;
    using global::GraphQL.Types;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
            Mutation = provider.GetRequiredService<AppMutation>();
        }
    }
}