using System.Linq;
using MADomain;

namespace MAService.Interface
{
    public interface IProductRepository
    {
        void Create(Product product);
        void Delete(Product product);
        Product GetById(int Id);
        IQueryable<Product> GetProducts();
        void Update(Product product);
    }
}