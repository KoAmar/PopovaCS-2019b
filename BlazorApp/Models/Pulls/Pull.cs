using System;
using System.Collections.Generic;

namespace BlazorApp.Models.Pulls
{
    public class Pull
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatorLogin { get; set; }
        public DateTime CreationDate { get; set; }

        public IList<Question> Questions { get; set; }
    }
}