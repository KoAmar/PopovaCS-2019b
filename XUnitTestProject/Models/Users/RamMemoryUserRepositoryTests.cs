using MainMVC.Models.Users;
using Xunit;

namespace XUnitTestProject.Models.Users
{
    public class RamMemoryUserRepositoryTests
    {

        private RamMemoryUserRepository CreateMockUserRepository()
        {
            return new RamMemoryUserRepository();
        }

        [Fact]
        public void Login_emptyUsers_Null()
        {
            // Arrange
            var mockUserRepository = new RamMemoryUserRepository();
            mockUserRepository.ClearUsers();
            var email = "pavl@mail.com";
            var password = "111111";
            var user = new User() { Email = email, Password = password };

            // Act
            var result = mockUserRepository.Login(user);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Login_normal_NotNull()
        {
            // Arrange
            var mockUserRepository = new RamMemoryUserRepository();

            var user = new User
            {
                Id = 1,
                Email = "pavlik@mail.com",
                Login = "Pavlik",
                Password = "111111",
                Role = User.Roles.User
            };

            // Act
            var result = mockUserRepository.Login(user);

            // Assert
            Assert.NotNull(result);
        }

    }
}
