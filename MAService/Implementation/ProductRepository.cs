using System;
using System.Linq;
using MAData;
using MADomain;
using MAService.Interface;
using Microsoft.EntityFrameworkCore;

namespace MAService.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext ctx;
        public ProductRepository(ApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }

        public void Create(Product product)
        {
            if (product is not null)
            {
                product.DateCreated = DateTime.Now;
                product.LastModified = DateTime.Now;
                ctx.Products.Add(product);
                SaveChanges();
            }
            else
            {
                throw new ArgumentNullException(nameof(product));
            }
        }

        public Product GetById(int Id)
        {
            if (Id <= 0)
                throw new ArgumentNullException("product");
            return GetProductsWithRelationship().FirstOrDefault(c => c.Id == Id);
        }

        public IQueryable<Product> GetProducts()
        {
            return ctx.Products;
        }

        public IQueryable<Product> GetProductsWithRelationship()
        {
            return ctx.Products
                        .Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                        .Include(x => x.ProductTags).ThenInclude(x => x.Tag)
                        .AsSplitQuery();
        }

        public void Update(Product product)
        {
            product.LastModified = DateTime.Now;
            ctx.Products.Update(product);
            SaveChanges();
        }

        public void Delete(Product product)
        {
            ctx.Products.Remove(product);

            SaveChanges();
        }
        public bool SaveChanges()
        {
            return (ctx.SaveChanges() >= 0);
        }
    }
}