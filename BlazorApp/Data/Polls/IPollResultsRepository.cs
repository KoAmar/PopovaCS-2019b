using BlazorApp.Models.Polls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data.Polls
{
    public interface IPollResultsRepository
    {
        IList<PollResult> GetResults();
        PollResult GetResult(int pollId);
        PollResult AddResult(PollResult pollResult);
    }
}
