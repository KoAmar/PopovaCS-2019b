using BlazorApp.Data.Users;
using BlazorApp.Models.Authorization;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NUnitTestProject1.Data.Users
{
    public class MockRep : MockUserRepository
    {
        public int GetUserIndex(User user)
        {
            return _users.IndexOf(user);
        }

        public User GetUser(int id)
        {
            return _users[id];
        }
    }

    [TestFixture]
    public class MockUserRepositoryTests
    {
        [TestCase("pavlik@mail.com", "111111")]
        public void Login_StateUnderTest_ExpectedBehavior(string email, string password)
        {
            // Arrange
            var mockUserRepository = new MockRep();
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


        [TestCase("123555", "1255ds@mail.com", "123456")]
        public void Register_StateUnderTest_ExpectedBehavior(string login, string email, string password)
        {
            // Arrange
            var mockUserRepository = new MockRep();

            // Act
            var result = mockUserRepository.Register(
                email,
                login,
                password);

            // Assert
            Assert.AreEqual(result, mockUserRepository.GetUser(result.Id));
        }
    }
}
