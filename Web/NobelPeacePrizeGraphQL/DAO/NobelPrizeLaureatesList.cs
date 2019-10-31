using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Web.NobelPeacePrizeGraphQL.DAO
{
    public class NobelPrizeLaureatesList
    {
        [JsonPropertyName("laureates")]
        public IEnumerable<NobelPrizeLaureateDAO> Laureates { get; set; }
    }
}
