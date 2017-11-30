using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Transportation.Data;
using Transportation.Data.Models;
using Transportation.Models;
using static AutoMapper.Mapper;

namespace Transportation.Controllers
{
    [RoutePrefix("api/buses")]
    public class BusController : ApiController
    {
        private readonly DataContext _db;

        public BusController(DataContext db)
        {
            _db = db;
        }

        [Route("")]
        public IEnumerable<BusViewModel> GetBuses()
        {
            var dataBuses = _db.Buses;

            return Map<IEnumerable<BusViewModel>>(dataBuses);
        }

        [Route("{id}")]
        public BusViewModel GetBus(int id)
        {
            var dataBus = _db.Buses.Single(b => b.Id == id);

            return Map<BusViewModel>(dataBus);
        }

        [HttpPost]
        [Route("")]
        public BusViewModel AddBus(BusViewModel bus)
        {
            var dataBus = Map<BusDataModel>(bus);

            _db.Buses.Add(dataBus);
            _db.SaveChanges();

            return Map<BusViewModel>(dataBus);
        }
        [HttpPut]
        [Route("{id}")]
        public BusViewModel EditBus(int id, BusViewModel bus)
        {
            var originBus = _db.Buses.Single(b => b.Id == id);
            bus.Id = id;

            _db.Entry(originBus).CurrentValues.SetValues(bus);
            _db.SaveChanges();

            return Map<BusViewModel>(originBus);
        }

        [HttpDelete]
        [Route("{id}")]
        public BusViewModel DeleteBus(int id)
        {
            var bus = _db.Buses.Single(b => b.Id == id);

            _db.Buses.Remove(bus);
            _db.SaveChanges();

            return Map<BusViewModel>(bus);
        }
    }
}
