using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainMVC.Models.Polls
{
    public class SQL_PollRerository : IPollRepository
    {
        private readonly AppDbContext context;

        public SQL_PollRerository(AppDbContext context)
        {
            this.context = context;
        }

        public Poll Add(Poll poll)
        {
            context.Polls.Add(poll);
            context.SaveChanges();
            return poll;
        }

        public Poll Delete(int Id)
        {
            Poll poll = context.Polls.Find(Id);
            if (poll != null)
            {
                context.Polls.Remove(poll);
                context.SaveChanges();
            }
            return poll;
        }

        public IEnumerable<Poll> GetPolls()
        {
            return context.Polls;
        }

        public Poll GetPoll(int Id)
        {
            return context.Polls.Find(Id);
        }

        public Poll Update(Poll pollChanges)
        {
            var poll = context.Polls.Attach(pollChanges);
            poll.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return pollChanges;
        }

        public Question GetQuestion(int Id)
        {
            throw new NotImplementedException();
        }

        public Question UpdateQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public Answer GetAnswer(int Id)
        {
            throw new NotImplementedException();
        }

        public Answer UpdateAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
