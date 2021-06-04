using MAData;
using MADomain;
using MAService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAService.Contract
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext ctx;
        public CategoryRepository(ApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }

        public void Create(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            ctx.Categories.Add(category);
            SaveChanges();
        }

        public Category GetById(int Id)
        {
            if (Id <= 0)
                throw new ArgumentNullException("Category");
            return ctx.Categories.FirstOrDefault(c => c.Id == Id);
        }

        public IQueryable<Category> GetCategories()
        {
            return ctx.Categories;
        }

        public void Update(Category category)
        {
            ctx.Categories.Update(category);
            SaveChanges();
        }

        public void Delete(Category category)
        {
            ctx.Categories.Remove(category);

            SaveChanges();
        }

        public bool SaveChanges()
        {
            return (ctx.SaveChanges() >= 0);
        }
    }
}
