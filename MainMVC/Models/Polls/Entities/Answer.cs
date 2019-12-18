using System;
using System.ComponentModel.DataAnnotations;

namespace MainMVC.Models.Polls.Entities
{
    public class Answer : ICloneable
    {
        public Answer()
        {
            Id = 0;
            AnswerSelected = false;
            Text = "noAnswerText";
            AnswerSelectedCounter = 0;
        }

        public Answer(string text = "noAnswerText", int answerSelectedCounter = 0)
        {
            Id = 0;
            AnswerSelected = false;
            Text = text;
            AnswerSelectedCounter = answerSelectedCounter;
        }

        public Answer(int id, string text, int answerSelectedCounter)
        {
            Id = id;
            Text = text;
            AnswerSelectedCounter = answerSelectedCounter;
        }

        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public bool AnswerSelected { get; set; }

        [Required]
        public int AnswerSelectedCounter { get; set; }

        public double CountPercent(int total)
        {
            double result = 0;
            if (total!=0)
            {
                result = ((float)AnswerSelectedCounter / (float)total) * 100;//%
                result = Math.Round(result, 2);
            }
            return result;
        }

        public object Clone() => new Answer(Id, Text, AnswerSelectedCounter);

        public void Update(Answer answerChanges)
        {
            Id = answerChanges.Id;
            Text = answerChanges.Text;
            AnswerSelectedCounter = answerChanges.AnswerSelectedCounter;
        }
    }
}