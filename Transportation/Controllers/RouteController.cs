using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Transportation.Interfaces;
using Transportation.Models;

namespace Transportation.Controllers
{
    [RoutePrefix("api/routes")]
    public class RouteController : ApiController
    {
        private readonly IRouteService _service;

        public RouteController(IRouteService service)
        {
            _service = service;
        }

        [Route("")]
        [ResponseType(typeof(IEnumerable<RouteViewModel>))]
        public IHttpActionResult GetRoutes()
        {
            return Ok(_service.GetRoutes());
        }

        [Route("{id}")]
        [ResponseType(typeof(RouteViewModel))]
        public IHttpActionResult GetRoute(int id)
        {
            return Ok(_service.GetRoute(id));
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(RouteViewModel))]
        public IHttpActionResult AddRoute(UpdateRouteModel route)
        {
            return Ok(_service.AddRoute(route));
        }

        [HttpPatch]
        [Route("{id}")]
        [ResponseType(typeof(RouteViewModel))]
        public IHttpActionResult UpdateRoute(int id, UpdateRouteModel route)
        {
            return Ok(_service.UpdateRoute(id, route));
        }

        [Route("{id}/calendar")]
        public IEnumerable<TimeTableViewModel> GetCalendar(int id)
        {
            return _service.GetCalendar(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteRoute(int id)
        {
            _service.DeleteRoute(id);
        }

    }
}
