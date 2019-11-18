using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.Polls
{
    public class Poll
    {
        public Poll()
        {
            Id = 0;
            Name = "";
            CreatorLogin = "";
            CreationDate = DateTime.Now;
            Questions = new List<Question>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatorLogin { get; set; }
        public DateTime CreationDate { get; set; }

        public IList<Question> Questions { get; set; }
    }
}