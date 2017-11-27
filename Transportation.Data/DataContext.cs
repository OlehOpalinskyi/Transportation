namespace Transportation.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }


        public virtual DbSet<BusDataModel> Buses { get; set; }
        public virtual DbSet<RouteDataModel> Routes { get; set; }
        public virtual DbSet<CityDataModel> Cities { get; set; }
        public virtual DbSet<PointDataModel> Points { get; set; }
        public virtual DbSet<OrderDataModel> Orders { get; set; }
        public virtual DbSet<TimeTableDataModel> TimeTable { get; set; }
    }
}