using MainMVC.Utilities;
using NUnit.Framework;
using System;

namespace NUnitTestProject1.Utilities
{
    [TestFixture]
    public class ValidEmailAttributeTests
    {
        [Test]
        public void IsValid_ByDomain_True()
        {
            // Arrange
            object value = "pavlik@mail.by";
            var validEmailAttribute = new ValidEmailDomainAttribute("by");

            // Act
            var result = validEmailAttribute.IsValid(
                value);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValid_RuDomain_False()
        {
            // Arrange
            object value = "pavlik@mail.ru";
            var validEmailAttribute = new ValidEmailDomainAttribute("by");

            // Act
            var result = validEmailAttribute.IsValid(
                value);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
