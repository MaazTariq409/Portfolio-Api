using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio_API.Data;

namespace Portfolio_API.Controllers
{
    [Route("api/[controller]/{userId}")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly PorfolioContext _context;

        public AboutController(PorfolioContext context)
        {
            _context = context;
        }

        // GET: api/<AboutController>
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> GetAboutDetails(int id)
        {
            
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
