﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MainMVC.Models.Polls.Entities
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
            foreach (var ans in PossibleAnswers)
            {
                possibleAnswers.Add((Answer)ans.Clone());
            }
            return new Question(Id, Text, SoleAnswer, AnswersCount, possibleAnswers);
        }

        public void Update(Question question)
        {
            Id = question.Id;
            Text = question.Text;
            SoleAnswer = question.SoleAnswer;

            PossibleAnswers.Clear();

            foreach (var ans in question.PossibleAnswers)
            {
                PossibleAnswers.Add((Answer)ans.Clone());
            }
            AnswersCount = 0;
        }
    }
}