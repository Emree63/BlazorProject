namespace DemoGraphQL.Server.GraphQL.GraphQLQueries
{
    using DemoGraphQL.Server.Contracts;
    using DemoGraphQL.Server.Entities;
    using DemoGraphQL.Server.GraphQL.GraphQLTypes;
    using global::GraphQL;
    using global::GraphQL.Types;
    using System;

    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IUserRepository repository)
        {
            Field<UserType>(
                "createUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }),
                resolve: context =>
                {
                    var user = context.GetArgument<User>("user");
                    return repository.CreateUser(user);
                }
            );

            Field<UserType>(
                "updateUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userId" }),
                resolve: context =>
                {
                    var user = context.GetArgument<User>("user");
                    var userId = context.GetArgument<Guid>("userId");

                    var dbUser = repository.GetById(userId);
                    if (dbUser == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find user in db."));
                        return null;
                    }

                    return repository.UpdateUser(dbUser, user);
                }
            );

            Field<StringGraphType>(
                "deleteUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userId" }),
                resolve: context =>
                {
                    var userId = context.GetArgument<Guid>("userId");
                    var user = repository.GetById(userId);
                    if (user == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find user in db."));
                        return null;
                    }

                    repository.DeleteUser(user);
                    return $"The user with the id: {userId} has been successfully deleted from db.";
                }
            );
        }
    }
}