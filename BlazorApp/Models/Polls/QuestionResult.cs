using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BlazorApp.Models.Polls
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