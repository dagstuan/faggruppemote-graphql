using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Web.NobelPeacePrizeGraphQL.DAO;
using Web.NobelPeacePrizeGraphQL.Models;

namespace Web.NobelPeacePrizeGraphQL
{
    public class NobelPeacePrizeData
    {
        private readonly IEnumerable<NobelPrize> prizes = new List<NobelPrize>();
        private readonly IEnumerable<NobelPrizeLaureate> laureates = new List<NobelPrizeLaureate>();

        public NobelPeacePrizeData()
        {
            using (var reader = File.OpenText("nobel_prizes.json"))
            {
                var lines = reader.ReadToEnd();
                var parsed = JsonSerializer.Deserialize<NobelPrizeList>(lines);
                prizes = parsed.Prizes.Select(p => new NobelPrize
                {
                    Year = p.year,
                    Category = GetCategory(p.category),
                    Laureates = p.laureates?.Select(l => l.id)
                });
            }

            using (var reader = File.OpenText("nobel_prize_winners.json"))
            {
                var lines = reader.ReadToEnd();
                var parsed = JsonSerializer.Deserialize<NobelPrizeLaureatesList>(lines);
                laureates = parsed.Laureates.Select(l => new NobelPrizeLaureate
                {
                    Id = l.id,
                    FirstName = l.firstname,
                    Surname = l.surname,
                    Prizes = l.prizes?.Select(p => new NobelPrizeLaureatePrize
                    {
                        Year = p.year,
                        Category = GetCategory(p.category)
                    }),
                });
            }
        }

        private NobelPrizeCategory GetCategory(string jsonCategory)
        {
            switch (jsonCategory)
            {
                case "chemistry":
                    return NobelPrizeCategory.Chemistry;
                case "medicine":
                    return NobelPrizeCategory.Medicine;
                case "economics":
                    return NobelPrizeCategory.Economics;
                case "peace":
                    return NobelPrizeCategory.Peace;
                case "physics":
                    return NobelPrizeCategory.Physics;
                case "literature":
                    return NobelPrizeCategory.Literature;
                default:
                    throw new System.Exception("Category not found");
            }
        }

        public IEnumerable<NobelPrize> GetPrizes()
        {
            return prizes;
        }

        public IEnumerable<NobelPrize> GetPrizesForYear(string year)
        {
            return prizes.Where(p => p.Year == year);
        }

        public IEnumerable<NobelPrize> GetPrizesForCategory(NobelPrizeCategory category)
        {
            return prizes.Where(p => p.Category == category);
        }

        public IEnumerable<NobelPrizeLaureate> GetLaureates()
        {
            return laureates;
        }

        public NobelPrizeLaureate GetLaureate(string laureateId)
        {
            return laureates.Single(l => l.Id == laureateId);
        }

        public NobelPrize GetPrize(string year, NobelPrizeCategory category)
        {
            return prizes.First(p => p.Year == year && p.Category == category);
        }

        public IEnumerable<NobelPrizeLaureate> GetLaureatesForPrize(string year, NobelPrizeCategory category)
        {
            var laureatesForPrize = GetPrize(year, category).Laureates;

            return laureates.Where(l => laureatesForPrize.Contains(l.Id));
        }

        public IEnumerable<NobelPrize> GetPrizesForLaureate(string laureateId)
        {
            var prizesForLaureate = GetLaureate(laureateId).Prizes;

            return prizes.Where(p => prizesForLaureate.Any(pfl => pfl.Category == p.Category && pfl.Year == p.Year));
        }
    }
}
