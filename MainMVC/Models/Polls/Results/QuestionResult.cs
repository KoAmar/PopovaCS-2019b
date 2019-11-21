using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MVC_v2.Models.Polls.Results
{
    public class QuestionResult
    {
        public QuestionResult()
        {
            Answers = new List<int>();
        }

        public IList<int> Answers { get; set; }
    }
}