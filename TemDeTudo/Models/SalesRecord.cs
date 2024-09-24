namespace TemDeTudo.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime  Date { get; set; }
        public Decimal Price { get; set; }
        public SalesStatus Status { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }

    public enum SalesStatus : int
    {
        PENDING = 0,
        BILLED = 1,
        CANCELED = 2
    }
}
