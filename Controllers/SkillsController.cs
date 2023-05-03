using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio_API.Data;
using Portfolio_API.Models;

namespace Portfolio_API.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class SkillsController : ControllerBase
	{
		private readonly PorfolioContext _context;

		public SkillsController(PorfolioContext context)
		{
			_context = context;
		}
		[HttpGet("{userId}/skills")]
		public ActionResult<List<Skills>> GetUserSkills(int userId)
		{
			var userSkills = _context.skills.Where(s => s.UserID == userId).ToList();
			return Ok(userSkills);
		}


		// POST api/<SkillsController>
		[HttpPost]
		public ActionResult AddUserSkill(int userId, [FromBody] Skills userSkill)
		{
			var user = _context.user.FirstOrDefault(u => u.Id == userId);
			if (user == null)
			{
				return NotFound();
			}

			//var skill = new Skills { SkillName = userSkill.SkillName, SkillLevel = userSkill.SkillLevel };

			//userSkill.UserID = userId;
			user.Skills.Add(userSkill);
			_context.SaveChanges();

			return Ok();
		}
		[HttpPut("users/{userId}/skills/{skillId}")]
		public ActionResult UpdateUserSkill(int userId, int skillId, [FromBody] Skills skillobj)
		{
			var user = _context.user.Include(u => u.Skills).FirstOrDefault(u => u.Id == userId);
			if (user == null)
			{
				return NotFound();
			}

			var skill = user.Skills.FirstOrDefault(s => s.Id == skillId);
			if (skill == null)
			{
				return NotFound();
			}

			// Update 
			skill.SkillName = skillobj.SkillName;
			skill.SkillName = skillobj.SkillName;

			_context.SaveChanges();

			return Ok();
		}
		[HttpDelete("users/{userId}/skills/{skillId}")]
		public IActionResult DeleteUserSkill(int userId, int skillId)
		{
			var user = _context.user.Include(u => u.Skills).FirstOrDefault(u => u.Id == userId);
			if (user == null)
			{
				return NotFound();
			}

			// Find the skill in the user's Skills collection.
			var skill = user.Skills.FirstOrDefault(s => s.Id == skillId);
			if (skill == null)
			{
				return NotFound();
			}
			user.Skills.Remove(skill);

			_context.SaveChanges();
			return Ok();
		}
	}
}
