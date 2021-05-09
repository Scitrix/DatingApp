using System;

namespace API.Entities
{
    public class Protocol
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string CreatorUsername { get; set; }
        public string ProtocolName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; }
        public bool Deleted { get; set; }

    }
}