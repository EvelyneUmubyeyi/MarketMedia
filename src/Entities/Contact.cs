using System.ComponentModel.DataAnnotations;

namespace MarketMedia.src.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        public string? phone { get; set; }
    }
}
