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
        [Test]
        public void SetIds_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Poll poll = new Poll()
            {
                Id = 1,
                Name = "First Poll",
                CreatorLogin = "Pavlik",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                CreationDate = default,
                QuestionsCount = 2,
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
                        },
                        new Question(){
                            Id = 0,
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            AnswersCount = 2,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy?"){Id = 0 },
                                new Answer("I'm just a poor boy"){Id = 0 }
                            }
                        }
                    }
            };
            int maxQuestionId = 0;
            int maxAnswerId = 0;

            // Act
            var result = UtilForPoll.SetIds(
                poll,
                maxQuestionId,
                maxAnswerId);

            // Assert
            Assert.AreEqual(5,result.Questions[1].PossibleAnswers[1].Id);
        }

    }
}
