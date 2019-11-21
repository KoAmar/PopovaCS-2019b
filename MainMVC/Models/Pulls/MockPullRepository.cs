using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_v2.Models.Polls
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
//            if(_polls.)
            return _polls[id];
        }

        public IList<Poll> GetPolls()
        {
            return _polls;
        }

        public Poll Add(Poll poll)
        {
            poll.Id = _polls.Max(e => e.Id) + 1;
            poll.CreatorLogin = "default";
            poll.CreationDate = DateTime.Now;
            poll.Questions = new List<Question>();
            _polls.Add(poll);
            return poll;
        }
    }
}
