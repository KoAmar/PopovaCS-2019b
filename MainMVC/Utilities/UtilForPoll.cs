using MainMVC.Models.Polls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainMVC.Utilities
{
    public static class UtilForPoll
    {
        public static Poll SetIds(Poll poll, int maxQuestionId, int maxAnswerId)
        {   
            foreach (var question in poll.Questions)
            {
                if (question != null)
                {
                    question.Id = ++maxQuestionId;
                    foreach (var answer in question.PossibleAnswers)
                    {
                        if (answer != null) { answer.Id = ++maxAnswerId; }
                    }

                }
            }
            return poll;
        }

        public static int MaxQuestionId(List<Poll> polls)
        {
            int result = int.MinValue;
            foreach (var poll in polls)
            {
                foreach (var question in poll.Questions)
                {
                    int id = question.Id;
                    if (id > result) { result = id; }
                }
            }
            return result;
        }

        public static int MaxAnswerId(List<Poll> polls)
        {
            int result = int.MinValue;
            foreach (var poll in polls)
            {
                foreach (var question in poll.Questions)
                {
                    foreach (var answer in question.PossibleAnswers)
                    {
                        //стояло question, вместо answer 
                        int id = answer.Id;
                        if (id > result) { result = id; }
                    }
                }
            }
            return result;
        }
    }
}
