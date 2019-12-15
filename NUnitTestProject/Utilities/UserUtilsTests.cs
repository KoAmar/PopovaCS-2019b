using System;
using System.Linq;
using MainMVC.Utilities;
using NUnit.Framework;

namespace NUnitTestProject.Utilities
{
    [TestFixture()]
    public class UserUtilsTests
    {
        private UserUtils CreateDomains()
        {
            return new UserUtils(new []{"by","ru"});
        }

        [Test]
        public void IsValid_ByDomain_True()
        {
            // Arrange
            object value = "pavlik@mail.by";
            var validEmailAttribute = CreateDomains();

            // Act
            var result = validEmailAttribute.IsValid(
                value);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValid_UaDomain_False()
        {
            // Arrange
            object value = "pavlik@mail.ua";
            var validEmailAttribute = CreateDomains();

            // Act
            var result = validEmailAttribute.IsValid(
                value);

            // Assert
            Assert.IsFalse(result);
        }
        
        [Test]
        public void IsValid_EmptyUser_False()
        {
            // Arrange
            object value = "@mail.by";
            var validEmailAttribute = CreateDomains();

            // Act
            var result = validEmailAttribute.IsValid(
                value);

            // Assert
            Assert.IsFalse(result);
        }
        
        [Test]
        public void IsValid_EmptyDomain1_False()
        {
            // Arrange
            object value = "pavlik@.by";
            var validEmailAttribute = CreateDomains();

            // Act
            var result = validEmailAttribute.IsValid(
                value);

            // Assert
            Assert.IsFalse(result);
        }
        
        [Test]
        public void IsValid_EmptyDomain2_False()
        {
            // Arrange
            object value = "pavlik@mail.";
            var validEmailAttribute = CreateDomains();

            // Act
            var result = validEmailAttribute.IsValid(
                value);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_longUser_False()
        {
            // Arrange
            object value = string.Concat(Enumerable.Repeat("a", 31))+"@mail.by";
            var validEmailAttribute = CreateDomains();

            // Act
            var result = validEmailAttribute.IsValid(
                value);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_longDomain1_False()
        {
            // Arrange
            object value = "pavlik@"+string.Concat(Enumerable.Repeat("b", 31))+".by";
            var validEmailAttribute = CreateDomains();

            // Act
            var result = validEmailAttribute.IsValid(
                value);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_longDomain2_False()
        {
            // Arrange
            object value = "pavlik@mail."+string.Concat(Enumerable.Repeat("Pavlik", 16));
            var validEmailAttribute = CreateDomains();

            // Act
            var result = validEmailAttribute.IsValid(
                value);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void StrongPasswordTest_level1_Equal()
        {
            // Arrange
            string password = "111111";

            // Act
            var result = UserUtils.StrongPassword(
                password);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void StrongPasswordTest_level2_Equal()
        {
            // Arrange
            string password = "11sR111";

            // Act
            var result = UserUtils.StrongPassword(
                password);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void StrongPasswordTest_level3_Equal()
        {
            // Arrange
            string password = "11$aY11";

            // Act
            var result = UserUtils.StrongPassword(
                password);

            // Assert
            Assert.True(result);
        }
                
        [Test]
        public void StrongPasswordTest_longStr_False()
        {
            // Arrange
            var password = string.Concat(Enumerable.Repeat("Pavlik#123 ", 10));
            Console.WriteLine(password);
            // Act
            var result = UserUtils.StrongPassword(
                password);
            // Assert
            Assert.False(result);
        }


        [Test]
        public void StrongPasswordTest_null_NullReferenceException()
        {
            // Arrange
            string password = null;

            // Act
            // Assert
            Assert.Throws<NullReferenceException>(() => UserUtils.StrongPassword(
                password));
        }

    }
}
