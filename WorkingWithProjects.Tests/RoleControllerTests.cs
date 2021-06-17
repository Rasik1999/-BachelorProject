using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WorkingWithProjects.API.Controllers;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.Tests
{
    public class RoleControllerTests
    {
        private Mock<IRoleRepository> mockRoleRepository;
        private RoleController roleController;
        private IEnumerable<Role> listOfRoles;
        private const string roleName = "NewTestName";

        [SetUp]
        public void Setup()
        {
            FillListOfRoles();
            mockRoleRepository = new Mock<IRoleRepository>();
            mockRoleRepository.Setup(x => x.GetAllRoles()).Returns(listOfRoles);
            mockRoleRepository.Setup(x => x.GetRole(1)).Returns(new Role { RoleId = 1, Name = "TestName" });
            mockRoleRepository.Setup(x => x.AddRole(It.IsAny<Role>())).Returns(new Role { Name = roleName });
            mockRoleRepository.Setup(x => x.UpdateRole(It.IsAny<Role>())).Returns(new Role { Name = roleName });
            mockRoleRepository.Setup(x => x.DeleteRole(It.IsAny<int>())).Returns(new Role { Name = roleName });
            roleController = new RoleController(mockRoleRepository.Object);
        }

        [Test]
        public void RoleController_Get_ReturnsList_Passed()
        {
            var actual = roleController.GetRoles().ToList();

            Assert.AreEqual(listOfRoles.Count(), actual.Count);
            Assert.IsTrue(actual.FirstOrDefault() != null);
            Assert.IsFalse(string.IsNullOrEmpty(actual.FirstOrDefault().Name));
        }

        [Test]
        public void RoleController_GetWithId_ReturnsRole_Passed()
        {
            var actual = roleController.GetRole(1);

            Assert.IsTrue(actual != null);
            Assert.IsFalse(string.IsNullOrEmpty(actual.Name));
        }

        [Test]
        public void RoleController_Post_ReturnsRole_Passed()
        {
            var actual = roleController.PostRole(new Role { Name = roleName });

            Assert.IsFalse(string.IsNullOrEmpty(actual.Name));
            Assert.AreEqual(roleName, actual.Name);
        }

        [Test]
        public void RoleController_Put_ReturnsRole_Passed()
        {
            var actual = roleController.PutRole(new Role() { Name = roleName });

            Assert.IsFalse(string.IsNullOrEmpty(actual.Name));
            Assert.AreEqual(roleName, actual.Name);
        }

        [Test]
        public void RoleController_Delete_ReturnsRole_Passed()
        {
            var actual = roleController.DeleteRole(1);

            Assert.IsFalse(string.IsNullOrEmpty(actual.Name));
            Assert.AreEqual(roleName, actual.Name);
        }

        private void FillListOfRoles()
        {
            listOfRoles = new List<Role> { new Role { RoleId = 1, Name = "TestName" } };
        }
    }
}
