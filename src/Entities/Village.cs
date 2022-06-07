using System.ComponentModel.DataAnnotations;

namespace MarketMedia.src.Entities
{
    public class Village
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int cellId { get; set; }
        public Cell Cell { get; set; }
    }
}
