namespace Web.NobelPeacePrizeGraphQL.Models
{
    public class NobelPrizeInput
    {
        public string Year { get; set; }
        public NobelPrizeCategory? Category { get; set; }
    }
}
