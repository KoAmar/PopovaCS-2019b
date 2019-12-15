using System;
using System.Collections.Generic;
using MainMVC.Models.Polls.Entities;

namespace MainMVC.Utilities.Models
{
    public static class UtilForPoll
    {
        public static List<Poll> SetIds(List<Poll> polls, int maxQuestionId, int maxAnswerId)
        {
            if (polls != null)
            {
                foreach (var poll in polls)
                {
                    foreach (var question in poll.Questions)
                    {
                        if (question.Id == 0) { question.Id = ++maxQuestionId; }
                        foreach (var answer in question.PossibleAnswers)
                        {
                            if (answer.Id == 0) { answer.Id = ++maxAnswerId; }
                        }
                    }
                }
            }
            return polls;
        }

        public static int MaxQuestionId(List<Poll> polls)
        {
            if (polls == null) throw new ArgumentNullException(nameof(polls));
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
            if (polls == null) throw new ArgumentNullException(nameof(polls));
            var result = int.MinValue;
            foreach (var poll in polls)
            {
                foreach (var question in poll.Questions)
                {
                    foreach (var answer in question.PossibleAnswers)
                    {
                        var id = answer.Id;
                        if (id > result) { result = id; }
                    }
                }
            }
            return result;
        }

    }
}