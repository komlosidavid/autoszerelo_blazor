using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace autoszerelo_backend.Entities
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
