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
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepo;
        private readonly IMapper mapper;
        public CategoryController(ICategoryRepository _category, IMapper mapper)
        {
            categoryRepo = _category;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<CategoryDTO>> GetAllCategories()
        {
            var categories = categoryRepo.GetCategories().ToList();
            return Ok(mapper.Map<List<CategoryDTO>>(categories));
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDTO> GetCategoryById(int id)
        {
            var category = categoryRepo.GetById(id);
            if (category == null) return NotFound();

            return Ok(mapper.Map<CategoryDTO>(category));
        }

        [HttpPost]
        public ActionResult CreateCategory([FromBody]CategoryCreationDTO model)
        {
            var category = mapper.Map<Category>(model);
            categoryRepo.Create(category);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id,[FromBody] CategoryUpdateDTO model)
        {
            var category = categoryRepo.GetById(id);
            if (category == null) return NotFound();
            category = mapper.Map(model, category);
            categoryRepo.Update(category);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var category = categoryRepo.GetById(id);

            if (category == null)
            {
                return NotFound();
            }
            categoryRepo.Delete(category);
            return NoContent();
        }
    }
}
