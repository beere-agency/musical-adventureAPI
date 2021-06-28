using MAData;
using MAService.Implementation;
using MAService.Interface;
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

        #region helpers
        private ICategoryRepository MockCategoryRepository(ApplicationDbContext context)
        {
            var categoryRepository = new CategoryRepository(context);

            return categoryRepository;
        }
        #endregion
    }
}
