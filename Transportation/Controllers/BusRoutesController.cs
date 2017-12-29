using System.Collections.Generic;
using System.Web.Http;
using Transportation.Interfaces;
using Transportation.Models;

namespace Transportation.Controllers
{
    [RoutePrefix("api/bus/{id}/routes")]
    public class BusRoutesController : ApiController
    {
        private readonly IBusService _service;

        public BusRoutesController(IBusService service)
        {
            _service = service;
        }

        [Route("")]
        public IEnumerable<RouteViewModel> GetRoutes(int id)
        {
            return _service.GetRoutes(id);
        }

        [Route("{routeId}")]
        public RouteViewModel GetRoute(int id, int routeId)
        {
            return _service.GetRoute(id, routeId);
        }

        [Route("add/{routeId}")]
        [HttpPatch]
        public RouteViewModel AddRoute(int id, int routeId)
        {
            return _service.AddRoute(id, routeId);
        }

        [HttpDelete]
        [Route("remove/{routeId}")]
        public RouteViewModel RemoveRoute(int id, int routeId)
        {
            return _service.RemoveRoute(id, routeId);
        }
    }
}
