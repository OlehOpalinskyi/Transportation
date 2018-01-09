using System.Collections.Generic;
using System.Web.Http;
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
        public IEnumerable<RouteViewModel> GetRoutes(int pointA, int pointB)
        {
            return _service.GetRoutes(pointA, pointB);
        }
    }
}
