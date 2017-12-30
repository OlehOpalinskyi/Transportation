using System.Collections.Generic;
using Transportation.Models;

namespace Transportation.Interfaces
{
    public interface ICityService
    {
        IEnumerable<CityViewModel> GetCities();
        CityViewModel GetCity(int id);
        CityViewModel AddCity(CityViewModel city);
        CityViewModel UpdateCity(int id, string name);
        CityViewModel DeleteCity(int id);
    }
}
