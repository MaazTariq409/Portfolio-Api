using System.ComponentModel.DataAnnotations;

namespace Portfolio_API.Models
{
    public class Skills
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Skill")]
        public string SkillName { get; set; }
        [Required]
        public string SkillLevel { get; set; }
    }
}
