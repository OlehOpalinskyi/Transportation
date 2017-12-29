using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Transportation.Data;
using Transportation.Data.Models;
using Transportation.Models;
using static AutoMapper.Mapper;

namespace Transportation.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrderController : ApiController
    {
        private readonly DataContext _db;

        public OrderController(DataContext db)
        {
            _db = db;
        }

        [Route("")]
        public IEnumerable<OrderViewModel> GetOrders()
        {
            var dataOrders = _db.Orders;
            return Map<IEnumerable<OrderViewModel>>(dataOrders);
        }

        [Route("{id}")]
        public OrderViewModel GetOrder(int id)
        {
            var dataOrder = _db.Orders.Single(o => o.Id == id);
            return Map<OrderViewModel>(dataOrder);
        }
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(OrderViewModel))]
        public IHttpActionResult CreateOrder(OrderViewModel order)
        {
            var isValid = Validate(order);
            if (isValid != string.Empty)
                return Content(HttpStatusCode.BadRequest, isValid);
            var dataOrder = Map<OrderDataModel>(order);
            var timeTable = _db.TimeTable.SingleOrDefault(t => t.Id == order.TimeTableId);
            dataOrder.TimeTable = timeTable;
            dataOrder.Pay = PaymentStatus.Unpaid;
            dataOrder.Price = GetPrice(timeTable.Route, order.PointA, order.PointB);
            _db.Orders.Add(dataOrder);

            return Ok(Map<OrderViewModel>(dataOrder));
        }

        private bool CheckCity(ref string err, RouteDataModel route, string pointA, string pointB)
        {
            var isPointA = route.Points.SingleOrDefault(p => p.City.Name == pointA);
            var isPointB = route.Points.SingleOrDefault(p => p.City.Name == pointB);
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

        private bool isAvailable(ref string err, OrderViewModel order)
        {
            var reservedPlaces = _db.Orders.Where(o => o.Date == order.Date && o.TimeTableId == order.TimeTableId).Count();
            var countOfPlaces = _db.TimeTable.Single(t => t.Id == order.TimeTableId).Bus.CountOfPassengers;
            if (reservedPlaces == countOfPlaces)
            {
                err = "There are no vacancies";
                return false;
            }
            else return true;
        }

        private string Validate(OrderViewModel order)
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

        private double GetPrice(RouteDataModel route, string pointA, string pointB)
        {
            var startRoute = route.Cities.First().Name;
            if (startRoute == pointA && route.Cities.Last().Name == pointB)
                return route.Price;
            if(startRoute == pointA)
                return route.Points.Single(p => p.City.Name == pointB).Price;

            var price1 = route.Points.Single(p => p.City.Name == pointA).Price;
            var price2 = route.Points.Single(p => p.City.Name == pointB).Price;
            return price2 - price1;
        }
    }
}
