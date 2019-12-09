using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MainMVC.Models.Polls.Entities
{
    public class Poll : ICloneable
    {
        public Poll()
        {
            Id = 0;
            Name = "noName";
            Description = "empty";
            CreatorLogin = "noLogin";
            CreationDate = DateTime.Now;
            Questions = new List<Question>();
            QuestionsCount = Questions.Count;
        }

        public Poll(int id, string name, string description, string creatorLogin,
            DateTime creationDate, int questionsCount, IList<Question> questions)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatorLogin = creatorLogin;
            CreationDate = creationDate;
            QuestionsCount = questionsCount;
            Questions = questions;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string CreatorLogin { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        [Range(1, 100)]
        public int QuestionsCount { get; set; }

        public IList<Question> Questions { get; set; }

        public object Clone()
        {
            IList<Question> questionList = new List<Question>();
            foreach (var question in Questions)
            {
                questionList.Add((Question)question.Clone());
            }
            return new Poll(Id, Name, Description, CreatorLogin, CreationDate, QuestionsCount, questionList);
        }

        public void Update(Poll poll)
        {
            Id = poll.Id;
            Name = poll.Name;
            Description = poll.Description;
            CreatorLogin = poll.CreatorLogin;
            CreationDate = poll.CreationDate;
            QuestionsCount = poll.QuestionsCount;

            Questions.Clear();

            foreach (var ans in poll.Questions)
            {
                Questions.Add((Question)ans.Clone());
            }
        }
    }
}