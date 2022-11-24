
using System.Threading.Tasks;

namespace SchoolManager.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
