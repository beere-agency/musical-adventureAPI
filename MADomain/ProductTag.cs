namespace MADomain
{
    public class ProductTag
    {
        public int TagId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Tag Tag { get; set; }
    }
}