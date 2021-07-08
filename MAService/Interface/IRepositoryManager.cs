using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAService.Interface
{
    public interface IRepositoryManager
    {
        ITagRepository TagRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IFileStorageRepository FileStorageRepository { get; }
    }
}
