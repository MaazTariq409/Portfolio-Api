using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio_API.Data;
using Portfolio_API.Models;

namespace Portfolio_API.Controllers
{
    [Route("api/aboutDetails")]
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
        public ActionResult<IEnumerable<string>> aboutDetails(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var aboutDetails = _context.about.FirstOrDefault(a => a.Id == id);
            if (aboutDetails == null)
            {
                return NotFound();
            }

            return Ok(aboutDetails);
        }

        // POST api/<AboutController>
        [HttpPost]
        public ActionResult aboutDetails(About about)
        {
            if(about == null)
            {
                return BadRequest();
            }

            _context.about.Add(about);
            _context.SaveChanges();

            return Ok();

        }

        //// PUT api/<AboutController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AboutController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
