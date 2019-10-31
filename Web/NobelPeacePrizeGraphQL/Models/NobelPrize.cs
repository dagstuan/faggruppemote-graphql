using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Web.NobelPeacePrizeGraphQL.Models
{
    public class NobelPrize
    {
        public string Year { get; set; }

        public NobelPrizeCategory Category { get; set; }
        public IEnumerable<string> Laureates { get; set; } = new List<string>();
    }
}
