using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Order
{
    class Sushi
    {
        public string Name { get; private set; }

        public float Weight { get; private set; }

        public float Cost { get; private set; }

        public int Things { get; set; }

        public bool HalfOrFull { get; private set; }

        public Sushi(string name, float weight, float cost, int things, bool halfOrFull)
        {
            Name = name;
            Weight = weight;
            Cost = cost;
            Things = things;
            HalfOrFull = halfOrFull;
        }
    }
}
