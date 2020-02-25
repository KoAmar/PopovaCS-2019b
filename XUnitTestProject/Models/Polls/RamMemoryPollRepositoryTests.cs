using MainMVC.Models.Polls;
using Moq;
using System;
using System.Linq;
using MainMVC.Models.Polls.Entities;
using Xunit;

namespace XUnitTestProject.Models.Polls
{
    public class RamMemoryPollRepositoryTests : IDisposable
    {
        private MockRepository mockRepository;



        public RamMemoryPollRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        private RamMemoryPollRepository CreateRamMemoryPollRepository()
        {
            return new RamMemoryPollRepository();
        }

        [Fact]
        public void GetAnswer_EmptPoll_Null()
        {
            // Arrange
            var ramMemoryPollRepository = this.CreateRamMemoryPollRepository();
            
            ramMemoryPollRepository.ClearPoll();
            // Act
            var result = ramMemoryPollRepository.GetAnswer(1);

            // Assert
            Assert.Null(result);
        }
        
        [Fact]
        public void GetAnswer_EmptQue_Null()
        {
            // Arrange
            var ramMemoryPollRepository = this.CreateRamMemoryPollRepository();
            
            ramMemoryPollRepository.ClearQue();
            // Act
            var result = ramMemoryPollRepository.GetAnswer(1);

            // Assert
            Assert.Null(result);
        }
        
        [Fact]
        public void GetAnswer_EmptAns_Null()
        {
            // Arrange
            var ramMemoryPollRepository = this.CreateRamMemoryPollRepository();
            
            ramMemoryPollRepository.ClearAnsw();
            // Act
            var result = ramMemoryPollRepository.GetAnswer(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetAnswer_if2_Ok()
        {
            // Arrange
            var ramMemoryPollRepository = this.CreateRamMemoryPollRepository();
            
            var polls = ramMemoryPollRepository.GetPolls().ToList();
            // Act
            var result = ramMemoryPollRepository.GetAnswer(1);

            // Assert
            Assert.Equal(result.Text,polls[0].Questions[0].PossibleAnswers[0].Text);
        }

        [Fact]
        public void GetAnswer_if1_Null()
        {
            // Arrange
            var ramMemoryPollRepository = this.CreateRamMemoryPollRepository();
            
            ramMemoryPollRepository.ClearAnsw();
            // Act
            var result = ramMemoryPollRepository.GetAnswer(999);

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public void UpdateAnswer_EmptPoll_Null()
        {
            // Arrange
            var ramMemoryPollRepository = this.CreateRamMemoryPollRepository();
            
            ramMemoryPollRepository.ClearPoll();
            // Act
            var result = ramMemoryPollRepository.UpdateAnswer(new Answer(){Id = 1});

            // Assert
            Assert.Null(result);
        }
        
        [Fact]
        public void UpdateAnswer_EmptQue_Null()
        {
            // Arrange
            var ramMemoryPollRepository = this.CreateRamMemoryPollRepository();
            
            ramMemoryPollRepository.ClearQue();
            // Act
            var result = ramMemoryPollRepository.UpdateAnswer(new Answer(){Id = 1});

            // Assert
            Assert.Null(result);
        }
        
        [Fact]
        public void UpdateAnswer_EmptAns_Null()
        {
            // Arrange
            var ramMemoryPollRepository = this.CreateRamMemoryPollRepository();
            
            ramMemoryPollRepository.ClearAnsw();
            // Act
            var result = ramMemoryPollRepository.UpdateAnswer(new Answer(){Id = 1});

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void UpdateAnswer_if2_Ok()
        {
            // Arrange
            var ramMemoryPollRepository = this.CreateRamMemoryPollRepository();
            
            var polls = ramMemoryPollRepository.GetPolls().ToList();
            // Act
            var result = ramMemoryPollRepository.UpdateAnswer(new Answer(){Id = 1});

            // Assert
            Assert.Equal(result.Text,polls[0].Questions[0].PossibleAnswers[0].Text);
        }

        [Fact]
        public void UpdateAnswer_if1_Null()
        {
            // Arrange
            var ramMemoryPollRepository = this.CreateRamMemoryPollRepository();
            
            ramMemoryPollRepository.ClearAnsw();
            // Act
            var answerChanges = new Answer(){Id = 999};
            var result = ramMemoryPollRepository.UpdateAnswer(answerChanges);

            // Assert
            Assert.Null(result);
        }
    }
}
