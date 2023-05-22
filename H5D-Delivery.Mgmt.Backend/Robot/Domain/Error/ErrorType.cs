using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain.Error
{
    public enum ErrorType
    {
        PersonNotAtHome = 0,
        PersonNotAuthorized = 1,
        CannotDeposit = 2,
        BlockedEntrance = 3,
        CannotMove = 4,
        NavigationError = 5,
        OutOfBattery = 6,
        PickMeUpImScared = 7,
        NoError = 8,
    }
}
