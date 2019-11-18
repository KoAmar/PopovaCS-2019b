using System.Collections.Generic;
using BlazorApp.Models.Polls;

namespace BlazorApp.Data.Polls
{
    public interface IPollRepository
    {
        Poll GetPoll(int id);
        IList<Poll> GetPolls();
        Poll Add(Poll pull);
    }
}
