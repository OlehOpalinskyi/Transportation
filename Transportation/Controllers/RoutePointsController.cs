using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Transportation.Interfaces;
using Transportation.Models;

namespace Transportation.Controllers
{
    [RoutePrefix("route/{id}/points")]
    public class RoutePointsController : ApiController
    {
        private readonly IRouteService _service;

        public RoutePointsController(IRouteService service)
        {
            _service = service;
        }

        [Route("")]
        [ResponseType(typeof(IEnumerable<PointViewModel>))]
        public IHttpActionResult GetPoints(int id)
        {
            return Ok(_service.GetPoints(id));
        }

        [Route("{pointId}")]
        [ResponseType(typeof(PointViewModel))]
        public IHttpActionResult GetPoint(int id, int pointId)
        {
            return Ok(_service.GetPoint(id, pointId));
        }

        [Route("")]
        [HttpPost]
        [ResponseType(typeof(RouteViewModel))]
        public IHttpActionResult AddPoints(int id, List<PointUpdateModel> points)
        {
            return Ok(_service.AddPoints(id, points));
        }

        [Route("{pointId}")]
        [HttpPatch]
        [ResponseType(typeof(PointViewModel))]
        public IHttpActionResult UpdatePoint(int id, int pointId, PointViewModel point)
        {
            return Ok(_service.UpdatePoint(id, pointId, point));
        }

        [Route("{pointId}")]
        [HttpDelete]
        public void DeletePoint(int id, int pointId)
        {
            _service.DeletePoint(id, pointId);
        }
    }
}
