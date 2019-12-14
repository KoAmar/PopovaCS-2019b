using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        }

        public Poll(int id, string name, string description, string creatorLogin,
            DateTime creationDate, IList<Question> questions)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatorLogin = creatorLogin;
            CreationDate = creationDate;
            Questions = questions;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string CreatorLogin { get; set; }

        public DateTime CreationDate { get; set; }

        public IList<Question> Questions { get; set; }

        public object Clone()
        {
            IList<Question> questionList = Questions.Select(question => (Question) question.Clone()).ToList();
            return new Poll(Id, Name, Description, CreatorLogin, CreationDate, questionList);
        }

        public void Update(Poll poll)
        {
            Id = poll.Id;
            Name = poll.Name;
            Description = poll.Description;
            CreatorLogin = poll.CreatorLogin;
            CreationDate = poll.CreationDate;

            Questions = new List<Question>(poll.Questions.Count);

            foreach (var question in poll.Questions)
            {
                Questions.Add((Question)question.Clone());
            }
        }
    }
}