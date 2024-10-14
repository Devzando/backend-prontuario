using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models
{
    [Table("Patients")]
    public class PatientModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; private set; } = string.Empty;

        [Required]
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; private set; }

        [Required]
        [MaxLength(15)]
        public string Sus { get; private set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        public string Cpf { get; private set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        public string Rg { get; private set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        public string Phone { get; private set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; private set; }
        public AddressModel AddressModel { get; private set; } = null!;
        public EmergencyContactDetailsModel EmergencyContactDetailsModel { get; private set; } = null!;
        public ICollection<ServiceModel> ServicesModel { get; private set; } = null!;
        public PatientModel() { }
        public PatientModel(
            long id,
            string name,
            DateTime birthDate,
            string sus,
            string cpf,
            string rg,
            string phone,
            AddressModel addressModel,
            EmergencyContactDetailsModel emergencyContactDetailsModel,
            ICollection<ServiceModel> servicesModel)
        {
            this.Id = id;
            this.Name = name;
            this.BirthDate = birthDate;
            this.Sus = sus;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Phone = phone;
            this.AddressModel = addressModel;
            this.EmergencyContactDetailsModel = emergencyContactDetailsModel;
            this.ServicesModel = servicesModel;
        }
        public PatientModel(
            string name,
            DateTime birthDate,
            string sus,
            string cpf,
            string rg,
            string phone,
            AddressModel addressModel,
            EmergencyContactDetailsModel emergencyContactDetailsModel)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.Sus = sus;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Phone = phone;
            this.AddressModel = addressModel;
            this.EmergencyContactDetailsModel = emergencyContactDetailsModel;
        }
    }
}
