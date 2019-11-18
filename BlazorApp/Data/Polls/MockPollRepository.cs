using BlazorApp.Models.Polls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data.Polls
{
    public class MockPollRepository : IPollRepository
    {
        private readonly List<Poll> _polls;

        public MockPollRepository()
        {
            _polls = new List<Poll>()
            {
                new Poll{
                    Id = 0,
                    Name = "First Poll",
                    CreatorLogin = "Pavlik",
                    CreationDate = default,
                    Questions = new List<Question>(){
                        new Question{
                            QuestionText = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<string>()
                            {
                                "Is this just fantasy?",
                                "I'm just a poor boy",
                                "I don't wanna die"
                            }
                        },
                        new Question{
                            QuestionText = null,
                            SoleAnswer = false,
                            PossibleAnswers = null
                        }
                    }
                },
                new Poll(){
                    Id = 1,
                    Name = "Second Poll",
                    CreatorLogin = "KoAmar",
                    CreationDate = default,
                    Questions = new List<Question>(){
                        new Question{
                            QuestionText = null,
                            SoleAnswer = false,
                            PossibleAnswers = null
                        },
                        new Question{
                            QuestionText = null,
                            SoleAnswer = false,
                            PossibleAnswers = null
                        },
                        new Question{
                            QuestionText = null,
                            SoleAnswer = false,
                            PossibleAnswers = null
                        }
                    }
                }
            };
        }

        public Poll GetPoll(int id)
        {
            return _polls[id];
        }

        public IList<Poll> GetPolls()
        {
            return _polls;
        }

        public Poll Add(Poll pull)
        {
            pull.Id = _polls.Max(e => e.Id) + 1;
            pull.CreatorLogin = "default";
            pull.CreationDate = DateTime.Now;
            pull.Questions = new List<Question>();
            _polls.Add(pull);
            return pull;
        }
    }
}
