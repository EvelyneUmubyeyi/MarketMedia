namespace MarketMedia.src.Models
{
    public class BranchOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Street_number { get; set; }
        public string Contact { get; set; }
        public int sellerId { get; set; }
        //public string Seller { get; set; }
        public int villageId { get; set; }
        //public string Village { get; set; }
    }
}
