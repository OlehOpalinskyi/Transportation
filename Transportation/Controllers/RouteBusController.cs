using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Transportation.Data;
using Transportation.Models;
using static AutoMapper.Mapper;

namespace Transportation.Controllers
{
    [RoutePrefix("route/{id}/buses")]
    public class RouteBusController : ApiController
    {
        private readonly DataContext _db;

        public RouteBusController(DataContext db)
        {
            _db = db;
        }

        [Route("")]
        public IEnumerable<BusViewModel> GetBuses(int id)
        {
            var dataBuses = _db.Routes.Single(r => r.Id == id).Buses;

            return Map<IEnumerable<BusViewModel>>(dataBuses);
        }

        [Route("subscribe/{busId}")]
        public BusViewModel AddBus(int id, int busId)
        {
            var bus = _db.Buses.Single(b => b.Id == busId);

            _db.Routes.Single(r => r.Id == id).Buses.Add(bus);

            return Map<BusViewModel>(bus);
        }

        [Route("unsubscribe/{busId}")]
        public IEnumerable<BusViewModel> RemoveBus(int id, int busId)
        {
            var bus = _db.Buses.Single(b => b.Id == busId);

            _db.Routes.Single(r => r.Id == id).Buses.Remove(bus);

            return Map<IEnumerable<BusViewModel>>(bus);
        }
    }
}
