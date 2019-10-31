using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Web.NobelPeacePrizeGraphQL.DAO
{
    public class NobelPrizeList
    {
        [JsonPropertyName("prizes")]
        public IEnumerable<NobelPrizeDAO> Prizes { get; set; }
    }
}
