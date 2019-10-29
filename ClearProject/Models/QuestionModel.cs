using System.Collections.Generic;

namespace ClearProject.Models
{
    public class QuestionModel
    {
        public string Question { get; set; }
        public bool SoleAnswer { get; set; }
        public List<string> PossibleAnswers { get; set; }
    }
}