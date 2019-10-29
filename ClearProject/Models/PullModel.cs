using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearProject.Models
{
    public class PullModel
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<QuestionModel> Enrollments { get; set; }
    }
}
