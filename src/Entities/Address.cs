using System.ComponentModel.DataAnnotations;

namespace MarketMedia.src.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string? Details { get; set; }

        public int? VillageId { get; set; }
        public Village Village { get; set; }

    }
}
