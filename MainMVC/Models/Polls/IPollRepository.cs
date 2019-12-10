using System.Collections.Generic;
using MainMVC.Models.Polls.Entities;

namespace MainMVC.Models.Polls
{
    public interface IPollRepository
    {
        Poll GetPoll(int id);

        IEnumerable<Poll> GetPolls();

        Poll Add(Poll poll);

        Poll Update(Poll employeeChanges);

        Poll Delete(int id);

        Question GetQuestion(int id);

        Question UpdateQuestion(Question question);

        Answer GetAnswer(int id);

        Answer UpdateAnswer(Answer answer);
    }
}