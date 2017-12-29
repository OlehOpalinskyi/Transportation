using System.Collections.Generic;
using Transportation.Models;

namespace Transportation.Interfaces
{
    public interface IBusService
    {
        IEnumerable<BusViewModel> GetBuses();
        BusViewModel GetBus(int id);
        BusViewModel AddBus(BusViewModel bus);
        BusViewModel EditBus(int id, BusViewModel bus);
        BusViewModel DeleteBus(int id);
        IEnumerable<RouteViewModel> GetRoutes(int id);
        RouteViewModel GetRoute(int id, int routeId);
        RouteViewModel AddRoute(int id, int routeId);
        RouteViewModel RemoveRoute(int id, int routeId);
    }
}
