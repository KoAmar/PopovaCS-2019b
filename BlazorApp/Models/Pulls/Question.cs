using System.Collections.Generic;

namespace BlazorApp.Models.Pulls
{
    public class Question
    {
        public string QuestionText { get; set; }
        public bool SoleAnswer { get; set; }
        public IList<string> PossibleAnswers { get; set; }
    }
}