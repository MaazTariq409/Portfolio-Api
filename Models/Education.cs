using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio_API.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Degree Name")]
        public string DegreeName { get; set; }
        [Required(ErrorMessage = "Please enter a Degree Level")]
        public string DegreeLevel { get; set; }

        public string passingYear { get; set; }

        [Required(ErrorMessage = "Please enter your grade")]
        public char Grade { get; set; }
        public string Achievement { get; set; }
        [Required]
        public string Institute { get; set; }
        [ForeignKey("UserID")]
        [ValidateNever]
        public User user { get; set; }
        public int UserID { get; set; }
    }
}
