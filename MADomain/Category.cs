namespace MADomain
{
    public class Category : Entity
    {
        public string Description { get; set; }
        public bool IsSubCategory { get; set; }
        public int ParentId { get; set; }
    }
}