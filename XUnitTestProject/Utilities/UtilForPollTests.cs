using System.Collections.Generic;
using MainMVC.Models.Polls.Entities;
using MainMVC.Utilities.Models;
using Xunit;

namespace XUnitTestProject.Utilities
{
    public class UtilForPollTests
    {
        public List<Poll> GetPolls()
        {
            return new List<Poll>(){
                new Poll(){
                    Id = 1,
                    Name = "First Poll",
                    CreatorLogin = "Pavlik",
                    Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                    CreationDate = default,
                    Questions = new List<Question>(){
                        new Question(){
                            Id = 0,
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy?"){Id = 0 },
                                new Answer("I'm just a poor boy"){Id = 0 },
                                new Answer("I don't wanna die"){Id = 0 }
                            }
                        }
                    }
                }
            };
        }

        [Fact]
        public void MaxQuestionId_emptyPoll_empty()
        {
            // Arrange
            List<Poll> polls = GetPolls();
            polls.Clear();

            // Act
            var result = UtilForPoll.MaxQuestionId(polls);

            // Assert
            Assert.Equal(int.MinValue, result);
        }

        [Fact]
        public void MaxQuestionId_emptyQuestion_empty()
        {
            // Arrange
            List<Poll> polls = GetPolls();
            polls[0].Questions.Clear();

            // Act
            var result = UtilForPoll.MaxQuestionId(polls);

            // Assert
            Assert.Equal(int.MinValue, result);
        }

        [Fact]
        public void MaxQuestionId_smallId_empty()
        {
            // Arrange
            List<Poll> polls = GetPolls();

            // Act
            var result = UtilForPoll.MaxQuestionId(polls);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void MaxQuestionId_normal_equal()
        {
            // Arrange
            List<Poll> polls = GetPolls();
            polls.Add(new Poll()
            {
                Id = 1,
                Name = "First Poll",
                CreatorLogin = "Pavlik",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                CreationDate = default,
                Questions = new List<Question>(){
                        new Question(){
                            Id = 5,
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy?"){Id = 0 },
                                new Answer("I'm just a poor boy"){Id = 0 },
                                new Answer("I don't wanna die"){Id = 0 }
                            }
                        }
                    }
            });

            // Act
            var result = UtilForPoll.MaxQuestionId(polls);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void SetIds_NullPoll_Null()
        {
            // Arrange
            List<Poll> polls = null;
            int maxQuestionId = 0;
            int maxAnswerId = 0;

            // Act
            var result = UtilForPoll.SetIds(
                polls,
                maxQuestionId,
                maxAnswerId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void SetIds_EmptyFor1_Empty()
        {
            // Arrange
            List<Poll> polls = GetPolls();
            polls.Clear();
            int maxQuestionId = 0;
            int maxAnswerId = 0;

            // Act
            var result = UtilForPoll.SetIds(
                polls,
                maxQuestionId,
                maxAnswerId);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SetIds_EmptyFor2_Empty()
        {
            // Arrange
            List<Poll> polls = GetPolls();
            polls[0].Questions.Clear();
            int maxQuestionId = 0;
            int maxAnswerId = 0;

            // Act
            var result = UtilForPoll.SetIds(
                polls,
                maxQuestionId,
                maxAnswerId);

            // Assert
            Assert.Empty(result[0].Questions);
        }

        [Fact]
        public void SetIds_EmptyFor3_Empty()
        {
            // Arrange
            List<Poll> polls = GetPolls();
            polls[0].Questions[0].PossibleAnswers.Clear();
            int maxQuestionId = 0;
            int maxAnswerId = 0;

            // Act
            var result = UtilForPoll.SetIds(
                polls,
                maxQuestionId,
                maxAnswerId);

            // Assert
            Assert.Empty(result[0].Questions[0].PossibleAnswers);
        }

        [Fact]
        public void SetIds_if5_Equal1()
        {
            // Arrange
            List<Poll> polls = GetPolls();
            int maxQuestionId = 0;
            int maxAnswerId = 0;

            // Act
            var result = UtilForPoll.SetIds(
                polls,
                maxQuestionId,
                maxAnswerId);

            // Assert
            Assert.Equal(1, result[0].Questions[0].Id);
        }

        [Fact]
        public void SetIds_if7_Equal2()
        {
            // Arrange
            List<Poll> polls = GetPolls();
            int maxQuestionId = 0;
            int maxAnswerId = 0;

            // Act
            var result = UtilForPoll.SetIds(
                polls,
                maxQuestionId,
                maxAnswerId);

            // Assert
            Assert.Equal(2, result[0].Questions[0].PossibleAnswers[1].Id);
        }
    }
}
