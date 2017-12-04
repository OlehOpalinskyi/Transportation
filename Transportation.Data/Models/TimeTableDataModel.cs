using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transportation.Data.Models
{
    [Table("TimeTable")]
    public class TimeTableDataModel
    {
        public int Id { get; set; }
        public int BusId { get; set; }
        public int RouteId { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan Time { get; set; }

        [ForeignKey("BusId")]
        public virtual BusDataModel Bus { get; set; }
        [ForeignKey("RouteId")]
        public virtual RouteDataModel Route { get; set; }
    }
}
