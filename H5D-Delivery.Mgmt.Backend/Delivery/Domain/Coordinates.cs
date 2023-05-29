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

        public static Coordinates Empty => new(0,0);

        public static int CalculateDistance(Coordinates point1, Coordinates point2)
        {
            int deltaX = point2.X - point1.X;
            int deltaY = point2.Y - point1.Y;

            int distanceSquared = (deltaX * deltaX) + (deltaY * deltaY);
            int distance = (int)Math.Sqrt(distanceSquared);

            return distance;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Coordinates other = (Coordinates)obj;
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Coordinates left, Coordinates right)
        {
            if (ReferenceEquals(left, right))
                return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;
            return left.Equals(right);
        }

        public static bool operator !=(Coordinates left, Coordinates right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"X:{X},Y:{Y} [mm]";
        }
    }
}
