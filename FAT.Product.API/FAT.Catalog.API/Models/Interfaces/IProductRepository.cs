using FAT.Catalog.API.Data;

namespace FAT.Catalog.API.Models.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);

        void Add(Product product);
        void Update(Product product);
    }
}