using System.ComponentModel.DataAnnotations;

namespace MarketMedia.src.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
