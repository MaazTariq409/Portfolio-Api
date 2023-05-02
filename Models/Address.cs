using System.ComponentModel.DataAnnotations;

namespace Portfolio_API.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }

    }
}
