using System.Collections.Generic;
using BlazorApp.Models.Pulls;

namespace BlazorApp.Data
{
    public interface IPullRepository
    {
        Pull GetPull(int id);
        //IList<Pull> GetPulls();
        Pull Add(Pull pull);
    }
}
