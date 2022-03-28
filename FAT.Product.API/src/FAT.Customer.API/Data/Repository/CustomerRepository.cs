using FAT.Catalog.API.Models.Interfaces;
using FAT.Core.Data;
using FAT.Customers.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FAT.Customers.API.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customer> GetById(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}