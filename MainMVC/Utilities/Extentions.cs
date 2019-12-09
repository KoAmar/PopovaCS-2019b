using MainMVC.Models.Polls.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainMVC.Utilities
{
    public static class Extentions
    {
        public static void UpdateTo(this List<Answer> answers, List<Answer> newAnswers)
        {
            foreach (var newAnswer in newAnswers)
            {
                var answer = answers.Where(ans => ans.Id == newAnswer.Id).FirstOrDefault();
                answer.AnswerSelected = newAnswer.AnswerSelected;
                answer.AnswerSelectedCounter = newAnswer.AnswerSelectedCounter;
                answer.Text = newAnswer.Text;
            }
        }

        public static void UpdateTo(this List<Question> questions)
        {
        }

        public static void UpdateTo(this List<Poll> polls)
        {
        }
    }
}