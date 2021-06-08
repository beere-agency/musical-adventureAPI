using System;

namespace MADomain
{
    public class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; } = DateTime.Now;
    }
}