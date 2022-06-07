namespace MarketMedia.src.Models
{
    public class SellerOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TIN_number { get; set; }

        public string? mobilePaymentCode { get; set; }

        public string? about { get; set; }

        public string? website { get; set; }

        public string? socialmedia { get; set; }
    }
}
