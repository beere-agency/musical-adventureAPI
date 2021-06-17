using AutoMapper;
using MADomain;
using MusicAdventureAPI.DTOs;

namespace MusicAdventureAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductCreationDTO, Product>();
        }
    }
}