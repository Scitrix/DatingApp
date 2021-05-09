using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IProtocolRepository
    {
        void Update(Protocol protocol);
        void AddProtocol(Protocol protocol);
        void DeleteProtocol(Protocol protocol);
        Task<PagedList<ProtocolDto>> GetProtocols(ProtocolParams protocolParams);
        Task<Protocol> GetProtocol(int id);
        Task<bool> SaveAllAsync();
    }
}