using AutoMapper;
using MADomain;
using MAService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Route("api/v{version:apiVersion}/tag")]
    public class TagController : ControllerBase
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;
        public TagController(IMapper _mapper, IRepositoryManager _repositoryManager)
        {
            mapper = _mapper;
            repositoryManager = _repositoryManager;
        }

        [HttpGet]
        public ActionResult<List<TagDTO>> GetAllTags()
        {
            var tags = repositoryManager.TagRepository.GetTags().ToList();
            return Ok(mapper.Map<List<TagDTO>>(tags));
        }

        [HttpGet("{id}")]
        public ActionResult<TagDTO> GetTagById(int id)
        {
            var tag = repositoryManager.TagRepository.GetById(id);
            if (tag == null) return NotFound();

            return Ok(mapper.Map<TagDTO>(tag));
        }

        [HttpPost]
        public ActionResult CreateTag([FromBody] TagCreationDTO model)
        {
            var tag = mapper.Map<Tag>(model);
            repositoryManager.TagRepository.Create(tag);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTag(int id, [FromBody] TagUpdateDTO model)
        {
            var tag = repositoryManager.TagRepository.GetById(id);
            if (tag == null) return NotFound();
            tag = mapper.Map(model, tag);
            repositoryManager.TagRepository.Update(tag);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTag(int id)
        {
            var tag = repositoryManager.TagRepository.GetById(id);

            if (tag == null)
            {
                return NotFound();
            }
            repositoryManager.TagRepository.Delete(tag);
            return NoContent();
        }
    }
}
