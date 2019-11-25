using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainMVC.Models.Polls
{
    public class Answer : ICloneable
    {
        public Answer(string text = "noAnswerText", int answerSelectedCounter = 0)
        {
            Id = 0;
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
        public string Text { get; set; }
        public int AnswerSelectedCounter { get; set; }

        public object Clone() => new Answer(Id, Text, AnswerSelectedCounter);
    }
}
