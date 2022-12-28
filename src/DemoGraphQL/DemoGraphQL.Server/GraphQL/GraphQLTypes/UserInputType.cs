namespace DemoGraphQL.Server.GraphQL.GraphQLTypes
{
    using global::GraphQL.Types;

    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "userInput";
            Field<NonNullGraphType<StringGraphType>>("username");
        }
    }
}