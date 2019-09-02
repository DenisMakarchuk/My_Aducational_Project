using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiMenu
{
    interface ISushiRepository
    {
        void CreateSushi(Sushi sushi);

        Sushi GetSushiById(int id);

        void GetSushis();

        void UpdateSushi(Sushi sushi);

        void DeleteSushi(int id);
    }
}
