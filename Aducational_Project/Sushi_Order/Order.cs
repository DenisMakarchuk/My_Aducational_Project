using System;
using SushiMenu;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Order
{
    class Order
    {
        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public string Address { get; set; }

        public List<Sushi> OrderSushi { get; set; }

        public int TotalSum { get; set; }

        public Order (string name, int phone, string address, List<Sushi> order, int sum)
        {
            Name = name;
            PhoneNumber = phone;
            Address = address;
            OrderSushi = order;
            TotalSum = sum;
        }
    }
}
