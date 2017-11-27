using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Transportation.Data;
using Transportation.Data.Models;
using Transportation.Models;
using static AutoMapper.Mapper;

namespace Transportation.Controllers
{
    [RoutePrefix("cities")]
    public class CityController : ApiController
    {
        private readonly DataContext _db;

        public CityController(DataContext db)
        {
            _db = db;
        }

        [Route("")]
        public IEnumerable<CityViewModel> GetCities()
        {
            var cities = _db.Cities;

            return Map<IEnumerable<CityViewModel>>(cities);
        }

        [Route("{id}")]
        public CityViewModel GetCity(int id)
        {
            var dataCity = _db.Cities.Single(c => c.Id == id);

            return Map<CityViewModel>(dataCity);
        }

        [HttpPost]
        [Route("")]
        public CityViewModel AddCity(CityViewModel city)
        {
            var dataCity = Map<CityDataModel>(city);
            _db.Cities.Add(dataCity);
            _db.SaveChanges();

            return Map<CityViewModel>(dataCity);
        }

        [HttpPut]
        [Route("{id}/{name}")]
        public CityViewModel UpdateCity(int id, string name)
        {
            var dataCity = _db.Cities.Single(c => c.Id == id);

            dataCity.Name = name;
            _db.SaveChanges();

            return Map<CityViewModel>(dataCity);
        }

        [HttpDelete]
        [Route("{id}")]
        public CityViewModel DeleteCity(int id)
        {
            var dataCity = _db.Cities.Single(c => c.Id == id);
            _db.Cities.Remove(dataCity);
            _db.SaveChanges();

            return Map<CityViewModel>(dataCity);
        }
    }
}
