using Microsoft.AspNetCore.Mvc;
using Portfolio_API.Data;
using Portfolio_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio_API.Controllers
{
	[Route("api/skills")]
	[ApiController]
	public class SkillsController : ControllerBase
	{
		private readonly PorfolioContext _context;

		public SkillsController(PorfolioContext context)
		{
			_context = context;
		}
		// GET: api/<SkillsController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var users = await _context.users
			.Include(_ => _.skills).ToListAsync();
			return Ok(users);
		}
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<SkillsController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<SkillsController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<SkillsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<SkillsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}



}
