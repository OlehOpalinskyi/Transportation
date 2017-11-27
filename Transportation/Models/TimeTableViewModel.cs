using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transportation.Data.Models;

namespace Transportation.Models
{
    public class TimeTableViewModel
    {
        public int Id { get; set; }
        public int BusId { get; set; }
        public int RouteId { get; set; }
        public WeekDay Day { get; set; }
        public TimeSpan Time { get; set; }
    }
}