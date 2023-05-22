using H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain.Error
{
    public class ErrorService
    {
        private readonly IErrorMessageRepository _errorMessageRepository;

        public ErrorService(IErrorMessageRepository errorMessageRepository)
        {
            _errorMessageRepository = errorMessageRepository;
        }

        public IEnumerable<ErrorMessage>? GetAllForSpecificRobot(Guid robotId)
        {
            return _errorMessageRepository.GetAllForSpecificRobot(robotId);
        }

        public IEnumerable<ErrorMessage>? GetXNewestForSpecificRobot(Guid robotId, uint amount)
        {
            return _errorMessageRepository.GetXNewestForSpecificRobot(robotId, amount);
        }

        public IEnumerable<ErrorMessage>? GetXNewest(uint amount)
        {
            return _errorMessageRepository.GetXNewest(amount);
        }

        public IEnumerable<ErrorMessage>? GetAll()
        {
            return _errorMessageRepository.GetAll();
        }

        public void Create(ErrorMessage errorMessage)
        {
            _errorMessageRepository.Create(errorMessage);
        }
    }
}
