using System.Collections.Generic;

namespace MADomain
{
    public class Product : Entity
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductTag> ProductTags { get; set; }
    }
}