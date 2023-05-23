using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Delivery.Domain;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Comm
{
    public class CoordinateDto
    {
        public int x { get; set; }
        public int y { get; set; }

        public CoordinateDto(Coordinates coordinates)
        {
            x = coordinates.X;
            y = coordinates.Y;
        }
    }
}
