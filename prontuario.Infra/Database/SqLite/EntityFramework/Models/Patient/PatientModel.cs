using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Address;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.EmergencyContactDetails;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Service;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.Patient
{
    [Table("Patients")]
    public class PatientModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; private set; }

        [MaxLength(150)]
        public string Name { get; private set; } = string.Empty;
        
        [MaxLength(150)]
        public string? SocialName { get; private set; } 
        
        [Column(TypeName = "Date")]
        public DateTime? BirthDate { get; private set; }

        [MaxLength(15)]
        public string? Sus { get; private set; } 

        [MaxLength(15)]
        public string Cpf { get; private set; } = string.Empty;

        [MaxLength(15)]
        public string? Rg { get; private set; } 
        
        [MaxLength(30)]
        public string? Status { get; private set; } 

        [MaxLength(15)]
        public string? Phone { get; private set; } 
        
        [MaxLength(150)]
        public string? MotherName { get; private set; } 
        public AddressModel AddressModel { get; private set; } = null!;
        public EmergencyContactDetailsModel EmergencyContactDetailsModel { get; private set; } = null!;
        public ICollection<ServiceModel>? ServicesModel { get; private set; }
        public PatientModel() { }
        public PatientModel(
            long? id,
            string name,
            string? socialName,
            DateTime? birthDate,
            string? sus,
            string cpf,
            string? rg,
            string? phone,
            string? motherName,
            string? status,
            AddressModel addressModel,
            EmergencyContactDetailsModel emergencyContactDetailsModel,
            ICollection<ServiceModel>? servicesModel)
        {
            this.Id = id;
            this.Name = name;
            this.SocialName = socialName;
            this.BirthDate = birthDate;
            this.Sus = sus;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Phone = phone;
            this.MotherName = motherName;
            this.Status = status;
            this.AddressModel = addressModel;
            this.EmergencyContactDetailsModel = emergencyContactDetailsModel;
            this.ServicesModel = servicesModel;
        }
    }
}
