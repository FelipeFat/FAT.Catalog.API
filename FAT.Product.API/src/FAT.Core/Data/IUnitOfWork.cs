using System.Threading.Tasks;

namespace FAT.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}