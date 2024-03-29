﻿namespace H5D_Delivery.Mgmt.Backend.Shared.Persistence
{
    public interface IRepositoryBase<T> where T : DbItem
    {
        IEnumerable<T>? GetAll();

        T? Get(Guid id);

        void Update(T dbItem);

        void Delete(Guid id);

        void Create(T dbItem);
    }
}
