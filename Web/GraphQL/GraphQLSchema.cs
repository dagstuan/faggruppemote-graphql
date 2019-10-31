using GraphQL;
using GraphQL.Types;

namespace Web.GraphQL
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(IDependencyResolver resolver) : base(resolver)
        {
        }
    }
}
