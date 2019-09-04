using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSushi
{
    interface IMenu //If we need add anythin else into menu
    {
        int Id { get; set; }

        string Name { get; set; }

        float Weight { get; set; }

        float Cost { get; set; }

        int Things { get; set; }

        bool HalfOrFull { get; set; }
    }
}
