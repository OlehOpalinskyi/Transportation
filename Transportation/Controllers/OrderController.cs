using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Transportation.Interfaces;
using Transportation.Models;

namespace Transportation.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrderController : ApiController
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [Route("")]
        public IEnumerable<OrderViewModel> GetOrders()
        {
            return _service.GetOrders();
        }

        [Route("{id}")]
        public OrderViewModel GetOrder(int id)
        {
            return _service.GetOrder(id);
        }
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(OrderViewModel))]
        public IHttpActionResult CreateOrder(OrderViewModel order)
        {
            var isValid = _service.Validate(order);
            if (isValid != string.Empty)
                return Content(HttpStatusCode.BadRequest, isValid);
            return Ok(_service.CreateOrder(order));
        }
    }
}
