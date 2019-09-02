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
        //public static List<Sushi> OrderSushi = new List<Sushi>();

        public int Id { get; set; }

        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public string Address { get; set; }

        public List<Sushi> OrderSushi { get; set; }

        public float TotalSum { get; set; }

        public Order (string name, int phone, string address, List<Sushi> sushiOrder, float sum)
        {
            Name = name;
            PhoneNumber = phone;
            Address = address;
            OrderSushi = sushiOrder;
            TotalSum = sum;
        }
    }
}
