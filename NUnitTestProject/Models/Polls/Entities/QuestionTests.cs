using System;
using System.Collections.Generic;
using MainMVC.Models.Polls;
using MainMVC.Models.Polls.Entities;
using NUnit.Framework;

namespace NUnitTestProject.Models.Polls.Entities
{
    [TestFixture()]
    public class QuestionTests
    {
        [Test()]
        public void UpdateTest()
        {
            var db = new RAM_MemoryRepository();
            var oldQuestion = (Question)db.GetQuestion(1).Clone();

            var newQuestion = new Question()
            {
                Id = 1,
                Text = "Is this the real life?",
                SoleAnswer = true,
                PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy4?"){Id = 4 },
                                new Answer("I'm just a poor boy"){Id = 5 }
                            }
            };

            db.UpdateQuestion(newQuestion);

            var actual = db.GetQuestion(1).PossibleAnswers[0].Text;
            var expected = newQuestion.PossibleAnswers[0].Text;

            Console.WriteLine(actual);
            Console.WriteLine(expected);


            //Assert.AreEqual(db.GetQuestion(1).PossibleAnswers.Count, old.PossibleAnswers.Count);
            Assert.AreEqual(expected, actual);
        }
    }
}