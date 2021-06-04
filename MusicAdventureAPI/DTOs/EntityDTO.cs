using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAdventureAPI.DTOs
{
    public class EntityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
