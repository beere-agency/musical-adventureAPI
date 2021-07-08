using MAData;
using MAService.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAService.Implementation
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext ctx;
        private readonly IConfiguration config;
        private ITagRepository _tagRepository;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private IFileStorageRepository _fileStorageRepository;
        public RepositoryManager(ApplicationDbContext _ctx, IConfiguration _config)
        {
            ctx = _ctx;
            config = _config;
        }

        public ITagRepository TagRepository
        {
            get
            {
                if (_tagRepository == null)
                    _tagRepository = new TagRepository(ctx);

                return _tagRepository;

            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(ctx);

                return _categoryRepository;

            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(ctx);

                return _productRepository;

            }
        }

        public IFileStorageRepository FileStorageRepository
        {
            get
            {
                if (_fileStorageRepository == null)
                    _fileStorageRepository = new FileStorageRepository(config);

                return _fileStorageRepository;

            }
        }
    }
}
