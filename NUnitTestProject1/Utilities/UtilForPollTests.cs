using MainMVC.Models.Polls;
using MainMVC.Utilities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NUnitTestProject1.Utilities
{
    [TestFixture]
    public class UtilForPollTests
    {
        private List<Poll> mockRepository;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new List<Poll>(){
                new Poll(){
                    Id = 1,
                    Name = "First Poll",
                    CreatorLogin = "Pavlik",
                    Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                    CreationDate = default,
                    QuestionsCount = 1,
                    Questions = new List<Question>(){
                        new Question(){
                            Id = 0,
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            AnswersCount = 3,
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

        [Test]
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

        [Test]
        public void SetIds_EmptyFor1_Empty()
        {
            // Arrange
            mockRepository.Clear();
            List<Poll> polls = mockRepository;
            int maxQuestionId = 0;
            int maxAnswerId = 0;

            // Act
            var result = UtilForPoll.SetIds(
                polls,
                maxQuestionId,
                maxAnswerId);

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void SetIds_EmptyFor2_Empty()
        {
            // Arrange
            mockRepository[0].Questions.Clear();
            List<Poll> polls = mockRepository;
            int maxQuestionId = 0;
            int maxAnswerId = 0;

            // Act
            var result = UtilForPoll.SetIds(
                polls,
                maxQuestionId,
                maxAnswerId);

            // Assert
            Assert.IsEmpty(result[0].Questions);
        }

        [Test]
        public void SetIds_EmptyFor3_Empty()
        {
            // Arrange
            mockRepository[0].Questions[0].PossibleAnswers.Clear();
            List<Poll> polls = mockRepository;
            int maxQuestionId = 0;
            int maxAnswerId = 0;

            // Act
            var result = UtilForPoll.SetIds(
                polls,
                maxQuestionId,
                maxAnswerId);

            // Assert
            Assert.IsEmpty(result[0].Questions[0].PossibleAnswers);
        }

        [Test]
        public void SetIds_if5_Equal1()
        {
            // Arrange
            List<Poll> polls = mockRepository;
            int maxQuestionId = 0;
            int maxAnswerId = 0;

            // Act
            var result = UtilForPoll.SetIds(
                polls,
                maxQuestionId,
                maxAnswerId);

            // Assert
            Assert.AreEqual(1, result[0].Questions[0].Id);
        }

        [Test]
        public void SetIds_if7_Equal2()
        {
            // Arrange
            List<Poll> polls = mockRepository;
            int maxQuestionId = 0;
            int maxAnswerId = 0;

            // Act
            var result = UtilForPoll.SetIds(
                polls,
                maxQuestionId,
                maxAnswerId);

            // Assert
            Assert.AreEqual(2, result[0].Questions[0].PossibleAnswers[1].Id);
        }
    }
}
