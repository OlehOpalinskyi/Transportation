using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transportation.Models
{
    public class PointViewModel
    {
        public int Id { get; set; }
        public string Point { get; set; }
        public double Price { get; set; }
        public TimeSpan ArrivalTime { get; set; }

        public int CityId { get; set; }
        public int RouteId { get; set; }
    }
}