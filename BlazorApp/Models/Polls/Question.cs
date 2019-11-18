using System.Collections.Generic;

namespace BlazorApp.Models.Polls
{
    public class Question
    {
        public Question()
        {
            Text = "";
            SoleAnswer = true;
            PossibleAnswers = new List<string>();
        }

        public string Text { get; set; }
        public bool SoleAnswer { get; set; }
        public IList<string> PossibleAnswers { get; set; }
    }
}