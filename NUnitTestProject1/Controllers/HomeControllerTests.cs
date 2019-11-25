using MainMVC.Controllers;
using MainMVC.Models.Polls;
using MainMVC.Models.Users;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace NUnitTestProject1.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ILogger<HomeController>> mockLogger;
        private Mock<IPollRepository> mockPollRepository;
        private Mock<IUserRepository> mockUserRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockLogger = this.mockRepository.Create<ILogger<HomeController>>();
            this.mockPollRepository = this.mockRepository.Create<IPollRepository>();
            this.mockUserRepository = this.mockRepository.Create<IUserRepository>();
        }

        [TearDown]
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }

        private HomeController CreateHomeController()
        {
            return new HomeController(
                this.mockLogger.Object,
                this.mockPollRepository.Object,
                this.mockUserRepository.Object);
        }

        [Test]
        public void PollsList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.PollsList();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ViewPoll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();
            int id = 0;

            // Act
            var result = homeController.ViewPoll(
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
        public void QuestionsList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();
            int pollId = 0;

            // Act
            var result = homeController.QuestionsList(
                pollId);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void EditNumberOfAnswers_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();
            int questionId = 0;

            // Act
            var result = homeController.EditNumberOfAnswers(
                questionId);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void EditNumberOfAnswers_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var homeController = this.CreateHomeController();
            Question question = null;

            // Act
            var result = homeController.EditNumberOfAnswers(
                question);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void EditAnswers_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();
            int id = 0;
            int question = 0;

            // Act
            var result = homeController.EditAnswers(
                id,
                question);

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
