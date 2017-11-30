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
    [RoutePrefix("api/routes")]
    public class RouteController : ApiController
    {
        private readonly DataContext _db;

        public RouteController(DataContext db)
        {
            _db = db;
        }

        [Route("")]
        public IEnumerable<RouteViewModel> GetRoutes()
        {
            var dataRoutes = _db.Routes;

            return Map<IEnumerable<RouteViewModel>>(dataRoutes);
        }

        [Route("{id}")]
        public RouteViewModel GetRoute(int id)
        {
            var dataRoute = _db.Routes.Single(r => r.Id == id);

            return Map<RouteViewModel>(dataRoute);
        }

        [HttpPost]
        [Route("")]
        public RouteViewModel AddRoute(UpdateRouteModel route)
        {
            var dataRoute = CreateRoute(route);
            _db.Routes.Add(dataRoute);
            _db.SaveChanges();

            return Map<RouteViewModel>(dataRoute);
        }

        [HttpPatch]
        [Route("{id}")]
        public RouteViewModel UpdateRoute(int id, UpdateRouteModel route)
        {
            var dataRoute = CreateRoute(route);
            dataRoute.Id = id;
            var originRoute = _db.Routes.Single(r => r.Id == id);
            originRoute.Price = dataRoute.Price;
            originRoute.Cities.Clear();
            originRoute.Cities = dataRoute.Cities;
            _db.SaveChanges();
            return Map<RouteViewModel>(dataRoute);
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteRoute(int id)
        {
            var route = _db.Routes.Single(r => r.Id == id);
            _db.Routes.Remove(route);
            _db.SaveChanges();

         ///   return Map<RouteViewModel>(route);
        }

        private RouteDataModel CreateRoute(UpdateRouteModel route)
        {
            var dataRoute = Map<RouteDataModel>(route);

            var cityIdA = Convert.ToInt32(route.PointA);
            var cityIdB = Convert.ToInt32(route.PointB);
            var pointA = _db.Cities.Single(c => c.Id == cityIdA);
            var pointB = _db.Cities.Single(c => c.Id == cityIdB);
            dataRoute.Cities.Add(pointA);
            dataRoute.Cities.Add(pointB);

            return dataRoute;
        }
    }
}
