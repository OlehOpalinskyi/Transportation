using System.Collections.Generic;
using System.Web.Http;
using Transportation.Interfaces;
using Transportation.Models;

namespace Transportation.Controllers
{
    [RoutePrefix("route/{id}/buses")]
    public class RouteBusController : ApiController
    {
        private readonly IRouteService _service;

        public RouteBusController(IRouteService service)
        {
            _service = service;
        }

        [Route("")]
        public IEnumerable<BusViewModel> GetBuses(int id)
        {
            return _service.GetBuses(id);
        }

        [Route("subscribe/{busId}")]
        public BusViewModel AddBus(int id, int busId)
        {
            return _service.AddBus(id, busId);
        }

        [Route("unsubscribe/{busId}")]
        public IEnumerable<BusViewModel> RemoveBus(int id, int busId)
        {
            return _service.RemoveBus(id, busId);
        }
    }
}
