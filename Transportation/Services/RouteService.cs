using System;
using System.Collections.Generic;
using System.Linq;
using Transportation.Data;
using Transportation.Data.Models;
using Transportation.Interfaces;
using Transportation.Models;
using static AutoMapper.Mapper;

namespace Transportation.Services
{
    public class RouteService : IRouteService
    {
        private readonly DataContext _db;

        public RouteService(DataContext context)
        {
            _db = context;
        }
        public RouteViewModel AddRoute(UpdateRouteModel route)
        {
            var dataRoute = Map<RouteDataModel>(route);
            _db.Routes.Add(dataRoute);
            _db.SaveChanges();

            return Map<RouteViewModel>(dataRoute);
        }

        public void DeleteRoute(int id)
        {
            var route = _db.Routes.Single(r => r.Id == id);
            _db.Routes.Remove(route);
            _db.SaveChanges();
        }

        public RouteViewModel GetRoute(int id)
        {
            var dataRoute = _db.Routes.Single(r => r.Id == id);

            return Map<RouteViewModel>(dataRoute);
        }

        public IEnumerable<RouteViewModel> GetRoutes()
        {
            var dataRoutes = _db.Routes;

            return Map<IEnumerable<RouteViewModel>>(dataRoutes);
        }

        public RouteViewModel UpdateRoute(int id, UpdateRouteModel route)
        {
            var originRoute = _db.Routes.Single(r => r.Id == id);
            originRoute.Price = route.Price;
            originRoute.RouteName = route.RouteName;
            _db.SaveChanges();
            return Map<RouteViewModel>(originRoute);
        }

        public IEnumerable<BusViewModel> GetBuses(int id)
        {
            var dataBuses = _db.Routes.Single(r => r.Id == id).Buses;

            return Map<IEnumerable<BusViewModel>>(dataBuses);
        }

        public BusViewModel AddBus(int id, int busId)
        {
            var bus = _db.Buses.Single(b => b.Id == busId);

            _db.Routes.Single(r => r.Id == id).Buses.Add(bus);

            return Map<BusViewModel>(bus);
        }

        public IEnumerable<BusViewModel> RemoveBus(int id, int busId)
        {
            var bus = _db.Buses.Single(b => b.Id == busId);

            _db.Routes.Single(r => r.Id == id).Buses.Remove(bus);

            return Map<IEnumerable<BusViewModel>>(bus);
        }

        public IEnumerable<PointViewModel> GetPoints(int id)
        {
            var dataPoints = _db.Routes.Single(r => r.Id == id).Points;

            return Map<IEnumerable<PointViewModel>>(dataPoints);
        }

        public PointViewModel GetPoint(int id, int pointId)
        {
            var dataPoint = _db.Routes.Single(r => r.Id == id).Points.Single(p => p.Id == pointId);

            return Map<PointViewModel>(dataPoint);
        }

        public RouteViewModel AddPoints(int id, List<PointUpdateModel> points)
        {
            var route = _db.Routes.Single(r => r.Id == id);
            var dataPoints = Map<IEnumerable<PointDataModel>>(points);
            foreach (var item in dataPoints)
            {
                var city = _db.Cities.Single(c => c.Id == item.CityId);
                item.City = city;
                item.RouteId = id;
                item.Route = route;
                route.Points.Add(item);
            }
            _db.SaveChanges();

            return Map<RouteViewModel>(route);
        }

        public PointViewModel UpdatePoint(int id, int pointId, PointViewModel point)
        {
            var dataPoint = _db.Points.Single(p => p.Id == pointId);
            dataPoint.Price = point.Price;
            dataPoint.ArrivalTime = point.ArrivalTime;
            _db.SaveChanges();

            return Map<PointViewModel>(dataPoint);
        }

        public void DeletePoint(int id, int pointId)
        {
            var point = _db.Points.Single(p => p.Id == pointId);
            _db.Points.Remove(point);
            _db.SaveChanges();
        }

        public IEnumerable<TimeTableViewModel> GetCalendar(int id)
        {
            var calendar = _db.TimeTable.Where(c => c.RouteId == id);

            return Map<IEnumerable<TimeTableViewModel>>(calendar);
        }
    }
}