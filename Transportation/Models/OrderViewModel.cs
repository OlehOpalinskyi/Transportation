using System;
using Transportation.Data.Models;

namespace Transportation.Models
{
    public class OrderViewModel : OrderUpdateModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public PaymentStatus Pay { get; set; }
        public new string PointA { get; set; }
        public new string PointB { get; set; }

    }

    public class OrderUpdateModel
    {
        public int PointA { get; set; }
        public int PointB { get; set; }
        public DateTime Date { get; set; }
        public int TimeTableId { get; set; }

        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
    }
}