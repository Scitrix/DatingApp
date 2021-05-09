using System;

namespace API.DTOs
{
    public class ProtocolUpdateDto
    {
        public string ProtocolName { get; set; }
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}