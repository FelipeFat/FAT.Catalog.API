using FAT.Core.DomainObjects;

namespace FAT.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        
    }
}