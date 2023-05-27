using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryPlanFactory
{
    public static class WaypointCoordinates
    {
        public static Coordinates DistributionCenter => new Coordinates(0, 0);
        public static Coordinates ZbwStrasse1 => new Coordinates(1100, 1000);
        public static Coordinates ZbwStrasse2 => new Coordinates(2000, 1000);
        public static Coordinates ZbwStrasse3 => new Coordinates(2900, 1000);
        public static Coordinates ZbwStrasse4 => new Coordinates(4000, 0);
        public static Coordinates WaypointStrasse1AndDistributionCenter => new Coordinates(1100, 0);
        public static Coordinates WaypointStrasse2 => new Coordinates(2000, 0);
        public static Coordinates WaypointStrasse3And4 => new Coordinates(2900, 1000);
        public static Coordinates Parkposition => new Coordinates(0, -800);
        public static Coordinates WaypointParkposition => new Coordinates(1100, -800);

        public static Coordinates Empty => new Coordinates(0, 0);
    }
}
