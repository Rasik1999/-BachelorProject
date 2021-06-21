using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WorkingWithProjects.API.Controllers;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.API.Services;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.Tests
{
    public class ProgressControllerTests
    {
        private Mock<IProgressRepository> mockProgressRepository;
        private Mock<INotificationService> mockNotificationService;
        private ProgressController progressController;
        private IEnumerable<Progress> listOfProgress;
        private const decimal progressValue = 1000;

        [SetUp]
        public void Setup()
        {
            FillListOfProgress();
            mockProgressRepository = new Mock<IProgressRepository>();
            mockNotificationService = new Mock<INotificationService>();
            mockProgressRepository.Setup(x => x.GetAllProgress()).Returns(listOfProgress);
            mockProgressRepository.Setup(x => x.GetProgressById(1)).Returns(new Progress { ProgressId = 1, DesiredValue = progressValue });
            mockProgressRepository.Setup(x => x.CreateProgress(It.IsAny<int>(), It.IsAny<decimal>())).ReturnsAsync(new Progress { DesiredValue = progressValue });
            mockProgressRepository.Setup(x => x.UpdateProgress(It.IsAny<Progress>())).Returns(new Progress { DesiredValue = progressValue });
            mockProgressRepository.Setup(x => x.DeletePogress(It.IsAny<int>())).Returns(new Progress { DesiredValue = progressValue });
            mockProgressRepository.Setup(x => x.GetProgressByProjectId(It.IsAny<int>())).ReturnsAsync(new Progress { DesiredValue = progressValue });
            progressController = new ProgressController(mockProgressRepository.Object, mockNotificationService.Object);
        }

        [Test]
        public void ProgressController_Get_ReturnsList_Passed()
        {
            var actual = progressController.Get().ToList();

            Assert.AreEqual(listOfProgress.Count(), actual.Count);
            Assert.IsTrue(actual.FirstOrDefault() != null);
        }

        [Test]
        public void ProgressController_GetWithId_ReturnsProgress_Passed()
        {
            var actual = progressController.Get(1);

            Assert.IsTrue(actual != null);
            Assert.AreEqual(progressValue, actual.DesiredValue);
        }

        [Test]
        public async System.Threading.Tasks.Task ProgressController_GetWithProjectId_ReturnsProgress_PassedAsync()
        {
            var actual = await progressController.GetByProjectIdAsync(1);

            Assert.IsTrue(actual != null);
            Assert.AreEqual(progressValue, actual.DesiredValue);
        }

        [Test]
        public async System.Threading.Tasks.Task ProgressController_Put_ReturnsProgress_PassedAsync()
        {
            var actual = await progressController.PutAsync(1, progressValue);

            Assert.IsTrue(actual != null);
            Assert.AreEqual(progressValue, actual.DesiredValue);
        }

        [Test]
        public void ProgressController_Delete_ReturnsProgress_Passed()
        {
            var actual = progressController.Delete(1);

            Assert.IsTrue(actual != null);
            Assert.AreEqual(progressValue, actual.DesiredValue);
        }

        private void FillListOfProgress()
        {
            listOfProgress = new List<Progress> { new Progress { ProgressId = 1, DesiredValue = progressValue } };
        }
    }
}
