using System.Collections.Generic;

namespace MainMVC.Models.Polls
{
    public class Question
    {
        public Question()
        {
            Text = "";
            SoleAnswer = true;
            PossibleAnswers = new List<Answer>();
        }

        public Question(string text, bool soleAnswer, IEnumerable<Answer> possibleAnswers)
        {
            Text = text;
            SoleAnswer = soleAnswer;
            PossibleAnswers = possibleAnswers;
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public bool SoleAnswer { get; set; }
        public IEnumerable<Answer> PossibleAnswers { get; set; }
    }
}