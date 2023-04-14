using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;
using H5D_Delivery.Mgmt.Backend.Stock.Domain;

namespace H5D_Delivery.Mgmt.Backend.Stock.Persistence
{
    public class StockRepository : RepositoryBase<StockItem>, IStockRepository
    {
        public StockRepository(StockContext stockContext) : base(stockContext) { }
    }
}
