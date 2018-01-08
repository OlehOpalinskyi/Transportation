using System.Collections.Generic;
using Transportation.Models;

namespace Transportation.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<RouteViewModel> GetRoutes(int pointA, int pointB);
    }
}
