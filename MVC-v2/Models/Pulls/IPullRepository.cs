using System.Collections.Generic;

namespace MVC_v2.Models.Pulls
{
    public interface IPullRepository
    {
        Pull GetPull(int id);
        IList<Pull> GePulls();
    }
}
