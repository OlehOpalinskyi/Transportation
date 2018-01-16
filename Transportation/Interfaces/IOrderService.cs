using System.Collections.Generic;
using Transportation.Models;

namespace Transportation.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderViewModel> GetOrders();
        OrderViewModel GetOrder(int id);
        OrderViewModel CreateOrder(OrderUpdateModel order);
        string Validate(OrderUpdateModel order);
    }
}
