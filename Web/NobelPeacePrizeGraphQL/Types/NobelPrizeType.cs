using GraphQL.Types;
using Web.NobelPeacePrizeGraphQL.Models;

namespace Web.NobelPeacePrizeGraphQL.Types
{
    public class NobelPrizeType : ObjectGraphType<NobelPrize>
    {
        public NobelPrizeType(NobelPeacePrizeData data)
        {
            Name = "NobelPrize";

            Field(np => np.Year).Description("The year the prize was given.");
            Field<NobelPrizeCategoryType>("category");

            Field<ListGraphType<NobelPrizeLaureateType>>(
                "laureates",
                resolve: context
                    => data.GetLaureatesForPrize(context.Source.Year, context.Source.Category));
        }
    }
}
