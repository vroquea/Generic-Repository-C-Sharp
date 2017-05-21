using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork : IRepository
    {
        /// <summary>
        /// Save all operations
        /// </summary>
        /// <returns></returns>
        int Save();
        /// <summary>
        /// Save all operations and return a Task
        /// </summary>
        /// <returns></returns>
        Task<int> SaveAsync();
    }
}
