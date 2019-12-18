using System;
using System.Collections.Generic;
using MainMVC.Models.Polls;
using MainMVC.Models.Polls.Entities;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject.Models.Polls.Entities
{
    public class PollTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public PollTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void UpdateTest()
        {
            var db = new RAM_MemoryRepository();
            var oldPoll = (Poll)db.GetPoll(1).Clone();

            var newPoll = new Poll()
            {
                Id = 2,
                Name = "Second Poll",
                CreatorLogin = "KoAmar",
                Description = "Miusov, as a man man of breeding and deilcacy, could not but feel some inwrd qualms, when he reached the Father Superior's with Ivan: he felt ashamed of havin lost his temper. He felt that he ought to have disdaimed that despicable wretch, Fyodor Pavlovitch, too much to have been upset by him in Father Zossima's cell, and so to have forgotten himself. Teh monks were not to blame, in any case, he reflceted, on the steps. And if they're decent people here (and the Father Superior, I understand, is a nobleman) why not be friendly and courteous withthem? I won't argue, I'll fall in with everything, I'll win them by politness, and show them that I've nothing to do with that Aesop, thta buffoon, that Pierrot, and have merely been takken in over this affair, just as they have.",
                CreationDate = default,
                Questions = new List<Question>(){
                    new Question(){
                        Id = 3,
                        Text = "Is this the real lifeee?",
                        PossibleAnswers = new List<Answer>()
                        {
                            new Answer("Is this just fantasy6?"){Id = 6 },
                            new Answer("I'm just a poor boy"){Id = 7 },
                            new Answer("I don't wanna die"){Id = 8 },
                            new Answer("I don't wanna die"){Id = 9 }
                        }
                    }
                },
            };
            db.Update(newPoll);

            var expected = newPoll.Questions[0];
            var result = db.GetPoll(2).Questions[0];

            _testOutputHelper.WriteLine(expected.Id.ToString());
            _testOutputHelper.WriteLine(expected.Text);
            _testOutputHelper.WriteLine(expected.PossibleAnswers[0].Text);
            _testOutputHelper.WriteLine(expected.ToString());
            _testOutputHelper.WriteLine(result.Id.ToString());
            _testOutputHelper.WriteLine(result.Text);
            _testOutputHelper.WriteLine(result.PossibleAnswers[0].Text);
            _testOutputHelper.WriteLine(result.ToString());

            //Assert.AreEqual(db.GetQuestion(1).PossibleAnswers.Count, old.PossibleAnswers.Count);
            Assert.Equal(expected.Text, result.Text);
        }
    }
}