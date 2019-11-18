using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models.Polls
{
    public class PollResult
    {
        public PollResult()
        {
            UserId = 0;
            QuestionResults = new List<QuestionResult>();
        }

        public int UserId { get; set; }
        public IList<QuestionResult> QuestionResults { get; set; }
    }
}
