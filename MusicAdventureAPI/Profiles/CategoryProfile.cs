using AutoMapper;
using MADomain;
using MusicAdventureAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAdventureAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryCreationDTO, Category>();
            CreateMap<CategoryUpdateDTO, Category>();
        }
    }
}
