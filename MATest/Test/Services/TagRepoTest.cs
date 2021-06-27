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
    public class TagRepoTest : TestBase
    {

        [Fact]
        public void GetAll_ShouldReturnAllTags()
        {
            using var context = GetSampleData(nameof(GetAll_ShouldReturnAllTags));
            //Arrange
            var tagRepository = MockTagRepository(context);

            //Act
            var allTags = tagRepository.GetTags().ToList();

            //Assert
            Assert.NotNull(allTags);
            Assert.Equal(4, allTags.Count());
        }

        [Fact]
        public void CreateNewTag_ShouldCreateNewTagData()
        {
            using var context = GetSampleData(nameof(CreateNewTag_ShouldCreateNewTagData));
            //Arrange 
            var tagRepository = MockTagRepository(context);
            var dataFactory = new DataFactory();
            var tag = dataFactory.GetTag(5, "NTA Building", DateTime.Now.AddDays(-1), DateTime.Now);

            //Act
            tagRepository.Create(tag);
            var allEmployee = tagRepository.GetTags().ToList();

            //Assert
            Assert.NotNull(allEmployee);
            Assert.Equal(5, allEmployee.Count());
        }

        [Fact]
        public void UpdateTag_ShouldUpdateTag()
        {
            using var context = GetSampleData(nameof(UpdateTag_ShouldUpdateTag));
            //Arrange
            var tagRepository = MockTagRepository(context);
            var tag = tagRepository.GetTags().FirstOrDefault(x => x.Id == 3);
            tag.Name = "fpl2";

            //Act
            tagRepository.Update(tag);
            var allTags = tagRepository.GetTags();
            var updatedTag = allTags.FirstOrDefault(x => x.Id == tag.Id);

            //Assert
            Assert.Equal(tag.Name, updatedTag.Name);
            Assert.Equal(4, allTags.ToList().Count());
        }

        //[Fact]
        //public void DeleteTag_ShouldDeleteTag()
        //{
        //    using var context = GetSampleData(nameof(UpdateTag_ShouldUpdateTag));
        //    //Arrange
        //    var tagRepository = MockTagRepository(context);
        //    var tag = tagRepository.GetTags().FirstOrDefault(x => x.Id == 6);

        //    //Act
        //    tagRepository.Delete(tag);
        //    var allTags = tagRepository.GetTags();

        //    //Assert
        //    Assert.Null(tagRepository.GetTags().FirstOrDefault(x => x.Id == 6));
        //}


        #region helpers
        private ITagRepository MockTagRepository(ApplicationDbContext context)
        {

            var tagRepository = new TagRepository(context);

            return tagRepository;
        }
        #endregion
    }
}
