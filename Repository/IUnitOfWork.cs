using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork : IRepository
    {
        int Save();
        Task<int> SaveAsync();
    }
}
