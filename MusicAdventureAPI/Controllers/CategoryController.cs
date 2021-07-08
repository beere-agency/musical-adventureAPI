using AutoMapper;
using MADomain;
using MAService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicAdventureAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAdventureAPI.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/category")]
    public class CategoryController : ControllerBase
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;
        public CategoryController(IMapper _mapper, IRepositoryManager _repositoryManager)
        {
            mapper = _mapper;
            repositoryManager = _repositoryManager;
        }
        [HttpGet]
        public ActionResult<List<CategoryDTO>> GetAllCategories()
        {
            var categories = repositoryManager.CategoryRepository.GetCategories().ToList();
            return Ok(mapper.Map<List<CategoryDTO>>(categories));
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDTO> GetCategoryById(int id)
        {
            var category = repositoryManager.CategoryRepository.GetById(id);
            if (category == null) return NotFound();

            return Ok(mapper.Map<CategoryDTO>(category));
        }

        [HttpPost]
        public ActionResult CreateCategory([FromBody]CategoryCreationDTO model)
        {
            var category = mapper.Map<Category>(model);
            repositoryManager.CategoryRepository.Create(category);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id,[FromBody] CategoryUpdateDTO model)
        {
            var category = repositoryManager.CategoryRepository.GetById(id);
            if (category == null) return NotFound();
            category = mapper.Map(model, category);
            repositoryManager.CategoryRepository.Update(category);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var category = repositoryManager.CategoryRepository.GetById(id);

            if (category == null)
            {
                return NotFound();
            }
            repositoryManager.CategoryRepository.Delete(category);
            return NoContent();
        }
    }
}
