using MainMVC.Models.Polls.Entities;
using MainMVC.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace MainMVC.Models.Polls
{
    public class RAM_MemoryRepository : IPollRepository
    {
        private List<Poll> _polls;

        public RAM_MemoryRepository()
        {
            _polls = Data.GetData();
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
            _polls.Add(poll);

            var maxQuestionId = UtilForPoll.MaxQuestionId(_polls);
            var maxAnswerId = UtilForPoll.MaxAnswerId(_polls);
            _polls = UtilForPoll.SetIds(_polls, maxQuestionId, maxAnswerId);
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
                        question.Update(questionChanges);
                    }
                }
            }
            var maxQuestionId = UtilForPoll.MaxQuestionId(_polls);
            var maxAnswerId = UtilForPoll.MaxAnswerId(_polls);
            //_polls = UtilForPoll.SetIds(_polls, maxQuestionId, maxAnswerId);
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
                            answer.Update(answerChanges);
                        }
                    }
                }
            }
            return answerChanges;
        }
    }
}