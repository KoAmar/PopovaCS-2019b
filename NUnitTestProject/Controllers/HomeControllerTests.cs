using MainMVC.Controllers;
using MainMVC.Models.Polls;
using MainMVC.Models.Polls.Entities;
using MainMVC.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace NUnitTestProject.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private Mock<ILogger<HomeController>> _mockLogger;
        private Mock<IPollRepository> _mockPollRepository;
        private Mock<IUserRepository> _mockUserRepository;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger<HomeController>>();
            _mockPollRepository = new Mock<IPollRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
        }

        private HomeController CreateHomeController()
        {
            return new HomeController(
                _mockLogger.Object,
                _mockPollRepository.Object,
                _mockUserRepository.Object);
        }

        [Test]
        public void PollsList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = CreateHomeController();
            _mockPollRepository.Setup(repo => repo.GetPolls()).Returns(Data.GetData());

            // Act
            var result = homeController.PollsList() as ViewResult;

            result.Model.ToString();
            // Assert
            Assert.AreEqual("Details",result.ViewName);
            //Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Test]
        public void PollStatistics_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();
            int id = 0;

            // Act
            var result = homeController.PollStatistics(
                id);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void CreatePoll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.CreatePoll();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void CreatePoll_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var homeController = this.CreateHomeController();
            Poll poll = null;

            // Act
            var result = homeController.CreatePoll(
                poll);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void EditPoll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.EditPoll();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void EditPoll_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var homeController = this.CreateHomeController();
            Poll poll = null;

            // Act
            var result = homeController.EditPoll(
                poll);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void Error_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.Error();

            // Assert
            Assert.Fail();
        }
    }
}
