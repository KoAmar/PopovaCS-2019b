using MainMVC.Controllers;
using MainMVC.Models.Polls;
using MainMVC.Models.Users;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using MainMVC.Models.Polls.Entities;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace XUnitTestProject.Controllers
{
    public class HomeControllerTests : IDisposable
    {
        private MockRepository mockRepository;

        private Mock<ILogger<HomeController>> mockLogger;
        private Mock<IPollRepository> mockPollRepository;
        private Mock<IUserRepository> mockUserRepository;

        public HomeControllerTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockLogger = mockRepository.Create<ILogger<HomeController>>();
            mockPollRepository = mockRepository.Create<IPollRepository>();
            mockUserRepository = mockRepository.Create<IUserRepository>();
        }

        public void Dispose()
        {
            mockRepository.VerifyAll();
        }

        private HomeController CreateHomeController()
        {
            return new HomeController(
                mockLogger.Object,
                mockPollRepository.Object,
                mockUserRepository.Object);
        }

        [Fact]
        public void PollsList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = CreateHomeController();
            mockPollRepository.Setup(repo => repo.GetPolls())
                .Returns(Data.GetData());

            // Act
            var result = homeController.PollsList();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var polls = Assert.IsType<List<Poll>>(viewResult.Model);
            //Assert.Equal(2, polls.Count);
            Assert.Equal("First Poll", polls[0].Name);
        }

        [Fact]
        public void PollStatistics_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = CreateHomeController();
            int id = 0;

            // Act
            var result = homeController.PollStatistics(
                id);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void CreatePoll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = CreateHomeController();

            // Act
            var result = homeController.CreatePoll();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void CreatePoll_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var homeController = CreateHomeController();
            Poll poll = null;

            // Act
            var result = homeController.CreatePoll(
                poll);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void EditPoll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = CreateHomeController();

            // Act
            var result = homeController.EditPoll();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void EditPoll_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var homeController = CreateHomeController();
            Poll poll = null;

            // Act
            var result = homeController.EditPoll(
                poll);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void Error_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = CreateHomeController();

            // Act
            var result = homeController.Error();

            // Assert
            Assert.True(false);
        }
    }
}
