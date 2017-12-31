using System.Collections.Generic;
using System.Web.Http;
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
        public IEnumerable<RouteViewModel> GetRoutes()
        {
            return _service.GetRoutes();
        }

        [Route("{id}")]
        public RouteViewModel GetRoute(int id)
        {
            return _service.GetRoute(id);
        }

        [HttpPost]
        [Route("")]
        public RouteViewModel AddRoute(UpdateRouteModel route)
        {
            return _service.AddRoute(route);
        }

        [HttpPatch]
        [Route("{id}")]
        public RouteViewModel UpdateRoute(int id, UpdateRouteModel route)
        {
            return _service.UpdateRoute(id, route);
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteRoute(int id)
        {
            _service.DeleteRoute(id);
        }

    }
}
