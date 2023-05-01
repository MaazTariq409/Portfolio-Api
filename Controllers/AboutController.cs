using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        // GET: api/<AboutController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AboutController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AboutController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AboutController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AboutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
