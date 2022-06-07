using System.ComponentModel.DataAnnotations;

namespace MarketMedia.src.Entities
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int TIN_number { get; set; }

        public string? mobilePaymentCode { get; set; }

        public string? about { get; set; }

        public string? website { get; set; }

        public string? socialmedia { get; set; }
    }
}
