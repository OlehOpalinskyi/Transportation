using System;
using Transportation.Data.Models;

namespace Transportation.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string PointA { get; set; }
        public string PointB { get; set; }
        public double Price { get; set; }
        public PaymentStatus Pay { get; set; }
        public DateTime Date { get; set; }
        public int TimeTableId { get; set; }

        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
    }
}