using prontuario.Domain.Entities.Address;
using prontuario.Domain.Entities.EmergencyContactDetails;
using prontuario.Domain.Entities.Nursing;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.Patient
{
    public class PatientEntity
    {
        public long Id { get; private set; }
        public string Name { get;  set; } = string.Empty;
        public string? SocialName { get; set; }
        public DateTime? BirthDate { get;  set; }
        public SUS Sus { get;  set; } = null!;
        public CPF Cpf { get;  set; } = null!;
        public RG Rg { get;  set; } = null!;
        public Phone Phone { get;  set; } = null!;
        public string? MotherName { get;  set; }
        public PatientStatus Status { get; set; } = null!;
        public AddressEntity AddressEntity { get;  set; } = null!;
        public ICollection<EmergencyContactDetailsEntity> EmergencyContactDetailsEntity { get; set; } = null!;
        public ICollection<ServiceEntity>? ServicesEntity { get; set; }

        public PatientEntity() { }
        public PatientEntity(
            long id,
            string name,
            string? socialName,
            DateTime? dateBirth, 
            SUS sus, 
            CPF cpf, 
            RG rg, 
            Phone phone,
            string? motherName,
            PatientStatus status,
            AddressEntity addressEntity,
            ICollection<EmergencyContactDetailsEntity> emergencyContactDetailsEntity,
            ICollection<ServiceEntity>? serviceEntities)
        {
            this.Id = id;
            this.Name = name;
            this.SocialName = socialName;
            this.BirthDate = dateBirth;
            this.Sus = sus;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Phone = phone;
            this.MotherName = motherName;
            this.Status = status;
            this.AddressEntity = addressEntity;
            this.EmergencyContactDetailsEntity = emergencyContactDetailsEntity;
            this.ServicesEntity = serviceEntities;
        }
    }
}
