namespace MarketMedia.src.Models
{
    public class ProductSellerOutputDto
    {
        public int ProductId { get; set; }
        //public string Product { get; set; }
        public int SellerId { get; set; }
        //public string Seller { get; set; }
        public decimal price { get; set; }
        public decimal discount { get; set; }
        public string? quantity_measurement { get; set; }
        public int quantity { get; set; }
        public string? promotion { get; set; }
        public decimal total_price { get; set; }
    }
}
