using NUnit.Framework;
using MainMVC.Models.Polls.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainMVC.Models.Polls.Entities.Tests
{
    [TestFixture()]
    public class QuestionTests
    {
        [Test()]
        public void UpdateTest()
        {
            var db = new RAM_MemoryRepository();
            var old = (Question)db.GetQuestion(1).Clone();
            Console.WriteLine(old.PossibleAnswers.Count);

            var question = new Question()
            {
                Id = 1,
                Text = "Is this the real life?",
                SoleAnswer = true,
                AnswersCount = 2,
                PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy?"){Id = 4 },
                                new Answer("I'm just a poor boy"){Id = 5 }
                            }
            };
            db.UpdateQuestion(question);

            //var exp =

            //Assert.AreEqual(db.GetQuestion(1).PossibleAnswers.Count, old.PossibleAnswers.Count);
            Assert.AreNotEqual(db.GetQuestion(1).PossibleAnswers[0].Text, old.PossibleAnswers[0].Text);
        }
    }
}