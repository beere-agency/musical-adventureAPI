using MAData;
using MAService.Implementation;
using MAService.Interface;
using MATest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MATest.Test.Services
{
    public class CategoryRepoTest : TestBase
    {
        [Fact]
        public void GetAll_ShouldReturnAllCategories()
        {
            using var context = GetSampleData(nameof(GetAll_ShouldReturnAllCategories));
            //Arrange
            var categoryRepository = MockCategoryRepository(context);

            //Act
            var allCategories = categoryRepository.GetCategories().ToList();

            //Assert
            Assert.NotNull(allCategories);
            Assert.Equal(4, allCategories.Count());
        }

        [Fact]
        public void CreateNewTag_ShouldCreateNewCategoryData()
        {
            using var context = GetSampleData(nameof(CreateNewTag_ShouldCreateNewCategoryData));
            //Arrange 
            var categoryRepository = MockCategoryRepository(context);
            var dataFactory = new DataFactory();
            var tag = dataFactory.GetCategory(5, "Raggae","Jamaican Pop", DateTime.Now.AddDays(-1), DateTime.Now);

            //Act
            categoryRepository.Create(tag);
            var allCategories = categoryRepository.GetCategories().ToList();

            //Assert
            Assert.NotNull(allCategories);
            Assert.Equal(5, allCategories.Count());
        }

        [Fact]
        public void UpdateTag_ShouldUpdateCategory()
        {
            using var context = GetSampleData(nameof(UpdateTag_ShouldUpdateCategory));
            //Arrange
            var categoryRepository = MockCategoryRepository(context);
            var tag = categoryRepository.GetCategories().FirstOrDefault(x => x.Id == 2);
            tag.Name = "fpl2";

            //Act
            categoryRepository.Update(tag);
            var allCategories = categoryRepository.GetCategories();
            var updatedTag = allCategories.FirstOrDefault(x => x.Id == tag.Id);

            //Assert
            Assert.Equal(tag.Name, updatedTag.Name);
            Assert.Equal(4, allCategories.ToList().Count());
        }

        [Fact]
        public void DeleteTag_ShouldDeleteTag()
        {
            using var context = GetSampleData(nameof(UpdateTag_ShouldUpdateCategory));
            //Arrange
            var categoryRepository = MockCategoryRepository(context);
            var tag = categoryRepository.GetCategories().FirstOrDefault(x => x.Id == 4);

            //Act
            categoryRepository.Delete(tag);
            var allTags = categoryRepository.GetCategories();

            //Assert
            Assert.Null(categoryRepository.GetCategories().FirstOrDefault(x => x.Id == 4));
        }

        #region helpers
        private ICategoryRepository MockCategoryRepository(ApplicationDbContext context)
        {
            var categoryRepository = new CategoryRepository(context);

            return categoryRepository;
        }
        #endregion
    }
}
