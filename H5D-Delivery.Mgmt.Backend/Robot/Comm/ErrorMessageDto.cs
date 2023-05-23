using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Error;

namespace H5D_Delivery.RoboSim
{
    public class ErrorMessageDto
    {
        public Guid deliveryId { get; set; }
        public int step { get; set; }
        public string type { get; set; }

        public ErrorMessage ConvertToErrorMessage()
        {
            return new ErrorMessage(Guid.NewGuid(), this.deliveryId, this.step, CastErrorType(type), DateTime.Now);
        }

        private ErrorType CastErrorType(string error)
        {
            switch (error)
            {
                case "personNotAtHome": return ErrorType.PersonNotAtHome;
                case "personNotAuthorized": return ErrorType.PersonNotAuthorized;
                case "cannotDeposit": return ErrorType.CannotDeposit;
                case "blockedEntrance": return ErrorType.BlockedEntrance;
                case "cannotMove": return ErrorType.CannotMove;
                case "navigationError": return ErrorType.NavigationError;
                case "outOfBattery": return ErrorType.OutOfBattery;
                case "pickMeUpImScared": return ErrorType.PickMeUpImScared;
                default: return ErrorType.NoError;
            }
        }
    }
}
