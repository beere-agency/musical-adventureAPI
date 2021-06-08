using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAdventureAPI.DTOs
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }

    public class TagCreationDTO
    {
        public string Name { get; set; }
    }

    public class TagUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
