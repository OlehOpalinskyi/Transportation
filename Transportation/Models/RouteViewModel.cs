using System.Collections.Generic;

namespace Transportation.Models
{
    public class RouteViewModel : UpdateRouteModel
    {
        public int Id { get; set; }

        public ICollection<PointViewModel> Points { get; set; }
    }

    public class UpdateRouteModel
    {
        public string PointA { get; set; }
        public string PointB { get; set; }
        public double Price { get; set; }
    }
}