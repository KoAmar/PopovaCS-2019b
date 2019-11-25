using System.Collections.Generic;

namespace MainMVC.Models.Polls
{
    public interface IPollRepository
    {
        Poll GetPoll(int id);
        IEnumerable<Poll> GetPolls();
        Poll Add(Poll pull);
    }
}
