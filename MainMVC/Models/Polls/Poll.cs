using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MainMVC.Models.Polls
{
    public class Poll
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

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string CreatorLogin { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Required]
        public int QuestionsCount { get; set; }
        public IList<Question> Questions { get; set; }
    }
}