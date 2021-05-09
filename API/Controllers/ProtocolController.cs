using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class ProtocolController : BaseApiController
    {
        private readonly IProtocolRepository _protocolRepository;
        private readonly IMapper _mapper;
        public ProtocolController(IProtocolRepository protocolRepository, IMapper mapper)
        {
            _mapper = mapper;
            _protocolRepository = protocolRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ProtocolDto>> CreateProtocol(ProtocolDto protocolDto)
        {
            var username = User.GetUsername();

            var protocol = new Protocol
            {
                CreatorUsername = username,
                CreatorId = User.GetUserId(),
                ProtocolName = protocolDto.ProtocolName
            };

            _protocolRepository.AddProtocol(protocol);

            if (await _protocolRepository.SaveAllAsync()) return Ok(_mapper.Map<ProtocolDto>(protocol));

            return BadRequest("Failed to create protocol");

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProtocolDto>>> GetProtocols([FromQuery] ProtocolParams protocolParams)
        {
            var protocols = await _protocolRepository.GetProtocols(protocolParams);
            Response.AddPaginationHeader(protocols.CurrentPage, protocols.PageSize, protocols.TotalCount, protocols.TotalPages);

            return protocols;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Protocol>> GetProtocol(int id)
        {
            var protocol = await _protocolRepository.GetProtocol(id);

            return protocol;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProtocol(int id, ProtocolUpdateDto protocolUpdateDto)
        {
            var protocol = await _protocolRepository.GetProtocol(id);
            protocol.ProtocolName = protocolUpdateDto.ProtocolName;
            protocol.ModifiedAt = protocolUpdateDto.ModifiedAt;

            _protocolRepository.Update(protocol);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProtocol(int id)
        {
            var protocol = await _protocolRepository.GetProtocol(id);
            protocol.Deleted = true;
            _protocolRepository.DeleteProtocol(protocol);

            return Ok(protocol);
        }
    }
}