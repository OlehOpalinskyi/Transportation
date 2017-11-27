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
            Cities = new List<CityDataModel>();
        }

        public int Id { get; set; }
        public string PointA { get; set; }
        public string PointB { get; set; }
        public double Price { get; set; }

        public virtual ICollection<BusDataModel> Buses { get; set; }
        public virtual ICollection<PointDataModel> Points { get; set; }
        public virtual ICollection<TimeTableDataModel> TimeTables { get; set; }
        public virtual ICollection<CityDataModel> Cities { get; set; }
    }
}
