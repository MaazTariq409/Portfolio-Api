using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio_API.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a company")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Please enter a Job Title")]
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
