using System.Collections.Generic;

namespace MVC_v2.Models.Polls
{
    public class Question
    {
        public string QuestionText { get; set; }
        public bool SoleAnswer { get; set; }
        public IList<string> PossibleAnswers { get; set; }
    }
}