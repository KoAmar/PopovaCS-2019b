﻿using System.Collections.Generic;
using BlazorApp.Models.Polls;

namespace BlazorApp.Data.Polls
{
    public interface IPollRepository
    {
        IList<Poll> GetPolls();
        Poll GetPoll(int id);
        Poll Add(Poll pull);
    }
}