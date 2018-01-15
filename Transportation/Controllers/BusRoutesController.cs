using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
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
        [ResponseType(typeof(IEnumerable<RouteViewModel>))]
        public IHttpActionResult GetRoutes(int id)
        {
            return Ok(_service.GetRoutes(id));
        }

        [Route("{routeId}")]
        [ResponseType(typeof(RouteViewModel))]
        public IHttpActionResult GetRoute(int id, int routeId)
        {
            return Ok(_service.GetRoute(id, routeId));
        }

        [Route("add/{routeId}")]
        [HttpPatch]
        [ResponseType(typeof(RouteViewModel))]
        public IHttpActionResult AddRoute(int id, int routeId)
        {
            return Ok(_service.AddRoute(id, routeId));
        }

        [HttpDelete]
        [Route("remove/{routeId}")]
        [ResponseType(typeof(RouteViewModel))]
        public IHttpActionResult RemoveRoute(int id, int routeId)
        {
            return Ok(_service.RemoveRoute(id, routeId));
        }
    }
}
