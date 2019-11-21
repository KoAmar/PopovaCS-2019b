using System.Collections.Generic;

namespace MVC_v2.Models.Polls
{
    public interface IPollRepository
    {
        IList<Poll> GetPolls();
        Poll GetPoll(int id);
        Poll Add(Poll poll);
    }
}
