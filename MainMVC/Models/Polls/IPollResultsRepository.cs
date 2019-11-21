using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_v2.Models.Polls
{
    public interface IPollResultsRepository
    {
        IList<PollResult> GetResults();
        PollResult GetResult(int pollId);
        PollResult AddResult(PollResult pollResult);
    }
}
