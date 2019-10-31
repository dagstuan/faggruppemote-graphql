using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web.NobelPeacePrizeGraphQL;
using Web.NobelPeacePrizeGraphQL.Models;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController
    {
        private readonly NobelPeacePrizeData _data;
        public TestController(NobelPeacePrizeData data)
        {
            _data = data;
        }

        [HttpGet]
        public IEnumerable<NobelPrize> Get()
        {
            return _data.GetPrizes();
        }
    }
}
