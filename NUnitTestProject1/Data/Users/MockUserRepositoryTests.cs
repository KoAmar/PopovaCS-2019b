using BlazorApp.Data.Users;
using BlazorApp.Models.Authorization;
using NUnit.Framework;
using System;

namespace NUnitTestProject1.Data.Users
{
    [TestFixture]
    public class MockUserRepositoryTests
    {
        [TestCase("pavlik@mail.com", "1")]
        [TestCase("pavlik@mail.com", "111111")]
        [TestCase("pavlik@mail", "111111")]
        public void Login_StateUnderTest_ExpectedBehavior(string email, string password)
        {
            // Arrange
            var mockUserRepository = new MockUserRepository();
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
            Console.WriteLine($"{user.ToString()} == {result.ToString()}");
            Assert.AreEqual(user,result);
        }

        [Test]
        public void Register_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mockUserRepository = new MockUserRepository();
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
