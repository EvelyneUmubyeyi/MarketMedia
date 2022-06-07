using System.ComponentModel.DataAnnotations;

namespace MarketMedia.src.Entities
{
    public class Cell
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int sectorId { get; set; }
        public Sector Sector { get; set; }
    }
}
