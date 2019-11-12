using BlazorApp.Models.Polls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Data
{
    public class RAMPollRepository : IPollRepository
    {
        private readonly List<Poll> _pulls;

        public RAMPollRepository()
        {
            _pulls = new List<Poll>()
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
            return _pulls[id];
        }

        public IList<Poll> GetPolls()
        {
            return _pulls;
        }

        public Poll Add(Poll pull)
        {
            pull.Id = _pulls.Max(e => e.Id) + 1;
            pull.CreatorLogin = "default";
            pull.CreationDate = DateTime.Now;
            pull.Questions = new List<Question>();
            _pulls.Add(pull);
            return pull;
        }
    }
}
