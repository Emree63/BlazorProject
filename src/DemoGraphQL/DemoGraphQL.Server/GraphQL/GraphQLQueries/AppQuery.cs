namespace DemoGraphQL.Server.GraphQL.GraphQLQueries
{
    using DemoGraphQL.Server.Contracts;
    using DemoGraphQL.Server.GraphQL.GraphQLTypes;
    using global::GraphQL;
    using global::GraphQL.Types;
    using System;

    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IUserRepository repository)
        {
            Field<ListGraphType<UserType>>(
               "users",
               resolve: context => repository.GetAll()
           );

            Field<UserType>(
                "user",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userId" }),
                resolve: context =>
                {
                    Guid id;
                    if (!Guid.TryParse(context.GetArgument<string>("userId"), out id))
                    {
                        context.Errors.Add(new ExecutionError("Wrong value for guid"));
                        return null;
                    }
                    return repository.GetById(id);
                }
            );
        }
    }
}