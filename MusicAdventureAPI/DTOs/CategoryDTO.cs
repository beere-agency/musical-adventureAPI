using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAdventureAPI.DTOs
{
    public class CategoryDTO : EntityDTO
    {
        public string Description { get; set; }
        public int ProductId { get; set; }
    }
}
