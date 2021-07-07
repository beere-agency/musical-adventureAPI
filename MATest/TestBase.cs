using MAData;
using MADomain;
using MATest.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATest
{
    public class TestBase
    {
        protected ApplicationDbContext GetSampleData(string db)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase(databaseName: db);

            var options = builder.Options;

            var context = new ApplicationDbContext(options);

            // Get sample data and save them for testing
            var tags = new List<Tag>();
            var categories = new List<Category>();
            var products = new List<Product>();
            var dataFactory = new DataFactory();

            //Create Temp Data
            tags.Add(dataFactory.GetTag(1,"music",DateTime.Now.AddDays(-1),DateTime.Now));
            tags.Add(dataFactory.GetTag(2,"beat",DateTime.Now.AddDays(-1),DateTime.Now));
            tags.Add(dataFactory.GetTag(3,"fpl",DateTime.Now.AddDays(-1),DateTime.Now));
            tags.Add(dataFactory.GetTag(6,"hello",DateTime.Now.AddDays(-1),DateTime.Now));
            context.Tags.AddRange(tags);

            context.SaveChanges();

            categories.Add(dataFactory.GetCategory(1, "Hip hop", "American Music", DateTime.Now.AddDays(-1), DateTime.Now));
            categories.Add(dataFactory.GetCategory(2, "Afro Pop", "African Music", DateTime.Now.AddDays(-1), DateTime.Now));
            categories.Add(dataFactory.GetCategory(3, "R and B", "Rythm and Blues Music", DateTime.Now.AddDays(-1), DateTime.Now));
            categories.Add(dataFactory.GetCategory(4, "Tungba", "Nigerian", DateTime.Now.AddDays(-1), DateTime.Now,2,true));
            context.Categories.AddRange(categories);

            context.SaveChanges();

            return context;
        }
    }
}
