using System.ComponentModel.DataAnnotations;

namespace MarketMedia.src.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
