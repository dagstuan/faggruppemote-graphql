using GraphQL.Types;
using Web.NobelPeacePrizeGraphQL.Models;

namespace Web.NobelPeacePrizeGraphQL.Types
{
    public class NobelPrizeLaureateType : ObjectGraphType<NobelPrizeLaureate>
    {
        public NobelPrizeLaureateType(NobelPeacePrizeData data)
        {
            Name = "NobelPrizeLaureate";

            Field(l => l.Id).Description("The id of the laureate");
            Field(l => l.FirstName).Description("The first name of the laureate");
            Field(l => l.Surname).Description("The last name of the laureate.");

            Field<ListGraphType<NobelPrizeType>>(
                "prizes",
                resolve: context
                    => data.GetPrizesForLaureate(context.Source.Id));
        }
    }
}
