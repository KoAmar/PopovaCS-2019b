using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_v2.Models.Pulls
{
    public class MockPullRepository : IPullRepository
    {
        private readonly List<Pull> _pulls;

        public MockPullRepository()
        {
            _pulls = new List<Pull>()
            {
                new Pull{
                    Id = 0,
                    Name = "First Pull", 
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
                new Pull(){
                    Id = 1,
                    Name = "Second Pull", 
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

        public Pull GetPull(int id)
        {
//            if(_pulls.)
            return _pulls[id];
        }

        public IList<Pull> GetPulls()
        {
            return _pulls;
        }

        public Pull Add(Pull pull)
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
