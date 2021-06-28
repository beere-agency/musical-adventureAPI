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

        public Category GetCategory(int id,string name,string description, DateTime dateCreated, DateTime lastModified, int parentId = 0, bool isSubCategory = false)
        {
            var category = new Category
            {
                Id = id,
                Description = description,
                Name = name,
                ParentId = parentId,
                IsSubCategory = isSubCategory,
                LastModified = lastModified,
                DateCreated = dateCreated
            };
            return category;
        }
    }
}
