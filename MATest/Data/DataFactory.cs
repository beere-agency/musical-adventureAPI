using MADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATest.Data
{
    public class DataFactory
    {

        public Tag GetTag(int id, string name, DateTime dateCreated, DateTime lastModified)
        {
            var tag = new Tag
            {
                Id = id,
                Name = name,
                DateCreated = dateCreated,
                LastModified = lastModified
            };
            return tag;
        }
    }
}
