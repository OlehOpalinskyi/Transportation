using System.Collections.Generic;
using System.Web.Http;
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
        public IEnumerable<BusViewModel> GetBuses()
        {
            return busService.GetBuses();
        }

        [Route("{id}")]
        public BusViewModel GetBus(int id)
        {
            return busService.GetBus(id);
        }

        [HttpPost]
        [Route("")]
        public BusViewModel AddBus(BusViewModel bus)
        {
            return busService.AddBus(bus);
        }
        [HttpPut]
        [Route("{id}")]
        public BusViewModel EditBus(int id, BusViewModel bus)
        {
            return busService.EditBus(id, bus);
        }

        [HttpDelete]
        [Route("{id}")]
        public BusViewModel DeleteBus(int id)
        {
            return busService.DeleteBus(id);
        }
    }
}
