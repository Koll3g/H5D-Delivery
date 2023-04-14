﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Shared;

namespace H5D_Delivery.Mgmt.Backend.Order.Persistence
{
    public class OrderRepository : RepositoryBase<Domain.Order>
    {
        public OrderRepository(OrderContext orderContext) : base(orderContext) { }
    }
}
