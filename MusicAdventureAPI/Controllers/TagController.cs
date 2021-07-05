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
    [Route("api/tag")]
    [Authorize]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagRepository tagRepo;
        private readonly IMapper mapper;
        public TagController(ITagRepository _tagRepo, IMapper mapper)
        {
            tagRepo = _tagRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<TagDTO>> GetAllTags()
        {
            var tags = tagRepo.GetTags().ToList();
            return Ok(mapper.Map<List<TagDTO>>(tags));
        }

        [HttpGet("{id}")]
        public ActionResult<TagDTO> GetTagById(int id)
        {
            var tag = tagRepo.GetById(id);
            if (tag == null) return NotFound();

            return Ok(mapper.Map<TagDTO>(tag));
        }

        [HttpPost]
        public ActionResult CreateTag([FromBody] TagCreationDTO model)
        {
            var tag = mapper.Map<Tag>(model);
            tagRepo.Create(tag);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTag(int id, [FromBody] TagUpdateDTO model)
        {
            var tag = tagRepo.GetById(id);
            if (tag == null) return NotFound();
            tag = mapper.Map(model, tag);
            tagRepo.Update(tag);

            return NoContent();
        }
    }
}
