using System;
using System.Collections.Generic;
using System.Linq;
using Transportation.Data;
using Transportation.Data.Models;
using Transportation.Interfaces;
using Transportation.Models;
using static AutoMapper.Mapper;

namespace Transportation.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _db;

        public OrderService(DataContext context)
        {
            _db = context;
        }

        public IEnumerable<OrderViewModel> GetOrders()
        {
            var dataOrders = _db.Orders;
            return Map<IEnumerable<OrderViewModel>>(dataOrders);
        }

        public OrderViewModel GetOrder(int id)
        {
            var dataOrder = _db.Orders.Single(o => o.Id == id);
            return Map<OrderViewModel>(dataOrder);
        }

        public OrderViewModel CreateOrder(OrderUpdateModel order)
        {
            var dataOrder = Map<OrderDataModel>(order);
            var timeTable = _db.TimeTable.SingleOrDefault(t => t.Id == order.TimeTableId);
            dataOrder.TimeTable = timeTable;
            dataOrder.Pay = PaymentStatus.Unpaid;
            dataOrder.Price = GetPrice(timeTable.Route, order.PointA, order.PointB);
            _db.Orders.Add(dataOrder);
            _db.SaveChanges();

            return Map<OrderViewModel>(dataOrder);
        }

        private bool CheckCity(ref string err, RouteDataModel route, int pointA, int pointB)
        {
            var isPointA = route.Points.SingleOrDefault(p => p.City.Id == pointA);
            var isPointB = route.Points.SingleOrDefault(p => p.City.Id == pointB);
            if (isPointA == null || isPointB == null)
            {
                err = "Incorrect route";
                return false;
            }
            else
                return true;
        }

        private bool CheckDate(ref string err, DateTime date, TimeTableDataModel timeTable)
        {
            if (date.DayOfWeek != timeTable.Day || date.TimeOfDay != timeTable.Time)
            {
                err = "Incorrect date";
                return false;
            }
            else return true;
        }

        private bool isAvailable(ref string err, OrderUpdateModel order)
        {
            var orders = _db.Orders.Where(o => o.Date == order.Date && o.TimeTableId == order.TimeTableId).ToList();
            var reservedPlaces = orders.Count;
            var countOfPlaces = _db.TimeTable.Single(t => t.Id == order.TimeTableId).Bus.CountOfPassengers;
            if (reservedPlaces == countOfPlaces)
            {
                var pointsOfOrder = orders.First().TimeTable.Route.Points.ToList();
                var startIndex = pointsOfOrder.FindIndex(x => x.CityId == order.PointA);
                foreach(var item in orders)
                {
                    var endIndex = pointsOfOrder.FindIndex(x => x.CityId == item.PointB);
                    if (endIndex <= startIndex)
                        return true;
                }
                err = "There are no vacancies";
                return false;
            }
            else return true;
        }

        public string Validate(OrderUpdateModel order)
        {
            var err = string.Empty;
            var timeTable = _db.TimeTable.SingleOrDefault(t => t.Id == order.TimeTableId);
            var route = timeTable.Route;
            if (timeTable == null)
                err = "Incorrect date";
            CheckCity(ref err, route, order.PointA, order.PointB);
            CheckDate(ref err, order.Date, timeTable);
            isAvailable(ref err, order);

            return err;
        }

        private double GetPrice(RouteDataModel route, int pointA, int pointB)
        {
            var price1 = route.Points.Single(p => p.City.Id == pointA).Price;
            var price2 = route.Points.Single(p => p.City.Id == pointB).Price;
            return price2 - price1;
        }
    }
}