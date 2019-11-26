using MainMVC.Models.Users;
using Moq;
using NUnit.Framework;
using System;

namespace NUnitTestProject1.Models.Users
{
    [TestFixture]
    public class MockUserRepositoryTests
    {

        private MockUserRepository CreateMockUserRepository()
        {
            return new MockUserRepository();
        }

        [Test]
        public void ContainEmail_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mockUserRepository = this.CreateMockUserRepository();
            string email = "pa1318vel@gmail.com";

            // Act
            var result = mockUserRepository.ContainEmail(
                email);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Login_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mockUserRepository = this.CreateMockUserRepository();
            string email = null;
            string password = null;

            // Act
            var result = mockUserRepository.Login(
                email,
                password);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void Register_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mockUserRepository = this.CreateMockUserRepository();
            string email = null;
            string login = null;
            string password = null;

            // Act
            var result = mockUserRepository.Register(
                email,
                login,
                password);

            // Assert
            Assert.Fail();
        }
    }
}
