using System.ComponentModel.DataAnnotations;

namespace Portfolio_API.Models
{
    public class Projects
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Project Title")]
        public string ProjectTitle { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a Programming Stack")]
        public string ProjectStack { get; set; }
        public string GitUrl { get; set; }
    }
}
