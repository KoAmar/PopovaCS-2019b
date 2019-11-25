using System.Collections.Generic;

namespace MainMVC.Models.Polls
{
    public interface IPollRepository
    {
        Poll GetPoll(int Id);
        IEnumerable<Poll> GetPolls();
        Poll Add(Poll poll);
        Poll Update(Poll employeeChanges);
        Poll Delete(int Id);
    }
}
