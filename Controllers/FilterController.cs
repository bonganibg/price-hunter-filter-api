using Microsoft.AspNetCore.Mvc;
using PriceHunterFilter;

namespace PriceHunterFilterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private static readonly string MONGO_CLIENT = @"mongodb://mongo:ycsHIZ1AbCoCIpEeKY8T@containers-us-west-166.railway.app:7962";
        private static readonly string DATABASE_NAME = "pc-part-hunter";
        private static readonly string API_COLLETION = "products";
        private static readonly string SCRAPER_COLLECTION = "holders";
        // GET: api/<FilterController>
        [HttpGet]
        public Dictionary<string,string> Get()
        {            
            PriceHunterMain filter = new PriceHunterMain(MONGO_CLIENT,DATABASE_NAME,API_COLLETION,SCRAPER_COLLECTION);
            filter.Start();
            return filter.GetLogs();
        }

        private void LoadService()
        {
            
        }

        // GET api/<FilterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FilterController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FilterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FilterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
