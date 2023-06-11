namespace Autoszerelo.Models.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Work
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CarId { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public float WorkHours { get; set; }

        [Required]
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        [Required]
        public Car Car { get; set; }

        [Required]
        public Client Client { get; set; }
    }
}
