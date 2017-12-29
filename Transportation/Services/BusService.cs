using System.Collections.Generic;
using System.Linq;
using Transportation.Data;
using Transportation.Data.Models;
using Transportation.Interfaces;
using Transportation.Models;
using static AutoMapper.Mapper;

namespace Transportation.Service
{
    public class BusService : IBusService
    {
        private readonly DataContext _db;

        public BusService(DataContext db)
        {
            _db = db;
        }

        public IEnumerable<BusViewModel> GetBuses()
        {
            var dataBuses = _db.Buses;

            return Map<IEnumerable<BusViewModel>>(dataBuses);
        }

        public BusViewModel GetBus(int id)
        {
            var dataBus = _db.Buses.Single(b => b.Id == id);

            return Map<BusViewModel>(dataBus);
        }

        public BusViewModel AddBus(BusViewModel bus)
        {
            var dataBus = Map<BusDataModel>(bus);

            _db.Buses.Add(dataBus);
            _db.SaveChanges();

            return Map<BusViewModel>(dataBus);
        }

        public BusViewModel EditBus(int id, BusViewModel bus)
        {
            var originBus = _db.Buses.Single(b => b.Id == id);
            bus.Id = id;

            _db.Entry(originBus).CurrentValues.SetValues(bus);
            _db.SaveChanges();

            return Map<BusViewModel>(originBus);
        }

        public BusViewModel DeleteBus(int id)
        {
            var bus = _db.Buses.Single(b => b.Id == id);

            _db.Buses.Remove(bus);
            _db.SaveChanges();

            return Map<BusViewModel>(bus);
        }

        public IEnumerable<RouteViewModel> GetRoutes(int id)
        {
            var dataRoutes = _db.Buses.Single(b => b.Id == id).Routes;

            return Map<IEnumerable<RouteViewModel>>(dataRoutes);
        }

        public RouteViewModel GetRoute(int id, int routeId)
        {
            var dataRoute = _db.Buses.Single(b => b.Id == id).Routes.Single(r => r.Id == routeId);

            return Map<RouteViewModel>(dataRoute);
        }

        public RouteViewModel AddRoute(int id, int routeId)
        {
            var route = _db.Routes.Single(r => r.Id == routeId);
            _db.Buses.Single(b => b.Id == id).Routes.Add(route);
            _db.SaveChanges();

            return Map<RouteViewModel>(route);
        }

        public RouteViewModel RemoveRoute(int id, int routeId)
        {
            var bus = _db.Buses.Single(b => b.Id == id);
            var route = bus.Routes.Single(r => r.Id == routeId);
            bus.Routes.Remove(route);
            _db.SaveChanges();

            return Map<RouteViewModel>(route);
        }
    }
}