using System;

namespace Transportation.Models
{
    public class TimeTableViewModel : DateTrip
    {
        public int Id { get; set; }
        public string NumberBus { get; set; }
        public string RouteName { get; set; }
        public double Price { get; set; }
    }

    public class TimeTableUpdateModel : DateTrip
    {
        public int BusId { get; set; }
        public int RouteId { get; set; }
    }

    public class DateTrip
    {
        public DayOfWeek Day { get; set; }
        public TimeSpan Time { get; set; }
    }
}