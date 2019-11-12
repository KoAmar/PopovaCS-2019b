using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.Polls
{
    public class Poll
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a name")]
        public string CreatorLogin { get; set; }
        public DateTime CreationDate { get; set; }

        public IList<Question> Questions { get; set; }
    }
}