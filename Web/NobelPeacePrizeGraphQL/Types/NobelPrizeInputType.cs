using GraphQL.Types;
using Web.NobelPeacePrizeGraphQL.Models;

namespace Web.NobelPeacePrizeGraphQL.Types
{
    public class NobelPrizeInputType : InputObjectGraphType<NobelPrizeInput>
    {
        public NobelPrizeInputType()
        {
            Name = "NobelPrizeInput";

            Field(x => x.Year, nullable: true);
            Field<NobelPrizeCategoryType>("category");
        }
    }
}
