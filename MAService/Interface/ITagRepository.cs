using MADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAService.Interface
{
    public interface ITagRepository
    {
        void Create(Tag tag);
        void Delete(Tag tag);
        Tag GetById(int Id);
        IQueryable<Tag> GetTags();
        void Update(Tag tag);
    }
}
