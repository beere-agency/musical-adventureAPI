using AutoMapper;
using MADomain;
using MusicAdventureAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAdventureAPI.Profiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDTO>();
            CreateMap<TagCreationDTO, Tag>();
            CreateMap<TagUpdateDTO, Tag>();
        }
    }
}
