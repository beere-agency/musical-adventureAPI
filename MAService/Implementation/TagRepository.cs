using MAData;
using MADomain;
using MAService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAService.Implementation
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext ctx;
        public TagRepository(ApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }

        public void Create(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));
            tag.DateCreated = DateTime.Now;
            ctx.Tags.Add(tag);
            SaveChanges();
        }

        public Tag GetById(int Id)
        {
            if (Id <= 0)
                throw new ArgumentNullException("Tag");
            return ctx.Tags.FirstOrDefault(c => c.Id == Id);
        }

        public IQueryable<Tag> GetTags()
        {
            return ctx.Tags;
        }

        public void Update(Tag tag)
        {
            tag.LastModified = DateTime.Now;            
            ctx.Tags.Update(tag);
            SaveChanges();
        }

        public void Delete(Tag tag)
        {
            ctx.Tags.Remove(tag);

            SaveChanges();
        }

        public bool SaveChanges()
        {
            return (ctx.SaveChanges() >= 0);
        }
    }
}
