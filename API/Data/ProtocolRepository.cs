using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProtocolRepository : IProtocolRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProtocolRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddProtocol(Protocol protocol)
        {
            _context.Protocols.Add(protocol);
        }

        public void DeleteProtocol(Protocol protocol)
        {
            _context.Protocols.Remove(protocol);
        }

        public async Task<Protocol> GetProtocol(int id)
        {
            return await _context.Protocols
                .SingleOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<PagedList<ProtocolDto>> GetProtocols(ProtocolParams protocolParams)
        {
            var query = _context.Protocols
                .OrderByDescending(m => m.CreatedAt)
                .ProjectTo<ProtocolDto>(_mapper.ConfigurationProvider)
                .AsQueryable();

            return await PagedList<ProtocolDto>.CreateAsync(query, protocolParams.PageNumber, protocolParams.PageSize);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Protocol protocol)
        {
            _context.Entry(protocol).State = EntityState.Modified;
        }

    }
}