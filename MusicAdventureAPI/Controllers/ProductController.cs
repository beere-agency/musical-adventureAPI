using System.Collections.Generic;
using System.Linq;
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
        public ProductController(IProductRepository _productRepo, IMapper _mapper)
        {
            productRepo = _productRepo;
            mapper = _mapper;
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
        public ActionResult CreateProduct([FromBody] ProductCreationDTO model)
        {
            var product = mapper.Map<Product>(model);
            productRepo.Create(product);

            return NoContent();
        }
    }
}