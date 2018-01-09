using System.Collections.Generic;
using System.Linq;
using Transportation.Data;
using Transportation.Interfaces;
using Transportation.Models;
using static AutoMapper.Mapper;

namespace Transportation.Services
{
    public class SearchService : ISearchService
    {
        private readonly DataContext _db;

        public SearchService(DataContext context)
        {
            _db = context;
        }
        public IEnumerable<RouteViewModel> GetRoutes(int pointA, int pointB)
        {
            var result = new List<RouteViewModel>();
            var routes = _db.Routes;
            foreach(var item in routes)
            {
                if (item.Cities.First().Id == pointA && item.Cities.Last().Id == pointB)
                {
                    result.Add(Map<RouteViewModel>(item));
                    continue;
                }
                    
                if(item.Cities.First().Id == pointA && item.Cities.Last().Id != pointB)
                {
                    if(item.Points.SingleOrDefault(p => p.CityId == pointB) != null)
                    {
                        result.Add(Map<RouteViewModel>(item));
                        continue;
                    }
                }

                if (item.Cities.First().Id != pointA && item.Cities.Last().Id == pointB)
                {
                    if (item.Points.SingleOrDefault(p => p.CityId == pointA) != null)
                    {
                        result.Add(Map<RouteViewModel>(item));
                        continue;
                    }
                }

                if (item.Cities.First().Id != pointA && item.Cities.Last().Id != pointB)
                {
                    var isPointA = item.Points.SingleOrDefault(p => p.CityId == pointA);
                    var isPointB = item.Points.SingleOrDefault(p => p.CityId == pointB);

                    if (isPointA != null && isPointB != null)
                        result.Add(Map<RouteViewModel>(item));
                }
            }

            return result;
        }
    }
}