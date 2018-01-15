using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
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
        [ResponseType(typeof(IEnumerable<BusViewModel>))]
        public IHttpActionResult GetBuses(int id)
        {
            return Ok(_service.GetBuses(id));
        }

        [Route("subscribe/{busId}")]
        [ResponseType(typeof(BusViewModel))]
        public IHttpActionResult AddBus(int id, int busId)
        {
            return Ok(_service.AddBus(id, busId));
        }

        [Route("unsubscribe/{busId}")]
        [ResponseType(typeof(IEnumerable<BusViewModel>))]
        public IHttpActionResult RemoveBus(int id, int busId)
        {
            return Ok(_service.RemoveBus(id, busId));
        }
    }
}
