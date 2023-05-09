using System.ComponentModel.DataAnnotations;

namespace Portfolio_API.Models
{
    public class Hobbies
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string HobbyName { get; set; }
    }
}
