using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain
{
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
