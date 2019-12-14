using MainMVC.Models.Polls.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainMVC.Models.Polls
{
    public static class Data
    {
        public static List<Poll> GetData()
        {
            return new List<Poll>()
            {
                new Poll(){
                    Id = 1,
                    Name = "First Poll",
                    CreatorLogin = "Pavlik",
                    Description = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                    CreationDate = default,
                    Questions = new List<Question>(){
                        new Question(){
                            Id = 1,
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this justы fantasy?"){Id = 1 },
                                new Answer("I'm just a poor boy"){Id = 2 },
                                new Answer("I don't wanna die"){Id = 3 }
                            }
                        },
                        new Question(){
                            Id = 2,
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy?"){Id = 4 },
                                new Answer("I'm just a poor boy"){Id = 5 }
                            }
                        }
                    }
                },
                new Poll( ){
                    Id=2,
                    Name = "Second Poll",
                    CreatorLogin = "KoAmar",
                    Description = $"Miusov, as a man man of breeding and deilcacy, could not but feel some inwrd qualms, when he reached the Father Superior's with Ivan: he felt ashamed of havin lost his temper. He felt that he ought to have disdaimed that despicable wretch, Fyodor Pavlovitch, too much to have been upset by him in Father Zossima's cell, and so to have forgotten himself. Teh monks were not to blame, in any case, he reflceted, on the steps. And if they're decent people here (and the Father Superior, I understand, is a nobleman) why not be friendly and courteous withthem? I won't argue, I'll fall in with everything, I'll win them by politness, and show them that I've nothing to do with that Aesop, thta buffoon, that Pierrot, and have merely been takken in over this affair, just as they have.",
                    CreationDate = default,
                    Questions = new List<Question>(){
                        new Question(){
                            Id = 3,
                            Text = "Is this the real life?",
                            SoleAnswer = true,
                            PossibleAnswers = new List<Answer>()
                            {
                                new Answer("Is this just fantasy?"){Id = 6 },
                                new Answer("I'm just a poor boy"){Id = 7 },
                                new Answer("I don't wanna die"){Id = 8 },
                                new Answer("I don't wanna die"){Id = 9 }
                            }
                        }
                    },
                }
            };
        }
    }
}