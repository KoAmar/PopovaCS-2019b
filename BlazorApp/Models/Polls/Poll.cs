using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.Polls
{
    public class Poll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatorLogin { get; set; }
        public DateTime CreationDate { get; set; }

        public IList<Question> Questions { get; set; }
    }
}