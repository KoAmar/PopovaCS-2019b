using BlazorApp.Models.Pulls;
using System.Collections.Generic;

namespace BlazorApp.Models.Pulls
{
    public interface IPullRepository
    {
        Pull GetPull(int id);
        IList<Pull> GetPulls();
        Pull Add(Pull pull);
    }
}
