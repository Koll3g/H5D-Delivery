using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Shared
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : DbItem
    {
        public void Create(T dbItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public T? Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T dbItem)
        {
            throw new NotImplementedException();
        }
    }
}
