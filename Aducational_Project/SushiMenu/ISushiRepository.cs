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

        Sushi GetSushiByName(string name);

        void GetSushis();

        void UpdateSushi(Sushi sushi);

        void DeleteSushi(string name);
    }
}
