using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace MusicAdventureAPI.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public List<TagDTO> Tags { get; set; }
    }

    public class ProductCreationDTO
    {
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile ImageUrl { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> TagIds { get; set; }
    }
}