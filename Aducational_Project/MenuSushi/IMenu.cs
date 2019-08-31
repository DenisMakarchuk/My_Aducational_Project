using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiMenu
{
    interface IMenu
    {
        string Name { get; set; }

        float Weight { get; set; }

        float Cost { get; set; }

        int Things { get; set; }

        bool HalfOrFull { get; set; }
    }
}
