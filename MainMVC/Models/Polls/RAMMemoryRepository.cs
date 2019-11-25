using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainMVC.Models.Polls
{
    public class RAMMemoryRepository : IPollRepository
    {
        private readonly List<Poll> _polls;

        public RAMMemoryRepository()
        {
            _polls = new List<Poll>()
            {
                new Poll{
                    Id = 1,
                    Name = "First Poll",
                    CreatorLogin = "Pavlik",
                    Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                    CreationDate = default,
                    Questions = new List<Question>(){
                        new Question{
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy?"),
                                new Answer("I'm just a poor boy"),
                                new Answer("I don't wanna die")
                            }
                        },
                        new Question{
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy?"),
                                new Answer("Is this just fantasy?"),
                                new Answer("I don't wanna die")
                            }
                        },
                        new Question{
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer("I'm just a poor boy"),
                                new Answer("I'm just a poor boy"),
                                new Answer("I'm just a poor boy"),
                                new Answer("I'm just a poor boy"),
                                new Answer("I'm just a poor boy")
                            }
                        },
                        new Question(),
                        new Question()
                    },
                    QuestionsCount = 5
                },
                new Poll(){
                    Id = 2,
                    Name = "Second Poll",
                    CreatorLogin = "KoAmar",
                    Description = $"Miusov, as a man man of breeding and deilcacy, could not but feel some inwrd qualms, when he reached the Father Superior's with Ivan: he felt ashamed of havin lost his temper. He felt that he ought to have disdaimed that despicable wretch, Fyodor Pavlovitch, too much to have been upset by him in Father Zossima's cell, and so to have forgotten himself. Teh monks were not to blame, in any case, he reflceted, on the steps. And if they're decent people here (and the Father Superior, I understand, is a nobleman) why not be friendly and courteous withthem? I won't argue, I'll fall in with everything, I'll win them by politness, and show them that I've nothing to do with that Aesop, thta buffoon, that Pierrot, and have merely been takken in over this affair, just as they have.",
                    CreationDate = default,
                    Questions = new List<Question>(){
                        new Question{
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy?"),
                                new Answer("Is this just fantasy?"),
                                new Answer("I don't wanna die")
                            }
                        },
                        new Question{
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy?"),
                                new Answer("Is this just fantasy?"),
                                new Answer("I don't wanna die")
                            }
                        },
                        new Question{
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy?"),
                                new Answer("Is this just fantasy?"),
                                new Answer("I don't wanna die")
                            }
                        }
                    },
                    QuestionsCount = 3
                }
            };
        }

        public Poll GetPoll(int id)
        {
            return _polls[id-1];
        }

        public IEnumerable<Poll> GetPolls()
        {
            return _polls;
        }

        public Poll Add(Poll pull)
        {
            pull.Id = _polls.Max(e => e.Id) + 1;
            _polls.Add(pull);
            return pull;
        }

        public Poll Update(Poll employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }

        public Poll Delete(int Id)
        {
            Poll employee = _polls.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                _polls.Remove(employee);
            }
            return employee;
            ;
        }
    }
}
