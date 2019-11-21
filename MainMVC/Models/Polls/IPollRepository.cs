using System.Collections.Generic;

namespace MVC_v2.Models.Polls
{
    public interface IPollRepository
    {
        Poll GetPoll(int id);
        IList<Poll> GetPolls();
        Poll Add(Poll pull);
    }
}
