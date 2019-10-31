using System.Collections.Generic;

namespace Web.NobelPeacePrizeGraphQL.DAO
{
    public class NobelPrizeListLaureateDAO
    {
        public string id { get; set; }
    }

    public class NobelPrizeDAO
    {
        public string year { get; set; }

        public string category { get; set; }

        public List<NobelPrizeListLaureateDAO> laureates { get; set; }
    }
}
