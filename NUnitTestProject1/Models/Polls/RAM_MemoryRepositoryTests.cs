using MainMVC.Models.Polls;
using MainMVC.Utilities;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace NUnitTestProject1.Models.Polls
{
    [TestFixture]
    public class RAM_MemoryRepositoryTests
    {

        private RAM_MemoryRepository CreateRAMMemoryRepository()
        {
            return new RAM_MemoryRepository();
        }

        [Test]
        public void GetPoll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rAMMemoryRepository = this.CreateRAMMemoryRepository();
            int id = 0;

            // Act
            var result = rAMMemoryRepository.GetPoll(
                id);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void GetPolls_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rAMMemoryRepository = this.CreateRAMMemoryRepository();

            // Act
            var result = rAMMemoryRepository.GetPolls();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rAMMemoryRepository = this.CreateRAMMemoryRepository();
            Poll poll = null;

            // Act
            var result = rAMMemoryRepository.Add(
                poll);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void MaxQuestionId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rAMMemoryRepository = CreateRAMMemoryRepository();

            // Act
            var result = UtilForPoll.MaxQuestionId(
                rAMMemoryRepository.GetPolls().ToList());

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void MaxAnswerId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rAMMemoryRepository = CreateRAMMemoryRepository();

            // Act
            var result = UtilForPoll.MaxAnswerId(
                rAMMemoryRepository.GetPolls().ToList());

            // Assert
            Assert.AreEqual(0,result);
        }

        [Test]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rAMMemoryRepository = this.CreateRAMMemoryRepository();
            Poll pollChanges = null;

            // Act
            var result = rAMMemoryRepository.Update(
                pollChanges);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rAMMemoryRepository = this.CreateRAMMemoryRepository();
            int Id = 0;

            // Act
            var result = rAMMemoryRepository.Delete(
                Id);

            // Assert
            Assert.Fail();
        }
    }
}
