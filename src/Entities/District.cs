using System.ComponentModel.DataAnnotations;

namespace MarketMedia.src.Entities
{
    public class District
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}
