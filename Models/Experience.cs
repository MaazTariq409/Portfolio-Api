using System.ComponentModel.DataAnnotations;

namespace Portfolio_API.Models
{
    public class Experience
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a company")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Please enter a Job Title")]
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Please enter responsibilities")]
        public string[] Responsibilities { get; set; }
    }
}
