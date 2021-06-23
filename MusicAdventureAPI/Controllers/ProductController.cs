using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MADomain;
using MAService.Interface;
using Microsoft.AspNetCore.Mvc;
using MusicAdventureAPI.DTOs;

namespace MusicAdventureAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepo;
        private readonly IMapper mapper;
        private readonly IFileStorageRepository fileStorage;
        private string container = "MAproducts";
        public ProductController(IProductRepository _productRepo, IMapper _mapper, IFileStorageRepository _fileStorage)
        {
            productRepo = _productRepo;
            mapper = _mapper;
            fileStorage = _fileStorage;
        }

        [HttpGet]
        public ActionResult<List<ProductDTO>> GetAllProducts()
        {
            var products = productRepo.GetProductsWithRelationship().ToList();
            return Ok(mapper.Map<List<ProductDTO>>(products));
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProductsById(int id)
        {
            var product = productRepo.GetById(id);
            if (product == null) return NotFound();

            return Ok(mapper.Map<ProductDTO>(product));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductCreationDTO model)
        {
            var product = mapper.Map<Product>(model);
            if (model.ImageFile != null)
            {
                product.ImageUrl = await fileStorage.SaveFile(container, model.ImageFile);
            }
            productRepo.Create(product);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductCreationDTO model)
        {
            var product = productRepo.GetById(id);
            if (product is null)
            {
                return NotFound();
            }
            product = mapper.Map(model, product);
            if (model.ImageFile != null)
            {
                product.ImageUrl = await fileStorage.EditFile(container, model.ImageFile, product.ImageUrl);
            }
            productRepo.Update(product);
            return NoContent();
        }
    }
}