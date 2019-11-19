using BlazorApp.Data.Users;
using BlazorApp.Models.Authorization;
using System;
using Xunit;

namespace XUnitTestProject1.Data.Users
{
    public class MockUserRepositoryTests
    {

        [Theory]
        [InlineData("pavlik@mail.com", "1111")]
        [InlineData("pavlikmail.com", "1111")]
        [InlineData("pavlik@mail.com", "111")]
        public void Login_StateUnderTest_ExpectedBehavior(string email, string password)
        {
            // Arrange
            var mockUserRepository = new MockUserRepository();
            var user = new User
            {
                Id = 1,
                Email = "pavlik@mail.com",
                Login = "Pavlik",
                PasswordHash = "1111",
                Role = User.Roles.User
            };

            // Act
            var result = mockUserRepository.Login(
                email,
                password);

            // Assert
            Assert.Equal(user, result);
        }

        [Fact]
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
            Assert.True(false);
        }
    }
}
