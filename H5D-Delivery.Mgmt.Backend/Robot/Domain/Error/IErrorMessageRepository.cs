using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain.Error
{
    public interface IErrorMessageRepository : IRepositoryBase<ErrorMessage>
    {
        public IEnumerable<ErrorMessage>? GetAllForSpecificRobot(Guid robotId);

        public IEnumerable<ErrorMessage>? GetXNewest(uint amount);

        public IEnumerable<ErrorMessage>? GetXNewestForSpecificRobot(Guid robotId, uint amount);
    }
}
