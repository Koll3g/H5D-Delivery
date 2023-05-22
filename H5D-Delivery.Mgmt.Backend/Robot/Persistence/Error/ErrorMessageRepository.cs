using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Error;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Robot.Persistence.Error
{
    public class ErrorMessageRepository : RepositoryBase<ErrorMessage>, IErrorMessageRepository
    {
        public ErrorMessageRepository(ErrorMessageContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<ErrorMessage>? GetAllForSpecificRobot(Guid robotId)
        {
            return _dbContext.DbSet?
                .Where(bc => bc.RobotId == robotId);
        }

        public IEnumerable<ErrorMessage>? GetXNewest(uint amount)
        {
            return _dbContext.DbSet?
                .OrderByDescending(bc => bc.DateTime)
                .Take((int)amount);
        }

        public IEnumerable<ErrorMessage>? GetXNewestForSpecificRobot(Guid robotId, uint amount)
        {
            return _dbContext.DbSet?
                .Where(bc => bc.RobotId == robotId)
                .OrderByDescending(bc => bc.DateTime)
                .Take((int)amount);
        }
    }
}
