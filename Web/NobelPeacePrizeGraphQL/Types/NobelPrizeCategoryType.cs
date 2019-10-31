using GraphQL.Types;
using Web.NobelPeacePrizeGraphQL.Models;

namespace Web.NobelPeacePrizeGraphQL.Types
{
    public class NobelPrizeCategoryType : EnumerationGraphType
    {
        public NobelPrizeCategoryType()
        {
            Name = "Category";
            Description = "Category of Nobel prize.";
            AddValue("chemistry", "Chemistry", NobelPrizeCategory.Chemistry);
            AddValue("medicine", "Medicine", NobelPrizeCategory.Medicine);
            AddValue("economics", "Economics", NobelPrizeCategory.Economics);
            AddValue("peace", "Peace", NobelPrizeCategory.Peace);
            AddValue("physics", "Physics", NobelPrizeCategory.Physics);
            AddValue("literature", "Literature", NobelPrizeCategory.Literature);
        }
    }
}
