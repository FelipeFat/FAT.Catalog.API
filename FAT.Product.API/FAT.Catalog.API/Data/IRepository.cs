using FAT.Catalog.API.Models.Interfaces;

namespace FAT.Catalog.API.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        
    }
}