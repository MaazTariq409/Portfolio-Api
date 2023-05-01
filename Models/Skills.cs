using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio_API.Models
{
    public class Skills
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Skill")]
        public string SkillName { get; set; }
        [Required]
        public string SkillLevel { get; set; }
        [ForeignKey("SignUpID")]
        public SignUp SignUp { get; set; }
        public int SignUpID { get; set; }
    }
}
