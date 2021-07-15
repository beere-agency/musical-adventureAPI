using System.Collections.Generic;
using AutoMapper;
using MADomain;
using MusicAdventureAPI.DTOs;

namespace MusicAdventureAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>()
                    .ForMember(x => x.Tags, options => options.MapFrom(MapProductTags))
                    .ForMember(x => x.Categories, options => options.MapFrom(MapProductCategories));
            CreateMap<Product, ProductBasicDTO>();

            //Product Mapping
            CreateMap<ProductCreationDTO, Product>()
                    .ForMember(x => x.ImageUrl, options => options.Ignore())
                    .ForMember(x => x.ProductTags, options => options.MapFrom(MapProductTags))
                    .ForMember(x => x.ProductCategories, options => options.MapFrom(MapProductCategories));
        }

        private List<TagDTO> MapProductTags(Product product, ProductDTO productDTO)
        {
            var result = new List<TagDTO>();

            if (product.ProductTags != null)
            {
                foreach (var tag in product.ProductTags)
                {
                    result.Add(new TagDTO() { Id = tag.TagId, Name = tag.Tag.Name });
                }
            }

            return result;
        }

        private List<CategoryDTO> MapProductCategories(Product product, ProductDTO productDTO)
        {
            var result = new List<CategoryDTO>();

            if (product.ProductCategories != null)
            {
                foreach (var category in product.ProductCategories)
                {
                    result.Add(new CategoryDTO() { Id = category.CategoryId, Name = category.Category.Name });
                }
            }

            return result;
        }

        private List<ProductCategory> MapProductCategories(ProductCreationDTO productCreationDTO, Product product)
        {
            var result = new List<ProductCategory>();

            if (productCreationDTO.CategoryIds == null) { return result; }
            foreach (var id in productCreationDTO.CategoryIds)
            {
                result.Add(new ProductCategory() { CategoryId = id });
            }
            return result;
        }

        private List<ProductTag> MapProductTags(ProductCreationDTO productCreationDTO, Product product)
        {
            var result = new List<ProductTag>();

            if (productCreationDTO.TagIds == null) { return result; }
            foreach (var id in productCreationDTO.TagIds)
            {
                result.Add(new ProductTag() { TagId = id });
            }
            return result;
        }
    }
}