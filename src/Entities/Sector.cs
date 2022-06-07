using System.ComponentModel.DataAnnotations;

namespace MarketMedia.src.Entities
{
    public class Sector
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
