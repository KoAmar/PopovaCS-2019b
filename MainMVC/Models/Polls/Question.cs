using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MainMVC.Models.Polls
{
    public class Question
    {
        public Question()
        {
            Text = "noText";
            SoleAnswer = true;
            PossibleAnswers = new List<Answer>();
            AnswersCount = 0;
        }

        public Question(string text, bool soleAnswer, IList<Answer> possibleAnswers)
        {
            Text = text;
            SoleAnswer = soleAnswer;
            PossibleAnswers = possibleAnswers;
        }
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public bool SoleAnswer { get; set; }
        [Required]
        [Range(1, 50)]
        public int AnswersCount { get; set; }
        public IList<Answer> PossibleAnswers { get; set; }
    }
}