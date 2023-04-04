using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Customer.Exceptions;
using System.Net;

namespace H5D_Delivery.Mgmt.Backend.Customer.Domain
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private static readonly string addressPattern = @"^Zbw-Strasse [1-4]$";
        private static readonly string phonePattern = @"^\d*$";
        private static readonly string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        public CustomerService(IContainer iocContainer)
        {
            _customerRepository = iocContainer.Resolve<ICustomerRepository>();
        }

        public IEnumerable<Customer> GetAll(Guid id)
        {
            return _customerRepository.GetAll(id);
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
                throw new AddressInvalidException($"Address must have format {addressPattern}");
            }

            if (!IsEMailValid(customer.EMail))
            {
                throw new EmailInvalidException($"E-Mail must have format {emailPattern}");
            }

            if (!IsPhoneNumberValid(customer.PhoneNumber))
            {
                throw new EmailInvalidException($"E-Mail must have format {emailPattern}");
            }

            return true;
        }

        private static bool IsAddressValid(string address)
        {
            var regex = new Regex(addressPattern);
            return regex.IsMatch(address);
        }

        private static bool IsEMailValid(string email)
        {
            var regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }

        private static bool IsPhoneNumberValid(string phoneNumber)
        {
            var regex = new Regex(phonePattern);
            return regex.IsMatch(phoneNumber);
        }
    }
}
