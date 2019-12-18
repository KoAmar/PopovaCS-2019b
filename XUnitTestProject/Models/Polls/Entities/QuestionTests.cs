using System;
using System.Collections.Generic;
using MainMVC.Models.Polls;
using MainMVC.Models.Polls.Entities;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject.Models.Polls.Entities
{
    public class QuestionTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public QuestionTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void UpdateTest()
        {
            var db = new RamMemoryPollRepository();
            var oldQuestion = (Question)db.GetQuestion(1).Clone();

            var newQuestion = new Question()
            {
                Id = 1,
                Text = "Is this the real life?",
                PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy4?"){Id = 4 },
                                new Answer("I'm just a poor boy"){Id = 5 }
                            }
            };

            db.UpdateQuestion(newQuestion);

            var actual = db.GetQuestion(1).PossibleAnswers[0].Text;
            var expected = newQuestion.PossibleAnswers[0].Text;

            _testOutputHelper.WriteLine(actual);
            _testOutputHelper.WriteLine(expected);


            //Assert.AreEqual(db.GetQuestion(1).PossibleAnswers.Count, old.PossibleAnswers.Count);
            Assert.Equal(expected, actual);
        }
    }
}