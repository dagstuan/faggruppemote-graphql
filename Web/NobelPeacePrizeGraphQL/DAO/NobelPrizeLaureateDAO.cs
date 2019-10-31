using System.Collections.Generic;

namespace Web.NobelPeacePrizeGraphQL.DAO
{
    public class NobelPrizeLaureateListPrizeDAO
    {
        public string year { get; set; }
        public string category { get; set; }
    }

    public class NobelPrizeLaureateDAO
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }

        public IEnumerable<NobelPrizeLaureateListPrizeDAO> prizes { get; set; }
    }
}
