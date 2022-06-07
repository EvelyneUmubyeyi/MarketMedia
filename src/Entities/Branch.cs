using System.ComponentModel.DataAnnotations;

namespace MarketMedia.src.Entities
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Street_number { get; set; }

        public string Contact { get; set; }

        public int sellerId { get; set; }
        public Seller Seller { get; set; }
        public int villageId { get; set; }
        public Village Village { get; set; }
    }
}
