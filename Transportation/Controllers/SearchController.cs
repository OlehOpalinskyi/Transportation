using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Transportation.Interfaces;
using Transportation.Models;

namespace Transportation.Controllers
{
    public class SearchController : ApiController
    {
        private readonly ISearchService _service;

        public SearchController(ISearchService service)
        {
            _service = service;
        }

        [Route("api/search/pointA/pointB")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<RouteViewModel>))]
        public IHttpActionResult GetRoutes(int pointA, int pointB)
        {
            return Ok(_service.GetRoutes(pointA, pointB));
        }
    }
}
