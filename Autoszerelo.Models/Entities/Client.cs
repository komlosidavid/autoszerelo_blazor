namespace Autoszerelo.Models.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Client
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
