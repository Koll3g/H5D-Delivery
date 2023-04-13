using H5D_Delivery.Mgmt.Backend.Customer.Domain;

namespace H5D_Delivery.Mgmt.Backend.Customer.Persistence
{
    public class FakeCustomerRepository
    {
        public List<Domain.Customer> CustomerList { get; }

        public FakeCustomerRepository()
        {
            CustomerList = FillCustomerList();
        }

        private static List<Domain.Customer> FillCustomerList()
        {
            return new List<Domain.Customer>
            {
                new Domain.Customer(Guid.NewGuid(), "Amsler", "ZbW-Strasse 1", "amsler@zbw.ch", "0761234567"),
                new Domain.Customer(Guid.NewGuid(), "Fischer", "ZbW-Strasse 2", "fischer@zbw.ch", "0771234567"),
                new Domain.Customer(Guid.NewGuid(), "Müller", "ZbW-Strasse 3", "mueller@zbw.ch", "0781234567"),
                new Domain.Customer(Guid.NewGuid(), "Zwingli", "ZbW-Strasse 4", "zwingli@zbw.ch", "0791234567")
            };

        }

        public IEnumerable<Domain.Customer> GetAll()
        {
            return CustomerList;
        }

        public Domain.Customer? Get(Guid id)
        {
            var customer = CustomerList.Find((x) => x.Id.Equals(id));

            if (customer == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found");
            }
            return customer;
        }

        public void Update(Domain.Customer customer)
        {
            var index = CustomerList.IndexOf(customer);

            if (index == -1)
            {
                CustomerList[index] = customer;
            }
            else
            {
                throw new KeyNotFoundException($"User with id {customer.Id} not found");
            }
        }

        public void Delete(Guid id)
        {
            var customer = CustomerList.Find((x) => x.Id.Equals(id));
            if (customer != null)
            {
                CustomerList.Remove(customer);
            }
            else
            {
                throw new KeyNotFoundException($"User with id {id} not found");
            }
        }

        public void Create(Domain.Customer customer)
        {
            CustomerList.Add(customer);
        }
    }
}
