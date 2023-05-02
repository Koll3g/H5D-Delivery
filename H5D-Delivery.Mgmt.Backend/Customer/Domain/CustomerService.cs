using System.Text.RegularExpressions;
using H5D_Delivery.Mgmt.Backend.Customer.Exceptions;

namespace H5D_Delivery.Mgmt.Backend.Customer.Domain
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private const string AddressPattern = @"^Zbw-Strasse [1-4]$";
        private const string PhonePattern = @"^\d*$";
        private const string EmailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer>? GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer? Get(Guid id)
        {
            return _customerRepository.Get(id);
        }

        public void Update(Customer customer)
        {
            _customerRepository.Update(customer);
        }

        public void Delete(Guid id)
        {
            _customerRepository.Delete(id);
        }

        public void Create(Domain.Customer customer)
        {
            if (!IsCustomerValid(customer))
            {
                return;
            }
            _customerRepository.Create(customer);
        }

        private static bool IsCustomerValid(Customer customer)
        {
            if (!IsAddressValid(customer.Address))
            {
                throw new AddressInvalidException($"Address must have format {AddressPattern}");
            }

            if (!IsEMailValid(customer.EMail))
            {
                throw new EmailInvalidException($"E-Mail must have format {EmailPattern}");
            }

            if (!IsPhoneNumberValid(customer.PhoneNumber))
            {
                throw new PhoneNumberInvalidException($"PhoneNumber must have format {PhonePattern}");
            }

            return true;
        }

        private static bool IsAddressValid(string address)
        {
            var regex = new Regex(AddressPattern);
            return regex.IsMatch(address);
        }

        private static bool IsEMailValid(string email)
        {
            var regex = new Regex(EmailPattern);
            return regex.IsMatch(email);
        }

        private static bool IsPhoneNumberValid(string phoneNumber)
        {
            var regex = new Regex(PhonePattern);
            return regex.IsMatch(phoneNumber);
        }

    }
}
