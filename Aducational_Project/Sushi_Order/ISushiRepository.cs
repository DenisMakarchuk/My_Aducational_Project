using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Order
{
    interface ISushiRepository
    {
        void CreateSushi(Sushi sushi);

        Sushi GetSushiByID(int id);

        List<Sushi> Sushis();

        Sushi UpdateSushi(Sushi moto);

        void DeleteSushi(int id);
    }
}
