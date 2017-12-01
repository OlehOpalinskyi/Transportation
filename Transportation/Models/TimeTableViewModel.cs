using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transportation.Data.Models;

namespace Transportation.Models
{
    public class TimeTableViewModel : TimeTableUpdateModel
    {
        public int Id { get; set; }
        public string NumberBus { get; set; }
        public string PointA { get; set; }
        public string PointB { get; set; }
        public double Price { get; set; }
    }

    public class TimeTableUpdateModel
    {
        public int BusId { get; set; }
        public int RouteId { get; set; }
        public WeekDay Day { get; set; }
        public TimeSpan Time { get; set; }
    }
}