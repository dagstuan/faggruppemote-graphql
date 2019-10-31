using System.Collections.Generic;
using GraphQL.Types;
using Web.NobelPeacePrizeGraphQL.Models;
using Web.NobelPeacePrizeGraphQL.Types;

namespace Web.NobelPeacePrizeGraphQL
{
    public class NobelPeacePrizeQuery : ObjectGraphType<object>
    {
        public NobelPeacePrizeQuery(NobelPeacePrizeData data)
        {
            Name = "Query";

            Field<ListGraphType<NobelPrizeType>>(
                "prizes",
                arguments: new QueryArguments(
                    new QueryArgument<NobelPrizeInputType> { Name = "input", Description = "Input args" }
                ),
                resolve: context =>
                {
                    var input = context.GetArgument<NobelPrizeInput>("input");

                    if (input == null)
                    {
                        return data.GetPrizes();
                    }

                    if (string.IsNullOrWhiteSpace(input.Year) && !input.Category.HasValue)
                    {
                        return new List<NobelPrize>();
                    }

                    if (!string.IsNullOrWhiteSpace(input.Year) && input.Category.HasValue)
                    {
                        return new List<NobelPrize>{
                            data.GetPrize(input.Year, input.Category.Value)
                        };
                    }

                    if (!input.Category.HasValue)
                    {
                        return data.GetPrizesForYear(input.Year);
                    }

                    return data.GetPrizesForCategory(input.Category.Value);
                }
                );

            Field<NobelPrizeLaureateType>(
                "laureates",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the laureate" }
                ),
                resolve: context
                    => data.GetLaureate(context.GetArgument<string>("id"))
                );
        }
    }
}
