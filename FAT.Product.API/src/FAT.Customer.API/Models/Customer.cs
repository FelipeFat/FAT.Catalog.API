using FAT.Core.DomainObjects;

namespace FAT.Customers.API.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public bool Deleted { get; private set; }
        public Address Address { get; private set; }

        // EF Relation
        protected Customer() { }

        public Customer(string name, Email email, Cpf cpf)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
            Deleted = false;
        }

        public void ChangeEmail(string email)
        {
            Email = new Email(email);
        }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }
    }
}
