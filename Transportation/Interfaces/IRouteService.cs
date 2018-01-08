using System.Collections.Generic;
using Transportation.Models;

namespace Transportation.Interfaces
{
    public interface IRouteService
    {
        IEnumerable<RouteViewModel> GetRoutes();
        RouteViewModel GetRoute(int id);
        RouteViewModel AddRoute(UpdateRouteModel route);
        RouteViewModel UpdateRoute(int id, UpdateRouteModel route);
        void DeleteRoute(int id);
        IEnumerable<BusViewModel> GetBuses(int id);
        BusViewModel AddBus(int id, int busId);
        IEnumerable<BusViewModel> RemoveBus(int id, int busId);
        IEnumerable<PointViewModel> GetPoints(int id);
        PointViewModel GetPoint(int id, int pointId);
        RouteViewModel AddPoints(int id, List<PointViewModel> points);
        PointViewModel UpdatePoint(int id, int pointId, PointViewModel point);
        void DeletePoint(int id, int pointId);
        IEnumerable<TimeTableViewModel> GetCalendar(int id);
    }
}
