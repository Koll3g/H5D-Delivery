using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Shared
{
    public abstract class DbItem : IEqualityComparer<DbItem>
    {
        public Guid Id { get; set; }

        protected DbItem(Guid id)
        {
            Id = id;
        }

        public bool Equals(DbItem? x, DbItem? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(DbItem obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
