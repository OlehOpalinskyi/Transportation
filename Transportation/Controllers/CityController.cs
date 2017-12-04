using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Transportation.Data;
using Transportation.Data.Models;
using Transportation.Models;
using static AutoMapper.Mapper;

namespace Transportation.Controllers
{
    [RoutePrefix("api/cities")]
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
            dataCity.Name = char.ToUpper(city.Name.First()) + city.Name.Substring(1).ToLower();
            _db.Cities.Add(dataCity);
            _db.SaveChanges();

            return Map<CityViewModel>(dataCity);
        }

        [HttpPut]
        [Route("{id}/{name}")]
        public CityViewModel UpdateCity(int id, string name)
        {
            var dataCity = _db.Cities.Single(c => c.Id == id);

            dataCity.Name = char.ToUpper(name.First()) + name.Substring(1).ToLower(); ;
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
