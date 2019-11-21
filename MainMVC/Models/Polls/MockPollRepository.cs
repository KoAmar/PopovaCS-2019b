using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_v2.Models.Polls
{
    public class MockPollRepository : IPollRepository
    {
        private readonly IList<Poll> _polls;

        public MockPollRepository()
        {
            _polls = new List<Poll>()
            {
                new Poll{
                    Id = 0,
                    Name = "First Poll",
                    CreatorLogin = "Pavlik",
                    Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                    CreationDate = default,
                    Questions = new List<Question>(){
                        new Question{
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<string>()
                            {
                                "Is this just fantasy?",
                                "I'm just a poor boy",
                                "I don't wanna die"
                            }
                        },
                        new Question{
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<string>()
                            {
                                "Is this just fantasy?",
                                "Is this just fantasy?",
                                "Is this just fantasy?",
                                "I'm just a poor boy",
                                "I don't wanna die"
                            }
                        },
                        new Question{
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<string>()
                            {
                                "I don't wanna die",
                                "I don't wanna die",
                                "I don't wanna die",
                                "I don't wanna die",
                                "I don't wanna die"
                            }
                        },
                        new Question(),
                        new Question()
                    }
                },
                new Poll(){
                    Id = 1,
                    Name = "Second Poll",
                    CreatorLogin = "KoAmar",
                    Description = $"Miusov, as a man man of breeding and deilcacy, could not but feel some inwrd qualms, when he reached the Father Superior's with Ivan: he felt ashamed of havin lost his temper. He felt that he ought to have disdaimed that despicable wretch, Fyodor Pavlovitch, too much to have been upset by him in Father Zossima's cell, and so to have forgotten himself. Teh monks were not to blame, in any case, he reflceted, on the steps. And if they're decent people here (and the Father Superior, I understand, is a nobleman) why not be friendly and courteous withthem? I won't argue, I'll fall in with everything, I'll win them by politness, and show them that I've nothing to do with that Aesop, thta buffoon, that Pierrot, and have merely been takken in over this affair, just as they have.",
                    CreationDate = default,
                    Questions = new List<Question>(){
                        new Question{
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<string>()
                            {
                                "Is this just fantasy?",
                                "I'm just a poor boy",
                                "I don't wanna die"
                            }
                        },
                        new Question{
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<string>()
                            {
                                "Is this just fantasy?",
                                "Is this just fantasy?",
                                "Is this just fantasy?",
                                "I'm just a poor boy",
                                "I don't wanna die"
                            }
                        },
                        new Question{
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<string>()
                            {
                                "I don't wanna die",
                                "I don't wanna die",
                                "I don't wanna die",
                                "I don't wanna die",
                                "I don't wanna die"
                            }
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

        public Poll Add(Poll poll)
        {
            poll.Id = _polls.Max(e => e.Id) + 1;
            _polls.Add(poll);
            return poll;
        }
    }
}
