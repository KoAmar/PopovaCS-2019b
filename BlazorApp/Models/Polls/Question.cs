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

        public Question(string text, bool soleAnswer, IList<string> possibleAnswers)
        {
            Text = text;
            SoleAnswer = soleAnswer;
            PossibleAnswers = possibleAnswers;
        }

        public string Text { get; set; }
        public bool SoleAnswer { get; set; }
        public IList<string> PossibleAnswers { get; set; }
    }
}