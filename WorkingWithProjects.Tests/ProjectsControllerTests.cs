using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkingWithProjects.API.Controllers;
using WorkingWithProjects.API.Helpers;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.API.Models.ViewModel;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.Tests
{
    public class ProjectsControllerTests
    {
        private Mock<IProjectRepository> mockProjectRepository;
        private Mock<IProgressRepository> mockProgressRepository;
        private Mock<IProjectsHelper> mockProjectsHelper;
        private Mock<IMapper> mockMapper;
        private ProjectsController projectController;
        private IEnumerable<Project> listOfProjects;
        private List<ProjectViewModel> listOfProjectViewModels;

        [SetUp]
        public void Setup()
        {
            FillListOfProjects();
            FillListOfProjectViewModels();

            mockProjectRepository = new Mock<IProjectRepository>();
            mockProgressRepository = new Mock<IProgressRepository>();
            mockMapper = new Mock<IMapper>();
            mockProjectsHelper = new Mock<IProjectsHelper>();

            mockProjectRepository.Setup(x => x.GetAllProjects()).ReturnsAsync(listOfProjects);
            mockProjectRepository.Setup(x => x.GetAllModeratedProjects()).Returns(listOfProjects);
            mockProjectRepository.Setup(x => x.GetProjectById(It.IsAny<int>())).ReturnsAsync(listOfProjects.FirstOrDefault());
            mockMapper.Setup(x => x.Map<List<ProjectViewModel>>(It.IsAny<List<Project>>())).Returns(listOfProjectViewModels);
            mockMapper.Setup(x => x.Map<ProjectViewModel>(It.IsAny<Project>())).Returns(listOfProjectViewModels.FirstOrDefault());
            mockProgressRepository.Setup(x => x.GetProgressByProjectId(It.IsAny<int>())).Returns(() => null);

            projectController = new ProjectsController(
                mockProjectRepository.Object,
                mockMapper.Object,
                mockProgressRepository.Object,
                mockProjectsHelper.Object);
        }

        [Test]
        public async Task ProjectController_Get_ReturnsList_PassedAsync()
        {
            OkObjectResult actual = await projectController.GetAllProjectsAsync() as OkObjectResult;

            Assert.IsTrue(actual.Value != null);
            Assert.IsTrue((actual.Value as List<ProjectViewModel>).Count == listOfProjectViewModels.Count);
        }

        [Test]
        public void ProjectController_GetModerated_ReturnsList_Passed()
        {
            listOfProjectViewModels.FirstOrDefault().IsModerated = true;
            
            OkObjectResult actual = projectController.GetAllModeratedProjects() as OkObjectResult;

            Assert.IsTrue(actual.Value != null);
            Assert.IsTrue((actual.Value as List<ProjectViewModel>).Count == listOfProjectViewModels.Count);
            Assert.IsTrue((actual.Value as List<ProjectViewModel>).FirstOrDefault().IsModerated);
        }

        [Test]
        public void ProjectController_GetById_ReturnsList_Passed()
        {
            OkObjectResult actual = projectController.GetProjectById(1) as OkObjectResult;

            Assert.IsTrue(actual.Value != null);
            Assert.AreEqual(listOfProjectViewModels.FirstOrDefault().Title, (actual.Value as ProjectViewModel).Title);
        }

        private void FillListOfProjects()
        {
            listOfProjects = new List<Project> { new Project { ProjectId = 1, Title = "NewTitle" } };
        }

        private void FillListOfProjectViewModels()
        {
            listOfProjectViewModels = new List<ProjectViewModel> { new ProjectViewModel { ProjectId = 1, Title = "NewTitle" } };
        }
    }
}
