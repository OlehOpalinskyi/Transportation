using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transportation.Models
{
    public class RouteViewModel
    {
        public int Id { get; set; }
        public string PointA { get; set; }
        public string PointB { get; set; }
        public double Price { get; set; }
    }
}