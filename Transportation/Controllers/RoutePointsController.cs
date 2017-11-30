using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Transportation.Data;
using Transportation.Data.Models;
using Transportation.Models;
using static AutoMapper.Mapper;

namespace Transportation.Controllers
{
    [RoutePrefix("route/{id}/points")]
    public class RoutePointsController : ApiController
    {
        private readonly DataContext _db;

        public RoutePointsController(DataContext db)
        {
            _db = db;
        }

        [Route("")]
        public IEnumerable<PointViewModel> GetPoints(int id)
        {
            var dataPoints = _db.Routes.Single(r => r.Id == id).Points;

            return Map<IEnumerable<PointViewModel>>(dataPoints);
        }

        [Route("{pointId}")]
        public PointViewModel GetPoint(int id, int pointId)
        {
            var dataPoint = _db.Routes.Single(r => r.Id == id).Points.Single(p => p.Id == pointId);

            return Map<PointViewModel>(dataPoint);
        }

        [Route("")]
        [HttpPost]
        public RouteViewModel AddPoints(int id, List<PointViewModel> points)
        {
            var route = _db.Routes.Single(r => r.Id == id);
            var dataPoints = Map<IEnumerable<PointDataModel>>(points);
            foreach (var item in dataPoints)
            {
                var city = _db.Cities.Single(c => c.Id == item.CityId);
                item.City = city;
                route.Points.Add(item);
            }
            _db.SaveChanges();

            return Map<RouteViewModel>(route);
        }

        [Route("{pointId}")]
        [HttpPatch]
        public PointViewModel UpdatePoint(int id, int pointId, PointViewModel point)
        {
            var dataPoint = _db.Points.Single(p => p.Id == pointId);
            dataPoint.Price = point.Price;
            dataPoint.ArrivalTime = point.ArrivalTime;
            _db.SaveChanges();

            return Map<PointViewModel>(dataPoint);
        }

        [Route("{pointId}")]
        [HttpDelete]
        public void DeletePoint(int id, int pointId)
        {
            var point = _db.Points.Single(p => p.Id == pointId);
            _db.Points.Remove(point);
            _db.SaveChanges();
        }
    }
}
