using Portfolio_API.DTOs;
using Portfolio_API.Models;

namespace Portfolio_API.Repository.Repository_Interface
{
	public interface ISkills
	{
		public IEnumerable<Skills> GetSkillsByUserID(int id);
		public void AddSkillsByUserID(int id, Skills skills);
		public void updateSkillsByUserID (int id, int UserID, Skills skill);
		public void removeSkillsByUserID(int id, int UserID);


	}
}
