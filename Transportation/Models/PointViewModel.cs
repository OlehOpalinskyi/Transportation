using System;

namespace Transportation.Models
{
    public class PointViewModel : PointUpdateModel
    {
        public int Id { get; set; }
        public string Point { get; set; }
    }

    public class PointUpdateModel
    {
        public double Price { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public int CityId { get; set; }
    }
}