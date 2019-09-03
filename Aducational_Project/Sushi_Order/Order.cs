using System;
using SushiMenu;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Order
{
    enum TheDayOfWeek
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    class Order
    {
        public TheDayOfWeek dayOfWeek { get; set; }

        public DateTime dateTime = DateTime.Now.ToLocalTime();

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
            OrderSushi = new List<Sushi>(sushiOrder);
            TotalSum = sum;
        }
    }
}
