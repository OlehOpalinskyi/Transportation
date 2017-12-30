using System.Collections.Generic;
using System.Web.Http;
using Transportation.Interfaces;
using Transportation.Models;

namespace Transportation.Controllers
{
    [RoutePrefix("api/cities")]
    public class CityController : ApiController
    {
        private readonly ICityService _service;

        public CityController(ICityService service)
        {
            _service = service;
        }

        [Route("")]
        public IEnumerable<CityViewModel> GetCities()
        {
            return _service.GetCities();
        }

        [Route("{id}")]
        public CityViewModel GetCity(int id)
        {
            return _service.GetCity(id);
        }

        [HttpPost]
        [Route("")]
        public CityViewModel AddCity(CityViewModel city)
        {
            return _service.AddCity(city);
        }

        [HttpPut]
        [Route("{id}/{name}")]
        public CityViewModel UpdateCity(int id, string name)
        {
            return _service.UpdateCity(id, name);
        }

        [HttpDelete]
        [Route("{id}")]
        public CityViewModel DeleteCity(int id)
        {
            return _service.DeleteCity(id);
        }
    }
}
