using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Web.NobelPeacePrizeGraphQL.Models
{
    public class NobelPrizeLaureatePrize
    {
        public string Year { get; set; }
        public NobelPrizeCategory Category { get; set; }
    }

    public class NobelPrizeLaureate
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public IEnumerable<NobelPrizeLaureatePrize> Prizes { get; set; } = new List<NobelPrizeLaureatePrize>();
    }
}
