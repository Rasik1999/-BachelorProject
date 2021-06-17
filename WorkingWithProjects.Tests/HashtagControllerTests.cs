using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WorkingWithProjects.API.Controllers;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.Tests
{
    public class HashtagControllerTests
    {
        private Mock<IHashtagRepository> mockHashtagsRepository;
        private HashtagsController hashtagsController;
        private IEnumerable<Hashtag> listOfHashtags;
        private const string hashtagName = "NewTestName";

        [SetUp]
        public void Setup()
        {
            FillListOfHashtags();
            mockHashtagsRepository = new Mock<IHashtagRepository>();
            mockHashtagsRepository.Setup(x => x.GetAllHashtags()).Returns(listOfHashtags);
            mockHashtagsRepository.Setup(x => x.GetHashtagById(1)).Returns(new Hashtag { HashtagId = 1, Name = "TestName" });
            mockHashtagsRepository.Setup(x => x.AddHashtag(It.IsAny<Hashtag>())).Returns(new Hashtag { Name = hashtagName });
            mockHashtagsRepository.Setup(x => x.UpdateHashtag(It.IsAny<Hashtag>())).Returns(new Hashtag { Name = hashtagName });
            mockHashtagsRepository.Setup(x => x.DeleteHashtag(It.IsAny<int>())).Returns(new Hashtag { Name = hashtagName });
            hashtagsController = new HashtagsController(mockHashtagsRepository.Object);
        }

        [Test]
        public void HashtagController_Get_ReturnsList_Passed()
        {
            var actual = hashtagsController.Get().ToList();

            Assert.AreEqual(listOfHashtags.Count(), actual.Count);
            Assert.IsTrue(actual.FirstOrDefault() != null);
            Assert.IsFalse(string.IsNullOrEmpty(actual.FirstOrDefault().Name));
        }

        [Test]
        public void HashtagController_GetWithId_ReturnsHashtag_Passed()
        {
            var actual = hashtagsController.Get(1);

            Assert.IsTrue(actual != null);
            Assert.IsFalse(string.IsNullOrEmpty(actual.Name));
        }

        [Test]
        public void HashtagController_Post_ReturnsHashtag_Passed()
        {
            var actual = hashtagsController.Post(hashtagName);

            Assert.IsFalse(string.IsNullOrEmpty(actual.Name));
            Assert.AreEqual(hashtagName, actual.Name);
        }

        [Test]
        public void HashtagController_Put_ReturnsHashtag_Passed()
        {
            var actual = hashtagsController.Put(new Hashtag() { Name = hashtagName });

            Assert.IsFalse(string.IsNullOrEmpty(actual.Name));
            Assert.AreEqual(hashtagName, actual.Name);
        }

        [Test]
        public void HashtagController_Delete_ReturnsHashtag_Passed()
        {
            var actual = hashtagsController.Delete(1);

            Assert.IsFalse(string.IsNullOrEmpty(actual.Name));
            Assert.AreEqual(hashtagName, actual.Name);
        }

        private void FillListOfHashtags()
        {
            listOfHashtags = new List<Hashtag> { new Hashtag { HashtagId = 1, Name = "TestName" } };
        }
    }
}