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
        //[TestCase("pavlik@mail", "111111")]
        public void Login_StateUnderTest_ExpectedBehavior()
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


        ////[Test]
        ////[TestCase("lokin", "pavlik@mail.com", "1")]
        //[TestCase("Pavlik", "pavlik@mail.com", "111111")]
        //[TestCase("123555", "1255ds@mail.com", "123456")]
        ////[TestCase("Pavlik", "pavlik@mail", "111111")]
        //public void Register_StateUnderTest_ExpectedBehavior(string login, string email, string password)
        //{
        //    // Arrange
        //    var mockUserRepository = new MockUserRepository();

        //    // Act
        //    var result = mockUserRepository.Register(
        //        email,
        //        login,
        //        password);

        //    var loginResult = mockUserRepository.Login(email, password);

        //    // Assert
        //    Assert.AreEqual(result, loginResult);
        //}
    }
}
