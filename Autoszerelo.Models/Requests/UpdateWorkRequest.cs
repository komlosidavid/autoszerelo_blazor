using autoszerelo_backend.Entities;

namespace autoszerelo_backend.Requests
{
    public class UpdateWorkRequest
    {
        public Guid ClientId { get; set; }
        public Guid CarId { get; set; }
    }
}