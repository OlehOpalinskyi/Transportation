using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
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
        [ResponseType(typeof(IEnumerable<CityViewModel>))]
        public IHttpActionResult GetCities()
        {
            return Ok(_service.GetCities());
        }

        [Route("{id}")]
        [ResponseType(typeof(CityViewModel))]
        public IHttpActionResult GetCity(int id)
        {
            return Ok(_service.GetCity(id));
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(CityViewModel))]
        public IHttpActionResult AddCity(CityViewModel city)
        {
            return Ok(_service.AddCity(city));
        }

        [HttpPut]
        [Route("{id}/{name}")]
        [ResponseType(typeof(CityViewModel))]
        public IHttpActionResult UpdateCity(int id, string name)
        {
            return Ok(_service.UpdateCity(id, name));
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(CityViewModel))]
        public IHttpActionResult DeleteCity(int id)
        {
            return Ok(_service.DeleteCity(id));
        }
    }
}
