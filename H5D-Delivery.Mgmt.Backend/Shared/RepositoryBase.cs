using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Customer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace H5D_Delivery.Mgmt.Backend.Shared
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : DbItem
    {
        private readonly DbContextBase<T> _dbContext;

        protected RepositoryBase(DbContextBase<T> dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
            _dbContext.Database.Migrate();
        }

        public IEnumerable<T>? GetAll()
        {
            return _dbContext.DbSet;
        }

        public T? Get(Guid id)
        {
            var dbItem = _dbContext.DbSet?.Find(id);
            if (dbItem == null)
            {
                throw new KeyNotFoundException();
            }
            return dbItem;
        }

        public void Update(T dbItem)
        {
            _dbContext.DbSet?.Update(dbItem);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var dbItem = Get(id);
            if (dbItem != null)
            {
                _dbContext.DbSet?.Remove(dbItem);
            }
            else
            {
                throw new KeyNotFoundException();
            }
            _dbContext.SaveChanges();
        }

        public void Create(T dbItem)
        {
            _dbContext.DbSet?.Add(dbItem);
            _dbContext.SaveChanges();
        }
    }
}
