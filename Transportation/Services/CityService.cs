using System.Collections.Generic;
using System.Linq;
using Transportation.Data;
using Transportation.Data.Models;
using Transportation.Interfaces;
using Transportation.Models;
using static AutoMapper.Mapper;

namespace Transportation.Services
{
    public class CityService : ICityService
    {
        private readonly DataContext _db;

        public CityService(DataContext context)
        {
            _db = context;
        }

        public IEnumerable<CityViewModel> GetCities()
        {
            var cities = _db.Cities;

            return Map<IEnumerable<CityViewModel>>(cities);
        }

        public CityViewModel GetCity(int id)
        {
            var dataCity = _db.Cities.Single(c => c.Id == id);

            return Map<CityViewModel>(dataCity);
        }

        public CityViewModel AddCity(CityViewModel city)
        {
            var dataCity = Map<CityDataModel>(city);
            dataCity.Name = char.ToUpper(city.Name.First()) + city.Name.Substring(1).ToLower();
            _db.Cities.Add(dataCity);
            _db.SaveChanges();

            return Map<CityViewModel>(dataCity);
        }

        public CityViewModel UpdateCity(int id, string name)
        {
            var dataCity = _db.Cities.Single(c => c.Id == id);

            dataCity.Name = char.ToUpper(name.First()) + name.Substring(1).ToLower(); ;
            _db.SaveChanges();

            return Map<CityViewModel>(dataCity);
        }

        public CityViewModel DeleteCity(int id)
        {
            var dataCity = _db.Cities.Single(c => c.Id == id);
            _db.Cities.Remove(dataCity);
            _db.SaveChanges();

            return Map<CityViewModel>(dataCity);
        }

    }
}