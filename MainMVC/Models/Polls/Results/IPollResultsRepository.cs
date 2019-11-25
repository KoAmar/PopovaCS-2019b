using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainMVC.Models.Polls.Results
{
    public interface IPollResultsRepository
    {
        IList<PollResult> GetResults();
        PollResult GetResult(int pollId);
        PollResult AddResult(PollResult pollResult);
    }
}
