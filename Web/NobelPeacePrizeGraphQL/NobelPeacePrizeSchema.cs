using GraphQL;
using GraphQL.Types;

namespace Web.NobelPeacePrizeGraphQL
{
    public class NobelPeacePrizeSchema : Schema
    {
        public NobelPeacePrizeSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<NobelPeacePrizeQuery>();
        }
    }
}
