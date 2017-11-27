using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transportation.Data.Models
{
    [Table("Bases")]
    public class BusDataModel
    {
        public BusDataModel()
        {
            Routes = new List<RouteDataModel>();
            TimeTables = new List<TimeTableDataModel>();
        }

        public int Id { get; set; }
        public int NumberOfBus { get; set; }
        public int CountOfPassengers { get; set; }

        public virtual ICollection<RouteDataModel> Routes { get; set; }
        public virtual ICollection<TimeTableDataModel> TimeTables { get; set; }
    }
}
