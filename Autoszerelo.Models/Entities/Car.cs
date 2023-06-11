namespace Autoszerelo.Models.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Type { get; set; } = "";

        [Required]
        [StringLength(7)]
        public string Licence { get; set; } = "";

        [Required]
        public int BuiltYear { get; set; }

        [Required]
        [EnumDataType(typeof(WorkCategory))]
        public WorkCategory WorkCategory { get; set; }

        [Required]
        public string ProblemDescription { get; set; } = "";

        [Required]
        public int FaultWeight { get; set; }

        [Required]
        public Guid ClientId { get; set; }
    }
}
