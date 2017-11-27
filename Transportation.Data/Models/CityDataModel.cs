using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transportation.Data.Models
{
    [Table("Cities")]
    public class CityDataModel
    {
        public CityDataModel()
        {
            Routes = new List<RouteDataModel>();
            Points = new List<PointDataModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RouteDataModel> Routes { get; set; }
        public virtual ICollection<PointDataModel> Points { get; set; }
    }
}
