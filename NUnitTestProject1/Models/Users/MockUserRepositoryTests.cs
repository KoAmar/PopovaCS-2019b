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
        public void StrongPasswordTest_level1_Equal()
        {
            // Arrange
            //var mockUserRepository = this.CreateMockUserRepository();
            string password = "111111";

            // Act
            var result = MockUserRepository.StrongPassword(
                password);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void StrongPasswordTest_level2_Equal()
        {
            // Arrange
            //var mockUserRepository = this.CreateMockUserRepository();
            string password = "11s111";

            // Act
            var result = MockUserRepository.StrongPassword(
                password);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void StrongPasswordTest_level3_Equal()
        {
            // Arrange
            //var mockUserRepository = this.CreateMockUserRepository();
            string password = "11$a11";

            // Act
            var result = MockUserRepository.StrongPassword(
                password);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Login_UnregistredLogin_Null()
        {
            // Arrange
            var mockUserRepository = new MockUserRepository();
            var email = "pavl@mail.com";
            var password = "111111";

            var user = new User
            {
                Id = 1,
                Email = "pavlik@mail.com",
                Login = "Pavlik",
                PasswordHash = "111111",
                Role = User.Roles.User
            };

            // Act
            var result = mockUserRepository.Login(
                email,
                password);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public void Login_badLogin_Equal()
        {
            // Arrange
            var mockUserRepository = new MockUserRepository();
            var email = "pavl@mail.com";
            var password = "111111";

            var user = new User
            {
                Id = 1,
                Email = "pavlik@mail.com",
                Login = "Pavlik",
                PasswordHash = "111111",
                Role = User.Roles.User
            };

            // Act
            var result = mockUserRepository.Login(
                email,
                password);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public void Login_emptyUsers_Null()
        {
            // Arrange
            var mockUserRepository = new MockUserRepository();
            mockUserRepository.ClearUsers();
            var email = "pavl@mail.com";
            var password = "111111";

            // Act
            var result = mockUserRepository.Login(
                email,
                password);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public void Login_normal_Equal()
        {
            // Arrange
            var mockUserRepository = new MockUserRepository();
            var email = "pavlik@mail.com";
            var password = "111111";

            var user = new User
            {
                Id = 1,
                Email = "pavlik@mail.com",
                Login = "Pavlik",
                PasswordHash = "111111",
                Role = User.Roles.User
            };

            // Act
            var result = mockUserRepository.Login(
                email,
                password);

            // Assert
            Assert.AreEqual(user, result);
        }

    }
}
