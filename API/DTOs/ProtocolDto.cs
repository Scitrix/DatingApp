using System;
using API.Entities;

namespace API.DTOs
{
    public class ProtocolDto
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string CreatorUsername { get; set; }
        public string ProtocolName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; }
    }
}