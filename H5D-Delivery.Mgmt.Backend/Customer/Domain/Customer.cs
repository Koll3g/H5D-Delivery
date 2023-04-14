using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Customer.Domain
{
    public class Customer : DbItem
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(Guid id, string name, string address, string eMail, string phoneNumber) : base(id)
        {
            Name = name;
            Address = address;
            EMail = eMail;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{Id}, {Name}, {Address}, {EMail}, {PhoneNumber}";
        }
    }
}
