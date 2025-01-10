using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Patient;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.Address
{
    [Table("Addresses")]
    public class AddressModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; private set; }

        [Required]
        [MaxLength(11)]
        public string Cep { get; private set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Street { get; private set; } = string.Empty;

        [Required]
        [MaxLength(60)]
        public string City { get; private set; } = string.Empty;
        [Required]
        public long Number { get; private set; } = 0;
        
        [Required]
        [MaxLength(40)]
        public string Neighborhood { get; private set; } = string.Empty;

        [Required]
        public long PatientId { get; private set; }

        [ForeignKey("PatientId")]
        [Column("Patient_Id")]
        public PatientModel PatientModel { get; private set; } = null!;

        public AddressModel() { }
        public AddressModel(
            long? id,
            string cep,
            string street,
            string city,
            long number,
            string neighborood)
        {
            this.Id = id;
            this.Cep = cep;
            this.Street = street;
            this.City = city;
            this.Number = number;
            this.Neighborhood = neighborood;
        }
    }
}
