using BlazorApp.Models.Polls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data.Polls
{
    public class MockPollResultsRepository:IPollResultsRepository 
    {
        private readonly IList<PollResult> _pollsResults;

        public MockPollResultsRepository()
        {
            _pollsResults = new List<PollResult>()
            {
                new PollResult()
                {
                    UserId = 0,
                    QuestionResults=new List<QuestionResult>()
                    {
                       new QuestionResult(){Answers = new List<int>(){1,2} },
                       new QuestionResult(){Answers = new List<int>(){1,2} },
                       new QuestionResult(){Answers = new List<int>(){1,2} }
                    }
                }
            };
        }

        public PollResult AddResult(PollResult pollResult)
        {
            _pollsResults.Add(pollResult);
            return pollResult;
        }

        public PollResult GetResult(int pollId)
        {
            return _pollsResults[pollId];
        }

        public IList<PollResult> GetResults()
        {
            throw new NotImplementedException();
        }
    }
}
