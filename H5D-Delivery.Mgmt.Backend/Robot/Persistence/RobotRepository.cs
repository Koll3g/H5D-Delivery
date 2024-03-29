﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Robot.Domain;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Robot.Persistence
{
    public class RobotRepository : RepositoryBase<Domain.Robot>, IRobotRepository
    {
        public RobotRepository(RobotContext dbContext) : base(dbContext)
        {
        }
    }
}
