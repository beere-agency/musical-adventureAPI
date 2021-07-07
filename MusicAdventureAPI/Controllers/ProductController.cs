using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MADomain;
using MAService.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAdventureAPI.DTOs;

namespace MusicAdventureAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepo;
        private readonly IMapper mapper;
        private readonly IFileStorageRepository fileStorage;
        private string container = "maproducts";
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
        //[Consumes("multipart/form-data")]
        public async Task<ActionResult> CreateProduct([FromForm] ProductCreationDTO model)
        {
            var product = mapper.Map<Product>(model);
            if (model.ImageFile != null)
            {
                product.ImageUrl = await fileStorage.SaveFile(container, model.ImageFile);
            }
            productRepo.Create(product);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromForm] ProductCreationDTO model)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = productRepo.GetById(id);

            if (product == null)
            {
                return NotFound();
            }
            productRepo.Delete(product);
            await fileStorage.DeleteFile(product.ImageUrl, container);
            return NoContent();
        }
    }
}