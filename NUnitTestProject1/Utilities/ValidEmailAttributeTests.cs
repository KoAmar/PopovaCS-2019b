using MainMVC.Utilities;
using NUnit.Framework;
using System;

namespace NUnitTestProject1.Utilities
{
    [TestFixture]
    public class ValidEmailAttributeTests
    {
        [Test]
        public void IsValid_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            object value = "pavlik@mail.by";
            var validEmailAttribute = new ValidEmailAttribute("by");

            // Act
            var result = validEmailAttribute.IsValid(
                value);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
