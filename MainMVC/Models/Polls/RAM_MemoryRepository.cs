using MainMVC.Models.Polls.Entities;
using MainMVC.Utilities;
using System.Collections.Generic;
using System.Linq;
using MainMVC.Utilities.Models;

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
            return _polls.ElementAtOrDefault(id - 1);
        }

        public IEnumerable<Poll> GetPolls()
        {
            return _polls;
        }

        public Poll Add(Poll poll)
        {
            var id = _polls.Max(e => e.Id) + 1;
            poll.Id = id;
            _polls.Add(poll);

            var maxQuestionId = UtilForPoll.MaxQuestionId(_polls);
            var maxAnswerId = UtilForPoll.MaxAnswerId(_polls);
            _polls = _polls.SetIds(maxQuestionId, maxAnswerId);
            return poll;
        }

        public Poll Update(Poll pollChanges)
        {
            var pollId = pollChanges.Id;
            foreach (var poll in _polls.Where(poll => poll.Id == pollId))
            {
                poll?.Update(pollChanges);
            }

            var maxQuestionId = UtilForPoll.MaxQuestionId(_polls);
            var maxAnswerId = UtilForPoll.MaxAnswerId(_polls);
            _polls = _polls.SetIds(maxQuestionId, maxAnswerId);

            return GetPoll(pollId);
        }

        public Poll Delete(int id)
        {
            Poll poll = _polls.FirstOrDefault(e => e.Id == id);
            if (poll != null)
            {
                _polls.Remove(poll);
            }
            return poll;
            ;
        }

        public Question GetQuestion(int id)
        {
            Question result = null;
            foreach (var poll in _polls)
            {
                foreach (var question in poll.Questions)
                {
                    if (question.Id == id)
                    {
                        result = (Question)question.Clone();
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

        public Answer GetAnswer(int id)
        {
            Answer result = null;
            foreach (var poll in _polls)
            {
                foreach (var question in poll.Questions)
                {
                    foreach (var answer in question.PossibleAnswers)
                    {
                        if (answer.Id == id)
                        {
                            result = (Answer)answer.Clone();
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