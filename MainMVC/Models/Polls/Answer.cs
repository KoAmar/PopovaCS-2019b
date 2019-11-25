using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainMVC.Models.Polls
{
    public class Answer
    {
        public Answer(int Id, string text = "noAnswerText", int answerSelectedCounter = 0)
        {
            this.Id = Id;
            Text = text;
            AnswerSelectedCounter = answerSelectedCounter;
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int AnswerSelectedCounter { get; set; }
    }
}
