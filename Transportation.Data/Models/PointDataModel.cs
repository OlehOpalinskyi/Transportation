using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transportation.Data.Models
{
    [Table("Points")]
    public class PointDataModel
    {
        public int Id { get; set; }
        public string Point { get; set; }
        public double Price { get; set; }
        public TimeSpan ArrivalTime { get; set; }

        public int CityId { get; set; }
        public int RouteId { get; set; }

        [ForeignKey("CityId")]
        public virtual CityDataModel City { get; set; }
        [ForeignKey("RouteId")]
        public virtual RouteDataModel Route { get; set; }
    }
}
