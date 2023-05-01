using System.ComponentModel.DataAnnotations;

namespace Portfolio_API.Models
{
    public class Responsibilities
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Responsibility { get; set; }
        public Experience experience { get; set; }
    }
}
