using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transportation.Data.Models
{
    [Table("Cities")]
    public class CityDataModel
    {
        public CityDataModel()
        {
            Points = new List<PointDataModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PointDataModel> Points { get; set; }
    }
}
