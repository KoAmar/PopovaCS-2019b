using MainMVC.Models.Polls;
using MainMVC.Utilities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NUnitTestProject1.Utilities
{
    [TestFixture]
    public class IdsTests
    {
        [Test]
        public void SetIds_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Poll poll = new Poll(){
                Id = 1,
                Name = "First Poll",
                CreatorLogin = "Pavlik",
                Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                CreationDate = default,
                QuestionsCount = 2,
                Questions = new List<Question>(){
                        new Question(1){
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            AnswersCount = 3,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer(1,"Is this just fantasy?"),
                                new Answer(2,"I'm just a poor boy"),
                                new Answer(3,"I don't wanna die")
                            }
                        },
                        new Question(2){
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            AnswersCount = 3,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer(4,"Is this just fantasy?"),
                                new Answer(5,"I don't wanna die")
                            }
                        }

                    }
            };
            var ids = new Ids();
            int maxQuestionId = 0;
            int maxAnswerId = 0;

            // Act
            var result = ids.SetIds(
                poll,
                maxQuestionId,
                maxAnswerId);

            // Assert
            Assert.Fail();
        }
    }
}
