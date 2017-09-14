using System.Threading.Tasks;
namespace Repository
{
    public interface IUnitOfWork : IRepository
    {
        /// <summary>
        /// Save all operations
        /// </summary>
        int Save();
        /// <summary>
        /// Save all operations async
        /// </summary>
        Task<int> SaveAsync();
    }
}
