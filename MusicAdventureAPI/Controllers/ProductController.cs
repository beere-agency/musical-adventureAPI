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
        private readonly IMapper mapper;
        private readonly IRepositoryManager repositoryManager;
        private string container = "maproducts";
        public ProductController(IMapper _mapper,IRepositoryManager _repositoryManager)
        {
            mapper = _mapper;
            repositoryManager = _repositoryManager;
        }

        [HttpGet]
        public ActionResult<List<ProductDTO>> GetAllProducts()
        {
            var products = repositoryManager.ProductRepository.GetProductsWithRelationship().ToList();
            return Ok(mapper.Map<List<ProductDTO>>(products));
        }

        [HttpGet("basic")]
        public ActionResult<List<ProductDTO>> GetAllProductsBasicDetial()
        {
            var products = repositoryManager.ProductRepository.GetProductsWithRelationship().ToList();
            return Ok(mapper.Map<List<ProductBasicDTO>>(products));
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProductsById(int id)
        {
            var product = repositoryManager.ProductRepository.GetById(id);
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
                product.ImageUrl = await repositoryManager.FileStorageRepository.SaveFile(container, model.ImageFile);
            }
            repositoryManager.ProductRepository.Create(product);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromForm] ProductCreationDTO model)
        {
            var product = repositoryManager.ProductRepository.GetById(id);
            if (product is null)
            {
                return NotFound();
            }
            product = mapper.Map(model, product);
            if (model.ImageFile != null)
            {
                product.ImageUrl = await repositoryManager.FileStorageRepository.EditFile(container, model.ImageFile, product.ImageUrl);
            }
            repositoryManager.ProductRepository.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = repositoryManager.ProductRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }
            repositoryManager.ProductRepository.Delete(product);
            await repositoryManager.FileStorageRepository.DeleteFile(product.ImageUrl, container);
            return NoContent();
        }
    }
}