using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Transportation.Interfaces;
using Transportation.Models;

namespace Transportation.Controllers
{
    [RoutePrefix("api/buses")]
    public class BusController : ApiController
    {
        private readonly IBusService busService;

        public BusController(IBusService service)
        {
            busService = service;
        }

        [Route("")]
        [ResponseType(typeof(IEnumerable<BusViewModel>))]
        public IHttpActionResult GetBuses()
        {
            return Ok(busService.GetBuses());
        }

        [Route("{id}")]
        [ResponseType(typeof(BusViewModel))]
        public IHttpActionResult GetBus(int id)
        {
            return Ok(busService.GetBus(id));
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(BusViewModel))]
        public IHttpActionResult AddBus(BusViewModel bus)
        {
            return Ok(busService.AddBus(bus));
        }

        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(BusViewModel))]
        public IHttpActionResult EditBus(int id, BusViewModel bus)
        {
            return Ok(busService.EditBus(id, bus));
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(BusViewModel))]
        public IHttpActionResult DeleteBus(int id)
        {
            return Ok(busService.DeleteBus(id));
        }
    }
}
