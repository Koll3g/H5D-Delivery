using FakeItEasy;
using H5D_Delivery.Mgmt.Backend.Customer.Domain;
using H5D_Delivery.Mgmt.Backend.Customer.Exceptions;

namespace H5D_Delivery.Mgmt.Backend.UnitTests.Customer
{
    public class CustomerServiceTests
    {

        [Theory]
        [InlineData("Zbw-Strasse 1", "asdf@zbw.ch", "078456167")]
        [InlineData("Zbw-Strasse 2", "test.pfupf@gmail.com", "454078456167")]
        [InlineData("Zbw-Strasse 3", "test_test@zbw.org", "1674654")]
        [InlineData("Zbw-Strasse 4", "test@blue.at", "455545078456167")]
        public void Create_ProvidedWithValidCustomer_CallsCustomerRepo(string address, string email, string phone)
        {
            //Arrange
            var customerRepository = A.Fake<ICustomerRepository>();
            var customerService = new CustomerService(customerRepository);
            var customer = new Backend.Customer.Domain.Customer(new Guid(), "Hans", address, email, phone);

            //Act
            customerService.Create(customer);

            //Assert
            A.CallTo(() => customerRepository.Create(customer)).MustHaveHappened();
        }

        [Theory]
        [InlineData("Züristrasse 4")]
        [InlineData("@awef 4")]
        [InlineData("14")]
        [InlineData("Zbw-Strasse4")]
        [InlineData("Zbw-Strasse 5")]
        [InlineData("")]
        public void Create_ProvidedWithInValidAddress_ThrowsAddressExceptionAndDoesNotCallRepo(string address)
        {

            //Arrange
            var customerRepository = A.Fake<ICustomerRepository>();
            var customerService = new CustomerService(customerRepository);
            var customer = new Backend.Customer.Domain.Customer(new Guid(), "Hans", address, "info@gmail.com", "46574841");

            //Act
            var act = () => customerService.Create(customer);
            
            //Assert
            var ex = Assert.Throws<AddressInvalidException>(act);
            Assert.IsType<AddressInvalidException>(ex);
            A.CallTo(() => customerRepository.Create(A<Backend.Customer.Domain.Customer>._)).MustNotHaveHappened();
        }

        [Theory]
        [InlineData("123#¦")]
        [InlineData("12314")]
        [InlineData("something@tds")]
        [InlineData("einname")]
        public void Create_ProvidedWithInValidEmail_ThrowsEmailExceptionAndDoesNotCallRepo(string email)
        {

            //Arrange
            var customerRepository = A.Fake<ICustomerRepository>();
            var customerService = new CustomerService(customerRepository);
            var customer = new Backend.Customer.Domain.Customer(new Guid(), "Hans", "Zbw-Strasse 4", email, "46574841");

            //Act
            var act = () => customerService.Create(customer);

            //Assert
            var ex = Assert.Throws<EmailInvalidException>(act);
            Assert.IsType<EmailInvalidException>(ex);
            A.CallTo(() => customerRepository.Create(A<Backend.Customer.Domain.Customer>._)).MustNotHaveHappened();
        }

        [Theory]
        [InlineData("#¦")]
        [InlineData("ABC")]
        [InlineData("+74")]
        [InlineData("einname")]
        public void Create_ProvidedWithInValidPhone_ThrowsPhoneExceptionAndDoesNotCallRepo(string phone)
        {

            //Arrange
            var customerRepository = A.Fake<ICustomerRepository>();
            var customerService = new CustomerService(customerRepository);
            var customer = new Backend.Customer.Domain.Customer(new Guid(), "Hans", "Zbw-Strasse 4", "info@gmail.com", phone);

            //Act
            var act = () => customerService.Create(customer);

            //Assert
            var ex = Assert.Throws<EmailInvalidException>(act);
            Assert.IsType<EmailInvalidException>(ex);
            A.CallTo(() => customerRepository.Create(A<Backend.Customer.Domain.Customer>._)).MustNotHaveHappened();
        }

    }
}
