using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Order
{
    interface IOrdersRepo
    {
        void AddOrder(Order order);

        Order GetOrder(int id);

        Order UpdateOrder(Order order);

        List<Order> GetOrders();

        void DeleteOrder(int id);
    }
}
