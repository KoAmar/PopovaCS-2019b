using MainMVC.Models.Users;
using Xunit;

namespace XUnitTestProject.Models.Users
{
    public class MockUserRepositoryTests
    {

        private RamMemoryUserRepository CreateMockUserRepository()
        {
            return new RamMemoryUserRepository();
        }

        [Fact]
        public void Login_UnregisteredLogin_Null()
        {
            // Arrange
            var mockUserRepository = new RamMemoryUserRepository();
            var email = "pavl@mail.com";
            var password = "111111";

            var user = new User
            {
                Id = 1,
                Email = "pavlik@mail.com",
                Login = "Pavlik",
                Password = "111111",
                Role = User.Roles.User
            };

            // Act
            var result = mockUserRepository.Login(
                email,
                password);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Login_badLogin_Equal()
        {
            // Arrange
            var mockUserRepository = new RamMemoryUserRepository();
            var email = "pavl@mail.com";
            var password = "111111";

            var user = new User
            {
                Id = 1,
                Email = "pavlik@mail.com",
                Login = "Pavlik",
                Password = "111111",
                Role = User.Roles.User
            };

            // Act
            var result = mockUserRepository.Login(
                email,
                password);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Login_emptyUsers_Null()
        {
            // Arrange
            var mockUserRepository = new RamMemoryUserRepository();
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

        [Fact]
        public void Login_normal_Equal()
        {
            // Arrange
            var mockUserRepository = new RamMemoryUserRepository();
            var email = "pavlik@mail.com";
            var password = "111111";

            var user = new User
            {
                Id = 1,
                Email = "pavlik@mail.com",
                Login = "Pavlik",
                Password = "111111",
                Role = User.Roles.User
            };

            // Act
            var result = mockUserRepository.Login(
                email,
                password);

            // Assert
            Assert.Equal(user, result);
        }

    }
}
