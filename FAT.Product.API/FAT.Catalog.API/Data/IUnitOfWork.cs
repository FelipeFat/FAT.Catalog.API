using System.Threading.Tasks;

namespace FAT.Catalog.API.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}