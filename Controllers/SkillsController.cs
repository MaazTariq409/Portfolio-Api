using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
	[Authorize]
	[ApiController]
	public class SkillsController : ControllerBase
	{
		private readonly PorfolioContext _context;
		private readonly ISkills _skillsRepository;
		private readonly IMapper _mapper;
		private ResponseObject _responseObject;

		public SkillsController(PorfolioContext context, IMapper mapper, ISkills SkillsRepository)
		{
			_context = context;
			_mapper = mapper;
			_skillsRepository = SkillsRepository;

		}
		[HttpGet]
		public ActionResult<List<Skills>> GetUserSkills()
		{
			var userId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);

			if (userId == null)
			{
				_responseObject = ResponseBuilder.GenerateResponse(ResultCode.Failure.ToString(), "Result not found");
			}
			else
			{

				var skillsFromDB = _skillsRepository.GetSkillsByUserID(userId);

				var skillsDto = _mapper.Map<IEnumerable<SkillsDto>>(skillsFromDB);

				_responseObject = ResponseBuilder.GenerateResponse(ResultCode.Success.ToString(), null, skillsDto);

			}

			return Ok(_responseObject);

		}


		//POST api/<SkillsController>
		[HttpPost]
		public ActionResult AddUserSkill([FromBody] SkillsDto userSkill)
		{
			var userId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
			if (userId == 0)
			{
				return NotFound();
			}

			var AddSkill = _mapper.Map<Skills>(userSkill);

			_skillsRepository.AddSkillsByUserID(userId, AddSkill);

			return Ok();


		}


		[HttpPut("{skillId}")]
		public ActionResult UpdateUserSkill(int skillId, [FromBody] SkillsDto userSkill)
		{
			var userId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
			if (userId == 0 || skillId == 0)
			{
				return NotFound();
			}

			var updateskills = _mapper.Map<Skills>(userSkill);

			_skillsRepository.updateSkillsByUserID(userId, skillId, updateskills);

			return Ok();

		}


		[HttpDelete]
		public IActionResult DeleteUserSkill(int skillId)
		{
			var userId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);

			if (userId == 0 || skillId == 0)
			{
				return NotFound();
			}

			_skillsRepository.removeSkillsByUserID(userId, skillId);

			return Ok();

		}
	}
}
