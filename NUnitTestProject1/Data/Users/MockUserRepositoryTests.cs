using MainMVC.Models.Users;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NUnitTestProject1.Data.Users
{

    [TestFixture]
    public class MockUserRepositoryTests
    {
        //[TestCase("pavlik@mail.com", "1")]
        [TestCase("pavlik@mail.com", "111111")]
        //[TestCase("pavlik@mail", "111111")]
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
            Assert.AreEqual(user, result);
        }


        //[Test]
        //[TestCase("lokin", "pavlik@mail.com", "1")]
        //[TestCase("Pavlik", "pavlik@mail.com", "111111")]
        [TestCase("123555", "1255ds@mail.com", "123456")]
        //[TestCase("Pavlik", "pavlik@mail", "111111")]
        public void Register_StateUnderTest_ExpectedBehavior(string login, string email, string password)
        {
            // Arrange
            var mockUserRepository = new MockUserRepository();

            // Act
            var result = mockUserRepository.Register(
                email,
                login,
                password);

            var loginResult = mockUserRepository.Login(email, password);

            // Assert
            Assert.AreEqual(result, loginResult);
        }
    }
}
