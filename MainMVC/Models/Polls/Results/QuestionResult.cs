using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MainMVC.Models.Polls.Results
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