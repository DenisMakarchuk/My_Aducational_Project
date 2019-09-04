using System;
using MenuSushi;
using System.Collections.Generic;
using Logs;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Order
{
    interface IOrderMakeRepository
    {
        void AddSushiInOrder(Sushi sushi);

        void GetSushisInOrder();

        void UpdateSushiInOrder(int id, SushiRepository sushis);

        void DeleteSushiFromOrder(int id);
    }
}
