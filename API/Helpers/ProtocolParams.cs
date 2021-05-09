namespace API.Helpers
{
    public class ProtocolParams : PaginationParams
    {
        public int id {get; set;}
        public string ProtocolName { get; set; }
        public string CreatorUsername { get; set; }
    }
}