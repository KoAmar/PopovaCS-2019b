//using MainMVC.Controllers;
//using MainMVC.Models.Polls;
//using MainMVC.Models.Users;
//using Microsoft.Extensions.Logging;
//using Moq;
//using NUnit.Framework;
//using System;

//namespace NUnitTestProject1.Controllers
//{
//    [TestFixture]
//    public class HomeControllerTests
//    {
//        private Mock<IPollRepository> mockPollRepository;

//        [SetUp]
//        public void SetUp()
//        {
//            mockPollRepository = new Mock<IPollRepository>();
//        }

//        [Test]
//        public void EditNumberOfAnswersTest()
//        {
//            // Arrange
//            mockPollRepository.Setup(e => e.GetPolls);

//            // Организация - создание контроллера
//            HomeController controller = new HomeController(mock.Object);

//            // Действие
//            Book book1 = controller.Edit(1).ViewData.Model as Book;

//            // Assert
//            Assert.AreEqual(1, book1.BookId);
//        }

//        var homeController = this.CreateHomeController();

//            // Act
//            var result = homeController.PollsList();

//            // Assert
//            Assert.Fail(); ;
//        }
//    }
//}
