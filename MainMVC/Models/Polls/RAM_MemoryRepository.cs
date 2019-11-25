using MainMVC.Utilities;
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
                        new Question(){
                            Id = 1,
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            AnswersCount = 3,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy?"){Id = 1 },
                                new Answer("I'm just a poor boy"){Id = 2 },
                                new Answer("I don't wanna die"){Id = 3 }
                            }
                        },
                        new Question(){
                            Id = 2,
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            AnswersCount = 2,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy?"){Id = 4 },
                                new Answer("I'm just a poor boy"){Id = 5 }
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
                        new Question(){
                            Id = 3,
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            AnswersCount = 4,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy?"){Id = 6 },
                                new Answer("I'm just a poor boy"){Id = 7 },
                                new Answer("I don't wanna die"){Id = 8 },
                                new Answer("I don't wanna die"){Id = 9 }
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

            var maxQuestionId = UtilForPoll.MaxQuestionId(_polls);
            var maxAnswerId = UtilForPoll.MaxAnswerId(_polls);

            _polls.Add(poll);
            return poll;
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

        public Question GetQuestion(int Id)
        {
            Question result = null;
            foreach (var poll in _polls)
            {
                foreach (var question in poll.Questions)
                {
                    if (question.Id == Id)
                    {
                        result = question;
                    }
                }
            }
            return result;
        }

        public Question UpdateQuestion(Question questionChanges)
        {
            foreach (var poll in _polls)
            {
                foreach (var question in poll.Questions)
                {
                    if (question.Id == questionChanges.Id)
                    {
                        question.AnswersCount = questionChanges.AnswersCount;
                        question.SoleAnswer = questionChanges.SoleAnswer;
                        question.Text = questionChanges.Text;

                        if (question.AnswersCount < question.PossibleAnswers.Count)
                        {
                            for (int num = 0; num < question.PossibleAnswers.Count - question.AnswersCount; num++)
                            {
                                question.PossibleAnswers.Add(new Answer());
                            }
                        }
                        else
                        {
                            for (int num = 0; num < question.AnswersCount - question.PossibleAnswers.Count; num++)
                            {
                                question.PossibleAnswers.RemoveAt(question.AnswersCount + num);
                            }
                        }

                        for (int num = 0; num < question.AnswersCount; num++)
                        {
                            question.PossibleAnswers[num] = questionChanges.PossibleAnswers[num];
                        }

                    }
                }
                var maxQuestionId = UtilForPoll.MaxQuestionId(_polls);
                var maxAnswerId = UtilForPoll.MaxAnswerId(_polls);
                UtilForPoll.SetIds(poll, maxQuestionId, maxAnswerId);
            }
            return questionChanges;
        }

        public Answer GetAnswer(int Id)
        {
            Answer result = null;
            foreach (var poll in _polls)
            {
                foreach (var question in poll.Questions)
                {
                    foreach (var answer in question.PossibleAnswers)
                    {
                        if (answer.Id == Id)
                        {
                            result = answer;
                        }
                    }
                }
            }
            return result;

        }

        public Answer UpdateAnswer(Answer answerChanges)
        {

            foreach (var poll in _polls)
            {
                foreach (var question in poll.Questions)
                {
                    foreach (var answer in question.PossibleAnswers)
                    {
                        if (answer.Id == answerChanges.Id)
                        {
                            answer.Text = answerChanges.Text;
                            answer.AnswerSelectedCounter = answerChanges.AnswerSelectedCounter;
                        }
                    }
                }
            }
            return answerChanges;
        }
    }
}
