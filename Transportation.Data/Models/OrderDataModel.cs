using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transportation.Data.Models
{
    [Table("Orders")]
    public class OrderDataModel
    {
        public int Id { get; set; }
        public int PointA { get; set; }
        public int PointB { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public PaymentStatus Pay { get; set; }
        public int TimeTableId { get; set; }

        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey("TimeTableId")]
        public virtual TimeTableDataModel TimeTable { get; set; }
    }

    public enum PaymentStatus
    {
        Unknown,
        Unpaid,
        Paid
    }
}
