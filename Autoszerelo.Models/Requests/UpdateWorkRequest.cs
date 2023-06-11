namespace Autoszerelo.Models.Requests
{
    public class UpdateWorkRequest
    {
        public Guid ClientId { get; set; }

        public Guid CarId { get; set; }
    }
}