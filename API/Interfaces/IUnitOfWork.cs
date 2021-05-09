using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository {get; }
        IProtocolRepository ProtocolRepository{get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}