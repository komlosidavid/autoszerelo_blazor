using autoszerelo_backend.Entities;

namespace autoszerelo_backend.Requests
{
    public class CreateCarRequest
    {
        public string Type { get; set; }
        public Guid OwnerId { get; set; }
        public string Licence { get; set; }
        public int BuiltYear { get; set; }
        public WorkCategory WorkCategory { get; set; }
        public string ProblemDescription { get; set; }
        public int FaultWeight { get; set; }
    }
}