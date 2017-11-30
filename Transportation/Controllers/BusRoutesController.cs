using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Transportation.Data;
using Transportation.Models;
using static AutoMapper.Mapper;

namespace Transportation.Controllers
{
    [RoutePrefix("api/bus/{id}/routes")]
    public class BusRoutesController : ApiController
    {
        private readonly DataContext _db;

        public BusRoutesController(DataContext db)
        {
            _db = db;
        }

        [Route("")]
        public IEnumerable<RouteViewModel> GetRoutes(int id)
        {
            var dataRoutes = _db.Buses.Single(b => b.Id == id).Routes;

            return Map<IEnumerable<RouteViewModel>>(dataRoutes);
        }

        [Route("{routeId}")]
        public RouteViewModel GetRoute(int id, int routeId)
        {
            var dataRoute = _db.Buses.Single(b => b.Id == id).Routes.Single(r => r.Id == routeId);

            return Map<RouteViewModel>(dataRoute);
        }

        [Route("add/{routeId}")]
        [HttpPatch]
        public RouteViewModel AddRoute(int id, int routeId)
        {
            var route = _db.Routes.Single(r => r.Id == routeId);
            _db.Buses.Single(b => b.Id == id).Routes.Add(route);
            _db.SaveChanges();

            return Map<RouteViewModel>(route);
        }
        [HttpDelete]
        [Route("remove/{routeId}")]
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
