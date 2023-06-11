namespace Autoszerelo.Models.Requests
{
    public class CreateWorkRequest
    {
        public Guid ClientId { get; set; }

        public Guid CarId { get; set; }
    }
}