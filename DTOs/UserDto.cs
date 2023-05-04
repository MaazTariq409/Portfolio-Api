using System.ComponentModel.DataAnnotations;

namespace Portfolio_API.DTOs
{
    public class UserDto
    {
        [Required(ErrorMessage = "Please enter a Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter an Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        public string ConfirmPassword { get; set; }
	}
}
