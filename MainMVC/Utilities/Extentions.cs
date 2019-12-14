using MainMVC.Models.Polls.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

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

        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            tempData.TryGetValue(key, out var o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }
    }
}