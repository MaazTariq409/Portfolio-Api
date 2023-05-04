using System.ComponentModel.DataAnnotations;

namespace Portfolio_API.DTOs
{
    public class EducationDto
    {
        public string DegreeName { get; set; }
        [Required(ErrorMessage = "Please enter a Degree Level")]
        public string DegreeLevel { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Please enter your grade")]
        public char Grade { get; set; }
        public string Achievement { get; set; }
        [Required]
        public string Institute { get; set; }
    }
}
