using MADomain;
using System.Linq;

namespace MAService.Interface
{
    public interface ICategoryRepository
    {
        void Create(Category category);
        void Delete(Category category);
        Category GetById(int Id);
        IQueryable<Category> GetClients();
        void Update(Category category);
    }
}