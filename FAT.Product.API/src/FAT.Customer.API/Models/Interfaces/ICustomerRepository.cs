using FAT.Core.Data;
using FAT.Customers.API.Models;

namespace FAT.Catalog.API.Models.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(Guid id);

        void Add(Customer customer);
        void Update(Customer customer);
    }
}