using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio_API.Data;
using Portfolio_API.DTOs;
using Portfolio_API.Models;
using Portfolio_API.Repository;
using Portfolio_API.Repository.Repository_Interface;

namespace Portfolio_API.Controllers
{
	[Route("api/skills")]
	[ApiController]
	public class SkillsController : ControllerBase
	{
		private readonly PorfolioContext _context;
		private readonly ISkills _skillsRepository;
		private readonly IMapper _mapper;

		public SkillsController(PorfolioContext context, IMapper mapper, ISkills SkillsRepository )
		{
			_context = context;
			_mapper = mapper;
			_skillsRepository = SkillsRepository;

		}
		[HttpGet("{userId}")]
		public ActionResult<List<Skills>> GetUserSkills(int id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var skillsFromDB = _skillsRepository.GetSkillsByUserID(id);

			var skillsDto = _mapper.Map<IEnumerable<SkillsDto>>(skillsFromDB);

			return Ok(skillsDto);

		}


		//POST api/<SkillsController>
		[HttpPost]
		public ActionResult AddUserSkill(int id, [FromBody] SkillsDto userSkill)
		{
			if (id == null)
			{
				return NotFound();
			}

			var AddSkill = _mapper.Map<Skills>(userSkill);

			_skillsRepository.AddSkillsByUserID(id, AddSkill);

			return Ok();


		}


		[HttpPut("{skillId}")]
		public ActionResult UpdateUserSkill(int id, int skillId, [FromBody] SkillsDto userSkill)
		{
			if (id == null || skillId == null)
			{
				return NotFound();
			}

			var updateskills = _mapper.Map<Skills>(userSkill);

			_skillsRepository.updateSkillsByUserID(id, skillId, updateskills);

			return Ok();

		}


		[HttpDelete]
		public IActionResult DeleteUserSkill(int id, int UserID)
		{

			if (id == null || UserID == null)
			{
				return NotFound();
			}

			_skillsRepository.removeSkillsByUserID(id, UserID);

			return Ok();

		}
	}
}
