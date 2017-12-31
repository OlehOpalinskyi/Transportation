using System.Collections.Generic;
using System.Web.Http;
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
        public IEnumerable<PointViewModel> GetPoints(int id)
        {
            return _service.GetPoints(id);
        }

        [Route("{pointId}")]
        public PointViewModel GetPoint(int id, int pointId)
        {
            return _service.GetPoint(id, pointId);
        }

        [Route("")]
        [HttpPost]
        public RouteViewModel AddPoints(int id, List<PointViewModel> points)
        {
            return _service.AddPoints(id, points);
        }

        [Route("{pointId}")]
        [HttpPatch]
        public PointViewModel UpdatePoint(int id, int pointId, PointViewModel point)
        {
            return _service.UpdatePoint(id, pointId, point);
        }

        [Route("{pointId}")]
        [HttpDelete]
        public void DeletePoint(int id, int pointId)
        {
            _service.DeletePoint(id, pointId);
        }
    }
}
