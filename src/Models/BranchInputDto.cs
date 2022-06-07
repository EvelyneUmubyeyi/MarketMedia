namespace MarketMedia.src.Models
{
    public class BranchInputDto
    {
        public string Name { get; set; }

        public string? Street_number { get; set; }

        public string Contact { get; set; }

        public int sellerId { get; set; }
        public int villageId { get; set; }
    }
}
