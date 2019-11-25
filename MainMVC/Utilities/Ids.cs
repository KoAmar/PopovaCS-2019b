using MainMVC.Models.Polls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainMVC.Utilities
{
    public class Ids
    {
        public Poll SetIds(Poll poll, int maxQuestionId, int maxAnswerId)
        {   

            foreach (var question in poll.Questions)
            {
                if (question != null)
                {
                    maxQuestionId++;
                    question.Id = maxQuestionId;
                    foreach (var answer in question.PossibleAnswers)
                    {
                        if (answer != null) { answer.Id = maxAnswerId++; }
                    }

                }
            }
            return poll;
        }
    }
}
