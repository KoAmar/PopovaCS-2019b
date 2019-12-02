using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MainMVC.Models.Polls
{
    public class Question : ICloneable
    {
        public Question()
        {
            Id = 0;
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

        public Question(int id, string text, bool soleAnswer, int answersCount, IList<Answer> possibleAnswers)
        {
            Id = id;
            Text = text;
            SoleAnswer = soleAnswer;
            AnswersCount = answersCount;
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


        public object Clone()
        {
            IList<Answer> possibleAnswers = new List<Answer>();
            for (int num = 0; num < PossibleAnswers.Count; num++)
            {
                possibleAnswers[num] = (Answer)PossibleAnswers[num].Clone();
            }
            return new Question(Id, Text, SoleAnswer, AnswersCount, possibleAnswers);

        }
    }
}