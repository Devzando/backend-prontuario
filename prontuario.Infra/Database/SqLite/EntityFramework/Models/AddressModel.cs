using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models
{
    [Table("Addresses")]
    public class AddressModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(11)]
        public string Cep { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Street { get; set; } = string.Empty;

        [Required]
        [MaxLength(60)]
        public string City { get; set; } = string.Empty;
        [Required]
        public long Number { get; set; } = 0;

        [Required]
        public long PatientId { get; set; }

        [ForeignKey("PatientId")]
        [Column("Patient_Id")]
        public PatientModel PatientModel { get; set; } = null!;


        public AddressModel() { }
        public AddressModel(
            long id,
            string cep,
            string street,
            string city,
            long number)
        {
            this.Id = id;
            this.Cep = cep;
            this.Street = street;
            this.City = city;
            this.Number = number;
        }
        public AddressModel(
            string cep,
            string street,
            string city,
            long number)
        {
            this.Cep = cep;
            this.Street = street;
            this.City = city;
            this.Number = number;
        }
    }
}
