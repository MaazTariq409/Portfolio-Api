using AutoMapper;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Portfolio_API.Data;
using Portfolio_API.DTOs;
using Portfolio_API.Models;
using Portfolio_API.Repository.Repository_Interface;

namespace Portfolio_API.Repository
{
	public class SkillsRepository : ISkills
	{
		private readonly PorfolioContext _context;
		public SkillsRepository(PorfolioContext context)
		{
			_context = context;

		}
		public IEnumerable<Skills> GetSkillsByUserID(int id)
		{
			return _context.skills.ToList();

		}
		public void AddSkillsByUserID(int id, Skills skills)
		{
			var users = _context.user.Include(x => x.Skills).FirstOrDefault(x => x.Id == id);
			users.Skills.Add(skills);
			Save();

		}

		public void updateSkillsByUserID(int id, int UserID, Skills skill)
		{
			var user = _context.user.Include(x => x.Skills).FirstOrDefault(x => x.Id == id);
			if (user != null)
			{
				var _Findskill = _context.skills.FirstOrDefault(i => i.Id == id);
				if (_Findskill != null)
				{
					_Findskill.SkillName = skill.SkillName;
					_Findskill.SkillLevel = skill.SkillLevel;
				}
				Save();
			}

		}

		public void removeSkillsByUserID(int id, int UserID)
		{
			var users = _context.user.Include(x => x.Skills).FirstOrDefault(x => x.Id == UserID);
			_context.Remove(users);
			_context.SaveChanges();
		}


		public void Save()
		{
			_context.SaveChanges();
		}


	}
}
