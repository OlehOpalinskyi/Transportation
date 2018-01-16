using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transportation.Data.Models
{
    [Table("Routes")]
    public class RouteDataModel
    {
        public RouteDataModel()
        {
            Buses = new List<BusDataModel>();
            Points = new List<PointDataModel>();
            TimeTables = new List<TimeTableDataModel>();
        }

        public int Id { get; set; }
        public double Price { get; set; }
        public string RouteName { get; set; }

        public virtual ICollection<BusDataModel> Buses { get; set; }
        public virtual ICollection<PointDataModel> Points { get; set; }
        public virtual ICollection<TimeTableDataModel> TimeTables { get; set; }
    }
}
