using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Delivery.Domain;

namespace H5D_Delivery.Mgmt.Backend.Robot.Comm
{
    public class CurrentPositionDto
    {
        public int x { get; set; }
        public int y { get; set; }

        public CurrentPositionDto(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Coordinates ConvertToCoordinates()
        {
            return new Coordinates(this.x, this.y);
        }
    }
}
