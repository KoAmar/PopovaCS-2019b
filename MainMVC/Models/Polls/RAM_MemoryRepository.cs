using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainMVC.Models.Polls
{
    public class RAM_MemoryRepository : IPollRepository
    {
        private readonly List<Poll> _polls;

        public RAM_MemoryRepository()
        {
            _polls = new List<Poll>()
            {
                new Poll(){
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
                },
                new Poll( ){
                    Id=2,
                    Name = "Second Poll",
                    CreatorLogin = "KoAmar",
                    Description = $"Miusov, as a man man of breeding and deilcacy, could not but feel some inwrd qualms, when he reached the Father Superior's with Ivan: he felt ashamed of havin lost his temper. He felt that he ought to have disdaimed that despicable wretch, Fyodor Pavlovitch, too much to have been upset by him in Father Zossima's cell, and so to have forgotten himself. Teh monks were not to blame, in any case, he reflceted, on the steps. And if they're decent people here (and the Father Superior, I understand, is a nobleman) why not be friendly and courteous withthem? I won't argue, I'll fall in with everything, I'll win them by politness, and show them that I've nothing to do with that Aesop, thta buffoon, that Pierrot, and have merely been takken in over this affair, just as they have.",
                    CreationDate = default,
                    QuestionsCount = 1,
                    Questions = new List<Question>(){
                        new Question(3){
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            AnswersCount = 3,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer(6,"Is this just fantasy?"),
                                new Answer(7,"I'm just a poor boy"),
                                new Answer(8,"I don't wanna die"),
                                new Answer(9,"I don't wanna die")
                            }
                        }
                    },
                }
            };
        }

        public Poll GetPoll(int id)
        {
            return _polls[id - 1];
        }

        public IEnumerable<Poll> GetPolls()
        {
            return _polls;
        }

        public Poll Add(Poll poll)
        {
            var Id = _polls.Max(e => e.Id) + 1;
            poll.Id = Id;

            var maxQuestionId = MaxQuestionId(_polls);
            var maxAnswerId = MaxAnswerId(_polls);

            _polls.Add(poll);
            return poll;
        }

        public int MaxQuestionId(List<Poll> polls)
        {
            int result = int.MinValue;
            foreach (var poll in polls)
            {
                foreach (var question in poll.Questions)
                {
                    int id = question.Id;
                    if (id > result) { result = id; }
                }
            }
            return result;
        }

        public int MaxAnswerId(List<Poll> polls)
        {
            int result = int.MinValue;
            foreach (var poll in polls)
            {
                foreach (var question in poll.Questions)
                {
                    foreach (var answer in question.PossibleAnswers)
                    {
                        //стояло question, вместо answer 
                        int id = answer.Id;
                        if (id > result) { result = id; }
                    }
                }
            }
            return result;
        }

        public Poll Update(Poll pollChanges)
        {
            Poll poll = _polls.FirstOrDefault(e => e.Id == pollChanges.Id);
            if (poll != null)
            {
                poll.Name = pollChanges.Name;
                poll.Description = pollChanges.Description;
                poll.Questions = pollChanges.Questions;
                poll.QuestionsCount = pollChanges.QuestionsCount;
            }
            return poll;
        }

        public Poll Delete(int Id)
        {
            Poll poll = _polls.FirstOrDefault(e => e.Id == Id);
            if (poll != null)
            {
                _polls.Remove(poll);
            }
            return poll;
            ;
        }
    }
}
