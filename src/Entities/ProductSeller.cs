using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketMedia.src.Entities
{
    public class ProductSeller
    {
        //[Key]
      //  public int Id { get; set; } 
        [Key]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Key]
        public int SellerId { get; set; }
        [ForeignKey("SellerId")]

        public Seller Seller { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal discount { get; set; }
        public string? quantity_measurement { get; set; }

        public int quantity { get; set; }
        public string? promotion { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal total_price { get; set; }
    }
}
