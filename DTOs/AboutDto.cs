using Portfolio_API.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Portfolio_API.DTOs
{
    public class AboutDto
    {
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter Last Name"), MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter a Phone No")]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please upload an image")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter an Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Linkedin { get; set; }
        public string Git { get; set; }
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
